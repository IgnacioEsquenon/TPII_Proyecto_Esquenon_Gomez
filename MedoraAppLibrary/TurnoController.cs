using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedoraAppLibrary
{
    public class TurnoController
    {
        private readonly string connectionString;

        public TurnoController(string connString)
        {
            connectionString = connString;
        }
        public bool CrearBloqueHorario(DateTime fechaInicio, DateTime fechaFin, TimeSpan horaInicio, TimeSpan horaFin, int duracionTurnos, int idMedico, int idDia)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("med_CrearBloqueHorario", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Asignamos todos los parámetros que el procedimiento espera
                        cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                        cmd.Parameters.AddWithValue("@FechaFin", fechaFin);
                        cmd.Parameters.AddWithValue("@HoraInicio", horaInicio);
                        cmd.Parameters.AddWithValue("@HoraFin", horaFin);
                        cmd.Parameters.AddWithValue("@DuracionTurnos", duracionTurnos);
                        cmd.Parameters.AddWithValue("@IdMedico", idMedico);
                        cmd.Parameters.AddWithValue("@IdDia", idDia);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        return true; 
                    }
                }
            }
            catch (SqlException ex)
            {
                
                MessageBox.Show(ex.Message, "Diagnóstico de Conflicto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public DataTable ObtenerDiasSemana()
        {
            DataTable dt = new DataTable();
            string query = "SELECT id_dia, nombre FROM Día ORDER BY id_dia";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(dt);
            }
            return dt;
        }

        public DataTable ListarBloquesMedico(int idMedico)
        {
            DataTable dtBloques = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("med_ListarBloquesMedico", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdMedico", idMedico);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dtBloques);
                }
            }
            return dtBloques;
        }

        public bool EliminarBloqueHorario(int idBloque)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("med_EliminarBloqueHorario", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdBloque", idBloque);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (SqlException ex)
            {
                // Esto mostrará el mensaje de error que definiste en el RAISERROR
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }


        // En TurnoController.cs
        public DataTable ObtenerEspecialidades()
        {
            DataTable dt = new DataTable();
            
            string query = "SELECT id_especialidad, nombre FROM Especialidad ORDER BY nombre";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar especialidades: " + ex.Message);
                }
            }
            return dt;
        }

        public DataTable ObtenerMedicosPorEspecialidad(int idEspecialidad)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("rec_BuscarMedico", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdEspecialidad", idEspecialidad);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar médicos: " + ex.Message);
                }
            }
            return dt;
        }

        public DataTable ObtenerTurnosDisponibles(int idMedico, DateTime fechaDesde, DateTime fechaHasta, int? idDia = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                   
                    SqlCommand cmd = new SqlCommand("rec_ObtenerTurnosDisponiblesConMedico", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdMedico", idMedico);
                    cmd.Parameters.AddWithValue("@FechaInicio", fechaDesde);
                    cmd.Parameters.AddWithValue("@FechaFin", fechaHasta);

                    
                    if (idDia.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@IdDia", idDia.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@IdDia", DBNull.Value);
                    }
                   
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener turnos: " + ex.Message);
                }
            }
            return dt;
        }

        public DataTable ObtenerDiasDeTrabajoPorMedico(int idMedico)
        {
            DataTable dtDias = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                
                using (SqlCommand cmd = new SqlCommand("med_ObtenerDiasDeTrabajoPorMedico", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdMedico", idMedico);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dtDias);
                }
            }
            return dtDias;
        }

        public bool RegistrarReserva(int idTurno, int idPaciente, int idMotivoConsulta)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("rec_RegistrarReserva", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdTurno", idTurno);
                    cmd.Parameters.AddWithValue("@IdPaciente", idPaciente);
                    cmd.Parameters.AddWithValue("@IdMotivoConsulta", idMotivoConsulta);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar la reserva: " + ex.Message);
                    return false;
                }
            }
        }

      
        public DataTable ObtenerMotivosPorEspecialidad(int idEspecialidad)
        {
            DataTable dt = new DataTable();
            string query = "SELECT id_motivo_consulta, descripcion FROM Motivo_Consulta WHERE id_especialidad = @idEspecialidad ORDER BY descripcion";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@idEspecialidad", idEspecialidad);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar motivos de consulta: " + ex.Message);
                }
            }
            return dt;
        }

        public DataTable ListarAgendaMedico(int idMedico, DateTime fechaDesde, DateTime fechaHasta, string filtroPaciente)
        {
            
            DataTable dtAgenda = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                
                con.Open();

                
                using (SqlCommand cmd = new SqlCommand("med_ListarAgendaMedico", con))
                {
                    
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdMedico", idMedico);
                    cmd.Parameters.AddWithValue("@FechaDesde", fechaDesde);
                    cmd.Parameters.AddWithValue("@FechaHasta", fechaHasta);

                    if (!string.IsNullOrEmpty(filtroPaciente))
                    {
                        cmd.Parameters.AddWithValue("@FiltroPaciente", filtroPaciente); 
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@FiltroPaciente", DBNull.Value);
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dtAgenda);
                }
            }

            return dtAgenda;
        }

        public DataTable ListarHistorialMedico(int idMedico, DateTime fechaDesde, DateTime fechaHasta, string filtroPaciente)
        {
            DataTable dtHistorial = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("med_ListarHistorialMedico", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdMedico", idMedico);
                    cmd.Parameters.AddWithValue("@FechaDesde", fechaDesde);
                    cmd.Parameters.AddWithValue("@FechaHasta", fechaHasta);

                    if (!string.IsNullOrEmpty(filtroPaciente))
                    {
                        cmd.Parameters.AddWithValue("@FiltroPaciente", filtroPaciente);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@FiltroPaciente", DBNull.Value);
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dtHistorial);
                }
            }
            return dtHistorial;
        }

        public bool FinalizarReserva(int idReserva, string diagnostico)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("med_FinalizarReserva", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdReserva", idReserva);
                        cmd.Parameters.AddWithValue("@Diagnostico", diagnostico);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        return true; 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el diagnóstico: " + ex.Message);
                return false; 
            }
        }

        public DataTable ListarReservasProximas(string filtro)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("rec_ListarReservasPacientes", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Filtro", string.IsNullOrEmpty(filtro) ? (object)DBNull.Value : filtro);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public bool CancelarReserva(int idReserva)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("rec_CancelarReserva", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdReserva", idReserva);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public bool RealizarBackupCompleto(string rutaArchivo)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sys_RealizarBackupCompleto", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Aumentamos el tiempo de espera por si la BD es grande
                        cmd.CommandTimeout = 300; // 5 minutos

                        
                        cmd.Parameters.AddWithValue("@RutaArchivo", rutaArchivo);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        return true; // Si todo sale bien, devuelve 'true'
                    }
                }
            }
            catch (Exception ex)
            {
                // Si algo falla, muestra un error detallado
                MessageBox.Show("Error al realizar el backup: " + ex.Message +
                                "\n\nIMPORTANTE: Asegúrese de que el servicio de SQL Server tenga permisos de escritura en la carpeta seleccionada (ver instrucciones en el archivo README).",
                                "Error de Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public DataTable DiagnosticarSolapamiento(DateTime fechaInicio, DateTime fechaFin, TimeSpan horaInicio, TimeSpan horaFin, int idMedico, int idDia)
        {
            DataTable dtConflicto = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_DiagnosticarSolapamiento", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@FechaFin", fechaFin);
                    cmd.Parameters.AddWithValue("@HoraInicio", horaInicio);
                    cmd.Parameters.AddWithValue("@HoraFin", horaFin);
                    cmd.Parameters.AddWithValue("@IdMedico", idMedico);
                    cmd.Parameters.AddWithValue("@IdDia", idDia);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dtConflicto);
                }
            }
            return dtConflicto;
        }

    }
}
