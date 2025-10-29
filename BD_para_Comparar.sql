SELECT TOP (1000) [id_turno]
      ,[fecha_turno]
      ,[hora_inicio]
      ,[hora_fin]
      ,[id_bloque]
  FROM [MedoraDB].[dbo].[Turno];

  CREATE PROCEDURE rec_BuscarMedico
                    @IdEspecialidad INT = NULL,
                    @TextoBusquedaNombre VARCHAR(50) = NULL
                AS
                BEGIN
                    SET NOCOUNT ON;

                    SELECT
                        U.id_usuario, -- Para el ValueMember
                        U.nombre + ' ' + U.apellido AS NombreCompleto, -- Para que devuelva el nombre completo
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
        U.nombre + ' ' + U.apellido AS Medico,
        T.fecha_turno,
        T.hora_inicio,
        T.hora_fin,
        D.nombre AS DiaSemana,
        ER.nombre AS EstadoTurno -- ? Usa 'ER' de Estado_Reserva
    FROM Turno T
    JOIN Bloque_Horario BH ON T.id_bloque = BH.id_bloque
    JOIN Día D ON BH.id_dia = D.id_dia
    JOIN Usuario U ON BH.id_usuario = U.id_usuario -- Usa 'id_usuario' como confirmamos
    JOIN Estado_Reserva ER ON T.id_estado_turno = ER.id_estado -- ? Apunta a Estado_Reserva
    WHERE
        BH.id_usuario = @IdMedico -- Usa 'id_usuario'
        AND T.id_estado_turno = 5 -- Filtra por el ID de 'Disponible'
        AND (@FechaInicio IS NULL OR T.fecha_turno >= @FechaInicio)
        AND (@FechaFin IS NULL OR T.fecha_turno <= @FechaFin)
        AND (@IdDia IS NULL OR BH.id_dia = @IdDia)
    ORDER BY T.fecha_turno, T.hora_inicio;
END;
GO


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

EXEC rec_ObtenerTurnosDisponiblesConMedico @IdMedico = 7;

CREATE OR ALTER PROCEDURE rec_ListarPacientes
    @Filtro VARCHAR(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        P.id_paciente, -- Esencial para el ValueMember
        -- ? CAMBIO CLAVE: Creamos una columna combinada para mostrar en el ComboBox
        P.apellido + ', ' + P.nombre + ' (' + P.dni + ')' AS DisplayText,
        P.nombre,
        P.apellido,
        P.dni,
        P.telefono,
        P.email,
        ISNULL(OS.nombre, 'Particular') AS obra_social
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


CREATE OR ALTER PROCEDURE rec_RegistrarReserva
                    @IdTurno INT,
                    @IdPaciente INT,
                    @MotivoConsulta INT
                AS
                BEGIN
                    SET NOCOUNT ON;

                    -- Validar que el turno esté disponible
                    IF NOT EXISTS (SELECT 1 FROM Turno WHERE id_turno = @IdTurno AND id_estado_turno = 5)
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