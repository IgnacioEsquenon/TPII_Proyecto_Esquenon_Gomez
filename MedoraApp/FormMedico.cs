

using System;
using System.Windows.Forms;

namespace MedoraApp
{
    public partial class FormMedico : Form
    {
        public FormMedico()
        {
            InitializeComponent();

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FormInicio inicio = new FormInicio();
            inicio.Show();
            this.Hide(); // cierra el formulario actual
        }

        private void btnBloques_Click(object sender, EventArgs e)
        {

            panelContenido.Controls.Clear();

            UC_MenuBloques uc = new UC_MenuBloques();
            uc.Dock = DockStyle.Fill;



            panelContenido.Controls.Add(uc);
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

        
    }
}
