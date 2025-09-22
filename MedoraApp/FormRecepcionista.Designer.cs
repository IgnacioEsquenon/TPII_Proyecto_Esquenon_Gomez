namespace MedoraApp
{
    partial class FormRecepcionista
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnCrearRecep = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnCrearMed = new System.Windows.Forms.Button();
            this.LSubTitulo = new System.Windows.Forms.Label();
            this.panelContenido = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelContenido.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.btnCrearRecep);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnVolver);
            this.panel1.Controls.Add(this.btnCrearMed);
            this.panel1.Controls.Add(this.LSubTitulo);
            this.panel1.Location = new System.Drawing.Point(0, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(140, 369);
            this.panel1.TabIndex = 2;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.Enabled = false;
            this.pictureBox2.Image = global::MedoraApp.Properties.Resources.agenda;
            this.pictureBox2.Location = new System.Drawing.Point(53, 207);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 25);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // btnCrearRecep
            // 
            this.btnCrearRecep.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnCrearRecep.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCrearRecep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearRecep.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCrearRecep.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnCrearRecep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCrearRecep.Location = new System.Drawing.Point(3, 180);
            this.btnCrearRecep.Name = "btnCrearRecep";
            this.btnCrearRecep.Size = new System.Drawing.Size(134, 61);
            this.btnCrearRecep.TabIndex = 9;
            this.btnCrearRecep.Text = "Administrar Turnos";
            this.btnCrearRecep.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCrearRecep.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Image = global::MedoraApp.Properties.Resources.file;
            this.pictureBox1.Location = new System.Drawing.Point(9, 114);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.Red;
            this.btnVolver.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnVolver.Location = new System.Drawing.Point(9, 325);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(116, 27);
            this.btnVolver.TabIndex = 6;
            this.btnVolver.Text = "Volver a Inicio";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnCrearMed
            // 
            this.btnCrearMed.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnCrearMed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCrearMed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearMed.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCrearMed.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnCrearMed.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCrearMed.Location = new System.Drawing.Point(3, 96);
            this.btnCrearMed.Name = "btnCrearMed";
            this.btnCrearMed.Size = new System.Drawing.Size(134, 61);
            this.btnCrearMed.TabIndex = 1;
            this.btnCrearMed.Text = "Añadir Paciente";
            this.btnCrearMed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCrearMed.UseVisualStyleBackColor = false;
            // 
            // LSubTitulo
            // 
            this.LSubTitulo.AutoSize = true;
            this.LSubTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.LSubTitulo.ForeColor = System.Drawing.Color.White;
            this.LSubTitulo.Location = new System.Drawing.Point(11, 16);
            this.LSubTitulo.Name = "LSubTitulo";
            this.LSubTitulo.Size = new System.Drawing.Size(72, 15);
            this.LSubTitulo.TabIndex = 0;
            this.LSubTitulo.Text = "Bienvenido, ";
            // 
            // panelContenido
            // 
            this.panelContenido.BackColor = System.Drawing.Color.White;
            this.panelContenido.Controls.Add(this.label1);
            this.panelContenido.Location = new System.Drawing.Point(143, 2);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Size = new System.Drawing.Size(659, 369);
            this.panelContenido.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(155, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(356, 74);
            this.label1.TabIndex = 0;
            this.label1.Text = "SELECCIONE UNA OPCION \r\nPARA COMENZAR";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormRecepcionista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 373);
            this.Controls.Add(this.panelContenido);
            this.Controls.Add(this.panel1);
            this.Name = "FormRecepcionista";
            this.Text = "FormRecepcionista";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelContenido.ResumeLayout(false);
            this.panelContenido.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnCrearRecep;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnCrearMed;
        private System.Windows.Forms.Label LSubTitulo;
        private System.Windows.Forms.Panel panelContenido;
        private System.Windows.Forms.Label label1;
    }
}