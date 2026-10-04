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
    public partial class AgregarEditarCiudad : Form
    {
        private string txtConexion = @"Server=ELRATONVAKERO89\SQLEXPRESS;" +
                                    @"Database=SistemaEscolar;" +
                                    @"Integrated Security=True;" +
                                    @"TrustServerCertificate=True;";

        private bool esNuevo = true;
        private int idCiudad = 0;

        public AgregarEditarCiudad()
        {
            InitializeComponent();
            esNuevo = true;
            this.Text = "Nueva Ciudad";
            CargarEstados();
        }

        public AgregarEditarCiudad(int id, string nombre, string SiglaCiudad, int idEstado)
        {
            InitializeComponent();
            esNuevo = false;
            idCiudad = id;
            txtNombreCiudad.Text = nombre;
            txtSiglaCiudad.Text = SiglaCiudad;
            CargarEstados();
            cbEstado.SelectedValue = idEstado;

            this.Text = "Editar Ciudad";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreCiudad.Text))
            {
                MessageBox.Show("Debe ingresar el nombre de la Ciudad.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreCiudad.Focus();
                return;
            }

            if (!int.TryParse(txtSiglaCiudad.Text, out int SiglaCiudad) || SiglaCiudad <= 0)
            {
                MessageBox.Show("Los créditos deben ser un número positivo.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSiglaCiudad.Focus();
                return;
            }
            if (cbEstado.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un estado.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbEstado.Focus();
                return;
            }
            if (esNuevo)
            {
                InsertarCiudad();
            }
            else
            {
                ActualizarCiudad();
            }
        }

        private void InsertarCiudad()
        {
            string inserta = "INSERT INTO [dbo].[Ciudad] " +
                            "([NombreCiudad], [SiglasCiudad], [IDEstado]) " +
                            "VALUES (@NombreCiudad, @SiglasCiudad, @Estado)";

            SqlConnection conexion = new SqlConnection(txtConexion);

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("sp_InsertarCiudad", conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@NombreCiudad", txtNombreCiudad.Text);
                comando.Parameters.AddWithValue("@SiglaCiudad", txtSiglaCiudad.Text);
                comando.Parameters.AddWithValue("@Estado", cbEstado.SelectedValue);

                int renglonesAfectados = comando.ExecuteNonQuery();

                if (renglonesAfectados >= 1)
                {
                    MessageBox.Show("Ciudad registrada exitosamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al registrar la Ciudad", "Error",
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

        private void ActualizarCiudad()
        {
            string edita = "UPDATE [dbo].[Ciudad] " +
                          "SET [NombreCiudad] = @Nombre, " +
                          "    [SiglasCiudad] = @Siglas, " +
                          "    [IDEstado] = @Estado " +
                          "WHERE [IDCiudad] = @ID";

            SqlConnection conexion = new SqlConnection(txtConexion);

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("sp_ActualizarCiudad", conexion);

                comando.Parameters.AddWithValue("@NombreCiudad", txtNombreCiudad.Text);
                comando.Parameters.AddWithValue("@SiglaCiudad", txtSiglaCiudad.Text);
                comando.Parameters.AddWithValue("@Estado", cbEstado.SelectedValue);
                comando.Parameters.AddWithValue("@IDCiudad", idCiudad);

                int registrosEditados = comando.ExecuteNonQuery();

                if (registrosEditados > 0)
                {
                    MessageBox.Show("Ciudad actualizada exitosamente.", "Éxito",
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

        private void CargarEstados()
        {
            string consulta = "SELECT [IDEstado], [NombreEstado] FROM [Estado]";
            SqlConnection conexion = new SqlConnection(txtConexion);

            try
            {
                conexion.Open();
                SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);
                cbEstado.DataSource = dt;
                cbEstado.DisplayMember = "NombreEstado";  
                cbEstado.ValueMember = "IDEstado";        
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar estados: " + ex.Message);
            }
            finally
            {
                if (conexion != null) conexion.Close();
            }
        }
        private void AgregarEditar_Load(object sender, EventArgs e)
        {

        }

        private void txtSiglaCiudad_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelCreditos_Click(object sender, EventArgs e)
        {
        }
    }
}
