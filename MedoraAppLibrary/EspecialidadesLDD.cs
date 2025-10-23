using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MedoraAppLibrary
{
    public class EspecialidadesLDD
    {
        private string connectionString;

        public EspecialidadesLDD(string connString) 
        {
            connectionString = connString;
        }

        public List<Especialidad> ObtenerEspecialidades()
        {
            List<Especialidad> listaEspecialidades = new List<Especialidad>();
            string query = "SELECT id_especialidad, Nombre FROM Especialidad"; 

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Especialidad especialidad = new Especialidad
                        {
                            id_especialidad = reader.GetInt32(0),
                            Nombre = reader.GetString(1)
                        };
                        listaEspecialidades.Add(especialidad);
                    }
                }
            }
            return listaEspecialidades;
        }
        }
}
