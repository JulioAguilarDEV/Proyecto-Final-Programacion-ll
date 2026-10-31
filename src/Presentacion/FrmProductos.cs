using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmProductos : Form
    {
        private const int RegistrosPorPagina = 10;
        private readonly ProductoOpticoNegocio _productoOpticoNegocio = new ProductoOpticoNegocio();
        private readonly TipoProductoNegocio _tipoProductoNegocio = new TipoProductoNegocio();
        private readonly ToolTip _toolTipPaginacion = new ToolTip();
        private readonly ComboBox _cboTipoProducto = new ComboBox();
        private readonly Label _lblPaginaActual = new Label();
        private List<ProductoOpticoEntidad> _listaProductos = new List<ProductoOpticoEntidad>();
        private List<ProductoOpticoEntidad> _listaProductosVisibles = new List<ProductoOpticoEntidad>();
        private int _paginaActual;

        public FrmProductos()
        {
            InitializeComponent();

            MtdPrepararControles();

            Load += FrmProductos_Load;
            chkSeleccionar.CheckedChanged += chkSeleccionar_CheckedChanged;
            btnBuscar.Click += btnBuscar_Click;
            btnLimpiarBusqueda.Click += btnLimpiarBusqueda_Click;
            btnNuevo.Click += btnNuevo_Click;
            btnGuardar.Click += btnGuardar_Click;
            btnEditar.Click += btnEditar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnCancelar.Click += btnCancelar_Click;
            btnLimpiar.Click += btnLimpiar_Click;
            dgvProducto.KeyDown += dgvProducto_KeyDown;
            dgvProducto.CellClick += dgvProducto_CellClick;
        }

        private void MtdPrepararControles()
        {
            dgvProducto.AutoGenerateColumns = false;
            CodigoProducto.DataPropertyName = "CodigoProducto";
            CodigoTipoProducto.DataPropertyName = "CodigoTipoProducto";
            Nombre.DataPropertyName = "Nombre";
            Descripcion.DataPropertyName = "Descripcion";
            Marca.DataPropertyName = "Marca";
            Precio.DataPropertyName = "Precio";
            Estado.DataPropertyName = "Estado";

            _cboTipoProducto.Name = "cboTipoProducto";
            _cboTipoProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboTipoProducto.Location = cboxTipoProducto.Location;
            _cboTipoProducto.Size = cboxTipoProducto.Size;
            _cboTipoProducto.Font = cboxTipoProducto.Font;
            _cboTipoProducto.Anchor = cboxTipoProducto.Anchor;
            _cboTipoProducto.TabIndex = cboxTipoProducto.TabIndex;
            grpDatos.Controls.Add(_cboTipoProducto);
            _cboTipoProducto.BringToFront();
            cboxTipoProducto.Visible = false;
            cboxTipoProducto.TabStop = false;

            cboxNombreProducto.DropDownStyle = ComboBoxStyle.DropDown;
            cboxNombreProducto.MaxLength = 100;
            cboxMarca.DropDownStyle = ComboBoxStyle.DropDown;
            cboxMarca.MaxLength = 60;
            txtDescripcionProducto.MaxLength = 200;
            txtPrecio.MaxLength = 13;
            txtBuscador.MaxLength = 200;
            lblBuscar.Text = "Código o texto:";
            cboxEstadoProducto.Items.Clear();
            cboxEstadoProducto.Items.Add("Activo");
            cboxEstadoProducto.Items.Add("Inactivo");
            cboxEstadoProducto.SelectedIndex = 0;

            _lblPaginaActual.AutoSize = true;
            _lblPaginaActual.Font = new Font("Microsoft Sans Serif", 12F);
            _lblPaginaActual.Location = new Point(430, 29);
            _lblPaginaActual.Name = "lblPaginaActual";
            _lblPaginaActual.Text = "Página 0 de 0";
            PanelInferior.Controls.Add(_lblPaginaActual);

            _toolTipPaginacion.SetToolTip(
                dgvProducto,
                "Use Re Pág y Av Pág para cambiar de página. Se muestran 10 productos por página.");
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            MtdCargarCatalogoTipoProducto();
            MtdConsultar();
            MtdLimpiar();
        }

        private void MtdCargarCatalogoTipoProducto()
        {
            try
            {
                List<TipoProductoEntidad> listaTipos = _tipoProductoNegocio.MtdConsultar();

                _cboTipoProducto.DisplayMember = "CodigoTipoProducto";
                _cboTipoProducto.ValueMember = "CodigoTipoProducto";
                _cboTipoProducto.DataSource = listaTipos;
                _cboTipoProducto.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo cargar el catálogo de tipos de producto. " + ex.Message,
                    "Error de catálogo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void MtdConsultar()
        {
            try
            {
                _listaProductos = _productoOpticoNegocio.MtdConsultar();
                _listaProductosVisibles = new List<ProductoOpticoEntidad>(_listaProductos);
                _paginaActual = 0;
                MtdMostrarPagina();
            }
            catch (Exception ex)
            {
                dgvProducto.DataSource = null;
                _listaProductos.Clear();
                _listaProductosVisibles.Clear();
                lblTotalRegistros.Text = "Total Registros: 0";
                MtdActualizarControlesPaginacion();

                MessageBox.Show(
                    "No se pudo consultar la lista de productos ópticos. " + ex.Message,
                    "Error de consulta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void MtdMostrarPagina()
        {
            List<ProductoOpticoEntidad> listaPagina = new List<ProductoOpticoEntidad>();
            int primerRegistro = _paginaActual * RegistrosPorPagina;
            int ultimoRegistro = Math.Min(
                primerRegistro + RegistrosPorPagina,
                _listaProductosVisibles.Count);

            for (int indice = primerRegistro; indice < ultimoRegistro; indice++)
            {
                listaPagina.Add(_listaProductosVisibles[indice]);
            }

            dgvProducto.DataSource = null;
            dgvProducto.DataSource = listaPagina;
            dgvProducto.ClearSelection();

            // El total refleja todos los resultados actuales, no solo la página visible.
            lblTotalRegistros.Text = "Total Registros: " + _listaProductosVisibles.Count;
            MtdActualizarControlesPaginacion();
        }

        private int MtdObtenerTotalPaginas()
        {
            return (_listaProductosVisibles.Count + RegistrosPorPagina - 1) / RegistrosPorPagina;
        }

        private void MtdActualizarControlesPaginacion()
        {
            int totalPaginas = MtdObtenerTotalPaginas();

            if (totalPaginas == 0)
            {
                _lblPaginaActual.Text = "Página 0 de 0";
            }
            else
            {
                _lblPaginaActual.Text = "Página " + (_paginaActual + 1) + " de " + totalPaginas;
            }
        }

        private void MtdCambiarPagina(int cambio)
        {
            int nuevaPagina = _paginaActual + cambio;

            if (nuevaPagina < 0 || nuevaPagina >= MtdObtenerTotalPaginas())
            {
                return;
            }

            _paginaActual = nuevaPagina;
            MtdMostrarPagina();
        }

        private void dgvProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.PageDown)
            {
                MtdCambiarPagina(1);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.PageUp)
            {
                MtdCambiarPagina(-1);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscador.Text))
            {
                MessageBox.Show(
                    "Ingrese un código, nombre, descripción o marca para buscar.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtBuscador.Focus();
                return;
            }

            try
            {
                _listaProductosVisibles = _productoOpticoNegocio.MtdBuscar(txtBuscador.Text.Trim());
                _paginaActual = 0;
                MtdMostrarPagina();

                if (_listaProductosVisibles.Count == 0)
                {
                    MessageBox.Show(
                        "No se encontraron productos que coincidan con el filtro.",
                        "Búsqueda",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error al buscar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            txtBuscador.Clear();
            _listaProductosVisibles = new List<ProductoOpticoEntidad>(_listaProductos);
            _paginaActual = 0;
            MtdMostrarPagina();
        }

        // ===== CRUD: CARGAR LOS DATOS SELECCIONADOS PARA EDITAR =====
        private void dgvProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!chkSeleccionar.Checked || e.RowIndex < 0)
            {
                dgvProducto.ClearSelection();
                return;
            }

            int indiceProducto = (_paginaActual * RegistrosPorPagina) + e.RowIndex;
            if (indiceProducto >= _listaProductosVisibles.Count)
            {
                return;
            }

            ProductoOpticoEntidad producto = _listaProductosVisibles[indiceProducto];

            txtCodigoExamen.Text = producto.CodigoProducto.ToString();
            cboxNombreProducto.Text = producto.Nombre;
            txtDescripcionProducto.Text = producto.Descripcion;
            txtPrecio.Text = producto.Precio.ToString("0.00");
            cboxMarca.Text = producto.Marca;
            cboxEstadoProducto.SelectedItem = producto.Estado;

            if (_cboTipoProducto.DataSource != null)
            {
                _cboTipoProducto.SelectedValue = producto.CodigoTipoProducto;
            }

            btnGuardar.Enabled = false;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            tabControl1.SelectedTab = tabPage2;
        }

        private void chkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkSeleccionar.Checked)
            {
                dgvProducto.ClearSelection();
            }
        }

        // ===== CRUD: AGREGAR =====
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ProductoOpticoEntidad producto = MtdObtenerDatosFormulario();

                if (_productoOpticoNegocio.MtdAgregar(producto))
                {
                    MessageBox.Show(
                        "Producto óptico agregado correctamente.",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    MtdConsultar();
                    MtdLimpiar();
                    tabControl1.SelectedTab = tabPage1;
                }
                else
                {
                    MessageBox.Show(
                        "No se pudo agregar el producto óptico.",
                        "Agregar",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al agregar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== CRUD: EDITAR =====
        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int codigoProducto;
                if (!int.TryParse(txtCodigoExamen.Text, out codigoProducto) || codigoProducto <= 0)
                {
                    MessageBox.Show(
                        "Seleccione un producto válido para editar.",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                ProductoOpticoEntidad producto = MtdObtenerDatosFormulario();
                producto.CodigoProducto = codigoProducto;

                if (_productoOpticoNegocio.MtdEditar(producto))
                {
                    MessageBox.Show(
                        "Producto óptico editado correctamente.",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    MtdConsultar();
                    MtdLimpiar();
                    tabControl1.SelectedTab = tabPage1;
                }
                else
                {
                    MessageBox.Show(
                        "No se encontró el producto para editar.",
                        "Editar",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al editar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== CRUD: ELIMINAR =====
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int codigoProducto;
            if (!int.TryParse(txtCodigoExamen.Text, out codigoProducto) || codigoProducto <= 0)
            {
                MessageBox.Show(
                    "Seleccione un producto válido para eliminar.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de eliminar el producto seleccionado?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
            {
                return;
            }

            try
            {
                if (_productoOpticoNegocio.MtdEliminar(codigoProducto))
                {
                    MessageBox.Show(
                        "Producto óptico eliminado correctamente.",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    MtdConsultar();
                    MtdLimpiar();
                    tabControl1.SelectedTab = tabPage1;
                }
                else
                {
                    MessageBox.Show(
                        "No se encontró el producto para eliminar.",
                        "Eliminar",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private ProductoOpticoEntidad MtdObtenerDatosFormulario()
        {
            int codigoTipoProducto;
            if (_cboTipoProducto.SelectedValue == null ||
                !int.TryParse(Convert.ToString(_cboTipoProducto.SelectedValue), out codigoTipoProducto))
            {
                throw new Exception("Seleccione un tipo de producto.");
            }

            decimal precio;
            if (!decimal.TryParse(
                txtPrecio.Text.Trim(),
                NumberStyles.Number,
                CultureInfo.CurrentCulture,
                out precio))
            {
                throw new Exception("Ingrese un precio válido.");
            }

            return new ProductoOpticoEntidad
            {
                CodigoTipoProducto = codigoTipoProducto,
                Nombre = cboxNombreProducto.Text.Trim(),
                Descripcion = txtDescripcionProducto.Text.Trim(),
                Marca = cboxMarca.Text.Trim(),
                Precio = precio,
                Estado = Convert.ToString(cboxEstadoProducto.SelectedItem)
            };
        }

        private void MtdLimpiar()
        {
            txtCodigoExamen.Clear();
            cboxNombreProducto.Text = string.Empty;
            txtDescripcionProducto.Clear();
            txtPrecio.Clear();
            cboxMarca.Text = string.Empty;
            cboxEstadoProducto.SelectedItem = "Activo";
            _cboTipoProducto.SelectedIndex = -1;
            btnGuardar.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            chkSeleccionar.Checked = false;
            cboxNombreProducto.Focus();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MtdLimpiar();
            tabControl1.SelectedTab = tabPage2;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MtdLimpiar();
            tabControl1.SelectedTab = tabPage1;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            MtdLimpiar();
        }
    }
}
