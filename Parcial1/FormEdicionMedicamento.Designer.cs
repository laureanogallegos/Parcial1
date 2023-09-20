namespace Parcial1
{
    partial class FormEdicionMedicamento
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
            txtNombreComercial = new TextBox();
            cbEsVentaLibre = new CheckBox();
            label1 = new Label();
            numPrecioVenta = new NumericUpDown();
            numStock = new NumericUpDown();
            numStockMinimo = new NumericUpDown();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            dgvDroguerias = new DataGridView();
            btnAgregarDrogueria = new Button();
            btnEliminarDrogueria = new Button();
            gbDroguerias = new GroupBox();
            btnConfirmar = new Button();
            btnCancelar = new Button();
            cbMonodroga = new ComboBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)numPrecioVenta).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStockMinimo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDroguerias).BeginInit();
            gbDroguerias.SuspendLayout();
            SuspendLayout();
            // 
            // txtNombreComercial
            // 
            txtNombreComercial.Location = new Point(12, 65);
            txtNombreComercial.Name = "txtNombreComercial";
            txtNombreComercial.Size = new Size(125, 27);
            txtNombreComercial.TabIndex = 0;
            // 
            // cbEsVentaLibre
            // 
            cbEsVentaLibre.AutoSize = true;
            cbEsVentaLibre.Location = new Point(12, 120);
            cbEsVentaLibre.Name = "cbEsVentaLibre";
            cbEsVentaLibre.Size = new Size(140, 24);
            cbEsVentaLibre.TabIndex = 1;
            cbEsVentaLibre.Text = "Es de venta libre";
            cbEsVentaLibre.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 42);
            label1.Name = "label1";
            label1.Size = new Size(133, 20);
            label1.TabIndex = 2;
            label1.Text = "Nombre comercial";
            // 
            // numPrecioVenta
            // 
            numPrecioVenta.DecimalPlaces = 2;
            numPrecioVenta.Location = new Point(12, 185);
            numPrecioVenta.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numPrecioVenta.Name = "numPrecioVenta";
            numPrecioVenta.Size = new Size(150, 27);
            numPrecioVenta.TabIndex = 4;
            // 
            // numStock
            // 
            numStock.Location = new Point(12, 250);
            numStock.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numStock.Name = "numStock";
            numStock.Size = new Size(150, 27);
            numStock.TabIndex = 5;
            // 
            // numStockMinimo
            // 
            numStockMinimo.Location = new Point(12, 312);
            numStockMinimo.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numStockMinimo.Name = "numStockMinimo";
            numStockMinimo.Size = new Size(150, 27);
            numStockMinimo.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 162);
            label2.Name = "label2";
            label2.Size = new Size(111, 20);
            label2.TabIndex = 7;
            label2.Text = "Precio de venta";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 227);
            label3.Name = "label3";
            label3.Size = new Size(45, 20);
            label3.TabIndex = 8;
            label3.Text = "Stock";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 289);
            label4.Name = "label4";
            label4.Size = new Size(100, 20);
            label4.TabIndex = 9;
            label4.Text = "Stock mínimo";
            // 
            // dgvDroguerias
            // 
            dgvDroguerias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDroguerias.Location = new Point(6, 26);
            dgvDroguerias.Name = "dgvDroguerias";
            dgvDroguerias.RowHeadersWidth = 51;
            dgvDroguerias.RowTemplate.Height = 29;
            dgvDroguerias.Size = new Size(444, 200);
            dgvDroguerias.TabIndex = 10;
            // 
            // btnAgregarDrogueria
            // 
            btnAgregarDrogueria.Location = new Point(6, 232);
            btnAgregarDrogueria.Name = "btnAgregarDrogueria";
            btnAgregarDrogueria.Size = new Size(159, 29);
            btnAgregarDrogueria.TabIndex = 11;
            btnAgregarDrogueria.Text = "Agregar Droguería";
            btnAgregarDrogueria.UseVisualStyleBackColor = true;
            btnAgregarDrogueria.Click += btnAgregarDrogueria_Click;
            // 
            // btnEliminarDrogueria
            // 
            btnEliminarDrogueria.Location = new Point(297, 232);
            btnEliminarDrogueria.Name = "btnEliminarDrogueria";
            btnEliminarDrogueria.Size = new Size(153, 29);
            btnEliminarDrogueria.TabIndex = 12;
            btnEliminarDrogueria.Text = "Eliminar Droguería";
            btnEliminarDrogueria.UseVisualStyleBackColor = true;
            btnEliminarDrogueria.Click += btnEliminarDrogueria_Click;
            // 
            // gbDroguerias
            // 
            gbDroguerias.Controls.Add(dgvDroguerias);
            gbDroguerias.Controls.Add(btnEliminarDrogueria);
            gbDroguerias.Controls.Add(btnAgregarDrogueria);
            gbDroguerias.Location = new Point(332, 27);
            gbDroguerias.Name = "gbDroguerias";
            gbDroguerias.Size = new Size(456, 268);
            gbDroguerias.TabIndex = 13;
            gbDroguerias.TabStop = false;
            gbDroguerias.Text = "Droguerías";
            // 
            // btnConfirmar
            // 
            btnConfirmar.Location = new Point(281, 409);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(94, 29);
            btnConfirmar.TabIndex = 14;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(403, 409);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 15;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // cbMonodroga
            // 
            cbMonodroga.FormattingEnabled = true;
            cbMonodroga.Location = new Point(12, 372);
            cbMonodroga.Name = "cbMonodroga";
            cbMonodroga.Size = new Size(151, 28);
            cbMonodroga.TabIndex = 16;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 349);
            label5.Name = "label5";
            label5.Size = new Size(88, 20);
            label5.TabIndex = 17;
            label5.Text = "Monodroga";
            // 
            // FormEdicionMedicamento
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(cbMonodroga);
            Controls.Add(btnCancelar);
            Controls.Add(btnConfirmar);
            Controls.Add(gbDroguerias);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(numStockMinimo);
            Controls.Add(numStock);
            Controls.Add(numPrecioVenta);
            Controls.Add(label1);
            Controls.Add(cbEsVentaLibre);
            Controls.Add(txtNombreComercial);
            Name = "FormEdicionMedicamento";
            Text = "FormEdicionMedicamento";
            Load += FormEdicionMedicamento_Load;
            ((System.ComponentModel.ISupportInitialize)numPrecioVenta).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStockMinimo).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDroguerias).EndInit();
            gbDroguerias.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombreComercial;
        private CheckBox cbEsVentaLibre;
        private Label label1;
        private NumericUpDown numPrecioVenta;
        private NumericUpDown numStock;
        private NumericUpDown numStockMinimo;
        private Label label2;
        private Label label3;
        private Label label4;
        private DataGridView dgvDroguerias;
        private Button btnAgregarDrogueria;
        private Button btnEliminarDrogueria;
        private GroupBox gbDroguerias;
        private Button btnConfirmar;
        private Button btnCancelar;
        private ComboBox cbMonodroga;
        private Label label5;
    }
}