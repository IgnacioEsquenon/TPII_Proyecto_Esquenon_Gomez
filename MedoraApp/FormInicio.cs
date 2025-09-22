using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedoraApp
{
    public partial class FormInicio : Form
    {
        public FormInicio()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string usuario = TB_Usuario.Text.Trim();
            string contraseña = TB_Password.Text.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Ingrese usuario y contraseña.");
                return;
            }

            string connectionString = @"Server=SEBAADMIN\SQLEXPRESS;Database=MedoraDB;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT id_usuario, nombre, apellido, contraseña_hash, id_rol FROM Usuario WHERE (email = @usuario OR dni = @usuario) AND contraseña_hash = @contraseña";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@contraseña", contraseña); // contraseña tal cual está en BD

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        int rol = Convert.ToInt32(reader["id_rol"]);
                        MessageBox.Show("Inicio de sesión exitoso.");

                        // Redirige segun rol
                        if (rol == 1) // Admin
                        {
                            FormAdmin ventanaAdmin = new FormAdmin();
                            ventanaAdmin.FormClosed += (s, args) => this.Close();
                            ventanaAdmin.Show();
                        }
                        else if (rol == 2) // Médico
                        {
                            FormMedico ventanaMedico = new FormMedico();
                            ventanaMedico.FormClosed += (s, args) => this.Close();
                            ventanaMedico.Show();
                        }
                        else if (rol == 3) // Recepcionista
                        {
                            FormRecepcionista ventanaRecep = new FormRecepcionista();
                            ventanaRecep.FormClosed += (s, args) => this.Close();
                            ventanaRecep.Show();
                        }
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }




        /*private string CalcularContraHash(string texto)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(texto));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }*/
    }

}
