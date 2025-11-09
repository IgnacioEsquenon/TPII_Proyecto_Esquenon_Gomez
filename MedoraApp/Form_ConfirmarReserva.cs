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
    public partial class Form_ConfirmarReserva : Form
    {
        // Variables para guardar la información que recibimos
        private int _idTurno;
        private string _medico;
        private DateTime _fecha;
        private TimeSpan _hora;
        private int _idEspecialidad;

        private TurnoController turnoController;
        private PacienteController pacienteController;


        public Form_ConfirmarReserva(int idTurno, string medico, DateTime fecha, 
            TimeSpan hora, int idEspecialidad, TurnoController tController, PacienteController pController)
        {
            InitializeComponent();

            _idTurno = idTurno;
            _medico = medico;
            _fecha = fecha;
            _hora = hora;
            _idEspecialidad = idEspecialidad;
            this.turnoController = tController;
            this.pacienteController = pController;
        }


        private void Form_ConfirmarReserva_Load(object sender, EventArgs e)
        {
            MostrarResumenTurno();
            CargarPacientes();
            CargarMotivos();
        }

        private void MostrarResumenTurno()
        {
            lblMedico.Text = _medico;
            lblFecha.Text = _fecha.ToShortDateString(); // Formato corto, ej: "27/10/2025"
            lblHora.Text = _hora.ToString(@"hh\:mm");    // Formato de 24hs, ej: "09:30"
        }

        private void CargarPacientes()
        {
            try
            {
                CB_Paciente.DataSource = pacienteController.ObtenerTodosLosPacientes();

                CB_Paciente.DisplayMember = "DisplayText";

                CB_Paciente.ValueMember = "id_paciente";

                CB_Paciente.SelectedIndex = -1;
                CB_Paciente.Text = "Buscar o seleccionar paciente...";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar pacientes: " + ex.Message);
            }
        }

        private void CargarMotivos()
        {
            try
            {
                CB_MotivoConsulta.DataSource = turnoController.ObtenerMotivosPorEspecialidad(_idEspecialidad);
                CB_MotivoConsulta.DisplayMember = "descripcion";
                CB_MotivoConsulta.ValueMember = "id_motivo_consulta";
                CB_MotivoConsulta.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar motivos de consulta: " + ex.Message);
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (CB_Paciente.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un paciente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (CB_MotivoConsulta.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un motivo de consulta.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idPaciente = Convert.ToInt32(CB_Paciente.SelectedValue);
            int idMotivo = Convert.ToInt32(CB_MotivoConsulta.SelectedValue);

            bool resultado = turnoController.RegistrarReserva(_idTurno, idPaciente, idMotivo);

            if (resultado)
            {
                MessageBox.Show("✅ ¡Reserva registrada con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; 
                this.Close(); 
            }
            
        }
    }
}
