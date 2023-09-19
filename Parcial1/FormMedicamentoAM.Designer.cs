namespace Parcial1
{
    partial class FormMedicamentoAM
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
            btnCancelar = new Button();
            btnAceptar = new Button();
            lblPrecioVenta = new Label();
            lblAgregaroModificar = new Label();
            txtNombreComercial = new TextBox();
            lblNombreComercial = new Label();
            btnLimpiar = new Button();
            btnAgregar = new Button();
            lblDisponibles = new Label();
            lblAsignadas = new Label();
            cmbMonodroga = new ComboBox();
            lbAsignados = new ListBox();
            cmbDisponibles = new ComboBox();
            cbVentaLibre = new CheckBox();
            numVenta = new NumericUpDown();
            numStock = new NumericUpDown();
            numStockMinimo = new NumericUpDown();
            lblStock = new Label();
            lblStockMinimo = new Label();
            lblMonodroga = new Label();
            ((System.ComponentModel.ISupportInitialize)numVenta).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStockMinimo).BeginInit();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(168, 284);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(83, 26);
            btnCancelar.TabIndex = 37;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(31, 284);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(83, 26);
            btnAceptar.TabIndex = 36;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // lblPrecioVenta
            // 
            lblPrecioVenta.AutoSize = true;
            lblPrecioVenta.Location = new Point(20, 106);
            lblPrecioVenta.Name = "lblPrecioVenta";
            lblPrecioVenta.Size = new Size(91, 15);
            lblPrecioVenta.TabIndex = 31;
            lblPrecioVenta.Text = "Precio de venta:";
            // 
            // lblAgregaroModificar
            // 
            lblAgregaroModificar.AutoSize = true;
            lblAgregaroModificar.Location = new Point(47, 9);
            lblAgregaroModificar.Name = "lblAgregaroModificar";
            lblAgregaroModificar.Size = new Size(161, 15);
            lblAgregaroModificar.TabIndex = 28;
            lblAgregaroModificar.Text = "Agregar o Modificar Usuarios";
            // 
            // txtNombreComercial
            // 
            txtNombreComercial.Location = new Point(129, 39);
            txtNombreComercial.Name = "txtNombreComercial";
            txtNombreComercial.Size = new Size(107, 23);
            txtNombreComercial.TabIndex = 38;
            // 
            // lblNombreComercial
            // 
            lblNombreComercial.AutoSize = true;
            lblNombreComercial.Location = new Point(12, 42);
            lblNombreComercial.Name = "lblNombreComercial";
            lblNombreComercial.Size = new Size(111, 15);
            lblNombreComercial.TabIndex = 40;
            lblNombreComercial.Text = "Nombre Comercial:";
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(403, 204);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 23);
            btnLimpiar.TabIndex = 51;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(530, 34);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 50;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // lblDisponibles
            // 
            lblDisponibles.AutoSize = true;
            lblDisponibles.Location = new Point(266, 39);
            lblDisponibles.Name = "lblDisponibles";
            lblDisponibles.Size = new Size(131, 15);
            lblDisponibles.TabIndex = 46;
            lblDisponibles.Text = "Droguerias Disponibles:";
            // 
            // lblAsignadas
            // 
            lblAsignadas.AutoSize = true;
            lblAsignadas.Location = new Point(273, 92);
            lblAsignadas.Name = "lblAsignadas";
            lblAsignadas.Size = new Size(124, 15);
            lblAsignadas.TabIndex = 53;
            lblAsignadas.Text = "Droguerias Asignadas:";
            // 
            // cmbMonodroga
            // 
            cmbMonodroga.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMonodroga.FormattingEnabled = true;
            cmbMonodroga.Location = new Point(117, 234);
            cmbMonodroga.Name = "cmbMonodroga";
            cmbMonodroga.Size = new Size(121, 23);
            cmbMonodroga.TabIndex = 54;
            // 
            // lbAsignados
            // 
            lbAsignados.FormattingEnabled = true;
            lbAsignados.ItemHeight = 15;
            lbAsignados.Location = new Point(403, 92);
            lbAsignados.Name = "lbAsignados";
            lbAsignados.Size = new Size(120, 94);
            lbAsignados.TabIndex = 56;
            // 
            // cmbDisponibles
            // 
            cmbDisponibles.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDisponibles.FormattingEnabled = true;
            cmbDisponibles.Location = new Point(403, 36);
            cmbDisponibles.Name = "cmbDisponibles";
            cmbDisponibles.Size = new Size(121, 23);
            cmbDisponibles.TabIndex = 57;
            // 
            // cbVentaLibre
            // 
            cbVentaLibre.AutoSize = true;
            cbVentaLibre.Location = new Point(76, 68);
            cbVentaLibre.Name = "cbVentaLibre";
            cbVentaLibre.Size = new Size(84, 19);
            cbVentaLibre.TabIndex = 58;
            cbVentaLibre.Text = "Venta Libre";
            cbVentaLibre.UseVisualStyleBackColor = true;
            // 
            // numVenta
            // 
            numVenta.Location = new Point(117, 103);
            numVenta.Maximum = new decimal(new int[] { 150000, 0, 0, 0 });
            numVenta.Name = "numVenta";
            numVenta.Size = new Size(120, 23);
            numVenta.TabIndex = 59;
            // 
            // numStock
            // 
            numStock.Location = new Point(116, 145);
            numStock.Maximum = new decimal(new int[] { 150000, 0, 0, 0 });
            numStock.Name = "numStock";
            numStock.Size = new Size(120, 23);
            numStock.TabIndex = 60;
            // 
            // numStockMinimo
            // 
            numStockMinimo.Location = new Point(116, 192);
            numStockMinimo.Maximum = new decimal(new int[] { 150000, 0, 0, 0 });
            numStockMinimo.Name = "numStockMinimo";
            numStockMinimo.Size = new Size(120, 23);
            numStockMinimo.TabIndex = 61;
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Location = new Point(47, 147);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(39, 15);
            lblStock.TabIndex = 62;
            lblStock.Text = "Stock:";
            // 
            // lblStockMinimo
            // 
            lblStockMinimo.AutoSize = true;
            lblStockMinimo.Location = new Point(20, 192);
            lblStockMinimo.Name = "lblStockMinimo";
            lblStockMinimo.Size = new Size(84, 15);
            lblStockMinimo.TabIndex = 63;
            lblStockMinimo.Text = "Stock Minimo:";
            // 
            // lblMonodroga
            // 
            lblMonodroga.AutoSize = true;
            lblMonodroga.Location = new Point(20, 241);
            lblMonodroga.Name = "lblMonodroga";
            lblMonodroga.Size = new Size(73, 15);
            lblMonodroga.TabIndex = 64;
            lblMonodroga.Text = "Monodroga:";
            // 
            // FormMedicamentoAM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(617, 322);
            Controls.Add(lblMonodroga);
            Controls.Add(lblStockMinimo);
            Controls.Add(lblStock);
            Controls.Add(numStockMinimo);
            Controls.Add(numStock);
            Controls.Add(numVenta);
            Controls.Add(cbVentaLibre);
            Controls.Add(cmbDisponibles);
            Controls.Add(lbAsignados);
            Controls.Add(cmbMonodroga);
            Controls.Add(lblAsignadas);
            Controls.Add(btnLimpiar);
            Controls.Add(btnAgregar);
            Controls.Add(lblDisponibles);
            Controls.Add(lblNombreComercial);
            Controls.Add(txtNombreComercial);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(lblPrecioVenta);
            Controls.Add(lblAgregaroModificar);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormMedicamentoAM";
            Text = "FormMedicamentoAM";
            Load += FormMedicamentoAM_Load;
            ((System.ComponentModel.ISupportInitialize)numVenta).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStockMinimo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private Button btnAceptar;
        private TextBox txtNombre;
        private Label lblPrecioVenta;
        private Label lblAgregaroModificar;
        private TextBox txtNombreComercial;
        private Label lblNombreComercial;
        private Button btnGuardarySALIT;
        private Button btnLimpiar;
        private Button btnAgregar;
        private CheckBox cbHabilitada;
        private Label label5;
        private Label lblDisponibles;
        private ComboBox cmbRoles;
        private Label lblAsignadas;
        private ComboBox cmbMonodroga;
        private ListBox lbAsignados;
        private ComboBox cmbDisponibles;
        private CheckBox cbVentaLibre;
        private NumericUpDown numVenta;
        private NumericUpDown numStock;
        private NumericUpDown numStockMinimo;
        private Label lblStock;
        private Label lblStockMinimo;
        private Label lblMonodroga;
    }
}