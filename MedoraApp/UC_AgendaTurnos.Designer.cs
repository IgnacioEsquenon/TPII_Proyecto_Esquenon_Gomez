namespace MedoraApp
{
    partial class UC_AgendaTurnos
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
            this.DGV_Agenda = new System.Windows.Forms.DataGridView();
            this.id_reserva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Paciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MotivoConsulta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObraSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstadoReserva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAtender = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DTP_FechaDesde = new System.Windows.Forms.DateTimePicker();
            this.DTP_FechaHasta = new System.Windows.Forms.DateTimePicker();
            this.TB_FiltroPaciente = new System.Windows.Forms.TextBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnLimpiarFiltros = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Agenda)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(882, 54);
            this.panel1.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(5, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Agenda de Turnos Proximos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cascadia Mono", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(5, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 21);
            this.label2.TabIndex = 21;
            this.label2.Text = "Filtros";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(5, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 21);
            this.label3.TabIndex = 22;
            this.label3.Text = "Desde:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(292, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 21);
            this.label4.TabIndex = 23;
            this.label4.Text = "Hasta:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(5, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(244, 21);
            this.label5.TabIndex = 24;
            this.label5.Text = "Paciente (DNI o Apellido):";
            // 
            // DGV_Agenda
            // 
            this.DGV_Agenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Agenda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_reserva,
            this.Fecha,
            this.Hora,
            this.Paciente,
            this.DNI,
            this.MotivoConsulta,
            this.ObraSocial,
            this.colEstadoReserva,
            this.colAtender});
            this.DGV_Agenda.Location = new System.Drawing.Point(3, 236);
            this.DGV_Agenda.Name = "DGV_Agenda";
            this.DGV_Agenda.ReadOnly = true;
            this.DGV_Agenda.Size = new System.Drawing.Size(854, 228);
            this.DGV_Agenda.TabIndex = 25;
            this.DGV_Agenda.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Agenda_CellContentClick);
            this.DGV_Agenda.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvAgenda_CellPainting);
            // 
            // id_reserva
            // 
            this.id_reserva.DataPropertyName = "id_reserva";
            this.id_reserva.HeaderText = "Nro Reserva";
            this.id_reserva.Name = "id_reserva";
            this.id_reserva.ReadOnly = true;
            this.id_reserva.Visible = false;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "fecha_turno";
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // Hora
            // 
            this.Hora.DataPropertyName = "hora_inicio";
            this.Hora.HeaderText = "Hora";
            this.Hora.Name = "Hora";
            this.Hora.ReadOnly = true;
            // 
            // Paciente
            // 
            this.Paciente.DataPropertyName = "Paciente";
            this.Paciente.HeaderText = "Paciente";
            this.Paciente.Name = "Paciente";
            this.Paciente.ReadOnly = true;
            // 
            // DNI
            // 
            this.DNI.DataPropertyName = "DNI";
            this.DNI.HeaderText = "DNI";
            this.DNI.Name = "DNI";
            this.DNI.ReadOnly = true;
            // 
            // MotivoConsulta
            // 
            this.MotivoConsulta.DataPropertyName = "motivo_consulta";
            this.MotivoConsulta.HeaderText = "Motivo de Consulta";
            this.MotivoConsulta.Name = "MotivoConsulta";
            this.MotivoConsulta.ReadOnly = true;
            // 
            // ObraSocial
            // 
            this.ObraSocial.DataPropertyName = "obra_social";
            this.ObraSocial.HeaderText = "Obra Social";
            this.ObraSocial.Name = "ObraSocial";
            this.ObraSocial.ReadOnly = true;
            // 
            // colEstadoReserva
            // 
            this.colEstadoReserva.DataPropertyName = "estado_reserva";
            this.colEstadoReserva.HeaderText = "Estado";
            this.colEstadoReserva.Name = "colEstadoReserva";
            this.colEstadoReserva.ReadOnly = true;
            // 
            // colAtender
            // 
            this.colAtender.HeaderText = "Accion";
            this.colAtender.Name = "colAtender";
            this.colAtender.ReadOnly = true;
            this.colAtender.Text = "Atender";
            this.colAtender.UseColumnTextForButtonValue = true;
            // 
            // DTP_FechaDesde
            // 
            this.DTP_FechaDesde.Location = new System.Drawing.Point(76, 110);
            this.DTP_FechaDesde.Name = "DTP_FechaDesde";
            this.DTP_FechaDesde.Size = new System.Drawing.Size(200, 20);
            this.DTP_FechaDesde.TabIndex = 26;
            // 
            // DTP_FechaHasta
            // 
            this.DTP_FechaHasta.Location = new System.Drawing.Point(353, 111);
            this.DTP_FechaHasta.Name = "DTP_FechaHasta";
            this.DTP_FechaHasta.Size = new System.Drawing.Size(200, 20);
            this.DTP_FechaHasta.TabIndex = 27;
            // 
            // TB_FiltroPaciente
            // 
            this.TB_FiltroPaciente.Location = new System.Drawing.Point(246, 162);
            this.TB_FiltroPaciente.Name = "TB_FiltroPaciente";
            this.TB_FiltroPaciente.Size = new System.Drawing.Size(200, 20);
            this.TB_FiltroPaciente.TabIndex = 28;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(405, 198);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(101, 32);
            this.btnFiltrar.TabIndex = 29;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // btnLimpiarFiltros
            // 
            this.btnLimpiarFiltros.Location = new System.Drawing.Point(528, 198);
            this.btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            this.btnLimpiarFiltros.Size = new System.Drawing.Size(101, 32);
            this.btnLimpiarFiltros.TabIndex = 30;
            this.btnLimpiarFiltros.Text = "Limpiar Filtros";
            this.btnLimpiarFiltros.UseVisualStyleBackColor = true;
            this.btnLimpiarFiltros.Click += new System.EventHandler(this.btnLimpiarFiltros_Click);
            // 
            // UC_AgendaTurnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateBlue;
            this.Controls.Add(this.btnLimpiarFiltros);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.TB_FiltroPaciente);
            this.Controls.Add(this.DTP_FechaHasta);
            this.Controls.Add(this.DTP_FechaDesde);
            this.Controls.Add(this.DGV_Agenda);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Name = "UC_AgendaTurnos";
            this.Size = new System.Drawing.Size(882, 480);
            this.Load += new System.EventHandler(this.UC_AgendaTurnos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Agenda)).EndInit();
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
        private System.Windows.Forms.DataGridView DGV_Agenda;
        private System.Windows.Forms.DateTimePicker DTP_FechaDesde;
        private System.Windows.Forms.DateTimePicker DTP_FechaHasta;
        private System.Windows.Forms.TextBox TB_FiltroPaciente;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnLimpiarFiltros;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_reserva;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora;
        private System.Windows.Forms.DataGridViewTextBoxColumn Paciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn DNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn MotivoConsulta;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObraSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstadoReserva;
        private System.Windows.Forms.DataGridViewButtonColumn colAtender;
    }
}
