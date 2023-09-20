namespace Parcial1
{
    partial class FormMedicamentos
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
            dgrMedicamentos = new DataGridView();
            btnAñadir = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgrMedicamentos).BeginInit();
            SuspendLayout();
            // 
            // dgrMedicamentos
            // 
            dgrMedicamentos.AllowUserToAddRows = false;
            dgrMedicamentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgrMedicamentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgrMedicamentos.Location = new Point(12, 12);
            dgrMedicamentos.MultiSelect = false;
            dgrMedicamentos.Name = "dgrMedicamentos";
            dgrMedicamentos.ReadOnly = true;
            dgrMedicamentos.RowHeadersVisible = false;
            dgrMedicamentos.RowTemplate.Height = 25;
            dgrMedicamentos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgrMedicamentos.Size = new Size(776, 390);
            dgrMedicamentos.TabIndex = 0;
            // 
            // btnAñadir
            // 
            btnAñadir.Location = new Point(12, 415);
            btnAñadir.Name = "btnAñadir";
            btnAñadir.Size = new Size(75, 23);
            btnAñadir.TabIndex = 1;
            btnAñadir.Text = "Añadir";
            btnAñadir.UseVisualStyleBackColor = true;
            btnAñadir.Click += btnAñadir_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(93, 415);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 2;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(174, 415);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(713, 415);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(75, 23);
            btnCerrar.TabIndex = 4;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // FormMedicamentos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCerrar);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAñadir);
            Controls.Add(dgrMedicamentos);
            Name = "FormMedicamentos";
            Text = "Form1";
            Load += FormMedicamentos_Load;
            ((System.ComponentModel.ISupportInitialize)dgrMedicamentos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgrMedicamentos;
        private Button btnAñadir;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnCerrar;
    }
}