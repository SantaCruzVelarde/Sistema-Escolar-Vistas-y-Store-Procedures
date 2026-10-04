namespace SistemaEscolar
{
    partial class AgregarEditarAlumno
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarEditarAlumno));
            gbDatos = new GroupBox();
            labelCreditos = new Label();
            txtApellidos = new TextBox();
            txtNombre = new TextBox();
            labelMateria = new Label();
            toolStrip1 = new ToolStrip();
            btnGuardar = new ToolStripButton();
            btnCancelar = new ToolStripButton();
            label1 = new Label();
            cbEstatus = new ComboBox();
            gbDatos.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // gbDatos
            // 
            gbDatos.Controls.Add(cbEstatus);
            gbDatos.Controls.Add(label1);
            gbDatos.Controls.Add(labelCreditos);
            gbDatos.Controls.Add(txtApellidos);
            gbDatos.Controls.Add(txtNombre);
            gbDatos.Controls.Add(labelMateria);
            gbDatos.Location = new Point(102, 55);
            gbDatos.Name = "gbDatos";
            gbDatos.Size = new Size(379, 154);
            gbDatos.TabIndex = 3;
            gbDatos.TabStop = false;
            gbDatos.Text = "Datos del Alumno";
            // 
            // labelCreditos
            // 
            labelCreditos.AutoSize = true;
            labelCreditos.Location = new Point(6, 79);
            labelCreditos.Name = "labelCreditos";
            labelCreditos.Size = new Size(75, 20);
            labelCreditos.TabIndex = 3;
            labelCreditos.Text = "Apellidos:";
            labelCreditos.Click += this.labelCreditos_Click;
            // 
            // txtApellidos
            // 
            txtApellidos.Location = new Point(98, 76);
            txtApellidos.Name = "txtApellidos";
            txtApellidos.Size = new Size(192, 26);
            txtApellidos.TabIndex = 2;
            txtApellidos.TextChanged += this.txtApellidos_TextChanged;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(98, 35);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(194, 26);
            txtNombre.TabIndex = 1;
            // 
            // labelMateria
            // 
            labelMateria.AutoSize = true;
            labelMateria.Location = new Point(6, 38);
            labelMateria.Name = "labelMateria";
            labelMateria.Size = new Size(67, 20);
            labelMateria.TabIndex = 0;
            labelMateria.Text = "Nombre:";
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(19, 19);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnGuardar, btnCancelar });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(551, 27);
            toolStrip1.TabIndex = 4;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnGuardar
            // 
            btnGuardar.Image = (Image)resources.GetObject("btnGuardar.Image");
            btnGuardar.ImageTransparentColor = Color.Magenta;
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(85, 24);
            btnGuardar.Text = "Guardar";
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Alignment = ToolStripItemAlignment.Right;
            btnCancelar.Image = (Image)resources.GetObject("btnCancelar.Image");
            btnCancelar.ImageTransparentColor = Color.Magenta;
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(89, 24);
            btnCancelar.Text = "Cancelar";
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 124);
            label1.Name = "label1";
            label1.Size = new Size(58, 20);
            label1.TabIndex = 4;
            label1.Text = "Estatus:";
            label1.Click += this.label1_Click;
            // 
            // cbEstatus
            // 
            cbEstatus.FormattingEnabled = true;
            cbEstatus.Location = new Point(98, 121);
            cbEstatus.Name = "cbEstatus";
            cbEstatus.Size = new Size(192, 27);
            cbEstatus.TabIndex = 5;
            cbEstatus.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // AgregarEditarAlumno
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(551, 230);
            Controls.Add(toolStrip1);
            Controls.Add(gbDatos);
            Name = "AgregarEditarAlumno";
            Text = "AgregarEditarAlumno";
            Load += AgregarEditar_Load;
            gbDatos.ResumeLayout(false);
            gbDatos.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox gbDatos;
        private Label labelCreditos;
        private TextBox txtApellidos;
        private TextBox txtNombre;
        private Label labelMateria;
        private ToolStrip toolStrip1;
        private ToolStripButton btnGuardar;
        private ToolStripButton btnCancelar;
        private ComboBox cbEstatus;
        private Label label1;
    }
}