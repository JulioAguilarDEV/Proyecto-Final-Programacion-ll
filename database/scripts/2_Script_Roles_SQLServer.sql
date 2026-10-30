USE OpticaGrupo8;
GO

IF OBJECT_ID('dbo.Rol', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Rol (
        CodigoRol INT IDENTITY(1,1) PRIMARY KEY,
        NombreRol VARCHAR(30) NOT NULL UNIQUE,
        Descripcion VARCHAR(150) NOT NULL,
        Estado VARCHAR(20) NOT NULL
    );
END;
GO

IF OBJECT_ID('dbo.RolAcceso', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.RolAcceso (
        CodigoRol INT NOT NULL,
        CodigoAcceso VARCHAR(30) NOT NULL,
        CONSTRAINT PK_RolAcceso PRIMARY KEY (CodigoRol, CodigoAcceso),
        CONSTRAINT FK_RolAcceso_Rol FOREIGN KEY (CodigoRol)
            REFERENCES dbo.Rol (CodigoRol) ON DELETE CASCADE
    );
END;
GO

INSERT INTO dbo.Rol (NombreRol, Descripcion, Estado)
SELECT r.NombreRol, r.Descripcion, 'Activo'
FROM (VALUES
    ('Administrador', 'Acceso completo a los módulos del sistema.'),
    ('Operador', 'Acceso a clientes, citas y operaciones de productos.'),
    ('Optometrista', 'Acceso a citas y módulos de atención visual.')
) r(NombreRol, Descripcion)
WHERE NOT EXISTS (
    SELECT 1 FROM dbo.Rol existente WHERE existente.NombreRol = r.NombreRol
);
GO

INSERT INTO dbo.RolAcceso (CodigoRol, CodigoAcceso)
SELECT r.CodigoRol, a.CodigoAcceso
FROM dbo.Rol r
CROSS JOIN (VALUES
    ('Inicio'), ('Sucursales'), ('Usuarios'), ('Clientes'), ('Citas'),
    ('Optometristas'), ('Examenes'), ('Recetas'), ('TiposProducto'),
    ('Productos'), ('Ordenes'), ('Entregas')
) a(CodigoAcceso)
WHERE r.NombreRol = 'Administrador'
AND NOT EXISTS (
    SELECT 1 FROM dbo.RolAcceso existente
    WHERE existente.CodigoRol = r.CodigoRol AND existente.CodigoAcceso = a.CodigoAcceso
);

INSERT INTO dbo.RolAcceso (CodigoRol, CodigoAcceso)
SELECT r.CodigoRol, a.CodigoAcceso
FROM dbo.Rol r
CROSS JOIN (VALUES
    ('Inicio'), ('Clientes'), ('Citas'), ('TiposProducto'), ('Productos'),
    ('Ordenes'), ('Entregas')
) a(CodigoAcceso)
WHERE r.NombreRol = 'Operador'
AND NOT EXISTS (
    SELECT 1 FROM dbo.RolAcceso existente
    WHERE existente.CodigoRol = r.CodigoRol AND existente.CodigoAcceso = a.CodigoAcceso
);

INSERT INTO dbo.RolAcceso (CodigoRol, CodigoAcceso)
SELECT r.CodigoRol, a.CodigoAcceso
FROM dbo.Rol r
CROSS JOIN (VALUES
    ('Inicio'), ('Citas'), ('Optometristas'), ('Examenes'), ('Recetas')
) a(CodigoAcceso)
WHERE r.NombreRol = 'Optometrista'
AND NOT EXISTS (
    SELECT 1 FROM dbo.RolAcceso existente
    WHERE existente.CodigoRol = r.CodigoRol AND existente.CodigoAcceso = a.CodigoAcceso
);
GO
