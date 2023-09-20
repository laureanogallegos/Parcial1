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
            txtNombreComercial = new TextBox();
            chkVentaLibre = new CheckBox();
            label2 = new Label();
            txtPrecioVenta = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtStock = new TextBox();
            txtStockMinimo = new TextBox();
            cmbMonodroga = new ComboBox();
            cmbDrogueria = new ComboBox();
            btnAceptar = new Button();
            btnCancelar = new Button();
            btnAgregarDrogueria = new Button();
            dgvDroguerias = new DataGridView();
            btnEliminarDrogueria = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDroguerias).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 15);
            label1.Name = "label1";
            label1.Size = new Size(108, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre Comercial";
            // 
            // txtNombreComercial
            // 
            txtNombreComercial.Location = new Point(173, 12);
            txtNombreComercial.Name = "txtNombreComercial";
            txtNombreComercial.Size = new Size(183, 23);
            txtNombreComercial.TabIndex = 1;
            // 
            // chkVentaLibre
            // 
            chkVentaLibre.AutoSize = true;
            chkVentaLibre.Location = new Point(226, 57);
            chkVentaLibre.Name = "chkVentaLibre";
            chkVentaLibre.Size = new Size(84, 19);
            chkVentaLibre.TabIndex = 2;
            chkVentaLibre.Text = "Venta Libre";
            chkVentaLibre.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(66, 95);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.No;
            label2.Size = new Size(88, 15);
            label2.TabIndex = 3;
            label2.Text = "Precio de venta";
            // 
            // txtPrecioVenta
            // 
            txtPrecioVenta.Location = new Point(173, 92);
            txtPrecioVenta.Name = "txtPrecioVenta";
            txtPrecioVenta.Size = new Size(183, 23);
            txtPrecioVenta.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(116, 155);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 5;
            label3.Text = "Stock";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(73, 199);
            label4.Name = "label4";
            label4.Size = new Size(81, 15);
            label4.TabIndex = 6;
            label4.Text = "Stock Minimo";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(84, 241);
            label5.Name = "label5";
            label5.Size = new Size(70, 15);
            label5.TabIndex = 7;
            label5.Text = "Monodroga";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(95, 292);
            label6.Name = "label6";
            label6.Size = new Size(59, 15);
            label6.TabIndex = 8;
            label6.Text = "Drogueria";
            // 
            // txtStock
            // 
            txtStock.Location = new Point(174, 154);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(183, 23);
            txtStock.TabIndex = 9;
            // 
            // txtStockMinimo
            // 
            txtStockMinimo.Location = new Point(173, 196);
            txtStockMinimo.Name = "txtStockMinimo";
            txtStockMinimo.Size = new Size(183, 23);
            txtStockMinimo.TabIndex = 10;
            // 
            // cmbMonodroga
            // 
            cmbMonodroga.FormattingEnabled = true;
            cmbMonodroga.Location = new Point(175, 241);
            cmbMonodroga.Name = "cmbMonodroga";
            cmbMonodroga.Size = new Size(183, 23);
            cmbMonodroga.TabIndex = 11;
            // 
            // cmbDrogueria
            // 
            cmbDrogueria.FormattingEnabled = true;
            cmbDrogueria.Location = new Point(175, 284);
            cmbDrogueria.Name = "cmbDrogueria";
            cmbDrogueria.Size = new Size(183, 23);
            cmbDrogueria.TabIndex = 12;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(151, 481);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 13;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click_1;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(302, 481);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 14;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAgregarDrogueria
            // 
            btnAgregarDrogueria.Location = new Point(177, 320);
            btnAgregarDrogueria.Name = "btnAgregarDrogueria";
            btnAgregarDrogueria.Size = new Size(183, 23);
            btnAgregarDrogueria.TabIndex = 15;
            btnAgregarDrogueria.Text = "Agregar Drogueria";
            btnAgregarDrogueria.UseVisualStyleBackColor = true;
            btnAgregarDrogueria.Click += btnAgregarDrogueria_Click_1;
            // 
            // dgvDroguerias
            // 
            dgvDroguerias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDroguerias.Location = new Point(151, 349);
            dgvDroguerias.Name = "dgvDroguerias";
            dgvDroguerias.RowTemplate.Height = 25;
            dgvDroguerias.Size = new Size(240, 94);
            dgvDroguerias.TabIndex = 16;
            // 
            // btnEliminarDrogueria
            // 
            btnEliminarDrogueria.Location = new Point(177, 449);
            btnEliminarDrogueria.Name = "btnEliminarDrogueria";
            btnEliminarDrogueria.Size = new Size(179, 23);
            btnEliminarDrogueria.TabIndex = 17;
            btnEliminarDrogueria.Text = "Eliminar drogueria";
            btnEliminarDrogueria.UseVisualStyleBackColor = true;
            btnEliminarDrogueria.Click += btnEliminarDrogueria_Click_1;
            // 
            // FormMedicamento
            // 
            AcceptButton = btnAceptar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(423, 529);
            ControlBox = false;
            Controls.Add(btnEliminarDrogueria);
            Controls.Add(dgvDroguerias);
            Controls.Add(btnAgregarDrogueria);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(cmbDrogueria);
            Controls.Add(cmbMonodroga);
            Controls.Add(txtStockMinimo);
            Controls.Add(txtStock);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtPrecioVenta);
            Controls.Add(label2);
            Controls.Add(chkVentaLibre);
            Controls.Add(txtNombreComercial);
            Controls.Add(label1);
            Name = "FormMedicamento";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormMedicamento";
            Load += FormMedicamento_Load_1;
            ((System.ComponentModel.ISupportInitialize)dgvDroguerias).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNombreComercial;
        private CheckBox chkVentaLibre;
        private Label label2;
        private TextBox txtPrecioVenta;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtStock;
        private TextBox txtStockMinimo;
        private ComboBox cmbMonodroga;
        private ComboBox cmbDrogueria;
        private Button btnAceptar;
        private Button btnCancelar;
        private Button btnAgregarDrogueria;
        private DataGridView dgvDroguerias;
        private Button btnEliminarDrogueria;
    }
}