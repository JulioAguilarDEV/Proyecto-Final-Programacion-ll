# AGENTS.md – Reglas para el agente de IA

Instrucciones para cualquier agente de IA (Claude, Copilot, etc.) que trabaje en este
proyecto. Leer completo antes de hacer cambios.

## 1. El proyecto

**Sistema Optica** – Ópticas Visión Guatemala, S. A. (Proyecto Final, Programación II,
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
| `database/scripts/` | Scripts de creación de la base de datos (SQL Server y PostgreSQL) |
| `database/data/` | Scripts de datos de prueba |
| `database/backups/` | Respaldos de la base de datos |
| `docs/diagrams/` | Diagrama conceptual y diagrama entidad-relación |
| `docs/guides/` | Enunciado del proyecto y guías |
| `ia/skills/` | Skills (archivos de parametrización) para el agente |
| `src/` | Solución `Sistema Optica.slnx` con los proyectos Entidad, Datos, Negocio y Presentacion |
| `MEMORY.md` | Memoria del proyecto: decisiones, avances y pendientes |

## 3. Reglas de arquitectura (obligatorias)

1. Flujo: **Presentación → Negocio → Datos → Base de datos**; la Entidad viaja entre capas.
2. Presentación **nunca** usa `SqlConnection` ni la capa Datos directamente.
3. Cada módulo implementa **Consultar, Agregar, Editar, Eliminar y Buscar**.
4. Las validaciones de reglas del negocio van en la capa Negocio.
5. Los proyectos son estilo antiguo: todo archivo nuevo se registra en su `.csproj`.

## 4. Estilo de código

- Código de **programador junior**, sencillo y comentado, igual al proyecto de ejemplo:
  comentarios de bloque `// =====`, métodos con prefijo `Mtd`, `try/catch` con `MessageBox`.
- Nombres y mensajes en **español**. Nada de LINQ ni técnicas avanzadas.
- Usar los colores del logo definidos en `ia/skills/crear-pantalla/00_CONTEXTO_PROYECTO.md`.

## 5. Skills disponibles

| Skill | Ubicación | Para qué |
|---|---|---|
| crear-pantalla | `ia/skills/crear-pantalla/SKILL.md` | Crear pantallas (diseño CRUD, dashboard, menú) y sus capas (Entidad, Datos, Negocio, lógica del formulario) a partir de una tabla |

El usuario pide nombrando los archivos de parametrización, por ejemplo:
*"Créame la pantalla de Clientes con el diseño de `02_DISENO_CRUD.md`"*. Leer primero
`SKILL.md` (índice) y después solo los archivos que se nombren.

## 6. Trabajo en equipo

| Integrante | Módulos | Componente |
|---|---|---|
| Docente + Grupo | Sucursales | CRUD patrón + Agente IA |
| Diego José Velásquez González | Usuarios · Clientes · Citas | Login |
| Luis Alfredo Ruano Dealtán | Tipos de Producto · Productos Ópticos · Órdenes | Panel de Acceso |
| Julio César Aguilar Tije | Optometristas · Exámenes Visuales · Recetas | Dashboard |

- No modificar los módulos de otro integrante sin avisar al usuario.
- Si una pantalla necesita una tabla de otro integrante (por ejemplo un ComboBox de Clientes)
  y sus capas no existen, crearlas con la skill y avisar que pertenecen a otro integrante.

## 7. Compilar y ejecutar

```powershell
& "C:\Program Files\Microsoft Visual Studio\18\Community\MSBuild\Current\Bin\MSBuild.exe" "src\Sistema Optica.slnx" /t:Build /p:Configuration=Debug /v:minimal /nologo
```

En Visual Studio el proyecto de inicio debe ser **Presentacion**. La cadena de conexión está
en `src/Presentacion/App.config` (`ConexionSQLServer`).

## 8. Al terminar cada tarea

1. Compilar sin errores ni advertencias.
2. Anotar en `MEMORY.md` qué se hizo, qué se decidió y qué queda pendiente (con fecha).
3. Decirle al usuario qué archivos se crearon o cambiaron.

## 9. No hacer

- No subir `bin/`, `obj/`, `.vs/` ni `src/packages/` (ya están en `.gitignore`).
- No cambiar la base de datos ni los scripts sin que el usuario lo pida.
- No inventar campos: los campos salen de la tabla que pasa el usuario o de
  `ia/skills/crear-pantalla/01_BASE_DE_DATOS.md`.
- No modificar `..\Sistema Veterinaria\` (es solo el ejemplo del curso).
