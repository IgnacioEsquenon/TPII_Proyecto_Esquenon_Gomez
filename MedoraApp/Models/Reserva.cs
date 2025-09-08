using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedoraApp.Models
{
    internal class Reserva
    {
        public int IdTurno { get; set; }           // Referencia al turno
        public int IdBloque { get; set; }          // Referencia al bloque
        public int IdMedico { get; set; }          // Referencia al médico (Clave compuesta triple)
        public string MotivoConsulta { get; set; }  // Motivo de la consulta
        public int IdEstado { get; set; }          // Referencia al estado de la reserva
        public int IdPaciente { get; set; }        // Referencia al paciente
    }
}
