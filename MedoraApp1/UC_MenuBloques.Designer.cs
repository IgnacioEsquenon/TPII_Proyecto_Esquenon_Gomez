namespace MedoraApp
{
    partial class UC_MenuBloques
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnVerBloques = new System.Windows.Forms.Button();
            this.btnEliminarBloq = new System.Windows.Forms.Button();
            this.btnModBloq = new System.Windows.Forms.Button();
            this.btnCrearBloq = new System.Windows.Forms.Button();
            this.p_Contenido_Bloq = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SandyBrown;
            this.panel1.Controls.Add(this.btnVerBloques);
            this.panel1.Controls.Add(this.btnEliminarBloq);
            this.panel1.Controls.Add(this.btnModBloq);
            this.panel1.Controls.Add(this.btnCrearBloq);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(669, 53);
            this.panel1.TabIndex = 0;
            // 
            // btnVerBloques
            // 
            this.btnVerBloques.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnVerBloques.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVerBloques.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerBloques.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnVerBloques.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnVerBloques.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerBloques.Location = new System.Drawing.Point(16, 5);
            this.btnVerBloques.Name = "btnVerBloques";
            this.btnVerBloques.Size = new System.Drawing.Size(110, 43);
            this.btnVerBloques.TabIndex = 5;
            this.btnVerBloques.Text = "Ver Bloques";
            this.btnVerBloques.UseVisualStyleBackColor = false;
            this.btnVerBloques.Click += new System.EventHandler(this.btnVerBloques_Click);
            // 
            // btnEliminarBloq
            // 
            this.btnEliminarBloq.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnEliminarBloq.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminarBloq.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarBloq.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminarBloq.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnEliminarBloq.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarBloq.Location = new System.Drawing.Point(448, 5);
            this.btnEliminarBloq.Name = "btnEliminarBloq";
            this.btnEliminarBloq.Size = new System.Drawing.Size(110, 43);
            this.btnEliminarBloq.TabIndex = 4;
            this.btnEliminarBloq.Text = "Eliminar Bloque";
            this.btnEliminarBloq.UseVisualStyleBackColor = false;
            // 
            // btnModBloq
            // 
            this.btnModBloq.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnModBloq.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnModBloq.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModBloq.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnModBloq.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnModBloq.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModBloq.Location = new System.Drawing.Point(322, 5);
            this.btnModBloq.Name = "btnModBloq";
            this.btnModBloq.Size = new System.Drawing.Size(110, 43);
            this.btnModBloq.TabIndex = 3;
            this.btnModBloq.Text = "Modificar Bloque";
            this.btnModBloq.UseVisualStyleBackColor = false;
            // 
            // btnCrearBloq
            // 
            this.btnCrearBloq.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnCrearBloq.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCrearBloq.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearBloq.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCrearBloq.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnCrearBloq.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCrearBloq.Location = new System.Drawing.Point(194, 5);
            this.btnCrearBloq.Name = "btnCrearBloq";
            this.btnCrearBloq.Size = new System.Drawing.Size(110, 43);
            this.btnCrearBloq.TabIndex = 2;
            this.btnCrearBloq.Text = "Crear Bloque";
            this.btnCrearBloq.UseVisualStyleBackColor = false;
            this.btnCrearBloq.Click += new System.EventHandler(this.btnCrearBloq_Click);
            // 
            // p_Contenido_Bloq
            // 
            this.p_Contenido_Bloq.BackColor = System.Drawing.Color.White;
            this.p_Contenido_Bloq.Location = new System.Drawing.Point(0, 54);
            this.p_Contenido_Bloq.Name = "p_Contenido_Bloq";
            this.p_Contenido_Bloq.Size = new System.Drawing.Size(668, 323);
            this.p_Contenido_Bloq.TabIndex = 1;
            // 
            // UC_MenuBloques
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.p_Contenido_Bloq);
            this.Controls.Add(this.panel1);
            this.Name = "UC_MenuBloques";
            this.Size = new System.Drawing.Size(669, 378);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel p_Contenido_Bloq;
        private System.Windows.Forms.Button btnVerBloques;
        private System.Windows.Forms.Button btnEliminarBloq;
        private System.Windows.Forms.Button btnModBloq;
        private System.Windows.Forms.Button btnCrearBloq;
    }
}
