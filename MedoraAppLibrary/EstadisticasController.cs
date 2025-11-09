using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MedoraAppLibrary
{
    public class EstadisticasController
    {
        private readonly string connectionString;

        public EstadisticasController(string connString)
        {
            this.connectionString = connString;
        }

        public DataTable GetAdminKPIs(DateTime desde, DateTime hasta)
        {
            return EjecutarSP("sp_Admin_GetDashboardKPIs", desde, hasta);
        }

        public DataTable GetAdminTurnosPorEspecialidad(DateTime desde, DateTime hasta)
        {
            return EjecutarSP("sp_Admin_GetTurnosPorEspecialidad", desde, hasta);
        }

        // --- MÉTODOS PARA EL MÉDICO ---
        public DataTable GetMedicoActividad(int idMedico, DateTime desde, DateTime hasta)
        {
            return EjecutarSP("med_EstadisticaActividadMedico", desde, hasta, idMedico);
        }

        public DataTable GetMedicoMotivos(int idMedico, DateTime desde, DateTime hasta)
        {
            return EjecutarSP("med_EstadisticaMotivosMedico", desde, hasta, idMedico);
        }

        // --- MÉTODOS PARA EL RECEPCIONISTA ---
        public DataTable GetRecepPacientesPorObraSocial()
        {
            return EjecutarSP("sp_Recep_GetPacientesPorObraSocial");
        }

        public DataTable GetRecepTurnosPorDia(DateTime desde, DateTime hasta)
        {
            return EjecutarSP("sp_Recep_GetTurnosPorDiaSemana", desde, hasta);
        }

        
        private DataTable EjecutarSP(string nombreSP, DateTime? desde = null, DateTime? hasta = null, int? idMedico = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(nombreSP, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (idMedico.HasValue) cmd.Parameters.AddWithValue("@IdMedico", idMedico.Value);
                    if (desde.HasValue) cmd.Parameters.AddWithValue("@FechaDesde", desde.Value); 
                    if (hasta.HasValue) cmd.Parameters.AddWithValue("@FechaHasta", hasta.Value);   

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable GetAdminEstadisticaGeneral(DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("admin_EstadisticaClinicaGeneral", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@FechaFin", fechaFin);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable GetAdminDistribucionDeEstados(DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Admin_GetDistribucionDeEstados", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@FechaFin", fechaFin);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable GetRecepEstadisticaObrasSociales(DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("rec_EstadisticaObrasSociales", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@FechaFin", fechaFin);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable GetRecepEstadisticaPacientes(DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("rec_EstadisticaPacientes", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@FechaFin", fechaFin);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }


    }
}
