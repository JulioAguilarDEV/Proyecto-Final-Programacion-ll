# 01 · Inspección inicial

> **Estado:** COMPLETO (Documento 01).
>
> **Úsalo** al empezar una tarea y antes de modificar archivos: prueba de CMD y permisos,
> archivos que se leen primero, estructura del proyecto y revisión de la solución
> (cuatro capas, referencias y formularios).
> Datos generales del proyecto (rutas, integrantes, pantallas hechas, colores):
> `ia/skills/crear-pantalla/00_CONTEXTO_PROYECTO.md`.

## 1. Prueba de CMD y permisos

Regla del curso: **preferir CMD (`cmd.exe`) en Windows**; no usar PowerShell si CMD sirve.
Claude Code no abre una terminal CMD propia: se usa `cmd.exe /c "comando"` o un archivo
`.cmd` temporal cuando la ruta lleva espacios.

1. Mostrar la ruta actual y listar la carpeta (`cd` y `dir /b`).
2. Crear `PruebaClaude.txt` con el texto `PRUEBA`, leerlo (`type`) y eliminarlo (`del`).
3. No modificar ningún otro archivo.
4. Informar qué acciones se ejecutaron y cuáles fallaron.

Si no se puede usar CMD o la prueba falla: **detenerse** y decirlo tal cual. No afirmar que
se usó CMD ni que la prueba salió bien, y no continuar hasta que el estudiante lo corrija.

## 2. Archivos que se leen primero

1. `CLAUDE.md` (Claude Code lo carga solo, junto con `MEMORY.md` y `ESTADO_DOCUMENTOS.md`).
2. `ESTADO_DOCUMENTOS.md` → qué documento está habilitado. No trabajar en un documento
   BLOQUEADO sin autorización del estudiante.
3. El skill que corresponda a la tarea.

## 3. Estructura del proyecto

```
ProyectoFinal_SistemaOptica\
├── README.md
├── CLAUDE.md
├── MEMORY.md
├── ESTADO_DOCUMENTOS.md
├── .gitignore
├── database\
│   ├── scripts\                  creación de la BD (SQL Server y PostgreSQL)
│   ├── data\                     datos de prueba
│   ├── backups\                  respaldos .bak
│   ├── CONEXION_DATABASE.md
│   └── 01_Backup_Base_Datos.sql
├── docs\
│   ├── diagrams\                 diagrama conceptual y entidad-relación
│   ├── guides\                   enunciado del proyecto
│   └── COMANDOS_RAPIDOS.md
├── ia\
│   └── skills\
│       ├── 01_Inspeccion_Inicial.md … 11_Publicacion.md
│       └── crear-pantalla\       skill para crear pantallas
└── src\
    └── Sistema Optica.slnx       Entidad, Datos, Negocio, Presentacion
```

Revisar que existan los 11 skills de `ia/skills/` y los archivos `.md` de la raíz. Si falta
algo o un nombre está mal, corregir **solo** lo que falta.

## 4. Revisar la solución

1. `src/Sistema Optica.slnx` debe tener las **cuatro capas**: Entidad, Datos, Negocio y Presentacion.
2. Referencias entre proyectos (`<ProjectReference>` de cada `.csproj`):
   Datos → Entidad · Negocio → Datos, Entidad · Presentacion → Negocio, Entidad (también
   tiene Datos, pero el código de Presentación nunca usa clases de Datos).
3. Formularios: leer `Frm*.cs`, `Frm*.Designer.cs` y `Frm*.resx` de `src/Presentacion/`.
4. Relacionar los controles con las columnas reales de SQL Server
   (`database/CONEXION_DATABASE.md` y `ia/skills/crear-pantalla/01_BASE_DE_DATOS.md`):

| Tabla | Columna | Tipo | Control | Observación |
|---|---|---|---|---|
| Optometrista | NumeroColegiado | VARCHAR(20) | txtNumeroColegiado | UNIQUE, MaxLength 20 |

5. Compilar (comando en `docs/COMANDOS_RAPIDOS.md`), abrir la solución en Visual Studio y
   revisar que los diseños se abren en el diseñador.

## 5. Reglas de la inspección

- No cambiar el diseñador ni agregar lógica CRUD mientras se inspecciona.
- No alterar las tablas de la base de datos.
- Indicar los errores encontrados y proponer **correcciones mínimas**.
- Pedir autorización antes de modificar cualquier archivo.
- Anotar en los `.md` solo hechos comprobados.
