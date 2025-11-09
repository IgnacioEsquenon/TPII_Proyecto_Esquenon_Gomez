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
    public partial class UC_CrearMedico : UserControl
    {
        private EspecialidadesLDD especialidadesLDD;
        private UsuarioController usuarioController;
        private string connectionString;

        public UC_CrearMedico(string connString)
        {
            InitializeComponent();
            connectionString = connString;
            especialidadesLDD = new EspecialidadesLDD(connectionString);
            usuarioController = new UsuarioController(connectionString);
            CargarEspecialidades();

        }

        private void CargarEspecialidades()
        {
            try
            {
                var especialidades = especialidadesLDD.ObtenerEspecialidades();
                LB_Especialidad.DataSource = especialidades;
                LB_Especialidad.DisplayMember = "Nombre";
                LB_Especialidad.ValueMember = "id_especialidad";
                LB_Especialidad.SelectedIndex = -1; // No seleccionar ninguna por defecto
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar especialidades: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TB_NombreMed_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void TB_ApellidoMed_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void TB_TelefonoMed_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TB_DNIMed_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        } 

        private void LB_Especialidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true; // Evita que se pueda escribir en el ComboBox
        }

        private bool EmailValido(string email)
        {
            string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, patron);
        }

        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            // Validar campos vacíos
            if (string.IsNullOrWhiteSpace(TB_NombreMed.Text) ||
                string.IsNullOrWhiteSpace(TB_ApellidoMed.Text) ||
                string.IsNullOrWhiteSpace(TB_DNI_Med.Text) ||
                string.IsNullOrWhiteSpace(TB_EmailMed.Text) ||
                string.IsNullOrWhiteSpace(TB_TelefonoMed.Text) ||
                string.IsNullOrWhiteSpace(TB_PasswordMed.Text))
            {
                MessageBox.Show("Debe completar todos los campos obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que nombre y apellido no contengan números
            if (TB_NombreMed.Text.Any(char.IsDigit))
            {
                MessageBox.Show("El nombre no puede contener números.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (TB_ApellidoMed.Text.Any(char.IsDigit))
            {
                MessageBox.Show("El apellido no puede contener números.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que DNI y Teléfono sean numéricos
            if (!TB_DNI_Med.Text.All(char.IsDigit))
            {
                MessageBox.Show("El DNI debe contener solo números.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!TB_TelefonoMed.Text.All(char.IsDigit))
            {
                MessageBox.Show("El teléfono debe contener solo números.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar email
            if (!EmailValido(TB_EmailMed.Text))
            {
                MessageBox.Show("Ingrese un email válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar contraseña (máx. 15 caracteres)
            if (TB_PasswordMed.Text.Length == 0)
            {
                MessageBox.Show("Debe ingresar una contraseña.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (TB_PasswordMed.Text.Length > 15)
            {
                MessageBox.Show("La contraseña no puede superar los 15 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(LB_Especialidad.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una especialidad.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            Usuario nuevoMedico = new Usuario
            {
                Nombre = TB_NombreMed.Text.Trim(),
                Apellido = TB_ApellidoMed.Text.Trim(),
                Dni = TB_DNI_Med.Text.Trim(),
                Email = TB_EmailMed.Text.Trim(),
                Telefono = TB_TelefonoMed.Text.Trim(),
                ContraseñaHash = ContrasenaHelper.HashPassword(TB_PasswordMed.Text),
                Rol = Rol.Medico, 
                Especialidad = new Especialidad { id_especialidad = Convert.ToInt32(LB_Especialidad.SelectedValue) }
            };

            
            bool resultado = usuarioController.CrearUsuario(nuevoMedico);

            if (resultado)
            {
                MessageBox.Show("✅ Médico registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("❌ Error al registrar el médico. Verifique la conexión o los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            TB_NombreMed.Clear();
            TB_ApellidoMed.Clear();
            TB_DNI_Med.Clear();
            TB_EmailMed.Clear();
            TB_TelefonoMed.Clear();
            TB_PasswordMed.Clear();
            LB_Especialidad.SelectedIndex = -1;
        }

       
    }

    } 

