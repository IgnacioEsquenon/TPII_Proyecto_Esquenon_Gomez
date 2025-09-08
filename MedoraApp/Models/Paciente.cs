using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedoraApp.Models
{
    internal class Paciente
    {
        public int IdPaciente { get; set; }    
        public string Nombre { get; set; }    
        public string Apellido { get; set; }     
        public string Dni { get; set; }          
        public string Email { get; set; }        
        public string Telefono { get; set; }     
    }
}
