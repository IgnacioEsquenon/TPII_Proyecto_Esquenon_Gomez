using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedoraAppLibrary
{
    internal class Paciente
    {
        public int IdPaciente { get; set; }    
        public string Nombre { get; set; }    
        public string Apellido { get; set; }     
        public string Dni { get; set; }          
        public string Email { get; set; }        
        public string Telefono { get; set; }

        public Paciente(int id, string nombre, string apellido, string dni, string email, string telefono)
        {
            IdPaciente = id;
            Nombre = nombre;
            Apellido = apellido;
            Dni = dni;
            Email = email;
            Telefono = telefono;
        }

        public string NombreCompleto()
        {
            return $"{Nombre} {Apellido}";
        }

        public override string ToString()
        {
            return $"{IdPaciente} - {NombreCompleto()}";
        }
    }


}
