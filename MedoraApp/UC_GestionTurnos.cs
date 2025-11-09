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
    public partial class UC_GestionTurnos : UserControl
    {
        private TurnoController turnoController;
        private PacienteController pacienteController; // Para la ventana emergente

        public UC_GestionTurnos(TurnoController tController, PacienteController pController)
        {
            InitializeComponent();
            this.turnoController = tController;
            this.pacienteController = pController;
            DGV_Turnos.AutoGenerateColumns = false;
        }

        private void UC_GestionTurnos_Load(object sender, EventArgs e)
        {
            CargarEspecialidades();
            DGV_Turnos.DataSource = null; 
        }

        private void CargarEspecialidades()
        {
            try
            {
                DataTable dtEspecialidades = turnoController.ObtenerEspecialidades();

                DataRow filaDefault = dtEspecialidades.NewRow();
                filaDefault["id_especialidad"] = 0; 
                filaDefault["nombre"] = "- Seleccione una Especialidad -";

                dtEspecialidades.Rows.InsertAt(filaDefault, 0);

                CB_Especialidad.DataSource = dtEspecialidades;
                CB_Especialidad.DisplayMember = "nombre";
                CB_Especialidad.ValueMember = "id_especialidad";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al inicializar especialidades: " + ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (CB_Medico.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un médico.");
                return;
            }

            int idMedico = Convert.ToInt32(CB_Medico.SelectedValue);
            DateTime fechaDesde = DTP_FechaDesde.Value.Date;
            DateTime fechaHasta = DTP_FechaHasta.Value.Date;

            if (fechaDesde > fechaHasta)
            {
                MessageBox.Show("La fecha 'Desde' no puede ser posterior a la fecha 'Hasta'.");
                return;
            }

           
            int? idDia = null; 
          
            if (CB_Dia.SelectedValue != null && Convert.ToInt32(CB_Dia.SelectedValue) != 0)
            {
                idDia = Convert.ToInt32(CB_Dia.SelectedValue);
            }

            DataTable dt = turnoController.ObtenerTurnosDisponibles(idMedico, fechaDesde, fechaHasta, idDia);

            DGV_Turnos.DataSource = dt;
            
        }


        private void CB_Especialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (turnoController == null || CB_Especialidad.SelectedValue == null || !(CB_Especialidad.SelectedValue is int))
            {
                return;
            }
            try
            {
                int idEspecialidad = Convert.ToInt32(CB_Especialidad.SelectedValue);
                
                if (idEspecialidad == 0)
                {
                    CB_Medico.DataSource = null;
                    CB_Medico.Enabled = false;
                    DGV_Turnos.DataSource = null;
                    return;
                }

                
                DataTable dtMedicos = turnoController.ObtenerMedicosPorEspecialidad(idEspecialidad);

                DataRow filaDefault = dtMedicos.NewRow();
                filaDefault["id_usuario"] = 0; 
                filaDefault["NombreCompleto"] = "- Seleccione un médico -";

                dtMedicos.Rows.InsertAt(filaDefault, 0);

                CB_Medico.DataSource = dtMedicos;
                CB_Medico.DisplayMember = "NombreCompleto";
                CB_Medico.ValueMember = "id_usuario";
                CB_Medico.Enabled = true; 

                DGV_Turnos.DataSource = null; 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al seleccionar especialidad: " + ex.Message);
                CB_Medico.DataSource = null;
                CB_Medico.Enabled = false;
            }
        }
        private void CB_Medico_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (CB_Medico.SelectedValue == null || !(CB_Medico.SelectedValue is int))
            {
                CB_Dia.DataSource = null;
                CB_Dia.Enabled = false;
                return;
            }

            try
            {
                int idMedico = Convert.ToInt32(CB_Medico.SelectedValue);

                
                DataTable dtDias = turnoController.ObtenerDiasDeTrabajoPorMedico(idMedico);

                if (dtDias.Rows.Count > 0)
                {
                   
                    DataRow filaTodos = dtDias.NewRow();
                    filaTodos["id_dia"] = 0; 
                    filaTodos["nombre"] = "- Todos los días -";
                    dtDias.Rows.InsertAt(filaTodos, 0);

                    CB_Dia.DataSource = dtDias;
                    CB_Dia.DisplayMember = "nombre";
                    CB_Dia.ValueMember = "id_dia";
                    CB_Dia.Enabled = true; // Habilitamos el filtro
                }
                else
                {
                    CB_Dia.DataSource = null;
                    CB_Dia.Enabled = false;
                }

                DGV_Turnos.DataSource = null; // Limpia la grilla al cambiar de médico
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar días del médico: " + ex.Message);
                CB_Dia.DataSource = null;
                CB_Dia.Enabled = false;
            }
        }


        private void DGV_Turnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

           
            Console.WriteLine("--- Inspeccionando Fila " + e.RowIndex + " ---");
            foreach (DataGridViewCell cell in DGV_Turnos.Rows[e.RowIndex].Cells)
            {
                string columnName = DGV_Turnos.Columns[cell.ColumnIndex].Name;
                object cellValue = cell.Value;
                Console.WriteLine($"Columna: {columnName}, Valor: {cellValue ?? "NULL"}");
            }
            Console.WriteLine("----------------------------------");
           

            if (e.RowIndex >= 0 && DGV_Turnos.Columns[e.ColumnIndex].Name == "btnReservar")
            {
                int idTurno = Convert.ToInt32(DGV_Turnos.Rows[e.RowIndex].Cells["id_turno"].Value);
                string medico = DGV_Turnos.Rows[e.RowIndex].Cells["Medico"].Value.ToString();
                DateTime fecha = Convert.ToDateTime(DGV_Turnos.Rows[e.RowIndex].Cells["fecha_turno"].Value);
                TimeSpan hora = (TimeSpan)DGV_Turnos.Rows[e.RowIndex].Cells["hora_inicio"].Value;

                int idEspecialidad = Convert.ToInt32(CB_Especialidad.SelectedValue);

                using (Form_ConfirmarReserva formReserva = new Form_ConfirmarReserva(
                    idTurno,
                    medico,
                    fecha,
                    hora,
                    idEspecialidad,
                    turnoController,
                    pacienteController))
                {
                    formReserva.ShowDialog();
                }

                btn_Buscar.PerformClick();
            }

        }
    }
}
