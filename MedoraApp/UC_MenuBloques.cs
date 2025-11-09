using MedoraAppLibrary;
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
        private TurnoController _turnoController;

        public UC_MenuBloques(int idMedico, TurnoController controller)
        {
            InitializeComponent();
            _idMedicoActual = idMedico; //Asignar el id del medico actual desde FormMedico
            _turnoController = controller;
            btnVerBloques.PerformClick(); // Simula el clic en "Ver Bloques" al cargar el UserControl
            
        }

        private void btnVerBloques_Click(object sender, EventArgs e)
        {
            p_Contenido_Bloq.Controls.Clear();
            UC_VerBloques uc = new UC_VerBloques(_idMedicoActual, _turnoController);
            uc.Dock = DockStyle.Fill;
            p_Contenido_Bloq.Controls.Add(uc);
        }

        private void btnCrearBloq_Click(object sender, EventArgs e)
        {
            p_Contenido_Bloq.Controls.Clear();
            UC_CrearBloque uc = new UC_CrearBloque(_idMedicoActual, _turnoController);
            uc.Dock = DockStyle.Fill;
            p_Contenido_Bloq.Controls.Add(uc);
        }
    }


}