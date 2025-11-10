namespace MedoraApp
{
    partial class UC_HistorialTurnos
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
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DTP_FechaDesde = new System.Windows.Forms.DateTimePicker();
            this.DTP_FechaHasta = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.TB_FiltroPaciente = new System.Windows.Forms.TextBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnLimpiarFiltros = new System.Windows.Forms.Button();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Paciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MotivoConsulta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiagnosticoData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVerDiagnostico = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(778, 54);
            this.panel1.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(5, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Historial de Turnos";
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fecha,
            this.Paciente,
            this.DNI,
            this.MotivoConsulta,
            this.colDiagnosticoData,
            this.colVerDiagnostico});
            this.dgvHistorial.Location = new System.Drawing.Point(15, 236);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.ReadOnly = true;
            this.dgvHistorial.Size = new System.Drawing.Size(746, 201);
            this.dgvHistorial.TabIndex = 22;
            this.dgvHistorial.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHistorial_CellContentClick);
            this.dgvHistorial.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvHistorial_CellFormatting);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cascadia Mono", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(10, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 21);
            this.label2.TabIndex = 23;
            this.label2.Text = "Consultas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(10, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 21);
            this.label3.TabIndex = 24;
            this.label3.Text = "Desde:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(285, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 21);
            this.label4.TabIndex = 25;
            this.label4.Text = "Hasta:";
            // 
            // DTP_FechaDesde
            // 
            this.DTP_FechaDesde.Location = new System.Drawing.Point(70, 107);
            this.DTP_FechaDesde.Name = "DTP_FechaDesde";
            this.DTP_FechaDesde.Size = new System.Drawing.Size(200, 20);
            this.DTP_FechaDesde.TabIndex = 27;
            // 
            // DTP_FechaHasta
            // 
            this.DTP_FechaHasta.Location = new System.Drawing.Point(355, 107);
            this.DTP_FechaHasta.Name = "DTP_FechaHasta";
            this.DTP_FechaHasta.Size = new System.Drawing.Size(200, 20);
            this.DTP_FechaHasta.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(10, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(244, 21);
            this.label5.TabIndex = 29;
            this.label5.Text = "Paciente (DNI o Apellido):";
            // 
            // TB_FiltroPaciente
            // 
            this.TB_FiltroPaciente.Location = new System.Drawing.Point(260, 145);
            this.TB_FiltroPaciente.Name = "TB_FiltroPaciente";
            this.TB_FiltroPaciente.Size = new System.Drawing.Size(200, 20);
            this.TB_FiltroPaciente.TabIndex = 30;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(14, 179);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(101, 32);
            this.btnFiltrar.TabIndex = 31;
            this.btnFiltrar.Text = "Consultar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnLimpiarFiltros
            // 
            this.btnLimpiarFiltros.Location = new System.Drawing.Point(134, 179);
            this.btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            this.btnLimpiarFiltros.Size = new System.Drawing.Size(101, 32);
            this.btnLimpiarFiltros.TabIndex = 32;
            this.btnLimpiarFiltros.Text = "Limpiar Filtros";
            this.btnLimpiarFiltros.UseVisualStyleBackColor = true;
            this.btnLimpiarFiltros.Click += new System.EventHandler(this.btnLimpiarFiltros_Click);
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha del Turno";
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // Paciente
            // 
            this.Paciente.DataPropertyName = "Nombre del Paciente";
            this.Paciente.HeaderText = "Nombre del Paciente";
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
            this.MotivoConsulta.DataPropertyName = "Motivo de Consulta";
            this.MotivoConsulta.HeaderText = "Motivo de la Consulta";
            this.MotivoConsulta.Name = "MotivoConsulta";
            this.MotivoConsulta.ReadOnly = true;
            // 
            // colDiagnosticoData
            // 
            this.colDiagnosticoData.DataPropertyName = "Diagnóstico";
            this.colDiagnosticoData.HeaderText = "Diagnostico";
            this.colDiagnosticoData.Name = "colDiagnosticoData";
            this.colDiagnosticoData.ReadOnly = true;
            this.colDiagnosticoData.Width = 150;
            // 
            // colVerDiagnostico
            // 
            this.colVerDiagnostico.HeaderText = "Ver Diagnostico";
            this.colVerDiagnostico.Name = "colVerDiagnostico";
            this.colVerDiagnostico.ReadOnly = true;
            this.colVerDiagnostico.Width = 150;
            // 
            // UC_HistorialTurnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateBlue;
            this.Controls.Add(this.btnLimpiarFiltros);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.TB_FiltroPaciente);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DTP_FechaHasta);
            this.Controls.Add(this.DTP_FechaDesde);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvHistorial);
            this.Controls.Add(this.panel1);
            this.Name = "UC_HistorialTurnos";
            this.Size = new System.Drawing.Size(778, 482);
            this.Load += new System.EventHandler(this.UC_HistorialTurnos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker DTP_FechaDesde;
        private System.Windows.Forms.DateTimePicker DTP_FechaHasta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TB_FiltroPaciente;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnLimpiarFiltros;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Paciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn DNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn MotivoConsulta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiagnosticoData;
        private System.Windows.Forms.DataGridViewButtonColumn colVerDiagnostico;
    }
}
