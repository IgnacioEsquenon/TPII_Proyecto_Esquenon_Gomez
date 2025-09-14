namespace AdminTurnosMedicos
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
            panel1 = new Panel();
            PB_icon_med = new PictureBox();
            btnVolver = new Button();
            btnReportes = new Button();
            btnHistorial = new Button();
            btnTurnos = new Button();
            btnPerfil = new Button();
            btnBloques = new Button();
            LSubTitulo = new Label();
            panelContenido = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PB_icon_med).BeginInit();
            panelContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.MidnightBlue;
            panel1.Controls.Add(pictureBox4);
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(PB_icon_med);
            panel1.Controls.Add(btnVolver);
            panel1.Controls.Add(btnReportes);
            panel1.Controls.Add(btnHistorial);
            panel1.Controls.Add(btnTurnos);
            panel1.Controls.Add(btnPerfil);
            panel1.Controls.Add(btnBloques);
            panel1.Controls.Add(LSubTitulo);
            panel1.Location = new Point(1, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(141, 433);
            panel1.TabIndex = 0;
            // 
            // PB_icon_med
            // 
            PB_icon_med.BackColor = Color.Transparent;
            PB_icon_med.BackgroundImageLayout = ImageLayout.None;
            PB_icon_med.Enabled = false;
            PB_icon_med.Image = Properties.Resources.timer;
            PB_icon_med.Location = new Point(21, 76);
            PB_icon_med.Name = "PB_icon_med";
            PB_icon_med.Size = new Size(35, 29);
            PB_icon_med.SizeMode = PictureBoxSizeMode.StretchImage;
            PB_icon_med.TabIndex = 7;
            PB_icon_med.TabStop = false;
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.Red;
            btnVolver.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVolver.ForeColor = SystemColors.ButtonHighlight;
            btnVolver.Location = new Point(3, 393);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(135, 31);
            btnVolver.TabIndex = 6;
            btnVolver.Text = "Volver a Inicio";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // btnReportes
            // 
            btnReportes.BackColor = Color.MidnightBlue;
            btnReportes.FlatStyle = FlatStyle.Flat;
            btnReportes.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReportes.ForeColor = Color.DarkOrange;
            btnReportes.Location = new Point(11, 289);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new Size(106, 50);
            btnReportes.TabIndex = 5;
            btnReportes.Text = "Informes";
            btnReportes.TextAlign = ContentAlignment.MiddleRight;
            btnReportes.UseVisualStyleBackColor = false;
            btnReportes.Click += btnReportes_Click;
            // 
            // btnHistorial
            // 
            btnHistorial.FlatStyle = FlatStyle.Flat;
            btnHistorial.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHistorial.ForeColor = Color.DarkOrange;
            btnHistorial.Location = new Point(11, 233);
            btnHistorial.Name = "btnHistorial";
            btnHistorial.Size = new Size(106, 45);
            btnHistorial.TabIndex = 4;
            btnHistorial.Text = "Historial";
            btnHistorial.TextAlign = ContentAlignment.MiddleRight;
            btnHistorial.UseVisualStyleBackColor = true;
            btnHistorial.Click += btnHistorial_Click;
            // 
            // btnTurnos
            // 
            btnTurnos.BackColor = Color.MidnightBlue;
            btnTurnos.FlatStyle = FlatStyle.Flat;
            btnTurnos.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTurnos.ForeColor = Color.DarkOrange;
            btnTurnos.Location = new Point(11, 177);
            btnTurnos.Name = "btnTurnos";
            btnTurnos.Size = new Size(106, 45);
            btnTurnos.TabIndex = 3;
            btnTurnos.Text = "Agenda";
            btnTurnos.TextAlign = ContentAlignment.MiddleRight;
            btnTurnos.UseVisualStyleBackColor = false;
            btnTurnos.Click += btnTurnos_Click;
            // 
            // btnPerfil
            // 
            btnPerfil.BackColor = Color.MidnightBlue;
            btnPerfil.FlatStyle = FlatStyle.Flat;
            btnPerfil.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPerfil.ForeColor = Color.DarkOrange;
            btnPerfil.Location = new Point(11, 121);
            btnPerfil.Name = "btnPerfil";
            btnPerfil.Size = new Size(106, 45);
            btnPerfil.TabIndex = 2;
            btnPerfil.Text = "Perfil";
            btnPerfil.TextAlign = ContentAlignment.MiddleRight;
            btnPerfil.UseVisualStyleBackColor = false;
            btnPerfil.Click += btnPerfil_Click;
            // 
            // btnBloques
            // 
            btnBloques.BackColor = Color.MidnightBlue;
            btnBloques.BackgroundImageLayout = ImageLayout.Stretch;
            btnBloques.FlatStyle = FlatStyle.Flat;
            btnBloques.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBloques.ForeColor = Color.DarkOrange;
            btnBloques.ImageAlign = ContentAlignment.MiddleLeft;
            btnBloques.Location = new Point(11, 65);
            btnBloques.Name = "btnBloques";
            btnBloques.Size = new Size(106, 50);
            btnBloques.TabIndex = 1;
            btnBloques.Text = "Bloques Horarios";
            btnBloques.TextAlign = ContentAlignment.MiddleRight;
            btnBloques.UseVisualStyleBackColor = false;
            btnBloques.Click += btnBloques_Click;
            // 
            // LSubTitulo
            // 
            LSubTitulo.AutoSize = true;
            LSubTitulo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            LSubTitulo.ForeColor = Color.White;
            LSubTitulo.Location = new Point(11, 17);
            LSubTitulo.Name = "LSubTitulo";
            LSubTitulo.Size = new Size(126, 21);
            LSubTitulo.TabIndex = 0;
            LSubTitulo.Text = "Bienvenido, Doc";
            // 
            // panelContenido
            // 
            panelContenido.BackColor = Color.White;
            panelContenido.Controls.Add(label1);
            panelContenido.Location = new Point(145, 2);
            panelContenido.Name = "panelContenido";
            panelContenido.Size = new Size(682, 436);
            panelContenido.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.Location = new Point(181, 193);
            label1.Name = "label1";
            label1.Size = new Size(356, 74);
            label1.TabIndex = 0;
            label1.Text = "SELECCIONE UNA OPCION \r\nPARA COMENZAR";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.Enabled = false;
            pictureBox1.Image = Properties.Resources.profile_user;
            pictureBox1.Location = new Point(21, 131);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(35, 29);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.BackgroundImageLayout = ImageLayout.None;
            pictureBox2.Enabled = false;
            pictureBox2.Image = Properties.Resources.agenda;
            pictureBox2.Location = new Point(21, 182);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(35, 36);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.BackgroundImageLayout = ImageLayout.None;
            pictureBox3.Enabled = false;
            pictureBox3.Image = Properties.Resources.file;
            pictureBox3.Location = new Point(21, 239);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(35, 28);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 10;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.Transparent;
            pictureBox4.BackgroundImageLayout = ImageLayout.None;
            pictureBox4.Enabled = false;
            pictureBox4.Image = Properties.Resources.report;
            pictureBox4.Location = new Point(21, 300);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(35, 28);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 11;
            pictureBox4.TabStop = false;
            // 
            // FormMedico
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(827, 438);
            Controls.Add(panel1);
            Controls.Add(panelContenido);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FormMedico";
            Text = "Medico";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PB_icon_med).EndInit();
            panelContenido.ResumeLayout(false);
            panelContenido.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
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
