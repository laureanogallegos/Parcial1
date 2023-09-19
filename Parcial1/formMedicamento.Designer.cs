namespace Parcial1
{
    partial class formMedicamento
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
            txtnombre = new TextBox();
            label1 = new Label();
            button1 = new Button();
            chventalibre = new CheckBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtprecio = new TextBox();
            txtstock = new TextBox();
            txtstockminimo = new TextBox();
            button2 = new Button();
            groupBox1 = new GroupBox();
            comboBox1 = new ComboBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // txtnombre
            // 
            txtnombre.Location = new Point(227, 19);
            txtnombre.Name = "txtnombre";
            txtnombre.Size = new Size(118, 23);
            txtnombre.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 16);
            label1.Name = "label1";
            label1.Size = new Size(109, 15);
            label1.TabIndex = 1;
            label1.Text = "Nombre comercial:";
            // 
            // button1
            // 
            button1.Location = new Point(12, 297);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "Aceptar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // chventalibre
            // 
            chventalibre.AutoSize = true;
            chventalibre.Location = new Point(215, 47);
            chventalibre.Name = "chventalibre";
            chventalibre.Size = new Size(15, 14);
            chventalibre.TabIndex = 3;
            chventalibre.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 46);
            label2.Name = "label2";
            label2.Size = new Size(79, 15);
            label2.TabIndex = 4;
            label2.Text = "es venta libre:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 73);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 5;
            label3.Text = "Precio:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(23, 168);
            label4.Name = "label4";
            label4.Size = new Size(84, 15);
            label4.TabIndex = 6;
            label4.Text = "Stock minimo:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(23, 116);
            label5.Name = "label5";
            label5.Size = new Size(39, 15);
            label5.TabIndex = 7;
            label5.Text = "Stock:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(23, 221);
            label6.Name = "label6";
            label6.Size = new Size(73, 15);
            label6.TabIndex = 8;
            label6.Text = "Monodroga:";
            // 
            // txtprecio
            // 
            txtprecio.Location = new Point(215, 70);
            txtprecio.Name = "txtprecio";
            txtprecio.Size = new Size(118, 23);
            txtprecio.TabIndex = 9;
            // 
            // txtstock
            // 
            txtstock.Location = new Point(215, 113);
            txtstock.Name = "txtstock";
            txtstock.Size = new Size(118, 23);
            txtstock.TabIndex = 10;
            // 
            // txtstockminimo
            // 
            txtstockminimo.Location = new Point(215, 165);
            txtstockminimo.Name = "txtstockminimo";
            txtstockminimo.Size = new Size(118, 23);
            txtstockminimo.TabIndex = 11;
            // 
            // button2
            // 
            button2.Location = new Point(303, 297);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 13;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(chventalibre);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtprecio);
            groupBox1.Controls.Add(txtstockminimo);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtstock);
            groupBox1.Location = new Point(12, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(366, 253);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(212, 213);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 12;
            // 
            // formMedicamento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 332);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(txtnombre);
            Controls.Add(groupBox1);
            Name = "formMedicamento";
            Text = "formMedicamento";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtnombre;
        private Label label1;
        private Button button1;
        private CheckBox chventalibre;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtprecio;
        private TextBox txtstock;
        private TextBox txtstockminimo;
        private Button button2;
        private GroupBox groupBox1;
        private ComboBox comboBox1;
    }
}