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
    public partial class AgregarEditarAcademico : Form
    {
        private string txtConexion = @"Server=ELRATONVAKERO89\SQLEXPRESS;" +
                                    @"Database=SistemaEscolar;" +
                                    @"Integrated Security=True;" +
                                    @"TrustServerCertificate=True;";

        private bool esNuevo = true;
        private int idAcademico = 0;

        public AgregarEditarAcademico()
        {
            InitializeComponent();
            esNuevo = true;
            this.Text = "Nuevo Académico";
            CargarGrados();
        }

        public AgregarEditarAcademico(int id, string nombre, string apellidos, string grado)
        {
            InitializeComponent();
            esNuevo = false;
            idAcademico = id;
            txtNombre.Text = nombre;
            txtApellidos.Text = apellidos;
            CargarGrados();
            cbGrado.SelectedItem = grado;
            this.Text = "Editar Académico";
        }

        private void CargarGrados()
        {
            cbGrado.Items.Clear();
            cbGrado.Items.Add("Licenciatura");
            cbGrado.Items.Add("Maestría");
            cbGrado.Items.Add("Doctor");
            if (cbGrado.Items.Count > 0) cbGrado.SelectedIndex = 0;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellidos.Text))
            {
                MessageBox.Show("Complete todos los campos.", "Validación");
                return;
            }

            if (cbGrado.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un grado.", "Validación");
                return;
            }

            if (esNuevo) Insertar(); else Actualizar();
        }

        private void Insertar()
        {
            SqlConnection conn = new SqlConnection(txtConexion);
            try
            {
                conn.Open();
                SqlCommand comando = new SqlCommand("sp_InsertarAcademico", conn);
                comando.Parameters.Add(CommandType.StoredProcedure);

                comando.Parameters.AddWithValue("@N", txtNombre.Text);
                comando.Parameters.AddWithValue("@A", txtApellidos.Text);
                comando.Parameters.AddWithValue("@G", cbGrado.SelectedItem.ToString());

                if (comando.ExecuteNonQuery() >= 1)
                {
                    MessageBox.Show("Académico registrado.", "Éxito");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (conn != null) conn.Close();
            }
        }
        private void Actualizar()
        {
            SqlConnection conn = new SqlConnection(txtConexion);
            try
            {
                conn.Open();
                SqlCommand comando = new SqlCommand("sp_ActualizarAcademico", conn);
                comando.Parameters.Add(CommandType.StoredProcedure);

                comando.Parameters.AddWithValue("@N", txtNombre.Text);
                comando.Parameters.AddWithValue("@A", txtApellidos.Text);
                comando.Parameters.AddWithValue("@G", cbGrado.SelectedItem.ToString());
                comando.Parameters.AddWithValue("@ID", idAcademico);

                if (comando.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Académico actualizado.", "Éxito");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (conn != null) conn.Close();
            }
        }

        private void AgregarEditar_Load(object sender, EventArgs e)
        {
            
        }
    }
}
