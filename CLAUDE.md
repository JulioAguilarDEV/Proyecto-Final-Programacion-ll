# CLAUDE.md – Reglas para el agente de IA (Claude Code)

Claude Code carga este archivo solo al abrir la carpeta del proyecto. Leer completo antes de
hacer cambios. También se cargan la memoria y el estado de los documentos del curso:

@MEMORY.md
@ESTADO_DOCUMENTOS.md

## 1. El proyecto

**Sistema Optica** – Ópticas Visión Guatemala, S. A. (Proyecto Final, Programación II 2026,
Universidad Mariano Gálvez, Centro Universitario Cuilapa, Grupo 8).
Sistema de escritorio para administrar sucursales, usuarios, clientes, citas, optometristas,
exámenes visuales, recetas, productos ópticos, órdenes y entregas.

- C# .NET Framework 4.8, Windows Forms, arquitectura por capas.
- Base de datos: SQL Server (`OpticaGrupo8`). El curso pide PostgreSQL + Supabase; los scripts
  de PostgreSQL también están en `database/`.
- Proyecto de ejemplo del curso: `..\Sistema Veterinaria\` (fuera de esta carpeta, solo referencia).

## 2. Estructura

| Carpeta / archivo | Contenido |
|---|---|
| `CLAUDE.md` | Estas reglas para el agente |
| `MEMORY.md` | Memoria del proyecto: decisiones, avances y pendientes |
| `ESTADO_DOCUMENTOS.md` | Estado de los documentos del curso (cuál está habilitado) |
| `database/scripts/` | Scripts de creación de la base de datos (SQL Server y PostgreSQL) |
| `database/data/` | Scripts de datos de prueba |
| `database/backups/` | Respaldos de la base de datos (`.bak`) |
| `database/CONEXION_DATABASE.md` | Datos de conexión y esquema verificado (sin contraseñas) |
| `database/01_Backup_Base_Datos.sql` | Script del respaldo (`BACKUP DATABASE`) |
| `docs/COMANDOS_RAPIDOS.md` | Comandos de CMD que se usan en el proyecto |
| `docs/diagrams/` | Diagrama conceptual y diagrama entidad-relación |
| `docs/guides/` | Enunciado del proyecto y guías |
| `ia/skills/01_…` a `11_…` | Skills de la guía del curso, uno por etapa |
| `ia/skills/crear-pantalla/` | Skill para crear pantallas y sus capas |
| `src/` | Solución `Sistema Optica.slnx` con los proyectos Entidad, Datos, Negocio y Presentacion |

## 3. Reglas del curso (Guía 01)

1. **Preferir CMD (`cmd.exe`) en Windows**; no usar PowerShell si CMD está disponible.
   Claude Code no abre una terminal CMD propia: usar `cmd.exe /c "comando"` o un archivo
   `.cmd` temporal cuando la ruta lleva espacios. Nunca decir que se usó CMD si no se usó.
2. C# .NET Framework, Windows Forms, SQL Server, capas Entidad/Datos/Negocio/Presentación,
   POO básica, consultas parametrizadas, `try/catch` y comentarios didácticos.
3. Conservar los diseños existentes.
4. Orden del curso: CRUD → Git/GitHub (después de los CRUD) → Login y roles (al final).
5. **Documentos 02 al 10 bloqueados** hasta que el estudiante los habilite
   (`ESTADO_DOCUMENTOS.md`). Si pide algo de un documento bloqueado, recordárselo y hacerlo
   solo si lo autoriza.
6. Mostrar primero el plan y esperar autorización antes de crear o modificar archivos.
7. Preguntar al terminar cada paso; no avanzar por cuenta propia.
8. En los `.md` anotar solo hechos comprobados: no marcar como correcta una prueba que no se
   ejecutó ni asumir resultados.
9. No ejecutar comandos de Git/GitHub sin que el estudiante lo pida.
10. Nunca escribir contraseñas en los `.md` ni subirlas a GitHub (el repositorio es público).

## 4. Reglas de arquitectura (obligatorias)

1. Flujo: **Presentación → Negocio → Datos → Base de datos**; la Entidad viaja entre capas.
2. Presentación **nunca** usa `SqlConnection` ni la capa Datos directamente.
3. Cada módulo implementa **Consultar, Agregar, Editar, Eliminar y Buscar**.
4. Las validaciones de reglas del negocio van en la capa Negocio.
5. Los proyectos son estilo antiguo: todo archivo nuevo se registra en su `.csproj`.

## 5. Estilo de código

- Código de **programador junior**, sencillo y comentado, igual al proyecto de ejemplo:
  comentarios de bloque `// =====`, métodos con prefijo `Mtd`, `try/catch` con `MessageBox`.
- Nombres y mensajes en **español**. Nada de LINQ ni técnicas avanzadas.
- Usar los colores del logo definidos en `ia/skills/crear-pantalla/00_CONTEXTO_PROYECTO.md`.

## 6. Skills disponibles

| Skill | Para qué | Estado |
|---|---|---|
| `ia/skills/01_Inspeccion_Inicial.md` | Prueba de CMD, revisar estructura, solución, capas y formularios | COMPLETO |
| `ia/skills/02_Conexion_SQLServer.md` | Conexión, inspección del esquema, respaldo y clase de conexión | COMPLETO |
| `ia/skills/03_CRUD_Simple.md` | CRUD de una tabla | PENDIENTE |
| `ia/skills/04_CRUD_Relacional.md` | CRUD con llaves foráneas | PENDIENTE |
| `ia/skills/05_Maestro_Detalle.md` | Pantalla encabezado + detalle | PENDIENTE |
| `ia/skills/06_Git_Colaborativo.md` | Trabajo en equipo con Git/GitHub | PENDIENTE |
| `ia/skills/07_Login_Roles.md` | Login y roles | PENDIENTE |
| `ia/skills/08_Panel_Navegacion.md` | Panel de navegación | PENDIENTE |
| `ia/skills/09_Dashboard.md` | Dashboard | PENDIENTE |
| `ia/skills/10_Revision_Proyecto.md` | Revisión del proyecto | PENDIENTE |
| `ia/skills/11_Publicacion.md` | Publicación | PENDIENTE |
| `ia/skills/crear-pantalla/SKILL.md` | Crear pantallas (diseño CRUD, dashboard, menú) y sus capas a partir de una tabla | En uso |

Con `crear-pantalla` el usuario pide nombrando los archivos de parametrización, por ejemplo:
*"Créame la pantalla de Clientes con el diseño de `02_DISENO_CRUD.md`"*. Leer primero
`SKILL.md` (índice) y después solo los archivos que se nombren.

## 7. Trabajo en equipo

| Integrante | Módulos | Componente |
|---|---|---|
| Docente + Grupo | Sucursales | CRUD patrón + Agente IA |
| Diego José Velásquez González | Usuarios · Clientes · Citas | Login |
| Luis Alfredo Ruano Dealtán | Tipos de Producto · Productos Ópticos · Órdenes | Panel de Acceso |
| Julio César Aguilar Tije | Optometristas · Exámenes Visuales · Recetas | Dashboard |

- No modificar los módulos de otro integrante sin avisar al usuario.
- Si una pantalla necesita una tabla de otro integrante (por ejemplo un ComboBox de Clientes)
  y sus capas no existen, crearlas con la skill y avisar que pertenecen a otro integrante.

## 8. Compilar y ejecutar

En CMD, desde la carpeta del proyecto:

```cmd
"C:\Program Files\Microsoft Visual Studio\18\Community\MSBuild\Current\Bin\MSBuild.exe" "src\Sistema Optica.slnx" /t:Build /p:Configuration=Debug /v:minimal /nologo
```

En Visual Studio el proyecto de inicio debe ser **Presentacion**. La cadena de conexión está
en `src/Presentacion/App.config` (`ConexionSQLServer`). Más comandos: `docs/COMANDOS_RAPIDOS.md`.

## 9. Al terminar cada tarea

1. Compilar sin errores ni advertencias.
2. Anotar en `MEMORY.md` qué se hizo, qué se decidió y qué queda pendiente (con fecha).
3. Si se terminó un paso de un documento, actualizar `ESTADO_DOCUMENTOS.md` (solo hechos comprobados).
4. Decirle al usuario qué archivos se crearon o cambiaron y preguntar antes de seguir.

## 10. No hacer

- No subir `bin/`, `obj/`, `.vs/` ni `src/packages/` (ya están en `.gitignore`).
- No cambiar la base de datos ni los scripts sin que el usuario lo pida.
- No inventar campos: los campos salen de la tabla que pasa el usuario o de
  `ia/skills/crear-pantalla/01_BASE_DE_DATOS.md`.
- No modificar `..\Sistema Veterinaria\` (es solo el ejemplo del curso).
