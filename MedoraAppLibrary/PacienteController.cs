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

        public bool RegistrarPaciente(Paciente nuevoPaciente)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    // 1. Llama al Stored Procedure correcto
                    using (SqlCommand cmd = new SqlCommand("rec_RegistrarPaciente", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // 2. Asigna todos los parámetros
                        cmd.Parameters.AddWithValue("@Nombre", nuevoPaciente.Nombre);
                        cmd.Parameters.AddWithValue("@Apellido", nuevoPaciente.Apellido);
                        cmd.Parameters.AddWithValue("@Dni", nuevoPaciente.Dni);
                        cmd.Parameters.AddWithValue("@Email", (object)nuevoPaciente.Email ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Telefono", nuevoPaciente.Telefono);

                        // 3. Pasa la nueva propiedad FechaNacimiento
                        cmd.Parameters.AddWithValue("@FechaNacimiento", nuevoPaciente.FechaNacimiento);

                        // 4. Maneja la Obra Social
                        if (nuevoPaciente.IdObraSocial.HasValue && nuevoPaciente.IdObraSocial.Value > 0)
                        {
                            cmd.Parameters.AddWithValue("@IdObraSocial", nuevoPaciente.IdObraSocial.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@IdObraSocial", DBNull.Value);
                        }

                        con.Open();
                        int filasAfectadas = cmd.ExecuteNonQuery();

                        // 5. Devuelve 'true' si la inserción fue exitosa
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Error de Clave Única (DNI, Email, etc.)
                {
                    MessageBox.Show("Error: El DNI, Email o Teléfono ya se encuentran registrados.", "Dato duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Error de base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado al registrar paciente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
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
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("rec_VerificarPacienteExistente", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Dni", dni);

                        // Maneja el caso de que el email sea un string vacío
                        if (!string.IsNullOrEmpty(email))
                        {
                            cmd.Parameters.AddWithValue("@Email", email);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Email", DBNull.Value);
                        }

                        con.Open();
                        // ExecuteScalar es perfecto para devolver un solo valor (1 o 0)
                        int resultado = (int)cmd.ExecuteScalar();
                        return (resultado == 1);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar paciente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true; // Si hay un error, devolvemos true por precaución para detener el registro.
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

