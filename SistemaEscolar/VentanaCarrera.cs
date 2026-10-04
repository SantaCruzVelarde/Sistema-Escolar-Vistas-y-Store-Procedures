using Microsoft.Data.SqlClient;
using System.Data;

namespace SistemaEscolar
{
    public partial class VentanaCarrera : Form
    {
        private string txtConexion = "Server=ELRATONVAKERO89\\SQLEXPRESS;" +
                              "Database=SistemaEscolar;" +
                              "Integrated Security=True;" +
                              "TrustServerCertificate=True;";
        public VentanaCarrera()
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
            string consulta = "SELECT * FROM vw_Carreras";

            DataTable dt = ObtieneDatosBD(consulta);
            DGV.DataSource = dt;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            AgregarEditarCarrera formDetalle = new AgregarEditarCarrera();

            if (formDetalle.ShowDialog() == DialogResult.OK)
            {  
                btnConsultar.PerformClick();
            }
        }   

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (DGV.SelectedRows == null || DGV.SelectedRows.Count != 1)
            {
                MessageBox.Show("Debe seleccionar un registro para editar.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow fila = DGV.SelectedRows[0];
            int id = int.Parse(fila.Cells["IDCarrera"].Value.ToString());
            string nombre = fila.Cells["NombreCarrera"].Value.ToString();
            string siglascarrera = fila.Cells["SiglasCarrera"].Value.ToString();

            AgregarEditarCarrera formDetalle = new AgregarEditarCarrera(id, nombre, siglascarrera);

            if (formDetalle.ShowDialog() == DialogResult.OK)
            {    
                btnConsultar.PerformClick();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (DGV.SelectedRows == null || DGV.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un registro para eliminar.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idCarrera = int.Parse(DGV.SelectedRows[0].Cells["IDCarrera"].Value.ToString());
            string nombreCarrera = DGV.SelectedRows[0].Cells["NombreCarrera"].Value.ToString();
            string siglascarrera = DGV.SelectedRows[0].Cells["SiglasCarrera"].Value.ToString();

            DialogResult resultado = MessageBox.Show(
                $"¿Está seguro de eliminar la Carrera '{nombreCarrera}'?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado != DialogResult.Yes)
                return;

            string txtEliminar = $"DELETE FROM [dbo].[Carrera] WHERE [IDCarrera] = {idCarrera}";

            SqlConnection conexion = new SqlConnection(txtConexion);

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("sp_EliminarCarrera", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IDCarrera", idCarrera);

                int numeroRenglonesAfectados = comando.ExecuteNonQuery();

                if (numeroRenglonesAfectados > 0)
                {
                    MessageBox.Show("Carrera eliminada exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnConsultar.PerformClick(); 
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el registro.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción al eliminar: " + ex.Message +
                    "\n\nPosiblemente la Carrera está siendo utilizada en grupos.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormCarrera_Load(object sender, EventArgs e)
        {
            btnConsultar.PerformClick();
        }

    }
}
