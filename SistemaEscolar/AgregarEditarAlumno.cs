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
    public partial class AgregarEditarAlumno : Form
    {
        private string txtConexion = @"Server=ELRATONVAKERO89\SQLEXPRESS;" +
                                    @"Database=SistemaEscolar;" +
                                    @"Integrated Security=True;" +
                                    @"TrustServerCertificate=True;";

        private bool esNuevo = true;
        private int idAlumno = 0;

        public AgregarEditarAlumno()
        {
            InitializeComponent();
            esNuevo = true;
            this.Text = "Nuevo Alumno";
            CargarEstatus();
        }

        public AgregarEditarAlumno(int id, string nombre, string apellidos, int estatus)
        {
            InitializeComponent();
            esNuevo = false;
            idAlumno = id;
            txtNombre.Text = nombre;
            txtApellidos.Text = apellidos;
            CargarEstatus();
            cbEstatus.SelectedValue = estatus;

            this.Text = "Editar Alumno";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrEmpty(txtApellidos.Text))
            {
                MessageBox.Show("Debe ingresar el nombre de el alumno.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }
            if (esNuevo)
            {
                InsertarAlumno();
            }
            else
            {
                ActualizarAlumno();
            }
        }

        private void InsertarAlumno()
        {
            string inserta = "INSERT INTO [dbo].[Alumno] " +
                            "([Nombre], [Apellidos], [Estatus]) " +
                            "VALUES " +
                            $"(@Nombre, @Apellidos, @Estatus)";

            SqlConnection conexion = new SqlConnection(txtConexion);

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("sp_InsertarAlumno", conexion);
                comando.CommandType = CommandType.StoredProcedure;  

                comando.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                comando.Parameters.AddWithValue("@Apellidos", txtApellidos.Text);
                comando.Parameters.AddWithValue("@Estatus", cbEstatus.SelectedValue);

                int renglonesAfectados = comando.ExecuteNonQuery();

                int rows = comando.ExecuteNonQuery();
                if (renglonesAfectados >= 1)
                {
                    MessageBox.Show("Alumno registrado exitosamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al registrar al alumno", "Error",
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

        private void ActualizarAlumno()
        {
            string edita = "UPDATE [dbo].[Alumno] " +
                        "SET [Nombre] = @Nombre, " +
                        "    [Apellidos] = @Apellidos " +
                          "    [Estatus] = @Estatus " +
                        "WHERE [IDAlumno] = @IDAlumno";

            SqlConnection conexion = new SqlConnection(txtConexion);

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("sp_ActualizarAlumno", conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                comando.Parameters.AddWithValue("@Apellidos", txtApellidos.Text);
                comando.Parameters.AddWithValue("@Estatus", cbEstatus.SelectedValue);
                comando.Parameters.AddWithValue("@IDAlumno", idAlumno);

                int registrosEditados = comando.ExecuteNonQuery();

                if (registrosEditados > 0)
                {
                    MessageBox.Show("Alumno actualizado exitosamente.", "Éxito",
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

        private void CargarEstatus()
        {
            string consulta = "SELECT [IDEstatus], [NombreEstatus] FROM [Estatus]";
            SqlConnection conexion = new SqlConnection(txtConexion);

            try
            {
                conexion.Open();
                SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);

                cbEstatus.DataSource = dt;
                cbEstatus.DisplayMember = "NombreEstatus";  
                cbEstatus.ValueMember = "IDEstatus";        
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar estatus: " + ex.Message);
            }
            finally
            {
                if (conexion != null) conexion.Close();
            }
        }

        private void AgregarEditar_Load(object sender, EventArgs e)
        {
        }

        private void txtApellidos_TextChanged(object sender, EventArgs e)
        {
        }

        private void labelCreditos_Click(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}
