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
    public partial class UC_AgendaTurnos : UserControl
    {
        private TurnoController turnoController;
        private int idMedicoLogueado;
        public UC_AgendaTurnos(TurnoController tController, int idMedico)
        {
            InitializeComponent();
            this.turnoController = tController;
            this.idMedicoLogueado = idMedico;
            DGV_Agenda.AutoGenerateColumns = false;
        }

        private void UC_AgendaTurnos_Load(object sender, EventArgs e)
        {
            LimpiarFiltros();
            CargarAgenda();
        }

        private void CargarAgenda()
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

                DataTable dtAgenda = turnoController.ListarAgendaMedico(
                    this.idMedicoLogueado,
                    fechaDesde,
                    fechaHasta,
                    filtroPaciente 
                );

                DGV_Agenda.DataSource = dtAgenda;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar la agenda: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DGV_Agenda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DGV_Agenda.Columns[e.ColumnIndex].Name == "colAtender")
            {
                string estado = DGV_Agenda.Rows[e.RowIndex].Cells["colEstadoReserva"].Value.ToString();
                if (estado == "Finalizado")
                {
                    return; 
                }
                
                int idReserva = Convert.ToInt32(DGV_Agenda.Rows[e.RowIndex].Cells["id_reserva"].Value);
                string nombrePaciente = DGV_Agenda.Rows[e.RowIndex].Cells["Paciente"].Value.ToString();

                using (Form_FinalizarConsulta formDiagnostico = new Form_FinalizarConsulta(idReserva, nombrePaciente, turnoController))
                {
                    formDiagnostico.ShowDialog();
                }

                CargarAgenda();
            }
        }

        private void dgvAgenda_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (DGV_Agenda.Columns[e.ColumnIndex].Name == "colAtender")
            {
                try
                {
                    object estadoValue = DGV_Agenda.Rows[e.RowIndex].Cells["colEstadoReserva"].Value;

                    if (estadoValue != null)
                    {
                        string estado = estadoValue.ToString();

                        if (estado == "Finalizado")
                        {
                            
                            e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
                            TextRenderer.DrawText(e.Graphics, "Atendido", e.CellStyle.Font, e.CellBounds, SystemColors.GrayText, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                            e.Handled = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error en CellPainting Fila {e.RowIndex}: {ex.Message}");
                }
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarAgenda();
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            LimpiarFiltros();
            CargarAgenda();
        }

        private void LimpiarFiltros()
        {
            DTP_FechaDesde.Value = DateTime.Now;
            DTP_FechaHasta.Value = DateTime.Now.AddMonths(1);
            TB_FiltroPaciente.Clear();
        }


    }
}
