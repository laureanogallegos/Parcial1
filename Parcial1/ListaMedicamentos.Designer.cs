namespace Parcial1
{
    partial class ListaMedicamentos
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
            btnEliminar = new Button();
            btnModificar = new Button();
            btnAgregar = new Button();
            dgvDrogueriasMedicamento = new DataGridView();
            dgvMedicamentos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvDrogueriasMedicamento).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMedicamentos).BeginInit();
            SuspendLayout();
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(466, 400);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(100, 23);
            btnEliminar.TabIndex = 9;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(232, 400);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(100, 23);
            btnModificar.TabIndex = 8;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(17, 400);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(100, 23);
            btnAgregar.TabIndex = 7;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // dgvDrogueriasMedicamento
            // 
            dgvDrogueriasMedicamento.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDrogueriasMedicamento.Location = new Point(612, 27);
            dgvDrogueriasMedicamento.Name = "dgvDrogueriasMedicamento";
            dgvDrogueriasMedicamento.RowTemplate.Height = 25;
            dgvDrogueriasMedicamento.Size = new Size(175, 362);
            dgvDrogueriasMedicamento.TabIndex = 6;
            // 
            // dgvMedicamentos
            // 
            dgvMedicamentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMedicamentos.Location = new Point(13, 27);
            dgvMedicamentos.Name = "dgvMedicamentos";
            dgvMedicamentos.RowTemplate.Height = 25;
            dgvMedicamentos.Size = new Size(553, 362);
            dgvMedicamentos.TabIndex = 5;
            // 
            // ListaMedicamentos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvDrogueriasMedicamento);
            Controls.Add(dgvMedicamentos);
            Name = "ListaMedicamentos";
            Text = "ListaMedicamentos";
            ((System.ComponentModel.ISupportInitialize)dgvDrogueriasMedicamento).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMedicamentos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnEliminar;
        private Button btnModificar;
        private Button btnAgregar;
        private DataGridView dgvDrogueriasMedicamento;
        private DataGridView dgvMedicamentos;
    }
}