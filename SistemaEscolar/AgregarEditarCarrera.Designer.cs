namespace SistemaEscolar
{
    partial class AgregarEditarCarrera
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarEditarCarrera));
            gbDatos = new GroupBox();
            LAB = new Label();
            txtSiglasCarrera = new TextBox();
            txtNombreCarrera = new TextBox();
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
            gbDatos.Controls.Add(LAB);
            gbDatos.Controls.Add(txtSiglasCarrera);
            gbDatos.Controls.Add(txtNombreCarrera);
            gbDatos.Controls.Add(labelMateria);
            gbDatos.Location = new Point(91, 64);
            gbDatos.Name = "gbDatos";
            gbDatos.Size = new Size(379, 119);
            gbDatos.TabIndex = 3;
            gbDatos.TabStop = false;
            gbDatos.Text = "Datos de la Carrera";
            // 
            // LAB
            // 
            LAB.AutoSize = true;
            LAB.Location = new Point(6, 76);
            LAB.Name = "LAB";
            LAB.Size = new Size(51, 20);
            LAB.TabIndex = 3;
            LAB.Text = "Siglas:";
            // 
            // txtSiglasCarrera
            // 
            txtSiglasCarrera.Location = new Point(134, 73);
            txtSiglasCarrera.Name = "txtSiglasCarrera";
            txtSiglasCarrera.Size = new Size(192, 26);
            txtSiglasCarrera.TabIndex = 2;
            // 
            // txtNombreCarrera
            // 
            txtNombreCarrera.Location = new Point(134, 33);
            txtNombreCarrera.Name = "txtNombreCarrera";
            txtNombreCarrera.Size = new Size(194, 26);
            txtNombreCarrera.TabIndex = 1;
            // 
            // labelMateria
            // 
            labelMateria.AutoSize = true;
            labelMateria.Location = new Point(6, 36);
            labelMateria.Name = "labelMateria";
            labelMateria.Size = new Size(119, 20);
            labelMateria.TabIndex = 0;
            labelMateria.Text = "Nombre Carrera:";
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
            // AgregarEditarCarrera
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(551, 230);
            Controls.Add(toolStrip1);
            Controls.Add(gbDatos);
            Name = "AgregarEditarCarrera";
            Text = "AgregarEditarCarrera";
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
        private Label LAB;
        private TextBox txtSiglasCarrera;
        private TextBox txtNombreCarrera;
        private Label labelMateria;
        private ToolStrip toolStrip1;
        private ToolStripButton btnGuardar;
        private ToolStripButton btnCancelar;
    }
}