
-- ==========================================
-- ELIMINAR BASE SI EXISTE
-- ==========================================
USE master;
GO
DROP DATABASE IF EXISTS BibliotecaDB;
GO

-- ==========================================
-- CREAR BASE DE DATOS
-- ==========================================
CREATE DATABASE BibliotecaDB;
GO

USE BibliotecaDB;
GO

-- ==========================================
-- TABLAS
-- ==========================================

-- -------- USUARIOS --------
CREATE TABLE Usuarios (
    UsuarioId INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Correo NVARCHAR(150) NOT NULL UNIQUE,
    TipoUsuario NVARCHAR(50) NOT NULL, -- Cliente / Administrativo
    FechaRegistro DATETIME DEFAULT GETDATE()
);

-- -------- LIBROS --------
CREATE TABLE Libros (
    LibroId INT IDENTITY(1,1) PRIMARY KEY,
    Titulo NVARCHAR(200) NOT NULL,
    Autor NVARCHAR(150) NOT NULL,
    Categoria NVARCHAR(100),
    Disponible BIT DEFAULT 1,
    Cantidad INT DEFAULT 1,
    FechaRegistro DATETIME DEFAULT GETDATE()
);

-- -------- PRESTAMOS --------
CREATE TABLE Prestamos (
    PrestamoId INT IDENTITY(1,1) PRIMARY KEY,
    UsuarioId INT NOT NULL,
    LibroId INT NOT NULL,
    FechaPrestamo DATE NOT NULL,
    FechaVencimiento DATE NOT NULL,
    FechaDevolucion DATE NULL,
    Estado NVARCHAR(50) NOT NULL, -- Activo / Devuelto
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(UsuarioId),
    FOREIGN KEY (LibroId) REFERENCES Libros(LibroId)
);

-- -------- RESEÑAS --------
CREATE TABLE Resenas (
    ResenaId INT IDENTITY(1,1) PRIMARY KEY,
    LibroId INT NOT NULL,
    Comentario NVARCHAR(500),
    Calificacion INT CHECK (Calificacion BETWEEN 1 AND 5),
    Fecha DATETIME DEFAULT GETDATE(),
    UsuarioId INT NOT NULL,
    FOREIGN KEY (LibroId) REFERENCES Libros(LibroId),
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(UsuarioId)
);

-- ==========================================
-- DATOS DE PRUEBA
-- ==========================================
INSERT INTO Usuarios (Nombre, Correo, TipoUsuario)
VALUES 
('Ana Gómez', 'ana@correo.com', 'Cliente'),
('Carlos Pérez', 'carlos@correo.com', 'Administrativo'),
('Marleni Barría', 'marlenibarria82@gmail.com', 'Administrativo');

INSERT INTO Libros (Titulo, Autor, Categoria, Disponible, Cantidad)
VALUES
('Cien años de soledad', 'Gabriel García Márquez', 'Novela', 1, 5),
('El principito', 'Antoine de Saint-Exupéry', 'Fábula', 1, 3),
('Don Quijote de la Mancha', 'Miguel de Cervantes', 'Clásico', 1, 4),
('1984', 'George Orwell', 'Distopía', 1, 2),
('La sombra del viento', 'Carlos Ruiz Zafón', 'Novela', 1, 6);

GO
-- ==========================================
-- PROCEDIMIENTOS ALMACENADOS
-- ==========================================

-- *********** LIBROS ***********
CREATE PROCEDURE sp_ListarLibros AS
BEGIN
    SELECT * FROM Libros;
END;
GO

CREATE PROCEDURE sp_LibrosDisponibles AS
BEGIN
    SELECT * FROM Libros WHERE Disponible = 1;
END;
GO

CREATE PROCEDURE sp_InsertarLibro
    @Titulo NVARCHAR(200),
    @Autor NVARCHAR(150),
    @Categoria NVARCHAR(100),
    @Cantidad INT
AS
BEGIN
    INSERT INTO Libros (Titulo, Autor, Categoria, Cantidad)
    VALUES (@Titulo, @Autor, @Categoria, @Cantidad);
END;
GO

CREATE PROCEDURE sp_ActualizarLibro
    @LibroId INT,
    @Titulo NVARCHAR(200),
    @Autor NVARCHAR(100),
    @Categoria NVARCHAR(100),
    @Cantidad INT
AS
BEGIN
    UPDATE Libros
    SET Titulo = @Titulo,
        Autor = @Autor,
        Categoria = @Categoria,
        Cantidad = @Cantidad,
        Disponible = CASE WHEN @Cantidad > 0 THEN 1 ELSE 0 END
    WHERE LibroId = @LibroId;
END
GO


CREATE PROCEDURE sp_EliminarLibro
    @LibroId INT
AS
BEGIN
    DELETE FROM Libros WHERE LibroId=@LibroId;
END;
GO

CREATE PROCEDURE sp_ObtenerLibroPorId
    @LibroId INT
AS
BEGIN
    SELECT * FROM Libros WHERE LibroId=@LibroId;
END;
GO

-- *********** USUARIOS ***********
CREATE PROCEDURE sp_ListarUsuarios AS
BEGIN
    SELECT * FROM Usuarios;
END;
GO

CREATE PROCEDURE sp_InsertarUsuario
    @Nombre NVARCHAR(100),
    @Correo NVARCHAR(100),
    @TipoUsuario NVARCHAR(50)
AS
BEGIN
    INSERT INTO Usuarios (Nombre, Correo, TipoUsuario)
    VALUES (@Nombre, @Correo, @TipoUsuario);
END;
GO

CREATE PROCEDURE sp_ActualizarUsuario
    @UsuarioId INT,
    @Nombre NVARCHAR(100),
    @Correo NVARCHAR(100),
    @TipoUsuario NVARCHAR(50)
AS
BEGIN
    UPDATE Usuarios
    SET Nombre=@Nombre, Correo=@Correo, TipoUsuario=@TipoUsuario
    WHERE UsuarioId=@UsuarioId;
END;
GO

CREATE PROCEDURE sp_EliminarUsuario
    @UsuarioId INT
AS
BEGIN
    DELETE FROM Usuarios WHERE UsuarioId=@UsuarioId;
END;
GO

CREATE PROCEDURE sp_ObtenerUsuarioPorId
    @UsuarioId INT
AS
BEGIN
    SELECT * FROM Usuarios WHERE UsuarioId=@UsuarioId;
END;
GO

CREATE PROCEDURE sp_ObtenerUsuarioPorCorreo
    @Correo NVARCHAR(150)
AS
BEGIN
    SELECT * FROM Usuarios WHERE Correo=@Correo;
END;
GO

-- *********** PRESTAMOS ***********
CREATE PROCEDURE sp_RegistrarPrestamo
    @UsuarioId INT,
    @LibroId INT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @CantidadActual INT;

    SELECT @CantidadActual = Cantidad FROM Libros WHERE LibroId=@LibroId;

    IF @CantidadActual IS NULL OR @CantidadActual <= 0
    BEGIN
        RAISERROR('No hay ejemplares disponibles para este libro.',16,1);
        RETURN;
    END

    INSERT INTO Prestamos (UsuarioId, LibroId, FechaPrestamo, FechaVencimiento, Estado)
    VALUES (@UsuarioId,@LibroId,GETDATE(),DATEADD(DAY,7,GETDATE()),'Activo');

    UPDATE Libros
    SET Cantidad=Cantidad-1,
        Disponible=CASE WHEN Cantidad-1=0 THEN 0 ELSE 1 END
    WHERE LibroId=@LibroId;
END;
GO

CREATE PROCEDURE sp_DevolverLibro
    @PrestamoId INT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @LibroId INT;

    SELECT @LibroId = LibroId FROM Prestamos WHERE PrestamoId=@PrestamoId AND Estado='Activo';

    IF @LibroId IS NULL
    BEGIN
        RAISERROR('El préstamo no existe o ya fue devuelto.',16,1);
        RETURN;
    END

    UPDATE Prestamos
    SET FechaDevolucion=GETDATE(), Estado='Devuelto'
    WHERE PrestamoId=@PrestamoId;

    UPDATE Libros
    SET Cantidad=Cantidad+1, Disponible=1
    WHERE LibroId=@LibroId;
END;
GO

CREATE PROCEDURE sp_ListarPrestamos AS
BEGIN
    SELECT 
        p.PrestamoId, p.UsuarioId, p.LibroId, 
        u.Nombre AS Usuario, l.Titulo AS Libro,
        p.FechaPrestamo, p.FechaVencimiento, p.FechaDevolucion, p.Estado
    FROM Prestamos p
    INNER JOIN Usuarios u ON p.UsuarioId=u.UsuarioId
    INNER JOIN Libros l ON p.LibroId=l.LibroId;
END;
GO

CREATE PROCEDURE sp_PrestamosActivos AS
BEGIN
    SELECT 
        p.PrestamoId, u.Nombre AS Usuario, l.Titulo AS Libro,
        p.FechaPrestamo, p.FechaVencimiento
    FROM Prestamos p
    INNER JOIN Usuarios u ON p.UsuarioId=u.UsuarioId
    INNER JOIN Libros l ON p.LibroId=l.LibroId
    WHERE p.Estado='Activo';
END;
GO

CREATE PROCEDURE sp_ObtenerPrestamoPorId
    @PrestamoId INT
AS
BEGIN
    SELECT 
        p.PrestamoId, p.UsuarioId, p.LibroId, u.Nombre AS Usuario, l.Titulo AS Libro,
        p.FechaPrestamo, p.FechaVencimiento, p.FechaDevolucion, p.Estado
    FROM Prestamos p
    INNER JOIN Usuarios u ON p.UsuarioId=u.UsuarioId
    INNER JOIN Libros l ON p.LibroId=l.LibroId
    WHERE p.PrestamoId=@PrestamoId;
END;
GO

CREATE PROCEDURE sp_EliminarPrestamo
    @PrestamoId INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Prestamos WHERE PrestamoId=@PrestamoId AND Estado='Devuelto')
    BEGIN
        DELETE FROM Prestamos WHERE PrestamoId=@PrestamoId;
    END
END;
GO

-- *********** RESEÑAS ***********
CREATE PROCEDURE sp_ListarResenas
AS
BEGIN
    SELECT 
        r.ResenaId,
        r.LibroId,
        l.Titulo AS Libro,
        r.Comentario,
        r.Calificacion,
        r.Fecha,
        r.UsuarioId,
        u.Nombre AS Usuario
    FROM Resenas r
    INNER JOIN Libros l ON r.LibroId = l.LibroId
    INNER JOIN Usuarios u ON r.UsuarioId = u.UsuarioId;
END;
GO



CREATE PROCEDURE sp_ObtenerResenaPorId
    @ResenaId INT
AS
BEGIN
    SELECT 
        r.ResenaId,
        r.LibroId,
        l.Titulo AS Libro,
        r.Comentario,
        r.Calificacion,
        r.Fecha,
        r.UsuarioId,
        u.Nombre AS Usuario
    FROM Resenas r
    INNER JOIN Libros l ON r.LibroId = l.LibroId
    INNER JOIN Usuarios u ON r.UsuarioId = u.UsuarioId
    WHERE r.ResenaId = @ResenaId;
END;
GO

CREATE PROCEDURE sp_InsertarResena
    @LibroId INT,
    @Comentario NVARCHAR(500),
    @Calificacion INT,
    @UsuarioId INT
AS
BEGIN
    INSERT INTO Resenas (LibroId, Comentario, Calificacion, UsuarioId)
    VALUES (@LibroId,@Comentario,@Calificacion,@UsuarioId);
END;
GO

CREATE PROCEDURE sp_ActualizarResena
    @ResenaId INT,
    @Comentario NVARCHAR(500),
    @Calificacion INT
AS
BEGIN
    UPDATE Resenas
    SET Comentario=@Comentario, Calificacion=@Calificacion, Fecha=GETDATE()
    WHERE ResenaId=@ResenaId;
END;
GO

CREATE PROCEDURE sp_EliminarResena
    @ResenaId INT
AS
BEGIN
    DELETE FROM Resenas WHERE ResenaId=@ResenaId;
END;
GO


















