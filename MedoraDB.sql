--================================================================================

----- Creación de la Base de Datos 'MedoraDB' ================================================================================

CREATE DATABASE MedoraDB;
GO

USE MedoraDB;
GO

----- Estructura ================================================================================
----- Tablas ====================================================================================
    -- Especialidad -----------------------------------------------------------------------------
        CREATE TABLE Especialidad (
          id_especialidad INT IDENTITY(1,1),
          nombre VARCHAR(50) NOT NULL,

          CONSTRAINT PK_Especialidad PRIMARY KEY (id_especialidad),
          CONSTRAINT UK_Especialidad_Unica UNIQUE (nombre)
        );

        INSERT INTO Especialidad (nombre)
        VALUES ('Cardiología'), ('Pediatria'), ('Dermatologia'), ('Ginecología'), ('Urología'), ('Traumatologia'), ('Clinica Medica'); 
        GO

    -- Rol --------------------------------------------------------------------------------------
        CREATE TABLE Rol (
          id_rol INT NOT NULL,
          nombre VARCHAR(30) NOT NULL,

          CONSTRAINT PK_Rol PRIMARY KEY (id_rol)
        );

        INSERT INTO Rol (id_rol, nombre)
        VALUES (1, 'Administrador'), (2, 'Médico'), (3, 'Recepcionista');
        GO

    -- Usuario ----------------------------------------------------------------------------------
        CREATE TABLE Usuario (
          id_usuario INT IDENTITY(1,1),
          nombre VARCHAR(50) NOT NULL,
          apellido VARCHAR(50) NOT NULL,
          dni VARCHAR(15) NOT NULL,
          email VARCHAR(50) NOT NULL,
          telefono VARCHAR(20) NOT NULL,
          contraseña_hash VARCHAR(100) NOT NULL,
          estado_usuario BIT DEFAULT 1,
          id_especialidad INT NULL,
          id_rol INT NOT NULL,

          CONSTRAINT PK_Usuario PRIMARY KEY (id_usuario),
          CONSTRAINT FK_Especialidad_Medico FOREIGN KEY (id_especialidad) REFERENCES Especialidad(id_especialidad),
          CONSTRAINT FK_Rol_Usuario FOREIGN KEY (id_rol) REFERENCES Rol(id_rol),
          CONSTRAINT UK_Dni_Usuario UNIQUE (dni),
          CONSTRAINT UK_Email_Usuario UNIQUE (email),
          CONSTRAINT UK_Telefono_Usuario UNIQUE (telefono),
        );
        -- Administradora
        INSERT INTO Usuario (nombre, apellido, dni, email, telefono, contraseña_hash, id_especialidad, id_rol)
        VALUES ('Ramona', 'Rodriguez', '203912342', 'adm@mail.com', '392183012', '673d190b758967621da243f06c350ce68be4276174dc886560239fea923d4a5a', NULL, 1);

        -- Médico
        INSERT INTO Usuario (nombre, apellido, dni, email, telefono, contraseña_hash, id_especialidad, id_rol)
        VALUES ('Juan', 'Pérez', '302139412', 'med@mail.com', '388213021', '673d190b758967621da243f06c350ce68be4276174dc886560239fea923d4a5a', 7, 2);

        -- Recepcionista
        INSERT INTO Usuario (nombre, apellido, dni, email, telefono, contraseña_hash, id_especialidad, id_rol)
        VALUES ('Lorena', 'Mettini', '32921921', 'recep@mail.com', '32193042', '673d190b758967621da243f06c350ce68be4276174dc886560239fea923d4a5a', NULL, 3);

        GO

    -- Día --------------------------------------------------------------------------------------
        CREATE TABLE Día (
          id_dia INT NOT NULL,
          nombre VARCHAR(15) NOT NULL,

          CONSTRAINT PK_Dia PRIMARY KEY (id_dia)
        );

        INSERT INTO Día (id_dia, nombre)
        VALUES (1, 'Lunes'), (2, 'Martes'), (3, 'Miércoles'), (4, 'Jueves'), (5, 'Viernes'), (6, 'Sábado');
        GO

    -- Bloque Horario ----------------------------------------------------------------------------
        CREATE TABLE Bloque_Horario (
          id_bloque INT IDENTITY(1,1) PRIMARY KEY,
          fecha_inicio DATE NOT NULL,
          fecha_fin DATE NOT NULL,
          hora_inicio TIME NOT NULL,
          hora_fin TIME NOT NULL,
          duracion_turnos INT NOT NULL,
          activo BIT DEFAULT 1,
          id_medico INT NOT NULL,
          id_dia INT NOT NULL,

          CONSTRAINT FK_Usuario_Bloque FOREIGN KEY (id_medico) REFERENCES Usuario(id_usuario),
          CONSTRAINT FK_Dia_Bloque FOREIGN KEY (id_dia) REFERENCES Día(id_dia),
          CONSTRAINT CK_DuracionNoNula CHECK (duracion_turnos > 0),
          CONSTRAINT CK_FechaValida CHECK (fecha_inicio < fecha_fin),
          CONSTRAINT CK_DuracionMinimaDeJornada CHECK (datediff (minute, [hora_inicio], [hora_fin]) >= [duracion_turnos])
        );
        GO

    -- Estado de Turno ---------------------------------------------------------------------------
        CREATE TABLE Estado_Turno (
          id_estado_turno INT NOT NULL,
          nombre VARCHAR(20) NOT NULL,

          CONSTRAINT PK_Estado_Turno PRIMARY KEY (id_estado_turno)
        );

        INSERT INTO Estado_Turno (id_estado_turno, nombre)
        VALUES (1, 'Disponible'), (2, 'Reservado'), (3, 'Inactivo');
        GO

    -- Turno ----------------------------------------------------------------------------
        CREATE TABLE Turno (
          id_turno INT IDENTITY(1,1),
          fecha_turno DATE NOT NULL,
          hora_inicio TIME NOT NULL,
          hora_fin TIME NOT NULL,
          id_bloque INT NOT NULL,
          id_estado_turno INT NOT NULL DEFAULT 1,

          CONSTRAINT PK_Turno PRIMARY KEY (id_turno),
          CONSTRAINT FK_Bloque_Turno FOREIGN KEY (id_bloque) REFERENCES Bloque_Horario(id_bloque),
          CONSTRAINT FK_Estado_Turno FOREIGN KEY (id_estado_turno) REFERENCES Estado_Turno(id_estado_turno),
          CONSTRAINT CK_HorarioValido CHECK (hora_inicio < hora_fin)
        );
        GO

    -- Estado de Reserva ----------------------------------------------------------------
        CREATE TABLE Estado_Reserva (
          id_estado INT NOT NULL,
          nombre VARCHAR(20) NOT NULL,

          CONSTRAINT PK_Estado_Reserva PRIMARY KEY (id_estado)
        );

        INSERT INTO Estado_Reserva (id_estado, nombre)
        VALUES (1, 'Activa'), (2, 'Cancelada'), (3, 'Atendida');
        GO

    -- Obra Social ----------------------------------------------------------------------
        CREATE TABLE Obra_Social (
            id_obra_social INT IDENTITY(1,1),
            nombre VARCHAR(100) NOT NULL,

            CONSTRAINT PK_Obra_Social PRIMARY KEY (id_obra_social),
            CONSTRAINT UK_ObraSocial_Unica UNIQUE (nombre)
        ); 

        INSERT INTO Obra_Social (nombre) VALUES
        ('IOSCOR'),
        ('PAMI'),
        ('OSDE'),
        ('SWISS MEDICAL');

        GO

    -- Paciente ----------------------------------------------------------------

        CREATE TABLE Paciente (
          id_paciente INT IDENTITY(1,1),
          nombre VARCHAR(50) NOT NULL,
          apellido VARCHAR(50) NOT NULL,
          dni VARCHAR(15) NOT NULL,
          email VARCHAR(50) NOT NULL,
          telefono VARCHAR(20) NOT NULL,
          fecha_nacimiento DATE NOT NULL,
          id_obra_social INT,

          CONSTRAINT PK_Paciente PRIMARY KEY (id_paciente),
          CONSTRAINT UK_Dni_Paciente UNIQUE (dni),
          CONSTRAINT UK_Email_Paciente UNIQUE (email),
          CONSTRAINT UK_Telefono_Paciente UNIQUE (telefono),
          CONSTRAINT FK_ObraSocial_Paciente FOREIGN KEY (id_obra_social) REFERENCES Obra_Social(id_obra_social)
        );
        GO

    -- Motivo de Consulta --------------------------------------------------------
        CREATE TABLE Motivo_Consulta (
          id_motivo_consulta INT IDENTITY(1,1),
          descripcion VARCHAR(255) NOT NULL,
          id_especialidad INT NOT NULL,

          CONSTRAINT PK_Motivo_Consulta PRIMARY KEY (id_motivo_consulta),
          CONSTRAINT FK_Especialidad_MotivoConsulta FOREIGN KEY (id_especialidad) REFERENCES Especialidad(id_especialidad)
        );
        

        -- Insert para Cardiologia --
        INSERT INTO Motivo_Consulta 
        VALUES  ('Dolor de Pecho',1), 
                ('Mareos',1), 
                ('Falta de Aire',1), 
                ('Taquicardia',1), 
                ('Arritmia',1);

        --Insert para Pediatria -- 
        INSERT INTO Motivo_Consulta 
        VALUES  ('Fiebre',2), 
                ('Diarrea',2), 
                ('Constipacion',2), 
                ('Vomitos',2), 
                ('Dificultad para Caminar',2);

        --Insert para Dermatologia -- 
        INSERT INTO Motivo_Consulta 
        VALUES  ('Quemaduras',3), 
                ('Urticarias',3), 
                ('Acne',3), 
                ('Picaduras',3), 
                ('Despigmentacion',3); 

        -- Ginecología
        INSERT INTO Motivo_Consulta 
        VALUES  ('Control Prenatal', 4), 
                ('Infección Urinaria', 4), 
                ('Dolor Pélvico', 4), 
                ('Irregularidad Menstrual', 4), 
                ('Menopausia', 4);

        -- Urología
        INSERT INTO Motivo_Consulta 
        VALUES  ('Cálculos Renales', 5), 
                ('Infección Urinaria', 5), 
                ('Disfunción Eréctil', 5), 
                ('Control Prostático', 5), 
                ('Hematuria', 5);

        --Insert para Traumatologia --
        INSERT INTO Motivo_Consulta 
        VALUES  ('Fractura',6), 
                ('Dolor Lumbar',6), 
                ('Artrosis',6), 
                ('Dolor de Cervicales',6), 
                ('Vertigo',6); 

        --Insert para Clinica Medica -- 
        INSERT INTO Motivo_Consulta 
        VALUES  ('Dolor Abdominal',7), 
                ('Cefaleas',7), 
                ('Sintoma Gastrointestinal',7), 
                ('Hipoglucemia',7), 
                ('Hipertension Arterial',7);
        GO

    -- Reserva ------------------------------------------------------------------
        CREATE TABLE Reserva (
          id_reserva INT IDENTITY(1,1),
          diagnostico VARCHAR(500) DEFAULT NULL,
          id_estado INT NOT NULL DEFAULT 1,
          id_turno INT NOT NULL,
          id_paciente INT NOT NULL,
          id_motivo_consulta INT NOT NULL,

          CONSTRAINT PK_Reserva PRIMARY KEY (id_reserva),
          CONSTRAINT FK_Estado_Reserva FOREIGN KEY (id_estado) REFERENCES Estado_Reserva(id_estado),
          CONSTRAINT FK_Turno_Reserva FOREIGN KEY (id_turno) REFERENCES Turno(id_turno),
          CONSTRAINT FK_Paciente_Reserva FOREIGN KEY (id_paciente) REFERENCES Paciente(id_paciente),
          CONSTRAINT FK_Motivo_Reserva FOREIGN KEY (id_motivo_consulta) REFERENCES Motivo_Consulta(id_motivo_consulta)
        );
        GO
-----------------------------------------------------------------------------------------------------

----- Procedimientos ================================================================================
----- Recepcionista =================================================================================
----- Procedimiento #01: Registrar Paciente ---------------------------------------------------------
              CREATE OR ALTER PROCEDURE rec_RegistrarPaciente
                @Nombre VARCHAR(50),
                @Apellido VARCHAR(50),
                @Dni VARCHAR(15),
                @Email VARCHAR(100),
                @Telefono VARCHAR(20),
                @FechaNacimiento DATE,
                @IdObraSocial INT = NULL
            AS
            BEGIN
                INSERT INTO Paciente (nombre, apellido, dni, email, telefono, fecha_nacimiento, id_obra_social)
                VALUES (@Nombre, @Apellido, @Dni, @Email, @Telefono, @FechaNacimiento, @IdObraSocial);
            END;
            GO
                
                --------------------------------------------
                /* Ejemplo de uso: EXEC rec_RegistrarPaciente
                                        @Nombre='Juan',
                                        @Apellido='Pérez',
                                        @Dni='12345678', 
                                        @Email='jp@gmail.com', 
                                        @Telefono='3777897856';*/


--------- Procedimiento #01.5: Verificar si existe ya el paciente ---------------------------------
CREATE OR ALTER PROCEDURE rec_VerificarPacienteExistente
    @Dni VARCHAR(15),
    @Email VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    -- Comprueba si existe algún paciente con ese DNI o Email (si el email no es nulo/vacío)
    IF EXISTS (
        SELECT 1 FROM Paciente 
        WHERE dni = @Dni OR (email = @Email AND @Email <> '')
    )
        SELECT 1 AS Existe;
    ELSE
        SELECT 0 AS Existe;
END
GO


-----------------------------------------------------------------------------------------------------
----- Procedimiento #02: Listar pacientes con opción de filtrado ------------------------------------
              CREATE OR ALTER PROCEDURE rec_ListarPacientes
                    @Filtro VARCHAR(50) = NULL
                AS
                BEGIN
                    SET NOCOUNT ON;

                    SELECT
                        P.id_paciente,
                        P.nombre,
                        P.apellido,
                        P.dni,
                        P.telefono,
                        P.email,
                        YEAR(CAST(GETDATE() AS DATE)) - YEAR(P.fecha_nacimiento) AS edad,
                        CASE
                          WHEN OS.nombre IS NULL THEN 'No posee' -- Si el nombre de la obra social es NULL se muestra ese mensaje.
                          ELSE OS.nombre                         -- De lo contrario, muestra el nombre de la obra social
                        END AS obra_social,
                        P.apellido + ', ' + P.nombre + ' (' + P.dni + ')' AS DisplayText
                    FROM Paciente P
                    LEFT JOIN Obra_Social OS ON P.id_obra_social = OS.id_obra_social
                    WHERE
                        @Filtro IS NULL -- Si es null, la evaluación dará verdadera y mostrará todas las tuplas.
                        OR UPPER(P.nombre) + ' ' + UPPER(P.apellido) LIKE '%' + UPPER(@Filtro) + '%'   -- Ejemplo, si P.nombre = Juan y @Filtro = Juan, realiza: UPPER(Juan) LIKE %UPPER(Juan)%
                                                                                                       --                                                        JUAN LIKE %JUAN% (Esto evalúa true y va a estar en la lista)
                        OR P.dni LIKE '%' + @Filtro + '%'                    -- '%' Se usa para buscar en cualquier parte de una cadena.
                    ORDER BY P.apellido, P.nombre;                           -- Por ejemplo, podría buscar '%ua%' y me aparecería 'Juan' ya que contiene en el medio esos caracteres.
                END;                                                         -- TRIM se utiliza para eliminar espacios, por ejemplo si tiene apellido doble, solo buscará las coincidencias 
                GO                                                           -- que coincidan con los caracteres del apellido, ignorando si existe un espacio.
                
                --------------------------------------------
                /* Ejemplo de uso: EXEC rec_ListarPacientes; -- Muestra todos los pacientes
                                   EXEC rec_ListarPacientes @Filtro = 'adrián aguilar'; -- Muestra pacientes que coincidan con el nombre 'juan lop'
                                   EXEC rec_ListarPacientes @Filtro = '45678900'; -- Muestra al paciente con DNI 45678900*/
-----------------------------------------------------------------------------------------------------
----- Procedimiento #03: Flujo de reservar turno ----------------------------------------------------
    ----  3.1: Búsqueda de médico para reservar un turno
              CREATE OR ALTER PROCEDURE rec_BuscarMedico
                    @IdEspecialidad INT = NULL,
                    @TextoBusquedaNombre VARCHAR(50) = NULL
                AS
                BEGIN
                    SET NOCOUNT ON;

                    SELECT
                        U.id_usuario AS id_usuario,
                        U.apellido + ', ' + U.nombre AS NombreCompleto,
                        E.nombre AS Especialidad
                    FROM Usuario U
                    JOIN Especialidad E ON U.id_especialidad = E.id_especialidad
                    WHERE
                        U.id_rol = 2 -- Médico
                        AND U.estado_usuario = 1
                        AND (@IdEspecialidad IS NULL OR U.id_especialidad = @IdEspecialidad)
                        AND (
                            @TextoBusquedaNombre IS NULL
                            OR UPPER(U.nombre) + ' ' + UPPER(U.apellido) LIKE '%' + UPPER(@TextoBusquedaNombre) + '%'
                        )
                    ORDER BY U.apellido, U.nombre;
                END;
                GO
                
                /* Ejemplo de primer paso:
                EXEC rec_BuscarMedico @IdEspecialidad = 2;
                */
    ---- 3.2: Mostrar turnos disponibles para un médico seleccionado con diferentes filtrados opcionales
               CREATE OR ALTER PROCEDURE rec_ObtenerTurnosDisponiblesConMedico
                    @IdMedico INT,
                    @FechaInicio DATE = NULL,
                    @FechaFin DATE = NULL,
                    @IdDia INT = NULL
                AS
                BEGIN
                    SET NOCOUNT ON;

                    SELECT
                        T.id_turno AS id_turno,
                         ISNULL(U.nombre, '') + ' ' + ISNULL(U.apellido, '') AS Medico,
                        T.fecha_turno,
                        D.nombre AS DiaSemana,
                        T.hora_inicio,
                        T.hora_fin,
                        ET.nombre AS EstadoTurno
                    FROM Turno T
                    JOIN Bloque_Horario BH ON T.id_bloque = BH.id_bloque
                    JOIN Día D ON BH.id_dia = D.id_dia
                    JOIN Usuario U ON BH.id_medico = U.id_usuario
                    JOIN Estado_Turno ET ON ET.id_estado_turno = T.id_estado_turno
                    WHERE
                        BH.id_medico = @IdMedico
                        AND T.id_estado_turno = 1 -- solo disponibles
                        AND T.fecha_turno >= CAST(GETDATE() AS DATE)
                        AND BH.fecha_fin >= CAST(GETDATE() AS DATE)
                        AND (@FechaInicio IS NULL OR T.fecha_turno >= @FechaInicio)
                        AND (@FechaFin IS NULL OR T.fecha_turno <= @FechaFin)
                        AND (@IdDia IS NULL OR BH.id_dia = @IdDia)
                    ORDER BY T.fecha_turno, T.hora_inicio;
                END;
                GO
                
                /* Ejemplo de segundo paso:
                DECLARE @IdMedico INT;

                -- Asignamos a una variable el valor del médico que buscamos
                SELECT @IdMedico = U.id_usuario 
                FROM Usuario U 
                WHERE UPPER(U.apellido) LIKE UPPER('mettini');

                -- Pasamos esa variable como parámetro para el segundo paso del flujo
                EXEC rec_ObtenerTurnosDisponibles
                    @IdMedico = 3,
                    @FechaInicio = '2025-11-01',
                    @FechaFin = '2025-11-30', -- Ver turnos de la primer semana de noviembre
                    @IdDia = NULL;
                */

    ---- 3.3: Función que inserta la reserva, cambiando el estado de turno a ocupado
              CREATE OR ALTER PROCEDURE rec_RegistrarReserva
                    @IdTurno INT,
                    @IdPaciente INT,
                    @IdMotivoConsulta INT
                AS
                BEGIN
                    SET NOCOUNT ON;

                    -- Validar que el turno esté disponible
                    IF NOT EXISTS (SELECT 1 FROM Turno WHERE id_turno = @IdTurno AND id_estado_turno = 1)
                    BEGIN
                        RAISERROR('El turno no está disponible o ya fue reservado.', 16, 1);
                        RETURN;
                    END;

                    -- Insertar la reserva
                    INSERT INTO Reserva (id_turno, id_paciente, id_motivo_consulta, id_estado)
                    VALUES (@IdTurno, @IdPaciente, @IdMotivoConsulta, 1); -- 1 = Activa

                    -- Actualizar estado del turno
                    UPDATE Turno
                    SET id_estado_turno = 2 -- Reservado
                    WHERE id_turno = @IdTurno;
                END;
                GO

                /*Ejemplo de tercer paso del flujo de reserva:
                -- Seleccionamos el turno con id 33 de los resultados anteriores
                SELECT
                    MC.id_motivo_consulta,
                    MC.descripcion
                FROM Motivo_Consulta MC
                JOIN Usuario U ON MC.id_especialidad = U.id_especialidad
                WHERE UPPER(U.apellido) LIKE UPPER('Mettini'); -- Para ver qué posibles motivos de consulta se le pueden asignar al paciente

                EXEC rec_RegistrarReserva
                    @IdTurno = 7,
                    @IdPaciente = 3,
                    @MotivoConsulta = 2; 
                */
            
----------------------------------------------------------------------------------------------------
----- Procedimiento #04: Listar Reservas de Pacientes con Filtros ----------------------------------
              CREATE OR ALTER PROCEDURE rec_ListarReservasPacientes
                    @Filtro VARCHAR(50) = NULL
                AS
                BEGIN
                    SET NOCOUNT ON;

                    SELECT  
                        R.id_reserva,
                        P.apellido + ', ' + P.nombre AS Paciente,
                        P.dni AS DniPaciente,
                        T.fecha_turno,
                        T.hora_inicio,
                        U.apellido + ', ' + U.nombre AS Medico,
                        ER.nombre AS EstadoReserva
                    FROM Reserva R
                    JOIN Turno T ON R.id_turno = T.id_turno
                    JOIN Paciente P ON R.id_paciente = P.id_paciente
                    INNER JOIN Estado_Reserva ER ON R.id_estado = ER.id_estado
                    INNER JOIN Bloque_Horario BH ON T.id_bloque = BH.id_bloque
                    INNER JOIN Usuario U ON BH.id_medico = U.id_usuario
                    WHERE 
                        R.id_estado = 1 
                        AND (T.fecha_turno > CAST(GETDATE() AS DATE) OR (T.fecha_turno = CAST(GETDATE() AS DATE) AND T.hora_inicio >= CAST(GETDATE() AS TIME)))
        
                        -- ===== LOGICA DE FILTRO MEJORADA =====
                        AND (
                            @Filtro IS NULL OR @Filtro = ''
                            -- Búsqueda por Paciente
                            OR P.nombre LIKE '%' + @Filtro + '%'
                            OR P.apellido LIKE '%' + @Filtro + '%'
                            OR P.dni LIKE '%' + @Filtro + '%'
                            -- Búsqueda por Médico
                            OR U.nombre LIKE '%' + @Filtro + '%'
                            OR U.apellido LIKE '%' + @Filtro + '%'
                        )
                        ---------------------------------------
                    ORDER BY T.fecha_turno ASC, T.hora_inicio ASC;
                END;
                GO
                
                /* Ejemplo 
                EXEC rec_ListarReservasPacientes;
                */
----------------------------------------------------------------------------------------------------
----- Procedimiento #05: Cancelar una reserva, cambiando su estado de reserva y liberando el turno -
                CREATE OR ALTER PROCEDURE rec_CancelarReserva
                    @IdReserva INT
                AS
                BEGIN
                    SET NOCOUNT ON;

                    DECLARE @IdTurno INT;

                    IF NOT EXISTS (SELECT 1 FROM Reserva WHERE id_reserva = @IdReserva AND id_estado = 1)
                    BEGIN
                        RAISERROR('La reserva no existe o ya fue cancelada/atendida.', 16, 1);
                        RETURN;
                    END;

                    -- Obtener el turno asociado a la reserva
                    SELECT @IdTurno = id_turno FROM Reserva WHERE id_reserva = @IdReserva;

                    -- Cambiar el estado de la reserva a "Cancelada" (2)
                    UPDATE Reserva
                    SET id_estado = 2
                    WHERE id_reserva = @IdReserva;

                    -- Cambiar el estado del turno a "Disponible" (1)
                    UPDATE Turno
                    SET id_estado_turno = 1
                    WHERE id_turno = @IdTurno;

                    PRINT 'La reserva fue cancelada correctamente y el turno se liberó.';
                END;
                GO

                /* Ejemplo
                EXEC rec_CancelarReserva
                    @IdReserva = 8;
                */
                    
-------------------------------------------------------------------------------------------------------
--- Procedimiento #06: Procedimiento que muestra estadísticas generales sobre los pacientes que realizaron
                    -- reservas dentro de un rango de fechas determinado. Incluye promedio de edad, distribución etaria
                    -- y porcentaje de pacientes con o sin obra social.
                CREATE OR ALTER PROCEDURE rec_EstadisticaPacientes
                    @FechaInicio DATE,
                    @FechaFin DATE
                AS
                BEGIN
                    SET NOCOUNT ON;

                    -- 1) Descripción general:
                    -- Este procedimiento analiza el perfil poblacional de los pacientes que realizaron reservas
                    -- dentro del rango de fechas establecido. Se calcula:
                    --  - Promedio de edad
                    --  - Distribución por rangos de edad (menores, adultos, mayores)
                    --  - Porcentaje de pacientes con y sin obra social.

                    -- 2) CTE: obtener pacientes únicos con reserva en el rango.
                    WITH PacientesReserva AS (
                        SELECT DISTINCT
                            P.id_paciente,
                            P.fecha_nacimiento,
                            P.id_obra_social,
                            DATEDIFF(YEAR, P.fecha_nacimiento, GETDATE()) AS Edad
                        FROM Paciente P
                        INNER JOIN Reserva R ON P.id_paciente = R.id_paciente
                        INNER JOIN Turno T ON R.id_turno = T.id_turno
                        WHERE T.fecha_turno BETWEEN @FechaInicio AND @FechaFin
                    )

                    -- 3) Cálculo de agregados principales
                    SELECT
                        ISNULL(CAST(AVG(Edad * 1.0) AS DECIMAL(5,2)), 0.00) AS [Promedio de Edad],
        
                        ISNULL(SUM(CASE WHEN Edad < 18 THEN 1 ELSE 0 END), 0) AS [Menores (<18)],
                        ISNULL(SUM(CASE WHEN Edad BETWEEN 18 AND 64 THEN 1 ELSE 0 END), 0) AS [Adultos (18-64)],
                        ISNULL(SUM(CASE WHEN Edad >= 65 THEN 1 ELSE 0 END), 0) AS [Mayores (65+)],
        
                        ISNULL(CAST(SUM(CASE WHEN Edad < 18 THEN 1 ELSE 0 END) * 100.0 / NULLIF(COUNT(*), 0) AS DECIMAL(5,2)), 0.00) AS [Porcentaje de Menores],
                        ISNULL(CAST(SUM(CASE WHEN Edad BETWEEN 18 AND 64 THEN 1 ELSE 0 END) * 100.0 / NULLIF(COUNT(*), 0) AS DECIMAL(5,2)), 0.00) AS [Porcentaje de Adultos],
                        ISNULL(CAST(SUM(CASE WHEN Edad >= 65 THEN 1 ELSE 0 END) * 100.0 / NULLIF(COUNT(*), 0) AS DECIMAL(5,2)), 0.00) AS [Porcentaje de Mayores],
        
                        ISNULL(SUM(CASE WHEN id_obra_social IS NOT NULL THEN 1 ELSE 0 END), 0) AS [Pacientes con Obra Social],
                        ISNULL(SUM(CASE WHEN id_obra_social IS NULL THEN 1 ELSE 0 END), 0) AS [Pacientes sin Obra Social],
        
                        ISNULL(CAST(SUM(CASE WHEN id_obra_social IS NOT NULL THEN 1 ELSE 0 END) * 100.0 / NULLIF(COUNT(*), 0) AS DECIMAL(5,2)), 0.00) AS [Porcentaje Con Obra Social],
                        ISNULL(CAST(SUM(CASE WHEN id_obra_social IS NULL THEN 1 ELSE 0 END) * 100.0 / NULLIF(COUNT(*), 0) AS DECIMAL(5,2)), 0.00) AS [Porcentaje Sin Obra Social]

                    FROM PacientesReserva;
                END;
                GO

                /* Ejemplo de uso:
                EXEC rec_EstadisticaPacientes
                    @FechaInicio = '2025-11-01',
                    @FechaFin = '2025-11-30';
                */
-------------------------------------------------------------------------------------------------------
--- Procedimiento #07: Procedimiento que muestra el ranking de las obras sociales más utilizadas
                    -- por los pacientes que realizaron reservas dentro de un rango de fechas, indicando su
                    -- participación porcentual respecto al total de pacientes con obra social.
                CREATE OR ALTER PROCEDURE rec_EstadisticaObrasSociales
                    @FechaInicio DATE,
                    @FechaFin DATE
                AS
                BEGIN
                    SET NOCOUNT ON;

                    -- 1) Descripción general:
                    -- Este procedimiento analiza la distribución de los pacientes con obra social
                    -- que realizaron reservas dentro del rango de fechas indicado.
                    -- Devuelve un ranking de obras sociales y su porcentaje sobre el total.

                    -- 2) CTE: obtener pacientes con obra social y reserva en el rango.
                    WITH PacientesObra AS (
                        SELECT DISTINCT
                            P.id_paciente,
                            ISNULL(OS.nombre, 'Particular') AS ObraSocial
                        FROM Paciente P
                        INNER JOIN Reserva R ON P.id_paciente = R.id_paciente
                        INNER JOIN Turno T ON R.id_turno = T.id_turno
                        LEFT JOIN Obra_Social OS ON P.id_obra_social = OS.id_obra_social
                        WHERE T.fecha_turno BETWEEN @FechaInicio AND @FechaFin
                    )

                    -- 3) Ranking de obras sociales por cantidad de pacientes
                    SELECT
                        ObraSocial AS [Obra Social],
                        COUNT(*) AS [Cantidad de Pacientes],
                        CAST(COUNT(*) * 100.0 / SUM(COUNT(*)) OVER() AS DECIMAL(6,2)) AS [Porcentaje sobre Total]
                    FROM PacientesObra
                    GROUP BY ObraSocial
                    ORDER BY [Cantidad de Pacientes] DESC;
                END;
                GO

                /* Ejemplo de uso:
                EXEC rec_EstadisticaObrasSociales
                    @FechaInicio = '2025-11-01',
                    @FechaFin = '2025-11-30';
                */
-------------------------------------------------------------------------------------------------------
--==================================================================================================
----- Médico =======================================================================================
----- Procedimiento #01: Crear bloques horarios (con sus respectivos turnos) -----------------------
    --- 1.1: Crear un bloque horario 
                CREATE OR ALTER PROCEDURE med_CrearBloqueHorario
                    @FechaInicio DATE,
                    @FechaFin DATE,
                    @HoraInicio TIME,
                    @HoraFin TIME,
                    @DuracionTurnos INT,
                    @IdMedico INT,
                    @IdDia INT
                AS
                BEGIN
                    SET NOCOUNT ON;

                    -- Validar solapamiento con otros bloques del mismo médico y día
                    IF EXISTS (
                        SELECT 1
                        FROM Bloque_Horario bh
                        WHERE bh.id_medico = @IdMedico
                          AND bh.activo = 1 -- Debe ser un bloque en vigencia, si está 'eliminado', no importa el solapamiento.
                          AND bh.id_dia = @IdDia -- Si un mismo médico intenta crear el bloque en un mismo día,
                          AND ( -- (Entonces se debe ver si coinciden en rango de fechas. Ej: Se tiene guardado [1/10 - 31/10], y se intenta insertar [15/10 - 15/11] ó [15/09 - 15/10])
                                -- Rango de fechas superpuesto
                                @FechaInicio < bh.fecha_fin -- Y si la fecha de inicio que se intenta insertar es anterior a una fecha de fin de un bloque guardado,
                                AND @FechaFin > bh.fecha_inicio -- Y la fecha de fin que se intenta insertar es posterior a la fecha de inicio de un bloque guardado,
                              ) -- (Si un mismo médico carga un bloque que tenga coincidencia en día y se solapan en fechas, hay que comprobar si también se solapa en horario
                                -- (Ya que podría darse el caso de que quiera cargar en el mismo rango de fechas un bloque en la mañana y otro en la tarde)).
                          AND (
                                -- Rango de horas superpuesto
                                @HoraInicio < bh.hora_fin -- Y la hora de inicio que se intenta insertar es anterior a la hora de fin de un bloque,
                                AND @HoraFin > bh.hora_inicio -- Y la hora de fin que se intenta insertar es posterior a la hora de inicio de un bloque.
                              ) -- (Entonces se tiene que coinciden en horarios. Ej: Se tiene guardado [8:00 - 12:00] y se intenta insertar [9:00 a 11:00]).
                    )           -- Si se cumplen todas las condiciones, existe solapamiento y no debe permitirse insertar el bloque, mostrando el mensaje de error.
                    BEGIN
                        RAISERROR('El médico ya tiene un bloque en ese rango de fechas y horas para ese día.', 16, 1);
                        RETURN;
                    END;

                    -- Si no hay conflicto, insertar el bloque
                    INSERT INTO Bloque_Horario (
                        fecha_inicio,
                        fecha_fin,
                        hora_inicio,
                        hora_fin,
                        duracion_turnos,
                        activo,
                        id_medico,
                        id_dia
                    )
                    VALUES (
                        @FechaInicio,
                        @FechaFin,
                        @HoraInicio,
                        @HoraFin,
                        @DuracionTurnos,
                        1,              -- Activo por defecto
                        @IdMedico,
                        @IdDia
                    );

                    PRINT 'Bloque horario creado correctamente.';
                END;
                GO

                /* Ejemplos:
                EXEC med_CrearBloqueHorario
                    @FechaInicio = '2026-11-01',
                    @FechaFin = '2026-11-30',
                    @HoraInicio = '08:00',
                    @HoraFin = '12:00',
                    @DuracionTurnos = 30,
                    @IdMedico = 2,
                    @IdDia = 1; -- Lunes
                */
    --- 1.2: Procedimiento que calcula e inserta todos los turnos de un bloque dado.
                CREATE OR ALTER PROCEDURE med_GenerarTurnosPorBloque
                    @IdBloque INT
                AS
                BEGIN
                    SET NOCOUNT ON;
                    SET DATEFIRST 1;

                    DECLARE 
                        @FechaInicio DATE,
                        @FechaFin DATE,
                        @HoraInicio TIME,
                        @HoraFin TIME,
                        @DuracionTurnos INT,
                        @IdMedico INT,
                        @IdDia INT;

                    SELECT 
                        @FechaInicio = BH.fecha_inicio,
                        @FechaFin = BH.fecha_fin,
                        @HoraInicio = BH.hora_inicio,
                        @HoraFin = BH.hora_fin,
                        @DuracionTurnos = BH.duracion_turnos,
                        @IdMedico = BH.id_medico,
                        @IdDia = BH.id_dia
                    FROM Bloque_Horario BH
                    WHERE BH.id_bloque = @IdBloque;

                    DECLARE @FechaActual DATE = @FechaInicio;

                    WHILE @FechaActual <= @FechaFin -- Este bucle itera de día en día, comenzando por @FechaInicio 
                    BEGIN                           -- y continuando mientras la fecha actual sea anterior o igual a la fecha de fin del bloque @FechaFin.
                        IF DATEPART(WEEKDAY, @FechaActual) = @IdDia -- Al avanzar entre día en día dentro del rango, compara si esa fecha es el día que fue seleccionado en el bloque.
                        BEGIN
                            DECLARE @HoraActual TIME = @HoraInicio; -- Se declara una variable para establecer el horario de asignación de inicio de cada turno.

                            WHILE DATEADD(MINUTE, @DuracionTurnos, @HoraActual) <= @HoraFin -- Bucle que itera hasta que la suma entre la duración de turno
                            BEGIN                                                           --  y la hora de inicio del turno tenga como resultado la hora de fin.
                                INSERT INTO Turno (fecha_turno, hora_inicio, hora_fin, id_bloque, id_estado_turno)
                                VALUES (
                                    @FechaActual,
                                    @HoraActual,
                                    DATEADD(MINUTE, @DuracionTurnos, @HoraActual), -- La hora de fin es sumar la duración del turno a la hora actual de inicio de turno.
                                    @IdBloque,
                                    1 -- Los turnos se asignan con estado_turno = 1 (disponible)
                                );
                                SET @HoraActual = DATEADD(MINUTE, @DuracionTurnos, @HoraActual); -- Se modifica la hora actual de inicio de turno para que el fin de un turno sea el inicio de otro.
                            END
                        END
                        SET @FechaActual = DATEADD(DAY, 1, @FechaActual); -- Se modifica la fecha que recorre el bucle, que aumenta de 1 en 1
                    END                                                   -- (Se puede optimzar para que se modifique de a 7, ya que pasan 7 días para que vuelva a coincidir un mismo día
                END;                                                      --                      (importante saber que funcionaría solo luego de que la condición inicial sea verdadera)).
                GO
                
    --- 1.3: Trigger que automatiza el proceso anterior, para que se realice cada vez que se inserta un nuevo bloque válido.
                CREATE OR ALTER TRIGGER trg_AutoGenerarTurnos
                ON Bloque_Horario
                AFTER INSERT
                AS
                BEGIN
                    SET NOCOUNT ON;

                    DECLARE @IdBloque INT;

                    SELECT @IdBloque = id_bloque FROM inserted;

                    EXEC med_GenerarTurnosPorBloque @IdBloque;
                END;
                GO
-------------------------------------------------------------------------------------------------------                
----- Procedimiento #02: Listar bloques horarios con diferentes opciones de filtrado ------------------
                CREATE OR ALTER PROCEDURE med_ListarBloquesMedico
                    @IdMedico INT, -- Obligatorio
                    @FechaDesde DATE = NULL,
                    @FechaHasta DATE = NULL,
                    @HoraDesde TIME = NULL,
                    @HoraHasta TIME = NULL,
                    @IdDia INT = NULL -- Opcionales
                AS
                BEGIN
                    SET NOCOUNT ON;

                    SELECT
                        BH.id_bloque,
                        BH.fecha_inicio as FechaInicio,
                        BH.fecha_fin AS FechaFin,
                        BH.hora_inicio AS HoraInicio,
                        BH.hora_fin AS HoraFin,
                        D.nombre AS DiaSemana
                    FROM Bloque_Horario BH
                    JOIN Día D ON D.id_dia = BH.id_dia
                    WHERE
                        BH.id_medico = @IdMedico
                        AND BH.activo = 1
                        AND (@FechaDesde IS NULL OR BH.fecha_inicio >= @FechaDesde)
                        AND (@FechaHasta IS NULL OR BH.fecha_fin <= @FechaHasta)
                        AND (@HoraDesde IS NULL OR BH.hora_inicio >= @HoraDesde)
                        AND (@HoraHasta IS NULL OR BH.hora_fin <= @HoraHasta)
                        AND (@IdDia IS NULL OR BH.id_dia = @IdDia)
                    ORDER BY
                        BH.fecha_inicio ASC,
                        BH.hora_inicio ASC;
                END;
                GO

                /* Ejemplo
                EXEC med_ListarBloquesMedico
                    @IdMedico = 10,
                    @FechaDesde = NULL,
                    @FechaHasta = NULL,
                    @HoraDesde = '8:00',
                    @HoraHasta = '12:00',
                    @IdDia = NULL;
                */
-------------------------------------------------------------------------------------------------------                
----- Procedimiento #03: Desactivar bloques horarios y sus turnos asociados (menos los reservados) ----
              CREATE OR ALTER PROCEDURE med_EliminarBloqueHorario
                    @IdBloque INT
                AS
                BEGIN
                    SET NOCOUNT ON;

                    -- Validar existencia del bloque
                    IF NOT EXISTS (SELECT 1 FROM Bloque_Horario WHERE id_bloque = @IdBloque AND activo = 1)
                    BEGIN
                        RAISERROR('El bloque no existe o ya está inactivo.', 16, 1);
                        RETURN;
                    END;

                    BEGIN TRY
                        BEGIN TRANSACTION;

                        -- 1. Inactivar turnos disponibles del bloque
                        UPDATE Turno
                        SET id_estado_turno = 3 -- Inactivo
                        WHERE id_bloque = @IdBloque
                          AND id_estado_turno = 1; -- Solo los disponibles

                        -- 2. Marcar el bloque como inactivo
                        UPDATE Bloque_Horario
                        SET activo = 0
                        WHERE id_bloque = @IdBloque;

                        -- 3. Confirmar transacción
                        COMMIT TRANSACTION;

                        PRINT 'Bloque inactivado correctamente. Turnos disponibles pasaron a estado Inactivo.';
                    END TRY
                    BEGIN CATCH
                        ROLLBACK TRANSACTION;
                        DECLARE @ErrorMsg NVARCHAR(4000) = ERROR_MESSAGE();
                        RAISERROR('Error al intentar inactivar el bloque: %s', 16, 1, @ErrorMsg);
                    END CATCH;
                END;
                GO

                /* Ejemplo:
                EXEC med_EliminarBloqueHorario
                    @IdBloque = 2;
                */
-------------------------------------------------------------------------------------------------------                
----- Procedimiento #05: Función que lista las reservas próximas del médico con diferentes filtros ----
                CREATE OR ALTER PROCEDURE med_ListarAgendaMedico
                    @IdMedico INT,                     
                    @FechaDesde DATE = NULL,           
                    @FechaHasta DATE = NULL,           
                    @IdPaciente INT = NULL,            
                    @FiltroPaciente VARCHAR(50) = NULL       
                AS
                BEGIN
                    SET NOCOUNT ON;

                    SELECT
                        R.id_reserva,
                        ER.nombre AS estado_reserva,
                        T.fecha_turno,
                        T.hora_inicio,
                        P.nombre + ' ' + P.apellido AS Paciente,
                        P.dni AS DNI,
                        ISNULL(NULLIF(OS.nombre, ''), 'Particular') AS obra_social,
                        MC.descripcion AS motivo_consulta
                    FROM Reserva R
                    INNER JOIN Turno T ON R.id_turno = T.id_turno
                    INNER JOIN Bloque_Horario BH ON T.id_bloque = BH.id_bloque
                    INNER JOIN Usuario U ON BH.id_medico = U.id_usuario
                    INNER JOIN Paciente P ON R.id_paciente = P.id_paciente
                    INNER JOIN Motivo_Consulta MC ON MC.id_motivo_consulta = R.id_motivo_consulta
                    LEFT JOIN Obra_Social OS ON P.id_obra_social = OS.id_obra_social -- opcional
                    INNER JOIN Estado_Reserva ER ON R.id_estado = ER.id_estado
                    WHERE
                        BH.id_medico = @IdMedico
                        AND (T.fecha_turno > CAST(GETDATE() AS DATE) OR (T.fecha_turno = CAST(GETDATE() AS DATE) AND T.hora_inicio >= CAST(GETDATE() AS TIME))) -- por defecto próximas
                        AND (@FechaDesde IS NULL OR T.fecha_turno >= @FechaDesde)
                        AND (@FechaHasta IS NULL OR T.fecha_turno <= @FechaHasta)
                        AND (@IdPaciente IS NULL OR P.id_paciente = @IdPaciente)
                        AND (@FiltroPaciente IS NULL OR P.dni LIKE '%' + @FiltroPaciente + '%' OR P.apellido LIKE '%' + @FiltroPaciente + '%')
                        AND R.id_estado <> 2
                    ORDER BY
                        T.fecha_turno ASC,
                        T.hora_inicio ASC;
                END;
                GO

                /*Ejemplo
                EXEC med_ListarAgendaMedico
                    @IdMedico = 3,                     
                    @FechaDesde = NULL,           
                    @FechaHasta = NULL,           
                    @IdPaciente = NULL,            
                    @FiltroPaciente = '200'
                 */
-------------------------------------------------------------------------------------------------------                
----- Procedimiento #06: Función que permite acceder al historial del paciente ------------------------
                CREATE OR ALTER PROCEDURE med_ObtenerHistorialPaciente
                    @IdPaciente INT,
                    @FechaDesde DATE = NULL,
                    @FechaHasta DATE = NULL
                AS
                BEGIN
                    SET NOCOUNT ON;

                    SELECT
                        T.fecha_turno AS [Fecha del Turno],

                        MC.descripcion AS [Motivo de Consulta],

                        U.nombre + ' ' + U.apellido AS [Nombre del Médico],
                        Esp.nombre AS Especialidad,
                        R.diagnostico AS Diagnóstico
                    FROM Reserva R
                    INNER JOIN Turno T ON R.id_turno = T.id_turno
                    INNER JOIN Bloque_Horario BH ON T.id_bloque = BH.id_bloque
                    INNER JOIN Usuario U ON BH.id_medico = U.id_usuario
                    INNER JOIN Paciente P ON R.id_paciente = P.id_paciente
                    LEFT JOIN Especialidad Esp ON U.id_especialidad = Esp.id_especialidad
                    INNER JOIN Motivo_Consulta MC ON MC.id_motivo_consulta = R.id_motivo_consulta

                    WHERE
                        R.id_paciente = @IdPaciente
                        AND R.id_estado = 3 -- Que esté atendido
                        AND (@FechaDesde IS NULL OR T.fecha_turno >= @FechaDesde)
                        AND (@FechaHasta IS NULL OR T.fecha_turno <= @FechaHasta)

                    ORDER BY
                        T.fecha_turno DESC,
                        T.hora_inicio DESC;
                END;
                GO

                /* Ejemplo
                EXEC med_ObtenerHistorialPaciente
                    @IdPaciente = 12,
                    @FechaDesde = NULL,
                    @FechaHasta = NULL;
                */
-------------------------------------------------------------------------------------------------------
----- Procedimiento #07: Función que permite acceder al historial del médico --------------------------
                CREATE OR ALTER PROCEDURE med_ListarHistorialMedico
                    @IdMedico INT,
                    @FechaDesde DATE = NULL,
                    @FechaHasta DATE = NULL,
                    @FiltroPaciente VARCHAR(50) = NULL
                AS
                BEGIN
                    SET NOCOUNT ON;

                    SELECT
                        T.fecha_turno AS [Fecha del Turno],
                        T.hora_inicio AS [Hora],
                        P.nombre + ' ' + P.apellido AS [Nombre del Paciente],
                        P.dni AS DNI,
                        MC.descripcion AS [Motivo de Consulta], -- <-- ¡AQUÍ ESTÁ LA LÍNEA AÑADIDA!

                        CASE
                            WHEN R.id_estado = 3 THEN 'Finalizado'
                            WHEN R.id_estado = 1 THEN 'No Asistió'
                        END AS [Estado],

                        CASE
                            WHEN R.id_estado = 1 THEN '(No asistió el Paciente)'
                            WHEN R.id_estado = 3 AND ISNULL(R.diagnostico, '') = '' THEN 'Sin diagnóstico'
                            ELSE R.diagnostico
                        END AS [Diagnóstico]

                    FROM Reserva R
                    -- ... (el resto del procedimiento es igual)
                    INNER JOIN Turno T ON R.id_turno = T.id_turno
                    INNER JOIN Bloque_Horario BH ON T.id_bloque = BH.id_bloque
                    INNER JOIN Usuario U ON BH.id_medico = U.id_usuario
                    INNER JOIN Paciente P ON R.id_paciente = P.id_paciente
                    INNER JOIN Estado_Reserva ER ON R.id_estado = ER.id_estado
                    LEFT JOIN Motivo_Consulta MC ON MC.id_motivo_consulta = R.id_motivo_consulta
                    WHERE
                        BH.id_medico = @IdMedico
                        AND (
                             T.fecha_turno < CAST(GETDATE() AS DATE)
                             OR
                             (T.fecha_turno = CAST(GETDATE() AS DATE) AND T.hora_inicio < CAST(GETDATE() AS TIME))
                            )
                        AND R.id_estado IN (1, 3)
                        AND (@FechaDesde IS NULL OR T.fecha_turno >= @FechaDesde)
                        AND (@FechaHasta IS NULL OR T.fecha_turno <= @FechaHasta)
                        AND (@FiltroPaciente IS NULL 
                            OR P.dni LIKE '%' + @FiltroPaciente + '%'
                            OR P.apellido LIKE '%' + @FiltroPaciente + '%')
                    ORDER BY
                        T.fecha_turno DESC, T.hora_inicio DESC;
                END;
                GO

                /* Ejemplo
                EXEC med_ListarHistorialMedico
                    @IdMedico = 2,
                    @FechaDesde = NULL,
                    @FechaHasta = NULL,
                    @FiltroPaciente = '';
                */
-------------------------------------------------------------------------------------------------------
----- Procedimiento #08: Función que permite a un médico dar por atendida una reserva, con opción de agregar un diagnótico -
                CREATE OR ALTER PROCEDURE med_FinalizarReserva
                    @IdReserva INT,
                    @Diagnostico NVARCHAR(500)
                AS
                BEGIN
                    SET NOCOUNT ON;

                    IF NOT EXISTS (SELECT 1 FROM Reserva WHERE id_reserva = @IdReserva)
                    BEGIN
                        RAISERROR('La reserva indicada no existe.', 16, 1);
                        RETURN;
                    END;

                    UPDATE Reserva
                    SET 
                        diagnostico = @Diagnostico,
                        id_estado = (SELECT id_estado FROM Estado_Reserva WHERE nombre = 'Atendida')
                    WHERE id_reserva = @IdReserva;

                    PRINT 'Reserva actualizada y marcada como atendida correctamente.';
                END;
                GO

                /* Ejemplo
                EXEC med_FinalizarReserva
                    @IdReserva = 13,
                    @Diagnostico = 'Diag 1';
                */
-------------------------------------------------------------------------------------------------------
--- Procedimiento #09: Procedimiento que muestra el total y porcertanje de reservas programadas, atendidas, canceladas o ausentadas,
                   -- y a su vez el promedio semanal de pacientes atendidos en un rango de fechas dado.
                CREATE OR ALTER PROCEDURE med_EstadisticaActividadMedico
                    @IdMedico INT,
                    @FechaDesde DATE,
                    @FechaHasta DATE
                AS
                BEGIN
                    SET NOCOUNT ON;

                    -- 1) Variable que calcula la cantidad de semanas dentro del rango de fechas pasado como parámetros.
                    DECLARE @TotalSemanas DECIMAL(5,2) = (DATEDIFF(DAY, @FechaDesde, @FechaHasta) + 1) / 7.0; -- Esto es un aproximado, ya que los meses no tienen una cantidad entera de semanas.
                                                                                                             -- Sumo 1 porque por ejemplo, para noviembre me dio 29 de resultado, pero hay un día más que no se cuenta.
                    -- Los parámetros para DECIMAL(p, s), p es la cantidad de dígitos en total, s la cantidad de dígitos después de la coma.
                    -- Ejemplo: 999,99 se podría guardar en DECIMAL(5,2), pero 1132,11 no, ya que su cantidad de dígitos en total (p) es 6 teniendo en cuenta decimales.

                    -- 2) Variables de agregados básicos
                    DECLARE @TotalProgramados INT = 0; -- Turnos con reservas programadas.
                    DECLARE @TotalAtendidos INT = 0;   -- Turnos cuyas reservas hayan sido atendidas.
                    DECLARE @TotalCancelados INT = 0;  -- Turnos cuyas reservas hayan sido canceladas.
                    DECLARE @TotalAusencias INT = 0;   -- Turnos cuyas reservas no fueron atendidas debido a la ausencia del paciente.

                    -- 3) Con la cláusula with se crea una tabla temporal (CTE) para almacenar todos los turnos del médico que hayan tenido una reserva en el mes establecido.
                    WITH TurnosMedico AS (
                        SELECT
                            T.id_turno,
                            T.fecha_turno,
                            R.id_estado AS EstadoReserva
                        FROM Turno T
                        INNER JOIN Bloque_Horario BH ON T.id_bloque = BH.id_bloque -- Turnos de cada bloque horario específico.
                        INNER JOIN Reserva R ON T.id_turno = R.id_turno            -- Que a su vez existan en reserva.
                        WHERE 
                            BH.id_medico = @IdMedico                               -- Que sean todos los bloques asociados al médico específico.
                            AND T.fecha_turno BETWEEN @FechaDesde AND @FechaHasta   -- Y que la fecha coincida con el rango establecido para el análisis.
                    )
                    -- 4) Calcular y asignar agregados usando la CTE luego de definirla con WITH.
                    SELECT -- ** ACLARACIÓN ** La tabla temporal 'TurnosMedico' actúa como un grupo en sí mismo, es por eso que se pueden aplicar funciones de agregación.
                        @TotalProgramados = COUNT(*), -- Total de turnos reservados con el filtrado de la tabla temporal.
                        @TotalAtendidos =   ISNULL(SUM(CASE WHEN EstadoReserva = 3 THEN 1 ELSE 0 END), 0) , -- Atendidos (Estado 3)
                        @TotalCancelados = ISNULL(SUM(CASE WHEN EstadoReserva = 2 THEN 1 ELSE 0 END), 0), -- Cancelados (Estado 2)
                        @TotalAusencias =  ISNULL(SUM(CASE WHEN EstadoReserva = 1 AND fecha_turno < CAST(GETDATE() AS DATE) THEN 1 ELSE 0 END), 0)  -- Se asume ausencia cuando el médico no finaliza una atención manualmente,
                                                                                                                                                    -- por tanto, expiraría la fecha pero mantendría su estado de activo (Estado 1).
                    FROM TurnosMedico T;

                    -- 5) Devolver resultados calculados
                    SELECT
                        @TotalProgramados AS [Reservas Programadas],
                        @TotalAtendidos  AS [Reservas Atendidas],
                        @TotalCancelados AS [Reservas Canceladas],
                        @TotalAusencias  AS Ausencias,
                        CASE 
                            WHEN @TotalProgramados = 0 THEN CAST(0 AS DECIMAL(6,2))
                            ELSE CAST(@TotalAtendidos * 100.0 / @TotalProgramados AS DECIMAL(6,2))
                        END AS [Porcentaje de Asistencia],
                        CASE
                            WHEN @TotalSemanas <= 0 THEN CAST(0 AS DECIMAL(6,2))
                            ELSE CAST(@TotalAtendidos / @TotalSemanas AS DECIMAL(6,2))
                        END AS [Promedio Semanal de Pacientes Atendidos];
                END;
                GO

                /* Ejemplo
                EXEC med_EstadisticaActividadMedico
                    @IdMedico = 2,
                    @FechaInicio = '2025-10-01',
                    @FechaFin = '2025-10-30';
                */
-------------------------------------------------------------------------------------------------------
--- Procedimiento #10: Procedimiento que muestra el ranking de motivos de consulta más frecuentes
                    -- atendidos por un médico en un rango de fechas determinado, incluyendo el porcentaje de participación
                    -- de cada motivo respecto al total de consultas realizadas.
                CREATE OR ALTER PROCEDURE med_EstadisticaMotivosMedico
                    @IdMedico INT,
                    @FechaDesde DATE,
                    @FechaHasta DATE
                AS
                BEGIN
                    SET NOCOUNT ON;

                    -- 1) Descripción general:
                    -- Este procedimiento devuelve un listado ordenado de los motivos de consulta más registrados por el médico.
                    -- El cálculo se realiza considerando únicamente las reservas atendidas (id_estado = 3),
                    -- dentro del rango de fechas indicado por los parámetros.

                    -- 2) CTE: se extraen todas las atenciones realizadas por el médico en el rango indicado.
                    WITH ConsultasMedico AS (
                        SELECT
                            MC.id_motivo_consulta,
                            MC.descripcion AS MotivoConsulta,
                            R.id_reserva
                        FROM Reserva R
                        INNER JOIN Turno T ON R.id_turno = T.id_turno
                        INNER JOIN Bloque_Horario BH ON T.id_bloque = BH.id_bloque
                        INNER JOIN Motivo_Consulta MC ON R.id_motivo_consulta = MC.id_motivo_consulta
                        WHERE
                            BH.id_medico = @IdMedico
                            AND R.id_estado = 3                              -- Solo reservas atendidas.
                            AND T.fecha_turno BETWEEN @FechaDesde AND @FechaHasta
                    ),

                    -- 3) Consulta principal: cálculo del ranking de motivos y su porcentaje relativo.
                    MotivosRankeados AS (
                        SELECT
                            MotivoConsulta,
                            COUNT(*) AS Cantidad,
                            -- Asignamos un número de ranking a cada motivo, del más alto al más bajo
                            ROW_NUMBER() OVER (ORDER BY COUNT(*) DESC) AS Ranking
                        FROM ConsultasMedico
                        GROUP BY MotivoConsulta
                    ),
                    -- 3. CTE para agrupar los motivos en "Top 3" y "Otros"
                    GruposFinales AS (
                        SELECT
                            Cantidad,
                            -- Si el ranking es 1, 2 o 3, mostramos el nombre.
                            -- Si es 4 o más, lo agrupamos como 'Otros'.
                            CASE 
                                WHEN Ranking <= 3 THEN MotivoConsulta
                                ELSE 'Otros'
                            END AS MotivoAgrupado
                        FROM MotivosRankeados
                    )
                    -- 4. Consulta final: Sumamos los grupos (porque 'Otros' puede agrupar varias filas)
                    SELECT
                        MotivoAgrupado AS [Motivo de Consulta],
                        SUM(Cantidad) AS [Cantidad de Atenciones],
                        -- Calculamos el porcentaje sobre el nuevo total
                        CAST(SUM(Cantidad) * 100.0 / SUM(SUM(Cantidad)) OVER() AS DECIMAL(5,2)) AS [Porcentaje sobre Total]
                    FROM GruposFinales
                    GROUP BY MotivoAgrupado
                    -- Ordenamos para que el 'Top 3' aparezca primero y 'Otros' al final
                    ORDER BY [Cantidad de Atenciones] DESC;
                END;
                GO

                /* Ejemplo de uso:
                DECLARE @IdMedico INT;
                SELECT @IdMedico = id_usuario FROM Usuario WHERE dni = '302139412' AND id_rol = 2;
                EXEC med_EstadisticaMotivosMedico
                    @IdMedico,
                    @FechaInicio = '2025-10-01',
                    @FechaFin = '2025-10-30';
                */
-------------------------------------------------------------------------------------------------------
--- Procedimiento Complementario #01: Sirve para obtener los dias en los que el médico tenga un bloque horario
                CREATE OR ALTER PROCEDURE med_ObtenerDiasDeTrabajoPorMedico
                    @IdMedico INT
                AS
                BEGIN
                    SET NOCOUNT ON;

                    -- Selecciona de forma única los días de los bloques de horario activos
                    SELECT DISTINCT
                        D.id_dia,
                        D.nombre
                    FROM Bloque_Horario BH
                    INNER JOIN Día D ON BH.id_dia = D.id_dia
                    WHERE
                        BH.id_medico = @IdMedico 
                    ORDER BY
                        D.id_dia;
                END
                GO
--=====================================================================================================

----- Administrador ===================================================================================
--- Procedimiento #01: Crear Usuario
                CREATE OR ALTER PROCEDURE admin_CrearUsuario
                    @nombre VARCHAR(50),
                    @apellido VARCHAR(50),
                    @dni VARCHAR(15),
                    @correo VARCHAR(50),
                    @telefono VARCHAR(20),
                    @contraseña VARCHAR(100),
                    @rol INT,
                    @especialidad INT = NULL -- puede ser NULL si no es médico
                AS
                BEGIN
                    SET NOCOUNT ON;

                    IF EXISTS (SELECT 1 FROM Usuario WHERE dni = @dni OR email = @correo OR telefono = @telefono)
                    BEGIN
                        RAISERROR('El usuario ya existe con el mismo DNI, email o teléfono.', 16, 1);
                        RETURN;
                    END

                    INSERT INTO Usuario (nombre, apellido, dni, email, telefono, contraseña_hash, id_rol, id_especialidad)
                    VALUES (@nombre, @apellido, @dni, @correo, @telefono, @contraseña, @rol, @especialidad);

                    PRINT 'Usuario creado correctamente.';
                END;
                /* Ejemplo
                EXEC admin_CrearUsuario
                    @nombre = 'Leandro',
                    @apellido = 'Martinez',
                    @dni = '430129418',
                    @correo = 'med4@mail.com',
                    @telefono = '3777-123912',
                    @contraseña = 'hash123',
                    @rol = 2,
                    @especialidad = 4;
                */
                GO
-------------------------------------------------------------------------------------------------------
--- Procedimiento #02: Listar Usuarios con diferentes filtros
                CREATE OR ALTER PROCEDURE admin_ListarUsuarios
                    @idRol INT = NULL,
                    @idEspecialidad INT = NULL,
                    @busqueda VARCHAR(50) = NULL,
                    @estadoUsuario BIT = NULL
                AS
                BEGIN
                    SET NOCOUNT ON;

                    SELECT 
                        u.id_usuario,
                        u.nombre + ' ' + u.apellido  AS [Nombre Completo],
                        u.dni AS DNI,
                        u.email AS Email,
                        u.telefono AS Telefono,
                        r.nombre AS Rol,
                        e.nombre AS Especialidad,
                        u.estado_usuario AS Estado
                    FROM Usuario AS u
                    LEFT JOIN Rol AS r ON u.id_rol = r.id_rol
                    LEFT JOIN Especialidad AS e ON u.id_especialidad = e.id_especialidad
                    WHERE 
                        (@idRol IS NULL OR u.id_rol = @idRol)
                        AND (@idEspecialidad IS NULL OR u.id_especialidad = @idEspecialidad)
                        AND (@estadoUsuario IS NULL OR u.estado_usuario = @estadoUsuario)
                        AND (
                            @busqueda IS NULL 
                            OR UPPER(u.nombre) + ' ' + UPPER(u.apellido) LIKE '%' + UPPER(@busqueda) + '%'                                                                     --                                                        JUAN LIKE %JUAN% (Esto evalúa true y va a estar en la lista)
                            OR u.dni LIKE '%' + @busqueda + '%'
                        )
                    ORDER BY u.apellido, u.nombre;
                END;

                /*
                EXEC admin_ListarUsuarios
                    @idRol = null,
                    @idEspecialidad = null,
                    @busqueda = '',
                    @estadoUsuario = null;
                */
                GO
-------------------------------------------------------------------------------------------------------
--- Procedimiento #03: Desactivar Usuario
                CREATE OR ALTER PROCEDURE admin_DesactivarUsuario
                    @idUsuario INT
                AS
                BEGIN
                    SET NOCOUNT ON;

                    IF NOT EXISTS (SELECT 1 FROM Usuario WHERE id_usuario = @idUsuario)
                    BEGIN
                        RAISERROR('El usuario no existe.', 16, 1);
                        RETURN;
                    END

                    UPDATE Usuario
                    SET estado_usuario = 0
                    WHERE id_usuario = @idUsuario;

                    PRINT 'Usuario desactivado correctamente.';
                END;

                 /*
                EXEC admin_DesactivarUsuario
                    @idUsuario = 6
                */
                GO
-------------------------------------------------------------------------------------------------------
--- Procedimiento #04: Procedimiento que muestra indicadores generales de la clínica.
                    -- Incluye la cantidad total de reservas programadas, atendidas, canceladas y ausentes, así como
                    -- el porcentaje de cada tipo y el promedio de reservas atendidas por médico.
                CREATE OR ALTER PROCEDURE admin_EstadisticaClinicaGeneral
                    @FechaInicio DATE,
                    @FechaFin DATE
                AS
                BEGIN
                    SET NOCOUNT ON;

                    -- 1) Variables de agregados globales
                    DECLARE @TotalProgramados INT = 0;
                    DECLARE @TotalAtendidos INT = 0;
                    DECLARE @TotalCancelados INT = 0;
                    DECLARE @TotalAusencias INT = 0;
                    DECLARE @TotalMedicos INT = 0;

                    -- 2) CTE que reúne todas las reservas del período analizado
                    WITH ReservasClinica AS (
                        SELECT
                            R.id_reserva,
                            R.id_estado,
                            T.fecha_turno,
                            BH.id_medico
                        FROM Reserva R
                        INNER JOIN Turno T ON R.id_turno = T.id_turno
                        INNER JOIN Bloque_Horario BH ON T.id_bloque = BH.id_bloque
                        WHERE T.fecha_turno BETWEEN @FechaInicio AND @FechaFin
                    )
                    -- 3) Asignar agregados
                    SELECT
                        @TotalProgramados = COUNT(*),
                        @TotalAtendidos = ISNULL(SUM(CASE WHEN id_estado = 3 THEN 1 ELSE 0 END), 0),
                        @TotalCancelados =  ISNULL(SUM(CASE WHEN id_estado = 2 THEN 1 ELSE 0 END), 0),
                        @TotalAusencias =  ISNULL(SUM(CASE WHEN id_estado = 1 AND fecha_turno < CAST(GETDATE() AS DATE) THEN 1 ELSE 0 END), 0),
                        @TotalMedicos = COUNT(DISTINCT id_medico)
                    FROM ReservasClinica;

                    -- 4) Devolver resultados
                    SELECT
                        @TotalProgramados AS [Reservas Programadas],
                        @TotalAtendidos  AS [Reservas Atendidas],
                        @TotalCancelados AS [Reservas Canceladas],
                        @TotalAusencias  AS [Reservas con Ausencia],
                        CASE WHEN @TotalProgramados = 0 THEN 0
                             ELSE CAST(@TotalAtendidos * 100.0 / @TotalProgramados AS DECIMAL(6,2))
                        END AS [% Atendidas],
                        CASE WHEN @TotalProgramados = 0 THEN 0
                             ELSE CAST(@TotalCancelados * 100.0 / @TotalProgramados AS DECIMAL(6,2))
                        END AS [% Canceladas],
                        CASE WHEN @TotalProgramados = 0 THEN 0
                             ELSE CAST(@TotalAusencias * 100.0 / @TotalProgramados AS DECIMAL(6,2))
                        END AS [% Ausencias],
                        CASE WHEN @TotalMedicos = 0 THEN 0
                             ELSE CAST(@TotalAtendidos * 1.0 / @TotalMedicos AS DECIMAL(6,2))
                        END AS [Promedio de Reservas Atendidas por Médico];
                END;
                GO

                /* Ejemplo de uso:
                EXEC admin_EstadisticaClinicaGeneral
                    @FechaInicio = '2025-10-01',
                    @FechaFin = '2025-10-30';
                */
-------------------------------------------------------------------------------------------------------
--- Procedimiento #05: Procedimiento que muestra el ranking de especialidades más demandadas
                    -- según la cantidad de reservas realizadas en un rango de fechas. También muestra el motivo
                    -- de consulta más frecuente dentro de cada especialidad.
                CREATE OR ALTER PROCEDURE admin_EstadisticaEspecialidades
                    @FechaInicio DATE,
                    @FechaFin DATE
                AS
                BEGIN
                    SET NOCOUNT ON;

                    -- 1) Descripción general:
                    -- Este procedimiento analiza la demanda por especialidad dentro del rango de fechas dado,
                    -- mostrando el total de reservas por especialidad, su porcentaje respecto al total y el
                    -- motivo de consulta más frecuente asociado a cada especialidad.

                    -- 2) CTE principal: reservas con su especialidad y motivo
                    WITH ReservasEspecialidad AS (
                        SELECT
                            E.id_especialidad,
                            E.nombre AS Especialidad,
                            MC.descripcion AS MotivoConsulta,
                            R.id_reserva
                        FROM Reserva R
                        INNER JOIN Turno T ON R.id_turno = T.id_turno
                        INNER JOIN Bloque_Horario BH ON T.id_bloque = BH.id_bloque
                        INNER JOIN Usuario M ON BH.id_medico = M.id_usuario
                        INNER JOIN Especialidad E ON M.id_especialidad = E.id_especialidad
                        LEFT JOIN Motivo_Consulta MC ON R.id_motivo_consulta = MC.id_motivo_consulta
                        WHERE T.fecha_turno BETWEEN @FechaInicio AND @FechaFin
                    ),
                    -- 3) Ranking de motivos dentro de cada especialidad
                    MotivosFrecuentes AS (
                        SELECT
                            id_especialidad,
                            MotivoConsulta,
                            ROW_NUMBER() OVER (PARTITION BY id_especialidad ORDER BY COUNT(*) DESC) AS rn
                        FROM ReservasEspecialidad
                        WHERE MotivoConsulta IS NOT NULL
                        GROUP BY id_especialidad, MotivoConsulta
                    )
                    -- 4) Resultado final: resumen por especialidad
                    SELECT
                        RE.Especialidad,
                        COUNT(*) AS [Cantidad de Reservas],
                        CAST(COUNT(*) * 100.0 / SUM(COUNT(*)) OVER() AS DECIMAL(6,2)) AS [% sobre Total],
                        MF.MotivoConsulta AS [Motivo Más Frecuente]
                    FROM ReservasEspecialidad RE
                    LEFT JOIN MotivosFrecuentes MF
                        ON RE.id_especialidad = MF.id_especialidad AND MF.rn = 1
                    GROUP BY RE.Especialidad, MF.MotivoConsulta
                    ORDER BY [Cantidad de Reservas] DESC;
                END;
                GO

                /* Ejemplo de uso:
                EXEC admin_EstadisticaEspecialidades
                    @FechaInicio = '2025-11-01',
                    @FechaFin = '2025-11-30';
                */
-------------------------------------------------------------------------------------------------------
--- Procedimiento #06: Procedimiento que permite al administrador realizar un backup de la base de datos.

                CREATE OR ALTER PROCEDURE sys_RealizarBackupCompleto
                    @RutaArchivo NVARCHAR(500)
                AS
                BEGIN
                    SET NOCOUNT ON;

                    -- Comando principal que crea el backup
                    BACKUP DATABASE MedoraDB
                    TO DISK = @RutaArchivo
                    WITH INIT, NAME = N'MedoraDB-BackupCompleto';
                END
                GO
-------------------------------------------------------------------------------------------------------
-- OPTIMIZACIÓN ---------------------------------------------------------------------------------------
-- Esta parte si bien parece destinada al proyecto ayuda una banda al rendimiento de las busquedas :) 

--OPTIMIZACION DE CONSULTAS A TRAVES DE INDICES 
-- La idea de los indices a grandes rasgos es mejorar bastante la velocidad de las consultas SELECT
-- Por ejemplo si en una tabla buscamos un registro por su dni, lo que hace la BD es buscarlo "fila por fila",
-- o tambien llamado como "TABLE SCAN" y es bastante lento 
-- Con un indice en una columna, la base de datos va directamente a la estructura del índice (que está ordenada), 
-- encuentra el DNI y obtiene un puntero directo a la ubicación física de esa fila en la tabla. 
-- Es instantaneo practicamente (obviamente esto luego para la presentacion lo voy a desarrollar mas pero 
-- basicamente esta es la idea general) 

                
                -- CONSULTAS INDEXADAS -- 
-- Tabla Paciente --
-- Este índice compuesto acelera muchísimo la búsqueda por apellido y nombre, 
-- que es la operación más común para la recepcionista.
CREATE INDEX IDX_Paciente_ApellidoNombre ON Paciente (apellido, nombre); 
GO
-- Tabla Usuario --
-- Estos índices son para filtrar rápidamente por rol (ej. 'mostrar solo médicos') y por especialidad. 

-- Para filtrar por rol
CREATE INDEX IDX_Usuario_id_rol ON Usuario (id_rol);
GO
-- Para encontrar médicos de una especialidad específica
CREATE INDEX IDX_Usuario_id_especialidad ON Usuario (id_especialidad);
GO
-- Tabla Turno --
-- Esta tabla va a crecer constantemente y se la va a consultar muchas veces, asi que conviene indexarla 

-- Esencial para las uniones (JOIN) con Bloque_Horario
CREATE INDEX IDX_Turno_id_bloque ON Turno (id_bloque);
GO
-- La más importante para que la búsqueda por fecha o rango de fechas sea instantánea
CREATE INDEX IDX_Turno_fecha_turno ON Turno (fecha_turno);
GO
-- Acelera la búsqueda de turnos 'Disponibles'
CREATE INDEX IDX_Turno_id_estado_turno ON Turno (id_estado_turno);
GO
-- Tabla Reserva -- 
-- Clave para buscar todas las reservas de un paciente rápidamente
CREATE INDEX IDX_Reserva_id_paciente ON Reserva (id_paciente);
GO
-- Hará que tus futuros reportes estadísticos por motivo sean mucho más rápidos
CREATE INDEX IDX_Reserva_id_motivo_consulta ON Reserva (id_motivo_consulta);
GO
-- Procedimientos para gráficos específicas de la APP ---------------------------------------------------------------------------------------
-- ===================================================================
-- PROCEDIMIENTOS PARA EL DASHBOARD DEL ADMINISTRADOR
-- ===================================================================

CREATE OR ALTER PROCEDURE sp_Admin_GetDashboardKPIs
    @FechaDesde DATE,
    @FechaHasta DATE
AS
BEGIN
    SET NOCOUNT ON;

    -- 1. Usamos una CTE para obtener la base de TODOS los turnos que ya ocurrieron
    --    y que eran citas válidas (no canceladas).
    WITH TurnosRelevantesPasados AS (
        SELECT
            R.id_estado,
            -- Contamos 1 si fue 'Finalizado' (Atendido)
            CASE WHEN R.id_estado = 3 THEN 1 ELSE 0 END AS Atendido,
            -- Contamos 1 si se quedó como 'Reservado' (No Asistió)
            CASE WHEN R.id_estado = 1 THEN 1 ELSE 0 END AS Ausencia
        FROM Reserva R
        JOIN Turno T ON R.id_turno = T.id_turno
        JOIN Bloque_Horario BH ON T.id_bloque = BH.id_bloque
        WHERE
            -- Que estén dentro del rango seleccionado por el admin
            T.fecha_turno BETWEEN @FechaDesde AND @FechaHasta
            -- Y que ya hayan sucedido (fecha y hora pasadas)
            AND (T.fecha_turno < CAST(GETDATE() AS DATE) OR (T.fecha_turno = CAST(GETDATE() AS DATE) AND T.hora_inicio < CAST(GETDATE() AS TIME)))
            -- Y que fueran citas válidas (no canceladas)
            AND R.id_estado <> 2
    )
    -- 2. Hacemos los cálculos sobre ese conjunto de datos
    SELECT
        -- KPI 1: Total de Turnos Atendidos (del SP anterior, sigue siendo útil)
        (SELECT COUNT(*) FROM Reserva R JOIN Turno T ON R.id_turno = T.id_turno WHERE T.fecha_turno BETWEEN @FechaDesde AND @FechaHasta AND R.id_estado = 3) AS TotalTurnosAtendidos,

        -- KPI 2: Especialidad Más Popular (del SP anterior)
        (SELECT TOP 1 E.nombre FROM Reserva R JOIN Turno T ON R.id_turno = T.id_turno JOIN Bloque_Horario BH ON T.id_bloque = BH.id_bloque JOIN Usuario U ON BH.id_medico = U.id_usuario JOIN Especialidad E ON U.id_especialidad = E.id_especialidad WHERE T.fecha_turno BETWEEN @FechaDesde AND @FechaHasta AND R.id_estado <> 2 GROUP BY E.nombre ORDER BY COUNT(*) DESC) AS EspecialidadPopular,

        -- KPI 3: Médico Más Activo (del SP anterior)
        (SELECT TOP 1 U.apellido + ', ' + U.nombre FROM Reserva R JOIN Turno T ON R.id_turno = T.id_turno JOIN Bloque_Horario BH ON T.id_bloque = BH.id_bloque JOIN Usuario U ON BH.id_medico = U.id_usuario WHERE T.fecha_turno BETWEEN @FechaDesde AND @FechaHasta AND R.id_estado = 3 GROUP BY U.apellido, U.nombre ORDER BY COUNT(*) DESC) AS MedicoMasActivo,
        
        -- KPI 4: Tasa de No Asistencia (CORREGIDA)
        CAST(
            -- Numerador: Suma total de Ausencias (ID 1)
            (SUM(Ausencia) * 100.0)
            -- Denominador: Suma total de (Atendidos + Ausencias)
            / NULLIF(SUM(Atendido) + SUM(Ausencia), 0)
        AS DECIMAL(5,2)) AS TasaNoAsistencia
        
    FROM TurnosRelevantesPasados;
END
GO

-- 2. Gráfico de Turnos por Especialidad
CREATE OR ALTER PROCEDURE sp_Admin_GetTurnosPorEspecialidad
    @FechaDesde DATE, @FechaHasta DATE
AS
BEGIN
    SELECT E.nombre AS Especialidad, COUNT(R.id_reserva) AS Cantidad
    FROM Reserva R
    JOIN Turno T ON R.id_turno = T.id_turno
    JOIN Bloque_Horario BH ON T.id_bloque = BH.id_bloque
    JOIN Usuario U ON BH.id_medico = U.id_usuario
    JOIN Especialidad E ON U.id_especialidad = E.id_especialidad
    WHERE T.fecha_turno BETWEEN @FechaDesde AND @FechaHasta AND R.id_estado <> 2
    GROUP BY E.nombre ORDER BY Cantidad DESC;
END
GO

-- 3.5 Grafico que distribuye los porcentajes 
CREATE OR ALTER PROCEDURE sp_Admin_GetDistribucionDeEstados
    @FechaInicio DATE,
    @FechaFin DATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Usamos la CTE para obtener todas las reservas que ya finalizaron de alguna forma
    WITH ReservasFinalizadas AS (
        SELECT 
            R.id_estado
        FROM Reserva R
        JOIN Turno T ON R.id_turno = T.id_turno
        JOIN Bloque_Horario BH ON T.id_bloque = BH.id_bloque
        WHERE 
            T.fecha_turno BETWEEN @FechaInicio AND @FechaFin
            -- Condición clave: Solo contamos turnos que ya "terminaron":
            AND (
                R.id_estado = 3 OR -- 2. Finalizado (Atendido)
                R.id_estado = 2 OR -- 3. Cancelado
                (R.id_estado = 1 AND T.fecha_turno < CAST(GETDATE() AS DATE)) -- 1. Activo que ya pasó (Ausencia)
            )
    )
    -- Contamos y agrupamos los resultados
    SELECT 
        CASE 
            WHEN id_estado = 3 THEN 'Atendidas'
            WHEN id_estado = 2 THEN 'Canceladas'
            WHEN id_estado = 1 THEN 'Ausencias'
        END AS Estado,
        COUNT(*) AS Cantidad
    FROM ReservasFinalizadas
    GROUP BY 
        CASE 
            WHEN id_estado = 3 THEN 'Atendidas'
            WHEN id_estado = 2 THEN 'Canceladas'
            WHEN id_estado = 1 THEN 'Ausencias'
        END;
END
GO

-- ===================================================================
-- PROCEDIMIENTOS PARA EL DASHBOARD DEL RECEPCIONISTA
-- ===================================================================

-- 1. Gráfico de Pacientes por Obra Social
CREATE OR ALTER PROCEDURE sp_Recep_GetPacientesPorObraSocial
AS
BEGIN
    SELECT ISNULL(OS.nombre, 'Particular') AS ObraSocial, COUNT(P.id_paciente) AS Cantidad
    FROM Paciente P
    LEFT JOIN Obra_Social OS ON P.id_obra_social = OS.id_obra_social
    GROUP BY OS.nombre ORDER BY Cantidad DESC;
END
GO

-- 2. Gráfico de Turnos por Día de la Semana
CREATE OR ALTER PROCEDURE sp_Recep_GetTurnosPorDiaSemana
    @FechaDesde DATE, @FechaHasta DATE
AS
BEGIN
    SET NOCOUNT ON;
    SET DATEFIRST 1; -- Lunes es el primer día

    SELECT 
        DATENAME(weekday, T.fecha_turno) AS DiaSemana,
        COUNT(R.id_reserva) AS Cantidad
    FROM Reserva R
    JOIN Turno T ON R.id_turno = T.id_turno
    WHERE T.fecha_turno BETWEEN @FechaDesde AND @FechaHasta AND R.id_estado <> 2
    GROUP BY DATENAME(weekday, T.fecha_turno), DATEPART(weekday, T.fecha_turno)
    ORDER BY DATEPART(weekday, T.fecha_turno) ASC;
END
GO

-------------------