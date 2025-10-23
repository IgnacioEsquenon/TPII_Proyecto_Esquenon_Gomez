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

                // Lógica para manejar el ID de obra social nulo
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
                    // Captura el error específico si el DNI o el Email ya existen
                    if (ex.Number == 2627) // Código de error para violación de UNIQUE constraint
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

        //----### // 2. MÉTODO PARA OBTENER TODOS LOS PACIENTES
        public DataTable ObtenerTodosLosPacientes()
        {
            DataTable dt = new DataTable();

            // ✅ Consulta SQL mejorada con LEFT JOIN
            string query = @"
        SELECT
            p.id_paciente,
            p.nombre,
            p.apellido,
            p.dni,
            p.edad,
            p.telefono,
            p.email,
            -- Usamos ISNULL para mostrar 'Particular' si id_obra_social es NULL
            ISNULL(os.nombre, 'Particular') AS nombre_obra_social
        FROM
            Paciente AS p
        LEFT JOIN
            Obra_Social AS os ON p.id_obra_social = os.id_obra_social
        ORDER BY
            p.apellido, p.nombre";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener pacientes: " + ex.Message);
                }
            }
            return dt;
        }

        //----### 3. MÉTODO PARA VERIFICAR SI UN PACIENTE YA EXISTE

        public bool ExistePaciente(string dni, string email)
        {
            // Usamos COUNT(1) que es muy eficiente para solo contar si hay coincidencias
            string query = "SELECT COUNT(1) FROM Paciente WHERE dni = @dni OR email = @email";

            // Manejo especial si el email está vacío, para no buscar un email nulo
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
                    object result = cmd.ExecuteScalar(); // Guárdalo en un 'object' primero

                    // ✅ Si el resultado no es nulo y es un número, lo convertimos
                    if (result != null && result != DBNull.Value)
                    {
                        int count = Convert.ToInt32(result);
                        return count > 0;
                    }

                    return false; // Si no devuelve nada, no existe.
                }
                catch (Exception ex)
                {
                    // ...
                    return true;
                }
            }
        }

        //----4. MÉTODO PARA OBTENER LA LISTA DE OBRAS SOCIALES

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

