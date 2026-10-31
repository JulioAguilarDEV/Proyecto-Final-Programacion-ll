# 02 · Conexión a SQL Server

> **Estado:** COMPLETO (Documento 01).
>
> **Úsalo para** comprobar la conexión a SQL Server, inspeccionar el esquema real (tablas,
> columnas, tipos, nulabilidad, PK y FK), preparar el respaldo y revisar la clase de
> conexión de la capa Datos.
> Referencia de las 12 tablas y tipos SQL → C#: `ia/skills/crear-pantalla/01_BASE_DE_DATOS.md`.

## 1. Datos de conexión

- Datos verificados (sin contraseña): `database/CONEXION_DATABASE.md`.
- Cadena que usa el sistema: `src/Presentacion/App.config` → `ConexionSQLServer`.
- SQL Server corre en Docker, contenedor `sql_prog2a` (puerto 1433, BD `OpticaGrupo8`).
  Si no conecta, revisar que el contenedor esté encendido: `docker start sql_prog2a`.
- **Nunca** escribir la contraseña en un `.md` ni subirla a GitHub. Solo va en la copia
  local de `App.config`.

## 2. Prueba de solo lectura

Claude puede consultar con `sqlcmd` dentro del contenedor (la contraseña se toma de la copia
local de `App.config`):

```cmd
docker exec sql_prog2a /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P "<contraseña>" -C -d OpticaGrupo8 -Q "SELECT DB_NAME() AS BaseActual;"
```

Consulta de prueba (si Claude no tiene acceso, el estudiante la ejecuta en SSMS y pega el resultado):

```sql
SELECT DB_NAME() AS BaseActual;

SELECT TOP (5) TABLE_SCHEMA, TABLE_NAME
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE'
ORDER BY TABLE_NAME;
```

Si no se puede acceder, explicar el error y dar los pasos para corregirlo. No seguir hasta
que la consulta funcione.

## 3. Inspección del catálogo (sin modificar datos)

```sql
-- Columnas, tipos y nulabilidad
SELECT TABLE_NAME, COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH,
       NUMERIC_PRECISION, NUMERIC_SCALE, IS_NULLABLE
FROM INFORMATION_SCHEMA.COLUMNS
ORDER BY TABLE_NAME, ORDINAL_POSITION;

-- Llaves primarias y campos UNIQUE
SELECT tc.TABLE_NAME, tc.CONSTRAINT_TYPE, kcu.COLUMN_NAME
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc
INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE kcu
        ON tc.CONSTRAINT_NAME = kcu.CONSTRAINT_NAME
WHERE tc.CONSTRAINT_TYPE IN ('PRIMARY KEY', 'UNIQUE')
ORDER BY tc.TABLE_NAME;

-- Llaves foráneas
SELECT OBJECT_NAME(fk.parent_object_id) AS Tabla,
       COL_NAME(fkc.parent_object_id, fkc.parent_column_id) AS Columna,
       OBJECT_NAME(fk.referenced_object_id) AS TablaReferenciada,
       COL_NAME(fkc.referenced_object_id, fkc.referenced_column_id) AS ColumnaReferenciada
FROM sys.foreign_keys fk
INNER JOIN sys.foreign_key_columns fkc ON fk.object_id = fkc.constraint_object_id
ORDER BY Tabla;
```

Reglas:
- No inventar columnas ni relaciones: todo sale de estas consultas.
- Resumir los hallazgos y anotarlos en `database/CONEXION_DATABASE.md` (sección 3).
- Si algo no coincide con `crear-pantalla/01_BASE_DE_DATOS.md`, avisar al estudiante antes de cambiarlo.

## 4. Respaldo de la base de datos

1. Revisar `database/01_Backup_Base_Datos.sql` (nombre real de la BD y ruta **dentro del
   contenedor**: `/var/opt/mssql/backups/`).
2. Antes de ejecutarlo, comprobar que la ruta existe y tiene permisos:
   `docker exec sql_prog2a ls -la /var/opt/mssql/backups`
3. Ejecutar el respaldo solo con autorización del estudiante y verificarlo con `RESTORE VERIFYONLY`.
4. Copiar el `.bak` fuera del contenedor, a `database/backups/`:
   `docker cp sql_prog2a:/var/opt/mssql/backups/<archivo>.bak database\backups\`

## 5. Clase de conexión (capa Datos)

Ya existe `src/Datos/ConexionBaseDatos.cs`:
- El constructor lee la cadena `ConexionSQLServer` de `App.config` con `ConfigurationManager`.
- `MtdObtenerDatos()` devuelve un `SqlConnection` nuevo que usan las clases Datos.

Reglas:
- Presentación **nunca** se conecta directo a SQL Server (solo usa Negocio y Entidad).
- En este paso no se programa ningún CRUD (Consultar/Agregar/Editar/Eliminar/Buscar).
- Si se agrega una prueba de conexión, que sea sencilla, con `try/catch` y mensajes claros.
- Cambio a PostgreSQL: `ia/skills/crear-pantalla/05_CAPA_DATOS.md`, sección 4.
