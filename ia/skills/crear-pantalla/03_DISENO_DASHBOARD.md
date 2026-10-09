# 03 · Diseño de Dashboard

> **Úsalo para el diseño** del Dashboard. Hay dos diseños:
> - **Diseño A – Bienvenida** (el que se usa ahora en `FrmDashboard`): solo el texto del logo
>   (sin el ojo) translúcido y la palabra "Bienvenidos". Es la pantalla de **Inicio** (botón Inicio del menú) que se abre dentro del
>   menú principal (`09_DISENO_MENU_PRINCIPAL.md`).
> - **Diseño B – Tarjetas y gráficas** (guardado para después): filtros, 6 tarjetas de
>   totales y 2 gráficas. Usarlo solo si el usuario lo pide.
> No es CRUD: no lleva pestañas Consultar/Gestionar.

---

# DISEÑO A – Bienvenida (actual)

## A.1 Estructura

```
FrmDashboard (ClientSize 1279x872, BackColor 253,252,250)
└── PanelPrincipal (Dock Fill, BackColor 253,252,250)
    ├── picLogoFondo   (800x341 en 240,200, Anchor None, Zoom) → Properties.Resources.LogoTranslucido (solo el texto del logo, sin el ojo)
    └── lblBienvenidos (700x100 en 290,571, Anchor None) → "Bienvenidos", Segoe UI Semibold 40F, Marino (3,47,103), centrado
```

- `Anchor = None` mantiene el logo y el texto **centrados** aunque la ventana cambie de tamaño.
- `LogoTranslucido.png` es el **texto** del logo de la empresa (sin el ojo) al 25 % de opacidad sobre el color de fondo
  (se generó a partir de `src/Presentacion/Resources/logo_original.png`). Si cambia el logo, regenerarlo igual.
- No lleva encabezado, ni botones, ni gráficas: **nada más**.

## A.2 Código del Designer

```csharp
        private void InitializeComponent()
        {
            this.PanelPrincipal = new System.Windows.Forms.Panel();
            this.picLogoFondo = new System.Windows.Forms.PictureBox();
            this.lblBienvenidos = new System.Windows.Forms.Label();
            this.PanelPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoFondo)).BeginInit();
            this.SuspendLayout();
            //
            // PanelPrincipal
            //
            this.PanelPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.PanelPrincipal.Controls.Add(this.picLogoFondo);
            this.PanelPrincipal.Controls.Add(this.lblBienvenidos);
            this.PanelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.PanelPrincipal.Name = "PanelPrincipal";
            this.PanelPrincipal.Size = new System.Drawing.Size(1279, 872);
            this.PanelPrincipal.TabIndex = 0;
            //
            // picLogoFondo
            //
            this.picLogoFondo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picLogoFondo.Image = global::Presentacion.Properties.Resources.LogoTranslucido;
            this.picLogoFondo.Location = new System.Drawing.Point(240, 200);
            this.picLogoFondo.Name = "picLogoFondo";
            this.picLogoFondo.Size = new System.Drawing.Size(800, 341);
            this.picLogoFondo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogoFondo.TabIndex = 0;
            this.picLogoFondo.TabStop = false;
            //
            // lblBienvenidos
            //
            this.lblBienvenidos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblBienvenidos.Font = new System.Drawing.Font("Segoe UI Semibold", 40F);
            this.lblBienvenidos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(47)))), ((int)(((byte)(103)))));
            this.lblBienvenidos.Location = new System.Drawing.Point(290, 571);
            this.lblBienvenidos.Name = "lblBienvenidos";
            this.lblBienvenidos.Size = new System.Drawing.Size(700, 100);
            this.lblBienvenidos.TabIndex = 1;
            this.lblBienvenidos.Text = "Bienvenidos";
            this.lblBienvenidos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // FrmDashboard
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1279, 872);
            this.Controls.Add(this.PanelPrincipal);
            this.Name = "FrmDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.PanelPrincipal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogoFondo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelPrincipal;
        private System.Windows.Forms.PictureBox picLogoFondo;
        private System.Windows.Forms.Label lblBienvenidos;
```

El `.cs` solo lleva el constructor con `InitializeComponent();` (no tiene lógica).

---

# DISEÑO B – Tarjetas y gráficas (guardado, no se usa ahora)

> Si se vuelve a usar: agregar `<Reference Include="System.Windows.Forms.DataVisualization" />`
> en `Presentacion.csproj` (se quitó porque el Diseño A no tiene gráficas).

## B.1 Estructura y reglas

No es CRUD, no tiene pestañas. Estructura (1279x872, fondo 253,252,250):

```
PanelEncabezado Top 100 (logo + "Ópticas Visión Guatemala" + "Dashboard - Resumen general del sistema")
PanelDivisor1   Top 5 Marino (3,47,103)
PanelFiltros    Top 70  → lblSucursal + cboSucursal, lblDesde + dtpDesde, lblHasta + dtpHasta, btnActualizar (ArrowsRotate)
PanelTarjetas   Top 220 → tlpTarjetas (TableLayoutPanel 3x2) con 6 tarjetas KPI
PanelCentral    Fill    → tlpGraficas (TableLayoutPanel 2x1) con 2 tarjetas de gráfica
PanelInferior   Bottom 70 → lblUltimaActualizacion, btnCerrar
```

- **Tarjeta KPI** (`pnlTarjeta{X}`, blanca, `Dock Fill`, `Margin 8,5,8,5`): `pnlAcento{X}` (Dock Left,
  6 px, Marino (3,47,103)) + `ico{X}` (IconPictureBox 48x48 en 26,23, Marino (3,47,103)) + `lblTitulo{X}`
  (Segoe UI 10F, color 82,81,78, en 92,12, sin dos puntos) + `lblTotal{X}` (Segoe UI Semibold 22F,
  color 11,11,11, en 88,34, texto "0").
  Tarjetas actuales: Clientes registrados (Users), Citas programadas (CalendarCheck),
  Exámenes realizados (Eye), Recetas vigentes (FilePrescription), Órdenes en proceso
  (CartShopping), Entregas pendientes (Truck).
- **Tarjeta de gráfica** (`pnlGrafica{X}`, blanca, Padding 12,8,12,8): `lblGrafica{X}` (Dock Top,
  40 alto, Segoe UI Semibold 12F) + `chart{X}` (Dock Fill).
- **Reglas de gráficas** (guía de visualización): una sola serie → un solo color
  `FromArgb(42,120,214)`, sin leyenda (el título dice qué es), barras delgadas
  (`CustomProperties = "PointWidth=0.6"`), cuadrícula solo en el eje de valores en color
  `225,224,217`, ejes y etiquetas en gris `137,135,129` / `195,194,183`, sin 3D, tooltip
  `"#VALX: #VALY exámenes"`. Nunca dos ejes Y en una misma gráfica. Los textos van en
  colores de tinta (negro/gris), nunca del color de la serie.
  Gráficas actuales: "Exámenes visuales por mes" (Column) y "Exámenes por optometrista" (Bar).
- Requiere `<Reference Include="System.Windows.Forms.DataVisualization" />` en `Presentacion.csproj` (hay que agregarla, ver nota de arriba).

**Orden de `Controls.Add` en PanelPrincipal** (el Fill primero, igual que en el CRUD):
`PanelCentral, PanelDivisor4, PanelInferior, PanelDivisor3, PanelTarjetas, PanelDivisor2, PanelFiltros, PanelDivisor1, PanelEncabezado`.

Para agregar otra tarjeta: copiar el bloque de la sección B.4 cambiando `Clientes` por el
nombre nuevo, ponerla en una celda libre del `tlpTarjetas` (o agregar una fila) y cambiar
el `IconChar` y el texto. Para otra gráfica: copiar el bloque de la sección B.5; si es de
barras horizontales usar `ChartType = Bar` y `PointWidth=0.5`.

## B.2 Declaraciones de las gráficas (al inicio de `InitializeComponent`)

```csharp
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
```

## B.3 Fila de filtros

```csharp
            //
            // PanelFiltros
            //
            this.PanelFiltros.Controls.Add(this.lblSucursal);
            this.PanelFiltros.Controls.Add(this.cboSucursal);
            this.PanelFiltros.Controls.Add(this.lblDesde);
            this.PanelFiltros.Controls.Add(this.dtpDesde);
            this.PanelFiltros.Controls.Add(this.lblHasta);
            this.PanelFiltros.Controls.Add(this.dtpHasta);
            this.PanelFiltros.Controls.Add(this.btnActualizar);
            this.PanelFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelFiltros.Location = new System.Drawing.Point(0, 105);
            this.PanelFiltros.Name = "PanelFiltros";
            this.PanelFiltros.Size = new System.Drawing.Size(1279, 70);
            this.PanelFiltros.TabIndex = 2;
            //
            // lblSucursal
            //
            this.lblSucursal.AutoSize = true;
            this.lblSucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblSucursal.Location = new System.Drawing.Point(20, 21);
            this.lblSucursal.Name = "lblSucursal";
            this.lblSucursal.Size = new System.Drawing.Size(108, 29);
            this.lblSucursal.TabIndex = 0;
            this.lblSucursal.Text = "Sucursal:";
            //
            // cboSucursal
            //
            this.cboSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cboSucursal.FormattingEnabled = true;
            this.cboSucursal.Location = new System.Drawing.Point(135, 17);
            this.cboSucursal.Name = "cboSucursal";
            this.cboSucursal.Size = new System.Drawing.Size(300, 37);
            this.cboSucursal.TabIndex = 1;
            //
            // lblDesde
            //
            this.lblDesde.AutoSize = true;
            this.lblDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblDesde.Location = new System.Drawing.Point(465, 21);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(82, 29);
            this.lblDesde.TabIndex = 2;
            this.lblDesde.Text = "Desde:";
            //
            // dtpDesde
            //
            this.dtpDesde.CustomFormat = "dd/MM/yyyy";
            this.dtpDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDesde.Location = new System.Drawing.Point(555, 18);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(190, 35);
            this.dtpDesde.TabIndex = 3;
            //
            // lblHasta
            //
            this.lblHasta.AutoSize = true;
            this.lblHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblHasta.Location = new System.Drawing.Point(770, 21);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(76, 29);
            this.lblHasta.TabIndex = 4;
            this.lblHasta.Text = "Hasta:";
            //
            // dtpHasta
            //
            this.dtpHasta.CustomFormat = "dd/MM/yyyy";
            this.dtpHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHasta.Location = new System.Drawing.Point(855, 18);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(190, 35);
            this.dtpHasta.TabIndex = 5;
            //
            // btnActualizar
            //
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnActualizar.IconChar = FontAwesome.Sharp.IconChar.ArrowsRotate;
            this.btnActualizar.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(47)))), ((int)(((byte)(103)))));
            this.btnActualizar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnActualizar.IconSize = 28;
            this.btnActualizar.Location = new System.Drawing.Point(1089, 12);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(170, 45);
            this.btnActualizar.TabIndex = 6;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = true;
```

## B.4 Tarjetas KPI (contenedor + una tarjeta completa)

Cada tarjeta lleva `((System.ComponentModel.ISupportInitialize)(this.ico…)).BeginInit();`
al inicio y `EndInit();` al final, igual que los PictureBox.

```csharp
            //
            // PanelTarjetas
            //
            this.PanelTarjetas.Controls.Add(this.tlpTarjetas);
            this.PanelTarjetas.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTarjetas.Location = new System.Drawing.Point(0, 180);
            this.PanelTarjetas.Name = "PanelTarjetas";
            this.PanelTarjetas.Padding = new System.Windows.Forms.Padding(12, 5, 12, 5);
            this.PanelTarjetas.Size = new System.Drawing.Size(1279, 220);
            this.PanelTarjetas.TabIndex = 4;
            //
            // tlpTarjetas
            //
            this.tlpTarjetas.ColumnCount = 3;
            this.tlpTarjetas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpTarjetas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpTarjetas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpTarjetas.Controls.Add(this.pnlTarjetaClientes, 0, 0);
            this.tlpTarjetas.Controls.Add(this.pnlTarjetaCitas, 1, 0);
            this.tlpTarjetas.Controls.Add(this.pnlTarjetaExamenes, 2, 0);
            this.tlpTarjetas.Controls.Add(this.pnlTarjetaRecetas, 0, 1);
            this.tlpTarjetas.Controls.Add(this.pnlTarjetaOrdenes, 1, 1);
            this.tlpTarjetas.Controls.Add(this.pnlTarjetaEntregas, 2, 1);
            this.tlpTarjetas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTarjetas.Location = new System.Drawing.Point(12, 5);
            this.tlpTarjetas.Name = "tlpTarjetas";
            this.tlpTarjetas.RowCount = 2;
            this.tlpTarjetas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTarjetas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTarjetas.Size = new System.Drawing.Size(1255, 210);
            this.tlpTarjetas.TabIndex = 0;
            //
            // pnlTarjetaClientes
            //
            this.pnlTarjetaClientes.BackColor = System.Drawing.Color.White;
            this.pnlTarjetaClientes.Controls.Add(this.lblTotalClientes);
            this.pnlTarjetaClientes.Controls.Add(this.lblTituloClientes);
            this.pnlTarjetaClientes.Controls.Add(this.icoClientes);
            this.pnlTarjetaClientes.Controls.Add(this.pnlAcentoClientes);
            this.pnlTarjetaClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTarjetaClientes.Location = new System.Drawing.Point(8, 5);
            this.pnlTarjetaClientes.Margin = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.pnlTarjetaClientes.Name = "pnlTarjetaClientes";
            this.pnlTarjetaClientes.Size = new System.Drawing.Size(402, 95);
            this.pnlTarjetaClientes.TabIndex = 0;
            //
            // lblTotalClientes
            //
            this.lblTotalClientes.AutoSize = true;
            this.lblTotalClientes.Font = new System.Drawing.Font("Segoe UI Semibold", 22F);
            this.lblTotalClientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(11)))), ((int)(((byte)(11)))));
            this.lblTotalClientes.Location = new System.Drawing.Point(88, 34);
            this.lblTotalClientes.Name = "lblTotalClientes";
            this.lblTotalClientes.Size = new System.Drawing.Size(42, 59);
            this.lblTotalClientes.TabIndex = 3;
            this.lblTotalClientes.Text = "0";
            //
            // lblTituloClientes
            //
            this.lblTituloClientes.AutoSize = true;
            this.lblTituloClientes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTituloClientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(81)))), ((int)(((byte)(78)))));
            this.lblTituloClientes.Location = new System.Drawing.Point(92, 12);
            this.lblTituloClientes.Name = "lblTituloClientes";
            this.lblTituloClientes.Size = new System.Drawing.Size(190, 28);
            this.lblTituloClientes.TabIndex = 2;
            this.lblTituloClientes.Text = "Clientes registrados";
            //
            // icoClientes
            //
            this.icoClientes.BackColor = System.Drawing.Color.White;
            this.icoClientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(47)))), ((int)(((byte)(103)))));
            this.icoClientes.IconChar = FontAwesome.Sharp.IconChar.Users;
            this.icoClientes.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(47)))), ((int)(((byte)(103)))));
            this.icoClientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icoClientes.IconSize = 48;
            this.icoClientes.Location = new System.Drawing.Point(26, 23);
            this.icoClientes.Name = "icoClientes";
            this.icoClientes.Size = new System.Drawing.Size(48, 48);
            this.icoClientes.TabIndex = 1;
            this.icoClientes.TabStop = false;
            //
            // pnlAcentoClientes
            //
            this.pnlAcentoClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(47)))), ((int)(((byte)(103)))));
            this.pnlAcentoClientes.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlAcentoClientes.Location = new System.Drawing.Point(0, 0);
            this.pnlAcentoClientes.Name = "pnlAcentoClientes";
            this.pnlAcentoClientes.Size = new System.Drawing.Size(6, 95);
            this.pnlAcentoClientes.TabIndex = 0;
```

## B.5 Gráficas (contenedor + una tarjeta de gráfica completa)

Cada `Chart` lleva `((System.ComponentModel.ISupportInitialize)(this.chart…)).BeginInit();`
al inicio y `EndInit();` al final. Requiere la referencia
`<Reference Include="System.Windows.Forms.DataVisualization" />` en `Presentacion.csproj` (hay que agregarla).

```csharp
            //
            // tlpGraficas
            //
            this.tlpGraficas.ColumnCount = 2;
            this.tlpGraficas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGraficas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGraficas.Controls.Add(this.pnlGraficaExamenesMes, 0, 0);
            this.tlpGraficas.Controls.Add(this.pnlGraficaOptometristas, 1, 0);
            this.tlpGraficas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpGraficas.Location = new System.Drawing.Point(12, 5);
            this.tlpGraficas.Name = "tlpGraficas";
            this.tlpGraficas.RowCount = 1;
            this.tlpGraficas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpGraficas.Size = new System.Drawing.Size(1255, 377);
            this.tlpGraficas.TabIndex = 0;
            //
            // pnlGraficaExamenesMes
            //
            this.pnlGraficaExamenesMes.BackColor = System.Drawing.Color.White;
            this.pnlGraficaExamenesMes.Controls.Add(this.chartExamenesMes);
            this.pnlGraficaExamenesMes.Controls.Add(this.lblGraficaExamenesMes);
            this.pnlGraficaExamenesMes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGraficaExamenesMes.Location = new System.Drawing.Point(8, 5);
            this.pnlGraficaExamenesMes.Margin = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.pnlGraficaExamenesMes.Name = "pnlGraficaExamenesMes";
            this.pnlGraficaExamenesMes.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.pnlGraficaExamenesMes.Size = new System.Drawing.Size(611, 367);
            this.pnlGraficaExamenesMes.TabIndex = 0;
            //
            // chartExamenesMes
            //
            this.chartExamenesMes.BackColor = System.Drawing.Color.White;
            chartArea1.AxisX.Interval = 1D;
            chartArea1.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(135)))), ((int)(((byte)(129)))));
            chartArea1.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(194)))), ((int)(((byte)(183)))));
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.MajorTickMark.Enabled = false;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(135)))), ((int)(((byte)(129)))));
            chartArea1.AxisY.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(224)))), ((int)(((byte)(217)))));
            chartArea1.AxisY.MajorTickMark.Enabled = false;
            chartArea1.BackColor = System.Drawing.Color.White;
            chartArea1.Name = "ChartArea1";
            this.chartExamenesMes.ChartAreas.Add(chartArea1);
            this.chartExamenesMes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartExamenesMes.Location = new System.Drawing.Point(12, 48);
            this.chartExamenesMes.Name = "chartExamenesMes";
            this.chartExamenesMes.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(214)))));
            series1.CustomProperties = "PointWidth=0.6";
            series1.Name = "Examenes";
            series1.ToolTip = "#VALX: #VALY exámenes";
            this.chartExamenesMes.Series.Add(series1);
            this.chartExamenesMes.Size = new System.Drawing.Size(587, 311);
            this.chartExamenesMes.TabIndex = 1;
            this.chartExamenesMes.Text = "Exámenes visuales por mes";
            //
            // lblGraficaExamenesMes
            //
            this.lblGraficaExamenesMes.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGraficaExamenesMes.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.lblGraficaExamenesMes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(11)))), ((int)(((byte)(11)))));
            this.lblGraficaExamenesMes.Location = new System.Drawing.Point(12, 8);
            this.lblGraficaExamenesMes.Name = "lblGraficaExamenesMes";
            this.lblGraficaExamenesMes.Size = new System.Drawing.Size(587, 40);
            this.lblGraficaExamenesMes.TabIndex = 0;
            this.lblGraficaExamenesMes.Text = "Exámenes visuales por mes";
            this.lblGraficaExamenesMes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
```

## B.6 Parte inferior

```csharp
            //
            // PanelInferior
            //
            this.PanelInferior.Controls.Add(this.lblUltimaActualizacion);
            this.PanelInferior.Controls.Add(this.btnCerrar);
            this.PanelInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelInferior.Location = new System.Drawing.Point(0, 802);
            this.PanelInferior.Name = "PanelInferior";
            this.PanelInferior.Size = new System.Drawing.Size(1279, 70);
            this.PanelInferior.TabIndex = 7;
            //
            // lblUltimaActualizacion
            //
            this.lblUltimaActualizacion.AutoSize = true;
            this.lblUltimaActualizacion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblUltimaActualizacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(81)))), ((int)(((byte)(78)))));
            this.lblUltimaActualizacion.Location = new System.Drawing.Point(20, 23);
            this.lblUltimaActualizacion.Name = "lblUltimaActualizacion";
            this.lblUltimaActualizacion.Size = new System.Drawing.Size(220, 28);
            this.lblUltimaActualizacion.TabIndex = 0;
            this.lblUltimaActualizacion.Text = "Última actualización: --";
            //
            // btnCerrar
            //
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCerrar.IconChar = FontAwesome.Sharp.IconChar.RightFromBracket;
            this.btnCerrar.IconColor = System.Drawing.Color.Firebrick;
            this.btnCerrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCerrar.IconSize = 28;
            this.btnCerrar.Location = new System.Drawing.Point(1109, 12);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(150, 45);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCerrar.UseVisualStyleBackColor = true;
```
