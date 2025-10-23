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
    public partial class UC_MenuBloques : UserControl
    {
        private int _idMedicoActual; //Var para guardar el id del medico actual
        public UC_MenuBloques(int idMedico)
        {
            InitializeComponent();
            _idMedicoActual = idMedico; //Asignar el id del medico actual desde FormMedico
            btnVerBloques.PerformClick(); // Simula el clic en "Ver Bloques" al cargar el UserControl
        }

        private void btnVerBloques_Click(object sender, EventArgs e)
        {
            p_Contenido_Bloq.Controls.Clear();
            UC_VerBloques uc = new UC_VerBloques(_idMedicoActual);
            uc.Dock = DockStyle.Fill;
            p_Contenido_Bloq.Controls.Add(uc);
        }

        private void btnCrearBloq_Click(object sender, EventArgs e)
        {
            p_Contenido_Bloq.Controls.Clear();
            UC_CrearBloque uc = new UC_CrearBloque(_idMedicoActual);
            uc.Dock = DockStyle.Fill;
            p_Contenido_Bloq.Controls.Add(uc);
        }
    }


}