namespace MedoraApp
{
    partial class UC_VerBloques
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.dgvListaBloques = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaBloques)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lista De Bloques";
            // 
            // dgvListaBloques
            // 
            this.dgvListaBloques.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaBloques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaBloques.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvListaBloques.Location = new System.Drawing.Point(16, 55);
            this.dgvListaBloques.Name = "dgvListaBloques";
            this.dgvListaBloques.Size = new System.Drawing.Size(624, 249);
            this.dgvListaBloques.TabIndex = 1;
            // 
            // UC_VerBloques
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateBlue;
            this.Controls.Add(this.dgvListaBloques);
            this.Controls.Add(this.label1);
            this.Name = "UC_VerBloques";
            this.Size = new System.Drawing.Size(668, 323);
            this.Load += new System.EventHandler(this.UC_VerBloques_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaBloques)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvListaBloques;
    }
}
