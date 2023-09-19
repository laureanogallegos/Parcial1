namespace Parcial1
{
    partial class FormMonodrogas
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
            dgvMonodrogas = new DataGridView();
            btnCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMonodrogas).BeginInit();
            SuspendLayout();
            // 
            // dgvMonodrogas
            // 
            dgvMonodrogas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMonodrogas.Location = new Point(23, 12);
            dgvMonodrogas.Name = "dgvMonodrogas";
            dgvMonodrogas.RowTemplate.Height = 25;
            dgvMonodrogas.Size = new Size(550, 261);
            dgvMonodrogas.TabIndex = 0;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(498, 295);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(75, 23);
            btnCerrar.TabIndex = 10;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // FormMonodrogas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(602, 330);
            Controls.Add(btnCerrar);
            Controls.Add(dgvMonodrogas);
            Name = "FormMonodrogas";
            Text = "FormMonodrogas";
            Load += FormMonodrogas_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMonodrogas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvMonodrogas;
        private Button btnCerrar;
    }
}