using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedoraAppLibrary
{
    public class Especialidad
    {
     
        public int IdEspecialidad { get; set; }
        public string Nombre { get; set; }

       
        public Especialidad() { }

       
        public Especialidad(int id, string nombre)
        {
            IdEspecialidad = id;
            Nombre = nombre;
        }

        
        public override string ToString()
        {
            return $"{IdEspecialidad} - {Nombre}";
        }
    }
}
