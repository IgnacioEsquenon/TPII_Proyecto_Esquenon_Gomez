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
    public partial class UC_MedicoDashboard : UserControl
    {
        private EstadisticasController _statsController;
        private int _idMedico;

        public UC_MedicoDashboard(int idMedico, EstadisticasController controller)
        {
            InitializeComponent();
            _idMedico = idMedico;
            _statsController = controller;
        }

        private void UC_MedicoDashboard_Load(object sender, EventArgs e)
        {
            dtpHasta.Value = DateTime.Now;
            dtpDesde.Value = DateTime.Now.AddMonths(-1);
            btnActualizar.PerformClick();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarKPIsMedico();
            CargarGraficoMotivos();
        }

        private void CargarKPIsMedico()
        {
            try
            {
                DataTable dt = _statsController.GetMedicoActividad(_idMedico, dtpDesde.Value, dtpHasta.Value);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    lblMisAtendidos.Text = row["Reservas Atendidas"].ToString();
                    lblPorcentajeAsist.Text = $"{Convert.ToDecimal(row["Porcentaje de Asistencia"]):F2}%";
                    lblPromedioSemanal.Text = $"{Convert.ToDecimal(row["Promedio Semanal de Pacientes Atendidos"]):F2}";
                }
            }
            catch (Exception ex) { MessageBox.Show("Error al cargar KPIs: " + ex.Message); }
        }

        private void CargarGraficoMotivos()
        {
            try
            {
                DataTable dt = _statsController.GetMedicoMotivos(_idMedico, dtpDesde.Value, dtpHasta.Value);

                chartMotivos.Series.Clear();
                chartMotivos.Legends.Clear();

                var series = chartMotivos.Series.Add("Motivos");
                series.ChartType = SeriesChartType.Pie; 

                series.XValueMember = "Motivo de Consulta";
                series.YValueMembers = "Cantidad de Atenciones";
                series.IsValueShownAsLabel = true; 
                series.Label = "#VALX (#PERCENT{P0})"; 

                chartMotivos.DataSource = dt;
                chartMotivos.DataBind();
                chartMotivos.Legends.Add(new Legend("Default") { Docking = Docking.Bottom });
            }
            catch (Exception ex) { MessageBox.Show("Error al cargar gráfico de motivos: " + ex.Message); }
        }

    }
}
