using MedoraAppLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MedoraApp
{
    public partial class UC_RecepDashboard : UserControl
    {
        private EstadisticasController _statsController;

        public UC_RecepDashboard(EstadisticasController controller)
        {
            InitializeComponent();
            _statsController = controller;
        }

        private void UC_RecepDashboard_Load(object sender, EventArgs e)
        {
            // Establece un rango de fechas por defecto (el último mes)
            dtpHasta.Value = DateTime.Now;
            dtpDesde.Value = DateTime.Now.AddMonths(-1);
            // Carga los datos por primera vez
            ActualizarDashboard();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarDashboard();
        }

        private void ActualizarDashboard()
        {
            try
            {
                CargarKPIsDemograficos();
                CargarGraficoObrasSociales();
                CargarGraficoDiasSemana();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el dashboard: " + ex.Message, "Error General", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarKPIsDemograficos()
        {
            DataTable dt = _statsController.GetRecepEstadisticaPacientes(dtpDesde.Value, dtpHasta.Value);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0]; 

                
                lblPromedioEdad.Text = $"{Convert.ToDecimal(row["Promedio de Edad"]):F1} años";

                lblConObraSocial.Text = row["Pacientes con Obra Social"].ToString();
                lblPorcConOS.Text = $"{Convert.ToDecimal(row["Porcentaje Con Obra Social"]):F1}%";

                lblSinObraSocial.Text = row["Pacientes sin Obra Social"].ToString();
                lblPorcSinOS.Text = $"{Convert.ToDecimal(row["Porcentaje Sin Obra Social"]):F1}%";

                lblMenores.Text = row["Menores (<18)"].ToString();
                lblPorcMenores.Text = $"{Convert.ToDecimal(row["Porcentaje de Menores"]):F1}%";

                lblAdultos.Text = row["Adultos (18-64)"].ToString();
                lblPorcAdultos.Text = $"{Convert.ToDecimal(row["Porcentaje de Adultos"]):F1}%";

                lblMayores.Text = row["Mayores (65+)"].ToString();
                lblPorcMayores.Text = $"{Convert.ToDecimal(row["Porcentaje de Mayores"]):F1}%";
            }
        }

        private void CargarGraficoObrasSociales()
        {
            DataTable dt = _statsController.GetRecepEstadisticaObrasSociales(dtpDesde.Value, dtpHasta.Value);

            chartObrasSociales.Series.Clear();
            chartObrasSociales.Titles.Clear();
            chartObrasSociales.Legends.Clear();

            var series = chartObrasSociales.Series.Add("ObrasSociales");
            series.ChartType = SeriesChartType.Doughnut; 
            series.IsValueShownAsLabel = true;

            // Columnas de la base de datos
            series.XValueMember = "Obra Social";
            series.YValueMembers = "Cantidad de Pacientes";

            // Formato de las etiquetas
            series.Label = "#PERCENT{P1}"; 
            series.LegendText = "#VALX (#VALY)"; 

            chartObrasSociales.DataSource = dt;
            chartObrasSociales.DataBind();

            chartObrasSociales.Titles.Add("Distribución de Pacientes por Obra Social");
            chartObrasSociales.Legends.Add(new Legend("Default") { Docking = Docking.Bottom });
        }

        private void CargarGraficoDiasSemana()
        {
            DataTable dt = _statsController.GetRecepTurnosPorDia(dtpDesde.Value, dtpHasta.Value);

            chartDiasSemana.Series.Clear();
            chartDiasSemana.Titles.Clear();
            chartDiasSemana.Legends.Clear();

            var series = chartDiasSemana.Series.Add("Turnos");
            series.ChartType = SeriesChartType.Column; 
            series.IsValueShownAsLabel = true; 

            // Columnas de la base de datos
            series.XValueMember = "DiaSemana";
            series.YValueMembers = "Cantidad";

            chartDiasSemana.DataSource = dt;
            chartDiasSemana.DataBind();

            chartDiasSemana.Titles.Add("Carga de Turnos por Día de la Semana");
        }


    }
}
