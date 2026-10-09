# 07 · Lógica del formulario (Presentación)

> **Úsalo para darle funcionamiento** a una pantalla ya diseñada con `02_DISENO_CRUD.md`:
> eventos de los botones, llenar el DataGridView, seleccionar registros, limpiar,
> ComboBox de llaves foráneas, exportar e imprimir.
> Requiere que ya existan las clases de `04_CAPA_ENTIDAD.md`, `05_CAPA_DATOS.md` y `06_CAPA_NEGOCIO.md`.
> Presentación solo usa **Negocio** y **Entidad** (nunca Datos ni SqlConnection).
> La pantalla se abre dentro de `FrmPrincipal`: su botón **Cerrar** (`this.Close()`) regresa al Dashboard.

## 1. Archivo

- `src/Presentacion/Frm{Tabla}.cs` → se reemplaza el `.cs` de solo diseño por esta plantilla.
- En `Frm{Tabla}.Designer.cs` se agregan las líneas de eventos (sección 2).

## 2. Eventos que se agregan al Designer

Cada línea va dentro de la sección de su control (después de `UseVisualStyleBackColor`) y
la del `Load` en la sección del formulario (después de `this.Text = …`):

```csharp
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            this.btnLimpiarBusqueda.Click += new System.EventHandler(this.btnLimpiarBusqueda_Click);
            this.chkSeleccionar.CheckedChanged += new System.EventHandler(this.chkSeleccionar_CheckedChanged);
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            this.dgv{Tabla}.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv{Tabla}_CellClick);
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            this.btnCerrarGestionar.Click += new System.EventHandler(this.btnCerrarGestionar_Click);
            this.Load += new System.EventHandler(this.Frm{Tabla}_Load);
```

## 3. Plantilla `Frm{Tabla}.cs` con lógica (ejemplo Optometrista)

```csharp
using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmOptometrista : Form
    {
        // =====================================================
        // POO: COMPOSICIÓN
        // Instancia de la capa Negocio
        // =====================================================

        private readonly OptometristaNegocio _optometristaNegocio = new OptometristaNegocio();
        private readonly UtilidadesGrid _utilidadesGrid = new UtilidadesGrid();

        // =====================================================
        // POO: CONSTRUCTOR
        // =====================================================

        public FrmOptometrista()
        {
            InitializeComponent();
        }

        // =====================================================
        // EVENTO LOAD DEL FORMULARIO
        // =====================================================

        private void FrmOptometrista_Load(object sender, EventArgs e)
        {
            // Las columnas ya están creadas en el diseño
            dgvOptometrista.AutoGenerateColumns = false;

            // [FK] Cargar los ComboBox de llaves foráneas (ver B.7)

            // Muestra los datos en el DataGridView
            MtdConsultar();
            MtdLimpiar();
        }

        // =====================================================
        // CRUD: CONSULTAR
        // =====================================================

        private void MtdConsultar()
        {
            try
            {
                List<OptometristaEntidad> listaOptometrista = _optometristaNegocio.MtdConsultar();

                dgvOptometrista.DataSource = null;
                dgvOptometrista.DataSource = listaOptometrista;
                dgvOptometrista.ClearSelection();

                lblTotalRegistros.Text = "Total Registros: " + listaOptometrista.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =====================================================
        // CRUD: AGREGAR
        // POO: BOTON GUARDAR
        // =====================================================

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Obtener el estado desde los RadioButton
                string estado = "Inactivo";
                if (rdbActivo.Checked)
                {
                    estado = "Activo";
                }

                // 2. Crear el objeto usando el constructor para 'Agregar'
                OptometristaEntidad optometrista = new OptometristaEntidad(
                    txtNombres.Text.Trim(),
                    txtApellidos.Text.Trim(),
                    txtNumeroColegiado.Text.Trim(),
                    txtTelefono.Text.Trim(),
                    txtCorreo.Text.Trim(),
                    estado
                );

                // 3. Guardar el registro a través de la capa de negocio
                bool resultado = _optometristaNegocio.MtdAgregar(optometrista);

                if (resultado)
                {
                    MessageBox.Show("Optometrista agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    MtdConsultar();
                    MtdLimpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =====================================================
        // CRUD: EDITAR
        // =====================================================

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int codigoOptometrista;

                if (!int.TryParse(txtCodigoOptometrista.Text, out codigoOptometrista))
                {
                    MessageBox.Show("Debe seleccionar un optometrista.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string estado = "Inactivo";
                if (rdbActivo.Checked)
                {
                    estado = "Activo";
                }

                // POO: Crear una instancia de la entidad (constructor con código)
                OptometristaEntidad optometrista = new OptometristaEntidad(
                    codigoOptometrista,
                    txtNombres.Text.Trim(),
                    txtApellidos.Text.Trim(),
                    txtNumeroColegiado.Text.Trim(),
                    txtTelefono.Text.Trim(),
                    txtCorreo.Text.Trim(),
                    estado
                );

                bool resultado = _optometristaNegocio.MtdEditar(optometrista);

                if (resultado)
                {
                    MessageBox.Show("Optometrista editado correctamente.", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    MtdConsultar();
                    chkSeleccionar.Checked = false;
                    MtdLimpiar();
                    tabControl1.SelectedTab = tabPage1;
                }
                else
                {
                    MessageBox.Show("No se encontró el optometrista que desea editar.", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =====================================================
        // CRUD: ELIMINAR
        // =====================================================

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int codigoOptometrista;

                if (!int.TryParse(txtCodigoOptometrista.Text, out codigoOptometrista))
                {
                    MessageBox.Show("Debe seleccionar un optometrista.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Solicitar confirmación al usuario
                DialogResult respuesta = MessageBox.Show("¿Está seguro de eliminar el optometrista seleccionado?", "Confirmar eliminación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.No)
                {
                    return;
                }

                bool resultado = _optometristaNegocio.MtdEliminar(codigoOptometrista);

                if (resultado)
                {
                    MessageBox.Show("Optometrista eliminado correctamente.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    MtdConsultar();
                    chkSeleccionar.Checked = false;
                    MtdLimpiar();
                    tabControl1.SelectedTab = tabPage1;
                }
                else
                {
                    MessageBox.Show("No fue posible eliminar el optometrista.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =====================================================
        // CRUD: BUSCAR
        // =====================================================

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int codigoOptometrista;

                if (string.IsNullOrWhiteSpace(txtBuscador.Text))
                {
                    MessageBox.Show("Debe ingresar el código del optometrista.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBuscador.Focus();
                    return;
                }

                if (!int.TryParse(txtBuscador.Text.Trim(), out codigoOptometrista))
                {
                    MessageBox.Show("El código debe contener solamente números.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBuscador.SelectAll();
                    txtBuscador.Focus();
                    return;
                }

                OptometristaEntidad optometristaEncontrado = _optometristaNegocio.MtdBuscar(codigoOptometrista);

                if (optometristaEncontrado == null)
                {
                    MessageBox.Show("No se encontró un optometrista con el código ingresado.", "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dgvOptometrista.DataSource = null;
                    lblTotalRegistros.Text = "Total Registros: 0";
                    txtBuscador.SelectAll();
                    txtBuscador.Focus();
                    return;
                }

                // POO: Crear una colección con el objeto encontrado
                List<OptometristaEntidad> listaResultado = new List<OptometristaEntidad>();
                listaResultado.Add(optometristaEncontrado);

                dgvOptometrista.DataSource = null;
                dgvOptometrista.DataSource = listaResultado;
                dgvOptometrista.ClearSelection();

                lblTotalRegistros.Text = "Total Registros: " + listaResultado.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            txtBuscador.Clear();
            MtdConsultar();
        }

        // =====================================================
        // SELECCIONAR UN REGISTRO DEL DATAGRIDVIEW
        // =====================================================

        private void chkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkSeleccionar.Checked)
            {
                // Limpiar cualquier fila seleccionada
                dgvOptometrista.ClearSelection();
            }
        }

        private void dgvOptometrista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar si el CheckBox está activado
            if (!chkSeleccionar.Checked)
            {
                dgvOptometrista.ClearSelection();
                return;
            }

            // Evitar seleccionar el encabezado
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow filaSeleccionada = dgvOptometrista.Rows[e.RowIndex];

            // Llenar los controles de la pestaña Gestionar
            txtCodigoOptometrista.Text = filaSeleccionada.Cells["colCodigoOptometrista"].Value.ToString();
            txtNombres.Text = filaSeleccionada.Cells["colNombres"].Value.ToString();
            txtApellidos.Text = filaSeleccionada.Cells["colApellidos"].Value.ToString();
            txtNumeroColegiado.Text = filaSeleccionada.Cells["colNumeroColegiado"].Value.ToString();
            txtTelefono.Text = filaSeleccionada.Cells["colTelefono"].Value.ToString();
            txtCorreo.Text = filaSeleccionada.Cells["colCorreo"].Value.ToString();

            string estado = filaSeleccionada.Cells["colEstado"].Value.ToString();
            rdbActivo.Checked = estado == "Activo";
            rdbInactivo.Checked = estado != "Activo";

            // Con un registro cargado solo se puede Editar o Eliminar
            btnGuardar.Enabled = false;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;

            // Mostrar automáticamente el Tab Gestionar
            tabControl1.SelectedTab = tabPage2;
        }

        // =====================================================
        // MÉTODO PARA LIMPIAR LOS CONTROLES
        // =====================================================

        private void MtdLimpiar()
        {
            txtCodigoOptometrista.Clear();
            txtNombres.Clear();
            txtApellidos.Clear();
            txtNumeroColegiado.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            rdbActivo.Checked = true;

            // Registro nuevo: solo se puede Guardar
            btnGuardar.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;

            txtNombres.Focus();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            chkSeleccionar.Checked = false;
            MtdLimpiar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            MtdLimpiar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            chkSeleccionar.Checked = false;
            MtdLimpiar();
            tabControl1.SelectedTab = tabPage1;
        }

        // =====================================================
        // EXPORTAR E IMPRIMIR
        // =====================================================

        private void btnExportar_Click(object sender, EventArgs e)
        {
            _utilidadesGrid.MtdExportar(dgvOptometrista, "Optometristas");
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            _utilidadesGrid.MtdImprimir(dgvOptometrista, "Listado de Optometristas");
        }

        // =====================================================
        // CERRAR
        // =====================================================

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCerrarGestionar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
```

## 4. Cómo leer/llenar cada tipo de control

| Control | Al guardar (control → entidad) | Al seleccionar fila (celda → control) | En MtdLimpiar |
|---|---|---|---|
| TextBox | `txtX.Text.Trim()` | `txtX.Text = fila.Cells["colX"].Value.ToString();` | `txtX.Clear();` |
| ComboBox FK | `Convert.ToInt32(cboX.SelectedValue)` (sin selección = 0) | `cboX.SelectedValue = Convert.ToInt32(fila.Cells["colCodigoX"].Value);` | `cboX.SelectedIndex = -1;` |
| ComboBox FK opcional | igual (0 = sin valor) | `int codigo = Convert.ToInt32(...); if (codigo > 0) { cboX.SelectedValue = codigo; } else { cboX.SelectedIndex = -1; }` | `cboX.SelectedIndex = -1;` |
| ComboBox lista fija | `cboX.Text` | `cboX.SelectedItem = fila.Cells["colX"].Value.ToString();` | `cboX.SelectedIndex = -1;` |
| DateTimePicker fecha | `dtpX.Value.Date` | `dtpX.Value = Convert.ToDateTime(fila.Cells["colX"].Value);` | `dtpX.Value = DateTime.Now;` |
| DateTimePicker hora | `new TimeSpan(dtpX.Value.Hour, dtpX.Value.Minute, 0)` | `dtpX.Value = DateTime.Today.Add((TimeSpan)fila.Cells["colX"].Value);` | `dtpX.Value = DateTime.Now;` |
| NumericUpDown decimal | `nudX.Value` | `nudX.Value = Convert.ToDecimal(fila.Cells["colX"].Value);` | `nudX.Value = 0;` |
| NumericUpDown entero | `Convert.ToInt32(nudX.Value)` | `nudX.Value = Convert.ToDecimal(fila.Cells["colX"].Value);` | `nudX.Value = 0;` |
| RadioButton estado | `string estado = "Inactivo"; if (rdbActivo.Checked) { estado = "Activo"; }` | `rdbActivo.Checked = estado == "Activo"; rdbInactivo.Checked = estado != "Activo";` | `rdbActivo.Checked = true;` |

## 5. ComboBox de llaves foráneas

En el Load (antes de `MtdConsultar()`), un método por cada FK. Se usa la capa **Negocio**
de la tabla relacionada:

```csharp
        // =====================================================
        // CARGAR COMBOBOX DE LLAVES FORÁNEAS
        // =====================================================

        private void MtdCargarClientes()
        {
            try
            {
                cboCliente.DataSource = null;
                cboCliente.DisplayMember = "NombreCompleto";
                cboCliente.ValueMember = "CodigoCliente";
                cboCliente.DataSource = _clienteNegocio.MtdConsultar();
                cboCliente.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
```

(con `private readonly ClienteNegocio _clienteNegocio = new ClienteNegocio();` arriba).

El texto que se muestra (`DisplayMember`) sale de `01_BASE_DE_DATOS.md`. Si la tabla
relacionada no tiene columna "Nombre", agregar en su Entidad la propiedad de solo lectura
de `04_CAPA_ENTIDAD.md` (sección 3).

Si la Entidad/Datos/Negocio de la tabla relacionada **todavía no existe** (es de otro
integrante), crear sus tres capas completas con esta misma guía (sin formulario) y
**avisar al usuario** que esa tabla le pertenece a otro integrante, para que no se duplique.
