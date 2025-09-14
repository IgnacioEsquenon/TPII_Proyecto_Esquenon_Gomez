namespace AdminTurnosMedicos
{
    partial class UC_PerflMed
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
            pictureBox1 = new PictureBox();
            label1 = new Label();
            TB_NombreComp = new TextBox();
            label2 = new Label();
            TB_Esp = new TextBox();
            label3 = new Label();
            TB_Matricula = new TextBox();
            label4 = new Label();
            TB_Email = new TextBox();
            label5 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ActiveCaption;
            pictureBox1.Location = new Point(24, 18);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(130, 119);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(160, 18);
            label1.Name = "label1";
            label1.Size = new Size(113, 15);
            label1.TabIndex = 1;
            label1.Text = "Nombre Completo:";
            // 
            // TB_NombreComp
            // 
            TB_NombreComp.BackColor = SystemColors.AppWorkspace;
            TB_NombreComp.Location = new Point(276, 15);
            TB_NombreComp.Name = "TB_NombreComp";
            TB_NombreComp.Size = new Size(168, 23);
            TB_NombreComp.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(160, 52);
            label2.Name = "label2";
            label2.Size = new Size(76, 15);
            label2.TabIndex = 3;
            label2.Text = "Especialidad:";
            // 
            // TB_Esp
            // 
            TB_Esp.BackColor = SystemColors.AppWorkspace;
            TB_Esp.Location = new Point(242, 49);
            TB_Esp.Name = "TB_Esp";
            TB_Esp.Size = new Size(115, 23);
            TB_Esp.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(160, 85);
            label3.Name = "label3";
            label3.Size = new Size(32, 15);
            label3.TabIndex = 5;
            label3.Text = "DNI:";
            // 
            // TB_Matricula
            // 
            TB_Matricula.BackColor = SystemColors.AppWorkspace;
            TB_Matricula.Location = new Point(205, 82);
            TB_Matricula.Name = "TB_Matricula";
            TB_Matricula.Size = new Size(152, 23);
            TB_Matricula.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(160, 122);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 7;
            label4.Text = "Email:";
            // 
            // TB_Email
            // 
            TB_Email.BackColor = SystemColors.AppWorkspace;
            TB_Email.Location = new Point(205, 119);
            TB_Email.Name = "TB_Email";
            TB_Email.Size = new Size(152, 23);
            TB_Email.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.Location = new Point(160, 156);
            label5.Name = "label5";
            label5.Size = new Size(59, 15);
            label5.TabIndex = 9;
            label5.Text = "Telefono:";
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.AppWorkspace;
            textBox1.Location = new Point(225, 153);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(132, 23);
            textBox1.TabIndex = 10;
            // 
            // button1
            // 
            button1.Location = new Point(24, 153);
            button1.Name = "button1";
            button1.Size = new Size(130, 23);
            button1.TabIndex = 11;
            button1.Text = "Modificar Datos";
            button1.UseVisualStyleBackColor = true;
            // 
            // UC_PerflMed
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PaleTurquoise;
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(TB_Email);
            Controls.Add(label4);
            Controls.Add(TB_Matricula);
            Controls.Add(label3);
            Controls.Add(TB_Esp);
            Controls.Add(label2);
            Controls.Add(TB_NombreComp);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "UC_PerflMed";
            Size = new Size(500, 259);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private TextBox TB_NombreComp;
        private Label label2;
        private TextBox TB_Esp;
        private Label label3;
        private TextBox TB_Matricula;
        private Label label4;
        private TextBox TB_Email;
        private Label label5;
        private TextBox textBox1;
        private Button button1;
    }
}
