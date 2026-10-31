# ESTADO_DOCUMENTOS.md – Documentos del curso

Estado de los documentos (guías) del curso Programación II 2026. Solo se trabaja en el
documento HABILITADO; los BLOQUEADOS se habilitan cuando el estudiante lo autoriza.
Se anotan solo hechos comprobados.

## Resumen

| Documento | Tema | Skills | Estado |
|---|---|---|---|
| 01 | Preparación del agente de IA y herramientas de desarrollo | 01, 02 | EN PROCESO |
| 02 | (se anota al recibir la guía) | — | BLOQUEADO |
| 03 | (se anota al recibir la guía) | — | BLOQUEADO |
| 04 | (se anota al recibir la guía) | — | BLOQUEADO |
| 05 | (se anota al recibir la guía) | — | BLOQUEADO |
| 06 | (se anota al recibir la guía) | — | BLOQUEADO |
| 07 | (se anota al recibir la guía) | — | BLOQUEADO |
| 08 | (se anota al recibir la guía) | — | BLOQUEADO |
| 09 | (se anota al recibir la guía) | — | BLOQUEADO |
| 10 | (se anota al recibir la guía) | — | BLOQUEADO |

## Documento 01 – Pasos

| Paso | Descripción | Estado |
|---|---|---|
| 1.1 | Prueba de CMD y permisos | ✅ 2026-10-17: Claude ejecutó en `cmd.exe` `cd`, `dir`, creó, leyó y borró `PruebaClaude.txt` |
| 1.2 | Estructura y reglas del agente | ✅ 2026-10-17: `CLAUDE.md`, `ESTADO_DOCUMENTOS.md`, 11 skills en `ia/skills/`, `docs/COMANDOS_RAPIDOS.md`, `database/CONEXION_DATABASE.md` y `database/01_Backup_Base_Datos.sql` |
| 1.3 | Revisar la estructura creada | ⏳ Falta que el estudiante confirme el árbol |
| 1.4 | Verificar SQL Server (consulta de solo lectura) | ⏳ Pendiente |
| 1.5 | Inspeccionar tablas, PK, FK y tipos | ⏳ Pendiente |
| 1.6 | Respaldo y propuesta de conexión por capas | ⏳ Pendiente (el script del respaldo está preparado, sin ejecutar) |
| 1.7 | Revisar la solución de `src/` (capas, referencias, formularios) | ⏳ Pendiente (la solución ya está en `src/` desde el 2026-10-03) |
| 1.8 | Configurar y probar la clase de conexión | ⏳ Pendiente de volver a probar (`ConexionBaseDatos.cs` ya existe; se probó con la BD el 2026-10-10) |
| 1.9 | Cerrar el Documento 01 | ⏳ Pendiente |

**Cierre del Documento 01:** solo cuando el estudiante escriba:
*«Documento 01 validado; actualiza MEMORY.md y ESTADO_DOCUMENTOS.md y habilita solo Documento 02»*.

## Avance hecho antes de esta guía

Las pantallas de Julio (FrmOptometrista, FrmExamenVisual, FrmReceta) ya tienen su CRUD
completo, probado con la base de datos el 2026-10-10 (ver `MEMORY.md`).
