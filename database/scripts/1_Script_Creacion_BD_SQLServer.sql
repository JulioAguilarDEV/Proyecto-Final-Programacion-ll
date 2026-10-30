-- Crear la base de datos
CREATE DATABASE OpticaGrupo8;
GO

USE OpticaGrupo8;
GO


-- Tabla Sucursal
CREATE TABLE dbo.Sucursal (
    CodigoSucursal INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Direccion VARCHAR(200) NOT NULL,
    Municipio VARCHAR(80) NOT NULL,
    Departamento VARCHAR(80) NOT NULL,
    Telefono VARCHAR(15) NOT NULL,
    HorarioAtencion VARCHAR(100) NOT NULL,
    Estado VARCHAR(20) NOT NULL
);


-- Tabla Usuario
CREATE TABLE dbo.Usuario (
    CodigoUsuario INT IDENTITY(1,1) PRIMARY KEY,
    CodigoSucursal INT NOT NULL,
    NombreCompleto VARCHAR(150) NOT NULL,
    NombreUsuario VARCHAR(50) NOT NULL UNIQUE,
    Contrasena VARCHAR(100) NOT NULL,
    Rol VARCHAR(30) NOT NULL,
    Estado VARCHAR(20) NOT NULL,
    FOREIGN KEY (CodigoSucursal) REFERENCES dbo.Sucursal (CodigoSucursal)
);

-- Catálogo de roles y accesos configurables para el menú
CREATE TABLE dbo.Rol (
    CodigoRol INT IDENTITY(1,1) PRIMARY KEY,
    NombreRol VARCHAR(30) NOT NULL UNIQUE,
    Descripcion VARCHAR(150) NOT NULL,
    Estado VARCHAR(20) NOT NULL
);

CREATE TABLE dbo.RolAcceso (
    CodigoRol INT NOT NULL,
    CodigoAcceso VARCHAR(30) NOT NULL,
    CONSTRAINT PK_RolAcceso PRIMARY KEY (CodigoRol, CodigoAcceso),
    CONSTRAINT FK_RolAcceso_Rol FOREIGN KEY (CodigoRol)
        REFERENCES dbo.Rol (CodigoRol) ON DELETE CASCADE
);


-- Tabla Cliente
CREATE TABLE dbo.Cliente (
    CodigoCliente INT IDENTITY(1,1) PRIMARY KEY,
    Nombres VARCHAR(100) NOT NULL,
    Apellidos VARCHAR(100) NOT NULL,
    DPI VARCHAR(13) NOT NULL UNIQUE,
    FechaNacimiento DATE NOT NULL,
    Telefono VARCHAR(15) NOT NULL,
    Correo VARCHAR(100),
    Direccion VARCHAR(200),
    Estado VARCHAR(20) NOT NULL
);


-- Tabla Optometrista
CREATE TABLE dbo.Optometrista (
    CodigoOptometrista INT IDENTITY(1,1) PRIMARY KEY,
    Nombres VARCHAR(100) NOT NULL,
    Apellidos VARCHAR(100) NOT NULL,
    NumeroColegiado VARCHAR(20) NOT NULL UNIQUE,
    Telefono VARCHAR(15) NOT NULL,
    Correo VARCHAR(100) NOT NULL,
    Estado VARCHAR(20) NOT NULL
);


-- Tabla Cita
CREATE TABLE dbo.Cita (
    CodigoCita INT IDENTITY(1,1) PRIMARY KEY,
    CodigoCliente INT NOT NULL,
    CodigoSucursal INT NOT NULL,
    CodigoOptometrista INT NOT NULL,
    Fecha DATE NOT NULL,
    Hora TIME NOT NULL,
    MotivoConsulta VARCHAR(200) NOT NULL,
    Estado VARCHAR(20) NOT NULL,
    FOREIGN KEY (CodigoCliente) REFERENCES dbo.Cliente (CodigoCliente),
    FOREIGN KEY (CodigoSucursal) REFERENCES dbo.Sucursal (CodigoSucursal),
    FOREIGN KEY (CodigoOptometrista) REFERENCES dbo.Optometrista (CodigoOptometrista)
);


-- Tabla ExamenVisual
CREATE TABLE dbo.ExamenVisual (
    CodigoExamen INT IDENTITY(1,1) PRIMARY KEY,
    CodigoCliente INT NOT NULL,
    CodigoOptometrista INT NOT NULL,
    CodigoCita INT,
    Fecha DATE NOT NULL,
    Observaciones VARCHAR(300),
    ResultadoGeneral VARCHAR(200) NOT NULL,
    Estado VARCHAR(20) NOT NULL,
    FOREIGN KEY (CodigoCliente) REFERENCES dbo.Cliente (CodigoCliente),
    FOREIGN KEY (CodigoOptometrista) REFERENCES dbo.Optometrista (CodigoOptometrista),
    FOREIGN KEY (CodigoCita) REFERENCES dbo.Cita (CodigoCita)
);


-- Tabla Receta
CREATE TABLE dbo.Receta (  -- OD = ojo derecho, OI = ojo izquierdo
    CodigoReceta INT IDENTITY(1,1) PRIMARY KEY,
    CodigoExamen INT NOT NULL,
    EsferaOD NUMERIC(5,2) NOT NULL,
    CilindroOD NUMERIC(5,2) NOT NULL,
    EjeOD INT NOT NULL,
    EsferaOI NUMERIC(5,2) NOT NULL,
    CilindroOI NUMERIC(5,2) NOT NULL,
    EjeOI INT NOT NULL,
    Adicion NUMERIC(4,2) NOT NULL,
    DistanciaPupilar NUMERIC(4,1) NOT NULL,
    FechaEmision DATE NOT NULL,
    Observaciones VARCHAR(300),
    Estado VARCHAR(20) NOT NULL,
    FOREIGN KEY (CodigoExamen) REFERENCES dbo.ExamenVisual (CodigoExamen)
);


-- Tabla TipoProducto
CREATE TABLE dbo.TipoProducto (
    CodigoTipoProducto INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(80) NOT NULL,
    Descripcion VARCHAR(200) NOT NULL,
    Estado VARCHAR(20) NOT NULL
);


-- Tabla ProductoOptico
CREATE TABLE dbo.ProductoOptico (
    CodigoProducto INT IDENTITY(1,1) PRIMARY KEY,
    CodigoTipoProducto INT NOT NULL,
    Nombre VARCHAR(100) NOT NULL,
    Descripcion VARCHAR(200) NOT NULL,
    Marca VARCHAR(60) NOT NULL,
    Precio NUMERIC(10,2) NOT NULL,
    Estado VARCHAR(20) NOT NULL,
    FOREIGN KEY (CodigoTipoProducto) REFERENCES dbo.TipoProducto (CodigoTipoProducto)
);


-- Tabla Orden
CREATE TABLE dbo.Orden (
    CodigoOrden INT IDENTITY(1,1) PRIMARY KEY,
    CodigoCliente INT NOT NULL,
    CodigoSucursal INT NOT NULL,
    Fecha DATE NOT NULL,
    Estado VARCHAR(20) NOT NULL,
    FOREIGN KEY (CodigoCliente) REFERENCES dbo.Cliente (CodigoCliente),
    FOREIGN KEY (CodigoSucursal) REFERENCES dbo.Sucursal (CodigoSucursal)
);


-- Tabla DetalleOrden
CREATE TABLE dbo.DetalleOrden (
    CodigoDetalle INT IDENTITY(1,1) PRIMARY KEY,
    CodigoOrden INT NOT NULL,
    CodigoProducto INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario NUMERIC(10,2) NOT NULL,
    Subtotal NUMERIC(10,2) NOT NULL,
    FOREIGN KEY (CodigoOrden) REFERENCES dbo.Orden (CodigoOrden),
    FOREIGN KEY (CodigoProducto) REFERENCES dbo.ProductoOptico (CodigoProducto)
);


-- Tabla Entrega
CREATE TABLE dbo.Entrega (
    CodigoEntrega INT IDENTITY(1,1) PRIMARY KEY,
    CodigoOrden INT NOT NULL,
    FechaEntrega DATE NOT NULL,
    NombreRecibe VARCHAR(150) NOT NULL,
    Observaciones VARCHAR(300),
    Estado VARCHAR(20) NOT NULL,
    FOREIGN KEY (CodigoOrden) REFERENCES dbo.Orden (CodigoOrden)
);
