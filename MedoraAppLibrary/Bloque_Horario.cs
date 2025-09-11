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

        // Obtener todas las fechas del bloque que coinciden con el día de la semana
        public List<DateTime> ObtenerFechasDelBloque()
        {
            List<DateTime> fechas = new List<DateTime>();
            DayOfWeek diaSemana = (DayOfWeek)IdDia;

            for (DateTime fecha = FechaInicio; fecha <= FechaFin; fecha = fecha.AddDays(1))
            {
                if (fecha.DayOfWeek == diaSemana)
                    fechas.Add(fecha);
            }

            return fechas;
        }

        // Generar turnos automáticos según la duración
        public void GenerarYGuardarTurnos(string connectionString)
        {
            List<DateTime> fechas = ObtenerFechasDelBloque();

            foreach (var fecha in fechas)
            {
                TimeSpan horaActual = HoraInicio;

                while (horaActual + TimeSpan.FromMinutes(DuracionTurnos) <= HoraFin)
                {
                    Turno turno = new Turno(fecha, horaActual, horaActual + TimeSpan.FromMinutes(DuracionTurnos), this.IdBloque);
                    turno.GuardarEnBD(connectionString); // Persistencia delegada a Turno
                    horaActual += TimeSpan.FromMinutes(DuracionTurnos);
                }
            }
        }

        // Recibe la cadena de conexión desde el proyecto ejecutable
        public void GuardarEnBD(string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                    INSERT INTO Bloque_Horario
                        (fecha_inicio, fecha_fin, hora_inicio, hora_fin, duracion_turnos, id_usuario, id_dia)
                    VALUES
                        (@FechaInicio, @FechaFin, @HoraInicio, @HoraFin, @DuracionTurnos, @IdUsuario, @IdDia);
                    SELECT CAST(scope_identity() AS int)"; // Retorna el ID generado

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                    cmd.Parameters.AddWithValue("@FechaFin", FechaFin);
                    cmd.Parameters.AddWithValue("@HoraInicio", HoraInicio);
                    cmd.Parameters.AddWithValue("@HoraFin", HoraFin);
                    cmd.Parameters.AddWithValue("@DuracionTurnos", DuracionTurnos);
                    cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                    cmd.Parameters.AddWithValue("@IdDia", IdDia);

                    // Obtiene el IdBloque generado
                    IdBloque = (int)cmd.ExecuteScalar();
                }
            }
        }
    }
}