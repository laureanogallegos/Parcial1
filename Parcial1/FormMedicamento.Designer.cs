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
            btnAsignarDrogueria = new Button();
            lblNombre = new Label();
            txtNombre = new TextBox();
            cboxVentaLibre = new CheckBox();
            label1 = new Label();
            txtPrecioVenta = new TextBox();
            txtStock = new TextBox();
            label2 = new Label();
            txtStockMinimo = new TextBox();
            label3 = new Label();
            cmbMonodroga = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            cmbDrogueria = new ComboBox();
            btnAceptar = new Button();
            SuspendLayout();
            // 
            // btnAsignarDrogueria
            // 
            btnAsignarDrogueria.Location = new Point(250, 90);
            btnAsignarDrogueria.Name = "btnAsignarDrogueria";
            btnAsignarDrogueria.Size = new Size(168, 23);
            btnAsignarDrogueria.TabIndex = 0;
            btnAsignarDrogueria.Text = "Asignar Drogueria";
            btnAsignarDrogueria.UseVisualStyleBackColor = true;
            btnAsignarDrogueria.Click += button1_Click;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(12, 9);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(51, 15);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(65, 6);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 2;
            // 
            // cboxVentaLibre
            // 
            cboxVentaLibre.AutoSize = true;
            cboxVentaLibre.Location = new Point(194, 10);
            cboxVentaLibre.Name = "cboxVentaLibre";
            cboxVentaLibre.Size = new Size(84, 19);
            cboxVentaLibre.TabIndex = 3;
            cboxVentaLibre.Text = "Venta Libre";
            cboxVentaLibre.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 43);
            label1.Name = "label1";
            label1.Size = new Size(72, 15);
            label1.TabIndex = 4;
            label1.Text = "Precio Venta";
            // 
            // txtPrecioVenta
            // 
            txtPrecioVenta.Location = new Point(99, 40);
            txtPrecioVenta.Name = "txtPrecioVenta";
            txtPrecioVenta.Size = new Size(100, 23);
            txtPrecioVenta.TabIndex = 5;
            // 
            // txtStock
            // 
            txtStock.Location = new Point(99, 69);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(100, 23);
            txtStock.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 72);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 6;
            label2.Text = "Stock";
            // 
            // txtStockMinimo
            // 
            txtStockMinimo.Location = new Point(99, 98);
            txtStockMinimo.Name = "txtStockMinimo";
            txtStockMinimo.Size = new Size(100, 23);
            txtStockMinimo.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 101);
            label3.Name = "label3";
            label3.Size = new Size(81, 15);
            label3.TabIndex = 8;
            label3.Text = "Stock Minimo";
            // 
            // cmbMonodroga
            // 
            cmbMonodroga.FormattingEnabled = true;
            cmbMonodroga.Location = new Point(297, 35);
            cmbMonodroga.Name = "cmbMonodroga";
            cmbMonodroga.Size = new Size(121, 23);
            cmbMonodroga.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(210, 43);
            label4.Name = "label4";
            label4.Size = new Size(70, 15);
            label4.TabIndex = 11;
            label4.Text = "Monodroga";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(210, 72);
            label5.Name = "label5";
            label5.Size = new Size(59, 15);
            label5.TabIndex = 13;
            label5.Text = "Drogueria";
            // 
            // cmbDrogueria
            // 
            cmbDrogueria.FormattingEnabled = true;
            cmbDrogueria.Location = new Point(297, 64);
            cmbDrogueria.Name = "cmbDrogueria";
            cmbDrogueria.Size = new Size(121, 23);
            cmbDrogueria.TabIndex = 12;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(12, 146);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(168, 23);
            btnAceptar.TabIndex = 14;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // FormMedicamento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(454, 183);
            Controls.Add(btnAceptar);
            Controls.Add(label5);
            Controls.Add(cmbDrogueria);
            Controls.Add(label4);
            Controls.Add(cmbMonodroga);
            Controls.Add(txtStockMinimo);
            Controls.Add(label3);
            Controls.Add(txtStock);
            Controls.Add(label2);
            Controls.Add(txtPrecioVenta);
            Controls.Add(label1);
            Controls.Add(cboxVentaLibre);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(btnAsignarDrogueria);
            Name = "FormMedicamento";
            Text = "FormMedicamento";
            Load += FormMedicamento_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAsignarDrogueria;
        private Label lblNombre;
        private TextBox txtNombre;
        private CheckBox cboxVentaLibre;
        private Label label1;
        private TextBox txtPrecioVenta;
        private TextBox txtStock;
        private Label label2;
        private TextBox txtStockMinimo;
        private Label label3;
        private ComboBox cmbMonodroga;
        private Label label4;
        private Label label5;
        private ComboBox cmbDrogueria;
        private Button btnAceptar;
    }
}