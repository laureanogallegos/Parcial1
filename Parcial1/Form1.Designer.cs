namespace Parcial1
{
    partial class Form1
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
            dgvmedicamentos = new DataGridView();
            dgvdrogueriasasociadas = new DataGridView();
            btnagregar = new Button();
            btnModifica = new Button();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvmedicamentos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvdrogueriasasociadas).BeginInit();
            SuspendLayout();
            // 
            // dgvmedicamentos
            // 
            dgvmedicamentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvmedicamentos.Location = new Point(20, 12);
            dgvmedicamentos.Name = "dgvmedicamentos";
            dgvmedicamentos.RowTemplate.Height = 25;
            dgvmedicamentos.Size = new Size(413, 274);
            dgvmedicamentos.TabIndex = 1;
            dgvmedicamentos.CellContentClick += dgvmedicamentos_CellContentClick;
            dgvmedicamentos.SelectionChanged += dgvmedicamentos_SelectionChanged;
            // 
            // dgvdrogueriasasociadas
            // 
            dgvdrogueriasasociadas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvdrogueriasasociadas.Location = new Point(447, 12);
            dgvdrogueriasasociadas.Name = "dgvdrogueriasasociadas";
            dgvdrogueriasasociadas.RowTemplate.Height = 25;
            dgvdrogueriasasociadas.Size = new Size(341, 274);
            dgvdrogueriasasociadas.TabIndex = 2;
            // 
            // btnagregar
            // 
            btnagregar.Location = new Point(48, 325);
            btnagregar.Name = "btnagregar";
            btnagregar.Size = new Size(75, 23);
            btnagregar.TabIndex = 3;
            btnagregar.Text = "Agregar";
            btnagregar.UseVisualStyleBackColor = true;
            btnagregar.Click += btnagregar_Click;
            // 
            // btnModifica
            // 
            btnModifica.Location = new Point(621, 325);
            btnModifica.Name = "btnModifica";
            btnModifica.Size = new Size(75, 23);
            btnModifica.TabIndex = 4;
            btnModifica.Text = "Modificar";
            btnModifica.UseVisualStyleBackColor = true;
            btnModifica.Click += btnModifica_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(358, 325);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 5;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnEliminar);
            Controls.Add(btnModifica);
            Controls.Add(btnagregar);
            Controls.Add(dgvdrogueriasasociadas);
            Controls.Add(dgvmedicamentos);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvmedicamentos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvdrogueriasasociadas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvmedicamentos;
        private DataGridView dgvdrogueriasasociadas;
        private Button btnagregar;
        private Button btnModifica;
        private Button btnEliminar;
    }
}