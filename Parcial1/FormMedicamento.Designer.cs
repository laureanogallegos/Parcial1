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
            lblNombre = new Label();
            lblCantidad = new Label();
            txtNombreComercial = new TextBox();
            numStock = new NumericUpDown();
            label1 = new Label();
            numStockMin = new NumericUpDown();
            label2 = new Label();
            txtPrecioVenta = new TextBox();
            label3 = new Label();
            boxMonodrogas = new ComboBox();
            gBoxProducto = new GroupBox();
            label5 = new Label();
            checkVentaLibre = new CheckBox();
            btnQuitar = new Button();
            btnAsignar = new Button();
            dgvDrogueriasMedicamento = new DataGridView();
            label4 = new Label();
            boxDrogueria = new ComboBox();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)numStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStockMin).BeginInit();
            gBoxProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDrogueriasMedicamento).BeginInit();
            SuspendLayout();
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(4, 355);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 1;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(17, 75);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(109, 15);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre comercial:";
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(61, 103);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(65, 15);
            lblCantidad.TabIndex = 2;
            lblCantidad.Text = "Venta libre:";
            // 
            // txtNombreComercial
            // 
            txtNombreComercial.Location = new Point(136, 72);
            txtNombreComercial.MaxLength = 50;
            txtNombreComercial.Name = "txtNombreComercial";
            txtNombreComercial.Size = new Size(144, 23);
            txtNombreComercial.TabIndex = 2;
            // 
            // numStock
            // 
            numStock.Location = new Point(136, 160);
            numStock.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numStock.Name = "numStock";
            numStock.Size = new Size(144, 23);
            numStock.TabIndex = 3;
            numStock.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(87, 168);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 4;
            label1.Text = "Stock:";
            // 
            // numStockMin
            // 
            numStockMin.Location = new Point(136, 195);
            numStockMin.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numStockMin.Name = "numStockMin";
            numStockMin.Size = new Size(144, 23);
            numStockMin.TabIndex = 5;
            numStockMin.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 131);
            label2.Name = "label2";
            label2.Size = new Size(91, 15);
            label2.TabIndex = 6;
            label2.Text = "Precio de venta:";
            // 
            // txtPrecioVenta
            // 
            txtPrecioVenta.Location = new Point(136, 126);
            txtPrecioVenta.MaxLength = 50;
            txtPrecioVenta.Name = "txtPrecioVenta";
            txtPrecioVenta.Size = new Size(144, 23);
            txtPrecioVenta.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(51, 232);
            label3.Name = "label3";
            label3.Size = new Size(73, 15);
            label3.TabIndex = 8;
            label3.Text = "Monodroga:\r\n";
            // 
            // boxMonodrogas
            // 
            boxMonodrogas.DropDownStyle = ComboBoxStyle.DropDownList;
            boxMonodrogas.FormattingEnabled = true;
            boxMonodrogas.Location = new Point(136, 229);
            boxMonodrogas.Name = "boxMonodrogas";
            boxMonodrogas.Size = new Size(144, 23);
            boxMonodrogas.TabIndex = 9;
            // 
            // gBoxProducto
            // 
            gBoxProducto.Controls.Add(label5);
            gBoxProducto.Controls.Add(checkVentaLibre);
            gBoxProducto.Controls.Add(btnQuitar);
            gBoxProducto.Controls.Add(btnAsignar);
            gBoxProducto.Controls.Add(dgvDrogueriasMedicamento);
            gBoxProducto.Controls.Add(label4);
            gBoxProducto.Controls.Add(boxDrogueria);
            gBoxProducto.Controls.Add(boxMonodrogas);
            gBoxProducto.Controls.Add(label3);
            gBoxProducto.Controls.Add(txtPrecioVenta);
            gBoxProducto.Controls.Add(label2);
            gBoxProducto.Controls.Add(numStockMin);
            gBoxProducto.Controls.Add(label1);
            gBoxProducto.Controls.Add(numStock);
            gBoxProducto.Controls.Add(txtNombreComercial);
            gBoxProducto.Controls.Add(lblCantidad);
            gBoxProducto.Controls.Add(lblNombre);
            gBoxProducto.Location = new Point(4, 12);
            gBoxProducto.Name = "gBoxProducto";
            gBoxProducto.Size = new Size(841, 337);
            gBoxProducto.TabIndex = 0;
            gBoxProducto.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(42, 203);
            label5.Name = "label5";
            label5.Size = new Size(84, 15);
            label5.TabIndex = 17;
            label5.Text = "Stock minimo:";
            // 
            // checkVentaLibre
            // 
            checkVentaLibre.AutoSize = true;
            checkVentaLibre.Location = new Point(136, 106);
            checkVentaLibre.Name = "checkVentaLibre";
            checkVentaLibre.Size = new Size(15, 14);
            checkVentaLibre.TabIndex = 16;
            checkVentaLibre.UseVisualStyleBackColor = true;
            // 
            // btnQuitar
            // 
            btnQuitar.Location = new Point(305, 308);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(114, 23);
            btnQuitar.TabIndex = 15;
            btnQuitar.Text = "Quitar drogueria";
            btnQuitar.UseVisualStyleBackColor = true;
            btnQuitar.Click += btnQuitar_Click;
            // 
            // btnAsignar
            // 
            btnAsignar.Location = new Point(168, 303);
            btnAsignar.Name = "btnAsignar";
            btnAsignar.Size = new Size(112, 23);
            btnAsignar.TabIndex = 14;
            btnAsignar.Text = "Asignar drogueria";
            btnAsignar.UseVisualStyleBackColor = true;
            btnAsignar.Click += btnAsignar_Click;
            // 
            // dgvDrogueriasMedicamento
            // 
            dgvDrogueriasMedicamento.AllowUserToAddRows = false;
            dgvDrogueriasMedicamento.AllowUserToDeleteRows = false;
            dgvDrogueriasMedicamento.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvDrogueriasMedicamento.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDrogueriasMedicamento.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDrogueriasMedicamento.Location = new Point(305, 22);
            dgvDrogueriasMedicamento.MultiSelect = false;
            dgvDrogueriasMedicamento.Name = "dgvDrogueriasMedicamento";
            dgvDrogueriasMedicamento.ReadOnly = true;
            dgvDrogueriasMedicamento.RowHeadersVisible = false;
            dgvDrogueriasMedicamento.RowTemplate.Height = 25;
            dgvDrogueriasMedicamento.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDrogueriasMedicamento.Size = new Size(516, 279);
            dgvDrogueriasMedicamento.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(51, 269);
            label4.Name = "label4";
            label4.Size = new Size(67, 15);
            label4.TabIndex = 12;
            label4.Text = "Droguerias:";
            // 
            // boxDrogueria
            // 
            boxDrogueria.DropDownStyle = ComboBoxStyle.DropDownList;
            boxDrogueria.FormattingEnabled = true;
            boxDrogueria.Location = new Point(136, 261);
            boxDrogueria.Name = "boxDrogueria";
            boxDrogueria.Size = new Size(144, 23);
            boxDrogueria.TabIndex = 11;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(762, 355);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FormMedicamento
            // 
            AcceptButton = btnAceptar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(845, 378);
            ControlBox = false;
            Controls.Add(btnCancelar);
            Controls.Add(gBoxProducto);
            Controls.Add(btnAceptar);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "FormMedicamento";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Load += FormMedicamento_Load;
            ((System.ComponentModel.ISupportInitialize)numStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStockMin).EndInit();
            gBoxProducto.ResumeLayout(false);
            gBoxProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDrogueriasMedicamento).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnAceptar;
        private Label lblCodigo;
        private Label lblNombre;
        private Label lblCantidad;
        private TextBox txtCodigoProducto;
        private TextBox txtNombreComercial;
        private NumericUpDown numStock;
        private Label label1;
        private NumericUpDown numStockMin;
        private Label label2;
        private TextBox txtPrecioVenta;
        private Label label3;
        private ComboBox boxMonodrogas;
        private GroupBox gBoxProducto;
        private Label label4;
        private ComboBox boxDrogueria;
        private DataGridView dgvDrogueriasMedicamento;
        private Button btnAsignar;
        private Button btnQuitar;
        private CheckBox checkVentaLibre;
        private Label label5;
        private Button btnCancelar;
    }
}