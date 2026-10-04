using Microsoft.Data.SqlClient;
using System.Data;

namespace SistemaEscolar
{
    public partial class VentanaPais : Form
    {
        private string txtConexion = "Server=ELRATONVAKERO89\\SQLEXPRESS;" +
                              "Database=SistemaEscolar;" +
                              "Integrated Security=True;" +
                              "TrustServerCertificate=True;";
        public VentanaPais()
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
            string consulta = "SELECT * FROM vw_Paises";

            DataTable dt = ObtieneDatosBD(consulta);
            DGV.DataSource = dt;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            AgregarEditarPais formDetalle = new AgregarEditarPais();

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
            int id = int.Parse(fila.Cells["IDPais"].Value.ToString());
            string nombre = fila.Cells["NombrePais"].Value.ToString();
            string siglapais = fila.Cells["SiglaPais"].Value.ToString();

            AgregarEditarPais formDetalle = new AgregarEditarPais(id, nombre, siglapais);

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

            int idPais = int.Parse(DGV.SelectedRows[0].Cells["IDPais"].Value.ToString());
            string nombrePais = DGV.SelectedRows[0].Cells["NombrePais"].Value.ToString();

            DialogResult resultado = MessageBox.Show(
                $"¿Está seguro de eliminar la Pais '{nombrePais}'?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado != DialogResult.Yes)
                return;

            string txtEliminar = $"DELETE FROM [dbo].[Pais] WHERE [IDPais] = {idPais}";

            SqlConnection conexion = new SqlConnection(txtConexion);

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("sp_EliminarPais", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IDPais", idPais);

                int numeroRenglonesAfectados = comando.ExecuteNonQuery();

                if (numeroRenglonesAfectados > 0)
                {
                    MessageBox.Show("Pais eliminada exitosamente.", "Éxito",
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
                    "\n\nPosiblemente la Pais está siendo utilizada en grupos.",
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

        private void FormPais_Load(object sender, EventArgs e)
        {
            btnConsultar.PerformClick();
        }

    }
}
