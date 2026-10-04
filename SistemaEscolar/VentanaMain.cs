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
    public partial class VentanaMain : Form
    {
        public VentanaMain()
        {
            InitializeComponent();
        }

        private void btnMaterias_Click(object sender, EventArgs e)
        {
            FormPanel(new VentanaMateria());
        }

        private void btnAula_Click(object sender, EventArgs e)
        {
            FormPanel(new VentanaAula());
        }

        private void btnAcademico_Click(object sender, EventArgs e)
        {
            FormPanel(new VentanaAcademico());
        }

        private void btnAlumno_Click(object sender, EventArgs e)
        {
            FormPanel(new VentanaAlumno());
        }

        private void btnCarrera_Click(object sender, EventArgs e)
        {
            FormPanel(new VentanaCarrera());
        }

        private void btnCiudad_Click(object sender, EventArgs e)
        {
            FormPanel(new VentanaCiudad());
        }

        private void btnEstado_Click(object sender, EventArgs e)
        {
            FormPanel(new VentanaEstado());
        }

        private void btnPais_Click(object sender, EventArgs e)
        {
            FormPanel(new VentanaPais());
        }

        private void btnEstatus_Click(object sender, EventArgs e)
        {
            FormPanel(new VentanaEstatus());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormPanel(Form subform)
        {
            if (panel1.Controls.Count > 0)
                panel1.Controls.RemoveAt(0);

            subform.TopLevel = false;
            subform.FormBorderStyle = FormBorderStyle.None;
            subform.Dock = DockStyle.Fill;
            panel1.Controls.Add(subform);
            panel1.Tag = subform;
            subform.Show();
        }
    }
}
