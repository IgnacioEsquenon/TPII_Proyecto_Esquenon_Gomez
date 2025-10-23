using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedoraAppLibrary
{
    public class Medico : Usuario
    {
        public Especialidad Especialidad_Medico { get; set; }

        // Constructor por defecto
        public Medico() { }

        // Constructor completo
        public Medico(int idUsuario, string nombre, string apellido, string dni, string email, string telefono, string contraseñaHash, Especialidad especialidad)
            : base(idUsuario, nombre, apellido, dni, email, contraseñaHash, Rol.Medico, telefono)
        {
            Especialidad_Medico = especialidad;
        }

        // Crear un bloque horario y generar turnos
        public void CrearBloqueConTurnos(BloqueHorario bloque, string connectionString)
        {
            // Asociar el bloque al médico
            bloque.IdUsuario = this.IdUsuario;

            // Guardar bloque en BD
            bloque.GuardarEnBD(connectionString);
        }
    }
}