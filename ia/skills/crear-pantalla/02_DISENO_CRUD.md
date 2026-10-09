# 02 · Diseño de pantalla CRUD (mantenimiento)

> **Úsalo para el diseño** de cualquier pantalla de mantenimiento con pestañas
> *Consultar* y *Gestionar* (Optometristas, Clientes, Recetas, etc.).
> Solo diseño: Designer + `.cs` con el constructor. La lógica va en `07_LOGICA_FORMULARIO.md`.
> Ejemplos vivos: `FrmOptometrista`, `FrmExamenVisual`, `FrmReceta` (en `src/Presentacion/`).
> Las pantallas se abren dentro del menú principal: al crear una, conectar su botón del menú
> como dice `09_DISENO_MENU_PRINCIPAL.md` (sección 4). Colores: `00_CONTEXTO_PROYECTO.md`.

## 1. Archivos y registro en el .csproj

Por cada pantalla `Frm{Tabla}` (ej. `FrmOptometrista`, `FrmExamenVisual`):

- `Presentacion/Frm{Tabla}.cs` → clase `public partial class Frm{Tabla} : Form`
- `Presentacion/Frm{Tabla}.Designer.cs` → todo el diseño (`InitializeComponent`)
- No hace falta `.resx` (el logo sale de `Properties.Resources`).

Agregar dentro del `<ItemGroup>` de los `Compile` en `Presentacion/Presentacion.csproj`
(en orden alfabético, como los demás):

```xml
    <Compile Include="Frm{Tabla}.cs">
      <SubType>Form</SubType>
    </Compile>
    <Compile Include="Frm{Tabla}.Designer.cs">
      <DependentUpon>Frm{Tabla}.cs</DependentUpon>
    </Compile>
```

## 2. Estructura de la pantalla CRUD (igual en todas)

Formulario de `1279 x 872` con un `TabControl` (`tabControl1`) y dos pestañas:

```
Frm{Tabla}  (ClientSize 1279x872, AutoScaleDimensions 9F,20F, StartPosition CenterScreen)
└── tabControl1 (Dock Fill)
    ├── tabPage1 "Consultar"
    │   └── PanelPrincipal (Dock Fill, BackColor Fondo (253,252,250), 1265x833)
    │       ├── PanelEncabezado    Top 100   → picLogo, lblTitulo, lblSubtitulo
    │       ├── PanelDivisor1      Top 5     → BackColor Marino (3,47,103) (línea de marca)
    │       ├── PanelFiltros       Top 100   → lblBuscar, txtBuscador, btnBuscar, btnLimpiarBusqueda
    │       ├── PanelDivisor2      Top 5
    │       ├── PanelCheck         Top 74    → chkSeleccionar, btnExportar, btnImprimir
    │       ├── PanelDivisor3      Top 5
    │       ├── PanelCentral       Fill      → dgv{Tabla} (Padding 20,0,20,0)
    │       ├── PanelDivisor4      Bottom 5
    │       └── PanelInferior      Bottom 100 → lblTotalRegistros, btnCerrar
    └── tabPage2 "Gestionar"
        └── PanelPrincipalGestionar (Dock Fill, BackColor Fondo (253,252,250))
            ├── PanelEncabezadoGestionar Top 100 → picLogoGestionar, lblTituloGestionar, lblSubtituloGestionar
            ├── PanelDivisor5            Top 5   → BackColor Marino (3,47,103)
            ├── PanelCentralGestionar    Fill    → grpDatos (Dock Fill, Padding 20,10,20,10)
            ├── PanelDivisor7            Bottom 5
            ├── PanelAcciones            Bottom 100 → btnNuevo, btnGuardar, btnCancelar, btnEditar, btnEliminar, btnLimpiar
            ├── PanelDivisor6            Bottom 5
            └── PanelInferiorGestionar   Bottom 100 → btnCerrarGestionar
```

**Orden de `Controls.Add` (importante para el Dock):** el panel `Fill` se agrega **primero**,
luego los de abajo y por último los de arriba (de adentro hacia afuera). Así el panel
central no queda tapado (error que tenía el ejemplo de la Veterinaria):

- PanelPrincipal: `PanelCentral, PanelDivisor4, PanelInferior, PanelDivisor3, PanelCheck, PanelDivisor2, PanelFiltros, PanelDivisor1, PanelEncabezado`
- PanelPrincipalGestionar: `PanelCentralGestionar, PanelDivisor7, PanelAcciones, PanelDivisor6, PanelInferiorGestionar, PanelDivisor5, PanelEncabezadoGestionar`

**Textos fijos:**
- `lblTitulo` / `lblTituloGestionar`: `Ópticas Visión Guatemala` (22F, Marino (3,47,103))
- `lblSubtitulo` / `lblSubtituloGestionar`: `Control y Gestión de {Módulo en plural}` (12F)
- `lblBuscar`: `Buscar por código:` · `chkSeleccionar`: `Seleccionar` · `lblTotalRegistros`: `Total Registros: 0`
- `grpDatos.Text`: `Datos del {entidad}:` / `Datos de la {entidad}:` (12F, ForeColor Marino (3,47,103); sus labels en Black)
- `this.Text` del formulario: módulo en plural (`Optometristas`, `Exámenes Visuales`, `Recetas`)

## 3. Nombres de controles

| Control | Prefijo | Ejemplo |
|---|---|---|
| Label | `lbl` | `lblNombres` |
| TextBox | `txt` | `txtNombres`, `txtCodigoOptometrista` |
| ComboBox | `cbo` | `cboCliente` (FK), `cboEstado` |
| DateTimePicker | `dtp` | `dtpFecha`, `dtpHora` |
| NumericUpDown | `nud` | `nudPrecio`, `nudEjeOD` |
| RadioButton | `rdb` | `rdbActivo`, `rdbInactivo` |
| CheckBox | `chk` | `chkSeleccionar` |
| DataGridView | `dgv` | `dgv{Tabla}` (ej. `dgvReceta`) |
| Columna del grid | `col` | `col{Campo}` (ej. `colFechaEmision`) |
| Botón (IconButton) | `btn` | `btnGuardar` |
| GroupBox | `grp` | `grpDatos` |
| Panel | `Panel`/`pnl` | `PanelCentral`, `pnlTarjetaClientes` |
| PictureBox | `pic` | `picLogo` |

Para una FK el control se llama como la tabla relacionada sin "Codigo":
`CodigoCliente` → `cboCliente` / `lblCliente`; `CodigoExamen` → `cboExamen`.

## 4. Tipo de campo → control

| Campo en la tabla | Control | Propiedades clave |
|---|---|---|
| PK `INT IDENTITY` | TextBox `txtCodigo…` | `Enabled = false`, `ReadOnly = true`, `TabStop = false` |
| FK `INT` | ComboBox `cbo{TablaFK}` | `DropDownStyle = DropDownList` (se llena en la lógica). Si permite NULL, label `(opcional)` |
| `VARCHAR(n)` normal | TextBox | `MaxLength = n` |
| `VARCHAR(300)` o más (Observaciones) | TextBox multilínea | `Multiline = true`, `ScrollBars = Vertical`, `Size 280x95`, `MaxLength = n`. Va al **final** de la columna derecha (ocupa 2 filas) |
| Contraseña | TextBox | `UseSystemPasswordChar = true` |
| `DATE` | DateTimePicker | `Format = Custom`, `CustomFormat = "dd/MM/yyyy"` |
| `TIME` | DateTimePicker | `Format = Time`, `ShowUpDown = true` |
| `NUMERIC(p,s)` | NumericUpDown | `DecimalPlaces = s`, `Increment`, `Minimum`, `Maximum` (ver sección 8) |
| `INT` que no es FK (Cantidad, Eje) | NumericUpDown | `DecimalPlaces = 0`, `Maximum` según el negocio |
| `Estado` Activo/Inactivo | 2 RadioButton | `rdbActivo` (`Checked = true`) y `rdbInactivo` |
| `Estado` con otros valores / listas fijas (Rol) | ComboBox | `DropDownList` + `Items.AddRange(...)` con los valores de `01_BASE_DE_DATOS.md` |

## 5. Distribución de los campos dentro de `grpDatos`

`grpDatos` mide 1225x498. Dos columnas, filas cada 60 px:

| | Label X | Control X | Ancho control |
|---|---|---|---|
| Columna izquierda | 30 | 330 | 280 |
| Columna derecha | 650 | 920 | 280 |

- Fila `i` (0, 1, 2…): control en `Y = 45 + 60*i`; label en `Y = 48 + 60*i`
  (Y de controles: 45, 105, 165, 225, 285, 345, 405 · Y de labels: 48, 108, 168, 228, 288, 348, 408).
- Máximo **7 filas** por columna. El multilínea (95 de alto) ocupa 2 filas y debe empezar
  como máximo en la fila 5 (Y 345).
- Orden: el PK siempre va primero a la izquierda. Se llena primero la columna izquierda con
  la mitad de los campos (redondeando hacia arriba) y el resto a la derecha, respetando el
  orden de la tabla; el multilínea se mueve al final. Se permite reacomodar para que campos
  relacionados queden a la par (ej. Receta: OD a la izquierda y OI a la derecha, misma fila).
- `TabIndex` en el orden en que el usuario debe llenar los datos.
- Labels: `AutoSize = true`, texto legible con tildes y dos puntos (`Número de colegiado:`),
  máximo ~21 caracteres para que no choquen con el control.
- Tamaños de referencia (12F): TextBox/DateTimePicker/NumericUpDown alto 35, ComboBox alto 37,
  RadioButton/Label alto 29–33.

Ejemplo real de **FrmReceta**:

| Fila | Izquierda | Derecha |
|---|---|---|
| 0 | Código receta (txt) | Examen visual (cbo FK) |
| 1 | Esfera OD (nud) | Esfera OI (nud) |
| 2 | Cilindro OD (nud) | Cilindro OI (nud) |
| 3 | Eje OD (nud) | Eje OI (nud) |
| 4 | Adición (nud) | Distancia pupilar (nud) |
| 5 | Fecha emisión (dtp) | Observaciones (multilínea, filas 5-6) |
| 6 | Estado (cbo) | |

## 6. Columnas del DataGridView

Una columna `DataGridViewTextBoxColumn` por cada campo de la tabla, en el mismo orden:

- `Name = "col{Campo}"`, `DataPropertyName = "{Campo}"` (igual que la propiedad de la Entidad),
  `HeaderText` legible (`Código`, `No. colegiado`, `Cód. cliente`, `Fecha emisión`), `ReadOnly = true`.
- PK: `HeaderText = "Código"`, `FillWeight = 60F`. FK: `Cód. {tabla}`, `FillWeight = 70F`.
  Textos largos (Correo, Observaciones, Resultado): `FillWeight = 140F–150F`. Estado: `70F`.
- `DATE` → estilo con `Format = "dd/MM/yyyy"`.
- `NUMERIC` → estilo con `Format = "N2"` (o `"N1"` si tiene 1 decimal) y `Alignment = MiddleRight`.
- `INT` que no es FK → estilo con `Alignment = MiddleRight`.
- Cada columna con formato usa **su propio** `dataGridViewCellStyleN` (3, 4, 5…), declarado al
  inicio de `InitializeComponent`. Los estilos 1 y 2 ya están ocupados (filas alternas y encabezado).

Propiedades fijas del grid (ya están en la plantilla): sin filas nuevas, solo lectura,
`FullRowSelect`, `MultiSelect = false`, `RowHeadersVisible = false`, columnas `Fill`,
encabezado Marino (3,47,103) con letra blanca en negrita 10F, filas alternas gris claro (238,241,244), fuente 10F.

## 7. Botones (FontAwesome.Sharp.IconButton)

Todos: `Font 12F`, `IconFont Auto`, `IconSize 28`, `Size 150x45`,
`TextImageRelation = ImageBeforeText`, `UseVisualStyleBackColor = true`.

| Botón | Texto | IconChar | IconColor | Panel | Location | Anchor |
|---|---|---|---|---|---|---|
| btnBuscar | Buscar | MagnifyingGlass | Marino | PanelFiltros | 575, 28 | — |
| btnLimpiarBusqueda | Limpiar | Eraser | DimGray | PanelFiltros | 745, 28 | — |
| btnExportar | Exportar | FileExport | SeaGreen | PanelCheck | 925, 15 | Top, Right |
| btnImprimir | Imprimir | Print | Marino | PanelCheck | 1095, 15 | Top, Right |
| btnCerrar | Cerrar | RightFromBracket | Firebrick | PanelInferior | 1095, 28 | Top, Right |
| btnNuevo | Nuevo | Plus | Marino | PanelAcciones | 45, 28 | — |
| btnGuardar | Guardar | FloppyDisk | SeaGreen | PanelAcciones | 250, 28 | — |
| btnCancelar | Cancelar | Ban | DimGray | PanelAcciones | 455, 28 | — |
| btnEditar | Editar | PenToSquare | DarkOrange | PanelAcciones | 660, 28 | — |
| btnEliminar | Eliminar | TrashCan | Firebrick | PanelAcciones | 865, 28 | — |
| btnLimpiar | Limpiar | Broom | DimGray | PanelAcciones | 1070, 28 | — |
| btnCerrarGestionar | Cerrar | RightFromBracket | Firebrick | PanelInferiorGestionar | 1095, 28 | Top, Right |

Otros fijos: `lblBuscar (20,36)`, `txtBuscador (250,33) 300x35 MaxLength 10`,
`chkSeleccionar (20,21)`, `lblTotalRegistros (20,36)`, `picLogo (20,10) 80x80 Zoom`,
`lblTitulo (115,8)`, `lblSubtitulo (121,62)`.

## 8. Valores decimales en el Designer

El Designer escribe los `decimal` así: `new decimal(new int[] { valorSinPunto, 0, 0, banderas })`
donde `banderas = decimales * 65536` y se usa `-2147483648` si el número es negativo.

| Valor | Código |
|---|---|
| 0.25 | `new decimal(new int[] { 25, 0, 0, 131072})` |
| 0.5 | `new decimal(new int[] { 5, 0, 0, 65536})` |
| 0.01 | `new decimal(new int[] { 1, 0, 0, 131072})` |
| 4 | `new decimal(new int[] { 4, 0, 0, 0})` |
| 80 | `new decimal(new int[] { 80, 0, 0, 0})` |
| 180 | `new decimal(new int[] { 180, 0, 0, 0})` |
| 100000 | `new decimal(new int[] { 100000, 0, 0, 0})` |
| -10 | `new decimal(new int[] { 10, 0, 0, -2147483648})` |
| -30 | `new decimal(new int[] { 30, 0, 0, -2147483648})` |

Rangos usados en Receta: Esfera −30 a 30 (paso 0.25), Cilindro −10 a 10 (paso 0.25),
Eje 0 a 180, Adición 0 a 4 (paso 0.25), Distancia pupilar 0 a 80 (1 decimal, paso 0.5).
Precio: 0 a 100000, 2 decimales. Cantidad: 0 a 1000. El `Minimum` siempre ≤ 0 para que el
valor inicial 0 sea válido; los mínimos reales se validan en Negocio.

## 9. Plantilla del Designer

Copiar esta plantilla y llenar las marcas `[D1]…[D10]`. Las partes fijas no se tocan.
Reemplazar: `{Tabla}` (ej. `Receta`), `{SUBTITULO}` (ej. `Control y Gestión de Recetas`),
`{GRUPO}` (ej. `Datos de la receta:`), `{TITULO_VENTANA}` (ej. `Recetas`).

**Bloques por marca:**

- `[D1]` estilos extra de columnas: `System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();` (uno por columna con formato).
- `[D2]` `this.col{Campo} = new System.Windows.Forms.DataGridViewTextBoxColumn();` por cada campo.
- `[D3]` `this.lbl… = new System.Windows.Forms.Label();` y el control de cada campo (`TextBox`, `ComboBox`, `DateTimePicker`, `NumericUpDown`, `RadioButton`).
- `[D4]` `((System.ComponentModel.ISupportInitialize)(this.nud…)).BeginInit();` por cada NumericUpDown.
- `[D5]` lista de columnas: `this.col{Campo1},` … `this.col{CampoN}});`
- `[D6]` bloque de cada columna (ver abajo).
- `[D7]` `this.grpDatos.Controls.Add(this.lbl…);` y `this.grpDatos.Controls.Add(this.ctrl…);` por cada campo.
- `[D8]` bloque de cada label y control (ver abajo).
- `[D9]` `((System.ComponentModel.ISupportInitialize)(this.nud…)).EndInit();` por cada NumericUpDown.
- `[D10]` declaraciones: `private System.Windows.Forms.DataGridViewTextBoxColumn col{Campo};`, `private System.Windows.Forms.Label lbl…;`, `private System.Windows.Forms.TextBox txt…;` etc.

```csharp
namespace Presentacion
{
    partial class Frm{Tabla}
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            // [D1]
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.PanelPrincipal = new System.Windows.Forms.Panel();
            this.PanelCentral = new System.Windows.Forms.Panel();
            this.dgv{Tabla} = new System.Windows.Forms.DataGridView();
            // [D2]
            this.PanelDivisor4 = new System.Windows.Forms.Panel();
            this.PanelInferior = new System.Windows.Forms.Panel();
            this.lblTotalRegistros = new System.Windows.Forms.Label();
            this.btnCerrar = new FontAwesome.Sharp.IconButton();
            this.PanelDivisor3 = new System.Windows.Forms.Panel();
            this.PanelCheck = new System.Windows.Forms.Panel();
            this.chkSeleccionar = new System.Windows.Forms.CheckBox();
            this.btnExportar = new FontAwesome.Sharp.IconButton();
            this.btnImprimir = new FontAwesome.Sharp.IconButton();
            this.PanelDivisor2 = new System.Windows.Forms.Panel();
            this.PanelFiltros = new System.Windows.Forms.Panel();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscador = new System.Windows.Forms.TextBox();
            this.btnBuscar = new FontAwesome.Sharp.IconButton();
            this.btnLimpiarBusqueda = new FontAwesome.Sharp.IconButton();
            this.PanelDivisor1 = new System.Windows.Forms.Panel();
            this.PanelEncabezado = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.PanelPrincipalGestionar = new System.Windows.Forms.Panel();
            this.PanelCentralGestionar = new System.Windows.Forms.Panel();
            this.grpDatos = new System.Windows.Forms.GroupBox();
            // [D3]
            this.PanelDivisor7 = new System.Windows.Forms.Panel();
            this.PanelAcciones = new System.Windows.Forms.Panel();
            this.btnNuevo = new FontAwesome.Sharp.IconButton();
            this.btnGuardar = new FontAwesome.Sharp.IconButton();
            this.btnCancelar = new FontAwesome.Sharp.IconButton();
            this.btnEditar = new FontAwesome.Sharp.IconButton();
            this.btnEliminar = new FontAwesome.Sharp.IconButton();
            this.btnLimpiar = new FontAwesome.Sharp.IconButton();
            this.PanelDivisor6 = new System.Windows.Forms.Panel();
            this.PanelInferiorGestionar = new System.Windows.Forms.Panel();
            this.btnCerrarGestionar = new FontAwesome.Sharp.IconButton();
            this.PanelDivisor5 = new System.Windows.Forms.Panel();
            this.PanelEncabezadoGestionar = new System.Windows.Forms.Panel();
            this.picLogoGestionar = new System.Windows.Forms.PictureBox();
            this.lblTituloGestionar = new System.Windows.Forms.Label();
            this.lblSubtituloGestionar = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.PanelPrincipal.SuspendLayout();
            this.PanelCentral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv{Tabla})).BeginInit();
            this.PanelInferior.SuspendLayout();
            this.PanelCheck.SuspendLayout();
            this.PanelFiltros.SuspendLayout();
            this.PanelEncabezado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.PanelPrincipalGestionar.SuspendLayout();
            this.PanelCentralGestionar.SuspendLayout();
            this.grpDatos.SuspendLayout();
            // [D4]
            this.PanelAcciones.SuspendLayout();
            this.PanelInferiorGestionar.SuspendLayout();
            this.PanelEncabezadoGestionar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoGestionar)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1279, 872);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.PanelPrincipal);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1271, 839);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Consultar";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // PanelPrincipal
            // 
            this.PanelPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.PanelPrincipal.Controls.Add(this.PanelCentral);
            this.PanelPrincipal.Controls.Add(this.PanelDivisor4);
            this.PanelPrincipal.Controls.Add(this.PanelInferior);
            this.PanelPrincipal.Controls.Add(this.PanelDivisor3);
            this.PanelPrincipal.Controls.Add(this.PanelCheck);
            this.PanelPrincipal.Controls.Add(this.PanelDivisor2);
            this.PanelPrincipal.Controls.Add(this.PanelFiltros);
            this.PanelPrincipal.Controls.Add(this.PanelDivisor1);
            this.PanelPrincipal.Controls.Add(this.PanelEncabezado);
            this.PanelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelPrincipal.Location = new System.Drawing.Point(3, 3);
            this.PanelPrincipal.Name = "PanelPrincipal";
            this.PanelPrincipal.Size = new System.Drawing.Size(1265, 833);
            this.PanelPrincipal.TabIndex = 0;
            // 
            // PanelCentral
            // 
            this.PanelCentral.Controls.Add(this.dgv{Tabla});
            this.PanelCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelCentral.Location = new System.Drawing.Point(0, 289);
            this.PanelCentral.Name = "PanelCentral";
            this.PanelCentral.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.PanelCentral.Size = new System.Drawing.Size(1265, 439);
            this.PanelCentral.TabIndex = 6;
            // 
            // dgv{Tabla}
            // 
            this.dgv{Tabla}.AllowUserToAddRows = false;
            this.dgv{Tabla}.AllowUserToDeleteRows = false;
            this.dgv{Tabla}.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(244)))));
            this.dgv{Tabla}.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv{Tabla}.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv{Tabla}.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(47)))), ((int)(((byte)(103)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(47)))), ((int)(((byte)(103)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv{Tabla}.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv{Tabla}.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv{Tabla}.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            // [D5]
            this.dgv{Tabla}.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv{Tabla}.EnableHeadersVisualStyles = false;
            this.dgv{Tabla}.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dgv{Tabla}.Location = new System.Drawing.Point(20, 0);
            this.dgv{Tabla}.MultiSelect = false;
            this.dgv{Tabla}.Name = "dgv{Tabla}";
            this.dgv{Tabla}.ReadOnly = true;
            this.dgv{Tabla}.RowHeadersVisible = false;
            this.dgv{Tabla}.RowHeadersWidth = 62;
            this.dgv{Tabla}.RowTemplate.Height = 28;
            this.dgv{Tabla}.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv{Tabla}.Size = new System.Drawing.Size(1225, 439);
            this.dgv{Tabla}.TabIndex = 0;
            // [D6]
            // 
            // PanelDivisor4
            // 
            this.PanelDivisor4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelDivisor4.Location = new System.Drawing.Point(0, 728);
            this.PanelDivisor4.Name = "PanelDivisor4";
            this.PanelDivisor4.Size = new System.Drawing.Size(1265, 5);
            this.PanelDivisor4.TabIndex = 8;
            // 
            // PanelInferior
            // 
            this.PanelInferior.Controls.Add(this.lblTotalRegistros);
            this.PanelInferior.Controls.Add(this.btnCerrar);
            this.PanelInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelInferior.Location = new System.Drawing.Point(0, 733);
            this.PanelInferior.Name = "PanelInferior";
            this.PanelInferior.Size = new System.Drawing.Size(1265, 100);
            this.PanelInferior.TabIndex = 7;
            // 
            // lblTotalRegistros
            // 
            this.lblTotalRegistros.AutoSize = true;
            this.lblTotalRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblTotalRegistros.Location = new System.Drawing.Point(20, 36);
            this.lblTotalRegistros.Name = "lblTotalRegistros";
            this.lblTotalRegistros.Size = new System.Drawing.Size(203, 29);
            this.lblTotalRegistros.TabIndex = 0;
            this.lblTotalRegistros.Text = "Total Registros: 0";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCerrar.IconChar = FontAwesome.Sharp.IconChar.RightFromBracket;
            this.btnCerrar.IconColor = System.Drawing.Color.Firebrick;
            this.btnCerrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCerrar.IconSize = 28;
            this.btnCerrar.Location = new System.Drawing.Point(1095, 28);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(150, 45);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // PanelDivisor3
            // 
            this.PanelDivisor3.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelDivisor3.Location = new System.Drawing.Point(0, 284);
            this.PanelDivisor3.Name = "PanelDivisor3";
            this.PanelDivisor3.Size = new System.Drawing.Size(1265, 5);
            this.PanelDivisor3.TabIndex = 5;
            // 
            // PanelCheck
            // 
            this.PanelCheck.Controls.Add(this.chkSeleccionar);
            this.PanelCheck.Controls.Add(this.btnExportar);
            this.PanelCheck.Controls.Add(this.btnImprimir);
            this.PanelCheck.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelCheck.Location = new System.Drawing.Point(0, 210);
            this.PanelCheck.Name = "PanelCheck";
            this.PanelCheck.Size = new System.Drawing.Size(1265, 74);
            this.PanelCheck.TabIndex = 4;
            // 
            // chkSeleccionar
            // 
            this.chkSeleccionar.AutoSize = true;
            this.chkSeleccionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.chkSeleccionar.Location = new System.Drawing.Point(20, 21);
            this.chkSeleccionar.Name = "chkSeleccionar";
            this.chkSeleccionar.Size = new System.Drawing.Size(155, 33);
            this.chkSeleccionar.TabIndex = 0;
            this.chkSeleccionar.Text = "Seleccionar";
            this.chkSeleccionar.UseVisualStyleBackColor = true;
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnExportar.IconChar = FontAwesome.Sharp.IconChar.FileExport;
            this.btnExportar.IconColor = System.Drawing.Color.SeaGreen;
            this.btnExportar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExportar.IconSize = 28;
            this.btnExportar.Location = new System.Drawing.Point(925, 15);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(150, 45);
            this.btnExportar.TabIndex = 1;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportar.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnImprimir.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.btnImprimir.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(47)))), ((int)(((byte)(103)))));
            this.btnImprimir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnImprimir.IconSize = 28;
            this.btnImprimir.Location = new System.Drawing.Point(1095, 15);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(150, 45);
            this.btnImprimir.TabIndex = 2;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // PanelDivisor2
            // 
            this.PanelDivisor2.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelDivisor2.Location = new System.Drawing.Point(0, 205);
            this.PanelDivisor2.Name = "PanelDivisor2";
            this.PanelDivisor2.Size = new System.Drawing.Size(1265, 5);
            this.PanelDivisor2.TabIndex = 3;
            // 
            // PanelFiltros
            // 
            this.PanelFiltros.Controls.Add(this.lblBuscar);
            this.PanelFiltros.Controls.Add(this.txtBuscador);
            this.PanelFiltros.Controls.Add(this.btnBuscar);
            this.PanelFiltros.Controls.Add(this.btnLimpiarBusqueda);
            this.PanelFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelFiltros.Location = new System.Drawing.Point(0, 105);
            this.PanelFiltros.Name = "PanelFiltros";
            this.PanelFiltros.Size = new System.Drawing.Size(1265, 100);
            this.PanelFiltros.TabIndex = 2;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblBuscar.Location = new System.Drawing.Point(20, 36);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(215, 29);
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Text = "Buscar por código:";
            // 
            // txtBuscador
            // 
            this.txtBuscador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtBuscador.Location = new System.Drawing.Point(250, 33);
            this.txtBuscador.MaxLength = 10;
            this.txtBuscador.Name = "txtBuscador";
            this.txtBuscador.Size = new System.Drawing.Size(300, 35);
            this.txtBuscador.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnBuscar.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnBuscar.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(47)))), ((int)(((byte)(103)))));
            this.btnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscar.IconSize = 28;
            this.btnBuscar.Location = new System.Drawing.Point(575, 28);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(150, 45);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // btnLimpiarBusqueda
            // 
            this.btnLimpiarBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnLimpiarBusqueda.IconChar = FontAwesome.Sharp.IconChar.Eraser;
            this.btnLimpiarBusqueda.IconColor = System.Drawing.Color.DimGray;
            this.btnLimpiarBusqueda.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLimpiarBusqueda.IconSize = 28;
            this.btnLimpiarBusqueda.Location = new System.Drawing.Point(745, 28);
            this.btnLimpiarBusqueda.Name = "btnLimpiarBusqueda";
            this.btnLimpiarBusqueda.Size = new System.Drawing.Size(150, 45);
            this.btnLimpiarBusqueda.TabIndex = 3;
            this.btnLimpiarBusqueda.Text = "Limpiar";
            this.btnLimpiarBusqueda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpiarBusqueda.UseVisualStyleBackColor = true;
            // 
            // PanelDivisor1
            // 
            this.PanelDivisor1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(47)))), ((int)(((byte)(103)))));
            this.PanelDivisor1.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelDivisor1.Location = new System.Drawing.Point(0, 100);
            this.PanelDivisor1.Name = "PanelDivisor1";
            this.PanelDivisor1.Size = new System.Drawing.Size(1265, 5);
            this.PanelDivisor1.TabIndex = 1;
            // 
            // PanelEncabezado
            // 
            this.PanelEncabezado.Controls.Add(this.picLogo);
            this.PanelEncabezado.Controls.Add(this.lblTitulo);
            this.PanelEncabezado.Controls.Add(this.lblSubtitulo);
            this.PanelEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelEncabezado.Location = new System.Drawing.Point(0, 0);
            this.PanelEncabezado.Name = "PanelEncabezado";
            this.PanelEncabezado.Size = new System.Drawing.Size(1265, 100);
            this.PanelEncabezado.TabIndex = 0;
            // 
            // picLogo
            // 
            this.picLogo.Image = global::Presentacion.Properties.Resources.Logo;
            this.picLogo.Location = new System.Drawing.Point(20, 10);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(80, 80);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(47)))), ((int)(((byte)(103)))));
            this.lblTitulo.Location = new System.Drawing.Point(115, 8);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(505, 52);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Ópticas Visión Guatemala";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblSubtitulo.Location = new System.Drawing.Point(121, 62);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(400, 29);
            this.lblSubtitulo.TabIndex = 2;
            this.lblSubtitulo.Text = "{SUBTITULO}";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.PanelPrincipalGestionar);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1271, 839);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Gestionar";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // PanelPrincipalGestionar
            // 
            this.PanelPrincipalGestionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.PanelPrincipalGestionar.Controls.Add(this.PanelCentralGestionar);
            this.PanelPrincipalGestionar.Controls.Add(this.PanelDivisor7);
            this.PanelPrincipalGestionar.Controls.Add(this.PanelAcciones);
            this.PanelPrincipalGestionar.Controls.Add(this.PanelDivisor6);
            this.PanelPrincipalGestionar.Controls.Add(this.PanelInferiorGestionar);
            this.PanelPrincipalGestionar.Controls.Add(this.PanelDivisor5);
            this.PanelPrincipalGestionar.Controls.Add(this.PanelEncabezadoGestionar);
            this.PanelPrincipalGestionar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelPrincipalGestionar.Location = new System.Drawing.Point(3, 3);
            this.PanelPrincipalGestionar.Name = "PanelPrincipalGestionar";
            this.PanelPrincipalGestionar.Size = new System.Drawing.Size(1265, 833);
            this.PanelPrincipalGestionar.TabIndex = 0;
            // 
            // PanelCentralGestionar
            // 
            this.PanelCentralGestionar.Controls.Add(this.grpDatos);
            this.PanelCentralGestionar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelCentralGestionar.Location = new System.Drawing.Point(0, 105);
            this.PanelCentralGestionar.Name = "PanelCentralGestionar";
            this.PanelCentralGestionar.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.PanelCentralGestionar.Size = new System.Drawing.Size(1265, 518);
            this.PanelCentralGestionar.TabIndex = 6;
            // 
            // grpDatos
            // 
            // [D7]
            this.grpDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.grpDatos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(47)))), ((int)(((byte)(103)))));
            this.grpDatos.Location = new System.Drawing.Point(20, 10);
            this.grpDatos.Name = "grpDatos";
            this.grpDatos.Size = new System.Drawing.Size(1225, 498);
            this.grpDatos.TabIndex = 0;
            this.grpDatos.TabStop = false;
            this.grpDatos.Text = "{GRUPO}";
            // [D8]
            // 
            // PanelDivisor7
            // 
            this.PanelDivisor7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelDivisor7.Location = new System.Drawing.Point(0, 623);
            this.PanelDivisor7.Name = "PanelDivisor7";
            this.PanelDivisor7.Size = new System.Drawing.Size(1265, 5);
            this.PanelDivisor7.TabIndex = 5;
            // 
            // PanelAcciones
            // 
            this.PanelAcciones.Controls.Add(this.btnNuevo);
            this.PanelAcciones.Controls.Add(this.btnGuardar);
            this.PanelAcciones.Controls.Add(this.btnCancelar);
            this.PanelAcciones.Controls.Add(this.btnEditar);
            this.PanelAcciones.Controls.Add(this.btnEliminar);
            this.PanelAcciones.Controls.Add(this.btnLimpiar);
            this.PanelAcciones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelAcciones.Location = new System.Drawing.Point(0, 628);
            this.PanelAcciones.Name = "PanelAcciones";
            this.PanelAcciones.Size = new System.Drawing.Size(1265, 100);
            this.PanelAcciones.TabIndex = 4;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnNuevo.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnNuevo.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(47)))), ((int)(((byte)(103)))));
            this.btnNuevo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNuevo.IconSize = 28;
            this.btnNuevo.Location = new System.Drawing.Point(45, 28);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(150, 45);
            this.btnNuevo.TabIndex = 0;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNuevo.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnGuardar.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.btnGuardar.IconColor = System.Drawing.Color.SeaGreen;
            this.btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGuardar.IconSize = 28;
            this.btnGuardar.Location = new System.Drawing.Point(250, 28);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(150, 45);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCancelar.IconChar = FontAwesome.Sharp.IconChar.Ban;
            this.btnCancelar.IconColor = System.Drawing.Color.DimGray;
            this.btnCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCancelar.IconSize = 28;
            this.btnCancelar.Location = new System.Drawing.Point(455, 28);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(150, 45);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            this.btnEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnEditar.IconChar = FontAwesome.Sharp.IconChar.PenToSquare;
            this.btnEditar.IconColor = System.Drawing.Color.DarkOrange;
            this.btnEditar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEditar.IconSize = 28;
            this.btnEditar.Location = new System.Drawing.Point(660, 28);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(150, 45);
            this.btnEditar.TabIndex = 3;
            this.btnEditar.Text = "Editar";
            this.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnEliminar.IconChar = FontAwesome.Sharp.IconChar.TrashCan;
            this.btnEliminar.IconColor = System.Drawing.Color.Firebrick;
            this.btnEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEliminar.IconSize = 28;
            this.btnEliminar.Location = new System.Drawing.Point(865, 28);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(150, 45);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnLimpiar.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.btnLimpiar.IconColor = System.Drawing.Color.DimGray;
            this.btnLimpiar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLimpiar.IconSize = 28;
            this.btnLimpiar.Location = new System.Drawing.Point(1070, 28);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(150, 45);
            this.btnLimpiar.TabIndex = 5;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // PanelDivisor6
            // 
            this.PanelDivisor6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelDivisor6.Location = new System.Drawing.Point(0, 728);
            this.PanelDivisor6.Name = "PanelDivisor6";
            this.PanelDivisor6.Size = new System.Drawing.Size(1265, 5);
            this.PanelDivisor6.TabIndex = 3;
            // 
            // PanelInferiorGestionar
            // 
            this.PanelInferiorGestionar.Controls.Add(this.btnCerrarGestionar);
            this.PanelInferiorGestionar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelInferiorGestionar.Location = new System.Drawing.Point(0, 733);
            this.PanelInferiorGestionar.Name = "PanelInferiorGestionar";
            this.PanelInferiorGestionar.Size = new System.Drawing.Size(1265, 100);
            this.PanelInferiorGestionar.TabIndex = 2;
            // 
            // btnCerrarGestionar
            // 
            this.btnCerrarGestionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrarGestionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCerrarGestionar.IconChar = FontAwesome.Sharp.IconChar.RightFromBracket;
            this.btnCerrarGestionar.IconColor = System.Drawing.Color.Firebrick;
            this.btnCerrarGestionar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCerrarGestionar.IconSize = 28;
            this.btnCerrarGestionar.Location = new System.Drawing.Point(1095, 28);
            this.btnCerrarGestionar.Name = "btnCerrarGestionar";
            this.btnCerrarGestionar.Size = new System.Drawing.Size(150, 45);
            this.btnCerrarGestionar.TabIndex = 0;
            this.btnCerrarGestionar.Text = "Cerrar";
            this.btnCerrarGestionar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCerrarGestionar.UseVisualStyleBackColor = true;
            // 
            // PanelDivisor5
            // 
            this.PanelDivisor5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(47)))), ((int)(((byte)(103)))));
            this.PanelDivisor5.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelDivisor5.Location = new System.Drawing.Point(0, 100);
            this.PanelDivisor5.Name = "PanelDivisor5";
            this.PanelDivisor5.Size = new System.Drawing.Size(1265, 5);
            this.PanelDivisor5.TabIndex = 1;
            // 
            // PanelEncabezadoGestionar
            // 
            this.PanelEncabezadoGestionar.Controls.Add(this.picLogoGestionar);
            this.PanelEncabezadoGestionar.Controls.Add(this.lblTituloGestionar);
            this.PanelEncabezadoGestionar.Controls.Add(this.lblSubtituloGestionar);
            this.PanelEncabezadoGestionar.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelEncabezadoGestionar.Location = new System.Drawing.Point(0, 0);
            this.PanelEncabezadoGestionar.Name = "PanelEncabezadoGestionar";
            this.PanelEncabezadoGestionar.Size = new System.Drawing.Size(1265, 100);
            this.PanelEncabezadoGestionar.TabIndex = 0;
            // 
            // picLogoGestionar
            // 
            this.picLogoGestionar.Image = global::Presentacion.Properties.Resources.Logo;
            this.picLogoGestionar.Location = new System.Drawing.Point(20, 10);
            this.picLogoGestionar.Name = "picLogoGestionar";
            this.picLogoGestionar.Size = new System.Drawing.Size(80, 80);
            this.picLogoGestionar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogoGestionar.TabIndex = 0;
            this.picLogoGestionar.TabStop = false;
            // 
            // lblTituloGestionar
            // 
            this.lblTituloGestionar.AutoSize = true;
            this.lblTituloGestionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.lblTituloGestionar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(47)))), ((int)(((byte)(103)))));
            this.lblTituloGestionar.Location = new System.Drawing.Point(115, 8);
            this.lblTituloGestionar.Name = "lblTituloGestionar";
            this.lblTituloGestionar.Size = new System.Drawing.Size(505, 52);
            this.lblTituloGestionar.TabIndex = 1;
            this.lblTituloGestionar.Text = "Ópticas Visión Guatemala";
            // 
            // lblSubtituloGestionar
            // 
            this.lblSubtituloGestionar.AutoSize = true;
            this.lblSubtituloGestionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblSubtituloGestionar.Location = new System.Drawing.Point(121, 62);
            this.lblSubtituloGestionar.Name = "lblSubtituloGestionar";
            this.lblSubtituloGestionar.Size = new System.Drawing.Size(400, 29);
            this.lblSubtituloGestionar.TabIndex = 2;
            this.lblSubtituloGestionar.Text = "{SUBTITULO}";
            // 
            // Frm{Tabla}
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1279, 872);
            this.Controls.Add(this.tabControl1);
            this.Name = "Frm{Tabla}";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "{TITULO_VENTANA}";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.PanelPrincipal.ResumeLayout(false);
            this.PanelCentral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv{Tabla})).EndInit();
            this.PanelInferior.ResumeLayout(false);
            this.PanelInferior.PerformLayout();
            this.PanelCheck.ResumeLayout(false);
            this.PanelCheck.PerformLayout();
            this.PanelFiltros.ResumeLayout(false);
            this.PanelFiltros.PerformLayout();
            this.PanelEncabezado.ResumeLayout(false);
            this.PanelEncabezado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.PanelPrincipalGestionar.ResumeLayout(false);
            this.PanelCentralGestionar.ResumeLayout(false);
            this.grpDatos.ResumeLayout(false);
            this.grpDatos.PerformLayout();
            // [D9]
            this.PanelAcciones.ResumeLayout(false);
            this.PanelInferiorGestionar.ResumeLayout(false);
            this.PanelEncabezadoGestionar.ResumeLayout(false);
            this.PanelEncabezadoGestionar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoGestionar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel PanelPrincipal;
        private System.Windows.Forms.Panel PanelEncabezado;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Panel PanelDivisor1;
        private System.Windows.Forms.Panel PanelFiltros;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscador;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private FontAwesome.Sharp.IconButton btnLimpiarBusqueda;
        private System.Windows.Forms.Panel PanelDivisor2;
        private System.Windows.Forms.Panel PanelCheck;
        private System.Windows.Forms.CheckBox chkSeleccionar;
        private FontAwesome.Sharp.IconButton btnExportar;
        private FontAwesome.Sharp.IconButton btnImprimir;
        private System.Windows.Forms.Panel PanelDivisor3;
        private System.Windows.Forms.Panel PanelCentral;
        private System.Windows.Forms.DataGridView dgv{Tabla};
        private System.Windows.Forms.Panel PanelDivisor4;
        private System.Windows.Forms.Panel PanelInferior;
        private System.Windows.Forms.Label lblTotalRegistros;
        private FontAwesome.Sharp.IconButton btnCerrar;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel PanelPrincipalGestionar;
        private System.Windows.Forms.Panel PanelEncabezadoGestionar;
        private System.Windows.Forms.PictureBox picLogoGestionar;
        private System.Windows.Forms.Label lblTituloGestionar;
        private System.Windows.Forms.Label lblSubtituloGestionar;
        private System.Windows.Forms.Panel PanelDivisor5;
        private System.Windows.Forms.Panel PanelCentralGestionar;
        private System.Windows.Forms.GroupBox grpDatos;
        private System.Windows.Forms.Panel PanelDivisor7;
        private System.Windows.Forms.Panel PanelAcciones;
        private FontAwesome.Sharp.IconButton btnNuevo;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private FontAwesome.Sharp.IconButton btnCancelar;
        private FontAwesome.Sharp.IconButton btnEditar;
        private FontAwesome.Sharp.IconButton btnEliminar;
        private FontAwesome.Sharp.IconButton btnLimpiar;
        private System.Windows.Forms.Panel PanelDivisor6;
        private System.Windows.Forms.Panel PanelInferiorGestionar;
        private FontAwesome.Sharp.IconButton btnCerrarGestionar;
        // [D10]
    }
}
```

### Bloques para `[D6]` (columnas)

```csharp
            // 
            // colCodigoReceta
            // 
            this.colCodigoReceta.DataPropertyName = "CodigoReceta";
            this.colCodigoReceta.FillWeight = 60F;
            this.colCodigoReceta.HeaderText = "Código";
            this.colCodigoReceta.Name = "colCodigoReceta";
            this.colCodigoReceta.ReadOnly = true;
            // 
            // colFechaEmision   (DATE)
            // 
            this.colFechaEmision.DataPropertyName = "FechaEmision";
            dataGridViewCellStyle3.Format = "dd/MM/yyyy";
            this.colFechaEmision.DefaultCellStyle = dataGridViewCellStyle3;
            this.colFechaEmision.FillWeight = 80F;
            this.colFechaEmision.HeaderText = "Fecha emisión";
            this.colFechaEmision.Name = "colFechaEmision";
            this.colFechaEmision.ReadOnly = true;
            // 
            // colEsferaOD   (NUMERIC)
            // 
            this.colEsferaOD.DataPropertyName = "EsferaOD";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.colEsferaOD.DefaultCellStyle = dataGridViewCellStyle4;
            this.colEsferaOD.FillWeight = 70F;
            this.colEsferaOD.HeaderText = "Esfera OD";
            this.colEsferaOD.Name = "colEsferaOD";
            this.colEsferaOD.ReadOnly = true;
```

### Bloques para `[D8]` (label + control de cada campo)

Label (igual para todos; `X` = 30 o 650, `Y` = 48 + 60*fila; `TabIndex` del label puede ser 20+):

```csharp
            // 
            // lblNombres
            // 
            this.lblNombres.AutoSize = true;
            this.lblNombres.ForeColor = System.Drawing.Color.Black;
            this.lblNombres.Location = new System.Drawing.Point(30, 108);
            this.lblNombres.Name = "lblNombres";
            this.lblNombres.Size = new System.Drawing.Size(114, 29);
            this.lblNombres.TabIndex = 2;
            this.lblNombres.Text = "Nombres:";
```

TextBox de código (PK):

```csharp
            this.txtCodigoReceta.Enabled = false;
            this.txtCodigoReceta.Location = new System.Drawing.Point(330, 45);
            this.txtCodigoReceta.Name = "txtCodigoReceta";
            this.txtCodigoReceta.ReadOnly = true;
            this.txtCodigoReceta.Size = new System.Drawing.Size(280, 35);
            this.txtCodigoReceta.TabIndex = 0;
            this.txtCodigoReceta.TabStop = false;
```

TextBox normal / multilínea:

```csharp
            this.txtNombres.Location = new System.Drawing.Point(330, 105);
            this.txtNombres.MaxLength = 100;
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(280, 35);
            this.txtNombres.TabIndex = 3;

            this.txtObservaciones.Location = new System.Drawing.Point(920, 345);
            this.txtObservaciones.MaxLength = 300;
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservaciones.Size = new System.Drawing.Size(280, 95);
            this.txtObservaciones.TabIndex = 12;
```

ComboBox de FK / ComboBox con lista fija:

```csharp
            this.cboCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(330, 105);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(280, 37);
            this.cboCliente.TabIndex = 3;

            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Items.AddRange(new object[] {
            "Vigente",
            "Vencida",
            "Anulada"});
            this.cboEstado.Location = new System.Drawing.Point(330, 405);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(280, 37);
            this.cboEstado.TabIndex = 11;
```

DateTimePicker fecha / hora:

```csharp
            this.dtpFecha.CustomFormat = "dd/MM/yyyy";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(920, 45);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(280, 35);
            this.dtpFecha.TabIndex = 9;

            this.dtpHora.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHora.Location = new System.Drawing.Point(920, 105);
            this.dtpHora.Name = "dtpHora";
            this.dtpHora.ShowUpDown = true;
            this.dtpHora.Size = new System.Drawing.Size(280, 35);
            this.dtpHora.TabIndex = 10;
```

NumericUpDown decimal / entero (recordar `[D4]` y `[D9]`):

```csharp
            this.nudEsferaOD.DecimalPlaces = 2;
            this.nudEsferaOD.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.nudEsferaOD.Location = new System.Drawing.Point(330, 105);
            this.nudEsferaOD.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudEsferaOD.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            -2147483648});
            this.nudEsferaOD.Name = "nudEsferaOD";
            this.nudEsferaOD.Size = new System.Drawing.Size(280, 35);
            this.nudEsferaOD.TabIndex = 2;

            this.nudEjeOD.Location = new System.Drawing.Point(330, 225);
            this.nudEjeOD.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.nudEjeOD.Name = "nudEjeOD";
            this.nudEjeOD.Size = new System.Drawing.Size(280, 35);
            this.nudEjeOD.TabIndex = 4;
```

RadioButton de Estado (Activo en X del control, Inactivo en X + 140):

```csharp
            this.rdbActivo.AutoSize = true;
            this.rdbActivo.Checked = true;
            this.rdbActivo.ForeColor = System.Drawing.Color.Black;
            this.rdbActivo.Location = new System.Drawing.Point(920, 166);
            this.rdbActivo.Name = "rdbActivo";
            this.rdbActivo.Size = new System.Drawing.Size(102, 33);
            this.rdbActivo.TabIndex = 13;
            this.rdbActivo.TabStop = true;
            this.rdbActivo.Text = "Activo";
            this.rdbActivo.UseVisualStyleBackColor = true;

            this.rdbInactivo.AutoSize = true;
            this.rdbInactivo.ForeColor = System.Drawing.Color.Black;
            this.rdbInactivo.Location = new System.Drawing.Point(1060, 166);
            this.rdbInactivo.Name = "rdbInactivo";
            this.rdbInactivo.Size = new System.Drawing.Size(119, 33);
            this.rdbInactivo.TabIndex = 14;
            this.rdbInactivo.Text = "Inactivo";
            this.rdbInactivo.UseVisualStyleBackColor = true;
```

Cada bloque va precedido de su comentario de sección como lo hace Visual Studio:

```csharp
            // 
            // nombreDelControl
            // 
```

### `.cs` de una pantalla de solo diseño

```csharp
using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Frm{Tabla} : Form
    {
        // =====================================================
        // POO: CONSTRUCTOR
        // =====================================================

        public Frm{Tabla}()
        {
            InitializeComponent();
        }
    }
}
```

En solo diseño **no** se escriben líneas `+= new System.EventHandler(...)` en el Designer
(darían error porque los métodos todavía no existen).
