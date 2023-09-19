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
            tbNombre = new TextBox();
            tbPrecio = new TextBox();
            tbStock = new TextBox();
            tbStockMin = new TextBox();
            btnAceptar = new Button();
            btnCancelar = new Button();
            cbVenta = new CheckBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            cbMonodroga = new ComboBox();
            SuspendLayout();
            // 
            // tbNombre
            // 
            tbNombre.Location = new Point(175, 12);
            tbNombre.Name = "tbNombre";
            tbNombre.Size = new Size(100, 23);
            tbNombre.TabIndex = 0;
            // 
            // tbPrecio
            // 
            tbPrecio.Location = new Point(175, 70);
            tbPrecio.Name = "tbPrecio";
            tbPrecio.Size = new Size(100, 23);
            tbPrecio.TabIndex = 2;
            // 
            // tbStock
            // 
            tbStock.Location = new Point(175, 99);
            tbStock.Name = "tbStock";
            tbStock.Size = new Size(100, 23);
            tbStock.TabIndex = 3;
            // 
            // tbStockMin
            // 
            tbStockMin.Location = new Point(175, 128);
            tbStockMin.Name = "tbStockMin";
            tbStockMin.Size = new Size(100, 23);
            tbStockMin.TabIndex = 4;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(38, 200);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 5;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(200, 200);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // cbVenta
            // 
            cbVenta.AutoSize = true;
            cbVenta.Location = new Point(212, 50);
            cbVenta.Name = "cbVenta";
            cbVenta.Size = new Size(15, 14);
            cbVenta.TabIndex = 7;
            cbVenta.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 15);
            label1.Name = "label1";
            label1.Size = new Size(108, 15);
            label1.TabIndex = 8;
            label1.Text = "Nombre Comercial";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(38, 49);
            label2.Name = "label2";
            label2.Size = new Size(79, 15);
            label2.TabIndex = 9;
            label2.Text = "Es Venta Libre";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(38, 78);
            label3.Name = "label3";
            label3.Size = new Size(88, 15);
            label3.TabIndex = 10;
            label3.Text = "Precio de Venta";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(38, 102);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 11;
            label4.Text = "Stock";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(38, 131);
            label5.Name = "label5";
            label5.Size = new Size(81, 15);
            label5.TabIndex = 12;
            label5.Text = "Stock Mínimo";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(38, 164);
            label6.Name = "label6";
            label6.Size = new Size(70, 15);
            label6.TabIndex = 13;
            label6.Text = "Monodroga";
            // 
            // cbMonodroga
            // 
            cbMonodroga.FormattingEnabled = true;
            cbMonodroga.Location = new Point(175, 161);
            cbMonodroga.Name = "cbMonodroga";
            cbMonodroga.Size = new Size(100, 23);
            cbMonodroga.TabIndex = 14;
            // 
            // FormMedicamento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(339, 235);
            Controls.Add(cbMonodroga);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cbVenta);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(tbStockMin);
            Controls.Add(tbStock);
            Controls.Add(tbPrecio);
            Controls.Add(tbNombre);
            Name = "FormMedicamento";
            Text = "FormMedicamento";
            Load += FormMedicamento_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbNombre;
        private TextBox tbPrecio;
        private TextBox tbStock;
        private TextBox tbStockMin;
        private Button btnAceptar;
        private Button btnCancelar;
        private CheckBox cbVenta;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private ComboBox cbMonodroga;
    }
}