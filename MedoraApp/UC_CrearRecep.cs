using MedoraAppLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedoraApp
{
    public partial class UC_CrearRecep : UserControl
    {
        private UsuarioController usuarioController;

        public UC_CrearRecep(string connString)
        {
            InitializeComponent();
            usuarioController = new UsuarioController(connString);
        }

        private void TB_NombreRec_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        } 

        private void TB_ApellidoRec_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void TB_TelefonoRec_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TB_DNIRec_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private bool EmailValido(string email)
        {
            string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, patron);
        }

        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            // Validar campos vacíos
            if (string.IsNullOrWhiteSpace(TB_NombreRec.Text) ||
                string.IsNullOrWhiteSpace(TB_ApellidoRec.Text) ||
                string.IsNullOrWhiteSpace(TB_DNIRec.Text) ||
                string.IsNullOrWhiteSpace(TB_EmailRec.Text) ||
                string.IsNullOrWhiteSpace(TB_TelefonoRec.Text) ||
                string.IsNullOrWhiteSpace(TB_PasswordRec.Text))
            {
                MessageBox.Show("Debe completar todos los campos obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que nombre y apellido no contengan números
            if (TB_NombreRec.Text.Any(char.IsDigit))
            {
                MessageBox.Show("El nombre no puede contener números.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (TB_ApellidoRec.Text.Any(char.IsDigit))
            {
                MessageBox.Show("El apellido no puede contener números.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que DNI y Teléfono sean numéricos
            if (!TB_DNIRec.Text.All(char.IsDigit))
            {
                MessageBox.Show("El DNI debe contener solo números.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!TB_TelefonoRec.Text.All(char.IsDigit))
            {
                MessageBox.Show("El teléfono debe contener solo números.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar email
            if (!EmailValido(TB_EmailRec.Text))
            {
                MessageBox.Show("Ingrese un email válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar contraseña (máx. 15 caracteres)
            if (TB_PasswordRec.Text.Length == 0)
            {
                MessageBox.Show("Debe ingresar una contraseña.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (TB_PasswordRec.Text.Length > 15)
            {
                MessageBox.Show("La contraseña no puede superar los 15 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Usuario nuevoRecepcionista = new Usuario
            {
                Nombre = TB_NombreRec.Text.Trim(),
                Apellido = TB_ApellidoRec.Text.Trim(),
                Dni = TB_DNIRec.Text.Trim(),
                Email = TB_EmailRec.Text.Trim(),
                Telefono = TB_TelefonoRec.Text.Trim(),
                ContraseñaHash = TB_PasswordRec.Text, //Dsp encriptar
                Rol = Rol.Recepcionista,
                Especialidad = null // Un recepcionista no tiene especialidad
            };

            try
            {
                //Llama al método del controlador para guardar en la BD
                bool resultado = usuarioController.CrearUsuario(nuevoRecepcionista);

                //Maneja el resultado de la operación
                if (resultado)
                {
                    MessageBox.Show("✅ Recepcionista registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos(); 
                }
                else
                {
                    MessageBox.Show("❌ Error al registrar el recepcionista. Verifique la conexión o los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LimpiarCampos()
        {
            TB_NombreRec.Clear();
            TB_ApellidoRec.Clear();
            TB_DNIRec.Clear();
            TB_EmailRec.Clear();
            TB_TelefonoRec.Clear();
            TB_PasswordRec.Clear();
        }

    }
 }

