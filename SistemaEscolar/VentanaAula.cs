using Microsoft.Data.SqlClient;
using System.Data;

namespace SistemaEscolar
{
    public partial class VentanaAula : Form
    {
       
        public VentanaAula()
        {
            InitializeComponent();
        }

        private string txtConexion = "Server=ELRATONVAKERO89\\SQLEXPRESS;" +
                             "Database=SistemaEscolar;" +
                             "Integrated Security=True;" +
                             "TrustServerCertificate=True;";

        private DataTable ObtieneDatosBD(string consulta)
        {
            DataTable dt = new DataTable();
            SqlConnection conexion = new SqlConnection(txtConexion);
            try
            {
                conexion.Open();
                SqlDataAdapter ad = new SqlDataAdapter(consulta, txtConexion);
                ad.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: " + ex.Message);
            }
            finally
            {
                if (conexion != null) conexion.Close();
            }
            return dt;
        }
    

        private void VentanaAula_Load(object sender, EventArgs e)
        {
            btnConsultar.PerformClick();
        }

        private void btnObtener_Click(object sender, EventArgs e)
        {
            string consulta = "SELECT * FROM vw_Aulas";

            DataTable dt = ObtieneDatosBD(consulta);
            DGV.DataSource = dt;

            if (DGV.Columns.Count > 0)
            {
                DGV.Columns["IDAula"].HeaderText = "ID";
                DGV.Columns["Edificio"].HeaderText = "Edificio";
                DGV.Columns["Aula"].HeaderText = "Aula";
                DGV.Columns["Piso"].HeaderText = "Piso";
                DGV.Columns["CapacidadMaxima"].HeaderText = "Capacidad Máxima";
                DGV.Columns["FechaHoraCreacion"].HeaderText = "Fecha Creación";
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string consulta = "SELECT [IDAula], [Edificio], [Aula], [Piso], " +
                              "[CapacidadMaxima], [FechaHoraCreacion] FROM [Aula]";
            DataTable dt = ObtieneDatosBD(consulta);
            DGV.DataSource = dt;

            if (DGV.Columns.Count > 0)
            {
                DGV.Columns["IDAula"].HeaderText = "ID";
                DGV.Columns["Edificio"].HeaderText = "Edificio";
                DGV.Columns["Aula"].HeaderText = "Aula";
                DGV.Columns["Piso"].HeaderText = "Piso";
                DGV.Columns["CapacidadMaxima"].HeaderText = "Capacidad Máxima";
                DGV.Columns["FechaHoraCreacion"].HeaderText = "Fecha Creación";
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            AgregarEditarAula formDetalle = new AgregarEditarAula();
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
            int id = int.Parse(fila.Cells["IDAula"].Value.ToString());
            string edificio = fila.Cells["Edificio"].Value.ToString();
            string aula = fila.Cells["Aula"].Value.ToString();
            int piso = int.Parse(fila.Cells["Piso"].Value.ToString());
            int capacidad = int.Parse(fila.Cells["CapacidadMaxima"].Value.ToString());

            AgregarEditarAula formDetalle = new AgregarEditarAula(id, edificio, aula, piso, capacidad);
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

            int id = int.Parse(DGV.SelectedRows[0].Cells["IDAula"].Value.ToString());
            string aula = DGV.SelectedRows[0].Cells["Aula"].Value.ToString();

            DialogResult resultado = MessageBox.Show(
                $"¿Está seguro de eliminar el aula '{aula}'?",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado != DialogResult.Yes) return;

            SqlConnection conexion = new SqlConnection(txtConexion);
            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("sp_EliminarAula", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IDAula", id);

                int rows = comando.ExecuteNonQuery();

                if (rows > 0)
                {
                    MessageBox.Show("Aula eliminada exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnConsultar.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message +
                    "\n\nPosiblemente el aula está siendo utilizada.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexion != null) conexion.Close();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
