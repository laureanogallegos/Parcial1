namespace Parcial1
{
    partial class FormDroguerias
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
            btnCerrar = new Button();
            dgvDroguerias = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvDroguerias).BeginInit();
            SuspendLayout();
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(487, 295);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(75, 23);
            btnCerrar.TabIndex = 12;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // dgvDroguerias
            // 
            dgvDroguerias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDroguerias.Location = new Point(12, 12);
            dgvDroguerias.Name = "dgvDroguerias";
            dgvDroguerias.RowTemplate.Height = 25;
            dgvDroguerias.Size = new Size(550, 261);
            dgvDroguerias.TabIndex = 11;
            // 
            // FormDroguerias
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(598, 332);
            Controls.Add(btnCerrar);
            Controls.Add(dgvDroguerias);
            Name = "FormDroguerias";
            Text = "FormDroguerias";
            Load += FormDroguerias_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDroguerias).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnCerrar;
        private DataGridView dgvDroguerias;
    }
}