namespace SistemaEscolar
{
    partial class VentanaEstado
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentanaEstado));
            toolStrip1 = new ToolStrip();
            btnConsultar = new ToolStripButton();
            btnInsertar = new ToolStripButton();
            btnEditar = new ToolStripButton();
            btnSalir = new ToolStripButton();
            btnEliminar = new ToolStripButton();
            DGV = new DataGridView();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGV).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(19, 19);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnConsultar, btnInsertar, btnEditar, btnSalir, btnEliminar });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 27);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnConsultar
            // 
            btnConsultar.Image = (Image)resources.GetObject("btnConsultar.Image");
            btnConsultar.ImageTransparentColor = Color.Magenta;
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(94, 24);
            btnConsultar.Text = "Consultar";
            btnConsultar.Click += btnConsultar_Click;
            // 
            // btnInsertar
            // 
            btnInsertar.Image = (Image)resources.GetObject("btnInsertar.Image");
            btnInsertar.ImageTransparentColor = Color.Magenta;
            btnInsertar.Name = "btnInsertar";
            btnInsertar.Size = new Size(81, 24);
            btnInsertar.Text = "Insertar";
            btnInsertar.Click += btnInsertar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Image = (Image)resources.GetObject("btnEditar.Image");
            btnEditar.ImageTransparentColor = Color.Magenta;
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(71, 24);
            btnEditar.Text = "Editar";
            btnEditar.Click += btnEditar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Alignment = ToolStripItemAlignment.Right;
            btnSalir.Image = (Image)resources.GetObject("btnSalir.Image");
            btnSalir.ImageTransparentColor = Color.Magenta;
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(61, 24);
            btnSalir.Text = "Salir";
            btnSalir.Click += btnSalir_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Image = (Image)resources.GetObject("btnEliminar.Image");
            btnEliminar.ImageTransparentColor = Color.Magenta;
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(86, 24);
            btnEliminar.Text = "Eliminar";
            btnEliminar.Click += btnEliminar_Click;
            // 
            // DGV
            // 
            DGV.AllowUserToAddRows = false;
            DGV.AllowUserToDeleteRows = false;
            DGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV.Location = new Point(12, 49);
            DGV.Name = "DGV";
            DGV.ReadOnly = true;
            DGV.RowHeadersWidth = 49;
            DGV.Size = new Size(776, 389);
            DGV.TabIndex = 1;
            DGV.CellContentClick += DGV_CellContentClick;
            // 
            // VentanaEstado
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(DGV);
            Controls.Add(toolStrip1);
            Name = "VentanaEstado";
            Text = "VentanaEstado";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGV).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton btnConsultar;
        private ToolStripButton btnInsertar;
        private ToolStripButton btnEditar;
        private ToolStripButton btnSalir;
        private DataGridView DGV;
        private ToolStripButton btnEliminar;
    }
}
