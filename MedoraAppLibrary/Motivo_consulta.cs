using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedoraAppLibrary
{
    public class MotivoConsulta
    {
        public int IdMotivoConsulta { get; set; }
        public string Descripcion { get; set; }
        public int IdEspecialidad { get; set; }

        // Constructor vacío
        public MotivoConsulta() { }
    }
}
