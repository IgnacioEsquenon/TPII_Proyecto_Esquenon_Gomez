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
    public partial class UC_GestionReservas : UserControl
    {
        private TurnoController _turnoController;

        public UC_GestionReservas(TurnoController controller)
        {
            InitializeComponent();
            _turnoController = controller;
            dgvReservas.AutoGenerateColumns = false;
            dgvReservas.ReadOnly = true;
        }

        private void UC_GestionReservas_Load(object sender, EventArgs e)
        {
            CargarReservas(); // Carga todas las reservas al abrir
        }

        private void CargarReservas()
        {
            try
            {
                dgvReservas.DataSource = _turnoController.ListarReservasProximas(txtFiltro.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las reservas: " + ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarReservas();
        }

        private void dgvReservas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvReservas.Columns[e.ColumnIndex].Name == "colCancelar")
            {
                string paciente = dgvReservas.Rows[e.RowIndex].Cells["colPaciente"].Value.ToString();
                var confirmacion = MessageBox.Show(
                    $"¿Está seguro de que desea cancelar la reserva del paciente {paciente}?",
                    "Confirmar Cancelación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmacion == DialogResult.Yes)
                {
                    int idReserva = Convert.ToInt32(dgvReservas.Rows[e.RowIndex].Cells["colIdReserva"].Value);
                    bool exito = _turnoController.CancelarReserva(idReserva);

                    if (exito)
                    {
                        MessageBox.Show("Reserva cancelada con éxito.", "Éxito");
                        CargarReservas(); // Recargamos la grilla para que la reserva desaparezca
                    }
                }
            }
        }
    }
}
