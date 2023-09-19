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
            numStockMin = new NumericUpDown();
            numStockMaximo = new NumericUpDown();
            txtNombre = new TextBox();
            cmbMonoDrogas = new ComboBox();
            checkBox1 = new CheckBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            button1 = new Button();
            btnAceptar = new Button();
            dgvDrogueriasDisponibles = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)numStockMin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStockMaximo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDrogueriasDisponibles).BeginInit();
            SuspendLayout();
            // 
            // numStockMin
            // 
            numStockMin.Location = new Point(176, 155);
            numStockMin.Name = "numStockMin";
            numStockMin.Size = new Size(120, 23);
            numStockMin.TabIndex = 0;
            // 
            // numStockMaximo
            // 
            numStockMaximo.Location = new Point(176, 117);
            numStockMaximo.Name = "numStockMaximo";
            numStockMaximo.Size = new Size(120, 23);
            numStockMaximo.TabIndex = 1;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(176, 71);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(120, 23);
            txtNombre.TabIndex = 2;
            // 
            // cmbMonoDrogas
            // 
            cmbMonoDrogas.FormattingEnabled = true;
            cmbMonoDrogas.Location = new Point(175, 196);
            cmbMonoDrogas.Name = "cmbMonoDrogas";
            cmbMonoDrogas.Size = new Size(121, 23);
            cmbMonoDrogas.TabIndex = 3;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(213, 235);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(81, 19);
            checkBox1.TabIndex = 4;
            checkBox1.Text = "Venta libre";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 117);
            label1.Name = "label1";
            label1.Size = new Size(80, 15);
            label1.TabIndex = 5;
            label1.Text = "StockMaximo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 71);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 6;
            label2.Text = "Nombre";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(24, 239);
            label3.Name = "label3";
            label3.Size = new Size(65, 15);
            label3.TabIndex = 7;
            label3.Text = "Venta Libre";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(24, 155);
            label4.Name = "label4";
            label4.Size = new Size(78, 15);
            label4.TabIndex = 8;
            label4.Text = "StockMinimo";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(24, 196);
            label5.Name = "label5";
            label5.Size = new Size(75, 15);
            label5.TabIndex = 9;
            label5.Text = "Monodrogas";
            // 
            // button1
            // 
            button1.Location = new Point(685, 325);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 10;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(91, 325);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 11;
            btnAceptar.Text = "aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // dgvDrogueriasDisponibles
            // 
            dgvDrogueriasDisponibles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDrogueriasDisponibles.Location = new Point(395, 12);
            dgvDrogueriasDisponibles.Name = "dgvDrogueriasDisponibles";
            dgvDrogueriasDisponibles.RowTemplate.Height = 25;
            dgvDrogueriasDisponibles.Size = new Size(382, 275);
            dgvDrogueriasDisponibles.TabIndex = 12;
            // 
            // FormMedicamento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvDrogueriasDisponibles);
            Controls.Add(btnAceptar);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(checkBox1);
            Controls.Add(cmbMonoDrogas);
            Controls.Add(txtNombre);
            Controls.Add(numStockMaximo);
            Controls.Add(numStockMin);
            Name = "FormMedicamento";
            Text = "FormMedicamento";
            Load += FormMedicamento_Load;
            ((System.ComponentModel.ISupportInitialize)numStockMin).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStockMaximo).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDrogueriasDisponibles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown numStockMin;
        private NumericUpDown numStockMaximo;
        private TextBox txtNombre;
        private ComboBox cmbMonoDrogas;
        private CheckBox checkBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button button1;
        private Button btnAceptar;
        private DataGridView dgvDrogueriasDisponibles;
    }
}