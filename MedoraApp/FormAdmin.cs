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

    public partial class FormAdmin : Form
    {
        string connectionString = System.Configuration.ConfigurationManager
                                     .ConnectionStrings["MedoraDB"]
                                     .ConnectionString;
       
        private TurnoController _turnoController;
        private EstadisticasController _estadisticasController;
        public FormAdmin()
        {
            InitializeComponent();
            _turnoController = new TurnoController(connectionString);
            _estadisticasController = new EstadisticasController(connectionString);
        }

        private void MostrarControl(UserControl controlAMostrar)
        {
            
            panelContenido.Controls.Clear();

            int nuevoAnchoCliente = panel1.Width + controlAMostrar.Width;
            int nuevoAltoCliente = controlAMostrar.Height;

            this.ClientSize = new System.Drawing.Size(nuevoAnchoCliente, nuevoAltoCliente);

            this.StartPosition = FormStartPosition.CenterScreen;

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

        private void btnRealizarBackup_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Archivos de Backup (*.bak)|*.bak";
            saveDialog.Title = "Guardar Backup Completo de la Base de Datos";
            saveDialog.FileName = $"MedoraDB_Backup_{DateTime.Now:yyyyMMdd_HHmm}.bak";

            
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                
                string rutaElegidaPorUsuario = saveDialog.FileName;

                
                this.Cursor = Cursors.WaitCursor;

                bool exito = _turnoController.RealizarBackupCompleto(rutaElegidaPorUsuario);

                this.Cursor = Cursors.Default;

                if (exito)
                {
                    MessageBox.Show("¡Backup completo realizado con éxito!\n\nArchivo guardado en:\n" + rutaElegidaPorUsuario,
                                    "Backup Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            MostrarControl(new UC_AdminDashboard(_estadisticasController));
        }
    }
}
