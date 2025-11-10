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
    public partial class UC_RegistrarPaciente : UserControl
    {
        private PacienteController pacienteController;

        public UC_RegistrarPaciente(PacienteController controller)
        {
            InitializeComponent();
            pacienteController = controller;
        }

        private void UC_RegistrarPaciente_Load(object sender, EventArgs e)
        {
            CargarObrasSociales();
        }

        private void CargarObrasSociales()
        {
            try
            {
                DataTable dtObras = pacienteController.ObtenerObrasSociales();

                DataRow filaParticular = dtObras.NewRow();
                filaParticular["id_obra_social"] = 0;
                filaParticular["nombre"] = "Particular / Ninguna";
                dtObras.Rows.InsertAt(filaParticular, 0);

                CB_ObraSocial.DataSource = dtObras;
                CB_ObraSocial.DisplayMember = "nombre";
                CB_ObraSocial.ValueMember = "id_obra_social";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar obras sociales: " + ex.Message);
            }
        }


        private void TB_NombrePac_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void TB_ApellidoPac_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void TB_TelefonoPac_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TB_DNIPac_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TB_EdadPac_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void CB_ObraSocial_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true; // Evita que se pueda escribir en el ComboBox
        }

        private bool EmailValido(string email)
        {
            string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, patron);
        }

        private void LimpiarCampos()
        {
            // Vacía todos los campos de texto
            TB_NombrePac.Clear();
            TB_ApellidoPac.Clear();
            TB_DNIPac.Clear();
            TB_EmailPac.Clear();
            TB_TelefonoPac.Clear();

            // Reinicia el ComboBox a la primera opción
            if (CB_ObraSocial.Items.Count > 0)
            {
                CB_ObraSocial.SelectedIndex = 0;
            }

            // Opcional: Pone el cursor en el primer campo para un nuevo registro
            TB_NombrePac.Focus();
        }

        private void btnCrearPac_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TB_NombrePac.Text) ||
                string.IsNullOrWhiteSpace(TB_ApellidoPac.Text) ||
                string.IsNullOrWhiteSpace(TB_DNIPac.Text) ||
                string.IsNullOrWhiteSpace(TB_TelefonoPac.Text) ||
                CB_ObraSocial.SelectedValue == null)
            {
                MessageBox.Show("Debe completar Nombre, Apellido, DNI, Teléfono y Obra Social.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (TB_NombrePac.Text.Any(char.IsDigit))
            {
                MessageBox.Show("El nombre no puede contener números.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (TB_ApellidoPac.Text.Any(char.IsDigit))
            {
                MessageBox.Show("El apellido no puede contener números.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar Fecha de Nacimiento 
            if (dtpFechaNacimiento.Value.Date > DateTime.Now.Date)
            {
                MessageBox.Show("La fecha de nacimiento no puede ser en el futuro.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar email (opcional, si se ingresó uno)
            if (!string.IsNullOrWhiteSpace(TB_EmailPac.Text) && !EmailValido(TB_EmailPac.Text))
            {
                MessageBox.Show("El formato del email no es válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que DNI y Teléfono sean numéricos 
            if (!TB_DNIPac.Text.All(char.IsDigit))
            {
                MessageBox.Show("El DNI debe contener solo números.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!TB_TelefonoPac.Text.All(char.IsDigit))
            {
                MessageBox.Show("El teléfono debe contener solo números.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (pacienteController.ExistePaciente(TB_DNIPac.Text.Trim(), TB_EmailPac.Text.Trim()))
            {
                MessageBox.Show("El DNI o el Email ya se encuentran registrados.", "Paciente Duplicado");
                return;
            }

            // --- 2. CREACIÓN DEL OBJETO PACIENTE ---
            Paciente nuevoPaciente = new Paciente
            {
                Nombre = TB_NombrePac.Text.Trim(),
                Apellido = TB_ApellidoPac.Text.Trim(),
                Dni = TB_DNIPac.Text.Trim(),
                Email = string.IsNullOrWhiteSpace(TB_EmailPac.Text) ? null : TB_EmailPac.Text.Trim(),
                Telefono = TB_TelefonoPac.Text.Trim(),
                FechaNacimiento = dtpFechaNacimiento.Value.Date, // <-- Lee del DateTimePicker
                IdObraSocial = (CB_ObraSocial.SelectedValue != null && (int)CB_ObraSocial.SelectedValue > 0)
                               ? (int?)CB_ObraSocial.SelectedValue
                               : null
            };

            // --- 3. INSERCIÓN EN LA BASE DE DATOS ---
            bool resultado = pacienteController.RegistrarPaciente(nuevoPaciente); // Llama al método correcto

            // --- 4. Verificación del Resultado ---
            if (resultado)
            {
                MessageBox.Show("✅ Paciente registrado correctamente.", "Éxito");
                LimpiarCampos();
            }
            // Si 'resultado' es false, el controlador ya se encargó de mostrar el mensaje de error.
        }
    }
}
