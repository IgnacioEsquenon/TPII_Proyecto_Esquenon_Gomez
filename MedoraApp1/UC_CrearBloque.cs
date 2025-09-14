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

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = @"INSERT INTO Bloque_Horario
                             (fecha_inicio, fecha_fin, hora_inicio, hora_fin, duracion_turnos,id_usuario ,id_dia)
                             VALUES
                             (@fechaInicio, @fechaFin, @horaInicio, @horaFin, @duracion, @idUsuario ,@idDia)";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@fechaInicio", dtpFechaInicio.Value.Date);
                        cmd.Parameters.AddWithValue("@fechaFin", dtpFechaFin.Value.Date);
                        cmd.Parameters.AddWithValue("@horaInicio", dtpHoraInicio.Value.TimeOfDay);
                        cmd.Parameters.AddWithValue("@horaFin", dtpHoraFin.Value.TimeOfDay);
                        cmd.Parameters.AddWithValue("@duracion", Convert.ToInt32(cmbDuracion.SelectedItem));
                        cmd.Parameters.AddWithValue("@idUsuario", 5); // id fijo del médico por ahora
                        cmd.Parameters.AddWithValue("@idDia", Convert.ToInt32(cmbDia.SelectedValue));

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Bloque guardado correctamente.");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el bloque: " + ex.Message);
                }
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            GuardarBloque();
        }
    }
}

