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
            dgvDrogueriasDelMedicamento = new DataGridView();
            dgvTodasLasDroguerias = new DataGridView();
            buttonAgregarDrogueria1 = new Button();
            elimnarDrogueria = new Button();
            label8 = new Label();
            label9 = new Label();
            checkBox1 = new CheckBox();
            cboxMonodroga = new ComboBox();
            nudStockMinimo = new NumericUpDown();
            nudStock = new NumericUpDown();
            nudPrecio = new NumericUpDown();
            tboxNombre = new TextBox();
            btnFinalizar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDrogueriasDelMedicamento).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTodasLasDroguerias).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudStockMinimo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPrecio).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(65, 42);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 0;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(65, 112);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 1;
            label2.Text = "Precio";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(65, 148);
            label3.Name = "label3";
            label3.Size = new Size(45, 20);
            label3.TabIndex = 2;
            label3.Text = "Stock";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(65, 188);
            label4.Name = "label4";
            label4.Size = new Size(100, 20);
            label4.TabIndex = 3;
            label4.Text = "Stock Minimo";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(65, 74);
            label5.Name = "label5";
            label5.Size = new Size(83, 20);
            label5.TabIndex = 4;
            label5.Text = "Venta Libre";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(65, 226);
            label6.Name = "label6";
            label6.Size = new Size(88, 20);
            label6.TabIndex = 5;
            label6.Text = "Monodroga";
            // 
            // dgvDrogueriasDelMedicamento
            // 
            dgvDrogueriasDelMedicamento.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDrogueriasDelMedicamento.Location = new Point(520, 145);
            dgvDrogueriasDelMedicamento.Name = "dgvDrogueriasDelMedicamento";
            dgvDrogueriasDelMedicamento.RowHeadersWidth = 51;
            dgvDrogueriasDelMedicamento.RowTemplate.Height = 29;
            dgvDrogueriasDelMedicamento.Size = new Size(300, 369);
            dgvDrogueriasDelMedicamento.TabIndex = 7;
            // 
            // dgvTodasLasDroguerias
            // 
            dgvTodasLasDroguerias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTodasLasDroguerias.Location = new Point(832, 145);
            dgvTodasLasDroguerias.Name = "dgvTodasLasDroguerias";
            dgvTodasLasDroguerias.RowHeadersWidth = 51;
            dgvTodasLasDroguerias.RowTemplate.Height = 29;
            dgvTodasLasDroguerias.Size = new Size(328, 369);
            dgvTodasLasDroguerias.TabIndex = 8;
            // 
            // buttonAgregarDrogueria1
            // 
            buttonAgregarDrogueria1.Location = new Point(919, 103);
            buttonAgregarDrogueria1.Name = "buttonAgregarDrogueria1";
            buttonAgregarDrogueria1.Size = new Size(175, 29);
            buttonAgregarDrogueria1.TabIndex = 9;
            buttonAgregarDrogueria1.Text = "Agregar Seleccionado";
            buttonAgregarDrogueria1.UseVisualStyleBackColor = true;
            buttonAgregarDrogueria1.Click += buttonAgregarDrogueria1_Click;
            // 
            // elimnarDrogueria
            // 
            elimnarDrogueria.Location = new Point(580, 103);
            elimnarDrogueria.Name = "elimnarDrogueria";
            elimnarDrogueria.Size = new Size(175, 29);
            elimnarDrogueria.TabIndex = 10;
            elimnarDrogueria.Text = "Eliminar Seleccionado";
            elimnarDrogueria.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(571, 74);
            label8.Name = "label8";
            label8.Size = new Size(203, 20);
            label8.TabIndex = 11;
            label8.Text = "Droguerias del Medicamento";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(933, 74);
            label9.Name = "label9";
            label9.Size = new Size(147, 20);
            label9.TabIndex = 12;
            label9.Text = "Todas las Droguerias";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(264, 77);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(18, 17);
            checkBox1.TabIndex = 13;
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // cboxMonodroga
            // 
            cboxMonodroga.FormattingEnabled = true;
            cboxMonodroga.Location = new Point(197, 223);
            cboxMonodroga.Name = "cboxMonodroga";
            cboxMonodroga.Size = new Size(151, 28);
            cboxMonodroga.TabIndex = 14;
            // 
            // nudStockMinimo
            // 
            nudStockMinimo.Location = new Point(198, 186);
            nudStockMinimo.Maximum = new decimal(new int[] { 1874919423, 2328306, 0, 0 });
            nudStockMinimo.Name = "nudStockMinimo";
            nudStockMinimo.Size = new Size(150, 27);
            nudStockMinimo.TabIndex = 15;
            // 
            // nudStock
            // 
            nudStock.Location = new Point(198, 148);
            nudStock.Maximum = new decimal(new int[] { 1874919423, 2328306, 0, 0 });
            nudStock.Name = "nudStock";
            nudStock.Size = new Size(150, 27);
            nudStock.TabIndex = 16;
            // 
            // nudPrecio
            // 
            nudPrecio.DecimalPlaces = 28;
            nudPrecio.Location = new Point(198, 110);
            nudPrecio.Maximum = new decimal(new int[] { 1874919423, 2328306, 0, 0 });
            nudPrecio.Name = "nudPrecio";
            nudPrecio.Size = new Size(150, 27);
            nudPrecio.TabIndex = 17;
            // 
            // tboxNombre
            // 
            tboxNombre.Location = new Point(198, 39);
            tboxNombre.Name = "tboxNombre";
            tboxNombre.Size = new Size(150, 27);
            tboxNombre.TabIndex = 18;
            // 
            // btnFinalizar
            // 
            btnFinalizar.Location = new Point(103, 355);
            btnFinalizar.Name = "btnFinalizar";
            btnFinalizar.Size = new Size(213, 84);
            btnFinalizar.TabIndex = 19;
            btnFinalizar.Text = "Finalizar";
            btnFinalizar.UseVisualStyleBackColor = true;
            btnFinalizar.Click += btnFinalizar_Click;
            // 
            // FormMedicamento
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1172, 526);
            Controls.Add(btnFinalizar);
            Controls.Add(tboxNombre);
            Controls.Add(nudPrecio);
            Controls.Add(nudStock);
            Controls.Add(nudStockMinimo);
            Controls.Add(cboxMonodroga);
            Controls.Add(checkBox1);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(elimnarDrogueria);
            Controls.Add(buttonAgregarDrogueria1);
            Controls.Add(dgvTodasLasDroguerias);
            Controls.Add(dgvDrogueriasDelMedicamento);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormMedicamento";
            Text = "Form1";
            Load += FormMedicamento_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDrogueriasDelMedicamento).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTodasLasDroguerias).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudStockMinimo).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPrecio).EndInit();
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
        private DataGridView dgvDrogueriasDelMedicamento;
        private DataGridView dgvTodasLasDroguerias;
        private Button buttonAgregarDrogueria1;
        private Button elimnarDrogueria;
        private Label label8;
        private Label label9;
        private CheckBox checkBox1;
        private ComboBox cboxMonodroga;
        private NumericUpDown nudStockMinimo;
        private NumericUpDown nudStock;
        private NumericUpDown nudPrecio;
        private TextBox tboxNombre;
        private Button btnFinalizar;
    }
}