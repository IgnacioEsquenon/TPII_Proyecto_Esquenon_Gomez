using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace MedoraAppLibrary
{
    public class UsuarioController
    {
        private string connectionString;

        public UsuarioController(string connString)
        {
            connectionString = connString;
        }

        public bool CrearUsuario(Usuario nuevoUsuario)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string query = @"INSERT INTO Usuario 
                                    (nombre, apellido, dni, email, telefono, contraseña_hash, id_rol, id_especialidad, estado_usuario)
                                    VALUES (@nombre, @apellido, @dni, @correo, @telefono, @contraseña, @rol, @especialidad, @estado)";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@nombre", nuevoUsuario.Nombre);
                    cmd.Parameters.AddWithValue("@apellido", nuevoUsuario.Apellido);
                    cmd.Parameters.AddWithValue("@dni", nuevoUsuario.Dni);
                    cmd.Parameters.AddWithValue("@correo", nuevoUsuario.Email);
                    cmd.Parameters.AddWithValue("@telefono", nuevoUsuario.Telefono ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@contraseña", nuevoUsuario.ContraseñaHash);
                    cmd.Parameters.AddWithValue("@rol", (int)nuevoUsuario.Rol);
                    cmd.Parameters.AddWithValue("@estado", nuevoUsuario.Estado);

                    if (nuevoUsuario.Rol == Rol.Medico)
                    {
                      cmd.Parameters.AddWithValue("@especialidad", nuevoUsuario.Especialidad.id_especialidad);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@especialidad", (object)DBNull.Value);
                    }
                       
                    connection.Open();
                    int filas = cmd.ExecuteNonQuery();

                    return filas > 0;
                }
                catch (Exception ex)
                {
                    
                    Console.WriteLine("Error al crear usuario: " + ex.Message);
                    return false;
                }
            }
        }

        public Usuario ValidarYObtenerUsuario(string usuario, string passwordIngresada)
        {
            Usuario usuarioEncontrado = null;
            string hashGuardado = "";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT id_usuario, nombre, apellido, contraseña_hash, id_rol, id_especialidad " +
                               "FROM Usuario WHERE (email = @usuario OR dni = @usuario) AND estado_usuario = 1";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                       
                        hashGuardado = reader["contraseña_hash"].ToString();
                        usuarioEncontrado = new Usuario
                        {
                            IdUsuario = Convert.ToInt32(reader["id_usuario"]),
                            Nombre = reader["nombre"].ToString(),
                            Apellido = reader["apellido"].ToString(),
                            Rol = (Rol)Convert.ToInt32(reader["id_rol"]),
                            Especialidad = new Especialidad { id_especialidad = reader["id_especialidad"] == DBNull.Value ? 0 : Convert.ToInt32(reader["id_especialidad"]) }
                        };
                    }
                }
            }

            
            if (usuarioEncontrado == null)
            {
                return null;
            }

           
            if (ContrasenaHelper.VerifyPassword(passwordIngresada, hashGuardado))
            {
                return usuarioEncontrado; 
            }
            else
            {
                return null; 
            }
        }

        public DataTable ObtenerTodosLosUsuarios(EstadoUsuarioFiltro filtro)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataTable dt = new DataTable();
                string query = @"
            SELECT
                u.id_usuario,
                u.nombre,
                u.apellido,
                u.dni,
                u.email,
                u.telefono,
                r.nombre AS nombre_rol,
                e.nombre AS nombre_Especialidad,
                u.id_rol,
                u.id_especialidad,
                u.estado_usuario
            FROM Usuario AS u
            LEFT JOIN Rol AS r ON u.id_rol = r.id_rol
            LEFT JOIN Especialidad AS e ON u.id_especialidad = e.id_especialidad
            WHERE (@filtro = -1 OR u.estado_usuario = @filtro)";
                try
                {
                    
                    int valorFiltro;
                    switch (filtro)
                    {
                        case EstadoUsuarioFiltro.Activos:
                            valorFiltro = 1;
                            break;
                        case EstadoUsuarioFiltro.Inactivos:
                            valorFiltro = 0;
                            break;
                        default: // Caso 'Todos'
                            valorFiltro = -1; // Usa -1 como valor especial para "todos"
                            break;
                    }

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@filtro", valorFiltro);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener usuarios: " + ex.Message);
                    
                }

                return dt;
            }
        }

        public bool EliminarUsuario(int idUsuario)
        {
            string query = "UPDATE Usuario SET estado_usuario = 0 WHERE id_usuario = @idUsuario";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                try
                {
                    connection.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al eliminar usuario: " + ex.Message);
                    return false;
                }
            }
        }
    }
    }
