using System.Drawing;
using System.Windows.Forms;

namespace MedoraApp
{
    partial class FormAdmin
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
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnVerUsuarios = new System.Windows.Forms.Button();
            this.btnCrearRecep = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnCrearMed = new System.Windows.Forms.Button();
            this.LSubTitulo = new System.Windows.Forms.Label();
            this.panelContenido = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelContenido.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.btnVerUsuarios);
            this.panel1.Controls.Add(this.btnCrearRecep);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnVolver);
            this.panel1.Controls.Add(this.btnCrearMed);
            this.panel1.Controls.Add(this.LSubTitulo);
            this.panel1.Location = new System.Drawing.Point(0, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(140, 369);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox3.Enabled = false;
            this.pictureBox3.Image = global::MedoraApp.Properties.Resources.agenda;
            this.pictureBox3.Location = new System.Drawing.Point(14, 243);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(30, 25);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 12;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.Enabled = false;
            this.pictureBox2.Image = global::MedoraApp.Properties.Resources.profile_user;
            this.pictureBox2.Location = new System.Drawing.Point(12, 157);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 25);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // btnVerUsuarios
            // 
            this.btnVerUsuarios.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnVerUsuarios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVerUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerUsuarios.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnVerUsuarios.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnVerUsuarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerUsuarios.Location = new System.Drawing.Point(3, 226);
            this.btnVerUsuarios.Name = "btnVerUsuarios";
            this.btnVerUsuarios.Size = new System.Drawing.Size(134, 61);
            this.btnVerUsuarios.TabIndex = 10;
            this.btnVerUsuarios.Text = "Ver Usuarios";
            this.btnVerUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVerUsuarios.UseVisualStyleBackColor = false;
            // 
            // btnCrearRecep
            // 
            this.btnCrearRecep.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnCrearRecep.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCrearRecep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearRecep.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCrearRecep.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnCrearRecep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCrearRecep.Location = new System.Drawing.Point(3, 140);
            this.btnCrearRecep.Name = "btnCrearRecep";
            this.btnCrearRecep.Size = new System.Drawing.Size(134, 61);
            this.btnCrearRecep.TabIndex = 9;
            this.btnCrearRecep.Text = "Crear Cuenta\r\nRecepcionista\r\n";
            this.btnCrearRecep.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCrearRecep.UseVisualStyleBackColor = false;
            this.btnCrearRecep.Click += new System.EventHandler(this.btnCrearRecep_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Image = global::MedoraApp.Properties.Resources.profile_user;
            this.pictureBox1.Location = new System.Drawing.Point(14, 73);
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
            this.btnCrearMed.Location = new System.Drawing.Point(3, 56);
            this.btnCrearMed.Name = "btnCrearMed";
            this.btnCrearMed.Size = new System.Drawing.Size(134, 61);
            this.btnCrearMed.TabIndex = 1;
            this.btnCrearMed.Text = "Crear Cuenta\r\nMedico\r\n";
            this.btnCrearMed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCrearMed.UseVisualStyleBackColor = false;
            this.btnCrearMed.Click += new System.EventHandler(this.btnCrearMed_Click);
            // 
            // LSubTitulo
            // 
            this.LSubTitulo.AutoSize = true;
            this.LSubTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.LSubTitulo.ForeColor = System.Drawing.Color.White;
            this.LSubTitulo.Location = new System.Drawing.Point(11, 16);
            this.LSubTitulo.Name = "LSubTitulo";
            this.LSubTitulo.Size = new System.Drawing.Size(108, 15);
            this.LSubTitulo.TabIndex = 0;
            this.LSubTitulo.Text = "Bienvenido, Admin";
            // 
            // panelContenido
            // 
            this.panelContenido.BackColor = System.Drawing.Color.White;
            this.panelContenido.Controls.Add(this.label1);
            this.panelContenido.Location = new System.Drawing.Point(143, 2);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Size = new System.Drawing.Size(659, 369);
            this.panelContenido.TabIndex = 2;
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
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 373);
            this.Controls.Add(this.panelContenido);
            this.Controls.Add(this.panel1);
            this.Name = "FormAdmin";
            this.Text = "Administrador";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelContenido.ResumeLayout(false);
            this.panelContenido.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Button btnVolver;
        private Button btnCrearMed;
        private Label LSubTitulo;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private Button btnVerUsuarios;
        private Button btnCrearRecep;
        private Panel panelContenido;
        private Label label1;
    }
}