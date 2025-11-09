using MedoraAppLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
        private UsuarioController _usuarioController;
        public FormInicio()
        {
            InitializeComponent();
            string connString = ConfigurationManager.ConnectionStrings["MedoraDB"].ConnectionString;
            _usuarioController = new UsuarioController(connString);
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

            try
            {
                
                Usuario usuarioValidado = _usuarioController.ValidarYObtenerUsuario(usuario, contraseña);
                if (usuarioValidado != null)
                {
                    
                    MessageBox.Show($"¡Bienvenido, {usuarioValidado.Nombre}!", "Inicio de sesión exitoso");

                    int rol = (int)usuarioValidado.Rol;
                    int idMedicoLogeado = usuarioValidado.IdUsuario;

                    
                    if (rol == 1) // Admin
                    {
                        FormAdmin ventanaAdmin = new FormAdmin();
                        ventanaAdmin.FormClosed += (s, args) => this.Close();
                        ventanaAdmin.Show();
                    }
                    else if (rol == 2) // Médico
                    {
                        FormMedico ventanaMedico = new FormMedico(idMedicoLogeado);
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
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message);
            }
        }

    }

}
