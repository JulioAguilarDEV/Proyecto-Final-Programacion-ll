# 07 · Login y roles

> **Estado:** PENDIENTE – se completa cuando se habilite su documento (`ESTADO_DOCUMENTOS.md`).
>
> **Para qué:** inicio de sesión y permisos según el rol del usuario. En el orden del curso
> va al final.

## Lo que ya existe en el proyecto

- Tabla `Usuario` con `NombreUsuario` (UNIQUE), `Contrasena`, `Rol` y `Estado`.
- `FrmLogin` (módulo de Diego) en `src/Presentacion/`.
- `Program.cs` inicia en `FrmPrincipal` mientras no exista el Login.
