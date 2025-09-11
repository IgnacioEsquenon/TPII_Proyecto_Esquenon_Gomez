using System;
using System.Data.SqlClient;

namespace MedoraAppLibrary
{
    public class Turno
    {
        public int IdTurno { get; set; }           // Autoincremental en la BD
        public DateTime FechaTurno { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public int IdBloque { get; set; }

        public Turno() { }

        public Turno(DateTime fechaTurno, TimeSpan horaInicio, TimeSpan horaFin, int idBloque)
        {
            FechaTurno = fechaTurno;
            HoraInicio = horaInicio;
            HoraFin = horaFin;
            IdBloque = idBloque;
        }

        public void GuardarEnBD(string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    INSERT INTO Turno (fecha_turno, hora_inicio, hora_fin, id_bloque)
                    VALUES (@FechaTurno, @HoraInicio, @HoraFin, @IdBloque);
                    SELECT CAST(scope_identity() AS int)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FechaTurno", FechaTurno);
                    cmd.Parameters.AddWithValue("@HoraInicio", HoraInicio);
                    cmd.Parameters.AddWithValue("@HoraFin", HoraFin);
                    cmd.Parameters.AddWithValue("@IdBloque", IdBloque);

                    // Obtiene el ID generado
                    IdTurno = (int)cmd.ExecuteScalar();
                }
            }
        }
    }
}