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
                    string query = "SELECT * FROM Bloque_Horario";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvListaBloques.DataSource = dataTable;
                    dgvListaBloques.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    //dgvListaBloques.Columns["hora_inicio"].DefaultCellStyle.Format = "HH:mm";
                    //dgvListaBloques.Columns["hora_fin"].DefaultCellStyle.Format = "HH:mm";

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los bloques: " + ex.Message);
                }
            }
        }


    }
}
