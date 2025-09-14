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

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormAdmin
            // 
            this.ClientSize = new System.Drawing.Size(647, 261);
            this.Name = "FormAdmin";
            this.ResumeLayout(false);

        }
    }
}
