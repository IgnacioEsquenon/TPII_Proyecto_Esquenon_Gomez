using MedoraAppLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MedoraApp
{
    public partial class UC_VerBloques : UserControl
    {
        private int _idMedicoActual; //Var para guardar el id del medico actual
        private TurnoController _turnoController;
        public UC_VerBloques(int idMedicoActual, TurnoController turnoController)
        {
            InitializeComponent();
            _idMedicoActual = idMedicoActual;
            _turnoController = turnoController; 
            dgvListaBloques.AutoGenerateColumns = false; // Asegura que no se generen columnas automáticamente
        }


        private void UC_VerBloques_Load(object sender, EventArgs e)
        {
            CargarBloques();
            
        }

        private void CargarBloques()
        {
            try
            {
                // Pide los datos al controlador, en lugar de ir a la BD directamente
                dgvListaBloques.DataSource = _turnoController.ListarBloquesMedico(_idMedicoActual);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los bloques: " + ex.Message);
            }
        }

        // El evento CellContentClick ahora maneja ambos botones
        private void dgvListaBloques_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignorar clics en la cabecera
            if (e.RowIndex < 0) return;

            // Si se hizo clic en el botón de Eliminar
            if (dgvListaBloques.Columns[e.ColumnIndex].Name == "colEliminar")
            {
                var confirmacion = MessageBox.Show(
                    "¿Está seguro de que desea eliminar este bloque horario?",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmacion == DialogResult.Yes)
                {
                    int idBloque = Convert.ToInt32(dgvListaBloques.Rows[e.RowIndex].Cells["colIdBloque"].Value);

                    // Llamamos al método del controlador que ya creamos
                    bool exito = _turnoController.EliminarBloqueHorario(idBloque);

                    if (exito)
                    {
                        MessageBox.Show("Bloque horario eliminado con éxito.", "Éxito");
                        CargarBloques(); // Recargamos la grilla para que se actualice
                    }
                }
            }
        }
    }
}
