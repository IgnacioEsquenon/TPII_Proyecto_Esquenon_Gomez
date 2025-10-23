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
        public UC_VerBloques(int idMedicoActual)
        {
            InitializeComponent();
            _idMedicoActual = idMedicoActual;
        }


        private void UC_VerBloques_Load(object sender, EventArgs e)
        {

            CargarBloques();
            AgregarBotones();
        }

        private void CargarBloques()
        {
            //Conexión a la base de datos
            string connectionString = ConfigurationManager
                            .ConnectionStrings["MedoraDB"]
                            .ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Bloque_Horario WHERE id_usuario = @idMedico ORDER BY fecha_inicio ASC";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@idMedico", _idMedicoActual);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvListaBloques.DataSource = dataTable;
                    dgvListaBloques.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    //dgvListaBloques.Columns["hora_inicio"].DefaultCellStyle.Format = "HH:mm";
                    //dgvListaBloques.Columns["hora_fin"].DefaultCellStyle.Format = "HH:mm";

                    
                    string[] columnasOcultas = { "id_bloque", "duracion_turnos", "id_usuario", "id_dia" };

                    foreach (string col in columnasOcultas)
                    {
                        if (dgvListaBloques.Columns.Contains(col))
                            dgvListaBloques.Columns[col].Visible = false;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los bloques: " + ex.Message);
                }
            }
        }

        private void AgregarBotones()
        {
            // Evita agregar los botones dos veces
            if (dgvListaBloques.Columns.Contains("btnModificar")) return;

            // Botón Modificar
            DataGridViewButtonColumn btnModificar = new DataGridViewButtonColumn();
            btnModificar.Name = "btnModificar";
            btnModificar.HeaderText = "Acciones";
            btnModificar.Text = "Modificar";
            btnModificar.UseColumnTextForButtonValue = true;
            btnModificar.DefaultCellStyle.BackColor = Color.Orange;
            btnModificar.DefaultCellStyle.ForeColor = Color.DarkBlue;
            btnModificar.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
            btnModificar.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvListaBloques.Columns.Add(btnModificar);
 
            // Botón Eliminar
            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
            btnEliminar.Name = "btnEliminar";
            btnEliminar.HeaderText = "";
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseColumnTextForButtonValue = true;
            btnEliminar.DefaultCellStyle.BackColor = Color.LightCoral;
            btnEliminar.DefaultCellStyle.ForeColor = Color.White;
            btnEliminar.DefaultCellStyle.SelectionBackColor = Color.Red;
            btnEliminar.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvListaBloques.Columns.Add(btnEliminar);
        }
    }
}
