-- Script de creación para PostgreSQL / Supabase (misma estructura que 1_Script_Creacion_BD_SQLServer.sql)
-- Ejecutar en el SQL Editor de Supabase. Las tablas se crean en el esquema public.
-- Los nombres de las tablas van en minúscula porque así los guarda PostgreSQL (Sucursal -> sucursal).


-- Tabla Sucursal
CREATE TABLE public.sucursal (
    CodigoSucursal SERIAL PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Direccion VARCHAR(200) NOT NULL,
    Municipio VARCHAR(80) NOT NULL,
    Departamento VARCHAR(80) NOT NULL,
    Telefono VARCHAR(15) NOT NULL,
    HorarioAtencion VARCHAR(100) NOT NULL,
    Estado VARCHAR(20) NOT NULL
);


-- Tabla Usuario
CREATE TABLE public.usuario (
    CodigoUsuario SERIAL PRIMARY KEY,
    CodigoSucursal INT NOT NULL,
    NombreCompleto VARCHAR(150) NOT NULL,
    NombreUsuario VARCHAR(50) NOT NULL UNIQUE,
    Contrasena VARCHAR(100) NOT NULL,
    Rol VARCHAR(30) NOT NULL,
    Estado VARCHAR(20) NOT NULL,
    FOREIGN KEY (CodigoSucursal) REFERENCES public.sucursal (CodigoSucursal)
);

-- Catálogo de roles y accesos configurables para el menú
CREATE TABLE public.rol (
    CodigoRol SERIAL PRIMARY KEY,
    NombreRol VARCHAR(30) NOT NULL UNIQUE,
    Descripcion VARCHAR(150) NOT NULL,
    Estado VARCHAR(20) NOT NULL
);

CREATE TABLE public.rolacceso (
    CodigoRol INT NOT NULL,
    CodigoAcceso VARCHAR(30) NOT NULL,
    PRIMARY KEY (CodigoRol, CodigoAcceso),
    FOREIGN KEY (CodigoRol) REFERENCES public.rol (CodigoRol) ON DELETE CASCADE
);


-- Tabla Cliente
CREATE TABLE public.cliente (
    CodigoCliente SERIAL PRIMARY KEY,
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
CREATE TABLE public.optometrista (
    CodigoOptometrista SERIAL PRIMARY KEY,
    Nombres VARCHAR(100) NOT NULL,
    Apellidos VARCHAR(100) NOT NULL,
    NumeroColegiado VARCHAR(20) NOT NULL UNIQUE,
    Telefono VARCHAR(15) NOT NULL,
    Correo VARCHAR(100) NOT NULL,
    Estado VARCHAR(20) NOT NULL
);


-- Tabla Cita
CREATE TABLE public.cita (
    CodigoCita SERIAL PRIMARY KEY,
    CodigoCliente INT NOT NULL,
    CodigoSucursal INT NOT NULL,
    CodigoOptometrista INT NOT NULL,
    Fecha DATE NOT NULL,
    Hora TIME NOT NULL,
    MotivoConsulta VARCHAR(200) NOT NULL,
    Estado VARCHAR(20) NOT NULL,
    FOREIGN KEY (CodigoCliente) REFERENCES public.cliente (CodigoCliente),
    FOREIGN KEY (CodigoSucursal) REFERENCES public.sucursal (CodigoSucursal),
    FOREIGN KEY (CodigoOptometrista) REFERENCES public.optometrista (CodigoOptometrista)
);


-- Tabla ExamenVisual
CREATE TABLE public.examenvisual (
    CodigoExamen SERIAL PRIMARY KEY,
    CodigoCliente INT NOT NULL,
    CodigoOptometrista INT NOT NULL,
    CodigoCita INT,
    Fecha DATE NOT NULL,
    Observaciones VARCHAR(300),
    ResultadoGeneral VARCHAR(200) NOT NULL,
    Estado VARCHAR(20) NOT NULL,
    FOREIGN KEY (CodigoCliente) REFERENCES public.cliente (CodigoCliente),
    FOREIGN KEY (CodigoOptometrista) REFERENCES public.optometrista (CodigoOptometrista),
    FOREIGN KEY (CodigoCita) REFERENCES public.cita (CodigoCita)
);


-- Tabla Receta
CREATE TABLE public.receta (  -- OD = ojo derecho, OI = ojo izquierdo
    CodigoReceta SERIAL PRIMARY KEY,
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
    FOREIGN KEY (CodigoExamen) REFERENCES public.examenvisual (CodigoExamen)
);


-- Tabla TipoProducto
CREATE TABLE public.tipoproducto (
    CodigoTipoProducto SERIAL PRIMARY KEY,
    Nombre VARCHAR(80) NOT NULL,
    Descripcion VARCHAR(200) NOT NULL,
    Estado VARCHAR(20) NOT NULL
);


-- Tabla ProductoOptico
CREATE TABLE public.productooptico (
    CodigoProducto SERIAL PRIMARY KEY,
    CodigoTipoProducto INT NOT NULL,
    Nombre VARCHAR(100) NOT NULL,
    Descripcion VARCHAR(200) NOT NULL,
    Marca VARCHAR(60) NOT NULL,
    Precio NUMERIC(10,2) NOT NULL,
    Estado VARCHAR(20) NOT NULL,
    FOREIGN KEY (CodigoTipoProducto) REFERENCES public.tipoproducto (CodigoTipoProducto)
);


-- Tabla Orden
CREATE TABLE public.orden (
    CodigoOrden SERIAL PRIMARY KEY,
    CodigoCliente INT NOT NULL,
    CodigoSucursal INT NOT NULL,
    Fecha DATE NOT NULL,
    Estado VARCHAR(20) NOT NULL,
    FOREIGN KEY (CodigoCliente) REFERENCES public.cliente (CodigoCliente),
    FOREIGN KEY (CodigoSucursal) REFERENCES public.sucursal (CodigoSucursal)
);


-- Tabla DetalleOrden
CREATE TABLE public.detalleorden (
    CodigoDetalle SERIAL PRIMARY KEY,
    CodigoOrden INT NOT NULL,
    CodigoProducto INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario NUMERIC(10,2) NOT NULL,
    Subtotal NUMERIC(10,2) NOT NULL,
    FOREIGN KEY (CodigoOrden) REFERENCES public.orden (CodigoOrden),
    FOREIGN KEY (CodigoProducto) REFERENCES public.productooptico (CodigoProducto)
);


-- Tabla Entrega
CREATE TABLE public.entrega (
    CodigoEntrega SERIAL PRIMARY KEY,
    CodigoOrden INT NOT NULL,
    FechaEntrega DATE NOT NULL,
    NombreRecibe VARCHAR(150) NOT NULL,
    Observaciones VARCHAR(300),
    Estado VARCHAR(20) NOT NULL,
    FOREIGN KEY (CodigoOrden) REFERENCES public.orden (CodigoOrden)
);
