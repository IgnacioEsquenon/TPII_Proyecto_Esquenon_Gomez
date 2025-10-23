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
    public partial class UC_GestionUsuarios : UserControl
    {
        private UsuarioController usuarioController;
        private EspecialidadesLDD especialidadesLDD;
        private DataTable dtmUsuarios; //Tabla "Master" de usuarios

        public UC_GestionUsuarios(string connectionString)
        {
            InitializeComponent();
            ConfigurarDGV();
            usuarioController = new UsuarioController(connectionString);
            especialidadesLDD = new EspecialidadesLDD(connectionString);
            CargarRoles();
            CargarUsuarios();
            CargarEstados();
        }

        private void ConfigurarDGV()
        {

            DGV_Usuarios.AutoGenerateColumns = false;
        }

        private void CargarUsuarios()
        {
            try
            {
                // Llamamos a la BD para obtener TODOS los usuarios (activos e inactivos)
                // y los guardamos en la tabla master.
                dtmUsuarios = usuarioController.ObtenerTodosLosUsuarios(EstadoUsuarioFiltro.Todos);

                // Asigno la tabla master como fuente de datos del DGV por unica vez. 
                // Ahora los filtros se aplicaran sobre esta tabla.
                DGV_Usuarios.DataSource = dtmUsuarios;
                DGV_Usuarios.Columns["id_usuario"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message);
            }

        }

        private void CargarEstados()
        {
            CB_Estados.Items.Clear(); // Limpiamos por si acaso
            CB_Estados.Items.Add("Todos");
            CB_Estados.Items.Add("Activos");
            CB_Estados.Items.Add("Inactivos");
            CB_Estados.SelectedIndex = 1; // <-- Lo dejamos en "Activos" por defecto
        }

        private void CargarRoles()
        {
            // Añade una opción para ver todos los roles
            CB_Roles.Items.Add("Todos");

            // Carga los roles de la enumeración
            foreach (var rol in Enum.GetValues(typeof(Rol)))
            {
                CB_Roles.Items.Add(rol.ToString());
            }

            CB_Roles.SelectedIndex = 0; // Selecciona "Todos" por defecto
        }

        private void CargarEspecialidades()
        {
            try
            {
                // Obtiene la lista de especialidades de la base de datos.
                var especialidades = especialidadesLDD.ObtenerEspecialidades();

                // Se inserta un valor predeterminado al inicio de la lista.
                // Esto evita que SelectedValue sea null.
                var listaVacia = new List<Especialidad> { new Especialidad { id_especialidad = 0, Nombre = "Seleccionar Especialidad" } };
                listaVacia.AddRange(especialidades);

                // Enlaza la lista modificada al ComboBox.
                CB_Especialidades.DataSource = listaVacia;
                CB_Especialidades.DisplayMember = "Nombre";
                CB_Especialidades.ValueMember = "id_especialidad";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar especialidades: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AplicarFiltros()
        {
            if (dtmUsuarios == null) return; 

            DataView dv = dtmUsuarios.DefaultView;
            var filtros = new List<string>();

            // --- Filtro por Rol ---
            string rolSeleccionado = CB_Roles.SelectedItem.ToString();

            if (rolSeleccionado != "Todos")
            {
                filtros.Add($"nombre_rol = '{rolSeleccionado}'");
            }

            // --- Filtro por Especialidad (corregido) ---
            // Solo aplica si el rol es Médico y el ComboBox de especialidades está visible.
            if (rolSeleccionado == "Medico" && CB_Especialidades.SelectedItem != null)
            {
                // 1. Obtenemos el objeto 'Especialidad' completo del ComboBox.
                Especialidad especialidadSeleccionada = (Especialidad)CB_Especialidades.SelectedItem;

                // 2. Ahora, accedemos a su ID de forma segura y lo comprobamos.
                if (especialidadSeleccionada.id_especialidad > 0) // > 0 para ignorar "Seleccionar Especialidad"
                {
                    filtros.Add($"id_especialidad = {especialidadSeleccionada.id_especialidad}");
                }
            }

            // --- AQUÍ PODÉS AGREGAR EL FILTRO DE ESTADO (Activo/Inactivo) ---
            // Por ejemplo, si tuvieras un ComboBox llamado CB_Estado:

            if (CB_Estados.SelectedItem != null)
            {
                string estadoSeleccionado = CB_Estados.SelectedItem.ToString();

                if (estadoSeleccionado == "Activos")
                {
                    // La columna en tu DataTable se llama 'estado_usuario' y 1 es activo
                    filtros.Add("estado_usuario = 1");
                }
                else if (estadoSeleccionado == "Inactivos")
                {
                    filtros.Add("estado_usuario = 0");
                }
                // Si es "Todos", simplemente no agregamos ningún filtro de estado.
            }

            // Unimos todos los filtros con "AND"
            dv.RowFilter = string.Join(" AND ", filtros);
            DGV_Usuarios.DataSource = dv;
            DGV_Usuarios.Columns["id_usuario"].Visible = false;
        }

        private void CB_Roles_SelectedIndexChanged(object sender, EventArgs e)
        {
            string rolSeleccionado = CB_Roles.SelectedItem.ToString();

            // Lógica para mostrar/ocultar el ComboBox de especialidades
            bool esMedico = rolSeleccionado == "Medico";
            lb_Especialidad.Visible = esMedico;
            CB_Especialidades.Visible = esMedico;

            if (esMedico && CB_Especialidades.DataSource == null)
            {
                CargarEspecialidades();
            }

            // Llamo a la funcion principal de aplicacion de filtros :)
            AplicarFiltros();
        }

        private void CB_Especialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void CB_Estados_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void DGV_Usuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Obtiene el ID del usuario de la fila seleccionada.
            int usuarioId = (int)DGV_Usuarios.Rows[e.RowIndex].Cells["id_usuario"].Value;

            // Si la columna que se hizo clic es la de eliminar
            if (DGV_Usuarios.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                // Pide confirmación al usuario antes de eliminar.
                DialogResult confirmacion = MessageBox.Show(
                    "¿Estás seguro de que quieres eliminar este usuario?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmacion == DialogResult.Yes)
                {
                    bool eliminado = this.usuarioController.EliminarUsuario(usuarioId);

                    if (eliminado)
                    {
                        MessageBox.Show("Usuario eliminado exitosamente.");
                        CargarUsuarios();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el usuario.");
                    }
                }
            }
        }

        private void DGV_Usuarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.DGV_Usuarios.Columns[e.ColumnIndex].Name == "Estado")
            {
                // Me aseguro de que el valor no sea nulo
                if (e.Value != null)
                {
                    bool esActivo = false;
                    // Intento convertir el valor a booleano. Esto funciona para 1/0, "True"/"False", etc.
                    if (bool.TryParse(e.Value.ToString(), out esActivo) || (e.Value is int && (int)e.Value == 1))
                    {
                        if (Convert.ToBoolean(e.Value)) // Si es True o 1
                        {
                            e.Value = "Activo";
                            e.CellStyle.ForeColor = Color.Green; 
                            e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold); 
                        }
                        else // Si es False o 0
                        {
                            e.Value = "Inactivo";
                            e.CellStyle.ForeColor = Color.Red; 
                        }
                    }
                }
            }
        }
    }
}