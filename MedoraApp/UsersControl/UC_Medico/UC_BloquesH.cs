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
    public partial class UC_BloquesH : UserControl
    {

        public UC_BloquesH()
        {
            InitializeComponent();
        }

        public event EventHandler BtnAtrasClick;

        private void btnAtras_Click(object sender, EventArgs e)
        {
            //Disparar el evento 
            if (BtnAtrasClick != null)
            {
                BtnAtrasClick(this, EventArgs.Empty);
            }
        }
    }
}
