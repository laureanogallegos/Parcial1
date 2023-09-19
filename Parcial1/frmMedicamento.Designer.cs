namespace Parcial1
{
    partial class frmMedicamento
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
            groupBox1 = new GroupBox();
            cmbMonodroga = new ComboBox();
            checkboxVentaLibre = new CheckBox();
            numPrecioVenta = new NumericUpDown();
            numStock = new NumericUpDown();
            numStockMinimo = new NumericUpDown();
            txtNombreComercial = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnCancelar = new Button();
            btnAceptar = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPrecioVenta).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStockMinimo).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cmbMonodroga);
            groupBox1.Controls.Add(checkboxVentaLibre);
            groupBox1.Controls.Add(numPrecioVenta);
            groupBox1.Controls.Add(numStock);
            groupBox1.Controls.Add(numStockMinimo);
            groupBox1.Controls.Add(txtNombreComercial);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnCancelar);
            groupBox1.Controls.Add(btnAceptar);
            groupBox1.Location = new Point(12, 21);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(388, 417);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // cmbMonodroga
            // 
            cmbMonodroga.FormattingEnabled = true;
            cmbMonodroga.Location = new Point(184, 303);
            cmbMonodroga.Name = "cmbMonodroga";
            cmbMonodroga.Size = new Size(154, 23);
            cmbMonodroga.TabIndex = 14;
            // 
            // checkboxVentaLibre
            // 
            checkboxVentaLibre.AutoSize = true;
            checkboxVentaLibre.Location = new Point(184, 86);
            checkboxVentaLibre.Name = "checkboxVentaLibre";
            checkboxVentaLibre.Size = new Size(15, 14);
            checkboxVentaLibre.TabIndex = 13;
            checkboxVentaLibre.UseVisualStyleBackColor = true;
            // 
            // numPrecioVenta
            // 
            numPrecioVenta.Location = new Point(184, 147);
            numPrecioVenta.Name = "numPrecioVenta";
            numPrecioVenta.Size = new Size(154, 23);
            numPrecioVenta.TabIndex = 12;
            // 
            // numStock
            // 
            numStock.Location = new Point(184, 189);
            numStock.Name = "numStock";
            numStock.Size = new Size(154, 23);
            numStock.TabIndex = 11;
            // 
            // numStockMinimo
            // 
            numStockMinimo.Location = new Point(184, 237);
            numStockMinimo.Name = "numStockMinimo";
            numStockMinimo.Size = new Size(154, 23);
            numStockMinimo.TabIndex = 10;
            // 
            // txtNombreComercial
            // 
            txtNombreComercial.Location = new Point(184, 36);
            txtNombreComercial.Name = "txtNombreComercial";
            txtNombreComercial.Size = new Size(154, 23);
            txtNombreComercial.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 303);
            label6.Name = "label6";
            label6.Size = new Size(70, 15);
            label6.TabIndex = 7;
            label6.Text = "Monodroga";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 245);
            label5.Name = "label5";
            label5.Size = new Size(81, 15);
            label5.TabIndex = 6;
            label5.Text = "Stock minimo";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 197);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 5;
            label4.Text = "Stock";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 149);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 4;
            label3.Text = "Precio venta";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 86);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 3;
            label2.Text = "Venta libre";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 36);
            label1.Name = "label1";
            label1.Size = new Size(108, 15);
            label1.TabIndex = 2;
            label1.Text = "Nombre Comercial";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(263, 365);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(29, 365);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 0;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // frmMedicamento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(421, 450);
            Controls.Add(groupBox1);
            Name = "frmMedicamento";
            Text = "frmMedicamento";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPrecioVenta).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStockMinimo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label2;
        private Label label1;
        private Button btnCancelar;
        private Button btnAceptar;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private CheckBox checkboxVentaLibre;
        private NumericUpDown numPrecioVenta;
        private NumericUpDown numStock;
        private NumericUpDown numStockMinimo;
        private TextBox txtNombreComercial;
        private ComboBox cmbMonodroga;
    }
}