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


namespace MedoraApp
{
    public partial class UC_VerBloques : UserControl
    {
        public UC_VerBloques()
        {
            InitializeComponent();
        }


        private void UC_VerBloques_Load(object sender, EventArgs e)
        {

            CargarBloques();
            AgregarBotones();
        }

        private void CargarBloques()
        {
            //Conexión a la base de datos
            string connectionString = @"Server=SEBAADMIN\SQLEXPRESS;Database=MedoraDB;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Bloque_Horario ORDER BY fecha_inicio ASC";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
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
