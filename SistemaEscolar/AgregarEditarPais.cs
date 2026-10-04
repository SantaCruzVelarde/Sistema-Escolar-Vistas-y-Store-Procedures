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
    public partial class AgregarEditarPais : Form
    {
        private string txtConexion = @"Server=ELRATONVAKERO89\SQLEXPRESS;" +
                                    @"Database=SistemaEscolar;" +
                                    @"Integrated Security=True;" +
                                    @"TrustServerCertificate=True;";

        private bool esNuevo = true;
        private int idPais = 0;

        public AgregarEditarPais()
        {
            InitializeComponent();
            esNuevo = true;
            this.Text = "Nueva Pais";
        }

        public AgregarEditarPais(int id, string nombre, string SiglaPais)
        {
            InitializeComponent();
            esNuevo = false;
            idPais = id;  
            txtNombrePais.Text = nombre;
            txtSiglaPais.Text = SiglaPais;

            this.Text = "Editar Pais";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombrePais.Text))
            {
                MessageBox.Show("Debe ingresar el nombre de la Pais.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombrePais.Focus();
                return;
            }

            if (!int.TryParse(txtSiglaPais.Text, out int SiglaPais) || SiglaPais <= 0)
            {
                MessageBox.Show("Los créditos deben ser un número positivo.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSiglaPais.Focus();
                return;
            }
            if (esNuevo)
            {
                InsertarPais();
            }
            else
            {
                ActualizarPais();
            }   
        }

        private void InsertarPais()
        {
            string inserta = "INSERT INTO [dbo].[Pais] " +
                            "([NombrePais], [SiglaPais]) " +
                            "VALUES " +
                            $"(@NombrePais, @SiglaPais)";

            SqlConnection conexion = new SqlConnection(txtConexion);

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("sp_InsertarPais", conexion);
                comando.CommandType = CommandType.StoredProcedure;


                comando.Parameters.AddWithValue("@NombrePais", txtNombrePais.Text);
                comando.Parameters.AddWithValue("@SiglaPais", txtSiglaPais.Text);

                int renglonesAfectados = comando.ExecuteNonQuery();

                if (renglonesAfectados >= 1)
                {
                    MessageBox.Show("Pais registrada exitosamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al registrar la Pais", "Error",
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

        private void ActualizarPais()
        {
            string edita = "UPDATE [dbo].[Pais] " +
                          "SET [NombrePais] = @NombrePais, " +
                          "    [SiglaPais] = @SiglaPais " +
                          "WHERE [IDPais] = @IDPais";

            SqlConnection conexion = new SqlConnection(txtConexion);

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("sp_ActualizarPais", conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@NombrePais", txtNombrePais.Text);
                comando.Parameters.AddWithValue("@SiglaPais", txtSiglaPais.Text);
                comando.Parameters.AddWithValue("@IDPais", idPais);

                int registrosEditados = comando.ExecuteNonQuery();

                if (registrosEditados > 0)
                {
                    MessageBox.Show("Pais actualizada exitosamente.", "Éxito",
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
