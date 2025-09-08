using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedoraApp.Models
{
    internal class Turno
    {
        public int IdTurno { get; set; }           // Clave primaria compuesta con IdBloque y IdMedico
        public int IdBloque { get; set; }          // Clave foránea a BloqueHorario
        public int IdMedico { get; set; }          // Clave foránea a Medico
        public DateTime FechaTurno { get; set; }   // Fecha del turno
        public TimeSpan HoraInicio { get; set; }   // Hora de inicio
        public TimeSpan HoraFin { get; set; }      // Hora de fin
    }
}
