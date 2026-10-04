using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaEscolar
{
    public partial class AgregarEditarAula : Form
    {
        private string txtConexion = @"Server=ELRATONVAKERO89\SQLEXPRESS;" +
                                    @"Database=SistemaEscolar;" +
                                    @"Integrated Security=True;" +
                                    @"TrustServerCertificate=True;";

        private bool esNuevo = true;
        private int idAula = 0;

        public AgregarEditarAula()
        {
            InitializeComponent();
            esNuevo = true;
            this.Text = "Nueva Aula";
        }

        public AgregarEditarAula(int id, string edificio, string aula, int piso, int capacidad)
        {
            InitializeComponent();
            esNuevo = false;
            idAula = id;

            txtEdificio.Text = edificio;
            txtAula.Text = aula;
            txtPiso.Text = piso.ToString();
            txtCapacidad.Text = capacidad.ToString();

            this.Text = "Editar Aula";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEdificio.Text))
            {
                MessageBox.Show("Debe ingresar el edificio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEdificio.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAula.Text))
            {
                MessageBox.Show("Debe ingresar el número de aula.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAula.Focus();
                return;
            }

            if (!int.TryParse(txtPiso.Text, out int piso) || piso < 0)
            {
                MessageBox.Show("El piso debe ser un número válido.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPiso.Focus();
                return;
            }

            if (!int.TryParse(txtCapacidad.Text, out int capacidad) || capacidad <= 0)
            {
                MessageBox.Show("La capacidad debe ser un número positivo.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCapacidad.Focus();
                return;
            }

            if (esNuevo) InsertarAula();
            else ActualizarAula();
        }

        private void InsertarAula()
        {
            string inserta = "INSERT INTO [dbo].[Aula] ([Edificio], [Aula], [Piso], [CapacidadMaxima]) " +
                           "VALUES (@Edificio, @Aula, @Piso, @Capacidad)";

            SqlConnection conexion = new SqlConnection(txtConexion);
            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("sp_InsertarAula", conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Edificio", txtEdificio.Text);
                comando.Parameters.AddWithValue("@Aula", txtAula.Text);
                comando.Parameters.AddWithValue("@Piso", int.Parse(txtPiso.Text));
                comando.Parameters.AddWithValue("@Capacidad", int.Parse(txtCapacidad.Text));

                int rows = comando.ExecuteNonQuery();
                if (rows >= 1)
                {
                    MessageBox.Show("Aula registrada exitosamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexion != null) conexion.Close();
            }
        }

        private void ActualizarAula()
        {
            string edita = "UPDATE [dbo].[Aula] SET [Edificio] = @Edificio, [Aula] = @Aula, " +
                          "[Piso] = @Piso, [CapacidadMaxima] = @Capacidad WHERE [IDAula] = @ID";

            SqlConnection conexion = new SqlConnection(txtConexion);
            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("sp_ActualizarMateria", conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Edificio", txtEdificio.Text);
                comando.Parameters.AddWithValue("@Aula", txtAula.Text);
                comando.Parameters.AddWithValue("@Piso", int.Parse(txtPiso.Text));
                comando.Parameters.AddWithValue("@Capacidad", int.Parse(txtCapacidad.Text));
                comando.Parameters.AddWithValue("@ID", idAula);

                int rows = comando.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Aula actualizada exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexion != null) conexion.Close();
            }
        }
        private void AgregarEditar_Load(object sender, EventArgs e)
        {

        }
    }
}
