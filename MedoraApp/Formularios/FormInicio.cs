using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminTurnosMedicos
{
    public partial class FormInicio : Form
    {
        public FormInicio()
        {
            InitializeComponent();
        }

        private void LTitulo_Click(object sender, EventArgs e)
        {

        }

        private void btnInicioMedico_Click(object sender, EventArgs e)
        {
            FormMedico ventana1 = new FormMedico();
            ventana1.FormClosed += (s, args) => this.Close();
            ventana1.Show();
            this.Hide();
        }

        private void btnInicioAdmin_Click(object sender, EventArgs e)
        {
            FormAdmin ventana2 = new FormAdmin();
            ventana2.FormClosed += (s, args) => this.Close();
            ventana2.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
