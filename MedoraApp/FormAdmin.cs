using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedoraApp
{
    public partial class FormAdmin : Form
    {
        string connectionString = System.Configuration.ConfigurationManager
                                     .ConnectionStrings["MedoraDB"]
                                     .ConnectionString;
        public FormAdmin()
        {
            InitializeComponent();
        }

        private void MostrarControl(UserControl controlAMostrar)
        {
            // Limpiamos el panel de contenido
            panelContenido.Controls.Clear();

            // Calculamos el nuevo tamaño que necesita el área visible del formulario.
            // Ancho = Ancho del menú + Ancho del nuevo control + un pequeño margen
            // Alto = Alto del nuevo control
            int nuevoAnchoCliente = panel1.Width + controlAMostrar.Width;
            int nuevoAltoCliente = controlAMostrar.Height;

            // Asignamos este nuevo tamaño al ClientSize del formulario.
            // El formulario se redimensionará automáticamente, y gracias al ANCHOR,
            // los paneles se ajustarán solos de forma perfecta.
            this.ClientSize = new System.Drawing.Size(nuevoAnchoCliente, nuevoAltoCliente);

            // Centramos la ventana en la pantalla para un efecto profesional.
            this.StartPosition = FormStartPosition.CenterScreen;

            // Añadimos el nuevo control al panel de contenido.
            controlAMostrar.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(controlAMostrar);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FormInicio inicio = new FormInicio();
            inicio.Show();
            this.Hide(); // cierra el formulario actual
        }

        private void btnCrearMed_Click(object sender, EventArgs e)
        {
            MostrarControl(new UC_CrearMedico(connectionString));
        }

        private void btnCrearRecep_Click(object sender, EventArgs e)
        {
            MostrarControl(new UC_CrearRecep(connectionString));
        }

        private void btnVerUsuarios_Click(object sender, EventArgs e)
        {
            MostrarControl(new UC_GestionUsuarios(connectionString));
        }
    }
}
