using System.Drawing;
using System.Windows.Forms;

namespace MedoraApp
{
    partial class FormMedico
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PB_icon_med = new System.Windows.Forms.PictureBox();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnHistorial = new System.Windows.Forms.Button();
            this.btnTurnos = new System.Windows.Forms.Button();
            this.btnPerfil = new System.Windows.Forms.Button();
            this.btnBloques = new System.Windows.Forms.Button();
            this.LSubTitulo = new System.Windows.Forms.Label();
            this.panelContenido = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_icon_med)).BeginInit();
            this.panelContenido.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.PB_icon_med);
            this.panel1.Controls.Add(this.btnVolver);
            this.panel1.Controls.Add(this.btnReportes);
            this.panel1.Controls.Add(this.btnHistorial);
            this.panel1.Controls.Add(this.btnTurnos);
            this.panel1.Controls.Add(this.btnPerfil);
            this.panel1.Controls.Add(this.btnBloques);
            this.panel1.Controls.Add(this.LSubTitulo);
            this.panel1.Location = new System.Drawing.Point(1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(135, 424);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox4.Enabled = false;
            this.pictureBox4.Image = global::MedoraApp.Properties.Resources.report;
            this.pictureBox4.Location = new System.Drawing.Point(18, 260);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(30, 24);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 11;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox3.Enabled = false;
            this.pictureBox3.Image = global::MedoraApp.Properties.Resources.file;
            this.pictureBox3.Location = new System.Drawing.Point(18, 207);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(30, 24);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.Enabled = false;
            this.pictureBox2.Image = global::MedoraApp.Properties.Resources.agenda;
            this.pictureBox2.Location = new System.Drawing.Point(18, 158);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 31);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Image = global::MedoraApp.Properties.Resources.profile_user;
            this.pictureBox1.Location = new System.Drawing.Point(18, 114);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // PB_icon_med
            // 
            this.PB_icon_med.BackColor = System.Drawing.Color.Transparent;
            this.PB_icon_med.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PB_icon_med.Enabled = false;
            this.PB_icon_med.Image = global::MedoraApp.Properties.Resources.timer;
            this.PB_icon_med.Location = new System.Drawing.Point(18, 66);
            this.PB_icon_med.Name = "PB_icon_med";
            this.PB_icon_med.Size = new System.Drawing.Size(30, 25);
            this.PB_icon_med.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PB_icon_med.TabIndex = 7;
            this.PB_icon_med.TabStop = false;
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
            // btnReportes
            // 
            this.btnReportes.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportes.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnReportes.Location = new System.Drawing.Point(9, 250);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(110, 43);
            this.btnReportes.TabIndex = 5;
            this.btnReportes.Text = "Informes";
            this.btnReportes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReportes.UseVisualStyleBackColor = false;
            // 
            // btnHistorial
            // 
            this.btnHistorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistorial.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistorial.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnHistorial.Location = new System.Drawing.Point(9, 202);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new System.Drawing.Size(110, 39);
            this.btnHistorial.TabIndex = 4;
            this.btnHistorial.Text = "Historial";
            this.btnHistorial.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHistorial.UseVisualStyleBackColor = true;
            // 
            // btnTurnos
            // 
            this.btnTurnos.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnTurnos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTurnos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTurnos.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnTurnos.Location = new System.Drawing.Point(9, 153);
            this.btnTurnos.Name = "btnTurnos";
            this.btnTurnos.Size = new System.Drawing.Size(110, 39);
            this.btnTurnos.TabIndex = 3;
            this.btnTurnos.Text = "Agenda";
            this.btnTurnos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTurnos.UseVisualStyleBackColor = false;
            // 
            // btnPerfil
            // 
            this.btnPerfil.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnPerfil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPerfil.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPerfil.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnPerfil.Location = new System.Drawing.Point(9, 105);
            this.btnPerfil.Name = "btnPerfil";
            this.btnPerfil.Size = new System.Drawing.Size(110, 39);
            this.btnPerfil.TabIndex = 2;
            this.btnPerfil.Text = "Perfil";
            this.btnPerfil.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPerfil.UseVisualStyleBackColor = false;
            // 
            // btnBloques
            // 
            this.btnBloques.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnBloques.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBloques.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBloques.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBloques.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnBloques.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBloques.Location = new System.Drawing.Point(9, 56);
            this.btnBloques.Name = "btnBloques";
            this.btnBloques.Size = new System.Drawing.Size(110, 43);
            this.btnBloques.TabIndex = 1;
            this.btnBloques.Text = "Bloques Horarios";
            this.btnBloques.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBloques.UseVisualStyleBackColor = false;
            this.btnBloques.Click += new System.EventHandler(this.btnBloques_Click);
            // 
            // LSubTitulo
            // 
            this.LSubTitulo.AutoSize = true;
            this.LSubTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LSubTitulo.ForeColor = System.Drawing.Color.White;
            this.LSubTitulo.Location = new System.Drawing.Point(9, 15);
            this.LSubTitulo.Name = "LSubTitulo";
            this.LSubTitulo.Size = new System.Drawing.Size(126, 21);
            this.LSubTitulo.TabIndex = 0;
            this.LSubTitulo.Text = "Bienvenido, Doc";
            // 
            // panelContenido
            // 
            this.panelContenido.BackColor = System.Drawing.Color.White;
            this.panelContenido.Controls.Add(this.label1);
            this.panelContenido.Location = new System.Drawing.Point(136, 2);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Size = new System.Drawing.Size(668, 372);
            this.panelContenido.TabIndex = 1;
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
            // FormMedico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 373);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelContenido);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormMedico";
            this.Text = "Medico";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_icon_med)).EndInit();
            this.panelContenido.ResumeLayout(false);
            this.panelContenido.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label LSubTitulo;
        private Button btnReportes;
        private Button btnHistorial;
        private Button btnTurnos;
        private Button btnPerfil;
        private Button btnBloques;
        private Button btnVolver;
        private Panel panelContenido;
        private Label label1;
        private PictureBox PB_icon_med;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
    }
}
