using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmOrdenes : Form
    {
        private const int RegistrosPorPagina = 10;
        private readonly OrdenNegocio _ordenNegocio = new OrdenNegocio();
        private readonly ClienteNegocio _clienteNegocio = new ClienteNegocio();
        private readonly SucursalNegocio _sucursalNegocio = new SucursalNegocio();
        private readonly ProductoOpticoNegocio _productoOpticoNegocio = new ProductoOpticoNegocio();
        private readonly ComboBox _cboClientes = new ComboBox();
        private readonly ComboBox _cboSucursales = new ComboBox();
        private readonly ComboBox _cboEstados = new ComboBox();
        private readonly Label _lblPaginaActual = new Label();
        private List<OrdenEntidad> _listaOrdenes = new List<OrdenEntidad>();
        private int _paginaActual;
        private int _codigoDetalleSeleccionado;

        public FrmOrdenes()
        {
            InitializeComponent();

            MtdPrepararControles();
            MtdConectarEventos();
        }

        private void MtdPrepararControles()
        {
            dgvOrdenes.AutoGenerateColumns = false;
            CodigoOrden.DataPropertyName = "CodigoOrden";
            CodigoSucursal.DataPropertyName = "CodigoSucursal";
            CodigoCliente.DataPropertyName = "CodigoCliente";
            FechaOrden.DataPropertyName = "Fecha";
            Productos.DataPropertyName = "NombreProducto";
            Cantidad.DataPropertyName = "Cantidad";
            Precio.DataPropertyName = "PrecioUnitario";
            Estado.DataPropertyName = "Estado";
            SubTotal.DataPropertyName = "Subtotal";

            // Estos ComboBox runtime permiten respetar el Designer existente.
            MtdPrepararCombo(_cboClientes, "cboClientes", textBox1);
            MtdPrepararCombo(_cboSucursales, "cboSucursales", textBox2);
            textBox1.Visible = false;
            textBox2.Visible = false;
            label3.Text = "Cliente:";
            label4.Text = "Sucursal:";

            cboxProductosOrden.DropDownStyle = ComboBoxStyle.DropDownList;
            cboxProductosOrden.Items.Clear();
            cboxProductosOrden.SelectedIndexChanged += cboxProductosOrden_SelectedIndexChanged;
            txtCantidad.TextChanged += txtCantidad_TextChanged;

            rdbActivo.Visible = false;
            rdbInactivo.Visible = false;
            _cboEstados.Name = "cboEstados";
            _cboEstados.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboEstados.Font = rdbActivo.Font;
            _cboEstados.Location = rdbActivo.Location;
            _cboEstados.Size = new Size(249, rdbActivo.Height);
            _cboEstados.Items.AddRange(new object[] { "En proceso", "Lista", "Entregada", "Anulada" });
            grpDatos.Controls.Add(_cboEstados);
            _cboEstados.BringToFront();

            txtCodigoOrden.ReadOnly = true;
            txtPrecio.ReadOnly = true;
            txtSubTotal.ReadOnly = true;
            txtBuscador.MaxLength = 100;
            lblBuscar.Text = "Buscar por código, cliente, sucursal o estado:";

            lblCodigoOptometrista.Text = "Código Orden:";
            lblNombres.Text = "Fecha de Orden:";
            lblApellidos.Text = "Productos:";

            _lblPaginaActual.AutoSize = true;
            _lblPaginaActual.Font = new Font("Microsoft Sans Serif", 12F);
            _lblPaginaActual.Location = new Point(500, 29);
            _lblPaginaActual.Name = "lblPaginaActual";
            _lblPaginaActual.Text = "Página 0 de 0";
            PanelInferior.Controls.Add(_lblPaginaActual);
        }

        private void MtdPrepararCombo(ComboBox combo, string nombre, TextBox controlReferencia)
        {
            combo.Name = nombre;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.Location = controlReferencia.Location;
            combo.Size = controlReferencia.Size;
            combo.Font = controlReferencia.Font;
            combo.Anchor = controlReferencia.Anchor;
            combo.TabIndex = controlReferencia.TabIndex;
            grpDatos.Controls.Add(combo);
            combo.BringToFront();
        }

        private void MtdConectarEventos()
        {
            Load += FrmOrdenes_Load;
            btnNuevo.Click += btnNuevo_Click;
            btnGuardar.Click += btnGuardar_Click;
            btnCancelar.Click += btnCancelar_Click;
            btnEditar.Click += btnEditar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnLimpiar.Click += btnLimpiar_Click;
            btnBuscar.Click += btnBuscar_Click;
            btnLimpiarBusqueda.Click += btnLimpiarBusqueda_Click;
            dgvOrdenes.CellClick += dgvOrdenes_CellClick;
            dgvOrdenes.KeyDown += dgvOrdenes_KeyDown;
        }

        private void FrmOrdenes_Load(object sender, EventArgs e)
        {
            MtdCargarCatalogos();
            MtdConsultar();
            MtdLimpiar();
        }

        private void MtdCargarCatalogos()
        {
            try
            {
                _cboClientes.DisplayMember = "NombreCompleto";
                _cboClientes.ValueMember = "CodigoCliente";
                _cboClientes.DataSource = _clienteNegocio.MtdConsultar();
                _cboClientes.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo cargar el catálogo de clientes. " + ex.Message,
                    "Error de catálogo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            try
            {
                _cboSucursales.DisplayMember = "Nombre";
                _cboSucursales.ValueMember = "CodigoSucursal";
                _cboSucursales.DataSource = _sucursalNegocio.MtdConsultar();
                _cboSucursales.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo cargar el catálogo de sucursales. " + ex.Message,
                    "Error de catálogo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            try
            {
                cboxProductosOrden.DisplayMember = "Nombre";
                cboxProductosOrden.ValueMember = "CodigoProducto";
                cboxProductosOrden.DataSource = _productoOpticoNegocio.MtdConsultar();
                cboxProductosOrden.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo cargar el catálogo de productos ópticos. " + ex.Message,
                    "Error de catálogo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void cboxProductosOrden_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductoOpticoEntidad producto = cboxProductosOrden.SelectedItem as ProductoOpticoEntidad;
            if (producto == null)
            {
                return;
            }

            txtPrecio.Text = producto.Precio.ToString("0.00", CultureInfo.CurrentCulture);
            MtdRecalcularSubtotal();
        }

        private void MtdRecalcularSubtotal()
        {
            int cantidad;
            decimal precio;

            if (int.TryParse(txtCantidad.Text, out cantidad) &&
                decimal.TryParse(txtPrecio.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out precio))
            {
                txtSubTotal.Text = (cantidad * precio).ToString("0.00", CultureInfo.CurrentCulture);
            }
            else
            {
                txtSubTotal.Clear();
            }
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            MtdRecalcularSubtotal();
        }

        private void MtdConsultar()
        {
            try
            {
                _listaOrdenes = _ordenNegocio.MtdConsultar();
                _paginaActual = 0;
                MtdMostrarPagina();
            }
            catch (Exception ex)
            {
                dgvOrdenes.DataSource = null;
                _listaOrdenes.Clear();
                lblTotalRegistros.Text = "Total Registros: 0";
                MtdActualizarPagina();
                MessageBox.Show(
                    "No se pudo consultar la lista de órdenes. " + ex.Message,
                    "Error de consulta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void MtdBuscar()
        {
            try
            {
                _listaOrdenes = _ordenNegocio.MtdBuscar(txtBuscador.Text.Trim());
                _paginaActual = 0;
                MtdMostrarPagina();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error de búsqueda",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void MtdMostrarPagina()
        {
            List<OrdenEntidad> listaPagina = new List<OrdenEntidad>();
            int primerRegistro = _paginaActual * RegistrosPorPagina;
            int ultimoRegistro = Math.Min(primerRegistro + RegistrosPorPagina, _listaOrdenes.Count);

            for (int indice = primerRegistro; indice < ultimoRegistro; indice++)
            {
                listaPagina.Add(_listaOrdenes[indice]);
            }

            dgvOrdenes.DataSource = null;
            dgvOrdenes.DataSource = listaPagina;
            dgvOrdenes.ClearSelection();

            // El total corresponde al resultado completo, no solo a las filas visibles.
            lblTotalRegistros.Text = "Total Registros: " + _listaOrdenes.Count;
            MtdActualizarPagina();
        }

        private void MtdActualizarPagina()
        {
            int totalPaginas = (_listaOrdenes.Count + RegistrosPorPagina - 1) / RegistrosPorPagina;

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
            int totalPaginas = (_listaOrdenes.Count + RegistrosPorPagina - 1) / RegistrosPorPagina;
            int nuevaPagina = _paginaActual + cambio;

            if (nuevaPagina < 0 || nuevaPagina >= totalPaginas)
            {
                return;
            }

            _paginaActual = nuevaPagina;
            MtdMostrarPagina();
        }

        private void dgvOrdenes_KeyDown(object sender, KeyEventArgs e)
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

        private void dgvOrdenes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            OrdenEntidad orden = dgvOrdenes.Rows[e.RowIndex].DataBoundItem as OrdenEntidad;
            if (orden == null)
            {
                return;
            }

            try
            {
                MtdCargarOrdenEnControles(orden);
                tabControl1.SelectedTab = tabPage2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los datos de la orden seleccionada. " + ex.Message,
                    "Error al seleccionar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void MtdCargarOrdenEnControles(OrdenEntidad orden)
        {
            txtCodigoOrden.Text = orden.CodigoOrden.ToString();
            _codigoDetalleSeleccionado = orden.CodigoDetalle;
            MtdSeleccionarValor(_cboClientes, orden.CodigoCliente);
            MtdSeleccionarValor(_cboSucursales, orden.CodigoSucursal);
            dtpFechaOrden.Value = orden.Fecha;

            if (orden.CodigoProducto > 0)
            {
                MtdSeleccionarValor(cboxProductosOrden, orden.CodigoProducto);
            }
            else
            {
                cboxProductosOrden.SelectedIndex = -1;
            }

            txtCantidad.Text = orden.Cantidad > 0 ? orden.Cantidad.ToString() : string.Empty;
            txtPrecio.Text = orden.PrecioUnitario > 0
                ? orden.PrecioUnitario.ToString("0.00", CultureInfo.CurrentCulture)
                : string.Empty;
            txtSubTotal.Text = orden.Subtotal > 0
                ? orden.Subtotal.ToString("0.00", CultureInfo.CurrentCulture)
                : string.Empty;
            _cboEstados.SelectedItem = orden.Estado;
        }

        private void MtdSeleccionarValor(ComboBox combo, int codigo)
        {
            if (combo.DataSource == null)
            {
                throw new Exception("El catálogo requerido no está disponible.");
            }

            combo.SelectedValue = codigo;
            if (combo.SelectedIndex < 0)
            {
                throw new Exception("No se encontró el código relacionado en el catálogo.");
            }
        }

        private OrdenEntidad MtdLeerOrdenDesdeControles()
        {
            int codigoOrden = 0;
            int.TryParse(txtCodigoOrden.Text, out codigoOrden);

            if (_cboClientes.SelectedValue == null || _cboSucursales.SelectedValue == null ||
                cboxProductosOrden.SelectedValue == null)
            {
                throw new Exception("Seleccione un cliente, una sucursal y un producto.");
            }

            int cantidad;
            if (!int.TryParse(txtCantidad.Text.Trim(), out cantidad))
            {
                throw new Exception("Ingrese una cantidad entera válida.");
            }

            decimal precio;
            if (!decimal.TryParse(
                txtPrecio.Text.Trim(),
                NumberStyles.Number,
                CultureInfo.CurrentCulture,
                out precio))
            {
                throw new Exception("Seleccione un producto con precio válido.");
            }

            OrdenEntidad orden = new OrdenEntidad();
            orden.CodigoOrden = codigoOrden;
            orden.CodigoDetalle = _codigoDetalleSeleccionado;
            orden.CodigoCliente = Convert.ToInt32(_cboClientes.SelectedValue);
            orden.CodigoSucursal = Convert.ToInt32(_cboSucursales.SelectedValue);
            orden.Fecha = dtpFechaOrden.Value.Date;
            orden.Estado = _cboEstados.SelectedItem == null ? string.Empty : _cboEstados.SelectedItem.ToString();
            orden.CodigoProducto = Convert.ToInt32(cboxProductosOrden.SelectedValue);
            orden.Cantidad = cantidad;
            orden.PrecioUnitario = precio;
            return orden;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtCodigoOrden.Text))
                {
                    throw new Exception("Para modificar una orden seleccionada, use el botón Editar.");
                }

                OrdenEntidad orden = MtdLeerOrdenDesdeControles();
                if (_ordenNegocio.MtdAgregar(orden))
                {
                    MessageBox.Show(
                        "La orden se agregó correctamente.",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    txtBuscador.Clear();
                    MtdConsultar();
                    MtdLimpiar();
                    tabControl1.SelectedTab = tabPage1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al agregar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCodigoOrden.Text))
                {
                    throw new Exception("Seleccione una orden del listado antes de editar.");
                }

                OrdenEntidad orden = MtdLeerOrdenDesdeControles();
                if (_ordenNegocio.MtdEditar(orden))
                {
                    MessageBox.Show(
                        "La orden se editó correctamente.",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    txtBuscador.Clear();
                    MtdConsultar();
                    MtdLimpiar();
                    tabControl1.SelectedTab = tabPage1;
                }
                else
                {
                    MessageBox.Show(
                        "La orden seleccionada ya no existe o cambió. Consulte la lista e intente nuevamente.",
                        "No se realizaron cambios",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al editar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int codigoOrden;
            if (!int.TryParse(txtCodigoOrden.Text, out codigoOrden) || codigoOrden <= 0)
            {
                MessageBox.Show(
                    "Seleccione una orden del listado antes de eliminar.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                "Se eliminará la orden " + codigoOrden + " junto con todos sus detalles. ¿Desea continuar?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes)
            {
                return;
            }

            try
            {
                if (_ordenNegocio.MtdEliminar(codigoOrden))
                {
                    MessageBox.Show(
                        "La orden se eliminó correctamente.",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    txtBuscador.Clear();
                    MtdConsultar();
                    MtdLimpiar();
                    tabControl1.SelectedTab = tabPage1;
                }
                else
                {
                    MessageBox.Show(
                        "No se encontró la orden seleccionada.",
                        "Sin cambios",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MtdLimpiar()
        {
            txtCodigoOrden.Clear();
            _codigoDetalleSeleccionado = 0;
            _cboClientes.SelectedIndex = -1;
            _cboSucursales.SelectedIndex = -1;
            cboxProductosOrden.SelectedIndex = -1;
            _cboEstados.SelectedItem = "En proceso";
            dtpFechaOrden.Value = DateTime.Today;
            txtCantidad.Clear();
            txtPrecio.Clear();
            txtSubTotal.Clear();
            dgvOrdenes.ClearSelection();
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MtdBuscar();
        }

        private void btnLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            txtBuscador.Clear();
            MtdConsultar();
        }
    }
}
