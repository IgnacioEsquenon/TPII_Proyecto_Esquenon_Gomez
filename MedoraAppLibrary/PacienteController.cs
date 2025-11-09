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
    public class PacienteController
    {
        private string connectionString;
        public PacienteController(string connString)
        {
            connectionString = connString;
        }

        public bool CrearPaciente(Paciente nuevoPaciente)
        {
            string query = @"INSERT INTO Paciente (nombre, apellido, dni, telefono, email, id_obra_social, edad)
                         VALUES (@nombre, @apellido, @dni, @telefono, @email, @id_obra_social, @edad)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@nombre", nuevoPaciente.Nombre);
                cmd.Parameters.AddWithValue("@apellido", nuevoPaciente.Apellido);
                cmd.Parameters.AddWithValue("@dni", nuevoPaciente.Dni);
                cmd.Parameters.AddWithValue("@telefono", (object)nuevoPaciente.Telefono ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@email", (object)nuevoPaciente.Email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@edad", nuevoPaciente.Edad);

                if (nuevoPaciente.IdObraSocial.HasValue)
                {
                    cmd.Parameters.AddWithValue("@id_obra_social", nuevoPaciente.IdObraSocial.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@id_obra_social", DBNull.Value);
                }

                try
                {
                    connection.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627) 
                    {
                        MessageBox.Show("Error: El DNI o el Email ya se encuentran registrados.", "Dato duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Error de base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return false;
                }
            }
        }

        public DataTable ObtenerTodosLosPacientes()
        {
            DataTable dt = new DataTable();
            string procedureName = "rec_ListarPacientes";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(procedureName, connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener pacientes: " + ex.Message);
                }
            }
            return dt;
        }



        public bool ExistePaciente(string dni, string email)
        {
            string query = "SELECT COUNT(1) FROM Paciente WHERE dni = @dni OR email = @email";

            if (string.IsNullOrWhiteSpace(email))
            {
                query = "SELECT COUNT(1) FROM Paciente WHERE dni = @dni";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (!string.IsNullOrWhiteSpace(email))
                {
                    query += " OR email = @email";
                }

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@dni", dni);

                if (!string.IsNullOrWhiteSpace(email))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                }

                try
                {
                    connection.Open();
                    object result = cmd.ExecuteScalar(); 

                    if (result != null && result != DBNull.Value)
                    {
                        int count = Convert.ToInt32(result);
                        return count > 0;
                    }

                    return false; 
                }
                catch (Exception ex)
                {
                    return true;
                }
            }
        }

        public DataTable ObtenerObrasSociales()
        {
            DataTable dt = new DataTable();
            string query = "SELECT id_obra_social, nombre FROM Obra_Social ORDER BY nombre";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener obras sociales: " + ex.Message);
                }
            }
            return dt;
        }

    }

    }

