namespace Parcial1
{
    partial class Principal
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
            BtnMonodrogas = new Button();
            btnMedicamentos = new Button();
            btnDrogueria = new Button();
            SuspendLayout();
            // 
            // BtnMonodrogas
            // 
            BtnMonodrogas.Location = new Point(24, 195);
            BtnMonodrogas.Name = "BtnMonodrogas";
            BtnMonodrogas.Size = new Size(229, 42);
            BtnMonodrogas.TabIndex = 8;
            BtnMonodrogas.Text = "Monodrogas";
            BtnMonodrogas.UseVisualStyleBackColor = true;
            BtnMonodrogas.Click += BtnMonodrogas_Click;
            // 
            // btnMedicamentos
            // 
            btnMedicamentos.Location = new Point(24, 128);
            btnMedicamentos.Name = "btnMedicamentos";
            btnMedicamentos.Size = new Size(229, 39);
            btnMedicamentos.TabIndex = 7;
            btnMedicamentos.Text = "Medicamentos";
            btnMedicamentos.UseVisualStyleBackColor = true;
            btnMedicamentos.Click += btnMedicamentos_Click;
            // 
            // btnDrogueria
            // 
            btnDrogueria.Location = new Point(24, 57);
            btnDrogueria.Name = "btnDrogueria";
            btnDrogueria.Size = new Size(229, 39);
            btnDrogueria.TabIndex = 6;
            btnDrogueria.Text = "Drogueria";
            btnDrogueria.UseVisualStyleBackColor = true;
            btnDrogueria.Click += btnDrogueria_Click;
            // 
            // Principal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(291, 313);
            Controls.Add(BtnMonodrogas);
            Controls.Add(btnMedicamentos);
            Controls.Add(btnDrogueria);
            Name = "Principal";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button BtnMonodrogas;
        private Button btnMedicamentos;
        private Button btnDrogueria;
    }
}