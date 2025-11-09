using MedoraAppLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedoraApp
{
    public partial class FormRecepcionista : Form
    {
        private PacienteController pacienteController;
        private TurnoController turnoController;
        private EstadisticasController estadisticasController;
        public FormRecepcionista()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.
                                        ConnectionStrings["MedoraDB"].
                                        ConnectionString;

            pacienteController = new PacienteController(connectionString);
            turnoController = new TurnoController(connectionString);
            estadisticasController = new EstadisticasController(connectionString);
        }


        private void MostrarControl(UserControl controlAMostrar)
        {
           
            panelContenido.Controls.Clear();

            int nuevoAnchoCliente = panel1.Width + controlAMostrar.Width;
            int nuevoAltoCliente = controlAMostrar.Height;

            this.ClientSize = new System.Drawing.Size(nuevoAnchoCliente, nuevoAltoCliente);

            
            this.StartPosition = FormStartPosition.CenterScreen;

           
            controlAMostrar.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(controlAMostrar);
        }


        private void btnVolver_Click(object sender, EventArgs e)
        {
            FormInicio inicio = new FormInicio();
            inicio.Show();
            this.Hide(); // cierra el formulario actual
        }

        private void btnCrearPaciente_Click(object sender, EventArgs e)
        {
            MostrarControl(new UC_RegistrarPaciente(pacienteController));
        }

        private void btnListaPacientes_Click(object sender, EventArgs e)
        {
            MostrarControl(new UC_ListaPacientes(pacienteController));
        }

        private void btnReservarTurno_Click(object sender, EventArgs e)
        {
            MostrarControl(new UC_GestionTurnos(turnoController, pacienteController));
                
        }

        private void btnListaReservas_Click(object sender, EventArgs e)
        {
            MostrarControl(new UC_GestionReservas(turnoController));
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            MostrarControl(new UC_RecepDashboard(estadisticasController));
        }
    }
}
