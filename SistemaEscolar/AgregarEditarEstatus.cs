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
    public partial class AgregarEditarEstatus : Form
    {
        private string txtConexion = @"Server=ELRATONVAKERO89\SQLEXPRESS;" +
                                    @"Database=SistemaEscolar;" +
                                    @"Integrated Security=True;" +
                                    @"TrustServerCertificate=True;";

        private bool esNuevo = true;
        private int idEstatus = 0;

        public AgregarEditarEstatus()
        {
            InitializeComponent();
            esNuevo = true;
            this.Text = "Nueva Estatus";
        }

        public AgregarEditarEstatus(int id, string nombre, string NombreEstatus, string usuario)
        {
            InitializeComponent();
            esNuevo = false;
            idEstatus = id;
            txtClaveEstatus.Text = nombre;
            txtNombreEstatus.Text = NombreEstatus;
            txtUsuario.Text = usuario;

            this.Text = "Editar Estatus";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtClaveEstatus.Text))
            {
                MessageBox.Show("Debe ingresar el nombre de la Estatus.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClaveEstatus.Focus();
                return;
            }

            if (!int.TryParse(txtNombreEstatus.Text, out int NombreEstatus) || NombreEstatus <= 0)
            {
                MessageBox.Show("Los créditos deben ser un número positivo.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreEstatus.Focus();
                return;
            }
            if (esNuevo)
            {
                InsertarEstatus();
            }
            else
            {
                ActualizarEstatus();
            }
        }

        private void InsertarEstatus()
        {
            string inserta = "INSERT INTO [dbo].[Estatus] " +
                            "([ClaveEstatus], [NombreEstatus]) " +
                            "VALUES " +
                            $"(@ClaveEstatus, @NombreEstatus)";

            SqlConnection conexion = new SqlConnection(txtConexion);

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("sp_InsertarEstatus", conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@ClaveEstatus", txtClaveEstatus.Text);
                comando.Parameters.AddWithValue("@NombreEstatus", int.Parse(txtNombreEstatus.Text));
                comando.Parameters.AddWithValue("@Usuario",
                    string.IsNullOrWhiteSpace(txtUsuario.Text) ? "admin" : txtUsuario.Text);

                int renglonesAfectados = comando.ExecuteNonQuery();

                if (renglonesAfectados >= 1)
                {
                    MessageBox.Show("Estatus registrada exitosamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al registrar la Estatus", "Error",
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

        private void ActualizarEstatus()
        {
            string edita = "UPDATE [dbo].[Estatus] " +
                          "SET [ClaveEstatus] = @ClaveEstatus, " +
                          "    [NombreEstatus] = @NombreEstatus " +
                          "    [Usuario] = @Usuario " +
                          "WHERE [IDEstatus] = @IDEstatus";

            SqlConnection conexion = new SqlConnection(txtConexion);

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("sp_ActualizarEstatus", conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@ClaveEstatus", txtClaveEstatus.Text);
                comando.Parameters.AddWithValue("@NombreEstatus", txtNombreEstatus.Text);
                comando.Parameters.AddWithValue("@Usuario",
                  string.IsNullOrWhiteSpace(txtUsuario.Text) ? "admin" : txtUsuario.Text);
                comando.Parameters.AddWithValue("@IDEstatus", idEstatus);

                int registrosEditados = comando.ExecuteNonQuery();

                if (registrosEditados > 0)
                {
                    MessageBox.Show("Estatus actualizada exitosamente.", "Éxito",
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

        private void txtNombreEstatus_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
