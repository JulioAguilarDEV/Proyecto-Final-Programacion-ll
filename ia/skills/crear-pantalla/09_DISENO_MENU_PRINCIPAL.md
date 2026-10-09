# 09 · Diseño del menú principal (ventana contenedora)

> **Úsalo para el diseño** de la ventana principal del sistema (`FrmPrincipal`): ventana sin
> borde con menú lateral azul marino, logo de la empresa arriba del menú, barra de título con botón
> hamburguesa y botones minimizar/maximizar/cerrar, y un **panel contenedor** donde se abren
> todas las pantallas CRUD y el Dashboard.
> También explica cómo **agregar una pantalla nueva al menú** (sección 4).
> Colores: ver `00_CONTEXTO_PROYECTO.md` (Colores del sistema).

## 1. Estructura

```
FrmPrincipal (ClientSize 1539x922, FormBorderStyle None, StartPosition CenterScreen)
├── PanelMenu (Dock Left, 260 de ancho, Marino 3,47,103)
│   ├── PanelLogo        Top 190  → fondo 253,252,250, Padding 12,10 → picLogoMenu (Dock Fill, Zoom, Resources.LogoIcono = logoicono.png)
│   ├── PanelDivisorMenu Top 4    → Marino (3,47,103)
│   ├── 12 IconButton    Top 50 c/u (Inicio, Sucursales, Usuarios, Clientes, Citas, Optometristas,
│   │                    Exámenes Visuales, Recetas, Tipos de Producto, Productos Ópticos, Órdenes, Entregas)
│   └── PanelUsuario     Bottom 90 → marino oscuro 2,34,77: icoUsuario (CircleUser) + lblNombreUsuario, lblRolUsuario, lblSucursalUsuario
├── PanelBarraTitulo (Dock Top, 50 de alto, blanco)
│   ├── btnMenu (IconPictureBox Bars, Marino) + lblTituloPantalla (nombre de la pantalla abierta, Segoe UI Semibold 13F, Marino)
│   ├── btnMinimizar, btnMaximizar, btnRestaurar (oculto), btnCerrar (IconPictureBox 28x28, gris 73,85,98, Anchor Top Right)
│   └── PanelLineaTitulo (Dock Bottom, 2 px, 225,228,232)
└── PanelContenedor (Dock Fill, 1279x872, fondo 253,252,250) → aquí se abren las pantallas
```

- **Orden de `Controls.Add` del formulario:** `PanelContenedor` (Fill), `PanelBarraTitulo` (Top), `PanelMenu` (Left).
  Así el menú ocupa todo el alto a la izquierda y la barra de título queda solo sobre el contenedor.
- **Orden de `Controls.Add` de PanelMenu:** `PanelUsuario`, los botones **del último al primero**
  (Entregas … Inicio), `PanelDivisorMenu`, `PanelLogo` (el que se agrega al final queda arriba).
- El contenedor mide 1279x872, igual que las pantallas CRUD, así se ven completas.

## 2. Botones del menú

Todos: `Dock Top`, `Size 260x50`, `FlatStyle Flat`, `FlatAppearance.BorderSize 0`,
`FlatAppearance.MouseOverBackColor` azul del iris del logo (2,66,125), `Font Segoe UI 10F`, `ForeColor White`,
`IconColor White`, `IconSize 30`, `ImageAlign MiddleLeft`, `TextAlign MiddleLeft`,
`TextImageRelation ImageBeforeText`, `Padding 20,0,0,0`, texto con 2 espacios al inicio (`"  Recetas"`).
El botón de la pantalla abierta se pinta del gris del logo (101,114,122) con `MtdResaltarBoton`
(el fondo del menú es Marino 3,47,103, así el botón seleccionado se distingue).

| Botón | Texto | IconChar | Abre |
|---|---|---|---|
| btnInicio | Inicio | House | `FrmDashboard` (bienvenida; la barra de título dice "Inicio") |
| btnSucursales | Sucursales | Store | (pendiente) |
| btnUsuarios | Usuarios | UserGear | (pendiente) |
| btnClientes | Clientes | Users | (pendiente) |
| btnCitas | Citas | CalendarCheck | (pendiente) |
| btnOptometristas | Optometristas | UserDoctor | `FrmOptometrista` |
| btnExamenes | Exámenes Visuales | Eye | `FrmExamenVisual` |
| btnRecetas | Recetas | FilePrescription | `FrmReceta` |
| btnTiposProducto | Tipos de Producto | Tags | (pendiente) |
| btnProductos | Productos Ópticos | Glasses | (pendiente) |
| btnOrdenes | Órdenes | CartShopping | (pendiente) |
| btnEntregas | Entregas | Truck | (pendiente) |

## 3. Funcionamiento (solo navegación, sin base de datos)

- Al iniciar abre `FrmDashboard` (bienvenida) dentro del contenedor, con el botón **Inicio** seleccionado.
- `MtdAbrirFormulario(formulario, titulo)`: cierra la pantalla anterior y muestra la nueva dentro
  del contenedor (`TopLevel = false`, sin borde, `Dock Fill`) y cambia `lblTituloPantalla`.
- Si una pantalla se cierra con su botón **Cerrar**, se regresa a Inicio.
- Hamburguesa: el menú pasa de su ancho normal a 70 (solo íconos) y viceversa.
- Arrastrar la barra de título mueve la ventana (funciones `ReleaseCapture`/`SendMessage` de Windows).
- Maximizar respeta la barra de tareas (`MaximizedBounds = Screen.FromControl(this).WorkingArea`).

## 4. Agregar una pantalla nueva al menú

Cuando se cree una pantalla (por ejemplo `FrmCliente`), cambiar su botón en `FrmPrincipal.cs`:

```csharp
        private void btnClientes_Click(object sender, EventArgs e)
        {
            MtdResaltarBoton(btnClientes);
            MtdAbrirFormulario(new FrmCliente(), "Clientes");
        }
```

(antes decía `MtdPantallaPendiente("Clientes");`). Si es un módulo nuevo que no tiene botón,
copiar un bloque de botón en el Designer, agregarlo a `PanelMenu.Controls.Add` en el lugar
correcto y sumar 50 al `Location` de los botones que quedan debajo.

## 5. Código del Designer (`FrmPrincipal.Designer.cs`)

```csharp
namespace Presentacion
{
    partial class FrmPrincipal
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
            this.PanelMenu = new System.Windows.Forms.Panel();
            this.PanelUsuario = new System.Windows.Forms.Panel();
            this.lblSucursalUsuario = new System.Windows.Forms.Label();
            this.lblRolUsuario = new System.Windows.Forms.Label();
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.icoUsuario = new FontAwesome.Sharp.IconPictureBox();
            this.btnEntregas = new FontAwesome.Sharp.IconButton();
            this.btnOrdenes = new FontAwesome.Sharp.IconButton();
            this.btnProductos = new FontAwesome.Sharp.IconButton();
            this.btnTiposProducto = new FontAwesome.Sharp.IconButton();
            this.btnRecetas = new FontAwesome.Sharp.IconButton();
            this.btnExamenes = new FontAwesome.Sharp.IconButton();
            this.btnOptometristas = new FontAwesome.Sharp.IconButton();
            this.btnCitas = new FontAwesome.Sharp.IconButton();
            this.btnClientes = new FontAwesome.Sharp.IconButton();
            this.btnUsuarios = new FontAwesome.Sharp.IconButton();
            this.btnSucursales = new FontAwesome.Sharp.IconButton();
            this.btnInicio = new FontAwesome.Sharp.IconButton();
            this.PanelDivisorMenu = new System.Windows.Forms.Panel();
            this.PanelLogo = new System.Windows.Forms.Panel();
            this.picLogoMenu = new System.Windows.Forms.PictureBox();
            this.PanelBarraTitulo = new System.Windows.Forms.Panel();
            this.btnMenu = new FontAwesome.Sharp.IconPictureBox();
            this.lblTituloPantalla = new System.Windows.Forms.Label();
            this.btnMinimizar = new FontAwesome.Sharp.IconPictureBox();
            this.btnMaximizar = new FontAwesome.Sharp.IconPictureBox();
            this.btnRestaurar = new FontAwesome.Sharp.IconPictureBox();
            this.btnCerrar = new FontAwesome.Sharp.IconPictureBox();
            this.PanelLineaTitulo = new System.Windows.Forms.Panel();
            this.PanelContenedor = new System.Windows.Forms.Panel();
            this.PanelMenu.SuspendLayout();
            this.PanelUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icoUsuario)).BeginInit();
            this.PanelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoMenu)).BeginInit();
            this.PanelBarraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestaurar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelMenu
            // 
            this.PanelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(47)))), ((int)(((byte)(103)))));
            this.PanelMenu.Controls.Add(this.PanelUsuario);
            this.PanelMenu.Controls.Add(this.btnEntregas);
            this.PanelMenu.Controls.Add(this.btnOrdenes);
            this.PanelMenu.Controls.Add(this.btnProductos);
            this.PanelMenu.Controls.Add(this.btnTiposProducto);
            this.PanelMenu.Controls.Add(this.btnRecetas);
            this.PanelMenu.Controls.Add(this.btnExamenes);
            this.PanelMenu.Controls.Add(this.btnOptometristas);
            this.PanelMenu.Controls.Add(this.btnCitas);
            this.PanelMenu.Controls.Add(this.btnClientes);
            this.PanelMenu.Controls.Add(this.btnUsuarios);
            this.PanelMenu.Controls.Add(this.btnSucursales);
            this.PanelMenu.Controls.Add(this.btnInicio);
            this.PanelMenu.Controls.Add(this.PanelDivisorMenu);
            this.PanelMenu.Controls.Add(this.PanelLogo);
            this.PanelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelMenu.Location = new System.Drawing.Point(0, 0);
            this.PanelMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanelMenu.Name = "PanelMenu";
            this.PanelMenu.Size = new System.Drawing.Size(231, 738);
            this.PanelMenu.TabIndex = 0;
            // 
            // PanelUsuario
            // 
            this.PanelUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(34)))), ((int)(((byte)(77)))));
            this.PanelUsuario.Controls.Add(this.lblSucursalUsuario);
            this.PanelUsuario.Controls.Add(this.lblRolUsuario);
            this.PanelUsuario.Controls.Add(this.lblNombreUsuario);
            this.PanelUsuario.Controls.Add(this.icoUsuario);
            this.PanelUsuario.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelUsuario.Location = new System.Drawing.Point(0, 666);
            this.PanelUsuario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanelUsuario.Name = "PanelUsuario";
            this.PanelUsuario.Size = new System.Drawing.Size(231, 72);
            this.PanelUsuario.TabIndex = 14;
            // 
            // lblSucursalUsuario
            // 
            this.lblSucursalUsuario.AutoSize = true;
            this.lblSucursalUsuario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSucursalUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(229)))), ((int)(((byte)(233)))));
            this.lblSucursalUsuario.Location = new System.Drawing.Point(73, 48);
            this.lblSucursalUsuario.Name = "lblSucursalUsuario";
            this.lblSucursalUsuario.Size = new System.Drawing.Size(63, 20);
            this.lblSucursalUsuario.TabIndex = 3;
            this.lblSucursalUsuario.Text = "Sucursal";
            // 
            // lblRolUsuario
            // 
            this.lblRolUsuario.AutoSize = true;
            this.lblRolUsuario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRolUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(229)))), ((int)(((byte)(233)))));
            this.lblRolUsuario.Location = new System.Drawing.Point(73, 30);
            this.lblRolUsuario.Name = "lblRolUsuario";
            this.lblRolUsuario.Size = new System.Drawing.Size(31, 20);
            this.lblRolUsuario.TabIndex = 2;
            this.lblRolUsuario.Text = "Rol";
            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.AutoSize = true;
            this.lblNombreUsuario.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblNombreUsuario.ForeColor = System.Drawing.Color.White;
            this.lblNombreUsuario.Location = new System.Drawing.Point(73, 9);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(68, 23);
            this.lblNombreUsuario.TabIndex = 1;
            this.lblNombreUsuario.Text = "Usuario";
            // 
            // icoUsuario
            // 
            this.icoUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(34)))), ((int)(((byte)(77)))));
            this.icoUsuario.IconChar = FontAwesome.Sharp.IconChar.UserCircle;
            this.icoUsuario.IconColor = System.Drawing.Color.White;
            this.icoUsuario.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icoUsuario.IconSize = 45;
            this.icoUsuario.Location = new System.Drawing.Point(14, 14);
            this.icoUsuario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.icoUsuario.Name = "icoUsuario";
            this.icoUsuario.Size = new System.Drawing.Size(50, 45);
            this.icoUsuario.TabIndex = 0;
            this.icoUsuario.TabStop = false;
            // 
            // btnEntregas
            // 
            this.btnEntregas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEntregas.FlatAppearance.BorderSize = 0;
            this.btnEntregas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(66)))), ((int)(((byte)(125)))));
            this.btnEntregas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntregas.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnEntregas.ForeColor = System.Drawing.Color.White;
            this.btnEntregas.IconChar = FontAwesome.Sharp.IconChar.Truck;
            this.btnEntregas.IconColor = System.Drawing.Color.White;
            this.btnEntregas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEntregas.IconSize = 30;
            this.btnEntregas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEntregas.Location = new System.Drawing.Point(0, 595);
            this.btnEntregas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEntregas.Name = "btnEntregas";
            this.btnEntregas.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnEntregas.Size = new System.Drawing.Size(231, 40);
            this.btnEntregas.TabIndex = 13;
            this.btnEntregas.Text = "  Entregas";
            this.btnEntregas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEntregas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEntregas.Click += new System.EventHandler(this.btnEntregas_Click);
            // 
            // btnOrdenes
            // 
            this.btnOrdenes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOrdenes.FlatAppearance.BorderSize = 0;
            this.btnOrdenes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(66)))), ((int)(((byte)(125)))));
            this.btnOrdenes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrdenes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnOrdenes.ForeColor = System.Drawing.Color.White;
            this.btnOrdenes.IconChar = FontAwesome.Sharp.IconChar.CartShopping;
            this.btnOrdenes.IconColor = System.Drawing.Color.White;
            this.btnOrdenes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnOrdenes.IconSize = 30;
            this.btnOrdenes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOrdenes.Location = new System.Drawing.Point(0, 555);
            this.btnOrdenes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOrdenes.Name = "btnOrdenes";
            this.btnOrdenes.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnOrdenes.Size = new System.Drawing.Size(231, 40);
            this.btnOrdenes.TabIndex = 12;
            this.btnOrdenes.Text = "  Órdenes";
            this.btnOrdenes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOrdenes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOrdenes.Click += new System.EventHandler(this.btnOrdenes_Click);
            // 
            // btnProductos
            // 
            this.btnProductos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProductos.FlatAppearance.BorderSize = 0;
            this.btnProductos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(66)))), ((int)(((byte)(125)))));
            this.btnProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductos.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnProductos.ForeColor = System.Drawing.Color.White;
            this.btnProductos.IconChar = FontAwesome.Sharp.IconChar.Glasses;
            this.btnProductos.IconColor = System.Drawing.Color.White;
            this.btnProductos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnProductos.IconSize = 30;
            this.btnProductos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductos.Location = new System.Drawing.Point(0, 515);
            this.btnProductos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnProductos.Size = new System.Drawing.Size(231, 40);
            this.btnProductos.TabIndex = 11;
            this.btnProductos.Text = "  Productos Ópticos";
            this.btnProductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // btnTiposProducto
            // 
            this.btnTiposProducto.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTiposProducto.FlatAppearance.BorderSize = 0;
            this.btnTiposProducto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(66)))), ((int)(((byte)(125)))));
            this.btnTiposProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTiposProducto.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnTiposProducto.ForeColor = System.Drawing.Color.White;
            this.btnTiposProducto.IconChar = FontAwesome.Sharp.IconChar.Tags;
            this.btnTiposProducto.IconColor = System.Drawing.Color.White;
            this.btnTiposProducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTiposProducto.IconSize = 30;
            this.btnTiposProducto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTiposProducto.Location = new System.Drawing.Point(0, 475);
            this.btnTiposProducto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTiposProducto.Name = "btnTiposProducto";
            this.btnTiposProducto.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnTiposProducto.Size = new System.Drawing.Size(231, 40);
            this.btnTiposProducto.TabIndex = 10;
            this.btnTiposProducto.Text = "  Tipos de Producto";
            this.btnTiposProducto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTiposProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTiposProducto.Click += new System.EventHandler(this.btnTiposProducto_Click);
            // 
            // btnRecetas
            // 
            this.btnRecetas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRecetas.FlatAppearance.BorderSize = 0;
            this.btnRecetas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(66)))), ((int)(((byte)(125)))));
            this.btnRecetas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecetas.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnRecetas.ForeColor = System.Drawing.Color.White;
            this.btnRecetas.IconChar = FontAwesome.Sharp.IconChar.FilePrescription;
            this.btnRecetas.IconColor = System.Drawing.Color.White;
            this.btnRecetas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRecetas.IconSize = 30;
            this.btnRecetas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecetas.Location = new System.Drawing.Point(0, 435);
            this.btnRecetas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRecetas.Name = "btnRecetas";
            this.btnRecetas.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnRecetas.Size = new System.Drawing.Size(231, 40);
            this.btnRecetas.TabIndex = 9;
            this.btnRecetas.Text = "  Recetas";
            this.btnRecetas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecetas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRecetas.Click += new System.EventHandler(this.btnRecetas_Click);
            // 
            // btnExamenes
            // 
            this.btnExamenes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExamenes.FlatAppearance.BorderSize = 0;
            this.btnExamenes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(66)))), ((int)(((byte)(125)))));
            this.btnExamenes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExamenes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnExamenes.ForeColor = System.Drawing.Color.White;
            this.btnExamenes.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.btnExamenes.IconColor = System.Drawing.Color.White;
            this.btnExamenes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExamenes.IconSize = 30;
            this.btnExamenes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExamenes.Location = new System.Drawing.Point(0, 395);
            this.btnExamenes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExamenes.Name = "btnExamenes";
            this.btnExamenes.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnExamenes.Size = new System.Drawing.Size(231, 40);
            this.btnExamenes.TabIndex = 8;
            this.btnExamenes.Text = "  Exámenes Visuales";
            this.btnExamenes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExamenes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExamenes.Click += new System.EventHandler(this.btnExamenes_Click);
            // 
            // btnOptometristas
            // 
            this.btnOptometristas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOptometristas.FlatAppearance.BorderSize = 0;
            this.btnOptometristas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(66)))), ((int)(((byte)(125)))));
            this.btnOptometristas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOptometristas.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnOptometristas.ForeColor = System.Drawing.Color.White;
            this.btnOptometristas.IconChar = FontAwesome.Sharp.IconChar.UserMd;
            this.btnOptometristas.IconColor = System.Drawing.Color.White;
            this.btnOptometristas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnOptometristas.IconSize = 30;
            this.btnOptometristas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOptometristas.Location = new System.Drawing.Point(0, 355);
            this.btnOptometristas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOptometristas.Name = "btnOptometristas";
            this.btnOptometristas.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnOptometristas.Size = new System.Drawing.Size(231, 40);
            this.btnOptometristas.TabIndex = 7;
            this.btnOptometristas.Text = "  Optometristas";
            this.btnOptometristas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOptometristas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOptometristas.Click += new System.EventHandler(this.btnOptometristas_Click);
            // 
            // btnCitas
            // 
            this.btnCitas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCitas.FlatAppearance.BorderSize = 0;
            this.btnCitas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(66)))), ((int)(((byte)(125)))));
            this.btnCitas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCitas.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCitas.ForeColor = System.Drawing.Color.White;
            this.btnCitas.IconChar = FontAwesome.Sharp.IconChar.CalendarCheck;
            this.btnCitas.IconColor = System.Drawing.Color.White;
            this.btnCitas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCitas.IconSize = 30;
            this.btnCitas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCitas.Location = new System.Drawing.Point(0, 315);
            this.btnCitas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCitas.Name = "btnCitas";
            this.btnCitas.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnCitas.Size = new System.Drawing.Size(231, 40);
            this.btnCitas.TabIndex = 6;
            this.btnCitas.Text = "  Citas";
            this.btnCitas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCitas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCitas.Click += new System.EventHandler(this.btnCitas_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClientes.FlatAppearance.BorderSize = 0;
            this.btnClientes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(66)))), ((int)(((byte)(125)))));
            this.btnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnClientes.ForeColor = System.Drawing.Color.White;
            this.btnClientes.IconChar = FontAwesome.Sharp.IconChar.Users;
            this.btnClientes.IconColor = System.Drawing.Color.White;
            this.btnClientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnClientes.IconSize = 30;
            this.btnClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientes.Location = new System.Drawing.Point(0, 275);
            this.btnClientes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnClientes.Size = new System.Drawing.Size(231, 40);
            this.btnClientes.TabIndex = 5;
            this.btnClientes.Text = "  Clientes";
            this.btnClientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUsuarios.FlatAppearance.BorderSize = 0;
            this.btnUsuarios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(66)))), ((int)(((byte)(125)))));
            this.btnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuarios.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnUsuarios.ForeColor = System.Drawing.Color.White;
            this.btnUsuarios.IconChar = FontAwesome.Sharp.IconChar.UserGear;
            this.btnUsuarios.IconColor = System.Drawing.Color.White;
            this.btnUsuarios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnUsuarios.IconSize = 30;
            this.btnUsuarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsuarios.Location = new System.Drawing.Point(0, 235);
            this.btnUsuarios.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnUsuarios.Size = new System.Drawing.Size(231, 40);
            this.btnUsuarios.TabIndex = 4;
            this.btnUsuarios.Text = "  Usuarios";
            this.btnUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnSucursales
            // 
            this.btnSucursales.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSucursales.FlatAppearance.BorderSize = 0;
            this.btnSucursales.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(66)))), ((int)(((byte)(125)))));
            this.btnSucursales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSucursales.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSucursales.ForeColor = System.Drawing.Color.White;
            this.btnSucursales.IconChar = FontAwesome.Sharp.IconChar.Store;
            this.btnSucursales.IconColor = System.Drawing.Color.White;
            this.btnSucursales.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSucursales.IconSize = 30;
            this.btnSucursales.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSucursales.Location = new System.Drawing.Point(0, 195);
            this.btnSucursales.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSucursales.Name = "btnSucursales";
            this.btnSucursales.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnSucursales.Size = new System.Drawing.Size(231, 40);
            this.btnSucursales.TabIndex = 3;
            this.btnSucursales.Text = "  Sucursales";
            this.btnSucursales.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSucursales.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSucursales.Click += new System.EventHandler(this.btnSucursales_Click);
            // 
            // btnInicio
            // 
            this.btnInicio.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInicio.FlatAppearance.BorderSize = 0;
            this.btnInicio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(66)))), ((int)(((byte)(125)))));
            this.btnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInicio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnInicio.ForeColor = System.Drawing.Color.White;
            this.btnInicio.IconChar = FontAwesome.Sharp.IconChar.House;
            this.btnInicio.IconColor = System.Drawing.Color.White;
            this.btnInicio.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnInicio.IconSize = 30;
            this.btnInicio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInicio.Location = new System.Drawing.Point(0, 155);
            this.btnInicio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnInicio.Size = new System.Drawing.Size(231, 40);
            this.btnInicio.TabIndex = 2;
            this.btnInicio.Text = "  Inicio";
            this.btnInicio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInicio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // PanelDivisorMenu
            // 
            this.PanelDivisorMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(47)))), ((int)(((byte)(103)))));
            this.PanelDivisorMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelDivisorMenu.Location = new System.Drawing.Point(0, 152);
            this.PanelDivisorMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanelDivisorMenu.Name = "PanelDivisorMenu";
            this.PanelDivisorMenu.Size = new System.Drawing.Size(231, 3);
            this.PanelDivisorMenu.TabIndex = 1;
            // 
            // PanelLogo
            // 
            this.PanelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.PanelLogo.Controls.Add(this.picLogoMenu);
            this.PanelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelLogo.Location = new System.Drawing.Point(0, 0);
            this.PanelLogo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanelLogo.Name = "PanelLogo";
            this.PanelLogo.Padding = new System.Windows.Forms.Padding(11, 8, 11, 8);
            this.PanelLogo.Size = new System.Drawing.Size(231, 152);
            this.PanelLogo.TabIndex = 0;
            // 
            // picLogoMenu
            // 
            this.picLogoMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picLogoMenu.Image = global::Presentacion.Properties.Resources.LogoIcono;
            this.picLogoMenu.Location = new System.Drawing.Point(11, 8);
            this.picLogoMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picLogoMenu.Name = "picLogoMenu";
            this.picLogoMenu.Size = new System.Drawing.Size(209, 136);
            this.picLogoMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogoMenu.TabIndex = 0;
            this.picLogoMenu.TabStop = false;
            // 
            // PanelBarraTitulo
            // 
            this.PanelBarraTitulo.BackColor = System.Drawing.Color.White;
            this.PanelBarraTitulo.Controls.Add(this.btnMenu);
            this.PanelBarraTitulo.Controls.Add(this.lblTituloPantalla);
            this.PanelBarraTitulo.Controls.Add(this.btnMinimizar);
            this.PanelBarraTitulo.Controls.Add(this.btnMaximizar);
            this.PanelBarraTitulo.Controls.Add(this.btnRestaurar);
            this.PanelBarraTitulo.Controls.Add(this.btnCerrar);
            this.PanelBarraTitulo.Controls.Add(this.PanelLineaTitulo);
            this.PanelBarraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelBarraTitulo.Location = new System.Drawing.Point(231, 0);
            this.PanelBarraTitulo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanelBarraTitulo.Name = "PanelBarraTitulo";
            this.PanelBarraTitulo.Size = new System.Drawing.Size(1137, 40);
            this.PanelBarraTitulo.TabIndex = 1;
            this.PanelBarraTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelBarraTitulo_MouseDown);
            // 
            // btnMenu
            // 
            this.btnMenu.BackColor = System.Drawing.Color.White;
            this.btnMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(47)))), ((int)(((byte)(103)))));
            this.btnMenu.IconChar = FontAwesome.Sharp.IconChar.Navicon;
            this.btnMenu.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(47)))), ((int)(((byte)(103)))));
            this.btnMenu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMenu.IconSize = 26;
            this.btnMenu.Location = new System.Drawing.Point(13, 6);
            this.btnMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(28, 26);
            this.btnMenu.TabIndex = 0;
            this.btnMenu.TabStop = false;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // lblTituloPantalla
            // 
            this.lblTituloPantalla.AutoSize = true;
            this.lblTituloPantalla.Font = new System.Drawing.Font("Segoe UI Semibold", 13F);
            this.lblTituloPantalla.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(47)))), ((int)(((byte)(103)))));
            this.lblTituloPantalla.Location = new System.Drawing.Point(55, 6);
            this.lblTituloPantalla.Name = "lblTituloPantalla";
            this.lblTituloPantalla.Size = new System.Drawing.Size(120, 30);
            this.lblTituloPantalla.TabIndex = 1;
            this.lblTituloPantalla.Text = "Inicio";
            this.lblTituloPantalla.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelBarraTitulo_MouseDown);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizar.BackColor = System.Drawing.Color.White;
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(85)))), ((int)(((byte)(98)))));
            this.btnMinimizar.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.btnMinimizar.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(85)))), ((int)(((byte)(98)))));
            this.btnMinimizar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMinimizar.IconSize = 22;
            this.btnMinimizar.Location = new System.Drawing.Point(1022, 8);
            this.btnMinimizar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(25, 22);
            this.btnMinimizar.TabIndex = 2;
            this.btnMinimizar.TabStop = false;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // btnMaximizar
            // 
            this.btnMaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximizar.BackColor = System.Drawing.Color.White;
            this.btnMaximizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaximizar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(85)))), ((int)(((byte)(98)))));
            this.btnMaximizar.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            this.btnMaximizar.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(85)))), ((int)(((byte)(98)))));
            this.btnMaximizar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMaximizar.IconSize = 22;
            this.btnMaximizar.Location = new System.Drawing.Point(1060, 8);
            this.btnMaximizar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMaximizar.Name = "btnMaximizar";
            this.btnMaximizar.Size = new System.Drawing.Size(25, 22);
            this.btnMaximizar.TabIndex = 3;
            this.btnMaximizar.TabStop = false;
            this.btnMaximizar.Click += new System.EventHandler(this.btnMaximizar_Click);
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestaurar.BackColor = System.Drawing.Color.White;
            this.btnRestaurar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestaurar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(85)))), ((int)(((byte)(98)))));
            this.btnRestaurar.IconChar = FontAwesome.Sharp.IconChar.WindowRestore;
            this.btnRestaurar.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(85)))), ((int)(((byte)(98)))));
            this.btnRestaurar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRestaurar.IconSize = 22;
            this.btnRestaurar.Location = new System.Drawing.Point(1060, 8);
            this.btnRestaurar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(25, 22);
            this.btnRestaurar.TabIndex = 4;
            this.btnRestaurar.TabStop = false;
            this.btnRestaurar.Visible = false;
            this.btnRestaurar.Click += new System.EventHandler(this.btnRestaurar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.White;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(85)))), ((int)(((byte)(98)))));
            this.btnCerrar.IconChar = FontAwesome.Sharp.IconChar.Remove;
            this.btnCerrar.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(85)))), ((int)(((byte)(98)))));
            this.btnCerrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCerrar.IconSize = 22;
            this.btnCerrar.Location = new System.Drawing.Point(1097, 8);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(25, 22);
            this.btnCerrar.TabIndex = 5;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // PanelLineaTitulo
            // 
            this.PanelLineaTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(228)))), ((int)(((byte)(232)))));
            this.PanelLineaTitulo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelLineaTitulo.Location = new System.Drawing.Point(0, 38);
            this.PanelLineaTitulo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanelLineaTitulo.Name = "PanelLineaTitulo";
            this.PanelLineaTitulo.Size = new System.Drawing.Size(1137, 2);
            this.PanelLineaTitulo.TabIndex = 6;
            // 
            // PanelContenedor
            // 
            this.PanelContenedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.PanelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelContenedor.Location = new System.Drawing.Point(231, 40);
            this.PanelContenedor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanelContenedor.Name = "PanelContenedor";
            this.PanelContenedor.Size = new System.Drawing.Size(1137, 698);
            this.PanelContenedor.TabIndex = 2;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1368, 738);
            this.Controls.Add(this.PanelContenedor);
            this.Controls.Add(this.PanelBarraTitulo);
            this.Controls.Add(this.PanelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ópticas Visión Guatemala";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.PanelMenu.ResumeLayout(false);
            this.PanelUsuario.ResumeLayout(false);
            this.PanelUsuario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icoUsuario)).EndInit();
            this.PanelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogoMenu)).EndInit();
            this.PanelBarraTitulo.ResumeLayout(false);
            this.PanelBarraTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestaurar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelMenu;
        private System.Windows.Forms.Panel PanelLogo;
        private System.Windows.Forms.PictureBox picLogoMenu;
        private System.Windows.Forms.Panel PanelDivisorMenu;
        private FontAwesome.Sharp.IconButton btnInicio;
        private FontAwesome.Sharp.IconButton btnSucursales;
        private FontAwesome.Sharp.IconButton btnUsuarios;
        private FontAwesome.Sharp.IconButton btnClientes;
        private FontAwesome.Sharp.IconButton btnCitas;
        private FontAwesome.Sharp.IconButton btnOptometristas;
        private FontAwesome.Sharp.IconButton btnExamenes;
        private FontAwesome.Sharp.IconButton btnRecetas;
        private FontAwesome.Sharp.IconButton btnTiposProducto;
        private FontAwesome.Sharp.IconButton btnProductos;
        private FontAwesome.Sharp.IconButton btnOrdenes;
        private FontAwesome.Sharp.IconButton btnEntregas;
        private System.Windows.Forms.Panel PanelUsuario;
        private FontAwesome.Sharp.IconPictureBox icoUsuario;
        private System.Windows.Forms.Label lblNombreUsuario;
        private System.Windows.Forms.Label lblRolUsuario;
        private System.Windows.Forms.Label lblSucursalUsuario;
        private System.Windows.Forms.Panel PanelBarraTitulo;
        private FontAwesome.Sharp.IconPictureBox btnMenu;
        private System.Windows.Forms.Label lblTituloPantalla;
        private FontAwesome.Sharp.IconPictureBox btnMinimizar;
        private FontAwesome.Sharp.IconPictureBox btnMaximizar;
        private FontAwesome.Sharp.IconPictureBox btnRestaurar;
        private FontAwesome.Sharp.IconPictureBox btnCerrar;
        private System.Windows.Forms.Panel PanelLineaTitulo;
        private System.Windows.Forms.Panel PanelContenedor;
    }
}
```

## 6. Código del formulario (`FrmPrincipal.cs`)

```csharp
using FontAwesome.Sharp;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmPrincipal : Form
    {
        // =====================================================
        // FUNCIONES DE WINDOWS
        // Permiten mover el formulario (que no tiene borde)
        // arrastrando la barra de título.
        // =====================================================

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        // =====================================================
        // POO: ENCAPSULAMIENTO
        // =====================================================

        // Pantalla que se está mostrando en el panel contenedor
        private Form _formularioActivo = null;

        // Ancho original del menú lateral
        private int _anchoMenu;

        // Colores del sistema (salen del logo)
        private readonly Color _colorMenu = Color.FromArgb(3, 47, 103);
        private readonly Color _colorSeleccionado = Color.FromArgb(101, 114, 122);

        // =====================================================
        // POO: CONSTRUCTOR
        // =====================================================

        public FrmPrincipal()
        {
            InitializeComponent();
            _anchoMenu = PanelMenu.Width;
        }

        // =====================================================
        // EVENTO LOAD DEL FORMULARIO
        // =====================================================

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            // Al iniciar el sistema se muestra la pantalla de Inicio (FrmDashboard)
            MtdResaltarBoton(btnInicio);
            MtdAbrirFormulario(new FrmDashboard(), "Inicio");
        }

        // =====================================================
        // ABRIR UNA PANTALLA DENTRO DEL PANEL CONTENEDOR
        // =====================================================

        private void MtdAbrirFormulario(Form formulario, string titulo)
        {
            // Guardar la pantalla anterior y cambiar a la nueva
            Form formularioAnterior = _formularioActivo;
            _formularioActivo = formulario;

            // Cerrar la pantalla que estaba abierta
            if (formularioAnterior != null && !formularioAnterior.IsDisposed)
            {
                formularioAnterior.Close();
            }

            // La pantalla se muestra dentro del panel, sin borde
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            formulario.FormClosed += MtdFormularioCerrado;

            PanelContenedor.Controls.Add(formulario);
            formulario.BringToFront();
            formulario.Show();

            lblTituloPantalla.Text = titulo;
        }

        // Si se cierra una pantalla (botón Cerrar), se regresa a Inicio
        private void MtdFormularioCerrado(object sender, FormClosedEventArgs e)
        {
            if (sender == _formularioActivo && !(sender is FrmDashboard))
            {
                MtdResaltarBoton(btnInicio);
                MtdAbrirFormulario(new FrmDashboard(), "Inicio");
            }
        }

        // =====================================================
        // RESALTAR EL BOTÓN SELECCIONADO DEL MENÚ
        // =====================================================

        private void MtdResaltarBoton(IconButton botonSeleccionado)
        {
            // Regresar todos los botones del menú a su color normal
            foreach (Control control in PanelMenu.Controls)
            {
                if (control is IconButton)
                {
                    control.BackColor = _colorMenu;
                }
            }

            // Pintar el botón seleccionado
            botonSeleccionado.BackColor = _colorSeleccionado;
        }

        // Mensaje para las pantallas que todavía no existen
        private void MtdPantallaPendiente(string nombrePantalla)
        {
            MessageBox.Show("La pantalla de " + nombrePantalla + " todavía no está creada.", "En construcción",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // =====================================================
        // BOTONES DEL MENÚ
        // =====================================================

        private void btnInicio_Click(object sender, EventArgs e)
        {
            MtdResaltarBoton(btnInicio);
            MtdAbrirFormulario(new FrmDashboard(), "Inicio");
        }

        private void btnSucursales_Click(object sender, EventArgs e)
        {
            MtdPantallaPendiente("Sucursales");
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            MtdPantallaPendiente("Usuarios");
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            MtdPantallaPendiente("Clientes");
        }

        private void btnCitas_Click(object sender, EventArgs e)
        {
            MtdPantallaPendiente("Citas");
        }

        private void btnOptometristas_Click(object sender, EventArgs e)
        {
            MtdResaltarBoton(btnOptometristas);
            MtdAbrirFormulario(new FrmOptometrista(), "Optometristas");
        }

        private void btnExamenes_Click(object sender, EventArgs e)
        {
            MtdResaltarBoton(btnExamenes);
            MtdAbrirFormulario(new FrmExamenVisual(), "Exámenes Visuales");
        }

        private void btnRecetas_Click(object sender, EventArgs e)
        {
            MtdResaltarBoton(btnRecetas);
            MtdAbrirFormulario(new FrmReceta(), "Recetas");
        }

        private void btnTiposProducto_Click(object sender, EventArgs e)
        {
            MtdPantallaPendiente("Tipos de Producto");
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            MtdPantallaPendiente("Productos Ópticos");
        }

        private void btnOrdenes_Click(object sender, EventArgs e)
        {
            MtdPantallaPendiente("Órdenes");
        }

        private void btnEntregas_Click(object sender, EventArgs e)
        {
            MtdPantallaPendiente("Entregas");
        }

        // =====================================================
        // BARRA DE TÍTULO
        // =====================================================

        // Botón hamburguesa: esconde o muestra el menú
        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (PanelMenu.Width == _anchoMenu)
            {
                PanelMenu.Width = 70;
            }
            else
            {
                PanelMenu.Width = _anchoMenu;
            }
        }

        // Mover la ventana arrastrando la barra de título
        private void PanelBarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            // Para que al maximizar no tape la barra de tareas de Windows
            this.MaximizedBounds = Screen.FromControl(this).WorkingArea;
            this.WindowState = FormWindowState.Maximized;

            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;

            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
```
