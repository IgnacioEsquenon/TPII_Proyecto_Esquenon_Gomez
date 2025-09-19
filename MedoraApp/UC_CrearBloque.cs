using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;
using MedoraAppLibrary;


namespace MedoraApp
{
    public partial class UC_CrearBloque : UserControl
    {
        public UC_CrearBloque()
        {
            InitializeComponent();
        }

        private void UC_CrearBloque_Load(object sender, EventArgs e)
        {
            CargarDias();
        }

        private void CargarDias()
        {
            string connectionString = @"Server=SEBAADMIN\SQLEXPRESS;Database=MedoraDB;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT id_dia, nombre FROM Día"; // id y nombre del día
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cmbDia.DataSource = dt;
                    cmbDia.DisplayMember = "nombre"; // lo que se muestra
                    cmbDia.ValueMember = "id_dia";   // el valor real que se usa en la BD
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los días: " + ex.Message);
                }
            }

        }

        private void GuardarBloque()
        {
            string connectionString = @"Server=SEBAADMIN\SQLEXPRESS;Database=MedoraDB;Trusted_Connection=True;";

            try
            {
                BloqueHorario bloque = new BloqueHorario
                {
                    FechaInicio = dtpFechaInicio.Value.Date,
                    FechaFin = dtpFechaFin.Value.Date,
                    HoraInicio = dtpHoraInicio.Value.TimeOfDay,   // 7:00 AM
                    HoraFin = dtpHoraFin.Value.TimeOfDay,      // 9:00 AM
                    DuracionTurnos = Convert.ToInt32(cmbDuracion.SelectedItem),  // Turnos de 30 minutos
                    IdUsuario = 5,                        // ID del médico en tabla Usuario
                    IdDia = Convert.ToInt32(cmbDia.SelectedValue)// 1=lunes, 2=martes...
                };

                // Guardar el bloque en la base de datos
                bloque.GuardarEnBD(connectionString);
                MessageBox.Show("Bloque guardado correctamente."); 

                // Generar y guardar turnos automáticamente
                bloque.GenerarYGuardarTurnos(connectionString);
                MessageBox.Show("✅ Turnos generados y guardados correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el bloque: " + ex.Message);
            }

        }

            
        private void btnCrear_Click(object sender, EventArgs e)
        {
            GuardarBloque();
        }
    }
}
