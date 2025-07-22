-- BaseDatos.sql

CREATE DATABASE BancoDB;
GO
USE BancoDB;
GO

-- Tabla Persona
CREATE TABLE Personas (
    IdPersona INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100),
    Genero NVARCHAR(10),
    Edad INT,
    Identificacion NVARCHAR(20),
    Direccion NVARCHAR(200),
    Telefono NVARCHAR(20)
);

-- Tabla Cliente (hereda de Persona)
CREATE TABLE Clientes (
    ClienteId INT PRIMARY KEY,
    Estado BIT,
    Password NVARCHAR(100),
    FOREIGN KEY (ClienteId) REFERENCES Personas(IdPersona)
);

-- Tabla Cuenta
CREATE TABLE Cuentas (
    NumeroCuenta INT PRIMARY KEY IDENTITY(100000,1),
    TipoCuenta NVARCHAR(20),
    SaldoInicial DECIMAL(18,2),
    Estado BIT,
    ClienteId INT,
    FOREIGN KEY (ClienteId) REFERENCES Clientes(ClienteId)
);

-- Tabla Movimiento
CREATE TABLE Movimientos (
    MovimientoId INT PRIMARY KEY IDENTITY(1,1),
    Fecha DATETIME,
    TipoMovimiento NVARCHAR(20),
    Valor DECIMAL(18,2),
    Saldo DECIMAL(18,2),
    NumeroCuenta INT,
    FOREIGN KEY (NumeroCuenta) REFERENCES Cuentas(NumeroCuenta)
);
