using System;
using MedoraAppLibrary;

namespace MedoraAppTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Definir la cadena de conexión (local, SQL Server)
            string connectionString = @"Server=DESKTOP-4QR6I55\SQLEXPRESS;Database=MedoraDB;Trusted_Connection=True;";

            try
            {
                // Crear un bloque horario de prueba
                BloqueHorario bloque = new BloqueHorario
                {
                    FechaInicio = new DateTime(2025, 9, 1),
                    FechaFin = new DateTime(2025, 9, 30),
                    HoraInicio = new TimeSpan(7, 0, 0),   // 7:00 AM
                    HoraFin = new TimeSpan(9, 0, 0),      // 9:00 AM
                    DuracionTurnos = 30,                  // Turnos de 30 minutos
                    IdUsuario = 2,                        // ID del médico en tabla Usuario
                    IdDia = 2                              // 1=lunes, 2=martes...
                };

                // Guardar el bloque en la base de datos
                bloque.GuardarEnBD(connectionString);
                Console.WriteLine("✅ Bloque guardado correctamente en la base de datos.");

                // Generar y guardar turnos automáticamente
                bloque.GenerarYGuardarTurnos(connectionString);
                Console.WriteLine("✅ Turnos generados y guardados correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error al procesar el bloque: " + ex.Message);
            }

            Console.WriteLine("Presione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}