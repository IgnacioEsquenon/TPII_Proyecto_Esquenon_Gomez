using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MedoraAppLibrary;
using System.Windows.Forms.DataVisualization.Charting;

namespace MedoraApp
{
    public partial class UC_AdminDashboard : UserControl
    {
        private EstadisticasController _statsController;

        public UC_AdminDashboard(EstadisticasController controller)
        {
            InitializeComponent();
            _statsController = controller;
        }

        private void UC_AdminDashboard_Load(object sender, EventArgs e)
        {
            // Establece un rango de fechas por defecto (el último mes) y carga los datos
            dtpHasta.Value = DateTime.Now;
            dtpDesde.Value = DateTime.Now.AddMonths(-1);
            btnActualizar.PerformClick();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                CargarKPIsGenerales();
                CargarGraficoEspecialidades();
                CargarGraficoDistribucion();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el dashboard: " + ex.Message);
            }
        }

        private void CargarKPIsGenerales()
        {
            try
            {
                DataTable dt = _statsController.GetAdminEstadisticaGeneral(dtpDesde.Value, dtpHasta.Value);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    lblProgramadas.Text = row["Reservas Programadas"].ToString();
                    lblAtendidas.Text = row["Reservas Atendidas"].ToString();
                    lblCanceladas.Text = row["Reservas Canceladas"].ToString();
                    lblAusencias.Text = row["Reservas con Ausencia"].ToString();
                    lblPromedioPorMedico.Text = $"{Convert.ToDecimal(row["Promedio de Reservas Atendidas por Médico"]):F2}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar KPIs generales: " + ex.Message);
            }
        }

        private void CargarGraficoEspecialidades()
        {
            try
            {
                DataTable dt = _statsController.GetAdminTurnosPorEspecialidad(dtpDesde.Value, dtpHasta.Value);

                chartEspecialidades.Series.Clear();
                chartEspecialidades.Titles.Clear();
                chartEspecialidades.Legends.Clear();

                var series = chartEspecialidades.Series.Add("Turnos");
                series.ChartType = SeriesChartType.Bar; 
                series.IsValueShownAsLabel = true;

                series.XValueMember = "Especialidad";
                series.YValueMembers = "Cantidad";

                chartEspecialidades.DataSource = dt;
                chartEspecialidades.DataBind();
                chartEspecialidades.Titles.Add("Turnos por Especialidad");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar gráfico de especialidades: " + ex.Message);
            }

        }

        private void CargarGraficoDistribucion()
        {
            try
            {
                DataTable dt = _statsController.GetAdminDistribucionDeEstados(dtpDesde.Value, dtpHasta.Value);

                chartDistribucionEstados.Series.Clear();
                chartDistribucionEstados.Titles.Clear();
                chartDistribucionEstados.Legends.Clear();

                var series = chartDistribucionEstados.Series.Add("Distribucion");
                series.ChartType = SeriesChartType.Pie; 
                series.IsValueShownAsLabel = true;

                series.XValueMember = "Estado";
                series.YValueMembers = "Cantidad";
                series.Label = "#PERCENT{P1}"; 
                series.LegendText = "#VALX"; 

                chartDistribucionEstados.DataSource = dt;
                chartDistribucionEstados.DataBind();

                chartDistribucionEstados.Titles.Add("Distribución de Turnos");
                chartDistribucionEstados.Legends.Add(new Legend("Default") { Docking = Docking.Bottom });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar gráfico de distribución: " + ex.Message);
            }
        }
    }

}
