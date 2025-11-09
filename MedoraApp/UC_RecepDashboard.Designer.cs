namespace MedoraApp
{
    partial class UC_RecepDashboard
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.chartObrasSociales = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chartDiasSemana = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label29 = new System.Windows.Forms.Label();
            this.lblPorcMayores = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.lblMayores = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.lblPorcAdultos = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.lblAdultos = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblPorcMenores = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblMenores = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblPorcSinOS = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblSinObraSocial = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblPorcConOS = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblConObraSocial = new System.Windows.Forms.Label();
            this.lblPromedioEdad = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartObrasSociales)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDiasSemana)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(1009, 56);
            this.panel1.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(5, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dashboard de Recepción";
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(715, 76);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(112, 23);
            this.btnActualizar.TabIndex = 34;
            this.btnActualizar.Text = "Cargar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // dtpHasta
            // 
            this.dtpHasta.Location = new System.Drawing.Point(493, 78);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(200, 20);
            this.dtpHasta.TabIndex = 33;
            this.dtpHasta.Value = new System.DateTime(2025, 11, 30, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(417, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 21);
            this.label4.TabIndex = 32;
            this.label4.Text = "Hasta - ";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(198, 77);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(200, 20);
            this.dtpDesde.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(122, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 21);
            this.label3.TabIndex = 30;
            this.label3.Text = "Desde - ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(17, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 21);
            this.label2.TabIndex = 29;
            this.label2.Text = "Periodo:";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.NavajoWhite;
            this.panel5.Controls.Add(this.chartObrasSociales);
            this.panel5.Controls.Add(this.label12);
            this.panel5.Controls.Add(this.label13);
            this.panel5.Location = new System.Drawing.Point(9, 116);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(478, 265);
            this.panel5.TabIndex = 35;
            // 
            // chartObrasSociales
            // 
            chartArea1.Name = "ChartArea1";
            this.chartObrasSociales.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartObrasSociales.Legends.Add(legend1);
            this.chartObrasSociales.Location = new System.Drawing.Point(36, 47);
            this.chartObrasSociales.Name = "chartObrasSociales";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartObrasSociales.Series.Add(series1);
            this.chartObrasSociales.Size = new System.Drawing.Size(392, 187);
            this.chartObrasSociales.TabIndex = 3;
            this.chartObrasSociales.Text = "chart1";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 53);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 13);
            this.label12.TabIndex = 2;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label13.Location = new System.Drawing.Point(122, 13);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(235, 21);
            this.label13.TabIndex = 1;
            this.label13.Text = "Pacientes por Obra Social";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.NavajoWhite;
            this.panel2.Controls.Add(this.chartDiasSemana);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(505, 116);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(478, 265);
            this.panel2.TabIndex = 36;
            // 
            // chartDiasSemana
            // 
            this.chartDiasSemana.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.AxisY.MajorGrid.Enabled = false;
            chartArea2.Name = "ChartArea1";
            this.chartDiasSemana.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartDiasSemana.Legends.Add(legend2);
            this.chartDiasSemana.Location = new System.Drawing.Point(17, 47);
            this.chartDiasSemana.Name = "chartDiasSemana";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartDiasSemana.Series.Add(series2);
            this.chartDiasSemana.Size = new System.Drawing.Size(392, 187);
            this.chartDiasSemana.TabIndex = 3;
            this.chartDiasSemana.Text = "chart1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(122, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(226, 21);
            this.label6.TabIndex = 1;
            this.label6.Text = "Turnos por Dia de Semana";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.SandyBrown;
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(0, 401);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1009, 41);
            this.panel3.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(3, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(442, 21);
            this.label7.TabIndex = 0;
            this.label7.Text = "Perfil de Pacientes (en el periodo seleccionado)";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.NavajoWhite;
            this.panel4.Controls.Add(this.label29);
            this.panel4.Controls.Add(this.lblPorcMayores);
            this.panel4.Controls.Add(this.label31);
            this.panel4.Controls.Add(this.lblMayores);
            this.panel4.Controls.Add(this.label25);
            this.panel4.Controls.Add(this.lblPorcAdultos);
            this.panel4.Controls.Add(this.label27);
            this.panel4.Controls.Add(this.lblAdultos);
            this.panel4.Controls.Add(this.label21);
            this.panel4.Controls.Add(this.lblPorcMenores);
            this.panel4.Controls.Add(this.label23);
            this.panel4.Controls.Add(this.lblMenores);
            this.panel4.Controls.Add(this.label18);
            this.panel4.Controls.Add(this.label15);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.lblPorcSinOS);
            this.panel4.Controls.Add(this.label20);
            this.panel4.Controls.Add(this.lblSinObraSocial);
            this.panel4.Controls.Add(this.label16);
            this.panel4.Controls.Add(this.label19);
            this.panel4.Controls.Add(this.lblPorcConOS);
            this.panel4.Controls.Add(this.label17);
            this.panel4.Controls.Add(this.label14);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.lblConObraSocial);
            this.panel4.Controls.Add(this.lblPromedioEdad);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Location = new System.Drawing.Point(30, 448);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(457, 242);
            this.panel4.TabIndex = 37;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label29.Location = new System.Drawing.Point(215, 207);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(28, 21);
            this.label29.TabIndex = 39;
            this.label29.Text = "%)";
            // 
            // lblPorcMayores
            // 
            this.lblPorcMayores.AutoSize = true;
            this.lblPorcMayores.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorcMayores.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPorcMayores.Location = new System.Drawing.Point(190, 207);
            this.lblPorcMayores.Name = "lblPorcMayores";
            this.lblPorcMayores.Size = new System.Drawing.Size(19, 21);
            this.lblPorcMayores.TabIndex = 38;
            this.lblPorcMayores.Text = ".";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label31.Location = new System.Drawing.Point(170, 207);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(19, 21);
            this.label31.TabIndex = 37;
            this.label31.Text = "(";
            // 
            // lblMayores
            // 
            this.lblMayores.AutoSize = true;
            this.lblMayores.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMayores.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblMayores.Location = new System.Drawing.Point(145, 207);
            this.lblMayores.Name = "lblMayores";
            this.lblMayores.Size = new System.Drawing.Size(19, 21);
            this.lblMayores.TabIndex = 36;
            this.lblMayores.Text = ".";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label25.Location = new System.Drawing.Point(226, 175);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(28, 21);
            this.label25.TabIndex = 35;
            this.label25.Text = "%)";
            // 
            // lblPorcAdultos
            // 
            this.lblPorcAdultos.AutoSize = true;
            this.lblPorcAdultos.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorcAdultos.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPorcAdultos.Location = new System.Drawing.Point(201, 175);
            this.lblPorcAdultos.Name = "lblPorcAdultos";
            this.lblPorcAdultos.Size = new System.Drawing.Size(19, 21);
            this.lblPorcAdultos.TabIndex = 34;
            this.lblPorcAdultos.Text = ".";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label27.Location = new System.Drawing.Point(181, 175);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(19, 21);
            this.label27.TabIndex = 33;
            this.label27.Text = "(";
            // 
            // lblAdultos
            // 
            this.lblAdultos.AutoSize = true;
            this.lblAdultos.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdultos.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAdultos.Location = new System.Drawing.Point(156, 175);
            this.lblAdultos.Name = "lblAdultos";
            this.lblAdultos.Size = new System.Drawing.Size(19, 21);
            this.lblAdultos.TabIndex = 32;
            this.lblAdultos.Text = ".";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label21.Location = new System.Drawing.Point(215, 145);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(28, 21);
            this.label21.TabIndex = 31;
            this.label21.Text = "%)";
            // 
            // lblPorcMenores
            // 
            this.lblPorcMenores.AutoSize = true;
            this.lblPorcMenores.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorcMenores.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPorcMenores.Location = new System.Drawing.Point(190, 145);
            this.lblPorcMenores.Name = "lblPorcMenores";
            this.lblPorcMenores.Size = new System.Drawing.Size(19, 21);
            this.lblPorcMenores.TabIndex = 30;
            this.lblPorcMenores.Text = ".";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label23.Location = new System.Drawing.Point(170, 145);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(19, 21);
            this.label23.TabIndex = 29;
            this.label23.Text = "(";
            // 
            // lblMenores
            // 
            this.lblMenores.AutoSize = true;
            this.lblMenores.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenores.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblMenores.Location = new System.Drawing.Point(145, 145);
            this.lblMenores.Name = "lblMenores";
            this.lblMenores.Size = new System.Drawing.Size(19, 21);
            this.lblMenores.TabIndex = 28;
            this.lblMenores.Text = ".";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label18.Location = new System.Drawing.Point(11, 207);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(127, 21);
            this.label18.TabIndex = 27;
            this.label18.Text = "Mayores (65+)";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label15.Location = new System.Drawing.Point(11, 175);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(145, 21);
            this.label15.TabIndex = 26;
            this.label15.Text = "Adultos (18-64)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(340, 99);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 21);
            this.label11.TabIndex = 25;
            this.label11.Text = "%)";
            // 
            // lblPorcSinOS
            // 
            this.lblPorcSinOS.AutoSize = true;
            this.lblPorcSinOS.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorcSinOS.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPorcSinOS.Location = new System.Drawing.Point(306, 99);
            this.lblPorcSinOS.Name = "lblPorcSinOS";
            this.lblPorcSinOS.Size = new System.Drawing.Size(19, 21);
            this.lblPorcSinOS.TabIndex = 24;
            this.lblPorcSinOS.Text = ".";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label20.Location = new System.Drawing.Point(286, 99);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(19, 21);
            this.label20.TabIndex = 23;
            this.label20.Text = "(";
            // 
            // lblSinObraSocial
            // 
            this.lblSinObraSocial.AutoSize = true;
            this.lblSinObraSocial.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSinObraSocial.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSinObraSocial.Location = new System.Drawing.Point(261, 99);
            this.lblSinObraSocial.Name = "lblSinObraSocial";
            this.lblSinObraSocial.Size = new System.Drawing.Size(19, 21);
            this.lblSinObraSocial.TabIndex = 22;
            this.lblSinObraSocial.Text = ".";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label16.Location = new System.Drawing.Point(340, 66);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(28, 21);
            this.label16.TabIndex = 21;
            this.label16.Text = "%)";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label19.Location = new System.Drawing.Point(11, 99);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(244, 21);
            this.label19.TabIndex = 16;
            this.label19.Text = "Pacientes sin Obra Social:";
            // 
            // lblPorcConOS
            // 
            this.lblPorcConOS.AutoSize = true;
            this.lblPorcConOS.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorcConOS.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPorcConOS.Location = new System.Drawing.Point(306, 66);
            this.lblPorcConOS.Name = "lblPorcConOS";
            this.lblPorcConOS.Size = new System.Drawing.Size(19, 21);
            this.lblPorcConOS.TabIndex = 15;
            this.lblPorcConOS.Text = ".";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label17.Location = new System.Drawing.Point(286, 66);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(19, 21);
            this.label17.TabIndex = 14;
            this.label17.Text = "(";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label14.Location = new System.Drawing.Point(10, 145);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(127, 21);
            this.label14.TabIndex = 11;
            this.label14.Text = "Menores (<18)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(11, 66);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(244, 21);
            this.label10.TabIndex = 9;
            this.label10.Text = "Pacientes con Obra Social:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(10, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(172, 21);
            this.label9.TabIndex = 8;
            this.label9.Text = "Promedio de Edad: ";
            // 
            // lblConObraSocial
            // 
            this.lblConObraSocial.AutoSize = true;
            this.lblConObraSocial.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConObraSocial.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblConObraSocial.Location = new System.Drawing.Point(261, 66);
            this.lblConObraSocial.Name = "lblConObraSocial";
            this.lblConObraSocial.Size = new System.Drawing.Size(19, 21);
            this.lblConObraSocial.TabIndex = 4;
            this.lblConObraSocial.Text = ".";
            // 
            // lblPromedioEdad
            // 
            this.lblPromedioEdad.AutoSize = true;
            this.lblPromedioEdad.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPromedioEdad.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPromedioEdad.Location = new System.Drawing.Point(190, 17);
            this.lblPromedioEdad.Name = "lblPromedioEdad";
            this.lblPromedioEdad.Size = new System.Drawing.Size(19, 21);
            this.lblPromedioEdad.TabIndex = 3;
            this.lblPromedioEdad.Text = ".";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 13);
            this.label8.TabIndex = 2;
            // 
            // UC_RecepDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateBlue;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpDesde);
            this.Name = "UC_RecepDashboard";
            this.Size = new System.Drawing.Size(1009, 711);
            this.Load += new System.EventHandler(this.UC_RecepDashboard_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartObrasSociales)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDiasSemana)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartObrasSociales;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDiasSemana;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblConObraSocial;
        private System.Windows.Forms.Label lblPromedioEdad;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblPorcConOS;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblPorcSinOS;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblSinObraSocial;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label lblPorcMayores;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label lblMayores;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label lblPorcAdultos;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label lblAdultos;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblPorcMenores;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lblMenores;
    }
}
