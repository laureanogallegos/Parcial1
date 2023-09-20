namespace Parcial1
{
    partial class FormSeleccionDrogueria
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
            dgvDroguerias = new DataGridView();
            btnCancelar = new Button();
            btnConfirmar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDroguerias).BeginInit();
            SuspendLayout();
            // 
            // dgvDroguerias
            // 
            dgvDroguerias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDroguerias.Location = new Point(12, 12);
            dgvDroguerias.Name = "dgvDroguerias";
            dgvDroguerias.RowHeadersWidth = 51;
            dgvDroguerias.RowTemplate.Height = 29;
            dgvDroguerias.Size = new Size(776, 370);
            dgvDroguerias.TabIndex = 0;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(12, 393);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnConfirmar
            // 
            btnConfirmar.Location = new Point(121, 393);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(94, 29);
            btnConfirmar.TabIndex = 2;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // FormSeleccionDrogueria
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 434);
            Controls.Add(btnConfirmar);
            Controls.Add(btnCancelar);
            Controls.Add(dgvDroguerias);
            Name = "FormSeleccionDrogueria";
            Text = "FormSeleccionDrogueria";
            Load += FormSeleccionDrogueria_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDroguerias).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvDroguerias;
        private Button btnCancelar;
        private Button btnConfirmar;
    }
}