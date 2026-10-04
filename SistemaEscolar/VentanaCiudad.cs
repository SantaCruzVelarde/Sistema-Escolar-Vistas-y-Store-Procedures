using Microsoft.Data.SqlClient;
using System.Data;

namespace SistemaEscolar
{
    public partial class VentanaCiudad : Form
    {
        private string txtConexion = "Server=ELRATONVAKERO89\\SQLEXPRESS;" +
                              "Database=SistemaEscolar;" +
                              "Integrated Security=True;" +
                              "TrustServerCertificate=True;";
        public VentanaCiudad()
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
            string consulta = "SELECT * FROM vw_Ciudades";

            DataTable dt = ObtieneDatosBD(consulta);
            DGV.DataSource = dt;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            AgregarEditarCiudad formDetalle = new AgregarEditarCiudad();

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
            int id = int.Parse(fila.Cells["IDCiudad"].Value.ToString());
            string nombre = fila.Cells["NombreCiudad"].Value.ToString();
            string SiglasCiudad = fila.Cells["SiglasCiudad"].Value.ToString();             
            int idEstado = int.Parse(fila.Cells["IDEstado"].Value.ToString());

            AgregarEditarCiudad formDetalle = new AgregarEditarCiudad(id, nombre, SiglasCiudad, idEstado);

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

            int idCiudad = int.Parse(DGV.SelectedRows[0].Cells["IDCiudad"].Value.ToString());
            string nombreCiudad = DGV.SelectedRows[0].Cells["NombreCiudad"].Value.ToString();

            DialogResult resultado = MessageBox.Show(
                $"¿Está seguro de eliminar la Ciudad '{nombreCiudad}'?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado != DialogResult.Yes)
                return;

            string txtEliminar = $"DELETE FROM [dbo].[Ciudad] WHERE [IDCiudad] = {idCiudad}";

            SqlConnection conexion = new SqlConnection(txtConexion);

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("sp_EliminarCiudad", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@IDCiudad", SqlDbType.Int);

                comando.Parameters.AddWithValue("@IDCiudad", idCiudad);
                comando.Parameters.AddWithValue("@NombreCiudad", nombreCiudad);

                int numeroRenglonesAfectados = comando.ExecuteNonQuery();

                if (numeroRenglonesAfectados > 0)
                {
                    MessageBox.Show("Ciudad eliminada exitosamente.", "Éxito",
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
                    "\n\nPosiblemente la Ciudad está siendo utilizada en grupos.",
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

        private void FormCiudad_Load(object sender, EventArgs e)
        {
            btnConsultar.PerformClick();
        }

    }
}
