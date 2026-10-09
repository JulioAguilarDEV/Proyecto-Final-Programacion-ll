# MEMORY.md – Memoria del proyecto

Registro de decisiones, avances y pendientes del Sistema Optica. El agente de IA lo lee al
empezar y lo actualiza al terminar cada tarea (ver `AGENTS.md`). Lo más reciente va arriba.

## Estado actual

| Pantalla | Diseño | Lógica (capas + eventos) | Responsable |
|---|---|---|---|
| FrmPrincipal (menú) | ✅ | ✅ navegación (sin BD) | Julio |
| FrmDashboard (bienvenida) | ✅ | — (no lleva) | Julio |
| FrmOptometrista | ✅ | ⏳ pendiente | Julio |
| FrmExamenVisual | ✅ | ⏳ pendiente | Julio |
| FrmReceta | ✅ | ⏳ pendiente | Julio |
| Sucursales | ⏳ | ⏳ | Docente + Grupo |
| Usuarios, Clientes, Citas, Login | ⏳ | ⏳ | Diego |
| Tipos de Producto, Productos Ópticos, Órdenes, Panel de Acceso | ⏳ | ⏳ | Luis |
| Entregas | ⏳ | ⏳ | (sin asignar en la distribución) |

## Decisiones

- **Base de datos:** se trabaja con SQL Server (`OpticaGrupo8`, librería `System.Data.SqlClient`)
  como el proyecto de ejemplo. El curso pide PostgreSQL + Supabase + Docker; los scripts de
  PostgreSQL están en `database/` y el cambio de la capa Datos está explicado en
  `ia/skills/crear-pantalla/05_CAPA_DATOS.md` (sección 4).
- **Diseño:** igual al ejemplo Sistema Veterinaria (pestañas Consultar/Gestionar), con los
  colores del logo: marino 3,47,103 (también fondo del menú); gris 101,114,122 (botón
  seleccionado del menú); azul del iris 2,66,125 (hover del menú); fondo 253,252,250.
- **Menú principal:** ventana sin borde con menú lateral gris, logo arriba y panel contenedor
  donde se abren todas las pantallas. Inicia en `FrmPrincipal` hasta que exista el Login.
- **Dashboard:** solo el texto del logo translúcido (sin el ojo, porque el ojo ya está en el
  menú) y "Bienvenidos" (el usuario no quiere gráficas ni tarjetas). El diseño con tarjetas y gráficas quedó guardado como Diseño B en
  `ia/skills/crear-pantalla/03_DISENO_DASHBOARD.md`. Ojo: la rúbrica evalúa que el Dashboard
  esté integrado con los demás módulos.
- **Grids:** las columnas se definen en el diseño (`col{Campo}`, `DataPropertyName = {Campo}`);
  en la lógica se usa `AutoGenerateColumns = false`.
- **Código:** estilo programador junior, comentado, en español.

## Historial

### 2026-10-03
- Se crearon los scripts de SQL Server a partir de los de PostgreSQL.
- Se armó la solución `src/Sistema Optica.slnx` (Entidad, Datos, Negocio, Presentacion) con
  las librerías del ejemplo (FontAwesome.Sharp, SqlClient, ConfigurationManager).
- Se diseñaron FrmOptometrista, FrmExamenVisual y FrmReceta (solo diseño).
- Se creó FrmPrincipal (menú) y FrmDashboard (bienvenida).
- Se escribió la skill `ia/skills/crear-pantalla/` dividida en archivos de parametrización
  (00 a 09) y se probó que sus plantillas de lógica compilan.
- Se reorganizó el proyecto con la estructura del curso (`database`, `docs`, `ia`, `src`).
- En el menú principal (`FrmPrincipal`) el logo de arriba se cambió por el ícono del ojo
  (`logoicono.png`, recurso `LogoIcono`). El botón Dashboard del menú ahora dice "Inicio".
- En el Dashboard se quitó el ojo del logo translúcido: `LogoTranslucido.png` ahora es solo el
  texto "ÓPTICAS VISIÓN – GUATEMALA, S. A." al 25 % (800x341 en 240,200) con "Bienvenidos" debajo.
- El menú lateral pasó de gris a azul marino (3,47,103), el color que tenía el botón
  seleccionado. Ahora el botón seleccionado es gris del logo (101,114,122), el hover es el azul
  del iris (2,66,125) y el panel de usuario marino oscuro (2,34,77).
- El botón del menú ya no es "Dashboard" sino **Inicio**: se llama `btnInicio` (evento
  `btnInicio_Click`), ícono de casa (`House`) y la barra de título dice "Inicio". Abre
  `FrmDashboard` (la bienvenida); el formulario conserva ese nombre porque es el componente
  Dashboard de la rúbrica.

## Pendientes

- [ ] Lógica CRUD de Optometristas, Exámenes Visuales y Recetas (capas + eventos).
- [ ] Probar con la base de datos (ejecutar los scripts de `database/`).
- [ ] Decidir si se migra a PostgreSQL/Supabase como pide el curso.
- [ ] Conectar al menú las pantallas de los demás integrantes cuando existan.
- [ ] Subir el proyecto a GitHub.
