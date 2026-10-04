namespace SistemaEscolar
{
    partial class AgregarEditarPais
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarEditarPais));
            gbDatos = new GroupBox();
            labelCreditos = new Label();
            txtSiglaPais = new TextBox();
            txtNombrePais = new TextBox();
            labelMateria = new Label();
            toolStrip1 = new ToolStrip();
            btnGuardar = new ToolStripButton();
            btnCancelar = new ToolStripButton();
            gbDatos.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // gbDatos
            // 
            gbDatos.Controls.Add(labelCreditos);
            gbDatos.Controls.Add(txtSiglaPais);
            gbDatos.Controls.Add(txtNombrePais);
            gbDatos.Controls.Add(labelMateria);
            gbDatos.Location = new Point(91, 64);
            gbDatos.Name = "gbDatos";
            gbDatos.Size = new Size(379, 119);
            gbDatos.TabIndex = 3;
            gbDatos.TabStop = false;
            gbDatos.Text = "Datos de Pais";
            // 
            // labelCreditos
            // 
            labelCreditos.AutoSize = true;
            labelCreditos.Location = new Point(6, 76);
            labelCreditos.Name = "labelCreditos";
            labelCreditos.Size = new Size(51, 20);
            labelCreditos.TabIndex = 3;
            labelCreditos.Text = "Siglas:";
            // 
            // txtSiglaPais
            // 
            txtSiglaPais.Location = new Point(136, 73);
            txtSiglaPais.Name = "txtSiglaPais";
            txtSiglaPais.Size = new Size(192, 26);
            txtSiglaPais.TabIndex = 2;
            // 
            // txtNombrePais
            // 
            txtNombrePais.Location = new Point(134, 33);
            txtNombrePais.Name = "txtNombrePais";
            txtNombrePais.Size = new Size(194, 26);
            txtNombrePais.TabIndex = 1;
            // 
            // labelMateria
            // 
            labelMateria.AutoSize = true;
            labelMateria.Location = new Point(6, 33);
            labelMateria.Name = "labelMateria";
            labelMateria.Size = new Size(96, 20);
            labelMateria.TabIndex = 0;
            labelMateria.Text = "Nombre Pais:";
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
            // AgregarEditarPais
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(551, 230);
            Controls.Add(toolStrip1);
            Controls.Add(gbDatos);
            Name = "AgregarEditarPais";
            Text = "AgregarEditarPais";
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
        private TextBox txtSiglaPais;
        private TextBox txtNombrePais;
        private Label labelMateria;
        private ToolStrip toolStrip1;
        private ToolStripButton btnGuardar;
        private ToolStripButton btnCancelar;
    }
}