using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedoraAppLibrary
{
    public class Especialidad
    {
     
        public int id_especialidad { get; set; }
        public string Nombre { get; set; }

       
        public Especialidad() { }

       
        public Especialidad(int id, string nombre)
        {
            id_especialidad = id;
            Nombre = nombre;
        }

        
        public override string ToString()
        {
            return $"{id_especialidad} - {Nombre}";
        }
    }
}
