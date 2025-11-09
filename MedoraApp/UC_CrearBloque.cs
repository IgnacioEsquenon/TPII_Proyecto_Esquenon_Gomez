using MedoraAppLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MedoraApp
{
    public partial class UC_CrearBloque : UserControl
    {
        private int _idMedicoActual; //Var para guardar el id del medico actual
        private TurnoController _turnoController;
        public UC_CrearBloque(int idMedico, TurnoController turnoController)
        {
            InitializeComponent();
            _idMedicoActual = idMedico; //Asignar el id del medico actual
            _turnoController = turnoController;
        }

        private void UC_CrearBloque_Load(object sender, EventArgs e)
        {
            CargarDias();
            dtpHoraInicio.Format = DateTimePickerFormat.Time;
            dtpHoraInicio.ShowUpDown = true;
            dtpHoraFin.Format = DateTimePickerFormat.Time;
            dtpHoraFin.ShowUpDown = true;
        }

        private void CargarDias()
        {
            try
            {
                
                cmbDia.DataSource = _turnoController.ObtenerDiasSemana();
                cmbDia.DisplayMember = "nombre";
                cmbDia.ValueMember = "id_dia";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los días: " + ex.Message);
            }

        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            
            if (dtpFechaInicio.Value.Date > dtpFechaFin.Value.Date)
            {
                MessageBox.Show("La fecha de inicio no puede ser posterior a la fecha de fin.", "Error de Fechas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dtpHoraInicio.Value >= dtpHoraFin.Value)
            {
                MessageBox.Show("La hora de inicio debe ser anterior a la hora de fin.", "Error de Horas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Convert.ToInt32(cmbDuracion.SelectedItem) <= 0)
            {
                MessageBox.Show("La duración de los turnos debe ser mayor a cero.", "Error de Duración", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime fechaInicio = dtpFechaInicio.Value.Date;
            DateTime fechaFin = dtpFechaFin.Value.Date;
            TimeSpan horaInicio = dtpHoraInicio.Value.TimeOfDay;
            TimeSpan horaFin = dtpHoraFin.Value.TimeOfDay;
            int duracion = Convert.ToInt32(cmbDuracion.SelectedItem);
            int idDia = Convert.ToInt32(cmbDia.SelectedValue);

            bool exito = _turnoController.CrearBloqueHorario(
                fechaInicio, fechaFin, horaInicio, horaFin,
                duracion, _idMedicoActual, idDia
            );

            if (exito)
            {
                MessageBox.Show("¡Bloque horario y turnos generados con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            // Si no fue exitoso, el controlador ya mostró el mensaje de error específico (ej: bloque solapado).
        }
    }
  }

