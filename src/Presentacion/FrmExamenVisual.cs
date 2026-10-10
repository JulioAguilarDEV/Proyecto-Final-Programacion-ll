using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmExamenVisual : Form
    {
        // =====================================================
        // POO: COMPOSICIÓN
        // Instancias de la capa Negocio
        // (Cliente, Optometrista y Cita llenan los ComboBox)
        // =====================================================

        private readonly ExamenVisualNegocio _examenVisualNegocio = new ExamenVisualNegocio();
        private readonly ClienteNegocio _clienteNegocio = new ClienteNegocio();
        private readonly OptometristaNegocio _optometristaNegocio = new OptometristaNegocio();
        private readonly CitaNegocio _citaNegocio = new CitaNegocio();
        private readonly UtilidadesGrid _utilidadesGrid = new UtilidadesGrid();

        // =====================================================
        // POO: CONSTRUCTOR
        // =====================================================

        public FrmExamenVisual()
        {
            InitializeComponent();
        }

        // =====================================================
        // EVENTO LOAD DEL FORMULARIO
        // =====================================================

        private void FrmExamenVisual_Load(object sender, EventArgs e)
        {
            // Las columnas ya están creadas en el diseño
            dgvExamenVisual.AutoGenerateColumns = false;

            // Cargar los ComboBox de llaves foráneas
            MtdCargarClientes();
            MtdCargarOptometristas();
            MtdCargarCitas();

            // Muestra los datos en el DataGridView
            MtdConsultar();
            MtdLimpiar();
        }

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

        private void MtdCargarOptometristas()
        {
            try
            {
                cboOptometrista.DataSource = null;
                cboOptometrista.DisplayMember = "NombreCompleto";
                cboOptometrista.ValueMember = "CodigoOptometrista";
                cboOptometrista.DataSource = _optometristaNegocio.MtdConsultar();
                cboOptometrista.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MtdCargarCitas()
        {
            try
            {
                cboCita.DataSource = null;
                cboCita.DisplayMember = "Descripcion";
                cboCita.ValueMember = "CodigoCita";
                cboCita.DataSource = _citaNegocio.MtdConsultar();
                cboCita.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // La cita es opcional: con la tecla Supr o Retroceso se quita la cita elegida
        private void cboCita_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                cboCita.SelectedIndex = -1;
            }
        }

        // =====================================================
        // CRUD: CONSULTAR
        // =====================================================

        private void MtdConsultar()
        {
            try
            {
                List<ExamenVisualEntidad> listaExamenVisual = _examenVisualNegocio.MtdConsultar();

                dgvExamenVisual.DataSource = null;
                dgvExamenVisual.DataSource = listaExamenVisual;
                dgvExamenVisual.ClearSelection();

                lblTotalRegistros.Text = "Total Registros: " + listaExamenVisual.Count;
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
                // 1. Crear el objeto usando el constructor para 'Agregar'
                //    Si un ComboBox no tiene selección, Convert.ToInt32 devuelve 0
                ExamenVisualEntidad examen = new ExamenVisualEntidad(
                    Convert.ToInt32(cboCliente.SelectedValue),
                    Convert.ToInt32(cboOptometrista.SelectedValue),
                    Convert.ToInt32(cboCita.SelectedValue),
                    dtpFecha.Value.Date,
                    txtObservaciones.Text.Trim(),
                    txtResultadoGeneral.Text.Trim(),
                    cboEstado.Text
                );

                // 2. Guardar el registro a través de la capa de negocio
                bool resultado = _examenVisualNegocio.MtdAgregar(examen);

                if (resultado)
                {
                    MessageBox.Show("Examen visual agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                int codigoExamen;

                if (!int.TryParse(txtCodigoExamen.Text, out codigoExamen))
                {
                    MessageBox.Show("Debe seleccionar un examen visual.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // POO: Crear una instancia de la entidad (constructor con código)
                ExamenVisualEntidad examen = new ExamenVisualEntidad(
                    codigoExamen,
                    Convert.ToInt32(cboCliente.SelectedValue),
                    Convert.ToInt32(cboOptometrista.SelectedValue),
                    Convert.ToInt32(cboCita.SelectedValue),
                    dtpFecha.Value.Date,
                    txtObservaciones.Text.Trim(),
                    txtResultadoGeneral.Text.Trim(),
                    cboEstado.Text
                );

                bool resultado = _examenVisualNegocio.MtdEditar(examen);

                if (resultado)
                {
                    MessageBox.Show("Examen visual editado correctamente.", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    MtdConsultar();
                    chkSeleccionar.Checked = false;
                    MtdLimpiar();
                    tabControl1.SelectedTab = tabPage1;
                }
                else
                {
                    MessageBox.Show("No se encontró el examen visual que desea editar.", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                int codigoExamen;

                if (!int.TryParse(txtCodigoExamen.Text, out codigoExamen))
                {
                    MessageBox.Show("Debe seleccionar un examen visual.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Solicitar confirmación al usuario
                DialogResult respuesta = MessageBox.Show("¿Está seguro de eliminar el examen visual seleccionado?", "Confirmar eliminación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.No)
                {
                    return;
                }

                bool resultado = _examenVisualNegocio.MtdEliminar(codigoExamen);

                if (resultado)
                {
                    MessageBox.Show("Examen visual eliminado correctamente.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    MtdConsultar();
                    chkSeleccionar.Checked = false;
                    MtdLimpiar();
                    tabControl1.SelectedTab = tabPage1;
                }
                else
                {
                    MessageBox.Show("No fue posible eliminar el examen visual.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                int codigoExamen;

                if (string.IsNullOrWhiteSpace(txtBuscador.Text))
                {
                    MessageBox.Show("Debe ingresar el código del examen visual.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBuscador.Focus();
                    return;
                }

                if (!int.TryParse(txtBuscador.Text.Trim(), out codigoExamen))
                {
                    MessageBox.Show("El código debe contener solamente números.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBuscador.SelectAll();
                    txtBuscador.Focus();
                    return;
                }

                ExamenVisualEntidad examenEncontrado = _examenVisualNegocio.MtdBuscar(codigoExamen);

                if (examenEncontrado == null)
                {
                    MessageBox.Show("No se encontró un examen visual con el código ingresado.", "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dgvExamenVisual.DataSource = null;
                    lblTotalRegistros.Text = "Total Registros: 0";
                    txtBuscador.SelectAll();
                    txtBuscador.Focus();
                    return;
                }

                // POO: Crear una colección con el objeto encontrado
                List<ExamenVisualEntidad> listaResultado = new List<ExamenVisualEntidad>();
                listaResultado.Add(examenEncontrado);

                dgvExamenVisual.DataSource = null;
                dgvExamenVisual.DataSource = listaResultado;
                dgvExamenVisual.ClearSelection();

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
                dgvExamenVisual.ClearSelection();
            }
        }

        private void dgvExamenVisual_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Al terminar de cargar los datos no debe quedar ninguna fila seleccionada
            dgvExamenVisual.ClearSelection();
        }

        private void dgvExamenVisual_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar si el CheckBox está activado
            if (!chkSeleccionar.Checked)
            {
                dgvExamenVisual.ClearSelection();
                return;
            }

            // Evitar seleccionar el encabezado
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow filaSeleccionada = dgvExamenVisual.Rows[e.RowIndex];

            // Llenar los controles de la pestaña Gestionar
            txtCodigoExamen.Text = filaSeleccionada.Cells["colCodigoExamen"].Value.ToString();
            cboCliente.SelectedValue = Convert.ToInt32(filaSeleccionada.Cells["colCodigoCliente"].Value);
            cboOptometrista.SelectedValue = Convert.ToInt32(filaSeleccionada.Cells["colCodigoOptometrista"].Value);

            // La cita es opcional: 0 significa que el examen no tiene cita
            int codigoCita = Convert.ToInt32(filaSeleccionada.Cells["colCodigoCita"].Value);
            if (codigoCita > 0)
            {
                cboCita.SelectedValue = codigoCita;
            }
            else
            {
                cboCita.SelectedIndex = -1;
            }

            dtpFecha.Value = Convert.ToDateTime(filaSeleccionada.Cells["colFecha"].Value);
            txtObservaciones.Text = filaSeleccionada.Cells["colObservaciones"].Value.ToString();
            txtResultadoGeneral.Text = filaSeleccionada.Cells["colResultadoGeneral"].Value.ToString();
            cboEstado.SelectedItem = filaSeleccionada.Cells["colEstado"].Value.ToString();

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
            txtCodigoExamen.Clear();
            cboCliente.SelectedIndex = -1;
            cboOptometrista.SelectedIndex = -1;
            cboCita.SelectedIndex = -1;
            dtpFecha.Value = DateTime.Now;
            txtResultadoGeneral.Clear();
            cboEstado.SelectedIndex = -1;
            txtObservaciones.Clear();

            // Registro nuevo: solo se puede Guardar
            btnGuardar.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;

            cboCliente.Focus();
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
            _utilidadesGrid.MtdExportar(dgvExamenVisual, "ExamenesVisuales");
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            _utilidadesGrid.MtdImprimir(dgvExamenVisual, "Listado de Exámenes Visuales");
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
