-- =============================================

--   CREACIÓN DE BASE DE DATOS MEDORA

CREATE DATABASE MedoraDB;
GO

USE MedoraDB;
GO

-- =================== ESTRUCTURA ==========================

--   TABLA: Especialidad
CREATE TABLE Especialidad (
  id_especialidad INT NOT NULL,
  nombre VARCHAR(50) NOT NULL,
  CONSTRAINT PK_Especialidad PRIMARY KEY (id_especialidad)
);

INSERT INTO Especialidad (id_especialidad, nombre)
VALUES (1, 'Cardiología'), (2, 'Oftalmología'), (3, 'Pediatría'), (4, 'Ginecología'), (5, 'Urología'), (6, 'Medicina General');
GO

-- =============================================

--   TABLA: Rol
CREATE TABLE Rol (
  id_rol INT NOT NULL,
  nombre VARCHAR(30) NOT NULL,
  CONSTRAINT PK_Rol PRIMARY KEY (id_rol)
);

INSERT INTO Rol (id_rol, nombre)
VALUES (1, 'Administrador'), (2, 'Médico'), (3, 'Recepcionista');
GO

-- =============================================

--   TABLA: Usuario
CREATE TABLE Usuario (
  id_usuario INT IDENTITY(1,1),
  nombre VARCHAR(50) NOT NULL,
  apellido VARCHAR(50) NOT NULL,
  dni VARCHAR(15) NOT NULL,
  email VARCHAR(50) NOT NULL,
  telefono VARCHAR(20) NOT NULL,
  contraseña_hash VARCHAR(100) NOT NULL,
  id_especialidad INT NULL,
  id_rol INT NOT NULL,
  CONSTRAINT PK_Usuario PRIMARY KEY (id_usuario),
  CONSTRAINT FK_Especialidad_Medico FOREIGN KEY (id_especialidad) REFERENCES Especialidad(id_especialidad),
  CONSTRAINT FK_Rol_Usuario FOREIGN KEY (id_rol) REFERENCES Rol(id_rol),
  CONSTRAINT UK_Dni_Usuario UNIQUE (dni),
  CONSTRAINT UK_Email_Usuario UNIQUE (email),
  CONSTRAINT UK_Telefono_Usuario UNIQUE (telefono),
);

  INSERT INTO Usuario (nombre, apellido, dni, email, telefono, contraseña_hash, id_especialidad, id_rol)
  VALUES ('Juan', 'Pérez', '26938124', 'juan@mail.com', '3682193212', 'hash123', 6, 2);
GO

-- =============================================

--   TABLA: Día
CREATE TABLE Día (
  id_dia INT NOT NULL,
  nombre VARCHAR(15) NOT NULL,
  CONSTRAINT PK_Dia PRIMARY KEY (id_dia)
);

INSERT INTO Día (id_dia, nombre)
VALUES (1, 'Lunes'), (2, 'Martes'), (3, 'Miércoles'), (4, 'Jueves'), (5, 'Viernes'), (6, 'Sábado');
GO


-- =============================================

--   TABLA: Bloque_Horario
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

-- =============================================

--   TABLA: Estado_Turno
CREATE TABLE Estado_Turno (
  id_estado_turno INT NOT NULL,
  nombre VARCHAR(20) NOT NULL,
  CONSTRAINT PK_Estado_Turno PRIMARY KEY (id_estado_turno)
);

INSERT INTO Estado_Turno (id_estado_turno, nombre)
VALUES (1, 'Disponible'), (2, 'Reservado'), (3, 'Inactivo');
GO

-- =============================================

--   TABLA: Turno
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

-- =============================================

--   TABLA: Estado_Reserva

CREATE TABLE Estado_Reserva (
  id_estado INT NOT NULL,
  nombre VARCHAR(20) NOT NULL
  CONSTRAINT PK_Estado_Reserva PRIMARY KEY (id_estado)
);

INSERT INTO Estado_Reserva (id_estado, nombre)
VALUES (1, 'Activa'), (2, 'Cancelada'), (3, 'Atendida');
GO

-- =============================================

--   TABLA: Paciente

CREATE TABLE Paciente (
  id_paciente INT IDENTITY(1,1),
  nombre VARCHAR(50) NOT NULL,
  apellido VARCHAR(50) NOT NULL,
  dni VARCHAR(15) NOT NULL,
  email VARCHAR(50) NOT NULL,
  telefono VARCHAR(20) NOT NULL,
  CONSTRAINT PK_Paciente PRIMARY KEY (id_paciente),
  CONSTRAINT UK_Dni_Paciente UNIQUE (dni),
  CONSTRAINT UK_Email_Paciente UNIQUE (email),
  CONSTRAINT UK_Telefono_Paciente UNIQUE (telefono)
);

INSERT INTO Paciente (nombre, apellido, dni, email, telefono)
VALUES ('Ramón', 'Méndez', '22837412', 'ramon@mail.com', '3682191232')
GO

-- =============================================

--   TABLA: Reserva

CREATE TABLE Reserva (
  id_reserva INT IDENTITY(1,1),
  motivo_consulta VARCHAR(200) NOT NULL,
  diagnostico VARCHAR(500) DEFAULT NULL,
  id_estado INT NOT NULL DEFAULT 1,
  id_turno INT NOT NULL,
  id_paciente INT NOT NULL,
  CONSTRAINT PK_Reserva PRIMARY KEY (id_reserva),
  CONSTRAINT FK_Estado_Reserva FOREIGN KEY (id_estado) REFERENCES Estado_Reserva(id_estado),
  CONSTRAINT FK_Turno_Reserva FOREIGN KEY (id_turno) REFERENCES Turno(id_turno),
  CONSTRAINT FK_Paciente_Reserva FOREIGN KEY (id_paciente) REFERENCES Paciente(id_paciente),
  CONSTRAINT UK_Turno UNIQUE (id_turno)
);
GO

----- Procedimientos ================================================================================
----- Recepcionista =================================================================================
----- Procedimiento #01: Registrar Paciente ---------------------------------------------------------
              CREATE OR ALTER PROCEDURE rec_RegistrarPaciente
                    @Nombre VARCHAR(50),
                    @Apellido VARCHAR(50),
                    @Dni VARCHAR(15),
                    @Email VARCHAR(100),
                    @Telefono VARCHAR(20),
                    @IdObraSocial INT = NULL -- Parámetro opcional, si no es proporcionado se asume NULL
                AS
                BEGIN
                    SET NOCOUNT ON; -- Esta sentencia indica que al hacer la consulta no se devuelva el mensaje de cuántas filas fueron afectadas.

                    INSERT INTO Paciente (nombre, apellido, dni, email, telefono, id_obra_social)
                    VALUES (@Nombre, @Apellido, @Dni, @Email, @Telefono, @IdObraSocial);
                END;
                GO
                
                --------------------------------------------
                /* Ejemplo de uso: EXEC rec_RegistrarPaciente
                                        @Nombre='Juan',
                                        @Apellido='Pérez',
                                        @Dni='12345678', 
                                        @Email='jp@gmail.com', 
                                        @Telefono='3777897856';*/
-----------------------------------------------------------------------------------------------------
----- Procedimiento #02: Listar pacientes con opción de filtrado ------------------------------------
              CREATE OR ALTER PROCEDURE rec_ListarPacientes
                    @Filtro VARCHAR(50) = NULL
                AS
                BEGIN
                    SET NOCOUNT ON;

                    SELECT
                        P.nombre AS Nombre,
                        P.apellido AS Apellido,
                        P.dni AS DNI,
                        P.telefono AS Telefono,
                        P.email AS Email,
                        CASE
                          WHEN OS.nombre IS NULL THEN 'No posee' -- Si el nombre de la obra social es NULL se muestra ese mensaje.
                          ELSE OS.nombre                         -- De lo contrario, muestra el nombre de la obra social
                        END AS obra_social                       
                    FROM Paciente P
                    LEFT JOIN Obra_Social OS ON P.id_obra_social = OS.id_obra_social
                    WHERE
                        @Filtro IS NULL -- Si es null, la evaluación dará verdadera y mostrará todas las tuplas.
                        OR UPPER(P.nombre) LIKE '%' + UPPER(@Filtro) + '%'   -- Ejemplo, si P.nombre = Juan y @Filtro = Juan, realiza: UPPER(Juan) LIKE %UPPER(Juan)%
                        OR UPPER(P.apellido) LIKE '%' + UPPER(@Filtro) + '%' --                                                        JUAN LIKE %JUAN% (Esto evalúa true y va a estar en la lista)
                        OR P.dni LIKE '%' + @Filtro + '%'                    -- '%' Se usa para buscar en cualquier parte de una cadena.
                    ORDER BY P.apellido, P.nombre;                           -- Por ejemplo, podría buscar '%ua%' y me aparecería 'Juan' ya que contiene en el medio esos caracteres.
                END;
                GO
                
                --------------------------------------------
                /* Ejemplo de uso: EXEC rec_ListarPacientes; -- Muestra todos los pacientes
                                   EXEC rec_ListarPacientes @Filtro = 'juan'; -- Muestra pacientes que se llamen 'juan'
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
                        U.nombre AS Nombre,
                        U.apellido AS Apellido,
                        E.nombre AS Especialidad
                    FROM Usuario U
                    JOIN Rol R ON U.id_rol = R.id_rol
                    JOIN Especialidad E ON U.id_especialidad = E.id_especialidad
                    WHERE
                        U.id_rol = 2 -- Médico
                        AND (@IdEspecialidad IS NULL OR E.id_especialidad = @IdEspecialidad)
                        AND (
                            @TextoBusquedaNombre IS NULL
                            OR UPPER(TRIM(U.nombre)) LIKE '%' + UPPER(TRIM(@TextoBusquedaNombre)) + '%'
                            OR UPPER(TRIM(U.apellido)) LIKE '%' + UPPER(TRIM(@TextoBusquedaNombre)) + '%'
                        )
                    ORDER BY U.apellido, U.nombre;
                END;
                GO
                
    ---- 3.2: Mostrar turnos disponibles para un médico seleccionado con diferentes filtrados opcionales
               CREATE OR ALTER PROCEDURE rec_ObtenerTurnosDisponibles
                    @IdMedico INT,
                    @FechaInicio DATE = NULL,
                    @FechaFin DATE = NULL,
                    @IdDia INT = NULL
                AS
                BEGIN
                    SET NOCOUNT ON;

                    SELECT
                        T.id_turno,
                        T.fecha_turno,
                        T.hora_inicio,
                        T.hora_fin,
                        D.nombre AS DiaSemana,
                        ET.nombre AS EstadoTurno
                    FROM Turno T
                    JOIN Bloque_Horario BH ON T.id_bloque = BH.id_bloque
                    JOIN Día D ON BH.id_dia = D.id_dia
                    JOIN Estado_Turno ET ON T.id_estado_turno = ET.id_estado_turno
                    WHERE
                        BH.id_medico = @IdMedico
                        AND ET.id_estado_turno = 1 -- solo disponibles
                        AND T.fecha_turno >= CAST(GETDATE() AS DATE)
                        AND BH.fecha_fin >= CAST(GETDATE() AS DATE)
                        AND (@FechaInicio IS NULL OR T.fecha_turno >= @FechaInicio)
                        AND (@FechaFin IS NULL OR T.fecha_turno <= @FechaFin)
                        AND (@IdDia IS NULL OR BH.id_dia = @IdDia)
                    ORDER BY T.fecha_turno, T.hora_inicio;
                END;
                GO
                

    ---- 3.3: Función que inserta la reserva, cambiando el estado de turno a ocupado
              CREATE OR ALTER PROCEDURE rec_RegistrarReserva
                    @IdTurno INT,
                    @IdPaciente INT,
                    @MotivoConsulta INT
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
                    INSERT INTO Reserva (id_turno, id_paciente, motivo_consulta, id_estado)
                    VALUES (@IdTurno, @IdPaciente, @MotivoConsulta, 1); -- 1 = Activa

                    -- Actualizar estado del turno
                    UPDATE Turno
                    SET id_estado_turno = 2 -- Reservado
                    WHERE id_turno = @IdTurno;
                END;
                GO
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
                        R.motivo_consulta,
                        R.id_turno,
                        R.id_paciente,
                        P.nombre AS NombrePaciente,
                        P.apellido AS ApellidoPaciente,
                        P.dni AS DniPaciente,
                        ER.nombre AS EstadoReserva,
                        T.fecha_turno,
                        T.hora_inicio,
                        T.hora_fin
                    FROM Reserva R
                    JOIN Turno T ON R.id_turno = T.id_turno
                    JOIN Paciente P ON R.id_paciente = P.id_paciente
                    JOIN Estado_Reserva ER ON R.id_estado = ER.id_estado
                    WHERE 
                        T.fecha_turno >= CAST(GETDATE() AS DATE)
                        AND (
                            @Filtro IS NULL 
                            OR P.nombre LIKE '%' + @Filtro + '%'
                            OR P.apellido LIKE '%' + @Filtro + '%'
                            OR P.dni LIKE '%' + @Filtro + '%'
                        )
                    ORDER BY T.fecha_turno ASC, T.hora_inicio ASC;
                END;
                GO
                
----------------------------------------------------------------------------------------------------
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
                        BH.fecha_inicio AS FechaInicio,
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
                
----- Procedimiento #05: Función que lista las reservas próximas del médico con diferentes filtros ----
                CREATE OR ALTER PROCEDURE med_ListarAgendaMedico
                    @IdMedico INT,                     
                    @FechaDesde DATE = NULL,           
                    @FechaHasta DATE = NULL,           
                    @IdPaciente INT = NULL,            
                    @IdDia INT = NULL,                 
                    @HoraDesde TIME = NULL,            
                    @HoraHasta TIME = NULL,            
                AS
                BEGIN
                    SET NOCOUNT ON;

                    SELECT
                        R.id_reserva,
                        R.motivo_consulta,
                        R.id_estado AS id_estado_reserva,
                        ER.nombre AS estado_reserva,
                        T.id_turno,
                        T.fecha_turno,
                        T.hora_inicio,
                        T.hora_fin,
                        BH.id_bloque,
                        BH.fecha_inicio AS bloque_fecha_inicio,
                        BH.fecha_fin   AS bloque_fecha_fin,
                        D.nombre AS nombre_dia,
                        P.id_paciente,
                        P.nombre AS paciente_nombre,
                        P.apellido AS paciente_apellido,
                        P.dni AS paciente_dni,
                        P.email AS paciente_email,
                        P.telefono AS paciente_telefono,
                        OS.id_obra_social,
                        OS.nombre AS obra_social
                    FROM Reserva R
                    INNER JOIN Turno T ON R.id_turno = T.id_turno
                    INNER JOIN Bloque_Horario BH ON T.id_bloque = BH.id_bloque
                    INNER JOIN Usuario U ON BH.id_medico = U.id_usuario
                    INNER JOIN Paciente P ON R.id_paciente = P.id_paciente
                    LEFT JOIN Obra_Social OS ON R.id_obra_social = OS.id_obra_social -- opcional
                    LEFT JOIN Estado_Reserva ER ON R.id_estado = ER.id_estado
                    LEFT JOIN Día D ON BH.id_dia = D.id_dia
                    WHERE
                        BH.id_medico = @IdMedico
                        AND (T.fecha_turno >= CAST(GETDATE() AS DATE)) -- por defecto próximas
                        AND (@FechaDesde IS NULL OR T.fecha_turno >= @FechaDesde)
                        AND (@FechaHasta IS NULL OR T.fecha_turno <= @FechaHasta)
                        AND (@IdPaciente IS NULL OR P.id_paciente = @IdPaciente)
                        AND (@IdDia IS NULL OR BH.id_dia = @IdDia)
                        AND (@HoraDesde IS NULL OR T.hora_inicio >= @HoraDesde)
                        AND (@HoraHasta IS NULL OR T.hora_fin <= @HoraHasta)
                    ORDER BY
                        T.fecha_turno ASC,
                        T.hora_inicio ASC;
                END;
                GO
                
----- Procedimiento #06: Función que permite acceder al historial del paciente ------------------------
                CREATE OR ALTER PROCEDURE med_ObtenerHistorialPaciente
                    @IdPaciente INT,
                    @FechaDesde DATE = NULL,
                    @FechaHasta DATE = NULL
                AS
                BEGIN
                    SET NOCOUNT ON;

                    SELECT
                        R.motivo_consulta,

                        T.fecha_turno,
                        T.hora_inicio,
                        T.hora_fin,

                        U.nombre AS medico_nombre,
                        U.apellido AS medico_apellido,
                        Esp.nombre AS especialidad_medico,

                        P.nombre AS paciente_nombre,
                        P.apellido AS paciente_apellido,
                        P.dni AS paciente_dni

                    FROM Reserva R
                    INNER JOIN Turno T ON R.id_turno = T.id_turno
                    INNER JOIN Bloque_Horario BH ON T.id_bloque = BH.id_bloque
                    INNER JOIN Usuario U ON BH.id_medico = U.id_usuario
                    INNER JOIN Paciente P ON R.id_paciente = P.id_paciente
                    LEFT JOIN Especialidad Esp ON U.id_especialidad = Esp.id_especialidad

                    WHERE
                        R.id_paciente = @IdPaciente
                        AND R.id_estado = (SELECT id_estado FROM Estado_Reserva WHERE nombre = 'Atendida')
                        AND (@FechaDesde IS NULL OR T.fecha_turno >= @FechaDesde)
                        AND (@FechaHasta IS NULL OR T.fecha_turno <= @FechaHasta)

                    ORDER BY
                        T.fecha_turno DESC,
                        T.hora_inicio DESC;
                END;
                GO

----- Procedimiento #07: Función que permite acceder al historial del médico --------------------------
                CREATE OR ALTER PROCEDURE med_ListarHistorialMedico
                    @IdMedico INT,
                    @FechaDesde DATE = NULL,
                    @FechaHasta DATE = NULL,
                    @IdPaciente INT = NULL,
                AS
                BEGIN
                    SET NOCOUNT ON;

                    SELECT
                        R.motivo_consulta,
                        R.diagnostico,

                        T.fecha_turno,
                        T.hora_inicio,
                        T.hora_fin,

                        P.nombre AS paciente_nombre,
                        P.apellido AS paciente_apellido,
                        P.dni AS paciente_dni
                    FROM Reserva R
                    INNER JOIN Turno T ON R.id_turno = T.id_turno
                    INNER JOIN Bloque_Horario BH ON T.id_bloque = BH.id_bloque
                    INNER JOIN Paciente P ON R.id_paciente = P.id_paciente
                    WHERE
                        BH.id_medico = @IdMedico
                        AND T.fecha_turno < CAST(GETDATE() AS DATE)
                        AND R.id_estado <> 2 -- Excluir canceladas
                        AND (@FechaDesde IS NULL OR T.fecha_turno >= @FechaDesde)
                        AND (@FechaHasta IS NULL OR T.fecha_turno <= @FechaHasta)
                        AND (@IdPaciente IS NULL OR P.id_paciente = @IdPaciente)
                    ORDER BY
                        T.fecha_turno DESC,
                        T.hora_inicio ASC;
                END;
                GO

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

----- Procedimiento #09: Reportes estadísticas del médico ---------------------------------------------
--=====================================================================================================
----- Administrador ==========================================================================
--- Funciones #01: Crear Usuario
--- Función #02: Listar Usuarios con diferentes filtros
--- Función #03: Desactivar Usuario
--- Funciones #04: Reportes de la clínica


