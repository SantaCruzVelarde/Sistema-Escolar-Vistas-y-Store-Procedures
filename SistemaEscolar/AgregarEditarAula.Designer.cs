namespace SistemaEscolar
{
    partial class AgregarEditarAula
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarEditarAula));
            gbDatos = new GroupBox();
            label2 = new Label();
            label1 = new Label();
            txtCapacidad = new TextBox();
            txtPiso = new TextBox();
            labelAula = new Label();
            txtAula = new TextBox();
            txtEdificio = new TextBox();
            labelEd = new Label();
            toolStrip1 = new ToolStrip();
            btnGuardar = new ToolStripButton();
            btnCancelar = new ToolStripButton();
            gbDatos.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // gbDatos
            // 
            gbDatos.Controls.Add(label2);
            gbDatos.Controls.Add(label1);
            gbDatos.Controls.Add(txtCapacidad);
            gbDatos.Controls.Add(txtPiso);
            gbDatos.Controls.Add(labelAula);
            gbDatos.Controls.Add(txtAula);
            gbDatos.Controls.Add(txtEdificio);
            gbDatos.Controls.Add(labelEd);
            gbDatos.Location = new Point(0, 52);
            gbDatos.Name = "gbDatos";
            gbDatos.Size = new Size(551, 175);
            gbDatos.TabIndex = 3;
            gbDatos.TabStop = false;
            gbDatos.Text = "Datos de Aula";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(339, 80);
            label2.Name = "label2";
            label2.Size = new Size(83, 20);
            label2.TabIndex = 7;
            label2.Text = "Capacidad:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(334, 41);
            label1.Name = "label1";
            label1.Size = new Size(39, 20);
            label1.TabIndex = 6;
            label1.Text = "Piso:";
            // 
            // txtCapacidad
            // 
            txtCapacidad.Location = new Point(405, 76);
            txtCapacidad.Name = "txtCapacidad";
            txtCapacidad.Size = new Size(134, 26);
            txtCapacidad.TabIndex = 5;
            // 
            // txtPiso
            // 
            txtPiso.Location = new Point(405, 33);
            txtPiso.Name = "txtPiso";
            txtPiso.Size = new Size(134, 26);
            txtPiso.TabIndex = 4;
            // 
            // labelAula
            // 
            labelAula.AutoSize = true;
            labelAula.Location = new Point(49, 79);
            labelAula.Name = "labelAula";
            labelAula.Size = new Size(42, 20);
            labelAula.TabIndex = 3;
            labelAula.Text = "Aula:";
            // 
            // txtAula
            // 
            txtAula.Location = new Point(134, 73);
            txtAula.Name = "txtAula";
            txtAula.Size = new Size(134, 26);
            txtAula.TabIndex = 2;
            // 
            // txtEdificio
            // 
            txtEdificio.Location = new Point(134, 33);
            txtEdificio.Name = "txtEdificio";
            txtEdificio.Size = new Size(134, 26);
            txtEdificio.TabIndex = 1;
            // 
            // labelEd
            // 
            labelEd.AutoSize = true;
            labelEd.Location = new Point(49, 36);
            labelEd.Name = "labelEd";
            labelEd.Size = new Size(62, 20);
            labelEd.TabIndex = 0;
            labelEd.Text = "Edificio:";
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
            // AgregarEditarAula
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(551, 230);
            Controls.Add(toolStrip1);
            Controls.Add(gbDatos);
            Name = "AgregarEditarAula";
            Text = "AgregarEditarAula";
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
        private Label labelAula;
        private TextBox txtAula;
        private TextBox txtEdificio;
        private Label labelEd;
        private ToolStrip toolStrip1;
        private ToolStripButton btnGuardar;
        private ToolStripButton btnCancelar;
        private TextBox txtCapacidad;
        private TextBox txtPiso;
        private Label label2;
        private Label label1;
    }
}