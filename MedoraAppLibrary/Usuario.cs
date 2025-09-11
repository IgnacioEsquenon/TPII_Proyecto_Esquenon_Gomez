using System;
using MedoraAppLibrary;

public class Usuario
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

    // Constructores
    public Usuario() { }

    public Usuario(int idUsuario, string nombre, string apellido, string dni, string email, string contraseñaHash, Rol rol, Especialidad especialidad, string telefono)
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
    }

    // Métodos básicos

    
    /// Devuelve el nombre completo del usuario.

    public string NombreCompleto()
    {
        return $"{Nombre} {Apellido}";
    }

    /// Verifica si el usuario es médico.

    public bool EsMedico()
    {
        return Rol == Rol.Medico;
    }


    public override string ToString()
    {
        return $"[{IdUsuario}] {NombreCompleto()} - Rol: {Rol}" +
               (EsMedico() && Especialidad != null ? $" (Especialidad: {Especialidad.Nombre})" : "");
    }
}
