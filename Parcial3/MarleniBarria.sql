-- Usar BD
CREATE DATABASE MarleniBarria;
GO
USE MarleniBarria;
GO

-- Tabla de usuarios (login y roles)
CREATE TABLE MB_Usuarios (
  UsuarioId INT IDENTITY(1,1) PRIMARY KEY,
  Usuario NVARCHAR(50) NOT NULL UNIQUE,
  Nombre NVARCHAR(100) NOT NULL,
  Email NVARCHAR(200),
  PasswordHash NVARCHAR(256) NOT NULL,
  Rol NVARCHAR(50) NOT NULL, -- EJEM. Admin, Abogado, Asistente
  Activo BIT NOT NULL DEFAULT 1,
  FechaCreacion DATETIME NOT NULL DEFAULT GETDATE()
);

-- Tabla de clientes
CREATE TABLE MB_Clientes (
  ClienteId INT IDENTITY(1,1) PRIMARY KEY,
  Nombre NVARCHAR(200) NOT NULL,
  Telefono NVARCHAR(50),
  Email NVARCHAR(200),
  Direccion NVARCHAR(300),
  Observaciones NVARCHAR(MAX)
);

-- Tabla de abogados 
CREATE TABLE MB_Abogados (
  AbogadoId INT IDENTITY(1,1) PRIMARY KEY,
  UsuarioId INT NULL, -- FK opcional hacia MB_Usuarios
  Nombre NVARCHAR(200) NOT NULL,
  Especialidad NVARCHAR(200),
  Telefono NVARCHAR(50),
  Email NVARCHAR(200),
  CONSTRAINT FK_Abogado_Usuario FOREIGN KEY (UsuarioId) REFERENCES MB_Usuarios(UsuarioId)
);

-- Tabla de casos
CREATE TABLE MB_Casos (
  CasoId INT IDENTITY(1,1) PRIMARY KEY,
  CodigoCaso NVARCHAR(50) NOT NULL UNIQUE, -- EJEM. C-2025-0001
  Titulo NVARCHAR(300) NOT NULL,
  Descripcion NVARCHAR(MAX),
  FechaInicio DATE NOT NULL,
  FechaVencimiento DATE NULL,
  Estado NVARCHAR(50) NOT NULL, -- Abierto, En Proceso, Cerrado, Archivado
  ClienteId INT NOT NULL,
  FechaUltimaActualizacion DATETIME NOT NULL DEFAULT GETDATE(),
  CONSTRAINT FK_Caso_Cliente FOREIGN KEY (ClienteId) REFERENCES MB_Clientes(ClienteId)
);

-- Tabla de asignaciones (un caso puede tener varios abogados)
CREATE TABLE MB_CasoAsignaciones (
  AsignacionId INT IDENTITY(1,1) PRIMARY KEY,
  CasoId INT NOT NULL,
  AbogadoId INT NOT NULL,
  FechaAsignacion DATETIME NOT NULL DEFAULT GETDATE(),
  RolEnCaso NVARCHAR(100), -- Principal, Co-autor, etc.
  CONSTRAINT FK_Asign_Caso FOREIGN KEY (CasoId) REFERENCES MB_Casos(CasoId),
  CONSTRAINT FK_Asign_Abogado FOREIGN KEY (AbogadoId) REFERENCES MB_Abogados(AbogadoId)
);

-- Tabla de documentos (metadata)
CREATE TABLE MB_Documentos (
  DocumentoId INT IDENTITY(1,1) PRIMARY KEY,
  CasoId INT NOT NULL,
  NombreOriginal NVARCHAR(300),
  RutaArchivo NVARCHAR(500), -- ruta relativa en servidor
  TipoDocumento NVARCHAR(100),
  FechaSubida DATETIME NOT NULL DEFAULT GETDATE(),
  SubidoPor INT NULL, -- UsuarioId
  Observaciones NVARCHAR(MAX),
  CONSTRAINT FK_Doc_Caso FOREIGN KEY (CasoId) REFERENCES MB_Casos(CasoId),
  CONSTRAINT FK_Doc_Usuario FOREIGN KEY (SubidoPor) REFERENCES MB_Usuarios(UsuarioId)
);

-- Tabla de eventos (audiencias, reuniones, recordatorios)
CREATE TABLE MB_Eventos (
  EventoId INT IDENTITY(1,1) PRIMARY KEY,
  CasoId INT NULL,
  Titulo NVARCHAR(200) NOT NULL,
  Descripcion NVARCHAR(MAX),
  FechaInicio DATETIME NOT NULL,
  FechaFin DATETIME NULL,
  TipoEvento NVARCHAR(100), -- Audiencia, Reunion, Vencimiento
  RecordatorioMinutos INT NULL, -- minutos antes para recordatorio
  CreadoPor INT NULL,
  CONSTRAINT FK_Evento_Caso FOREIGN KEY (CasoId) REFERENCES MB_Casos(CasoId),
  CONSTRAINT FK_Evento_Usuario FOREIGN KEY (CreadoPor) REFERENCES MB_Usuarios(UsuarioId)
);

-- Tabla de notas / bitácora
CREATE TABLE MB_Notas (
  NotaId INT IDENTITY(1,1) PRIMARY KEY,
  CasoId INT NOT NULL,
  UsuarioId INT NULL,
  Contenido NVARCHAR(MAX) NOT NULL,
  FechaCreacion DATETIME NOT NULL DEFAULT GETDATE(),
  CONSTRAINT FK_Nota_Caso FOREIGN KEY (CasoId) REFERENCES MB_Casos(CasoId),
  CONSTRAINT FK_Nota_Usuario FOREIGN KEY (UsuarioId) REFERENCES MB_Usuarios(UsuarioId)
);

-- Tabla de auditoría ligera
CREATE TABLE MB_Auditoria (
  AuditId INT IDENTITY(1,1) PRIMARY KEY,
  Tabla NVARCHAR(100),
  RegistroId INT,
  UsuarioId INT NULL,
  Accion NVARCHAR(50), -- Insert, Update, Delete
  Fecha DATETIME NOT NULL DEFAULT GETDATE(),
  Detalle NVARCHAR(MAX)
);

Select * from MB_Clientes;


Select * from MB_Abogados;

-- Tabla de preguntas
CREATE TABLE MB_Preguntas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Pregunta NVARCHAR(500) NOT NULL,
    Respuesta NVARCHAR(MAX) NOT NULL,
    Fecha DATETIME DEFAULT GETDATE()
);

INSERT INTO MB_Preguntas (Pregunta, Respuesta) VALUES
('¿Cómo resolverías estos problemas con una solución tecnológica?',
 'Para mejorar la gestión del bufete, una solución tecnológica ideal es un sistema web que centralice toda la información de los casos legales en una plataforma accesible y ordenada, permitiendo registrar y consultar clientes, abogados, documentos y plazos importantes.'),
('¿Qué pasos seguirías para desarrollar un sistema que permita al bufete gestionar de forma eficiente todos los aspectos de sus casos legales?',
 'Los pasos son: análisis de requerimientos, diseño del sistema, diseño de la base de datos, desarrollo de la aplicación web, pruebas, implementación y mantenimiento.'),
('¿Qué estructura tendría la base de datos?',
 'La base de datos tendría tablas relacionadas: Clientes, Abogados, Casos y Asignaciones, lo que permitiría almacenar y consultar toda la información sin duplicación.'),
('¿Por qué elegiste la estructura de base de datos que diseñaste? ¿Qué ventajas y desventajas tiene tu diseño?',
 'Se eligió un modelo relacional por su organización y eficiencia. Ventajas: evita duplicación, búsquedas rápidas, fácil mantenimiento. Desventajas: planificación inicial mayor y dependencia de claves foráneas.'),
('¿Qué interfaz gráfica utilizarías?',
 'Se utilizaría una interfaz web con ASP.NET Web Forms porque es fácil de usar, permite controles visuales, se conecta a SQL Server y puede accederse desde cualquier PC del bufete.');

 Select * from MB_Preguntas;