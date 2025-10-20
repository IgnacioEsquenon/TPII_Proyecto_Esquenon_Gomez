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

----- CONSULTAS =======================================================================
----- Recepcionista ===================================================================
----- Función #01: Registrar Paciente -------------------------------------------------
          /*INSERT INTO Paciente (nombre, apellido, dni, email, telefono)
            VALUES (@Nombre, @Apellido, @Dni, @Email, @Telefono);
            */
---------------------------------------------------------------------------------------
----- Función #02: Listar pacientes con opción de filtrado ----------------------------
          /*SELECT 
                id_paciente,
                nombre,
                apellido,
                dni,
                email,
                telefono
            FROM Paciente
            WHERE
                (@NombreApellido IS NULL OR UPPER(nombre) LIKE '%' + UPPER(@NombreApellido) + '%' OR UPPER(apellido) LIKE '%' + UPPER(@NombreApellido) + '%')
                AND (@Dni IS NULL OR dni = @Dni)
            ORDER BY apellido, nombre;
            */
---------------------------------------------------------------------------------------
----- Función #03: Flujo de reservar turno --------------------------------------------
    ---- Consulta #01: Búsqueda de médico para reservar un turno
                /*SELECT
                    U.id_usuario,
                    U.nombre AS NombreMedico,
                    U.apellido AS ApellidoMedico,
                    E.nombre AS Especialidad
                FROM Usuario U
                JOIN Rol R ON U.id_rol = R.id_rol
                JOIN Especialidad E ON U.id_especialidad = E.id_especialidad
                WHERE
                    U.id_rol = 2
                    AND E.id_especialidad = @IdEspecialidad
                    AND (
                        @TextoBusquedaNombre IS NULL
                        OR UPPER(TRIM(U.nombre)) LIKE '%' + UPPER(TRIM(@TextoBusquedaNombre)) + '%'
                        OR UPPER(TRIM(U.apellido)) LIKE '%' + UPPER(TRIM(@TextoBusquedaNombre)) + '%'
                    )
                ORDER BY
                    U.apellido, U.nombre;
                    */

    ---- Consulta #02: Mostrar turnos disponibles para un médico seleccionado con diferentes filtrados opcionales
               /* SELECT
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
                    AND T.fecha_turno >= CAST(GETDATE() AS DATE) -- no mostrar turnos pasados
                    AND BH.fecha_fin >= CAST(GETDATE() AS DATE)
                    AND (@FechaInicio IS NULL OR T.fecha_turno >= @FechaInicio)
                    AND (@FechaFin IS NULL OR T.fecha_turno <= @FechaFin)
                    AND (@IdDia IS NULL OR BH.id_dia = @IdDia)
                ORDER BY
                    T.fecha_turno, T.hora_inicio;
                    */

    ---- Consulta #03: Trigger de insertado que realice la reserva, cambiando el estado de turno a ocupado
              /*CREATE TRIGGER TR_ValidarYActualizarTurno
                ON Reserva
                INSTEAD OF INSERT
                AS
                BEGIN
                    -- Verificar que el turno esté disponible
                    IF EXISTS (
                        SELECT 1
                        FROM inserted I -- Inserted hace referencia a los objetos reserva que se intentan insertar
                        JOIN Turno T ON T.id_turno = I.id_turno -- Se juntan todos los turnos a los que las reservas hacen referencia
                        WHERE T.id_estado_turno <> 1 -- Si el id de su estado es distinto de 1, está ocupado o inactivo
                    )
                    BEGIN
                        RAISERROR('El turno ya está reservado o no está disponible.', 16, 1);
                        ROLLBACK TRANSACTION;
                        RETURN;
                    END;

                    -- Insertar la reserva
                    INSERT INTO Reserva (id_turno, id_paciente, motivo_consulta, id_estado)
                    SELECT id_turno, id_paciente, motivo_consulta, id_estado
                    FROM inserted;

                    -- Actualizar el turno a reservado
                    UPDATE T
                    SET T.id_estado_turno = 2
                    FROM Turno T
                    INNER JOIN inserted I ON T.id_turno = I.id_turno; /* Inserted puede incluir muchos objetos reserva que se están intentando insertar.
                                                                             Si queremos cambiar el turno específico que fue reservado, hace falta verificar que
                                                                             coincidan el turno, con la referencia que hace reserva de ese turno, y aplicar ese cambio
                                                                             a turno.*/
                END;
            */
------------------------------------------------------------------------------------
----- Función #04: Listar Reservas de Pacientes con Filtros ------------------------
              /*SELECT  
                    R.id_reserva,
                    R.motivo_consulta,
                    R.id_turno,
                   R.id_paciente,
                    P.nombre AS NombrePaciente,
                    P.apellido AS ApellidoPaciente,
                    P.dni AS DniPaciente,
                    ET.nombre AS EstadoReserva,
                    T.fecha_turno,
                    T.hora_inicio,
                    T.hora_fin
                FROM Reserva R
                JOIN Turno T ON R.id_turno = T.id_turno
                JOIN Paciente P ON R.id_paciente = P.id_paciente
                JOIN Estado_Turno ET ON T.id_estado_turno = ET.id_estado_turno
                WHERE 
                    T.fecha_turno >= CAST(GETDATE() AS DATE)
                    AND (@Filtro IS NULL 
                         OR P.nombre LIKE '%' + @Filtro + '%'
                         OR P.apellido LIKE '%' + @Filtro + '%'
                         OR P.dni LIKE '%' + @Filtro + '%')
                ORDER BY T.fecha_turno ASC, T.hora_inicio ASC;
                */
----------------------------------------------------------------------------------------------
--============================================================================================
----- Médico =================================================================================
----- Función #01: Crear bloques horarios (con sus respectivos turnos) -----------------------
    --- Consulta #01: Crear un bloque horario 
              /*INSERT INTO Bloque_Horario (fecha_inicio, fecha_fin, hora_inicio, hora_fin, duracion_turnos, id_medico, id_dia)
                VALUES (@FechaInicio, @FechaFin, @HoraInicio, @HoraFin, @DuracionTurnos, @IdUsuario, @IdDia);
                */
    --- Consulta #02: Trigger que verifica antes de insertar que el bloque por insertar no se solape con ningún otro que esté guardado.
    --- (No debe haber solapamiento entre horarios y rango de fechas cuando un bloque de un mismo médico coinciden en día)
              /*CREATE TRIGGER TR_NoSolapamientoBloques
                ON Bloque_Horario
                INSTEAD OF INSERT
                AS
                BEGIN
                    IF EXISTS (
                        SELECT 1
                        FROM Bloque_Horario bh
                        JOIN inserted i 
                            ON bh.id_medico = i.id_medico
                           AND bh.id_dia = i.id_dia  -- compara solo si es el mismo día
                        WHERE 
                            -- Fechas que se superponen
                            i.fecha_inicio < bh.fecha_fin
                            AND i.fecha_fin > bh.fecha_inicio
                            -- Horarios que se superponen dentro del día
                            AND i.hora_inicio < bh.hora_fin
                            AND i.hora_fin > bh.hora_inicio
                    )
                    BEGIN
                        RAISERROR('El médico ya tiene un bloque en ese rango de fechas y horas para ese día.', 16, 1);
                        ROLLBACK TRANSACTION;
                        RETURN;
                    END;

                    -- Si no hay conflicto, se realiza el insert original
                    INSERT INTO Bloque_Horario 
                        (fecha_inicio, fecha_fin, hora_inicio, hora_fin, duracion_turnos, activo, id_medico, id_dia)
                    SELECT 
                        fecha_inicio, fecha_fin, hora_inicio, hora_fin, duracion_turnos, activo, id_medico, id_dia
                    FROM inserted;
                END;
                */
    --- Consulta #03: Procedimiento que calcula e inserta todos los turnos de un bloque dado.
              /*CREATE PROCEDURE sp_GenerarTurnosPorBloque
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
                        @FechaInicio = fecha_inicio,
                        @FechaFin = fecha_fin,
                        @HoraInicio = hora_inicio,
                        @HoraFin = hora_fin,
                        @DuracionTurnos = duracion_turnos,
                        @IdMedico = id_medico,
                        @IdDia = id_dia
                    FROM Bloque_Horario
                    WHERE id_bloque = @IdBloque;

                    DECLARE @FechaActual DATE = @FechaInicio;

                    WHILE @FechaActual <= @FechaFin
                    BEGIN
                        IF DATEPART(WEEKDAY, @FechaActual) = @IdDia
                        BEGIN
                            DECLARE @HoraActual TIME = @HoraInicio;

                            WHILE DATEADD(MINUTE, @DuracionTurnos, @HoraActual) <= @HoraFin
                            BEGIN
                                INSERT INTO Turno (fecha_turno, hora_inicio, hora_fin, id_bloque, id_estado_turno)
                                VALUES (
                                    @FechaActual,
                                    @HoraActual,
                                    DATEADD(MINUTE, @DuracionTurnos, @HoraActual),
                                    @IdBloque,
                                    1
                                );
                                SET @HoraActual = DATEADD(MINUTE, @DuracionTurnos, @HoraActual);
                            END
                        END
                        SET @FechaActual = DATEADD(DAY, 1, @FechaActual);
                    END
                END;
                GO
                */
    --- Consulta #04: Trigger que automatiza el proceso anterior, para que se realice cada vez que se inserta un nuevo bloque válido.
              /*CREATE TRIGGER trg_AutoGenerarTurnos
                ON Bloque_Horario
                AFTER INSERT
                AS
                BEGIN
                    SET NOCOUNT ON;

                    DECLARE @IdBloque INT;

                    SELECT @IdBloque = id_bloque FROM inserted;

                    EXEC sp_GenerarTurnosPorBloque @IdBloque;
                END;
                GO
                */
----- Función #02: Listar bloques horarios con diferentes opciones de filtrado ---------------
              /*CREATE PROCEDURE sp_ListarBloquesMedico
                    @IdMedico INT,
                    @FechaDesde DATE = NULL,
                    @FechaHasta DATE = NULL,
                    @HoraDesde TIME = NULL,
                    @HoraHasta TIME = NULL,
                    @IdDia INT = NULL
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
                */
----- Función #03: Desactivar bloques horarios y sus turnos asociados (menos los reservados) -
              /*CREATE PROCEDURE sp_EliminarBloqueHorario
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
                */
----- Función #05: Función que lista las reservas próximas del médico con diferentes filtros -
              /*CREATE PROCEDURE sp_ListarAgendaMedico
                    @IdMedico INT,                     -- obligatorio: id del médico (Usuario.id_usuario)
                    @FechaDesde DATE = NULL,           -- opcional: filtro fecha desde
                    @FechaHasta DATE = NULL,           -- opcional: filtro fecha hasta
                    @IdPaciente INT = NULL,            -- opcional: filtrar por paciente
                    @IdDia INT = NULL,                 -- opcional: filtrar por día de la semana (id_dia)
                    @HoraDesde TIME = NULL,            -- opcional: filtrar jornadas (hora inicio >=)
                    @HoraHasta TIME = NULL,            -- opcional: filtrar jornadas (hora fin <=)
                    @SoloProximas BIT = 1              -- 1 = por defecto mostrar desde hoy hacia adelante
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
                    INNER JOIN Usuario U ON BH.id_medico = U.id_usuario    -- U = médico
                    INNER JOIN Paciente P ON R.id_paciente = P.id_paciente
                    LEFT JOIN Obra_Social OS ON R.id_obra_social = OS.id_obra_social   -- opcional
                    LEFT JOIN Estado_Reserva ER ON R.id_estado = ER.id_estado
                    LEFT JOIN Día D ON BH.id_dia = D.id_dia
                    WHERE
                        BH.id_medico = @IdMedico
                        AND (@SoloProximas = 0 OR T.fecha_turno >= CAST(GETDATE() AS DATE))  -- por defecto próximas
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
                */
----- Función #06: Función que permite acceder al historial del paciente ---------------------
              /*CREATE OR ALTER PROCEDURE sp_ObtenerHistorialPaciente
                    @IdPaciente INT,
                    @SoloFinalizados BIT = 1,       -- 1 = solo reservas finalizadas (asistidas); 0 = todas
                    @FechaDesde DATE = NULL,
                    @FechaHasta DATE = NULL
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
                        U.id_usuario AS id_medico,
                        U.nombre AS medico_nombre,
                        U.apellido AS medico_apellido,
                        Esp.nombre AS especialidad_medico,
                        OS.id_obra_social,
                        OS.nombre AS obra_social
                    FROM Reserva R
                    INNER JOIN Turno T ON R.id_turno = T.id_turno
                    INNER JOIN Bloque_Horario BH ON T.id_bloque = BH.id_bloque
                    INNER JOIN Usuario U ON BH.id_medico = U.id_usuario
                    LEFT JOIN Especialidad Esp ON U.id_especialidad = Esp.id_especialidad
                    LEFT JOIN Obra_Social OS ON R.id_obra_social = OS.id_obra_social
                    LEFT JOIN Estado_Reserva ER ON R.id_estado = ER.id_estado
                    WHERE
                        R.id_paciente = @IdPaciente
                        AND (@SoloFinalizados = 0 OR R.id_estado = (SELECT id_estado FROM Estado_Reserva WHERE nombre = 'Finalizado'))
                        AND (@FechaDesde IS NULL OR T.fecha_turno >= @FechaDesde)
                        AND (@FechaHasta IS NULL OR T.fecha_turno <= @FechaHasta)
                    ORDER BY
                        T.fecha_turno DESC,     -- historial: más recientes primero
                        T.hora_inicio DESC;
                END;
                GO
                */
----- Función #0: Reportes estadísticas del médico -------------------------------------------
--============================================================================================
----- Administrador ==========================================================================
--- Funciones #01: Crear Usuario
--- Función #02: Listar Usuarios con diferentes filtros
--- Función #03: Desactivar Usuario
--- Funciones #04: Reportes de la clínica

