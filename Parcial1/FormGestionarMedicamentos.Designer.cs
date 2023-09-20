namespace Parcial1
{
    partial class FormGestionarMedicamentos
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            btnModificarMedicamento = new Button();
            btnEliminarMedicamento = new Button();
            btnAgregarMedicamento = new Button();
            label1 = new Label();
            dgvDroguerias = new DataGridView();
            dgvMedicamentos = new DataGridView();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDroguerias).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMedicamentos).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnModificarMedicamento);
            groupBox1.Controls.Add(btnEliminarMedicamento);
            groupBox1.Controls.Add(btnAgregarMedicamento);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(dgvDroguerias);
            groupBox1.Controls.Add(dgvMedicamentos);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 426);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Medicamentos";
            // 
            // btnModificarMedicamento
            // 
            btnModificarMedicamento.Location = new Point(614, 175);
            btnModificarMedicamento.Name = "btnModificarMedicamento";
            btnModificarMedicamento.RightToLeft = RightToLeft.Yes;
            btnModificarMedicamento.Size = new Size(75, 23);
            btnModificarMedicamento.TabIndex = 5;
            btnModificarMedicamento.Text = "Modificar";
            btnModificarMedicamento.TextImageRelation = TextImageRelation.ImageAboveText;
            btnModificarMedicamento.UseVisualStyleBackColor = true;
            // 
            // btnEliminarMedicamento
            // 
            btnEliminarMedicamento.Location = new Point(695, 175);
            btnEliminarMedicamento.Name = "btnEliminarMedicamento";
            btnEliminarMedicamento.RightToLeft = RightToLeft.Yes;
            btnEliminarMedicamento.Size = new Size(75, 23);
            btnEliminarMedicamento.TabIndex = 4;
            btnEliminarMedicamento.Text = "Eliminar";
            btnEliminarMedicamento.UseVisualStyleBackColor = true;
            // 
            // btnAgregarMedicamento
            // 
            btnAgregarMedicamento.Location = new Point(533, 175);
            btnAgregarMedicamento.Name = "btnAgregarMedicamento";
            btnAgregarMedicamento.RightToLeft = RightToLeft.Yes;
            btnAgregarMedicamento.Size = new Size(75, 23);
            btnAgregarMedicamento.TabIndex = 3;
            btnAgregarMedicamento.Text = "Agregar";
            btnAgregarMedicamento.UseVisualStyleBackColor = true;
            btnAgregarMedicamento.Click += btnAgregarMedicamento_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 238);
            label1.Name = "label1";
            label1.Size = new Size(120, 15);
            label1.TabIndex = 2;
            label1.Text = "Droguerias Asociadas";
            // 
            // dgvDroguerias
            // 
            dgvDroguerias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDroguerias.Location = new Point(6, 256);
            dgvDroguerias.Name = "dgvDroguerias";
            dgvDroguerias.RowTemplate.Height = 25;
            dgvDroguerias.Size = new Size(764, 147);
            dgvDroguerias.TabIndex = 1;
            // 
            // dgvMedicamentos
            // 
            dgvMedicamentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMedicamentos.Location = new Point(6, 22);
            dgvMedicamentos.Name = "dgvMedicamentos";
            dgvMedicamentos.RowTemplate.Height = 25;
            dgvMedicamentos.Size = new Size(764, 147);
            dgvMedicamentos.TabIndex = 0;
            dgvMedicamentos.SelectionChanged += dgvMedicamentos_SelectionChanged;
            // 
            // FormGestionarMedicamentos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Name = "FormGestionarMedicamentos";
            Text = "Gestionar Medicamentos";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDroguerias).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMedicamentos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dgvMedicamentos;
        private Label label1;
        private DataGridView dgvDroguerias;
        private Button btnModificarMedicamento;
        private Button btnEliminarMedicamento;
        private Button btnAgregarMedicamento;
    }
}