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
    public partial class AgregarEditarMateria : Form
    {
        private string txtConexion = @"Server=ELRATONVAKERO89\SQLEXPRESS;" +
                                    @"Database=SistemaEscolar;" +
                                    @"Integrated Security=True;" +
                                    @"TrustServerCertificate=True;";

        private bool esNuevo = true;
        private int idMateria = 0;

        public AgregarEditarMateria()
        {
            InitializeComponent();
            esNuevo = true;
            this.Text = "Nueva Materia";
        }

        public AgregarEditarMateria(int id, string nombre, int creditos)
        {
            InitializeComponent();
            esNuevo = false;
            idMateria = id;  
            txtNombreMateria.Text = nombre;
            txtCreditos.Text = creditos.ToString();

            this.Text = "Editar Materia";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreMateria.Text))
            {
                MessageBox.Show("Debe ingresar el nombre de la materia.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreMateria.Focus();
                return;
            }

            if (!int.TryParse(txtCreditos.Text, out int creditos) || creditos <= 0)
            {
                MessageBox.Show("Los créditos deben ser un número positivo.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCreditos.Focus();
                return;
            }
            if (esNuevo)
            {
                InsertarMateria();
            }
            else
            {
                ActualizarMateria();
            }   
        }

        private void InsertarMateria()
        {
            string inserta = "INSERT INTO [dbo].[Materia] " +
                            "([NombreMateria], [Creditos]) " +
                            "VALUES " +
                            $"(@NombreMateria, @Creditos)";

            SqlConnection conexion = new SqlConnection(txtConexion);

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("sp_InsertarMateria", conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@NombreMateria", txtNombreMateria.Text);
                comando.Parameters.AddWithValue("@Creditos", int.Parse(txtCreditos.Text));

                int renglonesAfectados = comando.ExecuteNonQuery();

                if (renglonesAfectados >= 1)
                {
                    MessageBox.Show("Materia registrada exitosamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al registrar la materia", "Error",
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

        private void ActualizarMateria()
        {
            string edita = "UPDATE [dbo].[Materia] " +
                          "SET [NombreMateria] = @NombreMateria, " +
                          "    [Creditos] = @Creditos " +
                          "WHERE [IDMateria] = @IDMateria";

            SqlConnection conexion = new SqlConnection(txtConexion);

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("sp_ActualizarMateria", conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@IDMateria", idMateria);
                comando.Parameters.AddWithValue("@NombreMateria", txtNombreMateria.Text);
                comando.Parameters.AddWithValue("@Creditos", int.Parse(txtCreditos.Text));

                int registrosEditados = comando.ExecuteNonQuery();

                if (registrosEditados > 0)
                {
                    MessageBox.Show("Materia actualizada exitosamente.", "Éxito",
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
