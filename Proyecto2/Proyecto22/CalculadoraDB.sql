-- Crear la base de datos 
CREATE DATABASE CalculadoraDB;
GO

-- Usar la base de datos
USE CalculadoraDB;
GO

-- Crear la tabla para guardar los resultados
CREATE TABLE ResultadosCalculadora (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Expresion NVARCHAR(255) NOT NULL,
    Resultado FLOAT NOT NULL,
    Fecha DATETIME DEFAULT GETDATE()
);

