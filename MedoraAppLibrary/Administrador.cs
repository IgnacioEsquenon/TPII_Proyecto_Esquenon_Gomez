using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedoraAppLibrary
{
    public class Administrador : Usuario
    {
        // Constructor por defecto
        public Administrador() { }

        // Constructor completo
        public Administrador(int idUsuario, string nombre, string apellido, string dni, string email, string telefono, string contraseñaHash)
            : base(idUsuario, nombre, apellido, dni, email, contraseñaHash, Rol.Administrador, telefono)
        {
        }

    }
}
