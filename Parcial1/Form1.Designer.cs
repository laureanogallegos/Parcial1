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
            this.btnMedicamentos = new System.Windows.Forms.Button();
            this.btnMonodrogas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMedicamentos
            // 
            this.btnMedicamentos.Location = new System.Drawing.Point(72, 54);
            this.btnMedicamentos.Name = "btnMedicamentos";
            this.btnMedicamentos.Size = new System.Drawing.Size(135, 29);
            this.btnMedicamentos.TabIndex = 0;
            this.btnMedicamentos.Text = "Medicamentos";
            this.btnMedicamentos.UseVisualStyleBackColor = true;
            this.btnMedicamentos.Click += new System.EventHandler(this.btnMedicamentos_Click);
            // 
            // btnMonodrogas
            // 
            this.btnMonodrogas.Location = new System.Drawing.Point(72, 144);
            this.btnMonodrogas.Name = "btnMonodrogas";
            this.btnMonodrogas.Size = new System.Drawing.Size(135, 29);
            this.btnMonodrogas.TabIndex = 1;
            this.btnMonodrogas.Text = "Monodrogas";
            this.btnMonodrogas.UseVisualStyleBackColor = true;
            this.btnMonodrogas.Click += new System.EventHandler(this.btnMonodrogas_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 267);
            this.Controls.Add(this.btnMonodrogas);
            this.Controls.Add(this.btnMedicamentos);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnMedicamentos;
        private Button btnMonodrogas;
    }
}