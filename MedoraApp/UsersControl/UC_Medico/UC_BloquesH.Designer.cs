namespace AdminTurnosMedicos
{
    partial class UC_BloquesH
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
            panel1 = new Panel();
            btnEliminarB = new Button();
            btnModificarB = new Button();
            btnCrearB = new Button();
            panelBloques = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(btnEliminarB);
            panel1.Controls.Add(btnModificarB);
            panel1.Controls.Add(btnCrearB);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(543, 50);
            panel1.TabIndex = 0;
            // 
            // btnEliminarB
            // 
            btnEliminarB.Location = new Point(319, 3);
            btnEliminarB.Name = "btnEliminarB";
            btnEliminarB.Size = new Size(102, 37);
            btnEliminarB.TabIndex = 2;
            btnEliminarB.Text = "Eliminar Bloque";
            btnEliminarB.UseVisualStyleBackColor = true;
            // 
            // btnModificarB
            // 
            btnModificarB.Location = new Point(200, 3);
            btnModificarB.Name = "btnModificarB";
            btnModificarB.Size = new Size(113, 37);
            btnModificarB.TabIndex = 1;
            btnModificarB.Text = "Modificar Bloque";
            btnModificarB.UseVisualStyleBackColor = true;
            // 
            // btnCrearB
            // 
            btnCrearB.Location = new Point(101, 3);
            btnCrearB.Name = "btnCrearB";
            btnCrearB.Size = new Size(93, 37);
            btnCrearB.TabIndex = 0;
            btnCrearB.Text = "Crear Bloque";
            btnCrearB.UseVisualStyleBackColor = true;
            // 
            // panelBloques
            // 
            panelBloques.BackColor = SystemColors.Highlight;
            panelBloques.Location = new Point(3, 59);
            panelBloques.Name = "panelBloques";
            panelBloques.Size = new Size(543, 242);
            panelBloques.TabIndex = 1;
            // 
            // UC_BloquesH
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelBloques);
            Controls.Add(panel1);
            Name = "UC_BloquesH";
            Size = new Size(549, 304);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnEliminarB;
        private Button btnModificarB;
        private Button btnCrearB;
        private Panel panelBloques;
    }
}
