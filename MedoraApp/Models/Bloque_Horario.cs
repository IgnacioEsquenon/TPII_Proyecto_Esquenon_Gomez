using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedoraApp.Models
{
    internal class Bloque_Horario
    {
        public int IdBloque { get; set; }           // Clave primaria compuesta con IdMedico
        public int IdMedico { get; set; }           // Clave foránea a Medico
        public DateTime FechaInicio { get; set; }   // Fecha de inicio del bloque
        public DateTime FechaFin { get; set; }      // Fecha de fin del bloque
        public TimeSpan HoraInicio { get; set; }    // Hora de inicio
        public TimeSpan HoraFin { get; set; }       // Hora de fin
        public int DuracionTurnos { get; set; }     // Duración de cada turno en minutos
        public int IdDia { get; set; }              // Clave foránea a Día
    }
}
