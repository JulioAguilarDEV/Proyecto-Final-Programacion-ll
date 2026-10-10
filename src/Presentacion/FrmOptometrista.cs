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

        private void dgvOptometrista_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Al terminar de cargar los datos no debe quedar ninguna fila seleccionada
            dgvOptometrista.ClearSelection();
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
