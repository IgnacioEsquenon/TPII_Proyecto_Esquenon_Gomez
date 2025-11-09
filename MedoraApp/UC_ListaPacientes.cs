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
    public partial class UC_ListaPacientes : UserControl
    {
        private PacienteController pacienteController;
        private DataTable dtMaestroPacientes;

        public UC_ListaPacientes(PacienteController controller)
        {
            InitializeComponent();
            this.pacienteController = controller;
            DGV_Pacientes.AutoGenerateColumns = false;
        }

        private void UC_ListarPacientes_Load(object sender, EventArgs e)
        {
            CargarPacientes();
            ConfigurarDGV();
        }

        private void CargarPacientes()
        {
            try
            {
                dtMaestroPacientes = pacienteController.ObtenerTodosLosPacientes();
                DGV_Pacientes.DataSource = dtMaestroPacientes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de pacientes: " + ex.Message);
            }
        }
        private void ConfigurarDGV()
        {
            DGV_Pacientes.AutoGenerateColumns = false;

            if (DGV_Pacientes.Columns.Contains("id_paciente"))
            {
                DGV_Pacientes.Columns["id_paciente"].Visible = false;
            }
        }

        private void TB_Buscar_TextChanged(object sender, EventArgs e)
        {
            if (dtMaestroPacientes == null) return;

            string textoBusqueda = TB_Buscar.Text.Trim();
            DataView dv = dtMaestroPacientes.DefaultView;

            if (string.IsNullOrEmpty(textoBusqueda))
            {
                dv.RowFilter = string.Empty;
            }
            else
            {
                string filtro = $"dni LIKE '%{textoBusqueda}%' OR " +
                                $"nombre LIKE '%{textoBusqueda}%' OR " +
                                $"apellido LIKE '%{textoBusqueda}%'";

                dv.RowFilter = filtro;
            }
        }
    }
}
