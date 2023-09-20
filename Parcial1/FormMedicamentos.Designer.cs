namespace Parcial1
{
    partial class FormMedicamentos
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
            dgvDrogueriasMedicamento = new DataGridView();
            dgvDroguerias = new DataGridView();
            btnAgregar = new Button();
            btnRemover = new Button();
            btnAceptar = new Button();
            btnCancelar = new Button();
            txtNombre = new TextBox();
            label1 = new Label();
            numPrecioVenta = new NumericUpDown();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            numStock = new NumericUpDown();
            numStockMinimo = new NumericUpDown();
            checkVentaLibre = new CheckBox();
            comboMonodroga = new ComboBox();
            label7 = new Label();
            label8 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDrogueriasMedicamento).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDroguerias).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrecioVenta).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStockMinimo).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(comboMonodroga);
            groupBox1.Controls.Add(checkVentaLibre);
            groupBox1.Controls.Add(numStockMinimo);
            groupBox1.Controls.Add(numStock);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(numPrecioVenta);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Location = new Point(13, 20);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(318, 347);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Medicamento";
            // 
            // dgvDrogueriasMedicamento
            // 
            dgvDrogueriasMedicamento.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDrogueriasMedicamento.Location = new Point(347, 32);
            dgvDrogueriasMedicamento.Name = "dgvDrogueriasMedicamento";
            dgvDrogueriasMedicamento.RowTemplate.Height = 25;
            dgvDrogueriasMedicamento.Size = new Size(170, 335);
            dgvDrogueriasMedicamento.TabIndex = 1;
            // 
            // dgvDroguerias
            // 
            dgvDroguerias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDroguerias.Location = new Point(599, 32);
            dgvDroguerias.Name = "dgvDroguerias";
            dgvDroguerias.RowTemplate.Height = 25;
            dgvDroguerias.Size = new Size(189, 335);
            dgvDroguerias.TabIndex = 2;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(526, 107);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(63, 40);
            btnAgregar.TabIndex = 3;
            btnAgregar.Text = "<===";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnRemover
            // 
            btnRemover.Location = new Point(526, 220);
            btnRemover.Name = "btnRemover";
            btnRemover.Size = new Size(63, 40);
            btnRemover.TabIndex = 4;
            btnRemover.Text = "===>";
            btnRemover.UseVisualStyleBackColor = true;
            btnRemover.Click += btnRemover_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(12, 394);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 44);
            btnAceptar.TabIndex = 5;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(201, 394);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 44);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(121, 39);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(191, 23);
            txtNombre.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 44);
            label1.Name = "label1";
            label1.Size = new Size(106, 15);
            label1.TabIndex = 1;
            label1.Text = "Nombre comercial";
            // 
            // numPrecioVenta
            // 
            numPrecioVenta.Location = new Point(121, 87);
            numPrecioVenta.Name = "numPrecioVenta";
            numPrecioVenta.Size = new Size(99, 23);
            numPrecioVenta.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 89);
            label2.Name = "label2";
            label2.Size = new Size(88, 15);
            label2.TabIndex = 3;
            label2.Text = "Precio de Venta";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 133);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 4;
            label3.Text = "Stock";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 177);
            label4.Name = "label4";
            label4.Size = new Size(81, 15);
            label4.TabIndex = 5;
            label4.Text = "Stock Minimo";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(9, 225);
            label5.Name = "label5";
            label5.Size = new Size(65, 15);
            label5.TabIndex = 6;
            label5.Text = "Venta Libre";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(9, 271);
            label6.Name = "label6";
            label6.Size = new Size(70, 15);
            label6.TabIndex = 7;
            label6.Text = "Monodroga";
            // 
            // numStock
            // 
            numStock.Location = new Point(121, 131);
            numStock.Name = "numStock";
            numStock.Size = new Size(99, 23);
            numStock.TabIndex = 8;
            // 
            // numStockMinimo
            // 
            numStockMinimo.Location = new Point(121, 175);
            numStockMinimo.Name = "numStockMinimo";
            numStockMinimo.Size = new Size(99, 23);
            numStockMinimo.TabIndex = 9;
            // 
            // checkVentaLibre
            // 
            checkVentaLibre.AutoSize = true;
            checkVentaLibre.Location = new Point(121, 224);
            checkVentaLibre.Name = "checkVentaLibre";
            checkVentaLibre.Size = new Size(15, 14);
            checkVentaLibre.TabIndex = 10;
            checkVentaLibre.UseVisualStyleBackColor = true;
            // 
            // comboMonodroga
            // 
            comboMonodroga.FormattingEnabled = true;
            comboMonodroga.Location = new Point(121, 268);
            comboMonodroga.Name = "comboMonodroga";
            comboMonodroga.Size = new Size(121, 23);
            comboMonodroga.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(600, 10);
            label7.Name = "label7";
            label7.Size = new Size(107, 15);
            label7.TabIndex = 7;
            label7.Text = "Lista de Droguerias";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(347, 9);
            label8.Name = "label8";
            label8.Size = new Size(121, 15);
            label8.TabIndex = 8;
            label8.Text = "Droguerias Asignadas";
            // 
            // FormMedicamentos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(btnRemover);
            Controls.Add(btnAgregar);
            Controls.Add(dgvDroguerias);
            Controls.Add(dgvDrogueriasMedicamento);
            Controls.Add(groupBox1);
            Name = "FormMedicamentos";
            Text = "FormMedicamentos";
            Load += FormMedicamentos_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDrogueriasMedicamento).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDroguerias).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrecioVenta).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStockMinimo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dgvDrogueriasMedicamento;
        private DataGridView dgvDroguerias;
        private Button btnAgregar;
        private Button btnRemover;
        private Button btnAceptar;
        private Button btnCancelar;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private NumericUpDown numPrecioVenta;
        private Label label1;
        private TextBox txtNombre;
        private NumericUpDown numStockMinimo;
        private NumericUpDown numStock;
        private ComboBox comboMonodroga;
        private CheckBox checkVentaLibre;
        private Label label7;
        private Label label8;
    }
}