using System.Windows.Forms;
using System.Drawing;

namespace MedoraApp
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
            this.btnInicioMedico = new System.Windows.Forms.Button();
            this.btnInicioAdmin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_Email_Login = new System.Windows.Forms.TextBox();
            this.TB_Password_Login = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInicioMedico
            // 
            this.btnInicioMedico.Location = new System.Drawing.Point(75, 170);
            this.btnInicioMedico.Name = "btnInicioMedico";
            this.btnInicioMedico.Size = new System.Drawing.Size(99, 61);
            this.btnInicioMedico.TabIndex = 0;
            this.btnInicioMedico.Text = "Medico";
            this.btnInicioMedico.UseVisualStyleBackColor = true;
            this.btnInicioMedico.Click += new System.EventHandler(this.btnInicioMedico_Click);
            // 
            // btnInicioAdmin
            // 
            this.btnInicioAdmin.Location = new System.Drawing.Point(222, 170);
            this.btnInicioAdmin.Name = "btnInicioAdmin";
            this.btnInicioAdmin.Size = new System.Drawing.Size(99, 61);
            this.btnInicioAdmin.TabIndex = 1;
            this.btnInicioAdmin.Text = "Administrador";
            this.btnInicioAdmin.UseVisualStyleBackColor = true;
            this.btnInicioAdmin.Click += new System.EventHandler(this.btnInicioAdmin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(71, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(71, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Contraseña";
            // 
            // TB_Email_Login
            // 
            this.TB_Email_Login.Location = new System.Drawing.Point(165, 128);
            this.TB_Email_Login.Name = "TB_Email_Login";
            this.TB_Email_Login.Size = new System.Drawing.Size(190, 20);
            this.TB_Email_Login.TabIndex = 5;
            // 
            // TB_Password_Login
            // 
            this.TB_Password_Login.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TB_Password_Login.Location = new System.Drawing.Point(150, 82);
            this.TB_Password_Login.Name = "TB_Password_Login";
            this.TB_Password_Login.Size = new System.Drawing.Size(190, 20);
            this.TB_Password_Login.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnMinimizar);
            this.panel1.Controls.Add(this.btnSalir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(723, 43);
            this.panel1.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(10, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 19);
            this.label3.TabIndex = 10;
            this.label3.Text = "Inicio de Sesión";
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.BackColor = System.Drawing.Color.White;
            this.btnMinimizar.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimizar.ForeColor = System.Drawing.Color.Black;
            this.btnMinimizar.Location = new System.Drawing.Point(638, 3);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(39, 39);
            this.btnMinimizar.TabIndex = 9;
            this.btnMinimizar.Text = "_";
            this.btnMinimizar.UseVisualStyleBackColor = false;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            //
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.White;
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.Red;
            this.btnSalir.Location = new System.Drawing.Point(681, 3);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(39, 39);
            this.btnSalir.TabIndex = 8;
            this.btnSalir.Text = "X";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.TB_Password_Login);
            this.panel2.Controls.Add(this.btnInicioAdmin);
            this.panel2.Controls.Add(this.TB_Email_Login);
            this.panel2.Controls.Add(this.btnInicioMedico);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(154, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(414, 270);
            this.panel2.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Forte", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Coral;
            this.label4.Location = new System.Drawing.Point(93, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 35);
            this.label4.TabIndex = 7;
            this.label4.Text = "MEDORA";
            // 
            // FormInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(723, 413);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormInicio";
            this.Text = "Inicio De Sesión - Medora";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

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