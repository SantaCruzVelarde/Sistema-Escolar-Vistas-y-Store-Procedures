using Microsoft.Data.SqlClient;
using System.Data;

namespace SistemaEscolar
{
    public partial class VentanaAcademico : Form
    {
        private string txtConexion = "Server=ELRATONVAKERO89\\SQLEXPRESS;" +
                              "Database=SistemaEscolar;" +
                              "Integrated Security=True;" +
                              "TrustServerCertificate=True;";
        public VentanaAcademico()
        {
            InitializeComponent();
        }

        public DataTable ObtieneDatosBD(string txtConsulta)
        {
            DataTable dt = new DataTable();
            SqlConnection conexion = new SqlConnection(txtConexion);

            try
            {
                conexion.Open();
                SqlDataAdapter ad = new SqlDataAdapter(txtConsulta, txtConexion);
                ad.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }

            return dt;
        }

        private void btnObtener_Click(object sender, EventArgs e)
        {

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string consulta = "SELECT * FROM vw_Academicos";
            DataTable dt = ObtieneDatosBD(consulta);
            DGV.DataSource = dt;

            if (DGV.Columns.Count > 0)
            {
                DGV.Columns["IdAcademico"].HeaderText = "ID";
                DGV.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                DGV.Columns["Apellidos"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            AgregarEditarAcademico form = new AgregarEditarAcademico();
            if (form.ShowDialog() == DialogResult.OK) btnConsultar.PerformClick();
        }   

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (DGV.SelectedRows == null || DGV.SelectedRows.Count != 1)
            {
                MessageBox.Show("Seleccione un registro.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow fila = DGV.SelectedRows[0];
            AgregarEditarAcademico form = new AgregarEditarAcademico(
                int.Parse(fila.Cells["IdAcademico"].Value.ToString()),
                fila.Cells["Nombre"].Value.ToString(),
                fila.Cells["Apellidos"].Value.ToString(),
                fila.Cells["Grado"].Value.ToString()
            );
            if (form.ShowDialog() == DialogResult.OK) btnConsultar.PerformClick();
        }

        private void botEliminar_Click(object sender, EventArgs e)
        {
            if (DGV.SelectedRows == null || DGV.SelectedRows.Count == 0) return;

            int id = int.Parse(DGV.SelectedRows[0].Cells["IdAcademico"].Value.ToString());
            string nombre = DGV.SelectedRows[0].Cells["Nombre"].Value.ToString();

            if (MessageBox.Show($"¿Eliminar al académico '{nombre}'?", "Confirmar", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            SqlConnection conn = new SqlConnection(txtConexion);
            try
            {
                conn.Open();
                SqlCommand comando = new SqlCommand("sp_EliminarAcademico", conn);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@IdAcademico", id);
                SqlCommand cmd = comando;

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Académico eliminado.", "Éxito");
                    btnConsultar.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + "\n\nPosiblemente está asignado a grupos.", "Error");
            }
            finally
            {
                if (conn != null) conn.Close();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (DGV.SelectedRows == null || DGV.SelectedRows.Count == 0) return;

            int id = int.Parse(DGV.SelectedRows[0].Cells["IdAcademico"].Value.ToString());
            string nombre = DGV.SelectedRows[0].Cells["Nombre"].Value.ToString();

            if (MessageBox.Show($"¿Eliminar al académico '{nombre}'?", "Confirmar", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            SqlConnection conn = new SqlConnection(txtConexion);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"DELETE FROM [Academico] WHERE [IdAcademico] = {id}", conn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Académico eliminado.", "Éxito");
                    btnConsultar.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + "\n\nPosiblemente está asignado a grupos.", "Error");
            }
            finally
            {
                if (conn != null) conn.Close();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormAcademico_Load(object sender, EventArgs e)
        {
            btnConsultar.PerformClick();
        }

    }
}
