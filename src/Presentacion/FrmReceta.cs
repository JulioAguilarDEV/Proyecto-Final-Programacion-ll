using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmReceta : Form
    {
        // =====================================================
        // POO: COMPOSICIÓN
        // Instancias de la capa Negocio
        // (ExamenVisual llena el ComboBox de exámenes)
        // =====================================================

        private readonly RecetaNegocio _recetaNegocio = new RecetaNegocio();
        private readonly ExamenVisualNegocio _examenVisualNegocio = new ExamenVisualNegocio();
        private readonly UtilidadesGrid _utilidadesGrid = new UtilidadesGrid();

        // =====================================================
        // POO: CONSTRUCTOR
        // =====================================================

        public FrmReceta()
        {
            InitializeComponent();
        }

        // =====================================================
        // EVENTO LOAD DEL FORMULARIO
        // =====================================================

        private void FrmReceta_Load(object sender, EventArgs e)
        {
            // Las columnas ya están creadas en el diseño
            dgvReceta.AutoGenerateColumns = false;

            // Cargar el ComboBox de la llave foránea
            MtdCargarExamenes();

            // Muestra los datos en el DataGridView
            MtdConsultar();
            MtdLimpiar();
        }

        // =====================================================
        // CARGAR COMBOBOX DE LLAVES FORÁNEAS
        // =====================================================

        private void MtdCargarExamenes()
        {
            try
            {
                cboExamen.DataSource = null;
                cboExamen.DisplayMember = "Descripcion";
                cboExamen.ValueMember = "CodigoExamen";
                cboExamen.DataSource = _examenVisualNegocio.MtdConsultar();
                cboExamen.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =====================================================
        // CRUD: CONSULTAR
        // =====================================================

        private void MtdConsultar()
        {
            try
            {
                List<RecetaEntidad> listaReceta = _recetaNegocio.MtdConsultar();

                dgvReceta.DataSource = null;
                dgvReceta.DataSource = listaReceta;
                dgvReceta.ClearSelection();

                lblTotalRegistros.Text = "Total Registros: " + listaReceta.Count;
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
                //    Si el ComboBox no tiene selección, Convert.ToInt32 devuelve 0
                RecetaEntidad receta = new RecetaEntidad(
                    Convert.ToInt32(cboExamen.SelectedValue),
                    nudEsferaOD.Value,
                    nudCilindroOD.Value,
                    Convert.ToInt32(nudEjeOD.Value),
                    nudEsferaOI.Value,
                    nudCilindroOI.Value,
                    Convert.ToInt32(nudEjeOI.Value),
                    nudAdicion.Value,
                    nudDistanciaPupilar.Value,
                    dtpFechaEmision.Value.Date,
                    txtObservaciones.Text.Trim(),
                    cboEstado.Text
                );

                // 2. Guardar el registro a través de la capa de negocio
                bool resultado = _recetaNegocio.MtdAgregar(receta);

                if (resultado)
                {
                    MessageBox.Show("Receta agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                int codigoReceta;

                if (!int.TryParse(txtCodigoReceta.Text, out codigoReceta))
                {
                    MessageBox.Show("Debe seleccionar una receta.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // POO: Crear una instancia de la entidad (constructor con código)
                RecetaEntidad receta = new RecetaEntidad(
                    codigoReceta,
                    Convert.ToInt32(cboExamen.SelectedValue),
                    nudEsferaOD.Value,
                    nudCilindroOD.Value,
                    Convert.ToInt32(nudEjeOD.Value),
                    nudEsferaOI.Value,
                    nudCilindroOI.Value,
                    Convert.ToInt32(nudEjeOI.Value),
                    nudAdicion.Value,
                    nudDistanciaPupilar.Value,
                    dtpFechaEmision.Value.Date,
                    txtObservaciones.Text.Trim(),
                    cboEstado.Text
                );

                bool resultado = _recetaNegocio.MtdEditar(receta);

                if (resultado)
                {
                    MessageBox.Show("Receta editada correctamente.", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    MtdConsultar();
                    chkSeleccionar.Checked = false;
                    MtdLimpiar();
                    tabControl1.SelectedTab = tabPage1;
                }
                else
                {
                    MessageBox.Show("No se encontró la receta que desea editar.", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                int codigoReceta;

                if (!int.TryParse(txtCodigoReceta.Text, out codigoReceta))
                {
                    MessageBox.Show("Debe seleccionar una receta.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Solicitar confirmación al usuario
                DialogResult respuesta = MessageBox.Show("¿Está seguro de eliminar la receta seleccionada?", "Confirmar eliminación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.No)
                {
                    return;
                }

                bool resultado = _recetaNegocio.MtdEliminar(codigoReceta);

                if (resultado)
                {
                    MessageBox.Show("Receta eliminada correctamente.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    MtdConsultar();
                    chkSeleccionar.Checked = false;
                    MtdLimpiar();
                    tabControl1.SelectedTab = tabPage1;
                }
                else
                {
                    MessageBox.Show("No fue posible eliminar la receta.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                int codigoReceta;

                if (string.IsNullOrWhiteSpace(txtBuscador.Text))
                {
                    MessageBox.Show("Debe ingresar el código de la receta.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBuscador.Focus();
                    return;
                }

                if (!int.TryParse(txtBuscador.Text.Trim(), out codigoReceta))
                {
                    MessageBox.Show("El código debe contener solamente números.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBuscador.SelectAll();
                    txtBuscador.Focus();
                    return;
                }

                RecetaEntidad recetaEncontrada = _recetaNegocio.MtdBuscar(codigoReceta);

                if (recetaEncontrada == null)
                {
                    MessageBox.Show("No se encontró una receta con el código ingresado.", "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dgvReceta.DataSource = null;
                    lblTotalRegistros.Text = "Total Registros: 0";
                    txtBuscador.SelectAll();
                    txtBuscador.Focus();
                    return;
                }

                // POO: Crear una colección con el objeto encontrado
                List<RecetaEntidad> listaResultado = new List<RecetaEntidad>();
                listaResultado.Add(recetaEncontrada);

                dgvReceta.DataSource = null;
                dgvReceta.DataSource = listaResultado;
                dgvReceta.ClearSelection();

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
                dgvReceta.ClearSelection();
            }
        }

        private void dgvReceta_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Al terminar de cargar los datos no debe quedar ninguna fila seleccionada
            dgvReceta.ClearSelection();
        }

        private void dgvReceta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar si el CheckBox está activado
            if (!chkSeleccionar.Checked)
            {
                dgvReceta.ClearSelection();
                return;
            }

            // Evitar seleccionar el encabezado
            if (e.RowIndex < 0)
            {
                return;
            }

            try
            {
                DataGridViewRow filaSeleccionada = dgvReceta.Rows[e.RowIndex];

                // Llenar los controles de la pestaña Gestionar
                // (los NumericUpDown dan error si el valor está fuera de su Minimum/Maximum)
                txtCodigoReceta.Text = filaSeleccionada.Cells["colCodigoReceta"].Value.ToString();
                cboExamen.SelectedValue = Convert.ToInt32(filaSeleccionada.Cells["colCodigoExamen"].Value);
                nudEsferaOD.Value = Convert.ToDecimal(filaSeleccionada.Cells["colEsferaOD"].Value);
                nudCilindroOD.Value = Convert.ToDecimal(filaSeleccionada.Cells["colCilindroOD"].Value);
                nudEjeOD.Value = Convert.ToDecimal(filaSeleccionada.Cells["colEjeOD"].Value);
                nudEsferaOI.Value = Convert.ToDecimal(filaSeleccionada.Cells["colEsferaOI"].Value);
                nudCilindroOI.Value = Convert.ToDecimal(filaSeleccionada.Cells["colCilindroOI"].Value);
                nudEjeOI.Value = Convert.ToDecimal(filaSeleccionada.Cells["colEjeOI"].Value);
                nudAdicion.Value = Convert.ToDecimal(filaSeleccionada.Cells["colAdicion"].Value);
                nudDistanciaPupilar.Value = Convert.ToDecimal(filaSeleccionada.Cells["colDistanciaPupilar"].Value);
                dtpFechaEmision.Value = Convert.ToDateTime(filaSeleccionada.Cells["colFechaEmision"].Value);
                txtObservaciones.Text = filaSeleccionada.Cells["colObservaciones"].Value.ToString();
                cboEstado.SelectedItem = filaSeleccionada.Cells["colEstado"].Value.ToString();

                // Con un registro cargado solo se puede Editar o Eliminar
                btnGuardar.Enabled = false;
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;

                // Mostrar automáticamente el Tab Gestionar
                tabControl1.SelectedTab = tabPage2;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar la receta seleccionada: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =====================================================
        // MÉTODO PARA LIMPIAR LOS CONTROLES
        // =====================================================

        private void MtdLimpiar()
        {
            txtCodigoReceta.Clear();
            cboExamen.SelectedIndex = -1;
            nudEsferaOD.Value = 0;
            nudCilindroOD.Value = 0;
            nudEjeOD.Value = 0;
            nudEsferaOI.Value = 0;
            nudCilindroOI.Value = 0;
            nudEjeOI.Value = 0;
            nudAdicion.Value = 0;
            nudDistanciaPupilar.Value = 0;
            dtpFechaEmision.Value = DateTime.Now;
            cboEstado.SelectedIndex = -1;
            txtObservaciones.Clear();

            // Registro nuevo: solo se puede Guardar
            btnGuardar.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;

            cboExamen.Focus();
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
            _utilidadesGrid.MtdExportar(dgvReceta, "Recetas");
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            _utilidadesGrid.MtdImprimir(dgvReceta, "Listado de Recetas");
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
