using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmTiposDeProducto : Form
    {
        private const int RegistrosPorPagina = 10;
        private readonly TipoProductoNegocio _tipoProductoNegocio = new TipoProductoNegocio();
        private readonly ToolTip _toolTipPaginacion = new ToolTip();
        private List<TipoProductoEntidad> _listaTipoProducto = new List<TipoProductoEntidad>();
        private int _paginaActual;

        public FrmTiposDeProducto()
        {
            InitializeComponent();

            dgvTipoProducto.AutoGenerateColumns = false;
            CodigoTipo.DataPropertyName = "CodigoTipoProducto";
            Nombre.DataPropertyName = "Nombre";
            Descripcion.DataPropertyName = "Descripcion";
            Estado.DataPropertyName = "Estado";

            cboxNombreTipo.DropDownStyle = ComboBoxStyle.DropDown;
            cboxNombreTipo.Items.Clear();
            cboxNombreTipo.MaxLength = 80;
            txtDescripcionTipo.MaxLength = 200;
            txtBuscador.MaxLength = 10;
            rdbActivo.Text = "Activo";
            rdbInactivo.Text = "Inactivo";
            _toolTipPaginacion.SetToolTip(dgvTipoProducto, "Use Re Pág y Av Pág para cambiar de página.");

            Load += FrmTiposDeProducto_Load;
            dgvTipoProducto.KeyDown += dgvTipoProducto_KeyDown;
            dgvTipoProducto.CellClick += dgvTipoProducto_CellClick;
            chkSeleccionar.CheckedChanged += chkSeleccionar_CheckedChanged;
            btnBuscar.Click += btnBuscar_Click;
            btnLimpiarBusqueda.Click += btnLimpiarBusqueda_Click;
            btnNuevo.Click += btnNuevo_Click;
            btnGuardar.Click += btnGuardar_Click;
            btnEditar.Click += btnEditar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnCancelar.Click += btnCancelar_Click;
            btnLimpiar.Click += btnLimpiar_Click;
        }

        private void FrmTiposDeProducto_Load(object sender, EventArgs e)
        {
            MtdConsultar();
            MtdLimpiar();
        }

        private void MtdConsultar()
        {
            try
            {
                _listaTipoProducto = _tipoProductoNegocio.MtdConsultar();
                _paginaActual = 0;
                MtdMostrarPagina();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MtdMostrarPagina()
        {
            List<TipoProductoEntidad> listaPagina = new List<TipoProductoEntidad>();
            int primerRegistro = _paginaActual * RegistrosPorPagina;
            int ultimoRegistro = Math.Min(primerRegistro + RegistrosPorPagina, _listaTipoProducto.Count);

            for (int indice = primerRegistro; indice < ultimoRegistro; indice++)
            {
                listaPagina.Add(_listaTipoProducto[indice]);
            }

            dgvTipoProducto.DataSource = null;
            dgvTipoProducto.DataSource = listaPagina;
            dgvTipoProducto.ClearSelection();
            lblTotalRegistros.Text = "Total Registros: " + _listaTipoProducto.Count;
        }

        private void MtdCambiarPagina(int cambio)
        {
            int totalPaginas = (_listaTipoProducto.Count + RegistrosPorPagina - 1) / RegistrosPorPagina;
            int nuevaPagina = _paginaActual + cambio;

            if (nuevaPagina < 0 || nuevaPagina >= totalPaginas)
            {
                return;
            }

            _paginaActual = nuevaPagina;
            MtdMostrarPagina();
        }

        private void dgvTipoProducto_KeyDown(object sender, KeyEventArgs e)
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
            int codigoTipoProducto;
            if (!int.TryParse(txtBuscador.Text.Trim(), out codigoTipoProducto) || codigoTipoProducto <= 0)
            {
                MessageBox.Show("Ingrese un código de tipo de producto válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBuscador.Focus();
                return;
            }

            try
            {
                TipoProductoEntidad tipoProducto = _tipoProductoNegocio.MtdBuscar(codigoTipoProducto);
                _listaTipoProducto = new List<TipoProductoEntidad>();

                if (tipoProducto != null)
                {
                    _listaTipoProducto.Add(tipoProducto);
                }

                _paginaActual = 0;
                MtdMostrarPagina();

                if (tipoProducto == null)
                {
                    MessageBox.Show("No se encontró un tipo de producto con ese código.", "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                TipoProductoEntidad tipoProducto = new TipoProductoEntidad(
                    cboxNombreTipo.Text.Trim(),
                    txtDescripcionTipo.Text.Trim(),
                    MtdObtenerEstado());

                if (_tipoProductoNegocio.MtdAgregar(tipoProducto))
                {
                    MessageBox.Show("Tipo de producto agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MtdConsultar();
                    MtdLimpiar();
                    tabControl1.SelectedTab = tabPage1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int codigoTipoProducto;
                if (!int.TryParse(txtCodigoExamen.Text, out codigoTipoProducto))
                {
                    MessageBox.Show("Debe seleccionar un tipo de producto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                TipoProductoEntidad tipoProducto = new TipoProductoEntidad(
                    codigoTipoProducto,
                    cboxNombreTipo.Text.Trim(),
                    txtDescripcionTipo.Text.Trim(),
                    MtdObtenerEstado());

                if (_tipoProductoNegocio.MtdEditar(tipoProducto))
                {
                    MessageBox.Show("Tipo de producto editado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MtdConsultar();
                    MtdLimpiar();
                    chkSeleccionar.Checked = false;
                    tabControl1.SelectedTab = tabPage1;
                }
                else
                {
                    MessageBox.Show("No se encontró el tipo de producto.", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int codigoTipoProducto;
            if (!int.TryParse(txtCodigoExamen.Text, out codigoTipoProducto) || codigoTipoProducto <= 0)
            {
                MessageBox.Show("Debe seleccionar un tipo de producto válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de eliminar el tipo de producto seleccionado?", "Confirmar eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
            {
                return;
            }

            try
            {
                if (_tipoProductoNegocio.MtdEliminar(codigoTipoProducto))
                {
                    MessageBox.Show("Tipo de producto eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MtdConsultar();
                    MtdLimpiar();
                    chkSeleccionar.Checked = false;
                    tabControl1.SelectedTab = tabPage1;
                }
                else
                {
                    MessageBox.Show("No se encontró el tipo de producto.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkSeleccionar.Checked)
            {
                dgvTipoProducto.ClearSelection();
            }
        }

        private void dgvTipoProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!chkSeleccionar.Checked || e.RowIndex < 0)
            {
                dgvTipoProducto.ClearSelection();
                return;
            }

            DataGridViewRow fila = dgvTipoProducto.Rows[e.RowIndex];
            txtCodigoExamen.Text = Convert.ToString(fila.Cells["CodigoTipo"].Value);
            cboxNombreTipo.Text = Convert.ToString(fila.Cells["Nombre"].Value);
            txtDescripcionTipo.Text = Convert.ToString(fila.Cells["Descripcion"].Value);

            string estado = Convert.ToString(fila.Cells["Estado"].Value);
            rdbActivo.Checked = estado == "Activo";
            rdbInactivo.Checked = estado == "Inactivo";

            btnGuardar.Enabled = false;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            tabControl1.SelectedTab = tabPage2;
        }

        private string MtdObtenerEstado()
        {
            return rdbActivo.Checked ? "Activo" : "Inactivo";
        }

        private void MtdLimpiar()
        {
            txtCodigoExamen.Clear();
            cboxNombreTipo.Text = string.Empty;
            txtDescripcionTipo.Clear();
            rdbActivo.Checked = true;
            btnGuardar.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            cboxNombreTipo.Focus();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MtdLimpiar();
            tabControl1.SelectedTab = tabPage2;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            chkSeleccionar.Checked = false;
            MtdLimpiar();
            tabControl1.SelectedTab = tabPage1;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            MtdLimpiar();
        }

        private void dgvTipoProducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblEstado_Click(object sender, EventArgs e)
        {

        }
    }
}
