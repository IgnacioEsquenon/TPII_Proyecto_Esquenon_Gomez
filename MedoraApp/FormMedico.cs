
using System;
using System.Windows.Forms;

namespace MedoraApp
{
    public partial class FormMedico : Form
    {   
        private int _idMedicoActual; //Var para guardar el id del medico actual
        public FormMedico(int idMedico)
        {
            InitializeComponent();
            _idMedicoActual = idMedico; //Asignar el id del medico actual

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

        private void btnBloques_Click(object sender, EventArgs e)
        {
            MostrarControl(new UC_MenuBloques(_idMedicoActual));   
        }

        private void btnPerfil_Click(object sender, EventArgs e)
        {

            /*panelContenido.Visible = true;              
            panelContenido.Controls.Clear();

            UC_PerflMed uc = new UC_PerflMed();
            uc.Dock = DockStyle.Fill;


            panelContenido.Controls.Add(uc);*/

        }

        private void btnTurnos_Click(object sender, EventArgs e)
        {
            /*panelContenido.Visible = true;              
            panelContenido.Controls.Clear();

            UC_TurnosAg uc = new UC_TurnosAg();
            uc.Dock = DockStyle.Fill;

            panelContenido.Controls.Add(uc);*/
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            /*panelContenido.Visible = true;              
            panelContenido.Controls.Clear();

            UC_HistorialMed uc = new UC_HistorialMed();
            uc.Dock = DockStyle.Fill;

            panelContenido.Controls.Add(uc);*/
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            /*panelContenido.Visible = true;              
            panelContenido.Controls.Clear(); 

            UC_Reportes uc = new UC_Reportes();
            uc.Dock = DockStyle.Fill;

            panelContenido.Controls.Add(uc);*/
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
