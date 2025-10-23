using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MedoraAppLibrary
{
    public class Medico : Usuario
    {
        public Especialidad Especialidad_Medico { get; set; }

        // Constructor por defecto
        public Medico() { }

        // Constructor completo
        public Medico(int idUsuario, string nombre, string apellido, string dni, string email, string telefono, string contraseñaHash, Especialidad especialidad)
            : base(idUsuario, nombre, apellido, dni, email, contraseñaHash, Rol.Medico, telefono)
        {
            Especialidad_Medico = especialidad;
        }

        // Crear un bloque horario y generar turnos
        public void CrearBloqueConTurnos(BloqueHorario bloque, string connectionString)
        {
            // Asociar el bloque al médico
            bloque.IdUsuario = this.IdUsuario;

            // Guardar bloque en BD
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                CREATE OR ALTER PROCEDURE med_CrearBloqueHorario
                    @FechaInicio DATE,
                    @FechaFin DATE,
                    @HoraInicio TIME,
                    @HoraFin TIME,
                    @DuracionTurnos INT,
                    @IdMedico INT,
                    @IdDia INT";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FechaInicio", bloque.FechaInicio);
                    cmd.Parameters.AddWithValue("@FechaFin", bloque.FechaFin);
                    cmd.Parameters.AddWithValue("@HoraInicio", bloque.HoraInicio);
                    cmd.Parameters.AddWithValue("@HoraFin", bloque.HoraFin);
                    cmd.Parameters.AddWithValue("@DuracionTurnos", bloque.DuracionTurnos);
                    cmd.Parameters.AddWithValue("@IdUsuario", bloque.IdUsuario);
                    cmd.Parameters.AddWithValue("@IdDia", bloque.IdDia);

                    IdBloque = (int)cmd.ExecuteScalar();
                }
            }
        }
    }
}