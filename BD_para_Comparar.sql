
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
        ER.nombre AS EstadoTurno -- ? Usa el alias de Estado_Reserva
    FROM Turno T
    JOIN Bloque_Horario BH ON T.id_bloque = BH.id_bloque
    JOIN Día D ON BH.id_dia = D.id_dia
    -- ? CAMBIO 1: Se une a la tabla correcta 'Estado_Reserva'
    JOIN Estado_Reserva ER ON T.id_estado_turno = ER.id_estado 
    WHERE
        -- ? CAMBIO 2: Se usa 'id_usuario' de la tabla Bloque_Horario
        BH.id_usuario = @IdMedico
        -- ? CAMBIO 3: Se filtra por el ID de 'Disponible' (que es 5)
        AND T.id_estado_turno = 5 
        AND T.fecha_turno >= CAST(GETDATE() AS DATE)
        AND BH.fecha_fin >= CAST(GETDATE() AS DATE)
        AND (@FechaInicio IS NULL OR T.fecha_turno >= @FechaInicio)
        AND (@FechaFin IS NULL OR T.fecha_turno <= @FechaFin)
        AND (@IdDia IS NULL OR BH.id_dia = @IdDia)
    ORDER BY T.fecha_turno, T.hora_inicio;
END;
GO
----------------
CREATE OR ALTER PROCEDURE rec_ObtenerTurnosDisponiblesConMedico
    @IdMedico INT,
    @FechaInicio DATE = NULL,
    @FechaFin DATE = NULL,
    @IdDia INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        T.id_turno,
        -- ? CAMBIO CLAVE: Se usa ISNULL para prevenir el error.
        -- Si el nombre es NULL, usa ''. Si el apellido es NULL, usa ''.
        ISNULL(U.nombre, '') + ' ' + ISNULL(U.apellido, '') AS Medico,
        T.fecha_turno,
        T.hora_inicio,
        T.hora_fin,
        D.nombre AS DiaSemana,
        ER.nombre AS EstadoTurno
    FROM Turno T
    JOIN Bloque_Horario BH ON T.id_bloque = BH.id_bloque
    JOIN Día D ON BH.id_dia = D.id_dia
    JOIN Usuario U ON BH.id_usuario = U.id_usuario
    JOIN Estado_Reserva ER ON T.id_estado_turno = ER.id_estado
    WHERE
        BH.id_usuario = @IdMedico
        AND T.id_estado_turno = 5 -- Disponible
        AND (@FechaInicio IS NULL OR T.fecha_turno >= @FechaInicio)
        AND (@FechaFin IS NULL OR T.fecha_turno <= @FechaFin)
        AND (@IdDia IS NULL OR BH.id_dia = @IdDia)
    ORDER BY T.fecha_turno, T.hora_inicio;
END;
GO
-------------
---------
-- Esto arregla la visualizacion de la lista de pacientes 

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
        P.edad, -- ? AÑADIDO
        ISNULL(OS.nombre, 'Particular') AS obra_social, -- ? AÑADIDO
        P.apellido + ', ' + P.nombre + ' (' + P.dni + ')' AS DisplayText
    FROM Paciente P
    LEFT JOIN Obra_Social OS ON P.id_obra_social = OS.id_obra_social
    WHERE
        @Filtro IS NULL
        OR P.nombre LIKE '%' + @Filtro + '%'
        OR P.apellido LIKE '%' + @Filtro + '%'
        OR P.dni LIKE '%' + @Filtro + '%'
    ORDER BY P.apellido, P.nombre;
END;
GO
-----------
ALTER PROCEDURE med_ListarAgendaMedico
    @IdMedico INT,
    @FechaDesde DATE = NULL,
    @FechaHasta DATE = NULL,
    @FiltroPaciente VARCHAR(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        R.id_reserva,
        MC.descripcion AS motivo_consulta,
        ER.nombre AS estado_reserva,
        T.fecha_turno,
        T.hora_inicio,
        P.apellido + ', ' + P.nombre AS Paciente,
        P.dni AS DNI, -- <-- ¡AQUÍ ESTÁ LA LÍNEA AÑADIDA!
        ISNULL(NULLIF(OS.nombre, ''), 'Particular') AS obra_social

    FROM Reserva R
    -- ... (el resto del procedimiento es igual)
    INNER JOIN Turno T ON R.id_turno = T.id_turno
    INNER JOIN Bloque_Horario BH ON T.id_bloque = BH.id_bloque
    INNER JOIN Paciente P ON R.id_paciente = P.id_paciente
    INNER JOIN Estado_Reserva ER ON R.id_estado = ER.id_estado
    LEFT JOIN Motivo_Consulta MC ON R.id_motivo_consulta = MC.id_motivo_consulta
    LEFT JOIN Obra_Social OS ON P.id_obra_social = OS.id_obra_social
    WHERE
        BH.id_usuario = @IdMedico
        AND (
             T.fecha_turno > CAST(GETDATE() AS DATE)
             OR
             (T.fecha_turno = CAST(GETDATE() AS DATE) AND T.hora_inicio >= CAST(GETDATE() AS TIME))
            )
        AND R.id_estado <> 3 -- Excluimos los cancelados (ID 3 en tu sistema es Cancelado)
        AND (@FechaDesde IS NULL OR T.fecha_turno >= @FechaDesde)
        AND (@FechaHasta IS NULL OR T.fecha_turno <= @FechaHasta)
        AND (@FiltroPaciente IS NULL OR P.dni LIKE '%' + @FiltroPaciente + '%' OR P.apellido LIKE '%' + @FiltroPaciente + '%')
    ORDER BY
        T.fecha_turno ASC,
        T.hora_inicio ASC;
END;
GO
------------
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
        BH.id_usuario = @IdMedico -- Asumiendo que usas id_usuario aquí
    ORDER BY
        D.id_dia;
END
GO

-------------------------------------------------------------------------
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

-- Tabla Usuario --
-- Estos índices son para filtrar rápidamente por rol (ej. 'mostrar solo médicos') y por especialidad. 

-- Para filtrar por rol
CREATE INDEX IDX_Usuario_id_rol ON Usuario (id_rol);

-- Para encontrar médicos de una especialidad específica
CREATE INDEX IDX_Usuario_id_especialidad ON Usuario (id_especialidad);

-- Tabla Turno --
-- Esta tabla va a crecer constantemente y se la va a consultar muchas veces, asi que conviene indexarla 

-- Esencial para las uniones (JOIN) con Bloque_Horario
CREATE INDEX IDX_Turno_id_bloque ON Turno (id_bloque);

-- La más importante para que la búsqueda por fecha o rango de fechas sea instantánea
CREATE INDEX IDX_Turno_fecha_turno ON Turno (fecha_turno);

-- Acelera la búsqueda de turnos 'Disponibles'
CREATE INDEX IDX_Turno_id_estado_turno ON Turno (id_estado_turno);

-- Tabla Reserva -- 
-- Clave para buscar todas las reservas de un paciente rápidamente
CREATE INDEX IDX_Reserva_id_paciente ON Reserva (id_paciente);

-- Hará que tus futuros reportes estadísticos por motivo sean mucho más rápidos
CREATE INDEX IDX_Reserva_id_motivo_consulta ON Reserva (motivo_consulta);


CREATE TABLE Estado_Turno (
  id_estado_turno INT NOT NULL,
  nombre VARCHAR(20) NOT NULL,
  CONSTRAINT PK_Estado_Turno PRIMARY KEY (id_estado_turno)
);

INSERT INTO Estado_Turno (id_estado_turno, nombre)
VALUES (1, 'Disponible'), (2, 'Reservado'), (3, 'Inactivo');
GO

ALTER PROCEDURE med_ListarHistorialMedico
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
        P.apellido + ', ' + P.nombre AS [Nombre del Paciente],
        P.dni AS [DNI],
        MC.descripcion AS [Motivo de Consulta], -- <-- ¡AQUÍ ESTÁ LA LÍNEA AÑADIDA!

        CASE
            WHEN R.id_estado = 2 THEN 'Finalizado'
            WHEN R.id_estado = 1 THEN 'No Asistió'
        END AS [Estado],

        CASE
            WHEN R.id_estado = 1 THEN '(No asistió el Paciente)'
            WHEN R.id_estado = 2 AND ISNULL(R.diagnostico, '') = '' THEN 'Sin diagnóstico'
            ELSE R.diagnostico
        END AS [Diagnóstico]

    FROM Reserva R
    -- ... (el resto del procedimiento es igual)
    INNER JOIN Turno T ON R.id_turno = T.id_turno
    INNER JOIN Bloque_Horario BH ON T.id_bloque = BH.id_bloque
    INNER JOIN Usuario U ON BH.id_usuario = U.id_usuario
    INNER JOIN Paciente P ON R.id_paciente = P.id_paciente
    INNER JOIN Estado_Reserva ER ON R.id_estado = ER.id_estado
    LEFT JOIN Motivo_Consulta MC ON MC.id_motivo_consulta = R.id_motivo_consulta
    WHERE
        BH.id_usuario = @IdMedico
        AND (
             T.fecha_turno < CAST(GETDATE() AS DATE)
             OR
             (T.fecha_turno = CAST(GETDATE() AS DATE) AND T.hora_inicio < CAST(GETDATE() AS TIME))
            )
        AND R.id_estado IN (1, 2)
        AND (@FechaDesde IS NULL OR T.fecha_turno >= @FechaDesde)
        AND (@FechaHasta IS NULL OR T.fecha_turno <= @FechaHasta)
        AND (@FiltroPaciente IS NULL 
            OR P.dni LIKE '%' + @FiltroPaciente + '%'
            OR P.apellido LIKE '%' + @FiltroPaciente + '%')
    ORDER BY
        T.fecha_turno DESC, T.hora_inicio DESC;
END;
GO

ALTER PROCEDURE med_FinalizarReserva
    @IdReserva INT,
    @Diagnostico VARCHAR(500)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Reserva
    SET
        diagnostico = @Diagnostico,
        id_estado = 2 -- CORRECCIÓN: Usamos el ID 2 para 'Finalizado'
    WHERE
        id_reserva = @IdReserva;
END
GO

ALTER PROCEDURE rec_ObtenerTurnosDisponiblesConMedico
    @IdMedico INT,
    @FechaInicio DATE = NULL,
    @FechaFin DATE = NULL,
    @IdDia INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        T.id_turno,
        U.apellido + ', ' + U.nombre AS Medico,
        T.fecha_turno,
        T.hora_inicio,
        T.hora_fin,
        D.nombre AS DiaSemana
    FROM Turno T
    INNER JOIN Bloque_Horario BH ON T.id_bloque = BH.id_bloque
    INNER JOIN Día D ON BH.id_dia = D.id_dia
    INNER JOIN Usuario U ON BH.id_usuario = U.id_usuario
    WHERE
        BH.id_usuario = @IdMedico
        -- CORRECCIÓN: El ID para turnos disponibles es 5
        AND T.id_estado_turno = 5 
        AND T.fecha_turno >= CAST(GETDATE() AS DATE)
        AND (@FechaInicio IS NULL OR T.fecha_turno >= @FechaInicio)
        AND (@FechaFin IS NULL OR T.fecha_turno <= @FechaFin)
        AND (@IdDia IS NULL OR BH.id_dia = @IdDia)
    ORDER BY T.fecha_turno, T.hora_inicio;
END;
GO

CREATE OR ALTER PROCEDURE med_ListarAgendaMedico
    @IdMedico INT,
    @FechaDesde DATE = NULL,
    @FechaHasta DATE = NULL,
    @FiltroPaciente VARCHAR(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        R.id_reserva,
        MC.descripcion AS motivo_consulta,
        ER.nombre AS estado_reserva,
        -------------------------------------------------

        T.fecha_turno,
        T.hora_inicio,
        P.apellido + ', ' + P.nombre AS Paciente,
        ISNULL(NULLIF(OS.nombre, ''), 'Particular') AS obra_social
        
    FROM Reserva R
    INNER JOIN Turno T ON R.id_turno = T.id_turno
    INNER JOIN Bloque_Horario BH ON T.id_bloque = BH.id_bloque
    INNER JOIN Paciente P ON R.id_paciente = P.id_paciente
    INNER JOIN Estado_Reserva ER ON R.id_estado = ER.id_estado -- Asegúrate de tener este JOIN
    LEFT JOIN Motivo_Consulta MC ON R.id_motivo_consulta = MC.id_motivo_consulta
    LEFT JOIN Obra_Social OS ON P.id_obra_social = OS.id_obra_social
    WHERE
        BH.id_usuario = @IdMedico
        -- La lógica de la agenda es mostrar lo que está por venir
        AND (
             T.fecha_turno > CAST(GETDATE() AS DATE)
             OR
             (T.fecha_turno = CAST(GETDATE() AS DATE) AND T.hora_inicio >= CAST(GETDATE() AS TIME))
            )
        AND R.id_estado <> 3 -- Excluimos los cancelados (ID 3)
        AND (@FechaDesde IS NULL OR T.fecha_turno >= @FechaDesde)
        AND (@FechaHasta IS NULL OR T.fecha_turno <= @FechaHasta)
        AND (@FiltroPaciente IS NULL OR P.dni LIKE '%' + @FiltroPaciente + '%' OR P.apellido LIKE '%' + @FiltroPaciente + '%')
    ORDER BY
        T.fecha_turno ASC,
        T.hora_inicio ASC;
END;
GO

--Ultima correccion xd 
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

    -- Validar solapamiento ÚNICAMENTE con otros bloques ACTIVOS del mismo médico
    IF EXISTS (
        SELECT 1
        FROM Bloque_Horario bh
        WHERE 
            bh.id_usuario = @IdMedico
            AND bh.activo = 1 -- ¡CORRECCIÓN CLAVE! Ignora los bloques con activo = 0
            AND bh.id_dia = @IdDia
            AND @FechaInicio <= bh.fecha_fin
            AND @FechaFin >= bh.fecha_inicio
            AND @HoraInicio < bh.hora_fin
            AND @HoraFin > bh.hora_inicio
    )
    BEGIN
        RAISERROR('El médico ya tiene un bloque ACTIVO que se solapa en ese rango de fechas y horas para ese día.', 16, 1);
        RETURN;
    END;

    -- Si no hay conflicto, inserta el nuevo bloque (que por defecto será activo)
    INSERT INTO Bloque_Horario (
        fecha_inicio, fecha_fin, hora_inicio, hora_fin,
        duracion_turnos, activo, id_usuario, id_dia
    )
    VALUES (
        @FechaInicio, @FechaFin, @HoraInicio, @HoraFin,
        @DuracionTurnos, 1, @IdMedico, @IdDia
    );
END;
GO

-----------
CREATE OR ALTER PROCEDURE med_GenerarTurnosPorBloque
    @IdBloque INT
AS
BEGIN
    SET NOCOUNT ON;
    SET DATEFIRST 1;

    DECLARE 
        @FechaInicio DATE, @FechaFin DATE,
        @HoraInicio TIME, @HoraFin TIME,
        @DuracionTurnos INT, @IdDia INT;

    SELECT 
        @FechaInicio = BH.fecha_inicio,
        @FechaFin = BH.fecha_fin,
        @HoraInicio = BH.hora_inicio,
        @HoraFin = BH.hora_fin,
        @DuracionTurnos = BH.duracion_turnos,
        @IdDia = BH.id_dia
    FROM Bloque_Horario BH
    WHERE BH.id_bloque = @IdBloque;

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
                    1 -- CORREGIDO: Los nuevos turnos se crean como 'Disponible' (ID 1 de Estado_Turno)
                );
                SET @HoraActual = DATEADD(MINUTE, @DuracionTurnos, @HoraActual);
            END
        END
        SET @FechaActual = DATEADD(DAY, 1, @FechaActual);
    END
END;
GO
----------
CREATE OR ALTER PROCEDURE rec_ObtenerTurnosDisponiblesConMedico
    @IdMedico INT,
    @FechaInicio DATE = NULL,
    @FechaFin DATE = NULL,
    @IdDia INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        T.id_turno,
        U.apellido + ', ' + U.nombre AS Medico,
        T.fecha_turno,
        T.hora_inicio,
        T.hora_fin,
        D.nombre AS DiaSemana,
        ET.nombre AS EstadoTurno
    FROM Turno T
    INNER JOIN Bloque_Horario BH ON T.id_bloque = BH.id_bloque
    INNER JOIN Día D ON BH.id_dia = D.id_dia
    INNER JOIN Usuario U ON BH.id_usuario = U.id_usuario
    INNER JOIN Estado_Turno ET ON T.id_estado_turno = ET.id_estado_turno
    WHERE
        BH.id_usuario = @IdMedico
        AND T.id_estado_turno = 1 -- CORREGIDO: Busca turnos con estado 'Disponible' (ID 1 de Estado_Turno)
        AND T.fecha_turno >= CAST(GETDATE() AS DATE)
        AND (@FechaInicio IS NULL OR T.fecha_turno >= @FechaInicio)
        AND (@FechaFin IS NULL OR T.fecha_turno <= @FechaFin)
        AND (@IdDia IS NULL OR BH.id_dia = @IdDia)
    ORDER BY T.fecha_turno, T.hora_inicio;
END;
GO
-------------
CREATE OR ALTER PROCEDURE rec_RegistrarReserva
    @IdTurno INT,
    @IdPaciente INT,
    @IdMotivoConsulta INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;

    -- Paso 1: Crear la cita del paciente en la tabla Reserva
    -- Asumimos que 1 = 'Activa' para Estado_Reserva
    INSERT INTO Reserva (id_turno, id_paciente, id_motivo_consulta, id_estado)
    VALUES (@IdTurno, @IdPaciente, @IdMotivoConsulta, 1);

    -- Paso 2: Ocupar el espacio de tiempo en la tabla Turno
    UPDATE Turno
    SET id_estado_turno = 2 -- CORREGIDO: Actualiza el turno a 'Reservado' (ID 2 de Estado_Turno)
    WHERE id_turno = @IdTurno
      AND id_estado_turno = 1; -- Seguridad: Solo actualiza si el turno seguía disponible

    COMMIT TRANSACTION;
END;
GO
-----------------
CREATE OR ALTER PROCEDURE med_FinalizarReserva
    @IdReserva INT,
    @Diagnostico VARCHAR(500)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Reserva
    SET
        diagnostico = @Diagnostico,
        id_estado = 2 -- CORREGIDO: Usa el ID 2 para 'Finalizado' de la tabla Estado_Reserva
    WHERE
        id_reserva = @IdReserva;
END;
GO
-------------------
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
        P.apellido + ', ' + P.nombre AS [Nombre del Paciente],
        P.dni AS [DNI],
        MC.descripcion AS [Motivo de Consulta],
        
        CASE
            WHEN R.id_estado = 2 THEN 'Finalizado'
            WHEN R.id_estado = 1 THEN 'No Asistió'
        END AS [Estado],

        CASE
            WHEN R.id_estado = 1 THEN '(No asistió el Paciente)'
            WHEN R.id_estado = 2 AND ISNULL(R.diagnostico, '') = '' THEN 'Sin diagnóstico'
            ELSE R.diagnostico
        END AS [Diagnóstico]
        
    FROM Reserva R
    INNER JOIN Turno T ON R.id_turno = T.id_turno
    INNER JOIN Bloque_Horario BH ON T.id_bloque = BH.id_bloque
    INNER JOIN Usuario U ON BH.id_usuario = U.id_usuario
    INNER JOIN Paciente P ON R.id_paciente = P.id_paciente
    INNER JOIN Estado_Reserva ER ON R.id_estado = ER.id_estado
    LEFT JOIN Motivo_Consulta MC ON MC.id_motivo_consulta = R.id_motivo_consulta
    WHERE
        BH.id_usuario = @IdMedico
        AND (
             T.fecha_turno < CAST(GETDATE() AS DATE)
             OR
             (T.fecha_turno = CAST(GETDATE() AS DATE) AND T.hora_inicio < CAST(GETDATE() AS TIME))
            )
        -- CORREGIDO: El historial se compone de 'Activas' (1) y 'Finalizadas' (2)
        AND R.id_estado IN (1, 2) 
        AND (@FechaDesde IS NULL OR T.fecha_turno >= @FechaDesde)
        AND (@FechaHasta IS NULL OR T.fecha_turno <= @FechaHasta)
        AND (@FiltroPaciente IS NULL 
            OR P.dni LIKE '%' + @FiltroPaciente + '%'
            OR P.apellido LIKE '%' + @FiltroPaciente + '%')
    ORDER BY
        T.fecha_turno DESC, T.hora_inicio DESC;
END;
GO

CREATE OR ALTER PROCEDURE rec_BuscarMedico
    @IdEspecialidad INT = NULL,
    @TextoBusquedaNombre VARCHAR(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        U.id_usuario,
        U.apellido + ', ' + U.nombre AS NombreCompleto
        
    FROM Usuario U
    JOIN Rol R ON U.id_rol = R.id_rol
    WHERE
        U.id_rol = 2 -- Médico
        AND (@IdEspecialidad IS NULL OR U.id_especialidad = @IdEspecialidad)
        AND (
            @TextoBusquedaNombre IS NULL
            OR UPPER(TRIM(U.nombre)) LIKE '%' + UPPER(TRIM(@TextoBusquedaNombre)) + '%'
            OR UPPER(TRIM(U.apellido)) LIKE '%' + UPPER(TRIM(@TextoBusquedaNombre)) + '%'
        )
    ORDER BY U.apellido, U.nombre;
END;
GO
-------------

CREATE OR ALTER PROCEDURE rec_ListarReservasPacientes
    @Filtro VARCHAR(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT  
        R.id_reserva,
        T.fecha_turno,
        T.hora_inicio,
        P.apellido + ', ' + P.nombre AS Paciente,
        P.dni AS DniPaciente,
        U.apellido + ', ' + U.nombre AS Medico,
        ER.nombre AS EstadoReserva
    FROM Reserva R
    INNER JOIN Turno T ON R.id_turno = T.id_turno
    INNER JOIN Paciente P ON R.id_paciente = P.id_paciente
    INNER JOIN Estado_Reserva ER ON R.id_estado = ER.id_estado
    INNER JOIN Bloque_Horario BH ON T.id_bloque = BH.id_bloque
    INNER JOIN Usuario U ON BH.id_usuario = U.id_usuario
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

------ PROCEDIMIENTO PARA EL BACKUP DE LOS DATOS ----------- 

USE MedoraDB;
GO

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

----------
CREATE OR ALTER PROCEDURE rec_CancelarReserva
    @IdReserva INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;

    DECLARE @IdTurno INT;

    -- 1. Validar que la reserva exista y no esté ya finalizada o cancelada
    IF NOT EXISTS (SELECT 1 FROM Reserva WHERE id_reserva = @IdReserva AND id_estado = 1)
    BEGIN
        ROLLBACK TRANSACTION;
        RAISERROR('La reserva no existe o ya ha sido finalizada/cancelada.', 16, 1);
        RETURN;
    END

    -- 2. Obtener el ID del turno asociado a la reserva
    SELECT @IdTurno = id_turno FROM Reserva WHERE id_reserva = @IdReserva;

    -- 3. Actualizar el estado de la Reserva a 'Cancelado' (ID 3)
    UPDATE Reserva
    SET id_estado = 3
    WHERE id_reserva = @IdReserva;

    -- 4. Actualizar el estado del Turno a 'Disponible' (ID 1 de Estado_Turno)
    UPDATE Turno
    SET id_estado_turno = 1
    WHERE id_turno = @IdTurno;

    COMMIT TRANSACTION;
END;
GO 
------------- 

-- Asegúrate de estar en tu base de datos
USE MedoraDB;
GO

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
            CASE WHEN R.id_estado = 2 THEN 1 ELSE 0 END AS Atendido,
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
            AND R.id_estado IN (1, 2) -- 1='Reservado'(Ausencia), 2='Finalizado'(Atendido)
            -- (No es necesario el IdMedico aquí porque es un reporte global)
    )
    -- 2. Hacemos los cálculos sobre ese conjunto de datos
    SELECT
        -- KPI 1: Total de Turnos Atendidos (del SP anterior, sigue siendo útil)
        (SELECT COUNT(*) FROM Reserva R JOIN Turno T ON R.id_turno = T.id_turno WHERE T.fecha_turno BETWEEN @FechaDesde AND @FechaHasta AND R.id_estado = 2) AS TotalTurnosAtendidos,

        -- KPI 2: Especialidad Más Popular (del SP anterior)
        (SELECT TOP 1 E.nombre FROM Reserva R JOIN Turno T ON R.id_turno = T.id_turno JOIN Bloque_Horario BH ON T.id_bloque = BH.id_bloque JOIN Usuario U ON BH.id_usuario = U.id_usuario JOIN Especialidad E ON U.id_especialidad = E.id_especialidad WHERE T.fecha_turno BETWEEN @FechaDesde AND @FechaHasta AND R.id_estado IN (1, 2) GROUP BY E.nombre ORDER BY COUNT(*) DESC) AS EspecialidadPopular,

        -- KPI 3: Médico Más Activo (del SP anterior)
        (SELECT TOP 1 U.apellido + ', ' + U.nombre FROM Reserva R JOIN Turno T ON R.id_turno = T.id_turno JOIN Bloque_Horario BH ON T.id_bloque = BH.id_bloque JOIN Usuario U ON BH.id_usuario = U.id_usuario WHERE T.fecha_turno BETWEEN @FechaDesde AND @FechaHasta AND R.id_estado = 2 GROUP BY U.apellido, U.nombre ORDER BY COUNT(*) DESC) AS MedicoMasActivo,
        
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
    JOIN Usuario U ON BH.id_usuario = U.id_usuario
    JOIN Especialidad E ON U.id_especialidad = E.id_especialidad
    WHERE T.fecha_turno BETWEEN @FechaDesde AND @FechaHasta AND R.id_estado IN (1, 2)
    GROUP BY E.nombre ORDER BY Cantidad DESC;
END
GO

-- 3. Grafico de porcentajes 
CREATE OR ALTER PROCEDURE admin_EstadisticaClinicaGeneral
    @FechaInicio DATE,
    @FechaFin DATE
AS
BEGIN
    SET NOCOUNT ON;

    -- 1) CTE que reúne todas las reservas del período, corrigiendo el nombre de la columna
    WITH ReservasClinica AS (
        SELECT
            R.id_estado,
            T.fecha_turno,
            BH.id_usuario -- CORRECCIÓN: Se usa id_usuario
        FROM Reserva R
        INNER JOIN Turno T ON R.id_turno = T.id_turno
        INNER JOIN Bloque_Horario BH ON T.id_bloque = BH.id_bloque
        WHERE T.fecha_turno BETWEEN @FechaInicio AND @FechaFin
    )
    -- 2) Calcular y devolver todos los agregados en un solo paso
    SELECT
        -- Total de reservas registradas en el período (incluyendo canceladas)
        COUNT(*) AS [Reservas Programadas],

        -- Total 'Finalizado' (ID 2)
        ISNULL(SUM(CASE WHEN id_estado = 2 THEN 1 ELSE 0 END), 0) AS [Reservas Atendidas],

        -- Total 'Cancelado' (ID 3)
        ISNULL(SUM(CASE WHEN id_estado = 3 THEN 1 ELSE 0 END), 0) AS [Reservas Canceladas],

        -- Total 'Ausencias' (ID 1 Y cuya fecha ya pasó)
        ISNULL(SUM(CASE WHEN id_estado = 1 AND fecha_turno < CAST(GETDATE() AS DATE) THEN 1 ELSE 0 END), 0) AS [Reservas con Ausencia],
        
        -- Porcentaje de Asistencia (Atendidos / (Atendidos + Ausencias))
        -- Esta es una métrica mucho más precisa del rendimiento.
        CAST(
            ISNULL(SUM(CASE WHEN id_estado = 2 THEN 1 ELSE 0 END), 0) * 100.0 /
            NULLIF( ISNULL(SUM(CASE WHEN id_estado = 2 THEN 1 ELSE 0 END), 0) + ISNULL(SUM(CASE WHEN id_estado = 1 AND fecha_turno < CAST(GETDATE() AS DATE) THEN 1 ELSE 0 END), 0) , 0)
        AS DECIMAL(5,2)) AS [% Atendidas (s/ Atendibles)],
        
        -- Porcentaje de Cancelación (Cancelados / Total Programadas)
        CAST(
            ISNULL(SUM(CASE WHEN id_estado = 3 THEN 1 ELSE 0 END), 0) * 100.0 /
            NULLIF(COUNT(*), 0)
        AS DECIMAL(5,2)) AS [% Canceladas (s/ Total)],

        -- Promedio de Atendidas por Médico que trabajó en el período
        CAST(
            ISNULL(SUM(CASE WHEN id_estado = 2 THEN 1 ELSE 0 END), 0) * 1.0 /
            NULLIF(COUNT(DISTINCT id_usuario), 0) -- Cuenta los médicos únicos que tuvieron reservas
        AS DECIMAL(6,2)) AS [Promedio de Reservas Atendidas por Médico]

    FROM ReservasClinica;
END;
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
                R.id_estado = 2 OR -- 2. Finalizado (Atendido)
                R.id_estado = 3 OR -- 3. Cancelado
                (R.id_estado = 1 AND T.fecha_turno < CAST(GETDATE() AS DATE)) -- 1. Activo que ya pasó (Ausencia)
            )
    )
    -- Contamos y agrupamos los resultados
    SELECT 
        CASE 
            WHEN id_estado = 2 THEN 'Atendidas'
            WHEN id_estado = 3 THEN 'Canceladas'
            WHEN id_estado = 1 THEN 'Ausencias'
        END AS Estado,
        COUNT(*) AS Cantidad
    FROM ReservasFinalizadas
    GROUP BY 
        CASE 
            WHEN id_estado = 2 THEN 'Atendidas'
            WHEN id_estado = 3 THEN 'Canceladas'
            WHEN id_estado = 1 THEN 'Ausencias'
        END;
END
GO

-- ===================================================================
-- PROCEDIMIENTOS PARA EL DASHBOARD DEL MÉDICO
-- ===================================================================

-- 1. KPIs de Actividad del Médico
CREATE OR ALTER PROCEDURE med_EstadisticaActividadMedico
    @IdMedico INT,
    @FechaDesde DATE,
    @FechaHasta DATE
AS
BEGIN
    SET NOCOUNT ON;

    WITH TurnosMedico AS (
        SELECT T.fecha_turno, R.id_estado AS EstadoReserva
        FROM Turno T
        INNER JOIN Bloque_Horario BH ON T.id_bloque = BH.id_bloque
        INNER JOIN Reserva R ON T.id_turno = R.id_turno
        WHERE BH.id_usuario = @IdMedico 
          AND T.fecha_turno BETWEEN @FechaDesde AND @FechaHasta
    )
    SELECT
        COUNT(*) AS [Reservas Programadas],

        -- ===== CORRECCIONES (Envueltos en ISNULL) =====
        ISNULL(SUM(CASE WHEN EstadoReserva = 2 THEN 1 ELSE 0 END), 0) AS [Reservas Atendidas],
        ISNULL(SUM(CASE WHEN EstadoReserva = 3 THEN 1 ELSE 0 END), 0) AS [Reservas Canceladas],
        ISNULL(SUM(CASE WHEN EstadoReserva = 1 AND fecha_turno < CAST(GETDATE() AS DATE) THEN 1 ELSE 0 END), 0) AS Ausencias,
        
        -- Cálculo de Porcentaje Corregido (con ISNULL externo también)
        ISNULL(CAST(
            ISNULL(SUM(CASE WHEN EstadoReserva = 2 THEN 1 ELSE 0 END), 0) * 100.0 /
            NULLIF( ISNULL(SUM(CASE WHEN EstadoReserva = 2 THEN 1 ELSE 0 END), 0) + ISNULL(SUM(CASE WHEN EstadoReserva = 1 AND fecha_turno < CAST(GETDATE() AS DATE) THEN 1 ELSE 0 END), 0) , 0)
        AS DECIMAL(5,2)), 0.00) AS [Porcentaje de Asistencia],
        
        -- Cálculo de Promedio Corregido (con ISNULL externo también)
        ISNULL(CAST(
            ISNULL(SUM(CASE WHEN EstadoReserva = 2 THEN 1 ELSE 0 END), 0) * 1.0 /
            NULLIF(((DATEDIFF(DAY, @FechaDesde, @FechaHasta) + 1) / 7.0), 0)
        AS DECIMAL(5,2)), 0.00) AS [Promedio Semanal de Pacientes Atendidos]
        
    FROM TurnosMedico;
END;
GO

-- 2. Gráfico de Motivos de Consulta del Médico
CREATE OR ALTER PROCEDURE med_EstadisticaMotivosMedico
    @IdMedico INT,
    @FechaDesde DATE,
    @FechaHasta DATE
AS
BEGIN
    SET NOCOUNT ON;

    -- 1. CTE para obtener todas las consultas finalizadas (igual que antes)
    WITH ConsultasMedico AS (
        SELECT MC.descripcion AS MotivoConsulta
        FROM Reserva R
        INNER JOIN Turno T ON R.id_turno = T.id_turno
        INNER JOIN Bloque_Horario BH ON T.id_bloque = BH.id_bloque
        INNER JOIN Motivo_Consulta MC ON R.id_motivo_consulta = MC.id_motivo_consulta
        WHERE BH.id_usuario = @IdMedico
          AND R.id_estado = 2 -- Finalizado
          AND T.fecha_turno BETWEEN @FechaDesde AND @FechaHasta
    ),
    -- 2. CTE para contar y rankear los motivos
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
    WHERE T.fecha_turno BETWEEN @FechaDesde AND @FechaHasta AND R.id_estado <> 3
    GROUP BY DATENAME(weekday, T.fecha_turno), DATEPART(weekday, T.fecha_turno)
    ORDER BY DATEPART(weekday, T.fecha_turno) ASC;
END
GO

-------------------
CREATE OR ALTER PROCEDURE rec_EstadisticaPacientes
    @FechaInicio DATE,
    @FechaFin DATE
AS
BEGIN
    SET NOCOUNT ON;

    -- 1) CTE: obtener pacientes únicos con reserva en el rango
    WITH PacientesReserva AS (
        SELECT DISTINCT
            P.id_paciente,
            P.id_obra_social,
            P.Edad -- CORRECCIÓN: Usamos la columna 'Edad' (INT) directamente
        FROM Paciente P
        INNER JOIN Reserva R ON P.id_paciente = R.id_paciente
        INNER JOIN Turno T ON R.id_turno = T.id_turno
        WHERE T.fecha_turno BETWEEN @FechaInicio AND @FechaFin
          AND P.Edad IS NOT NULL -- Ignoramos pacientes sin edad registrada
    )

    -- 2) Cálculo de agregados principales (Esta parte funciona igual)
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

-----------------------------
CREATE OR ALTER PROCEDURE rec_EstadisticaObrasSociales
    @FechaInicio DATE,
    @FechaFin DATE
AS
BEGIN
    SET NOCOUNT ON;

    -- CTE: obtener pacientes únicos (con y sin obra social)
    WITH PacientesReserva AS (
        SELECT DISTINCT
            P.id_paciente,
            -- CORRECCIÓN: Usamos ISNULL para agrupar los NULL como 'Particular'
            ISNULL(OS.nombre, 'Particular') AS ObraSocial
        FROM Paciente P
        INNER JOIN Reserva R ON P.id_paciente = R.id_paciente
        INNER JOIN Turno T ON R.id_turno = T.id_turno
        -- CORRECCIÓN: Cambiado a LEFT JOIN para incluir pacientes con id_obra_social NULL
        LEFT JOIN Obra_Social OS ON P.id_obra_social = OS.id_obra_social
        WHERE T.fecha_turno BETWEEN @FechaInicio AND @FechaFin
    )

    -- Ranking de obras sociales por cantidad de pacientes únicos
    SELECT
        ObraSocial AS [Obra Social],
        COUNT(*) AS [Cantidad de Pacientes],
        -- Tu lógica de porcentaje aquí ya era perfecta
        CAST(COUNT(*) * 100.0 / SUM(COUNT(*)) OVER() AS DECIMAL(6,2)) AS [Porcentaje sobre Total]
    FROM PacientesReserva
    GROUP BY ObraSocial
    ORDER BY [Cantidad de Pacientes] DESC;
END;
GO