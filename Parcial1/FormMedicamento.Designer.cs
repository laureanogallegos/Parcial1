namespace Parcial1
{
    partial class FormMedicamento
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
            txtNombre = new TextBox();
            numPrecio = new NumericUpDown();
            numStock = new NumericUpDown();
            numStockMinimo = new NumericUpDown();
            comMonodroga = new ComboBox();
            chkVentaLibre = new CheckBox();
            btnAceptar = new Button();
            btnCerrar = new Button();
            label1 = new Label();
            nu = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)numPrecio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStockMinimo).BeginInit();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(12, 12);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 0;
            // 
            // numPrecio
            // 
            numPrecio.Location = new Point(12, 41);
            numPrecio.Name = "numPrecio";
            numPrecio.Size = new Size(120, 23);
            numPrecio.TabIndex = 1;
            // 
            // numStock
            // 
            numStock.Location = new Point(12, 70);
            numStock.Name = "numStock";
            numStock.Size = new Size(120, 23);
            numStock.TabIndex = 2;
            // 
            // numStockMinimo
            // 
            numStockMinimo.Location = new Point(12, 99);
            numStockMinimo.Name = "numStockMinimo";
            numStockMinimo.Size = new Size(120, 23);
            numStockMinimo.TabIndex = 3;
            // 
            // comMonodroga
            // 
            comMonodroga.FormattingEnabled = true;
            comMonodroga.Location = new Point(12, 128);
            comMonodroga.Name = "comMonodroga";
            comMonodroga.Size = new Size(121, 23);
            comMonodroga.TabIndex = 4;
            // 
            // chkVentaLibre
            // 
            chkVentaLibre.AutoSize = true;
            chkVentaLibre.Location = new Point(12, 157);
            chkVentaLibre.Name = "chkVentaLibre";
            chkVentaLibre.Size = new Size(83, 19);
            chkVentaLibre.TabIndex = 5;
            chkVentaLibre.Text = "checkBox1";
            chkVentaLibre.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(12, 182);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 6;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(126, 182);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(75, 23);
            btnCerrar.TabIndex = 7;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(147, 20);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 8;
            label1.Text = "label1";
            // 
            // nu
            // 
            nu.AutoSize = true;
            nu.Location = new Point(147, 49);
            nu.Name = "nu";
            nu.Size = new Size(38, 15);
            nu.TabIndex = 9;
            nu.Text = "label2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(147, 78);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 10;
            label3.Text = "label3";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(147, 107);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 11;
            label4.Text = "label4";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(147, 136);
            label5.Name = "label5";
            label5.Size = new Size(38, 15);
            label5.TabIndex = 12;
            label5.Text = "label5";
            // 
            // FormMedicamento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(223, 220);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(nu);
            Controls.Add(label1);
            Controls.Add(btnCerrar);
            Controls.Add(btnAceptar);
            Controls.Add(chkVentaLibre);
            Controls.Add(comMonodroga);
            Controls.Add(numStockMinimo);
            Controls.Add(numStock);
            Controls.Add(numPrecio);
            Controls.Add(txtNombre);
            Name = "FormMedicamento";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)numPrecio).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStockMinimo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombre;
        private NumericUpDown numPrecio;
        private NumericUpDown numStock;
        private NumericUpDown numStockMinimo;
        private ComboBox comMonodroga;
        private CheckBox chkVentaLibre;
        private Button btnAceptar;
        private Button btnCerrar;
        private Label label1;
        private Label nu;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}