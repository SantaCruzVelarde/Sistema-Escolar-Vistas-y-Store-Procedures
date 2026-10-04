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
    public partial class AgregarEditarCarrera : Form
    {
        private string txtConexion = @"Server=ELRATONVAKERO89\SQLEXPRESS;" +
                                    @"Database=SistemaEscolar;" +
                                    @"Integrated Security=True;" +
                                    @"TrustServerCertificate=True;";

        private bool esNuevo = true;
        private int idCarrera = 0;

        public AgregarEditarCarrera()
        {
            InitializeComponent();
            esNuevo = true;
            this.Text = "Nueva Carrera";
        }

        public AgregarEditarCarrera(int id, string nombre, string siglascarrera)
        {
            InitializeComponent();
            esNuevo = false;
            idCarrera = id;  
            txtNombreCarrera.Text = nombre;
            txtSiglasCarrera.Text = siglascarrera;

            this.Text = "Editar Carrera";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreCarrera.Text))
            {
                MessageBox.Show("Debe ingresar el nombre de la Carrera.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreCarrera.Focus();
                return;
            }

            if (!int.TryParse(txtSiglasCarrera.Text, out int siglascarrera) || siglascarrera <= 0)
            {
                MessageBox.Show("Los créditos deben ser un número positivo.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSiglasCarrera.Focus();
                return;
            }
            if (esNuevo)
            {
                InsertarCarrera();
            }
            else
            {
                ActualizarCarrera();
            }   
        }

        private void InsertarCarrera()
        {
            string inserta = "INSERT INTO [dbo].[Carrera] " +
                            "([NombreCarrera], [SiglasCarrera]) " +
                            "VALUES " +
                            $"(@NombreCarrera, @SiglasCarrera)";

            SqlConnection conexion = new SqlConnection(txtConexion);

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("sp_InsertarCarrera", conexion);    
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@NombreCarrera", txtNombreCarrera.Text);
                comando.Parameters.AddWithValue("@SiglasCarrera", txtSiglasCarrera.Text);

                int renglonesAfectados = comando.ExecuteNonQuery();

                if (renglonesAfectados >= 1)
                {
                    MessageBox.Show("Carrera registrada exitosamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al registrar la Carrera", "Error",
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

        private void ActualizarCarrera()
        {
            string edita = "UPDATE [dbo].[Carrera] " +
                          "SET [NombreCarrera] = @NombreCarrera, " +
                          "    [SiglasCarrera] = @SiglasCarrera " +
                          "WHERE [IDCarrera] = @IDCarrera";

            SqlConnection conexion = new SqlConnection(txtConexion);

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("sp_EditarCarrera", conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@NombreCarrera", txtNombreCarrera.Text);
                comando.Parameters.AddWithValue("@SiglasCarrera", int.Parse(txtSiglasCarrera.Text));
                comando.Parameters.AddWithValue("@IDCarrera", idCarrera);

                int registrosEditados = comando.ExecuteNonQuery();

                if (registrosEditados > 0)
                {
                    MessageBox.Show("Carrera actualizada exitosamente.", "Éxito",
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
