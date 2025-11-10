using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedoraAppLibrary
{
    public class Paciente
    {
        public int IdPaciente { get; set; }    
        public string Nombre { get; set; }    
        public string Apellido { get; set; }     
        public string Dni { get; set; }          
        public string Email { get; set; }        
        public string Telefono { get; set; }

        public DateTime FechaNacimiento { get; set; } 

        // Se usa 'int?' para permitir que un paciente no tenga obra social (valor NULL)
        public int? IdObraSocial { get; set; }

        public Paciente() { }

        public Paciente(int id, string nombre, string apellido, string dni, string email, string telefono, DateTime fechaNacimiento, int? id_obra_social )
        {
            IdPaciente = id;
            Nombre = nombre;
            Apellido = apellido;
            Dni = dni;
            Email = email;
            Telefono = telefono;
            this.FechaNacimiento = fechaNacimiento;
            this.IdObraSocial = id_obra_social;
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
