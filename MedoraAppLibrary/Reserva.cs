using System;
using System.Data.SqlClient;

namespace MedoraAppLibrary
{
    public class Reserva
    {
        public int IdReserva { get; set; }
        public string MotivoConsulta { get; set; }
        public int IdEstado { get; set; }
        public int IdTurno { get; set; }
        public int IdPaciente { get; set; }

        // Nuevos atributos útiles para mostrar en la vista
        public string EstadoReserva { get; set; }
        public DateTime FechaTurno { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }

        // Asociación al paciente
        public Paciente Paciente { get; set; }

        public Reserva() { }

        public Reserva(string motivoConsulta, int idEstado, int idTurno, int idPaciente)
        {
            MotivoConsulta = motivoConsulta;
            IdEstado = idEstado;
            IdTurno = idTurno;
            IdPaciente = idPaciente;
        }

        
        
    }
}
