using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MedoraAppLibrary
{
    public class BloqueHorario
    {
       
        public int IdBloque { get; set; }         
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public int DuracionTurnos { get; set; }
        public bool Activo { get; set; }
        public int IdUsuario { get; set; }        
        public int IdDia { get; set; }           

        
        public BloqueHorario() { }

        public BloqueHorario(DateTime fechaInicio, DateTime fechaFin,
                             TimeSpan horaInicio, TimeSpan horaFin, int duracionTurnos,
                             int idUsuario, int idDia)
        {
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            HoraInicio = horaInicio;
            HoraFin = horaFin;
            DuracionTurnos = duracionTurnos;
            IdUsuario = idUsuario;
            IdDia = idDia;
        }

        public void GuardarEnBD(string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                INSERT INTO Bloque_Horario
                    (fecha_inicio, fecha_fin, hora_inicio, hora_fin, duracion_turnos, id_medico, id_dia)
                VALUES
                    (@FechaInicio, @FechaFin, @HoraInicio, @HoraFin, @DuracionTurnos, @IdUsuario, @IdDia);
                SELECT CAST(scope_identity() AS int);";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                    cmd.Parameters.AddWithValue("@FechaFin", FechaFin);
                    cmd.Parameters.AddWithValue("@HoraInicio", HoraInicio);
                    cmd.Parameters.AddWithValue("@HoraFin", HoraFin);
                    cmd.Parameters.AddWithValue("@DuracionTurnos", DuracionTurnos);
                    cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                    cmd.Parameters.AddWithValue("@IdDia", IdDia);

                    IdBloque = (int)cmd.ExecuteScalar();
                }
            }
        }
    }
}