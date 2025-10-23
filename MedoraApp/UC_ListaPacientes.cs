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

        // Aplica la configuración inicial al DataGridView
        private void ConfigurarDGV()
        {
            // Esencial para que se respeten las columnas del diseñador
            DGV_Pacientes.AutoGenerateColumns = false;

            // Ocultamos la columna del ID del paciente
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
                // Si la barra de búsqueda está vacía, se quita el filtro y se muestran todos
                dv.RowFilter = string.Empty;
            }
            else
            {
                // Se crea un filtro que busca el texto en las columnas de DNI, nombre O apellido.
                // Los '%' son comodines que permiten encontrar el texto en cualquier parte del campo.
                string filtro = $"dni LIKE '%{textoBusqueda}%' OR " +
                                $"nombre LIKE '%{textoBusqueda}%' OR " +
                                $"apellido LIKE '%{textoBusqueda}%'";

                // Se aplica el filtro a la vista de datos
                dv.RowFilter = filtro;
            }
        }
    }
}
