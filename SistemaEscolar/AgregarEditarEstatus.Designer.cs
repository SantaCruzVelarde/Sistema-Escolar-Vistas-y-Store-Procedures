namespace SistemaEscolar
{
    partial class AgregarEditarEstatus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarEditarEstatus));
            gbDatos = new GroupBox();
            labelCreditos = new Label();
            txtNombreEstatus = new TextBox();
            txtClaveEstatus = new TextBox();
            labelMateria = new Label();
            toolStrip1 = new ToolStrip();
            btnGuardar = new ToolStripButton();
            btnCancelar = new ToolStripButton();
            label1 = new Label();
            txtUsuario = new TextBox();
            gbDatos.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // gbDatos
            // 
            gbDatos.Controls.Add(txtUsuario);
            gbDatos.Controls.Add(label1);
            gbDatos.Controls.Add(labelCreditos);
            gbDatos.Controls.Add(txtNombreEstatus);
            gbDatos.Controls.Add(txtClaveEstatus);
            gbDatos.Controls.Add(labelMateria);
            gbDatos.Location = new Point(95, 55);
            gbDatos.Name = "gbDatos";
            gbDatos.Size = new Size(379, 142);
            gbDatos.TabIndex = 3;
            gbDatos.TabStop = false;
            gbDatos.Text = "Datos Estatus";
            // 
            // labelCreditos
            // 
            labelCreditos.AutoSize = true;
            labelCreditos.Location = new Point(6, 73);
            labelCreditos.Name = "labelCreditos";
            labelCreditos.Size = new Size(67, 20);
            labelCreditos.TabIndex = 3;
            labelCreditos.Text = "Nombre:";
            // 
            // txtNombreEstatus
            // 
            txtNombreEstatus.Location = new Point(81, 70);
            txtNombreEstatus.Name = "txtNombreEstatus";
            txtNombreEstatus.Size = new Size(192, 26);
            txtNombreEstatus.TabIndex = 2;
            txtNombreEstatus.TextChanged += txtNombreEstatus_TextChanged;
            // 
            // txtClaveEstatus
            // 
            txtClaveEstatus.Location = new Point(81, 30);
            txtClaveEstatus.Name = "txtClaveEstatus";
            txtClaveEstatus.Size = new Size(194, 26);
            txtClaveEstatus.TabIndex = 1;
            // 
            // labelMateria
            // 
            labelMateria.AutoSize = true;
            labelMateria.Location = new Point(6, 33);
            labelMateria.Name = "labelMateria";
            labelMateria.Size = new Size(48, 20);
            labelMateria.TabIndex = 0;
            labelMateria.Text = "Clave:";
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(19, 19);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnGuardar, btnCancelar });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(512, 27);
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
            label1.Location = new Point(6, 113);
            label1.Name = "label1";
            label1.Size = new Size(62, 20);
            label1.TabIndex = 4;
            label1.Text = "Usuario:";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(81, 110);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(192, 26);
            txtUsuario.TabIndex = 5;
            // 
            // AgregarEditarEstatus
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(512, 209);
            Controls.Add(toolStrip1);
            Controls.Add(gbDatos);
            Name = "AgregarEditarEstatus";
            Text = "AgregarEditarEstatus";
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
        private TextBox txtNombreEstatus;
        private TextBox txtClaveEstatus;
        private Label labelMateria;
        private ToolStrip toolStrip1;
        private ToolStripButton btnGuardar;
        private ToolStripButton btnCancelar;
        private TextBox txtUsuario;
        private Label label1;
    }
}