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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtNombreComercial = new TextBox();
            txtPrecioVenta = new TextBox();
            txtStock = new TextBox();
            txtStockMinimo = new TextBox();
            chkVentaLibre = new CheckBox();
            cmbMonodroga = new ComboBox();
            cmbDrogueria = new ComboBox();
            btnCancelar = new Button();
            btnAceptar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 17);
            label1.Name = "label1";
            label1.Size = new Size(106, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre comercial";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 64);
            label2.Name = "label2";
            label2.Size = new Size(81, 15);
            label2.TabIndex = 0;
            label2.Text = "Es venta libre?";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 122);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 0;
            label3.Text = "Precio venta";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 186);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 0;
            label4.Text = "Stock";
            label4.Click += label3_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 238);
            label5.Name = "label5";
            label5.Size = new Size(81, 15);
            label5.TabIndex = 0;
            label5.Text = "Stock Minimo";
            label5.Click += label3_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 291);
            label6.Name = "label6";
            label6.Size = new Size(70, 15);
            label6.TabIndex = 0;
            label6.Text = "Monodroga";
            label6.Click += label3_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 340);
            label7.Name = "label7";
            label7.Size = new Size(59, 15);
            label7.TabIndex = 0;
            label7.Text = "Drogueria";
            label7.Click += label3_Click;
            // 
            // txtNombreComercial
            // 
            txtNombreComercial.Location = new Point(124, 14);
            txtNombreComercial.Name = "txtNombreComercial";
            txtNombreComercial.Size = new Size(253, 23);
            txtNombreComercial.TabIndex = 1;
            // 
            // txtPrecioVenta
            // 
            txtPrecioVenta.Location = new Point(124, 119);
            txtPrecioVenta.Name = "txtPrecioVenta";
            txtPrecioVenta.Size = new Size(253, 23);
            txtPrecioVenta.TabIndex = 1;
            // 
            // txtStock
            // 
            txtStock.Location = new Point(124, 183);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(253, 23);
            txtStock.TabIndex = 1;
            // 
            // txtStockMinimo
            // 
            txtStockMinimo.Location = new Point(124, 235);
            txtStockMinimo.Name = "txtStockMinimo";
            txtStockMinimo.Size = new Size(253, 23);
            txtStockMinimo.TabIndex = 1;
            // 
            // chkVentaLibre
            // 
            chkVentaLibre.AutoSize = true;
            chkVentaLibre.Location = new Point(124, 65);
            chkVentaLibre.Name = "chkVentaLibre";
            chkVentaLibre.Size = new Size(15, 14);
            chkVentaLibre.TabIndex = 2;
            chkVentaLibre.UseVisualStyleBackColor = true;
            // 
            // cmbMonodroga
            // 
            cmbMonodroga.FormattingEnabled = true;
            cmbMonodroga.Location = new Point(124, 288);
            cmbMonodroga.Name = "cmbMonodroga";
            cmbMonodroga.Size = new Size(253, 23);
            cmbMonodroga.TabIndex = 3;
            // 
            // cmbDrogueria
            // 
            cmbDrogueria.FormattingEnabled = true;
            cmbDrogueria.Location = new Point(124, 340);
            cmbDrogueria.Name = "cmbDrogueria";
            cmbDrogueria.Size = new Size(253, 23);
            cmbDrogueria.TabIndex = 3;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(270, 399);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 15;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(91, 399);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 14;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // FormMedicamento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(419, 434);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(cmbDrogueria);
            Controls.Add(cmbMonodroga);
            Controls.Add(chkVentaLibre);
            Controls.Add(txtStockMinimo);
            Controls.Add(txtStock);
            Controls.Add(txtPrecioVenta);
            Controls.Add(txtNombreComercial);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormMedicamento";
            Text = "FormMedicamento";
            Load += FormMedicamento_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtNombreComercial;
        private TextBox txtPrecioVenta;
        private TextBox txtStock;
        private TextBox txtStockMinimo;
        private CheckBox chkVentaLibre;
        private ComboBox cmbMonodroga;
        private ComboBox cmbDrogueria;
        private Button btnCancelar;
        private Button btnAceptar;
    }
}