# CONEXION_DATABASE.md – Conexión a la base de datos

**No escribir contraseñas en este archivo** (el repositorio de GitHub es público).

## 1. Datos de conexión

Tomados de la cadena `ConexionSQLServer` de `src/Presentacion/App.config`.

| Dato | Valor |
|---|---|
| Servidor | `localhost` (SQL Server en Docker, contenedor `sql_prog2a`) |
| Puerto | `1433` |
| Base de datos | `OpticaGrupo8` |
| Autenticación | SQL Server |
| Usuario | `sa` |
| Contraseña | [CONFIGURAR LOCALMENTE] – solo en la copia local de `App.config` |

## 2. Prueba de conexión

⏳ Pendiente (Documento 01, paso 1.4). Consulta de solo lectura en
`ia/skills/02_Conexion_SQLServer.md`, sección 2.

## 3. Esquema verificado

⏳ Pendiente (Documento 01, paso 1.5): tablas, columnas, tipos, nulabilidad, PK y FK
obtenidos del catálogo de SQL Server.

## 4. Otras conexiones (comentadas en `App.config`)

- `ConexionPostgreSQL`: PostgreSQL en Docker.
- `ConexionSupabase`: Supabase (directo o por el pooler).

Las dos necesitan Npgsql y cambiar la capa Datos.
