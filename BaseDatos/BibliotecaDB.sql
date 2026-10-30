/*
   Proyecto: Sistema de Gestión de Biblioteca
   Asignatura: Programación Avanzada
   Script de creación de la base de datos BibliotecaDB
   Motor: SQL Server Express
*/

-- Si la base ya existe se elimina para poder volver a ejecutar el script.
-- Al hacer esto se borran todos los datos que tenga.
USE master;
GO

IF DB_ID('BibliotecaDB') IS NOT NULL
BEGIN
    ALTER DATABASE BibliotecaDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE BibliotecaDB;
END
GO

CREATE DATABASE BibliotecaDB;
GO

USE BibliotecaDB;
GO

/*
   TABLA AUTORES
*/
CREATE TABLE Autores (
    IdAutor          INT IDENTITY(1,1) NOT NULL,
    Nombre           NVARCHAR(60)  NOT NULL,
    Apellido         NVARCHAR(60)  NOT NULL,
    Nacionalidad     NVARCHAR(50)  NULL,
    FechaNacimiento  DATE          NULL,
    CONSTRAINT PK_Autores PRIMARY KEY (IdAutor)
);
GO

/*
   TABLA EDITORIALES
*/
CREATE TABLE Editoriales (
    IdEditorial  INT IDENTITY(1,1) NOT NULL,
    Nombre       NVARCHAR(100) NOT NULL,
    Pais         NVARCHAR(50)  NULL,
    Telefono     NVARCHAR(20)  NULL,
    Correo       NVARCHAR(100) NULL,
    CONSTRAINT PK_Editoriales PRIMARY KEY (IdEditorial),
    CONSTRAINT UQ_Editoriales_Nombre UNIQUE (Nombre)
);
GO

/* 
   TABLA LIBROS
   Existencias = total de ejemplares que tiene la biblioteca
   Disponibles = ejemplares que se pueden prestar en este momento
*/
CREATE TABLE Libros (
    IdLibro          INT IDENTITY(1,1) NOT NULL,
    ISBN             NVARCHAR(20)  NOT NULL,
    Titulo           NVARCHAR(150) NOT NULL,
    IdAutor          INT           NOT NULL,
    IdEditorial      INT           NOT NULL,
    AnioPublicacion  INT           NULL,
    Genero           NVARCHAR(50)  NULL,
    Existencias      INT           NOT NULL,
    Disponibles      INT           NOT NULL,
    CONSTRAINT PK_Libros PRIMARY KEY (IdLibro),
    CONSTRAINT UQ_Libros_ISBN UNIQUE (ISBN),
    CONSTRAINT FK_Libros_Autores FOREIGN KEY (IdAutor)
        REFERENCES Autores (IdAutor),
    CONSTRAINT FK_Libros_Editoriales FOREIGN KEY (IdEditorial)
        REFERENCES Editoriales (IdEditorial),
    CONSTRAINT CK_Libros_Anio CHECK (AnioPublicacion IS NULL OR AnioPublicacion BETWEEN 1450 AND 2100),
    CONSTRAINT CK_Libros_Existencias CHECK (Existencias >= 0),
    CONSTRAINT CK_Libros_Disponibles CHECK (Disponibles >= 0 AND Disponibles <= Existencias)
);
GO

/*
   TABLA USUARIOS
*/
CREATE TABLE Usuarios (
    IdUsuario      INT IDENTITY(1,1) NOT NULL,
    Documento      NVARCHAR(20)  NOT NULL,
    Nombre         NVARCHAR(60)  NOT NULL,
    Apellido       NVARCHAR(60)  NOT NULL,
    Telefono       NVARCHAR(20)  NULL,
    Correo         NVARCHAR(100) NULL,
    FechaRegistro  DATE          NOT NULL CONSTRAINT DF_Usuarios_FechaRegistro DEFAULT (GETDATE()),
    CONSTRAINT PK_Usuarios PRIMARY KEY (IdUsuario),
    CONSTRAINT UQ_Usuarios_Documento UNIQUE (Documento)
);
GO

/*
   TABLA PRESTAMOS
   Estado: 'Prestado' o 'Devuelto'
   Si está prestado no tiene fecha de devolución,
   si está devuelto la fecha de devolución es obligatoria.
*/
CREATE TABLE Prestamos (
    IdPrestamo               INT IDENTITY(1,1) NOT NULL,
    IdUsuario                INT          NOT NULL,
    IdLibro                  INT          NOT NULL,
    FechaPrestamo            DATE         NOT NULL,
    FechaDevolucionPrevista  DATE         NOT NULL,
    FechaDevolucion          DATE         NULL,
    Estado                   NVARCHAR(10) NOT NULL CONSTRAINT DF_Prestamos_Estado DEFAULT ('Prestado'),
    CONSTRAINT PK_Prestamos PRIMARY KEY (IdPrestamo),
    CONSTRAINT FK_Prestamos_Usuarios FOREIGN KEY (IdUsuario)
        REFERENCES Usuarios (IdUsuario),
    CONSTRAINT FK_Prestamos_Libros FOREIGN KEY (IdLibro)
        REFERENCES Libros (IdLibro),
    CONSTRAINT CK_Prestamos_Estado CHECK (Estado IN ('Prestado', 'Devuelto')),
    CONSTRAINT CK_Prestamos_FechaPrevista CHECK (FechaDevolucionPrevista >= FechaPrestamo),
    CONSTRAINT CK_Prestamos_FechaDevolucion CHECK (FechaDevolucion IS NULL OR FechaDevolucion >= FechaPrestamo),
    CONSTRAINT CK_Prestamos_Coherencia CHECK (
        (Estado = 'Prestado' AND FechaDevolucion IS NULL) OR
        (Estado = 'Devuelto' AND FechaDevolucion IS NOT NULL)
    )
);
GO

/*
   DATOS DE PRUEBA
*/

INSERT INTO Autores (Nombre, Apellido, Nacionalidad, FechaNacimiento) VALUES
('Gabriel',   'García Márquez',    'Colombiana',     '1927-03-06'),
('Isabel',    'Allende',           'Chilena',        '1942-08-02'),
('Mario',     'Vargas Llosa',      'Peruana',        '1936-03-28'),
('Jorge Luis','Borges',            'Argentina',      '1899-08-24'),
('Laura',     'Restrepo',          'Colombiana',     NULL),
('Héctor',    'Abad Faciolince',   'Colombiana',     NULL),
('Robert C.', 'Martin',            'Estadounidense', NULL);
GO

INSERT INTO Editoriales (Nombre, Pais) VALUES
('Penguin Random House', 'España'),
('Planeta',              'España'),
('Alfaguara',            'España'),
('Anaya Multimedia',     'España'),
('Norma',                'Colombia');
GO

-- Al principio Disponibles = Existencias, más abajo se ajusta según los préstamos activos
INSERT INTO Libros (ISBN, Titulo, IdAutor, IdEditorial, AnioPublicacion, Genero, Existencias, Disponibles) VALUES
('978-0000000001', 'Cien años de soledad',              1, 1, 1967, 'Novela',       5, 5),
('978-0000000002', 'El amor en los tiempos del cólera', 1, 1, 1985, 'Novela',       3, 3),
('978-0000000003', 'Crónica de una muerte anunciada',   1, 1, 1981, 'Novela',       4, 4),
('978-0000000004', 'La casa de los espíritus',          2, 2, 1982, 'Novela',       2, 2),
('978-0000000005', 'La ciudad y los perros',            3, 3, 1963, 'Novela',       2, 2),
('978-0000000006', 'Ficciones',                         4, 1, 1944, 'Cuentos',      3, 3),
('978-0000000007', 'Delirio',                           5, 3, 2004, 'Novela',       2, 2),
('978-0000000008', 'El olvido que seremos',             6, 2, 2006, 'Biografía',    3, 3),
('978-0000000009', 'Código limpio',                     7, 4, 2008, 'Programación', 2, 2),
('978-0000000010', 'Arquitectura limpia',               7, 4, 2017, 'Programación', 2, 2),
('978-0000000011', 'Eva Luna',                          2, 2, 1987, 'Novela',       2, 2),
('978-0000000012', 'El Aleph',                          4, 1, 1949, 'Cuentos',      2, 2);
GO

INSERT INTO Usuarios (Documento, Nombre, Apellido, Telefono, Correo, FechaRegistro) VALUES
('1012345678', 'Andrés',    'Rodríguez', '3001234567', 'andres.rodriguez@correo.com', '2026-08-01'),
('1023456789', 'Camila',    'Gómez',     '3012345678', 'camila.gomez@correo.com',     '2026-08-03'),
('1034567890', 'Santiago',  'Martínez',  '3023456789', 'santiago.martinez@correo.com','2026-08-10'),
('1045678901', 'Valentina', 'López',     '3034567890', 'valentina.lopez@correo.com',  '2026-08-15'),
('1056789012', 'Juan David','Hernández', '3045678901', 'juan.hernandez@correo.com',   '2026-08-20'),
('1067890123', 'Laura',     'Ramírez',   '3056789012', 'laura.ramirez@correo.com',    '2026-09-02'),
('1078901234', 'Felipe',    'Castro',    NULL,         'felipe.castro@correo.com',    '2026-09-05'),
('1089012345', 'Daniela',   'Torres',    '3078901234', NULL,                          '2026-09-12');
GO

INSERT INTO Prestamos (IdUsuario, IdLibro, FechaPrestamo, FechaDevolucionPrevista, FechaDevolucion, Estado) VALUES
(1, 1,  '2026-09-01', '2026-09-15', '2026-09-14', 'Devuelto'),
(2, 9,  '2026-09-05', '2026-09-19', '2026-09-20', 'Devuelto'),
(3, 2,  '2026-09-20', '2026-10-04', '2026-10-03', 'Devuelto'),
(2, 12, '2026-09-25', '2026-10-09', '2026-10-12', 'Devuelto'),
(4, 1,  '2026-10-10', '2026-10-24', NULL,         'Prestado'),
(5, 5,  '2026-10-15', '2026-10-29', NULL,         'Prestado'),
(1, 9,  '2026-10-20', '2026-11-03', NULL,         'Prestado'),
(6, 7,  '2026-10-22', '2026-11-05', NULL,         'Prestado');
GO

-- Se descuentan de Disponibles los libros que siguen prestados
UPDATE L
SET L.Disponibles = L.Existencias - ISNULL(P.Cantidad, 0)
FROM Libros L
LEFT JOIN (
    SELECT IdLibro, COUNT(*) AS Cantidad
    FROM Prestamos
    WHERE Estado = 'Prestado'
    GROUP BY IdLibro
) P ON P.IdLibro = L.IdLibro;
GO

-- Consultas rápidas para revisar que todo quedó bien
SELECT * FROM Autores;
SELECT * FROM Editoriales;
SELECT * FROM Libros;
SELECT * FROM Usuarios;
SELECT * FROM Prestamos;
GO
