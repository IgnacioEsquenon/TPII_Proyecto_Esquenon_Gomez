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

namespace MedoraApp
{
    public partial class UC_HistorialTurnos : UserControl
    {
        private TurnoController turnoController;
        private int idMedicoLogueado;

        public UC_HistorialTurnos(TurnoController tController, int idMedico)
        {
            InitializeComponent();
            this.turnoController = tController;
            this.idMedicoLogueado = idMedico;
            dgvHistorial.AutoGenerateColumns = false;
        }

        private void UC_HistorialTurnos_Load(object sender, EventArgs e)
        {
            LimpiarFiltros();
            CargarHistorial();
        }

        private void CargarHistorial()
        {
            try
            {
                DateTime fechaDesde = DTP_FechaDesde.Value.Date;
                DateTime fechaHasta = DTP_FechaHasta.Value.Date;
                string filtroPaciente = TB_FiltroPaciente.Text;

                if (fechaDesde > fechaHasta)
                {
                    MessageBox.Show("La fecha 'Desde' no puede ser posterior a la fecha 'Hasta'.", "Error de Fechas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable dt = turnoController.ListarHistorialMedico(
                    this.idMedicoLogueado,
                    fechaDesde,
                    fechaHasta,
                    filtroPaciente
                );

                dgvHistorial.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar el historial: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarHistorial();
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            LimpiarFiltros();
            CargarHistorial();
        }

        private void LimpiarFiltros()
        {
            // Por defecto, mostramos los turnos del último mes
            DTP_FechaDesde.Value = DateTime.Now.AddMonths(-1);
            DTP_FechaHasta.Value = DateTime.Now;
            TB_FiltroPaciente.Clear();
        }

        private void dgvHistorial_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // 1. Verificamos que no estemos en la cabecera
            if (e.RowIndex < 0) return;

            // 2. Verificamos que estemos en nuestra columna de botón "colVerDiagnostico"
            if (dgvHistorial.Columns[e.ColumnIndex].Name == "colVerDiagnostico")
            {
                // 3. Obtenemos el texto de forma SEGURA desde la columna de DATOS INVISIBLE
                //    'as string' convertirá DBNull.Value o null en un 'null' de C# sin fallar.
                string diagnostico = dgvHistorial.Rows[e.RowIndex].Cells["colDiagnosticoData"].Value as string;

                // 4. La Lógica de Decisión
                //    string.IsNullOrEmpty() comprueba si es null O una cadena vacía ""
                if (string.IsNullOrEmpty(diagnostico) || diagnostico == "(No asistió el Paciente)" || diagnostico == "Sin diagnóstico")
                {
                    // Si no hay diagnóstico, mostramos el texto informativo
                    e.Value = diagnostico;
                }
                else
                {
                    // Si SÍ hay un diagnóstico, ponemos el texto del botón
                    e.Value = "Ver Diagnóstico";
                }
            }
        }
        private void dgvHistorial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0 && dgvHistorial.Columns[e.ColumnIndex].Name == "colVerDiagnostico")
            {
                
                string diagnostico = dgvHistorial.Rows[e.RowIndex].Cells["colDiagnosticoData"].Value.ToString();

                
                if (diagnostico != "(No asistió el Paciente)" && diagnostico != "Sin diagnóstico")
                {
                    
                    MessageBox.Show(diagnostico, "Detalle del Diagnóstico", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
