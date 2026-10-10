# 00 · Contexto del proyecto

> **Úsalo siempre** (leerlo primero). Datos generales del Sistema Optica, estructura de
> carpetas, integrantes, pantallas que ya existen, colores, nombres que se usan en todas las
> plantillas y estilo de código.

## 1. Datos del proyecto

| Dato | Valor |
|---|---|
| Carpeta raíz | `ProyectoFinal_SistemaOptica/` (en `C:\Users\rephot\Desktop\Proyecto Final Julio\`) |
| Solución | `src/Sistema Optica.slnx` |
| Capas (proyectos) | `src/Entidad/`, `src/Datos/`, `src/Negocio/`, `src/Presentacion/` (namespace = nombre de la carpeta) |
| Ejecutable | `Presentacion` → `SistemaOptica.exe` (debe ser el **proyecto de inicio** en Visual Studio) |
| Framework | .NET Framework 4.8, Windows Forms, proyectos estilo antiguo (`packages.config`) |
| Librerías | FontAwesome.Sharp 6.6.0 (IconButton, IconPictureBox), System.Data.SqlClient 4.9.1, System.Configuration.ConfigurationManager 10.0.12 |
| Base de datos | SQL Server, BD `OpticaGrupo8`. Creación: `database/scripts/1_Script_Creacion_BD_SQLServer.sql`. Datos de prueba: `database/data/2_Script_Datos_Prueba_SQLServer.sql` (también están las versiones PostgreSQL) |
| Conexión | `src/Presentacion/App.config` → cadena `ConexionSQLServer` (SQL Server en Docker, contenedor `sql_prog2a`); se lee en `src/Datos/ConexionBaseDatos.cs` con `MtdObtenerDatos()`. Ahí mismo están comentadas `ConexionPostgreSQL` (Docker) y `ConexionSupabase` (necesitan Npgsql) |
| Imágenes | `src/Presentacion/Resources/` → `Logo.png` (círculo con lentes, encabezado de las pantallas CRUD), `logoicono.png` (ícono del ojo, arriba del menú principal → recurso `LogoIcono`), `LogoTranslucido.png` (texto del logo sin el ojo al 25 %, Dashboard), `LogoOptica.png` (logo completo recortado, ya no se usa) y `logo_original.png` (original). Se usan con `global::Presentacion.Properties.Resources.Nombre` |
| Exportar/Imprimir | `src/Presentacion/UtilidadesGrid.cs` → `MtdExportar(dgv, nombre)` y `MtdImprimir(dgv, titulo)` |
| Diagramas | `docs/diagrams/` (conceptual y entidad-relación) |
| Enunciado del proyecto | `docs/guides/Proyecto Final Grupo 8.docx` |
| Ejemplo original | `..\Sistema Veterinaria\` (fuera del proyecto: FrmCitass, CitasEntidad, CitasDatos, CitasNegocio) |

**Estructura de carpetas (la pide el curso):**

```
ProyectoFinal_SistemaOptica\
├── database\  scripts\ (creación) · data\ (datos de prueba) · backups\
├── docs\      diagrams\ · guides\
├── ia\        skills\crear-pantalla\ (estos archivos de parametrización)
├── src\       solución de Visual Studio (Entidad, Datos, Negocio, Presentacion)
├── AGENTS.md  reglas para el agente de IA
├── MEMORY.md  memoria del proyecto (decisiones y avances)
├── .gitignore
└── README.md
```

**IMPORTANTE (.csproj):** los proyectos son estilo antiguo. Cada archivo nuevo debe
agregarse a mano al `.csproj` de su capa o no se compila (cada archivo indica qué línea agregar).

**Integrantes y módulos (Grupo 8):**

| Integrante | Carné | Módulos | Componente |
|---|---|---|---|
| Docente + Grupo | — | Sucursales | CRUD patrón + Agente IA |
| Diego José Velásquez González | 1590-24-9994 | Usuarios · Clientes · Citas | Login |
| Luis Alfredo Ruano Dealtán | 1590-22-5860 | Tipos de Producto · Productos Ópticos · Órdenes | Panel de Acceso |
| **Julio César Aguilar Tije (usuario)** | 1590-24-20986 | **Optometristas · Exámenes Visuales · Recetas** | **Dashboard** |

**Pantallas ya hechas (usarlas como referencia viva):**

| Formulario | Estado | Sirve de ejemplo para |
|---|---|---|
| `FrmOptometrista` | diseño + lógica | TextBox, RadioButton Activo/Inactivo, UNIQUE (colegiado) y FK al eliminar |
| `FrmExamenVisual` | diseño + lógica | ComboBox de FK (Cliente, Optometrista, Cita), FK opcional (0 = NULL, Supr la quita), fecha, multilínea, estado en ComboBox |
| `FrmReceta` | diseño + lógica | NumericUpDown decimal/entero (con try/catch en CellClick), columnas con formato N2/N1 |
| `FrmDashboard` | solo diseño | Bienvenida: texto del logo translúcido (sin el ojo) + "Bienvenidos" (`03_DISENO_DASHBOARD.md`, Diseño A); se abre con el botón **Inicio** del menú |
| `FrmPrincipal` | diseño + navegación | Ventana principal: menú lateral, barra de título y panel contenedor (`09_DISENO_MENU_PRINCIPAL.md`) |

`Program.cs` inicia temporalmente en `FrmPrincipal` hasta que exista el Login.
Todas las pantallas se abren **dentro** del panel contenedor de `FrmPrincipal`.

## 2. Colores del sistema (salen del logo de la empresa) — usar siempre estos

| Uso | Color (R,G,B) | En el Designer |
|---|---|---|
| Marino (fondo del menú lateral, títulos, líneas de marca, encabezado del grid, íconos principales) | 3, 47, 103 | `System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(47)))), ((int)(((byte)(103)))))` |
| Gris del logo (botón seleccionado del menú) | 101, 114, 122 | `…FromArgb(… 101 … 114 … 122 …)` |
| Azul del iris del logo (botón del menú al pasar el mouse) | 2, 66, 125 | `…FromArgb(… 2 … 66 … 125 …)` |
| Marino oscuro (panel de usuario del menú) | 2, 34, 77 | `…FromArgb(… 2 … 34 … 77 …)` |
| Gris de íconos de la barra de título | 73, 85, 98 | `…FromArgb(… 73 … 85 … 98 …)` |
| Fondo de las pantallas | 253, 252, 250 | `…FromArgb(… 253 … 252 … 250 …)` |
| Filas alternas del grid | 238, 241, 244 | `…FromArgb(… 238 … 241 … 244 …)` |
| Línea bajo la barra de título | 225, 228, 232 | `…FromArgb(… 225 … 228 … 232 …)` |
| Texto sobre gris o marino | Blanco | `System.Drawing.Color.White` |
| Íconos de acciones | SeaGreen (guardar/exportar), DarkOrange (editar), Firebrick (eliminar/cerrar), DimGray (cancelar/limpiar) | colores con nombre |

## 3. Flujo entre capas

Flujo: **Presentación → Negocio → Datos → Base de datos**, la Entidad viaja entre capas.
Presentación **nunca** usa `SqlConnection` ni la capa Datos directamente.

## 4. Nombres y marcadores que usan todas las plantillas

Nombres: `{Tabla}` = nombre de la tabla tal cual (`Optometrista`, `ExamenVisual`, `Receta`);
`{tabla}` = la misma en camelCase (`optometrista`, `examenVisual`); `{PK}` = la columna PK real
(`CodigoOptometrista`, `CodigoExamen`, `CodigoReceta`); `{pk}` = PK en camelCase.
Campos privados: `_` + camelCase (`_numeroColegiado`); siglas completas en minúscula (`DPI` → `_dpi`).

## 5. Estilo de código (obligatorio)

- Código estilo **programador junior**: sencillo, con los comentarios de bloque
  `// =====` igual que el ejemplo, nombres en español, nada de LINQ ni trucos avanzados.
- Métodos con prefijo `Mtd` (`MtdConsultar`, `MtdLimpiar`), errores con `try/catch` y `MessageBox`.
- Archivos `.cs` guardados en UTF-8 con BOM (como Visual Studio).
