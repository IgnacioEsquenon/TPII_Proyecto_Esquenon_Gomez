using AdminTurnosMedicos.UsersControl.UC_Medico;

namespace AdminTurnosMedicos
{
    public partial class FormMedico : Form
    {
        public FormMedico()
        {
            InitializeComponent();

        }

        //Efecto hover de iconos (visual nomas)
        



        private void btnVolver_Click(object sender, EventArgs e)
        {
            FormInicio inicio = new FormInicio();
            inicio.Show();
            this.Hide(); // cierra el formulario actual
        }

        private void btnBloques_Click(object sender, EventArgs e)
        {

            panelContenido.Controls.Clear();

            UC_BloquesH uc = new UC_BloquesH();
            uc.Dock = DockStyle.Fill;

            // Me suscribo al evento del UC
            uc.BtnAtrasClick += (s, ev) =>
            {
                panel1.Visible = true;       // muestro el men�
                panelContenido.Controls.Clear();  // limpio el UC
            };

            panelContenido.Controls.Add(uc);
        }

        private void btnPerfil_Click(object sender, EventArgs e)
        {

            panelContenido.Visible = true;              // El men� sigue visible
            panelContenido.Controls.Clear();

            UC_PerflMed uc = new UC_PerflMed();
            uc.Dock = DockStyle.Fill;


            panelContenido.Controls.Add(uc);

        }

        private void btnTurnos_Click(object sender, EventArgs e)
        {
            panelContenido.Visible = true;              // El men� sigue visible
            panelContenido.Controls.Clear();

            UC_TurnosAg uc = new UC_TurnosAg();
            uc.Dock = DockStyle.Fill;

            panelContenido.Controls.Add(uc);
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            panelContenido.Visible = true;              // El men� sigue visible
            panelContenido.Controls.Clear();

            UC_HistorialMed uc = new UC_HistorialMed();
            uc.Dock = DockStyle.Fill;

            panelContenido.Controls.Add(uc);
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            panelContenido.Visible = true;              // El men� sigue visible
            panelContenido.Controls.Clear(); 

            UC_Reportes uc = new UC_Reportes();
            uc.Dock = DockStyle.Fill;

            panelContenido.Controls.Add(uc);
        }
    }
}
