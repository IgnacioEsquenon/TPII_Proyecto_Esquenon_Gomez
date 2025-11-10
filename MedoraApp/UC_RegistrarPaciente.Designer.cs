namespace MedoraApp
{
    partial class UC_RegistrarPaciente
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
            this.label1 = new System.Windows.Forms.Label();
            this.TB_TelefonoPac = new System.Windows.Forms.TextBox();
            this.TB_EmailPac = new System.Windows.Forms.TextBox();
            this.TB_DNIPac = new System.Windows.Forms.TextBox();
            this.TB_ApellidoPac = new System.Windows.Forms.TextBox();
            this.TB_NombrePac = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Edad = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.CB_ObraSocial = new System.Windows.Forms.ComboBox();
            this.btnCrearPac = new System.Windows.Forms.Button();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Orange;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(659, 48);
            this.panel1.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(5, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registrar Paciente";
            // 
            // TB_TelefonoPac
            // 
            this.TB_TelefonoPac.Location = new System.Drawing.Point(148, 260);
            this.TB_TelefonoPac.Name = "TB_TelefonoPac";
            this.TB_TelefonoPac.Size = new System.Drawing.Size(153, 20);
            this.TB_TelefonoPac.TabIndex = 38;
            this.TB_TelefonoPac.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_TelefonoPac_KeyPress);
            // 
            // TB_EmailPac
            // 
            this.TB_EmailPac.Location = new System.Drawing.Point(148, 216);
            this.TB_EmailPac.Name = "TB_EmailPac";
            this.TB_EmailPac.Size = new System.Drawing.Size(153, 20);
            this.TB_EmailPac.TabIndex = 37;
            // 
            // TB_DNIPac
            // 
            this.TB_DNIPac.Location = new System.Drawing.Point(148, 143);
            this.TB_DNIPac.Name = "TB_DNIPac";
            this.TB_DNIPac.Size = new System.Drawing.Size(153, 20);
            this.TB_DNIPac.TabIndex = 36;
            this.TB_DNIPac.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_DNIPac_KeyPress);
            // 
            // TB_ApellidoPac
            // 
            this.TB_ApellidoPac.Location = new System.Drawing.Point(148, 104);
            this.TB_ApellidoPac.Name = "TB_ApellidoPac";
            this.TB_ApellidoPac.Size = new System.Drawing.Size(153, 20);
            this.TB_ApellidoPac.TabIndex = 35;
            this.TB_ApellidoPac.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_ApellidoPac_KeyPress);
            // 
            // TB_NombrePac
            // 
            this.TB_NombrePac.Location = new System.Drawing.Point(148, 66);
            this.TB_NombrePac.Name = "TB_NombrePac";
            this.TB_NombrePac.Size = new System.Drawing.Size(153, 20);
            this.TB_NombrePac.TabIndex = 34;
            this.TB_NombrePac.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_NombrePac_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(33, 259);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 21);
            this.label6.TabIndex = 33;
            this.label6.Text = "Telefono:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(33, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 21);
            this.label5.TabIndex = 32;
            this.label5.Text = "Email:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(33, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 21);
            this.label4.TabIndex = 31;
            this.label4.Text = "DNI:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(33, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 21);
            this.label3.TabIndex = 30;
            this.label3.Text = "Apellido:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(33, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 21);
            this.label2.TabIndex = 29;
            this.label2.Text = "Nombre:";
            // 
            // Edad
            // 
            this.Edad.AutoSize = true;
            this.Edad.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Edad.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Edad.Location = new System.Drawing.Point(33, 176);
            this.Edad.Name = "Edad";
            this.Edad.Size = new System.Drawing.Size(190, 21);
            this.Edad.TabIndex = 39;
            this.Edad.Text = "Fecha de Nacimiento:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(33, 302);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(217, 21);
            this.label7.TabIndex = 40;
            this.label7.Text = "Seleccione Obra Social:";
            // 
            // CB_ObraSocial
            // 
            this.CB_ObraSocial.FormattingEnabled = true;
            this.CB_ObraSocial.Location = new System.Drawing.Point(257, 301);
            this.CB_ObraSocial.Name = "CB_ObraSocial";
            this.CB_ObraSocial.Size = new System.Drawing.Size(134, 21);
            this.CB_ObraSocial.TabIndex = 42;
            this.CB_ObraSocial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CB_ObraSocial_KeyPress);
            // 
            // btnCrearPac
            // 
            this.btnCrearPac.Location = new System.Drawing.Point(242, 365);
            this.btnCrearPac.Name = "btnCrearPac";
            this.btnCrearPac.Size = new System.Drawing.Size(149, 38);
            this.btnCrearPac.TabIndex = 43;
            this.btnCrearPac.Text = "Registrar Paciente";
            this.btnCrearPac.UseVisualStyleBackColor = true;
            this.btnCrearPac.Click += new System.EventHandler(this.btnCrearPac_Click);
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(229, 176);
            this.dtpFechaNacimiento.MaxDate = new System.DateTime(2025, 11, 16, 0, 0, 0, 0);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaNacimiento.TabIndex = 44;
            this.dtpFechaNacimiento.Value = new System.DateTime(2025, 11, 9, 0, 0, 0, 0);
            // 
            // UC_RegistrarPaciente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateBlue;
            this.Controls.Add(this.dtpFechaNacimiento);
            this.Controls.Add(this.btnCrearPac);
            this.Controls.Add(this.CB_ObraSocial);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Edad);
            this.Controls.Add(this.TB_TelefonoPac);
            this.Controls.Add(this.TB_EmailPac);
            this.Controls.Add(this.TB_DNIPac);
            this.Controls.Add(this.TB_ApellidoPac);
            this.Controls.Add(this.TB_NombrePac);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Name = "UC_RegistrarPaciente";
            this.Size = new System.Drawing.Size(659, 479);
            this.Load += new System.EventHandler(this.UC_RegistrarPaciente_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_TelefonoPac;
        private System.Windows.Forms.TextBox TB_EmailPac;
        private System.Windows.Forms.TextBox TB_DNIPac;
        private System.Windows.Forms.TextBox TB_ApellidoPac;
        private System.Windows.Forms.TextBox TB_NombrePac;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Edad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CB_ObraSocial;
        private System.Windows.Forms.Button btnCrearPac;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
    }
}
