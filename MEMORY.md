# MEMORY.md – Memoria del proyecto

Registro de decisiones, avances y pendientes del Sistema Optica. El agente de IA lo lee al
empezar y lo actualiza al terminar cada tarea (ver `AGENTS.md`). Lo más reciente va arriba.

## Estado actual

| Pantalla | Diseño | Lógica (capas + eventos) | Responsable |
|---|---|---|---|
| FrmPrincipal (menú) | ✅ | ✅ navegación (sin BD) | Julio |
| FrmDashboard (bienvenida) | ✅ | — (no lleva) | Julio |
| FrmOptometrista | ✅ | ✅ probada con la BD | Julio |
| FrmExamenVisual | ✅ | ✅ probada con la BD | Julio |
| FrmReceta | ✅ | ✅ probada con la BD | Julio |
| Sucursales | ⏳ | ⏳ | Docente + Grupo |
| Login | ✅ | ✅ autenticación y permisos de menú | Diego |
| Usuarios, Clientes, Citas | ⏳ | ⏳ | Diego |
| Roles y accesos | ✅ | ✅ CRUD de roles y configuración de menú | Julio |
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
- **Conexiones (`App.config`):** activa solo `ConexionSQLServer` (Docker `sql_prog2a`, puerto
  1433, BD `OpticaGrupo8`). `ConexionPostgreSQL` (Docker `postgres_progra2`) y
  `ConexionSupabase` quedan comentadas: necesitan Npgsql y cambiar la capa Datos.
- **Supabase:** la contraseña de la BD **no se sube** (el repo de GitHub es público): en el
  repo queda `<CONTRASEÑA-DE-LA-BD>` y cada integrante la pone en su copia. La anon key no
  sirve para conectarse desde ADO.NET. Probado el 2026-10-10: conecta directo
  (`db.qdxlfblrocahnsviapwj.supabase.co`, solo IPv6) y por el pooler `aws-0-us-east-2`
  (IPv4). La BD de Supabase **está vacía**: falta correr ahí los scripts
  `*_PostgreSQL_OpticaGrupo8.sql`.
- **Capas de Cliente y Cita:** las creó Julio solo para llenar los ComboBox de Exámenes
  Visuales (son tablas de Diego). Diego debe usar esas clases y no crear otras.
- **ComboBox:** la propiedad del `DisplayMember` (`NombreCompleto`, `Descripcion`) **no** lleva
  `[Browsable(false)]`; con ese atributo el ComboBox muestra `Entidad.ClienteEntidad`.

## Historial

### 2026-10-24
- Con autorización del usuario, se agregaron `dbo.Rol` y `dbo.RolAcceso` con los roles
  Administrador, Operador y Optometrista. Se aplicó `database/scripts/2_Script_Roles_SQLServer.sql`
  a la BD SQL Server ya existente, dentro de una transacción; la consulta de verificación
  confirmó 12 accesos iniciales para Administrador, 7 para Operador y 5 para Optometrista.
- Se agregaron las capas Entidad/Datos/Negocio para roles y autenticación, el formulario
  `FrmRoles` para CRUD y configuración de permisos, y se conectó el Login al inicio de la
  aplicación. `FrmPrincipal` oculta y bloquea opciones no asignadas; la pantalla de roles queda
  reservada a Administrador. El acceso a Inicio se mantiene obligatorio; Administrador no se
  puede desactivar, renombrar ni eliminar para evitar perder la administración.
- Se actualizaron los scripts de creación y datos de SQL Server/PostgreSQL. El build Debug
  terminó correctamente con MSBuild de Visual Studio 2022. Pendiente: pruebas manuales de
  inicio de sesión y edición de permisos en la interfaz.

### 2026-10-27
- Se corrigió el recorte de pantallas incrustadas al abrirlas desde el menú principal. La ventana
  principal inicia maximizada y conserva el tamaño nativo de diseño de cada formulario; se quitó
  el escalado proporcional aplicado al incrustarlos, que reducía el ancho de botones e iconos y
  cortaba sus textos. El menú compacto centra iconos, oculta textos que no caben, muestra/oculta
  la identidad de sesión y mantiene el botón Roles sobre el panel de usuario. Build Debug exitoso.
- Tras confirmarse que Optometristas aún no quedaba visible correctamente y que los botones seguían
  recortados, se reforzó el alojamiento: el menú aplica `AutoScaleMode.None`, fuerza el formulario
  activo al frente del panel y ajusta los `IconButton` de los CRUD a un ancho mínimo de 150,
  tipografía de 9 pt e icono de 20 px. El formulario principal limita maximización al área de
  trabajo de Windows para evitar ocultar la fila inferior bajo la barra de tareas. Build Debug
  exitoso; el usuario debe cerrar la instancia anterior y volver a ejecutar el binario actualizado.
- Con autorización del usuario, el nombre completo y rol de la sesión ahora se muestran en el
  encabezado superior de las pantallas CRUD de Usuarios y Roles. FrmPrincipal pasa el usuario
  autenticado a ambas pantallas; FrmUsuarios reutiliza sus paneles de encabezado en tiempo de
  ejecución y FrmRoles agrega el indicador sin editar manualmente ningún Designer.
- Pendiente: validación visual manual de ambos encabezados.
- Se actualizó el Login por código en `FrmLogin.cs`, sin tocar `FrmLogin.Designer.cs`: fondo azul
  claro, tarjeta blanca, título y textos de ayuda, campos con mejor jerarquía y botones con
  colores de acción y estados hover. Se conservó la autenticación y navegación existentes.
  Build Debug exitoso; pendiente validar visualmente en ejecución.
- Se documentaron con comentarios sencillos las propiedades y métodos de las capas de Entidad,
  Datos y Negocio para Login/Roles. El panel superior de `FrmPrincipal` y el panel de usuario
  muestran ahora el nombre completo y el rol de la sesión. La consulta de Login compara la
  contraseña existente con parámetro SQL y no devuelve la contraseña en la entidad de sesión;
  no se agregó cifrado ni se modificó App.config.

### 2026-10-23
- El usuario aclaró que el módulo autorizado es `FrmProductos` y autorizó crear su ComboBox de
  TipoProducto en tiempo de ejecución, sin editar el Designer. Se agregaron Entidad/Datos/
  Negocio para consultar `dbo.ProductoOptico` con JOIN a `dbo.TipoProducto`, cargar el catálogo
  existente por `CodigoTipoProducto`/`Nombre`, y mostrar 10 resultados por página desde
  Presentación conservando el total de la consulta completa. Solo se conectaron eventos de
  consulta, búsqueda local y navegación. El usuario confirmó compilación y pruebas correctas.
  Los cambios iniciales de paginación en `FrmTiposDeProducto` se revirtieron al aclararse que
  el módulo autorizado era `FrmProductos`; su Designer queda sin cambios.
- Con autorización del 2026-10-23 se agregaron solo Agregar, Buscar, Editar y Eliminar para
  `ProductoOptico`, sin cambiar la base de datos ni `FrmProductos.Designer.cs`. Datos usa
  parámetros tipados; Buscar filtra por código (PK), nombre, descripción y marca. Negocio valida
  el tipo FK, longitudes, precio y estado. Presentación usa `SelectedValue` para la FK, carga los
  campos al seleccionar para editar, refresca el total después de cada operación y mantiene
  paginación de 10 en Presentación sin alterar el total de resultados. El Skill
  `04_CRUD_Relacional.md` no se encontró; se siguieron las guías actuales de capas. Pendiente:
  compilación y pruebas manuales del usuario; esperar confirmación antes de cerrar.
- El usuario informó que el control "Código Tipo Producto" mostraba la descripción en vez del
  código. Se cambió el `DisplayMember` del ComboBox runtime a `CodigoTipoProducto`; el
  `ValueMember` y `SelectedValue` siguen usando esa misma clave. Pendiente de prueba visual del
  usuario; no se compiló.
- Se inicia `FrmOrdenes` solo con consulta y carga de catálogos. Se agregaron capas Entidad,
  Datos y Negocio de Orden, con consulta de Orden y detalle/producto mediante JOIN; la pantalla
  pagina 10 filas desde Presentación y conserva el total de la consulta completa. Los ComboBox
  runtime cargan Cliente (`NombreCompleto`/`CodigoCliente`), Sucursal (`Nombre`/`CodigoSucursal`)
  y Producto (`Nombre`/`CodigoProducto`), sin editar `FrmOrdenes.Designer.cs`. Como no existían
  capas de Sucursal, se crearon consultas sencillas de Entidad/Datos/Negocio únicamente para el
  catálogo requerido; esas capas corresponden al módulo de Docente + Grupo. El usuario confirmó
  el 2026-10-23 que la consulta y los catálogos funcionan correctamente. Esta etapa queda probada;
  después autorizó las operaciones CRUD restantes.
- Con autorización del 2026-10-23 se agregaron Agregar, Buscar, Editar y Eliminar para Ordenes.
  Datos usa SQL parametrizado y transacciones para guardar/editar cabecera y detalle, y para
  eliminar la orden junto con sus detalles; Negocio valida FK, estado, cantidad y montos.
  Presentación carga los códigos FK desde `SelectedValue`, al seleccionar una fila coloca sus
  valores en los controles, busca por PK/cliente/sucursal/estado, mantiene la paginación de 10
  filas y el total del conjunto consultado. Editar cambia la cabecera y la línea seleccionada,
  preservando otros detalles; eliminar quita todos los detalles de esa orden. No se modificaron
  `FrmOrdenes.Designer.cs`, la base de datos ni otros módulos. Pendiente: el usuario compilará y
  probará las operaciones; esperar su confirmación antes de cerrar.
- Ante el reporte de que Eliminar no permite borrar productos, se consultó SQL Server en modo de
  solo lectura: los cinco productos existentes están referenciados por `DetalleOrden`. El usuario
  decidió conservar el bloqueo de la FK y pedir inactivación manual; se aclaró el mensaje SQL 547
  para recomendar editar el producto y cambiarlo a Inactivo. No se modificaron datos ni esquema.

### 2026-10-10
- Se subió todo a GitHub (`main`): pantallas de Diego y Luis, scripts PostgreSQL para
  Supabase y la lógica de las pantallas de Julio.
- **Lógica de las pantallas de Julio:** capas Entidad/Datos/Negocio de Optometrista,
  ExamenVisual y Receta (más Cliente y Cita para los ComboBox) y eventos de FrmOptometrista,
  FrmExamenVisual y FrmReceta. `App.config` con 3 conexiones (solo SQL Server activa).
  Probado contra `OpticaGrupo8` en Docker dentro de transacciones que se deshacen: 39
  pruebas de capas y 55 de pantalla (botones reales, CellClick, ComboBox, validaciones,
  UNIQUE, FK al eliminar). Después se regresó el IDENTITY de las tablas al código 5 para que
  el siguiente registro sea el 6.
- El DataGridView seleccionaba la primera fila al abrir (el `ClearSelection()` del Load no
  basta): se agregó el evento `DataBindingComplete` con `ClearSelection()`
  (`07_LOGICA_FORMULARIO.md`).
- Se crearon `database/scripts/1_Script_Creacion_BD_PostgreSQL_OpticaGrupo8.sql` y
  `database/data/2_Script_Datos_Prueba_PostgreSQL_OpticaGrupo8.sql`: copia 1 a 1 de los de
  SQL Server (mismas tablas, campos y datos), listos para el SQL Editor de Supabase: sin
  `CREATE DATABASE` ni `\c` (Supabase da error con `\c` y las tablas van en el esquema public
  de la base del proyecto). Se probaron en Docker (postgres:18) enviando cada archivo como una
  sola consulta: 12 tablas con 5 registros cada una. Los scripts de PostgreSQL anteriores se
  dejaron igual.
- En Supabase el script de creación daba `relation "public.Sucursal" does not exist`: Supabase
  agrega `alter table "public"."Sucursal" enable row level security` con el nombre entre
  comillas y PostgreSQL guardó la tabla como `sucursal`. Se pusieron en minúscula solo los
  nombres de las tablas en `CREATE TABLE` y `REFERENCES` (la BD queda igual; los campos no
  cambian). Probado en Docker con esos ALTER agregados: 12 tablas con RLS y los datos cargan.

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

- [x] Lógica CRUD de Optometristas, Exámenes Visuales y Recetas (capas + eventos).
- [x] Probar con la base de datos (SQL Server en Docker, `sql_prog2a`).
- [ ] Decidir si se migra a PostgreSQL/Supabase como pide el curso.
- [ ] Conectar al menú las pantallas de los demás integrantes cuando existan.
- [x] Subir el proyecto a GitHub (`main`, 2026-10-10).
- [ ] Correr en Supabase los scripts `*_PostgreSQL_OpticaGrupo8.sql` (la BD de Supabase está vacía).
