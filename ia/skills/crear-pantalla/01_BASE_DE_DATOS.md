# 01 · Base de datos

> **Úsalo siempre** para completar los campos que pase el usuario: tipos, NULL, llaves
> foráneas, UNIQUE y los valores de Estado. También trae la equivalencia de tipos SQL → C#.
> Scripts: `database/scripts/` (creación) y `database/data/` (datos de prueba).

## 1. Tablas

Todas las PK son `INT IDENTITY(1,1)`. `(N)` = permite NULL. Estados usados en los datos de prueba.

| Tabla | Campos | FK / UNIQUE | Valores de Estado |
|---|---|---|---|
| Sucursal | CodigoSucursal, Nombre V100, Direccion V200, Municipio V80, Departamento V80, Telefono V15, HorarioAtencion V100, Estado V20 | — | Activo / Inactivo |
| Usuario | CodigoUsuario, CodigoSucursal INT, NombreCompleto V150, NombreUsuario V50, Contrasena V100, Rol V30, Estado V20 | FK Sucursal · UNIQUE NombreUsuario | Activo / Inactivo (Rol: Administrador / Operador / Optometrista) |
| Cliente | CodigoCliente, Nombres V100, Apellidos V100, DPI V13, FechaNacimiento DATE, Telefono V15, Correo V100 (N), Direccion V200 (N), Estado V20 | UNIQUE DPI | Activo / Inactivo |
| Optometrista | CodigoOptometrista, Nombres V100, Apellidos V100, NumeroColegiado V20, Telefono V15, Correo V100, Estado V20 | UNIQUE NumeroColegiado | Activo / Inactivo |
| Cita | CodigoCita, CodigoCliente INT, CodigoSucursal INT, CodigoOptometrista INT, Fecha DATE, Hora TIME, MotivoConsulta V200, Estado V20 | FK Cliente, Sucursal, Optometrista | Programada / Atendida / Cancelada |
| ExamenVisual | CodigoExamen, CodigoCliente INT, CodigoOptometrista INT, CodigoCita INT (N), Fecha DATE, Observaciones V300 (N), ResultadoGeneral V200, Estado V20 | FK Cliente, Optometrista, Cita | Pendiente / Realizado / Anulado |
| Receta | CodigoReceta, CodigoExamen INT, EsferaOD N(5,2), CilindroOD N(5,2), EjeOD INT, EsferaOI N(5,2), CilindroOI N(5,2), EjeOI INT, Adicion N(4,2), DistanciaPupilar N(4,1), FechaEmision DATE, Observaciones V300 (N), Estado V20 | FK ExamenVisual | Vigente / Vencida / Anulada |
| TipoProducto | CodigoTipoProducto, Nombre V80, Descripcion V200, Estado V20 | — | Activo / Inactivo |
| ProductoOptico | CodigoProducto, CodigoTipoProducto INT, Nombre V100, Descripcion V200, Marca V60, Precio N(10,2), Estado V20 | FK TipoProducto | Activo / Inactivo |
| Orden | CodigoOrden, CodigoCliente INT, CodigoSucursal INT, Fecha DATE, Estado V20 | FK Cliente, Sucursal | En proceso / Lista / Entregada / Anulada |
| DetalleOrden | CodigoDetalle, CodigoOrden INT, CodigoProducto INT, Cantidad INT, PrecioUnitario N(10,2), Subtotal N(10,2) | FK Orden, ProductoOptico | (no tiene) |
| Entrega | CodigoEntrega, CodigoOrden INT, FechaEntrega DATE, NombreRecibe V150, Observaciones V300 (N), Estado V20 | FK Orden | Pendiente / Entregada |

**Tablas usadas por otras (para el mensaje de "no se puede eliminar"):** Sucursal (Usuario, Cita, Orden),
Cliente (Cita, ExamenVisual, Orden), Optometrista (Cita, ExamenVisual), Cita (ExamenVisual),
ExamenVisual (Receta), TipoProducto (ProductoOptico), ProductoOptico (DetalleOrden), Orden (DetalleOrden, Entrega).

**Qué mostrar en el ComboBox cuando otra tabla apunta a esta (DisplayMember):**
Sucursal → `Nombre` · Cliente → `NombreCompleto`* · Optometrista → `NombreCompleto`* ·
Cita → `Descripcion`* · ExamenVisual → `Descripcion`* · TipoProducto → `Nombre` ·
ProductoOptico → `Nombre` · Orden → `Descripcion`* (*propiedad de solo lectura: `04_CAPA_ENTIDAD.md`, sección 3).

## 2. Tipos SQL → C#

| SQL | C# | Leer del SqlDataReader | Valor inicial | Leer del control |
|---|---|---|---|---|
| INT | `int` | `Convert.ToInt32(rd["X"])` | `0` | `Convert.ToInt32(nudX.Value)` / `Convert.ToInt32(cboX.SelectedValue)` |
| INT NULL (FK opcional) | `int` (0 = sin valor) | `rd["X"] == DBNull.Value ? 0 : Convert.ToInt32(rd["X"])` | `0` | `Convert.ToInt32(cboX.SelectedValue)` |
| VARCHAR | `string` | `rd["X"].ToString()` (NULL queda "") | `string.Empty` | `txtX.Text.Trim()` / `cboX.Text` |
| DATE | `DateTime` | `Convert.ToDateTime(rd["X"])` | `DateTime.Now.Date` | `dtpX.Value.Date` |
| TIME | `TimeSpan` | `(TimeSpan)rd["X"]` | `DateTime.Now.TimeOfDay` | `new TimeSpan(dtpX.Value.Hour, dtpX.Value.Minute, 0)` |
| NUMERIC | `decimal` | `Convert.ToDecimal(rd["X"])` | `0` | `nudX.Value` |
| BIT | `bool` | `Convert.ToBoolean(rd["X"])` | `true` | `chkX.Checked` |
