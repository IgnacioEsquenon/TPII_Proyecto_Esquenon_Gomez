using MedoraAppLibrary;
using System;
using System.Collections.Generic;

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
                // Crear instancia del médico
                Medico medico = new Medico
                {
                    IdUsuario = 4,
                    Nombre = "Juan",
                    Apellido = "Pérez",
                    Email = "juan.perez@hospital.com"
                };

                // Crear bloque horario
                BloqueHorario bloque = new BloqueHorario
                {
                    FechaInicio = new DateTime(2026, 2, 5),
                    FechaFin = new DateTime(2026, 3, 20),
                    HoraInicio = new TimeSpan(10, 0, 0),   // 10:00 AM
                    HoraFin = new TimeSpan(20, 0, 0),      // 8:00 PM
                    DuracionTurnos = 30,                   // Turnos de 30 minutos
                    IdDia = 5,                             // 1=lunes, 2=martes, etc.
                    Activo = true
                };

                // El médico crea el bloque con sus turnos
                medico.CrearBloqueConTurnos(bloque, connectionString);

                Console.WriteLine($"Bloque horario creado exitosamente para el médico");
                Console.WriteLine("Turnos generados y guardados correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al procesar el bloque: " + ex.Message);
            }

            Console.WriteLine("Presione cualquier tecla para salir...");
            Console.ReadKey();

            /*string connectionString = @"Server=DESKTOP-4QR6I55\SQLEXPRESS;Database=MedoraDB;Trusted_Connection=True;";

            // 1️⃣ Crear instancia de recepcionista
            Recepcionista recepcionista = new Recepcionista(1, "Ana", "Gomez", "12345678", "ana@mail.com", "555-1234", "hash123");

            // 2️⃣ Buscar médicos
            Console.Write("Ingrese id de especialidad: ");
            int idEspecialidad = int.Parse(Console.ReadLine());

            Console.Write("Ingrese nombre o apellido (opcional, Enter para omitir): ");
            string textoBusqueda = Console.ReadLine();

            List<Medico> medicos = recepcionista.BuscarMedicos(connectionString, idEspecialidad, string.IsNullOrWhiteSpace(textoBusqueda) ? null : textoBusqueda);

            if (medicos.Count == 0)
            {
                Console.WriteLine("No se encontraron médicos.");
                return;
            }

            Console.WriteLine("\nMédicos encontrados:");
            for (int i = 0; i < medicos.Count; i++)
                Console.WriteLine($"{i + 1}. {medicos[i].Nombre} {medicos[i].Apellido} ({medicos[i].Especialidad_Medico.Nombre})");

            Console.Write("Seleccione un médico por número: ");
            int seleccionMedico = int.Parse(Console.ReadLine());
            Medico medicoSeleccionado = medicos[seleccionMedico - 1];

            // 3️⃣ Filtros opcionales
            Console.WriteLine("\n--- FILTROS OPCIONALES ---");

            Console.Write("Fecha desde (yyyy-MM-dd) o Enter para omitir: ");
            string inputDesde = Console.ReadLine();
            DateTime? fechaInicio = null;
            if (!string.IsNullOrWhiteSpace(inputDesde))
            {
                fechaInicio = DateTime.Parse(inputDesde);
            }

            Console.Write("Fecha hasta (yyyy-MM-dd) o Enter para omitir: ");
            string inputHasta = Console.ReadLine();
            DateTime? fechaFin = null;
            if (!string.IsNullOrWhiteSpace(inputHasta))
            {
                fechaFin = DateTime.Parse(inputHasta);
            }

            Console.Write("Id del día (1=Lunes, 2=Martes... 7=Domingo) o Enter para omitir: ");
            string inputDia = Console.ReadLine();
            int? idDia = null;
            if (!string.IsNullOrWhiteSpace(inputDia))
            {
                idDia = int.Parse(inputDia);
            }

            // 4️⃣ Obtener turnos disponibles filtrados
            List<Turno> turnos = recepcionista.ObtenerTurnosDisponibles(connectionString, medicoSeleccionado.IdUsuario, fechaInicio, fechaFin, idDia);

            if (turnos.Count == 0)
            {
                Console.WriteLine("No hay turnos disponibles para ese médico con esos filtros.");
                return;
            }

            Console.WriteLine("\nTurnos disponibles:");
            for (int i = 0; i < turnos.Count; i++)
                Console.WriteLine($"{i + 1}. {turnos[i].FechaTurno:yyyy-MM-dd} {turnos[i].HoraInicio} - {turnos[i].HoraFin}");

            Console.Write("Seleccione un turno por número: ");
            int seleccionTurno = int.Parse(Console.ReadLine());
            Turno turnoSeleccionado = turnos[seleccionTurno - 1];

            // 5️⃣ Crear reserva
            Console.Write("\nIngrese id del paciente: ");
            int idPaciente = int.Parse(Console.ReadLine());

            Console.Write("Ingrese motivo de consulta: ");
            string motivoConsulta = Console.ReadLine();

            Reserva nuevaReserva = new Reserva(motivoConsulta, 1, turnoSeleccionado.IdTurno, idPaciente);

            bool exito = recepcionista.CrearReserva(connectionString, nuevaReserva);
            Console.WriteLine(exito ? "\n✅ Reserva creada correctamente." : "\n❌ Error al crear la reserva.");

            Console.WriteLine("=== CONSULTA DE RESERVAS PRÓXIMAS ===");
            Console.Write("Ingrese nombre o apellido del paciente (opcional): ");
            string filtro = Console.ReadLine();

            var reservas = recepcionista.ObtenerReservasProximas(
                connectionString,
                string.IsNullOrWhiteSpace(filtro) ? null : filtro
            );

            if (reservas.Count == 0)
            {
                Console.WriteLine("\nNo hay reservas próximas que coincidan con el criterio.");
                return;
            }

            Console.WriteLine($"\nSe encontraron {reservas.Count} reservas próximas:\n");

            int contador = 1;
            foreach (var r in reservas)
            {
                Console.WriteLine($"{contador++}. {r.FechaTurno:dd/MM/yyyy} {r.HoraInicio} - {r.HoraFin}");
                Console.WriteLine($"   Paciente: {r.Paciente.Nombre} {r.Paciente.Apellido}");
                Console.WriteLine($"   Motivo: {r.MotivoConsulta}");
                Console.WriteLine($"   Estado: {r.EstadoReserva}");
                Console.WriteLine();
            }

            Console.WriteLine("=========================================");
            Console.WriteLine("Fin de la consulta.");*/
        }
    }
}
