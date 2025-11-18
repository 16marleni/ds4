-- Creación base de datos
CREATE DATABASE laboratoriomvc;
GO

USE laboratoriomvc;
GO


-- Creación tabla [user], se utiliza [] como delimitador, para indicarle al programa que es literal la palabra y no la palabra reservada.
CREATE TABLE [user] (
    id INT NOT NULL IDENTITY(1,1),
    email VARCHAR(50) NULL,
    password VARCHAR(100) NULL
);

ALTER TABLE [user]
ADD CONSTRAINT PK_user PRIMARY KEY (id);

select * from [user];