using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedoraApp.Models
{
    internal class Estado_Reserva
    {
        public int IdEstado { get; set; }     // Clave primaria
        public string Nombre { get; set; }    // Nombre del estado (Libre, Ocupado, Cancelado, Finalizado)
    }
}
