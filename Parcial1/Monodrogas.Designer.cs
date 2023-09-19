namespace Parcial1
{
    partial class Monodrogas
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
            this.dgvMonodrogas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonodrogas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMonodrogas
            // 
            this.dgvMonodrogas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMonodrogas.Location = new System.Drawing.Point(12, 1);
            this.dgvMonodrogas.Name = "dgvMonodrogas";
            this.dgvMonodrogas.RowHeadersWidth = 51;
            this.dgvMonodrogas.RowTemplate.Height = 29;
            this.dgvMonodrogas.Size = new System.Drawing.Size(776, 383);
            this.dgvMonodrogas.TabIndex = 4;
            // 
            // Monodrogas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvMonodrogas);
            this.Name = "Monodrogas";
            this.Text = "Monodrogas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonodrogas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DataGridView dgvMonodrogas;
    }
}