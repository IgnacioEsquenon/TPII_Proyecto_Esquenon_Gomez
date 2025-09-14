namespace AdminTurnosMedicos
{
    partial class FormInicio
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
            btnInicioMedico = new Button();
            btnInicioAdmin = new Button();
            label1 = new Label();
            label2 = new Label();
            TB_Email_Login = new TextBox();
            TB_Password_Login = new TextBox();
            panel1 = new Panel();
            label3 = new Label();
            btnMinimizar = new Button();
            btnSalir = new Button();
            panel2 = new Panel();
            label4 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // btnInicioMedico
            // 
            btnInicioMedico.Location = new Point(109, 196);
            btnInicioMedico.Name = "btnInicioMedico";
            btnInicioMedico.Size = new Size(116, 70);
            btnInicioMedico.TabIndex = 0;
            btnInicioMedico.Text = "Medico";
            btnInicioMedico.UseVisualStyleBackColor = true;
            btnInicioMedico.Click += btnInicioMedico_Click;
            // 
            // btnInicioAdmin
            // 
            btnInicioAdmin.Location = new Point(280, 196);
            btnInicioAdmin.Name = "btnInicioAdmin";
            btnInicioAdmin.Size = new Size(116, 70);
            btnInicioAdmin.TabIndex = 1;
            btnInicioAdmin.Text = "Administrador";
            btnInicioAdmin.UseVisualStyleBackColor = true;
            btnInicioAdmin.Click += btnInicioAdmin_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(83, 94);
            label1.Name = "label1";
            label1.Size = new Size(47, 20);
            label1.TabIndex = 3;
            label1.Text = "Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(83, 145);
            label2.Name = "label2";
            label2.Size = new Size(88, 20);
            label2.TabIndex = 4;
            label2.Text = "Contraseña";
            // 
            // TB_Email_Login
            // 
            TB_Email_Login.Location = new Point(175, 146);
            TB_Email_Login.Name = "TB_Email_Login";
            TB_Email_Login.Size = new Size(221, 23);
            TB_Email_Login.TabIndex = 5;
            TB_Email_Login.TextChanged += textBox1_TextChanged;
            // 
            // TB_Password_Login
            // 
            TB_Password_Login.BackColor = SystemColors.ButtonHighlight;
            TB_Password_Login.Location = new Point(175, 95);
            TB_Password_Login.Name = "TB_Password_Login";
            TB_Password_Login.Size = new Size(221, 23);
            TB_Password_Login.TabIndex = 6;
            // 
            // panel1
            // 
            panel1.BackColor = Color.MidnightBlue;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(btnMinimizar);
            panel1.Controls.Add(btnSalir);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(843, 50);
            panel1.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Bahnschrift SemiBold SemiConden", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(12, 17);
            label3.Name = "label3";
            label3.Size = new Size(107, 19);
            label3.TabIndex = 10;
            label3.Text = "Inicio de Sesión";
            // 
            // btnMinimizar
            // 
            btnMinimizar.BackColor = Color.White;
            btnMinimizar.Font = new Font("Segoe UI Black", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMinimizar.ForeColor = Color.Black;
            btnMinimizar.Location = new Point(744, 3);
            btnMinimizar.Name = "btnMinimizar";
            btnMinimizar.Size = new Size(45, 45);
            btnMinimizar.TabIndex = 9;
            btnMinimizar.Text = "_";
            btnMinimizar.UseVisualStyleBackColor = false;
            btnMinimizar.Click += btnMinimizar_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.White;
            btnSalir.Font = new Font("Segoe UI Black", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = Color.Red;
            btnSalir.Location = new Point(795, 3);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(45, 45);
            btnSalir.TabIndex = 8;
            btnSalir.Text = "X";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.MidnightBlue;
            panel2.Controls.Add(label4);
            panel2.Controls.Add(TB_Password_Login);
            panel2.Controls.Add(btnInicioAdmin);
            panel2.Controls.Add(TB_Email_Login);
            panel2.Controls.Add(btnInicioMedico);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(180, 82);
            panel2.Name = "panel2";
            panel2.Size = new Size(483, 312);
            panel2.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Forte", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Coral;
            label4.Location = new Point(109, 31);
            label4.Name = "label4";
            label4.Size = new Size(155, 35);
            label4.TabIndex = 7;
            label4.Text = "MEDORA";
            // 
            // FormInicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(843, 477);
            Controls.Add(panel2);
            Controls.Add(panel1);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormInicio";
            Text = "Inicio De Sesión - Medora";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnInicioMedico;
        private Button btnInicioAdmin;
        private Label label1;
        private Label label2;
        private TextBox TB_Email_Login;
        private TextBox TB_Password_Login;
        private Panel panel1;
        private Button btnSalir;
        private Button btnMinimizar;
        private Label label3;
        private Panel panel2;
        private Label label4;
    }
}