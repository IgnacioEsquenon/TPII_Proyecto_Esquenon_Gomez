using MedoraAppLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MedoraAppLibrary
{
    public class Recepcionista : Usuario
    {
        // Constructor por defecto
        public Recepcionista() { }

        // Constructor completo
        public Recepcionista(int idUsuario, string nombre, string apellido, string dni, string email, string telefono, string contraseñaHash)
            : base(idUsuario, nombre, apellido, dni, email, contraseñaHash, Rol.Recepcionista, telefono)
        {
        }

        public bool RegistrarPaciente(string connectionString, Paciente paciente)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
            INSERT INTO Paciente (nombre, apellido, dni, email, telefono)
            VALUES (@Nombre, @Apellido, @Dni, @Email, @Telefono);";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", paciente.Nombre ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Apellido", paciente.Apellido ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Dni", paciente.Dni ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Email", paciente.Email ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Telefono", paciente.Telefono ?? (object)DBNull.Value);

                    int filas = cmd.ExecuteNonQuery();
                    return filas > 0; // true si se insertó correctamente
                }
            }
        }

        public List<Paciente> ObtenerPacientes(
    string connectionString,
    string nombreApellido = null,
    string dni = null,
    string telefono = null,
    string email = null)
        {
            List<Paciente> pacientes = new List<Paciente>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
            SELECT 
                id_paciente,
                nombre,
                apellido,
                dni,
                email,
                telefono
            FROM Paciente
            WHERE
                (@NombreApellido IS NULL OR UPPER(nombre) LIKE '%' + UPPER(@NombreApellido) + '%' OR UPPER(apellido) LIKE '%' + UPPER(@NombreApellido) + '%')
                AND (@Dni IS NULL OR dni = @Dni)
                AND (@Telefono IS NULL OR telefono = @Telefono)
                AND (@Email IS NULL OR email = @Email)
            ORDER BY apellido, nombre;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NombreApellido", (object)nombreApellido ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Dni", (object)dni ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Telefono", (object)telefono ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Email", (object)email ?? DBNull.Value);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pacientes.Add(new Paciente(
                                (int)reader["id_paciente"],
                                reader["nombre"].ToString(),
                                reader["apellido"].ToString(),
                                reader["dni"].ToString(),
                                reader["email"].ToString(),
                                reader["telefono"].ToString()
                            ));
                        }
                    }
                }
            }

            return pacientes;
        }

        // Buscar médicos
        public List<Medico> BuscarMedicos(string connectionString, int idEspecialidad, string textoBusqueda = null)
        {
            List<Medico> medicos = new List<Medico>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT
                        U.id_usuario,
                        U.nombre AS NombreMedico,
                        U.apellido AS ApellidoMedico,
                        E.nombre AS Especialidad
                    FROM Usuario U
                    JOIN Rol R ON U.id_rol = R.id_rol
                    JOIN Especialidad E ON U.id_especialidad = E.id_especialidad
                    WHERE
                        U.id_rol = 2
                        AND E.id_especialidad = @IdEspecialidad
                        AND (
                            @TextoBusquedaNombre IS NULL
                            OR UPPER(LTRIM(RTRIM(U.nombre))) LIKE '%' + UPPER(LTRIM(RTRIM(@TextoBusquedaNombre))) + '%'
                            OR UPPER(LTRIM(RTRIM(U.apellido))) LIKE '%' + UPPER(LTRIM(RTRIM(@TextoBusquedaNombre))) + '%'
                        )
                    ORDER BY U.apellido, U.nombre;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdEspecialidad", idEspecialidad);
                    cmd.Parameters.AddWithValue("@TextoBusquedaNombre", (object)textoBusqueda ?? DBNull.Value);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            medicos.Add(new Medico
                            {
                                IdUsuario = (int)reader["id_usuario"],
                                Nombre = reader["NombreMedico"].ToString(),
                                Apellido = reader["ApellidoMedico"].ToString(),
                                Especialidad_Medico = new Especialidad { Nombre = reader["Especialidad"].ToString() }
                            });
                        }
                    }
                }
            }

            return medicos;
        }

        // Listar turnos disponibles de un médico
        public List<Turno> ObtenerTurnosDisponibles(
    string connectionString,
    int idMedico,
    DateTime? fechaInicio = null,
    DateTime? fechaFin = null,
    int? idDia = null)
        {
            var turnos = new List<Turno>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
            SELECT
                T.id_turno,
                T.fecha_turno,
                T.hora_inicio,
                T.hora_fin,
                D.nombre AS DiaSemana,
                ET.nombre AS EstadoTurno
            FROM Turno T
            JOIN Bloque_Horario BH ON T.id_bloque = BH.id_bloque
            JOIN Día D ON BH.id_dia = D.id_dia
            JOIN Estado_Turno ET ON T.id_estado_turno = ET.id_estado_turno
            WHERE
                BH.id_medico = @IdMedico
                AND ET.id_estado_turno = 1
                AND T.fecha_turno >= CAST(GETDATE() AS DATE)
                AND BH.fecha_fin >= CAST(GETDATE() AS DATE)
                AND (@FechaInicio IS NULL OR T.fecha_turno >= @FechaInicio)
                AND (@FechaFin IS NULL OR T.fecha_turno <= @FechaFin)
                AND (@IdDia IS NULL OR BH.id_dia = @IdDia)
            ORDER BY T.fecha_turno, T.hora_inicio;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdMedico", idMedico);
                    cmd.Parameters.AddWithValue("@FechaInicio", (object)fechaInicio ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FechaFin", (object)fechaFin ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IdDia", (object)idDia ?? DBNull.Value);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            turnos.Add(new Turno
                            {
                                IdTurno = (int)reader["id_turno"],
                                FechaTurno = (DateTime)reader["fecha_turno"],
                                HoraInicio = (TimeSpan)reader["hora_inicio"],
                                HoraFin = (TimeSpan)reader["hora_fin"]
                            });
                        }
                    }
                }
            }

            return turnos;
        }

        // Registrar una reserva
        public bool CrearReserva(string connectionString, Reserva reserva)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    INSERT INTO Reserva (id_turno, id_paciente, motivo_consulta, id_estado)
                    VALUES (@IdTurno, @IdPaciente, @MotivoConsulta, @IdEstado);";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdTurno", reserva.IdTurno);
                    cmd.Parameters.AddWithValue("@IdPaciente", reserva.IdPaciente);
                    cmd.Parameters.AddWithValue("@MotivoConsulta", string.IsNullOrEmpty(reserva.MotivoConsulta) ? (object)DBNull.Value : reserva.MotivoConsulta);
                    cmd.Parameters.AddWithValue("@IdEstado", reserva.IdEstado);

                    int filas = cmd.ExecuteNonQuery();
                    return filas > 0;
                }
            }
        }

        public List<Reserva> ObtenerReservasProximas(
    string connectionString,
    string filtroPaciente = null)
        {
            var reservas = new List<Reserva>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
            SELECT 
                R.id_reserva,
                R.motivo_consulta,
                R.id_turno,
                R.id_paciente,
                P.nombre AS NombrePaciente,
                P.apellido AS ApellidoPaciente,
                P.dni AS DniPaciente,
                ET.nombre AS EstadoReserva,
                T.fecha_turno,
                T.hora_inicio,
                T.hora_fin
            FROM Reserva R
            JOIN Turno T ON R.id_turno = T.id_turno
            JOIN Paciente P ON R.id_paciente = P.id_paciente
            JOIN Estado_Turno ET ON T.id_estado_turno = ET.id_estado_turno
            WHERE 
                T.fecha_turno >= CAST(GETDATE() AS DATE)
                AND (@Filtro IS NULL 
                     OR P.nombre LIKE '%' + @Filtro + '%'
                     OR P.apellido LIKE '%' + @Filtro + '%'
                     OR P.dni LIKE '%' + @Filtro + '%')
            ORDER BY T.fecha_turno ASC, T.hora_inicio ASC;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Filtro",
                        string.IsNullOrWhiteSpace(filtroPaciente) ? (object)DBNull.Value : filtroPaciente);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            reservas.Add(new Reserva
                            {
                                IdReserva = (int)reader["id_reserva"],
                                MotivoConsulta = reader["motivo_consulta"].ToString(),
                                IdTurno = (int)reader["id_turno"],
                                IdPaciente = (int)reader["id_paciente"],

                                // Datos del paciente (objeto embebido o campos sueltos)
                                Paciente = new Paciente(
                                    (int)reader["id_paciente"],
                                    reader["NombrePaciente"].ToString(),
                                    reader["ApellidoPaciente"].ToString(),
                                    reader["DniPaciente"].ToString(),
                                    "", "" // Email y teléfono no se consultan aquí
                                ),

                                EstadoReserva = reader["EstadoReserva"].ToString(),
                                FechaTurno = (DateTime)reader["fecha_turno"],
                                HoraInicio = (TimeSpan)reader["hora_inicio"],
                                HoraFin = (TimeSpan)reader["hora_fin"]
                            });
                        }
                    }
                }
            }

            return reservas;
        }
    }
}