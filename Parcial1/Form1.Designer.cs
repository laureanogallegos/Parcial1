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
            btnMedicamento = new Button();
            btnSalir = new Button();
            SuspendLayout();
            // 
            // btnMedicamento
            // 
            btnMedicamento.Location = new Point(25, 38);
            btnMedicamento.Name = "btnMedicamento";
            btnMedicamento.Size = new Size(146, 55);
            btnMedicamento.TabIndex = 0;
            btnMedicamento.Text = "Agregar Medicamento";
            btnMedicamento.UseVisualStyleBackColor = true;
            btnMedicamento.Click += btnMedicamento_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(214, 54);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 2;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(315, 122);
            Controls.Add(btnSalir);
            Controls.Add(btnMedicamento);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnMedicamento;
        private Button btnSalir;
    }
}