using System;
using MedoraAppLibrary;

namespace MedoraAppLibrary
{
    // Atributos 
    public int IdUsuario { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Dni { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefono { get; set; }  
    public string ContraseñaHash { get; set; } = string.Empty;
    public Rol Rol { get; set; }   
    public Especialidad Especialidad { get; set; } 
    public bool Estado { get; set; } = true; // true = activo, false = inactivo

        // Constructores
        public Usuario() { }

    public Usuario(int idUsuario, string nombre, string apellido, string dni, string email, string contraseñaHash, Rol rol, Especialidad especialidad, string telefono, bool estado)
    {
        IdUsuario = idUsuario;
        Nombre = nombre;
        Apellido = apellido;
        Dni = dni;
        Email = email;
        Telefono = telefono;
        ContraseñaHash = contraseñaHash;
        Rol = rol;
        Especialidad = especialidad;
        Estado = estado;
    }

        // Métodos básicos

        /// Devuelve el nombre completo del usuario.
        public string NombreCompleto()
        {
            return $"{Nombre} {Apellido}";
        }

        /// Determina si el usuario es médico.
        public bool EsMedico()
        {
            return Rol_Usuario == Rol.Medico;
        }


        /// Determina si el usuario es recepcionista.
        public bool EsRecepcionista()
        {
            return Rol_Usuario == Rol.Recepcionista;
        }


        /// Determina si el usuario es administrador.
        public bool EsAdministrador()
        {
            return Rol_Usuario == Rol.Administrador;
        }

        public override string ToString()
        {
            return $"[{IdUsuario}] {NombreCompleto()} - Rol: {Rol_Usuario}";
        }
    }
}