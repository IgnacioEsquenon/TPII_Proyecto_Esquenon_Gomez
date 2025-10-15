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
VALUES (1, 'Cardiología'), (2, 'Oftalmología'), (3, 'Pediatría'), (4, 'Ginecología'), (5, 'Urología'), (6, 'Atención Primaria');
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
  telefono NUMERIC(12),
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
  VALUES ('Juan', 'Pérez', '26938124', 'juan@mail.com', null, 'hash123', 6, 2);
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
  id_medico INT NOT NULL,
  id_dia INT NOT NULL,
  CONSTRAINT FK_Usuario_Bloque FOREIGN KEY (id_medico) REFERENCES Usuario(id_usuario),
  CONSTRAINT FK_Dia_Bloque FOREIGN KEY (id_dia) REFERENCES Día(id_dia),
  CONSTRAINT CK_DuracionNoNula CHECK (duracion_turnos > 0),
  CONSTRAINT CK_FechaValida CHECK (fecha_inicio < fecha_fin),
  CONSTRAINT CK_DuracionMinimaDeJornada CHECK (datediff (minute, [hora_inicio], [hora_fin]) >= [duracion_turnos])

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
END;*/
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
  email VARCHAR(50),
  telefono VARCHAR(20),
  CONSTRAINT PK_Paciente PRIMARY KEY (id_paciente),
  CONSTRAINT UK_Dni_Paciente UNIQUE (dni),
  CONSTRAINT UK_Email_Paciente UNIQUE (email),
  CONSTRAINT UK_Telefono_Paciente UNIQUE (telefono)
);

INSERT INTO Paciente (nombre, apellido, dni, email, telefono)
VALUES ('Ramón', 'Méndez', '22837412', 'ramon@mail.com', null)
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

-- CONSULTAS ===================================

-- Flujo Para Reservar (Recepcionista)
/* 1. Búsqueda de médico para reservar un turno
    SELECT
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

    2. Mostrar turnos disponibles para un médico seleccionado
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
        BH.id_medico = @id_medico
        AND ET.id_estado_turno = 1
        AND T.fecha_turno >= CAST(GETDATE() AS DATE)          -- No mostrar turnos pasados
        AND BH.fecha_fin >= CAST(GETDATE() AS DATE)            -- Solo bloques vigentes
    ORDER BY
        T.fecha_turno, T.hora_inicio;

    3. Trigger de insertado que realice la reserva, cambiando el estado de turno a ocupado
    CREATE TRIGGER TR_ValidarYActualizarTurno
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

    -- Crear
    */