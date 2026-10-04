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
    public partial class AgregarEditarEstado : Form
    {
        private string txtConexion = @"Server=ELRATONVAKERO89\SQLEXPRESS;" +
                                    @"Database=SistemaEscolar;" +
                                    @"Integrated Security=True;" +
                                    @"TrustServerCertificate=True;";

        private bool esNuevo = true;
        private int idEstado = 0;

        public AgregarEditarEstado()
        {
            InitializeComponent();
            esNuevo = true;
            this.Text = "Nueva Estado";
        }

        public AgregarEditarEstado(int id, string nombre, string SiglaEstado)
        {
            InitializeComponent();
            esNuevo = false;
            idEstado = id;  
            txtNombreEstado.Text = nombre;
            txtSiglaEstado.Text = SiglaEstado;

            this.Text = "Editar Estado";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreEstado.Text))
            {
                MessageBox.Show("Debe ingresar el nombre de la Estado.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreEstado.Focus();
                return;
            }

            if (!int.TryParse(txtSiglaEstado.Text, out int SiglaEstado) || SiglaEstado <= 0)
            {
                MessageBox.Show("Los créditos deben ser un número positivo.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSiglaEstado.Focus();
                return;
            }
            if (esNuevo)
            {
                InsertarEstado();
            }
            else
            {
                ActualizarEstado();
            }   
        }

        private void InsertarEstado()
        {
            string inserta = "INSERT INTO [dbo].[Estado] " +
                            "([NombreEstado], [SiglaEstado]) " +
                            "VALUES " +
                            $"(@NombreEstado, @SiglaEstado)";

            SqlConnection conexion = new SqlConnection(txtConexion);

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("sp_InsertarEstado", conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@NombreEstado", txtNombreEstado.Text);
                comando.Parameters.AddWithValue("@SiglaEstado", txtSiglaEstado.Text);

                int renglonesAfectados = comando.ExecuteNonQuery();

                if (renglonesAfectados >= 1)
                {
                    MessageBox.Show("Estado registrada exitosamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al registrar la Estado", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción al insertar: " + ex.Message,
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

        private void ActualizarEstado()
        {
            string edita = "UPDATE [dbo].[Estado] " +
                          "SET [NombreEstado] = @NombreEstado, " +
                          "    [SiglaEstado] = @SiglaEstado " +
                          "WHERE [IDEstado] = @IDEstado";

            SqlConnection conexion = new SqlConnection(txtConexion);

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("sp_EditarEstado", conexion);

                comando.Parameters.AddWithValue("@NombreEstado", txtNombreEstado.Text);
                comando.Parameters.AddWithValue("@SiglaEstado", txtSiglaEstado.Text);
                comando.Parameters.AddWithValue("@IDEstado", idEstado);

                int registrosEditados = comando.ExecuteNonQuery();

                if (registrosEditados > 0)
                {
                    MessageBox.Show("Estado actualizada exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el registro.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción al editar: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
        }

        private void AgregarEditar_Load(object sender, EventArgs e)
        {

        }
    }
}
