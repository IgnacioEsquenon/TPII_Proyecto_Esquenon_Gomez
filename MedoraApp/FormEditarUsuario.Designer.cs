namespace MedoraApp
{
    partial class FormEditarUsuario
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
            this.TB_PasswordMed = new System.Windows.Forms.TextBox();
            this.TB_TelefonoMed = new System.Windows.Forms.TextBox();
            this.TB_EmailMed = new System.Windows.Forms.TextBox();
            this.TB_DNI_Med = new System.Windows.Forms.TextBox();
            this.TB_ApellidoMed = new System.Windows.Forms.TextBox();
            this.TB_NombreMed = new System.Windows.Forms.TextBox();
            this.LB_especialidad = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CB_Especialidades = new System.Windows.Forms.ComboBox();
            this.btnGuardarCambios = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CB_Roles = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // TB_PasswordMed
            // 
            this.TB_PasswordMed.Location = new System.Drawing.Point(139, 203);
            this.TB_PasswordMed.MaxLength = 15;
            this.TB_PasswordMed.Name = "TB_PasswordMed";
            this.TB_PasswordMed.Size = new System.Drawing.Size(153, 20);
            this.TB_PasswordMed.TabIndex = 27;
            // 
            // TB_TelefonoMed
            // 
            this.TB_TelefonoMed.Location = new System.Drawing.Point(139, 167);
            this.TB_TelefonoMed.Name = "TB_TelefonoMed";
            this.TB_TelefonoMed.Size = new System.Drawing.Size(153, 20);
            this.TB_TelefonoMed.TabIndex = 26;
            this.TB_TelefonoMed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_TelefonoMed_KeyPress);
            // 
            // TB_EmailMed
            // 
            this.TB_EmailMed.Location = new System.Drawing.Point(139, 133);
            this.TB_EmailMed.Name = "TB_EmailMed";
            this.TB_EmailMed.Size = new System.Drawing.Size(153, 20);
            this.TB_EmailMed.TabIndex = 25;
            // 
            // TB_DNI_Med
            // 
            this.TB_DNI_Med.Location = new System.Drawing.Point(139, 100);
            this.TB_DNI_Med.Name = "TB_DNI_Med";
            this.TB_DNI_Med.Size = new System.Drawing.Size(153, 20);
            this.TB_DNI_Med.TabIndex = 24;
            this.TB_DNI_Med.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_DNIMed_KeyPress);
            // 
            // TB_ApellidoMed
            // 
            this.TB_ApellidoMed.Location = new System.Drawing.Point(139, 67);
            this.TB_ApellidoMed.Name = "TB_ApellidoMed";
            this.TB_ApellidoMed.Size = new System.Drawing.Size(153, 20);
            this.TB_ApellidoMed.TabIndex = 23;
            this.TB_ApellidoMed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_ApellidoMed_KeyPress);
            // 
            // TB_NombreMed
            // 
            this.TB_NombreMed.Location = new System.Drawing.Point(139, 35);
            this.TB_NombreMed.Name = "TB_NombreMed";
            this.TB_NombreMed.Size = new System.Drawing.Size(153, 20);
            this.TB_NombreMed.TabIndex = 22;
            this.TB_NombreMed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_NombreMed_KeyPress);
            // 
            // LB_especialidad
            // 
            this.LB_especialidad.AutoSize = true;
            this.LB_especialidad.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_especialidad.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LB_especialidad.Location = new System.Drawing.Point(33, 266);
            this.LB_especialidad.Name = "LB_especialidad";
            this.LB_especialidad.Size = new System.Drawing.Size(226, 21);
            this.LB_especialidad.TabIndex = 21;
            this.LB_especialidad.Text = "Seleccione Especialidad:";
            this.LB_especialidad.Visible = false;
            
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(33, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 21);
            this.label7.TabIndex = 20;
            this.label7.Text = "Contraseña:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(33, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 21);
            this.label6.TabIndex = 19;
            this.label6.Text = "Telefono:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(33, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 21);
            this.label5.TabIndex = 18;
            this.label5.Text = "Email:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(33, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 21);
            this.label4.TabIndex = 17;
            this.label4.Text = "DNI:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(33, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 21);
            this.label3.TabIndex = 16;
            this.label3.Text = "Apellido:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(33, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 21);
            this.label2.TabIndex = 15;
            this.label2.Text = "Nombre:";
            // 
            // CB_Especialidades
            // 
            this.CB_Especialidades.FormattingEnabled = true;
            this.CB_Especialidades.Location = new System.Drawing.Point(265, 269);
            this.CB_Especialidades.Name = "CB_Especialidades";
            this.CB_Especialidades.Size = new System.Drawing.Size(134, 21);
            this.CB_Especialidades.TabIndex = 28;
            this.CB_Especialidades.Visible = false;
            // 
            // btnGuardarCambios
            // 
            this.btnGuardarCambios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGuardarCambios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarCambios.Location = new System.Drawing.Point(52, 303);
            this.btnGuardarCambios.Name = "btnGuardarCambios";
            this.btnGuardarCambios.Size = new System.Drawing.Size(132, 46);
            this.btnGuardarCambios.TabIndex = 29;
            this.btnGuardarCambios.Text = "Guardar Cambios";
            this.btnGuardarCambios.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(218, 303);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(132, 46);
            this.btnSalir.TabIndex = 30;
            this.btnSalir.Text = "Descartar y Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(33, 236);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 21);
            this.label1.TabIndex = 31;
            this.label1.Text = "Seleccione Rol:";
            this.label1.Visible = false;
            // 
            // CB_Roles
            // 
            this.CB_Roles.FormattingEnabled = true;
            this.CB_Roles.Location = new System.Drawing.Point(184, 236);
            this.CB_Roles.Name = "CB_Roles";
            this.CB_Roles.Size = new System.Drawing.Size(134, 21);
            this.CB_Roles.TabIndex = 32;
            this.CB_Roles.Visible = false;
            
            // 
            // FormEditarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateBlue;
            this.ClientSize = new System.Drawing.Size(448, 376);
            this.Controls.Add(this.CB_Roles);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGuardarCambios);
            this.Controls.Add(this.CB_Especialidades);
            this.Controls.Add(this.TB_PasswordMed);
            this.Controls.Add(this.TB_TelefonoMed);
            this.Controls.Add(this.TB_EmailMed);
            this.Controls.Add(this.TB_DNI_Med);
            this.Controls.Add(this.TB_ApellidoMed);
            this.Controls.Add(this.TB_NombreMed);
            this.Controls.Add(this.LB_especialidad);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormEditarUsuario";
            this.Text = "FormEditarUsuario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TB_PasswordMed;
        private System.Windows.Forms.TextBox TB_TelefonoMed;
        private System.Windows.Forms.TextBox TB_EmailMed;
        private System.Windows.Forms.TextBox TB_DNI_Med;
        private System.Windows.Forms.TextBox TB_ApellidoMed;
        private System.Windows.Forms.TextBox TB_NombreMed;
        private System.Windows.Forms.Label LB_especialidad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CB_Especialidades;
        private System.Windows.Forms.Button btnGuardarCambios;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CB_Roles;
    }
}