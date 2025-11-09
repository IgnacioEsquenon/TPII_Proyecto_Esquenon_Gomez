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
    public partial class Form_FinalizarConsulta : Form
    {
        private int idReserva;
        private TurnoController turnoController;
        public Form_FinalizarConsulta(int idReserva, string nombrePaciente, TurnoController controller)
        {
            InitializeComponent();
            this.idReserva = idReserva;
            this.turnoController = controller;
            lblInfoPaciente.Text = "Paciente: " + nombrePaciente;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDiagnostico.Text))
            {
                MessageBox.Show("Por favor, ingrese un diagnóstico o unas notas para la consulta.", "Campo Vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            bool exito = turnoController.FinalizarReserva(this.idReserva, txtDiagnostico.Text);

            if (exito)
            {
                MessageBox.Show("Diagnóstico guardado y turno finalizado con éxito.", "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; 
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
