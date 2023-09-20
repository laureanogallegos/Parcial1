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
            btnAceptar = new Button();
            txtNombreComercial = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtPrecioVenta = new TextBox();
            label3 = new Label();
            txtStockMinimo = new TextBox();
            label4 = new Label();
            cmbMonodroga = new ComboBox();
            Stock = new Label();
            txtStock = new TextBox();
            cmbDrogueria = new ComboBox();
            label5 = new Label();
            btnCancelar = new Button();
            dgvDrogueriasAsociadas = new DataGridView();
            btnDesasignar = new Button();
            btnAsignarDrogueria = new Button();
            checkVentaLibre = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dgvDrogueriasAsociadas).BeginInit();
            SuspendLayout();
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(193, 415);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 0;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // txtNombreComercial
            // 
            txtNombreComercial.Location = new Point(246, 20);
            txtNombreComercial.Name = "txtNombreComercial";
            txtNombreComercial.Size = new Size(100, 23);
            txtNombreComercial.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(135, 23);
            label1.Name = "label1";
            label1.Size = new Size(105, 15);
            label1.TabIndex = 2;
            label1.Text = "NombreComercial";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(171, 52);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 4;
            label2.Text = "PrecioVenta";
            // 
            // txtPrecioVenta
            // 
            txtPrecioVenta.Location = new Point(246, 49);
            txtPrecioVenta.Name = "txtPrecioVenta";
            txtPrecioVenta.Size = new Size(100, 23);
            txtPrecioVenta.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(162, 111);
            label3.Name = "label3";
            label3.Size = new Size(78, 15);
            label3.TabIndex = 6;
            label3.Text = "StockMinimo";
            // 
            // txtStockMinimo
            // 
            txtStockMinimo.Location = new Point(246, 108);
            txtStockMinimo.Name = "txtStockMinimo";
            txtStockMinimo.Size = new Size(100, 23);
            txtStockMinimo.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(170, 163);
            label4.Name = "label4";
            label4.Size = new Size(70, 15);
            label4.TabIndex = 8;
            label4.Text = "Monodroga";
            // 
            // cmbMonodroga
            // 
            cmbMonodroga.FormattingEnabled = true;
            cmbMonodroga.Location = new Point(246, 160);
            cmbMonodroga.Name = "cmbMonodroga";
            cmbMonodroga.Size = new Size(121, 23);
            cmbMonodroga.TabIndex = 9;
            // 
            // Stock
            // 
            Stock.AutoSize = true;
            Stock.Location = new Point(204, 82);
            Stock.Name = "Stock";
            Stock.Size = new Size(36, 15);
            Stock.TabIndex = 11;
            Stock.Text = "Stock";
            // 
            // txtStock
            // 
            txtStock.Location = new Point(246, 79);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(100, 23);
            txtStock.TabIndex = 10;
            // 
            // cmbDrogueria
            // 
            cmbDrogueria.FormattingEnabled = true;
            cmbDrogueria.Location = new Point(109, 352);
            cmbDrogueria.Name = "cmbDrogueria";
            cmbDrogueria.Size = new Size(121, 23);
            cmbDrogueria.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 355);
            label5.Name = "label5";
            label5.Size = new Size(91, 15);
            label5.TabIndex = 12;
            label5.Text = "Lista Droguerias";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(274, 415);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 14;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // dgvDrogueriasAsociadas
            // 
            dgvDrogueriasAsociadas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDrogueriasAsociadas.Location = new Point(12, 196);
            dgvDrogueriasAsociadas.Name = "dgvDrogueriasAsociadas";
            dgvDrogueriasAsociadas.RowTemplate.Height = 25;
            dgvDrogueriasAsociadas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDrogueriasAsociadas.Size = new Size(501, 150);
            dgvDrogueriasAsociadas.TabIndex = 15;
            // 
            // btnDesasignar
            // 
            btnDesasignar.Location = new Point(355, 351);
            btnDesasignar.Name = "btnDesasignar";
            btnDesasignar.Size = new Size(113, 23);
            btnDesasignar.TabIndex = 17;
            btnDesasignar.Text = "Desasignar Drogueria";
            btnDesasignar.UseVisualStyleBackColor = true;
            // 
            // btnAsignarDrogueria
            // 
            btnAsignarDrogueria.Location = new Point(236, 352);
            btnAsignarDrogueria.Name = "btnAsignarDrogueria";
            btnAsignarDrogueria.Size = new Size(113, 23);
            btnAsignarDrogueria.TabIndex = 16;
            btnAsignarDrogueria.Text = "Asignar drogueria";
            btnAsignarDrogueria.UseVisualStyleBackColor = true;
            btnAsignarDrogueria.Click += btnAsignarDrogueria_Click;
            // 
            // checkVentaLibre
            // 
            checkVentaLibre.AutoSize = true;
            checkVentaLibre.Location = new Point(246, 137);
            checkVentaLibre.Name = "checkVentaLibre";
            checkVentaLibre.Size = new Size(81, 19);
            checkVentaLibre.TabIndex = 18;
            checkVentaLibre.Text = "VentaLibre";
            checkVentaLibre.UseVisualStyleBackColor = true;
            // 
            // FormMedicamento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(543, 450);
            Controls.Add(checkVentaLibre);
            Controls.Add(btnDesasignar);
            Controls.Add(btnAsignarDrogueria);
            Controls.Add(dgvDrogueriasAsociadas);
            Controls.Add(btnCancelar);
            Controls.Add(cmbDrogueria);
            Controls.Add(label5);
            Controls.Add(Stock);
            Controls.Add(txtStock);
            Controls.Add(cmbMonodroga);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtStockMinimo);
            Controls.Add(label2);
            Controls.Add(txtPrecioVenta);
            Controls.Add(label1);
            Controls.Add(txtNombreComercial);
            Controls.Add(btnAceptar);
            Name = "FormMedicamento";
            Text = "FormMedicamento";
            Load += FormMedicamento_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDrogueriasAsociadas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAceptar;
        private TextBox txtNombreComercial;
        private Label label1;
        private Label label2;
        private TextBox txtPrecioVenta;
        private Label label3;
        private TextBox txtStockMinimo;
        private Label label4;
        private ComboBox cmbMonodroga;
        private Label Stock;
        private TextBox txtStock;
        private ComboBox cmbDrogueria;
        private Label label5;
        private Button btnCancelar;
        private DataGridView dgvDrogueriasAsociadas;
        private Button btnDesasignar;
        private Button btnAsignarDrogueria;
        private CheckBox checkVentaLibre;
    }
}