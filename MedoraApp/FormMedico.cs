
using MedoraAppLibrary;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace MedoraApp
{
    public partial class FormMedico : Form
    {   
        private int _idMedicoActual; //Var para guardar el id del medico actual
        private TurnoController turnoController;
        private EstadisticasController estadisticaController;
        string connString = ConfigurationManager.
                                        ConnectionStrings["MedoraDB"].
                                        ConnectionString;


        public FormMedico(int idMedico)
        {
            InitializeComponent();
            _idMedicoActual = idMedico; //Asignar el id del medico actual
            this.turnoController = new TurnoController(connString);
            this.estadisticaController = new EstadisticasController(connString);

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

        private void btnBloques_Click(object sender, EventArgs e)
        {
            MostrarControl(new UC_MenuBloques(_idMedicoActual, turnoController));   
        }

        private void btnAgenda_Click(object sender, EventArgs e)
        {
            MostrarControl(new UC_AgendaTurnos(turnoController, _idMedicoActual));
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            MostrarControl(new UC_HistorialTurnos(turnoController, _idMedicoActual));
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            MostrarControl(new UC_MedicoDashboard(_idMedicoActual, estadisticaController));
        }

    }
}
