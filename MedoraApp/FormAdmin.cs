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
        public FormAdmin()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FormInicio inicio = new FormInicio();
            inicio.Show();
            this.Hide(); // cierra el formulario actual
        }

        private void btnCrearMed_Click(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear();

            UC_CrearMedico uc = new UC_CrearMedico();
            uc.Dock = DockStyle.Fill;

            panelContenido.Controls.Add(uc);
        }

        private void btnCrearRecep_Click(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear();

            UC_CrearRecep uc = new UC_CrearRecep();
            uc.Dock = DockStyle.Fill;

            panelContenido.Controls.Add(uc);
        }
    }
}
