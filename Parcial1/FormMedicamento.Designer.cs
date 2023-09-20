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
            txtNombre = new TextBox();
            txtPrecio = new TextBox();
            label3 = new Label();
            txtStock = new TextBox();
            label4 = new Label();
            txtStockMinimo = new TextBox();
            label5 = new Label();
            label6 = new Label();
            checkBox1 = new CheckBox();
            dgvDroguerias = new DataGridView();
            dgvDrogueriasAll = new DataGridView();
            btmAgregar = new Button();
            comboMonodroga = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvDroguerias).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDrogueriasAll).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 53);
            label1.Name = "label1";
            label1.Size = new Size(105, 15);
            label1.TabIndex = 0;
            label1.Text = "NombreComercial";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(161, 50);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(194, 23);
            txtNombre.TabIndex = 1;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(161, 78);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(194, 23);
            txtPrecio.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(41, 81);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 4;
            label3.Text = "Precio Venta";
            // 
            // txtStock
            // 
            txtStock.Location = new Point(161, 107);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(194, 23);
            txtStock.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(41, 110);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 6;
            label4.Text = "Stock";
            // 
            // txtStockMinimo
            // 
            txtStockMinimo.Location = new Point(161, 136);
            txtStockMinimo.Name = "txtStockMinimo";
            txtStockMinimo.Size = new Size(194, 23);
            txtStockMinimo.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(41, 139);
            label5.Name = "label5";
            label5.Size = new Size(78, 15);
            label5.TabIndex = 8;
            label5.Text = "StockMinimo";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(49, 179);
            label6.Name = "label6";
            label6.Size = new Size(70, 15);
            label6.TabIndex = 10;
            label6.Text = "Monodroga";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(271, 225);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(84, 19);
            checkBox1.TabIndex = 12;
            checkBox1.Text = "Venta Libre";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // dgvDroguerias
            // 
            dgvDroguerias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDroguerias.Location = new Point(468, 29);
            dgvDroguerias.Name = "dgvDroguerias";
            dgvDroguerias.RowTemplate.Height = 25;
            dgvDroguerias.Size = new Size(365, 111);
            dgvDroguerias.TabIndex = 13;
            // 
            // dgvDrogueriasAll
            // 
            dgvDrogueriasAll.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDrogueriasAll.Location = new Point(468, 176);
            dgvDrogueriasAll.Name = "dgvDrogueriasAll";
            dgvDrogueriasAll.RowTemplate.Height = 25;
            dgvDrogueriasAll.Size = new Size(365, 111);
            dgvDrogueriasAll.TabIndex = 14;
            // 
            // btnAgregarDrogueria
            // 

            // 
            // btmAgregar
            // 
            btmAgregar.Location = new Point(758, 302);
            btmAgregar.Name = "btmAgregar";
            btmAgregar.Size = new Size(75, 23);
            btmAgregar.TabIndex = 16;
            btmAgregar.Text = "Agregar";
            btmAgregar.UseVisualStyleBackColor = true;
            // 
            // comboMonodroga
            // 
            comboMonodroga.FormattingEnabled = true;
            comboMonodroga.Location = new Point(161, 179);
            comboMonodroga.Name = "comboMonodroga";
            comboMonodroga.Size = new Size(194, 23);
            comboMonodroga.TabIndex = 17;
            // 
            // FormMedicamento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 339);
            Controls.Add(comboMonodroga);
            Controls.Add(btmAgregar);
            Controls.Add(dgvDrogueriasAll);
            Controls.Add(dgvDroguerias);
            Controls.Add(checkBox1);
            Controls.Add(label6);
            Controls.Add(txtStockMinimo);
            Controls.Add(label5);
            Controls.Add(txtStock);
            Controls.Add(label4);
            Controls.Add(txtPrecio);
            Controls.Add(label3);
            Controls.Add(txtNombre);
            Controls.Add(label1);
            Name = "FormMedicamento";
            Text = "FormMedicamento";
            ((System.ComponentModel.ISupportInitialize)dgvDroguerias).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDrogueriasAll).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNombre;
        private TextBox txtPrecio;
        private Label label3;
        private TextBox txtStock;
        private Label label4;
        private TextBox txtStockMinimo;
        private Label label5;
        private TextBox textBox6;
        private Label label6;
        private Label label7;
        private TextBox textBox7;
        private CheckBox checkBox1;
        private DataGridView dgvDroguerias;
        private DataGridView dgvDrogueriasAll;
        private Button btnAgregarD;
        private Button btmAgregar;
        private ComboBox comboMonodroga;
    }
}