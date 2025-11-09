namespace MedoraApp
{
    partial class UC_GestionTurnos
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.DGV_Turnos = new System.Windows.Forms.DataGridView();
            this.id_turno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_turno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hora_inicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaSemana = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoTurno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Medico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnReservar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DTP_FechaDesde = new System.Windows.Forms.DateTimePicker();
            this.DTP_FechaHasta = new System.Windows.Forms.DateTimePicker();
            this.CB_Especialidad = new System.Windows.Forms.ComboBox();
            this.CB_Medico = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CB_Dia = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Turnos)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(910, 54);
            this.panel1.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(5, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gestionar Turnos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cascadia Mono", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(3, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(307, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Complete las siguientes opciones ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(3, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 21);
            this.label3.TabIndex = 20;
            this.label3.Text = "Elija Especialidad:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(3, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(298, 21);
            this.label4.TabIndex = 21;
            this.label4.Text = "Seleccione un Medico disponible:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(3, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 21);
            this.label5.TabIndex = 22;
            this.label5.Text = "Desde:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(3, 251);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 21);
            this.label6.TabIndex = 23;
            this.label6.Text = "Hasta:";
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.Location = new System.Drawing.Point(101, 348);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(101, 50);
            this.btn_Buscar.TabIndex = 24;
            this.btn_Buscar.Text = "Buscar Turnos";
            this.btn_Buscar.UseVisualStyleBackColor = true;
            this.btn_Buscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // DGV_Turnos
            // 
            this.DGV_Turnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Turnos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_turno,
            this.fecha_turno,
            this.hora_inicio,
            this.DiaSemana,
            this.EstadoTurno,
            this.Medico,
            this.btnReservar});
            this.DGV_Turnos.Location = new System.Drawing.Point(352, 66);
            this.DGV_Turnos.Name = "DGV_Turnos";
            this.DGV_Turnos.ReadOnly = true;
            this.DGV_Turnos.Size = new System.Drawing.Size(545, 366);
            this.DGV_Turnos.TabIndex = 25;
            this.DGV_Turnos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Turnos_CellContentClick);
            // 
            // id_turno
            // 
            this.id_turno.DataPropertyName = "id_turno";
            this.id_turno.HeaderText = "id_turno";
            this.id_turno.Name = "id_turno";
            this.id_turno.ReadOnly = true;
            this.id_turno.Visible = false;
            // 
            // fecha_turno
            // 
            this.fecha_turno.DataPropertyName = "fecha_turno";
            this.fecha_turno.HeaderText = "Fecha ";
            this.fecha_turno.Name = "fecha_turno";
            this.fecha_turno.ReadOnly = true;
            // 
            // hora_inicio
            // 
            this.hora_inicio.DataPropertyName = "hora_inicio";
            this.hora_inicio.HeaderText = "Hora";
            this.hora_inicio.Name = "hora_inicio";
            this.hora_inicio.ReadOnly = true;
            // 
            // DiaSemana
            // 
            this.DiaSemana.DataPropertyName = "DiaSemana";
            this.DiaSemana.HeaderText = "Dia";
            this.DiaSemana.Name = "DiaSemana";
            this.DiaSemana.ReadOnly = true;
            // 
            // EstadoTurno
            // 
            this.EstadoTurno.DataPropertyName = "EstadoTurno";
            this.EstadoTurno.HeaderText = "Estado";
            this.EstadoTurno.Name = "EstadoTurno";
            this.EstadoTurno.ReadOnly = true;
            // 
            // Medico
            // 
            this.Medico.DataPropertyName = "Medico";
            this.Medico.HeaderText = "Medico";
            this.Medico.Name = "Medico";
            this.Medico.ReadOnly = true;
            this.Medico.Visible = false;
            // 
            // btnReservar
            // 
            this.btnReservar.HeaderText = "Reservar";
            this.btnReservar.Name = "btnReservar";
            this.btnReservar.ReadOnly = true;
            this.btnReservar.Text = "Reservar";
            this.btnReservar.UseColumnTextForButtonValue = true;
            // 
            // DTP_FechaDesde
            // 
            this.DTP_FechaDesde.Location = new System.Drawing.Point(64, 217);
            this.DTP_FechaDesde.Name = "DTP_FechaDesde";
            this.DTP_FechaDesde.Size = new System.Drawing.Size(200, 20);
            this.DTP_FechaDesde.TabIndex = 26;
            // 
            // DTP_FechaHasta
            // 
            this.DTP_FechaHasta.Location = new System.Drawing.Point(64, 252);
            this.DTP_FechaHasta.Name = "DTP_FechaHasta";
            this.DTP_FechaHasta.Size = new System.Drawing.Size(200, 20);
            this.DTP_FechaHasta.TabIndex = 27;
            // 
            // CB_Especialidad
            // 
            this.CB_Especialidad.FormattingEnabled = true;
            this.CB_Especialidad.Location = new System.Drawing.Point(180, 104);
            this.CB_Especialidad.Name = "CB_Especialidad";
            this.CB_Especialidad.Size = new System.Drawing.Size(166, 21);
            this.CB_Especialidad.TabIndex = 28;
            this.CB_Especialidad.SelectedIndexChanged += new System.EventHandler(this.CB_Especialidad_SelectedIndexChanged);
            // 
            // CB_Medico
            // 
            this.CB_Medico.FormattingEnabled = true;
            this.CB_Medico.Location = new System.Drawing.Point(7, 176);
            this.CB_Medico.Name = "CB_Medico";
            this.CB_Medico.Size = new System.Drawing.Size(195, 21);
            this.CB_Medico.TabIndex = 29;
            this.CB_Medico.SelectedIndexChanged += new System.EventHandler(this.CB_Medico_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(3, 291);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(172, 21);
            this.label7.TabIndex = 30;
            this.label7.Text = "Seleccione un dia:";
            // 
            // CB_Dia
            // 
            this.CB_Dia.FormattingEnabled = true;
            this.CB_Dia.Location = new System.Drawing.Point(170, 294);
            this.CB_Dia.Name = "CB_Dia";
            this.CB_Dia.Size = new System.Drawing.Size(121, 21);
            this.CB_Dia.TabIndex = 31;
            // 
            // UC_GestionTurnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateBlue;
            this.Controls.Add(this.CB_Dia);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CB_Medico);
            this.Controls.Add(this.CB_Especialidad);
            this.Controls.Add(this.DTP_FechaHasta);
            this.Controls.Add(this.DTP_FechaDesde);
            this.Controls.Add(this.DGV_Turnos);
            this.Controls.Add(this.btn_Buscar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Name = "UC_GestionTurnos";
            this.Size = new System.Drawing.Size(910, 479);
            this.Load += new System.EventHandler(this.UC_GestionTurnos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Turnos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.DataGridView DGV_Turnos;
        private System.Windows.Forms.DateTimePicker DTP_FechaDesde;
        private System.Windows.Forms.DateTimePicker DTP_FechaHasta;
        private System.Windows.Forms.ComboBox CB_Especialidad;
        private System.Windows.Forms.ComboBox CB_Medico;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_turno;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_turno;
        private System.Windows.Forms.DataGridViewTextBoxColumn hora_inicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaSemana;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoTurno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Medico;
        private System.Windows.Forms.DataGridViewButtonColumn btnReservar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CB_Dia;
    }
}
