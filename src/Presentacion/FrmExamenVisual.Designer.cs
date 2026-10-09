namespace Presentacion
{
    partial class FrmExamenVisual
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.PanelPrincipal = new System.Windows.Forms.Panel();
            this.PanelCentral = new System.Windows.Forms.Panel();
            this.dgvExamenVisual = new System.Windows.Forms.DataGridView();
            this.colCodigoExamen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodigoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodigoOptometrista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodigoCita = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colObservaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResultadoGeneral = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PanelDivisor4 = new System.Windows.Forms.Panel();
            this.PanelInferior = new System.Windows.Forms.Panel();
            this.lblTotalRegistros = new System.Windows.Forms.Label();
            this.PanelDivisor3 = new System.Windows.Forms.Panel();
            this.PanelCheck = new System.Windows.Forms.Panel();
            this.chkSeleccionar = new System.Windows.Forms.CheckBox();
            this.PanelDivisor2 = new System.Windows.Forms.Panel();
            this.PanelFiltros = new System.Windows.Forms.Panel();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscador = new System.Windows.Forms.TextBox();
            this.PanelDivisor1 = new System.Windows.Forms.Panel();
            this.PanelEncabezado = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.PanelPrincipalGestionar = new System.Windows.Forms.Panel();
            this.PanelCentralGestionar = new System.Windows.Forms.Panel();
            this.grpDatos = new System.Windows.Forms.GroupBox();
            this.lblCodigoExamen = new System.Windows.Forms.Label();
            this.txtCodigoExamen = new System.Windows.Forms.TextBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.lblOptometrista = new System.Windows.Forms.Label();
            this.cboOptometrista = new System.Windows.Forms.ComboBox();
            this.lblCita = new System.Windows.Forms.Label();
            this.cboCita = new System.Windows.Forms.ComboBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblResultadoGeneral = new System.Windows.Forms.Label();
            this.txtResultadoGeneral = new System.Windows.Forms.TextBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.PanelDivisor7 = new System.Windows.Forms.Panel();
            this.PanelAcciones = new System.Windows.Forms.Panel();
            this.PanelDivisor6 = new System.Windows.Forms.Panel();
            this.PanelInferiorGestionar = new System.Windows.Forms.Panel();
            this.PanelDivisor5 = new System.Windows.Forms.Panel();
            this.PanelEncabezadoGestionar = new System.Windows.Forms.Panel();
            this.btnCerrar = new FontAwesome.Sharp.IconButton();
            this.btnExportar = new FontAwesome.Sharp.IconButton();
            this.btnImprimir = new FontAwesome.Sharp.IconButton();
            this.btnBuscar = new FontAwesome.Sharp.IconButton();
            this.btnLimpiarBusqueda = new FontAwesome.Sharp.IconButton();
            this.btnNuevo = new FontAwesome.Sharp.IconButton();
            this.btnGuardar = new FontAwesome.Sharp.IconButton();
            this.btnCancelar = new FontAwesome.Sharp.IconButton();
            this.btnEditar = new FontAwesome.Sharp.IconButton();
            this.btnEliminar = new FontAwesome.Sharp.IconButton();
            this.btnLimpiar = new FontAwesome.Sharp.IconButton();
            this.btnCerrarGestionar = new FontAwesome.Sharp.IconButton();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.PanelPrincipal.SuspendLayout();
            this.PanelCentral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExamenVisual)).BeginInit();
            this.PanelInferior.SuspendLayout();
            this.PanelCheck.SuspendLayout();
            this.PanelFiltros.SuspendLayout();
            this.PanelEncabezado.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.PanelPrincipalGestionar.SuspendLayout();
            this.PanelCentralGestionar.SuspendLayout();
            this.grpDatos.SuspendLayout();
            this.PanelAcciones.SuspendLayout();
            this.PanelInferiorGestionar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1137, 698);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.PanelPrincipal);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(1129, 669);
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
            this.PanelPrincipal.Location = new System.Drawing.Point(3, 2);
            this.PanelPrincipal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanelPrincipal.Name = "PanelPrincipal";
            this.PanelPrincipal.Size = new System.Drawing.Size(1123, 665);
            this.PanelPrincipal.TabIndex = 0;
            // 
            // PanelCentral
            // 
            this.PanelCentral.Controls.Add(this.dgvExamenVisual);
            this.PanelCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelCentral.Location = new System.Drawing.Point(0, 161);
            this.PanelCentral.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanelCentral.Name = "PanelCentral";
            this.PanelCentral.Padding = new System.Windows.Forms.Padding(18, 0, 18, 0);
            this.PanelCentral.Size = new System.Drawing.Size(1123, 420);
            this.PanelCentral.TabIndex = 6;
            // 
            // dgvExamenVisual
            // 
            this.dgvExamenVisual.AllowUserToAddRows = false;
            this.dgvExamenVisual.AllowUserToDeleteRows = false;
            this.dgvExamenVisual.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(244)))));
            this.dgvExamenVisual.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvExamenVisual.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvExamenVisual.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(47)))), ((int)(((byte)(103)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(47)))), ((int)(((byte)(103)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExamenVisual.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvExamenVisual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExamenVisual.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigoExamen,
            this.colCodigoCliente,
            this.colCodigoOptometrista,
            this.colCodigoCita,
            this.colFecha,
            this.colObservaciones,
            this.colResultadoGeneral,
            this.colEstado});
            this.dgvExamenVisual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExamenVisual.EnableHeadersVisualStyles = false;
            this.dgvExamenVisual.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dgvExamenVisual.Location = new System.Drawing.Point(18, 0);
            this.dgvExamenVisual.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvExamenVisual.MultiSelect = false;
            this.dgvExamenVisual.Name = "dgvExamenVisual";
            this.dgvExamenVisual.ReadOnly = true;
            this.dgvExamenVisual.RowHeadersVisible = false;
            this.dgvExamenVisual.RowHeadersWidth = 62;
            this.dgvExamenVisual.RowTemplate.Height = 28;
            this.dgvExamenVisual.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExamenVisual.Size = new System.Drawing.Size(1087, 420);
            this.dgvExamenVisual.TabIndex = 0;
            // 
            // colCodigoExamen
            // 
            this.colCodigoExamen.DataPropertyName = "CodigoExamen";
            this.colCodigoExamen.FillWeight = 60F;
            this.colCodigoExamen.HeaderText = "Código";
            this.colCodigoExamen.MinimumWidth = 6;
            this.colCodigoExamen.Name = "colCodigoExamen";
            this.colCodigoExamen.ReadOnly = true;
            // 
            // colCodigoCliente
            // 
            this.colCodigoCliente.DataPropertyName = "CodigoCliente";
            this.colCodigoCliente.FillWeight = 70F;
            this.colCodigoCliente.HeaderText = "Cód. cliente";
            this.colCodigoCliente.MinimumWidth = 6;
            this.colCodigoCliente.Name = "colCodigoCliente";
            this.colCodigoCliente.ReadOnly = true;
            // 
            // colCodigoOptometrista
            // 
            this.colCodigoOptometrista.DataPropertyName = "CodigoOptometrista";
            this.colCodigoOptometrista.FillWeight = 80F;
            this.colCodigoOptometrista.HeaderText = "Cód. optometrista";
            this.colCodigoOptometrista.MinimumWidth = 6;
            this.colCodigoOptometrista.Name = "colCodigoOptometrista";
            this.colCodigoOptometrista.ReadOnly = true;
            // 
            // colCodigoCita
            // 
            this.colCodigoCita.DataPropertyName = "CodigoCita";
            this.colCodigoCita.FillWeight = 60F;
            this.colCodigoCita.HeaderText = "Cód. cita";
            this.colCodigoCita.MinimumWidth = 6;
            this.colCodigoCita.Name = "colCodigoCita";
            this.colCodigoCita.ReadOnly = true;
            // 
            // colFecha
            // 
            this.colFecha.DataPropertyName = "Fecha";
            dataGridViewCellStyle3.Format = "dd/MM/yyyy";
            this.colFecha.DefaultCellStyle = dataGridViewCellStyle3;
            this.colFecha.FillWeight = 70F;
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.MinimumWidth = 6;
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            // 
            // colObservaciones
            // 
            this.colObservaciones.DataPropertyName = "Observaciones";
            this.colObservaciones.FillWeight = 150F;
            this.colObservaciones.HeaderText = "Observaciones";
            this.colObservaciones.MinimumWidth = 6;
            this.colObservaciones.Name = "colObservaciones";
            this.colObservaciones.ReadOnly = true;
            // 
            // colResultadoGeneral
            // 
            this.colResultadoGeneral.DataPropertyName = "ResultadoGeneral";
            this.colResultadoGeneral.FillWeight = 150F;
            this.colResultadoGeneral.HeaderText = "Resultado general";
            this.colResultadoGeneral.MinimumWidth = 6;
            this.colResultadoGeneral.Name = "colResultadoGeneral";
            this.colResultadoGeneral.ReadOnly = true;
            // 
            // colEstado
            // 
            this.colEstado.DataPropertyName = "Estado";
            this.colEstado.FillWeight = 70F;
            this.colEstado.HeaderText = "Estado";
            this.colEstado.MinimumWidth = 6;
            this.colEstado.Name = "colEstado";
            this.colEstado.ReadOnly = true;
            // 
            // PanelDivisor4
            // 
            this.PanelDivisor4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelDivisor4.Location = new System.Drawing.Point(0, 581);
            this.PanelDivisor4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanelDivisor4.Name = "PanelDivisor4";
            this.PanelDivisor4.Size = new System.Drawing.Size(1123, 4);
            this.PanelDivisor4.TabIndex = 8;
            // 
            // PanelInferior
            // 
            this.PanelInferior.Controls.Add(this.lblTotalRegistros);
            this.PanelInferior.Controls.Add(this.btnCerrar);
            this.PanelInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelInferior.Location = new System.Drawing.Point(0, 585);
            this.PanelInferior.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanelInferior.Name = "PanelInferior";
            this.PanelInferior.Size = new System.Drawing.Size(1123, 80);
            this.PanelInferior.TabIndex = 7;
            // 
            // lblTotalRegistros
            // 
            this.lblTotalRegistros.AutoSize = true;
            this.lblTotalRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblTotalRegistros.Location = new System.Drawing.Point(18, 29);
            this.lblTotalRegistros.Name = "lblTotalRegistros";
            this.lblTotalRegistros.Size = new System.Drawing.Size(164, 25);
            this.lblTotalRegistros.TabIndex = 0;
            this.lblTotalRegistros.Text = "Total Registros: 0";
            // 
            // PanelDivisor3
            // 
            this.PanelDivisor3.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelDivisor3.Location = new System.Drawing.Point(0, 157);
            this.PanelDivisor3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanelDivisor3.Name = "PanelDivisor3";
            this.PanelDivisor3.Size = new System.Drawing.Size(1123, 4);
            this.PanelDivisor3.TabIndex = 5;
            // 
            // PanelCheck
            // 
            this.PanelCheck.Controls.Add(this.chkSeleccionar);
            this.PanelCheck.Controls.Add(this.btnExportar);
            this.PanelCheck.Controls.Add(this.btnImprimir);
            this.PanelCheck.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelCheck.Location = new System.Drawing.Point(0, 98);
            this.PanelCheck.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanelCheck.Name = "PanelCheck";
            this.PanelCheck.Size = new System.Drawing.Size(1123, 59);
            this.PanelCheck.TabIndex = 4;
            // 
            // chkSeleccionar
            // 
            this.chkSeleccionar.AutoSize = true;
            this.chkSeleccionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.chkSeleccionar.Location = new System.Drawing.Point(18, 17);
            this.chkSeleccionar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkSeleccionar.Name = "chkSeleccionar";
            this.chkSeleccionar.Size = new System.Drawing.Size(137, 29);
            this.chkSeleccionar.TabIndex = 0;
            this.chkSeleccionar.Text = "Seleccionar";
            this.chkSeleccionar.UseVisualStyleBackColor = true;
            // 
            // PanelDivisor2
            // 
            this.PanelDivisor2.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelDivisor2.Location = new System.Drawing.Point(0, 94);
            this.PanelDivisor2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanelDivisor2.Name = "PanelDivisor2";
            this.PanelDivisor2.Size = new System.Drawing.Size(1123, 4);
            this.PanelDivisor2.TabIndex = 3;
            // 
            // PanelFiltros
            // 
            this.PanelFiltros.Controls.Add(this.lblBuscar);
            this.PanelFiltros.Controls.Add(this.txtBuscador);
            this.PanelFiltros.Controls.Add(this.btnBuscar);
            this.PanelFiltros.Controls.Add(this.btnLimpiarBusqueda);
            this.PanelFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelFiltros.Location = new System.Drawing.Point(0, 14);
            this.PanelFiltros.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanelFiltros.Name = "PanelFiltros";
            this.PanelFiltros.Size = new System.Drawing.Size(1123, 80);
            this.PanelFiltros.TabIndex = 2;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblBuscar.Location = new System.Drawing.Point(18, 29);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(175, 25);
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Text = "Buscar por código:";
            // 
            // txtBuscador
            // 
            this.txtBuscador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtBuscador.Location = new System.Drawing.Point(222, 26);
            this.txtBuscador.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBuscador.MaxLength = 10;
            this.txtBuscador.Name = "txtBuscador";
            this.txtBuscador.Size = new System.Drawing.Size(267, 30);
            this.txtBuscador.TabIndex = 1;
            // 
            // PanelDivisor1
            // 
            this.PanelDivisor1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(47)))), ((int)(((byte)(103)))));
            this.PanelDivisor1.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelDivisor1.Location = new System.Drawing.Point(0, 10);
            this.PanelDivisor1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanelDivisor1.Name = "PanelDivisor1";
            this.PanelDivisor1.Size = new System.Drawing.Size(1123, 4);
            this.PanelDivisor1.TabIndex = 1;
            // 
            // PanelEncabezado
            // 
            this.PanelEncabezado.Controls.Add(this.lblTitulo);
            this.PanelEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelEncabezado.Location = new System.Drawing.Point(0, 0);
            this.PanelEncabezado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanelEncabezado.Name = "PanelEncabezado";
            this.PanelEncabezado.Size = new System.Drawing.Size(1123, 10);
            this.PanelEncabezado.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(47)))), ((int)(((byte)(103)))));
            this.lblTitulo.Location = new System.Drawing.Point(102, 6);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(0, 42);
            this.lblTitulo.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.PanelPrincipalGestionar);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(1129, 669);
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
            this.PanelPrincipalGestionar.Location = new System.Drawing.Point(3, 2);
            this.PanelPrincipalGestionar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanelPrincipalGestionar.Name = "PanelPrincipalGestionar";
            this.PanelPrincipalGestionar.Size = new System.Drawing.Size(1123, 665);
            this.PanelPrincipalGestionar.TabIndex = 0;
            // 
            // PanelCentralGestionar
            // 
            this.PanelCentralGestionar.Controls.Add(this.grpDatos);
            this.PanelCentralGestionar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelCentralGestionar.Location = new System.Drawing.Point(0, 14);
            this.PanelCentralGestionar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanelCentralGestionar.Name = "PanelCentralGestionar";
            this.PanelCentralGestionar.Padding = new System.Windows.Forms.Padding(18, 8, 18, 8);
            this.PanelCentralGestionar.Size = new System.Drawing.Size(1123, 483);
            this.PanelCentralGestionar.TabIndex = 6;
            // 
            // grpDatos
            // 
            this.grpDatos.Controls.Add(this.lblCodigoExamen);
            this.grpDatos.Controls.Add(this.txtCodigoExamen);
            this.grpDatos.Controls.Add(this.lblCliente);
            this.grpDatos.Controls.Add(this.cboCliente);
            this.grpDatos.Controls.Add(this.lblOptometrista);
            this.grpDatos.Controls.Add(this.cboOptometrista);
            this.grpDatos.Controls.Add(this.lblCita);
            this.grpDatos.Controls.Add(this.cboCita);
            this.grpDatos.Controls.Add(this.lblFecha);
            this.grpDatos.Controls.Add(this.dtpFecha);
            this.grpDatos.Controls.Add(this.lblResultadoGeneral);
            this.grpDatos.Controls.Add(this.txtResultadoGeneral);
            this.grpDatos.Controls.Add(this.lblEstado);
            this.grpDatos.Controls.Add(this.cboEstado);
            this.grpDatos.Controls.Add(this.lblObservaciones);
            this.grpDatos.Controls.Add(this.txtObservaciones);
            this.grpDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.grpDatos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(47)))), ((int)(((byte)(103)))));
            this.grpDatos.Location = new System.Drawing.Point(18, 8);
            this.grpDatos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpDatos.Name = "grpDatos";
            this.grpDatos.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpDatos.Size = new System.Drawing.Size(1087, 467);
            this.grpDatos.TabIndex = 0;
            this.grpDatos.TabStop = false;
            this.grpDatos.Text = "Datos del examen visual:";
            // 
            // lblCodigoExamen
            // 
            this.lblCodigoExamen.AutoSize = true;
            this.lblCodigoExamen.ForeColor = System.Drawing.Color.Black;
            this.lblCodigoExamen.Location = new System.Drawing.Point(27, 38);
            this.lblCodigoExamen.Name = "lblCodigoExamen";
            this.lblCodigoExamen.Size = new System.Drawing.Size(156, 25);
            this.lblCodigoExamen.TabIndex = 0;
            this.lblCodigoExamen.Text = "Código examen:";
            // 
            // txtCodigoExamen
            // 
            this.txtCodigoExamen.Enabled = false;
            this.txtCodigoExamen.Location = new System.Drawing.Point(293, 36);
            this.txtCodigoExamen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCodigoExamen.Name = "txtCodigoExamen";
            this.txtCodigoExamen.ReadOnly = true;
            this.txtCodigoExamen.Size = new System.Drawing.Size(249, 30);
            this.txtCodigoExamen.TabIndex = 1;
            this.txtCodigoExamen.TabStop = false;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.ForeColor = System.Drawing.Color.Black;
            this.lblCliente.Location = new System.Drawing.Point(27, 86);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(79, 25);
            this.lblCliente.TabIndex = 2;
            this.lblCliente.Text = "Cliente:";
            // 
            // cboCliente
            // 
            this.cboCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(293, 84);
            this.cboCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(249, 33);
            this.cboCliente.TabIndex = 3;
            // 
            // lblOptometrista
            // 
            this.lblOptometrista.AutoSize = true;
            this.lblOptometrista.ForeColor = System.Drawing.Color.Black;
            this.lblOptometrista.Location = new System.Drawing.Point(27, 134);
            this.lblOptometrista.Name = "lblOptometrista";
            this.lblOptometrista.Size = new System.Drawing.Size(129, 25);
            this.lblOptometrista.TabIndex = 4;
            this.lblOptometrista.Text = "Optometrista:";
            // 
            // cboOptometrista
            // 
            this.cboOptometrista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOptometrista.FormattingEnabled = true;
            this.cboOptometrista.Location = new System.Drawing.Point(293, 132);
            this.cboOptometrista.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboOptometrista.Name = "cboOptometrista";
            this.cboOptometrista.Size = new System.Drawing.Size(249, 33);
            this.cboOptometrista.TabIndex = 5;
            // 
            // lblCita
            // 
            this.lblCita.AutoSize = true;
            this.lblCita.ForeColor = System.Drawing.Color.Black;
            this.lblCita.Location = new System.Drawing.Point(27, 182);
            this.lblCita.Name = "lblCita";
            this.lblCita.Size = new System.Drawing.Size(145, 25);
            this.lblCita.TabIndex = 6;
            this.lblCita.Text = "Cita (opcional):";
            // 
            // cboCita
            // 
            this.cboCita.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCita.FormattingEnabled = true;
            this.cboCita.Location = new System.Drawing.Point(293, 180);
            this.cboCita.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboCita.Name = "cboCita";
            this.cboCita.Size = new System.Drawing.Size(249, 33);
            this.cboCita.TabIndex = 7;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.ForeColor = System.Drawing.Color.Black;
            this.lblFecha.Location = new System.Drawing.Point(578, 38);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(73, 25);
            this.lblFecha.TabIndex = 8;
            this.lblFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "dd/MM/yyyy";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(818, 36);
            this.dtpFecha.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(249, 30);
            this.dtpFecha.TabIndex = 9;
            // 
            // lblResultadoGeneral
            // 
            this.lblResultadoGeneral.AutoSize = true;
            this.lblResultadoGeneral.ForeColor = System.Drawing.Color.Black;
            this.lblResultadoGeneral.Location = new System.Drawing.Point(578, 86);
            this.lblResultadoGeneral.Name = "lblResultadoGeneral";
            this.lblResultadoGeneral.Size = new System.Drawing.Size(175, 25);
            this.lblResultadoGeneral.TabIndex = 10;
            this.lblResultadoGeneral.Text = "Resultado general:";
            // 
            // txtResultadoGeneral
            // 
            this.txtResultadoGeneral.Location = new System.Drawing.Point(818, 84);
            this.txtResultadoGeneral.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtResultadoGeneral.MaxLength = 200;
            this.txtResultadoGeneral.Name = "txtResultadoGeneral";
            this.txtResultadoGeneral.Size = new System.Drawing.Size(249, 30);
            this.txtResultadoGeneral.TabIndex = 11;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.ForeColor = System.Drawing.Color.Black;
            this.lblEstado.Location = new System.Drawing.Point(578, 134);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(79, 25);
            this.lblEstado.TabIndex = 12;
            this.lblEstado.Text = "Estado:";
            // 
            // cboEstado
            // 
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Items.AddRange(new object[] {
            "Pendiente",
            "Realizado",
            "Anulado"});
            this.cboEstado.Location = new System.Drawing.Point(818, 132);
            this.cboEstado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(249, 33);
            this.cboEstado.TabIndex = 13;
            this.cboEstado.SelectedIndexChanged += new System.EventHandler(this.cboEstado_SelectedIndexChanged);
            // 
            // lblObservaciones
            // 
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.ForeColor = System.Drawing.Color.Black;
            this.lblObservaciones.Location = new System.Drawing.Point(578, 182);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Size = new System.Drawing.Size(150, 25);
            this.lblObservaciones.TabIndex = 14;
            this.lblObservaciones.Text = "Observaciones:";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(818, 180);
            this.txtObservaciones.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtObservaciones.MaxLength = 300;
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservaciones.Size = new System.Drawing.Size(249, 77);
            this.txtObservaciones.TabIndex = 15;
            // 
            // PanelDivisor7
            // 
            this.PanelDivisor7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelDivisor7.Location = new System.Drawing.Point(0, 497);
            this.PanelDivisor7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanelDivisor7.Name = "PanelDivisor7";
            this.PanelDivisor7.Size = new System.Drawing.Size(1123, 4);
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
            this.PanelAcciones.Location = new System.Drawing.Point(0, 501);
            this.PanelAcciones.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanelAcciones.Name = "PanelAcciones";
            this.PanelAcciones.Size = new System.Drawing.Size(1123, 80);
            this.PanelAcciones.TabIndex = 4;
            // 
            // PanelDivisor6
            // 
            this.PanelDivisor6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelDivisor6.Location = new System.Drawing.Point(0, 581);
            this.PanelDivisor6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanelDivisor6.Name = "PanelDivisor6";
            this.PanelDivisor6.Size = new System.Drawing.Size(1123, 4);
            this.PanelDivisor6.TabIndex = 3;
            // 
            // PanelInferiorGestionar
            // 
            this.PanelInferiorGestionar.Controls.Add(this.btnCerrarGestionar);
            this.PanelInferiorGestionar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelInferiorGestionar.Location = new System.Drawing.Point(0, 585);
            this.PanelInferiorGestionar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanelInferiorGestionar.Name = "PanelInferiorGestionar";
            this.PanelInferiorGestionar.Size = new System.Drawing.Size(1123, 80);
            this.PanelInferiorGestionar.TabIndex = 2;
            // 
            // PanelDivisor5
            // 
            this.PanelDivisor5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(47)))), ((int)(((byte)(103)))));
            this.PanelDivisor5.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelDivisor5.Location = new System.Drawing.Point(0, 10);
            this.PanelDivisor5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanelDivisor5.Name = "PanelDivisor5";
            this.PanelDivisor5.Size = new System.Drawing.Size(1123, 4);
            this.PanelDivisor5.TabIndex = 1;
            // 
            // PanelEncabezadoGestionar
            // 
            this.PanelEncabezadoGestionar.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelEncabezadoGestionar.Location = new System.Drawing.Point(0, 0);
            this.PanelEncabezadoGestionar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanelEncabezadoGestionar.Name = "PanelEncabezadoGestionar";
            this.PanelEncabezadoGestionar.Size = new System.Drawing.Size(1123, 10);
            this.PanelEncabezadoGestionar.TabIndex = 0;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCerrar.IconChar = FontAwesome.Sharp.IconChar.RightFromBracket;
            this.btnCerrar.IconColor = System.Drawing.Color.Firebrick;
            this.btnCerrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCerrar.IconSize = 28;
            this.btnCerrar.Location = new System.Drawing.Point(972, 22);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(133, 36);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnExportar.IconChar = FontAwesome.Sharp.IconChar.FileExport;
            this.btnExportar.IconColor = System.Drawing.Color.SeaGreen;
            this.btnExportar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExportar.IconSize = 28;
            this.btnExportar.Location = new System.Drawing.Point(821, 12);
            this.btnExportar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(133, 36);
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
            this.btnImprimir.Location = new System.Drawing.Point(972, 12);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(133, 36);
            this.btnImprimir.TabIndex = 2;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnBuscar.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnBuscar.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(47)))), ((int)(((byte)(103)))));
            this.btnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscar.IconSize = 28;
            this.btnBuscar.Location = new System.Drawing.Point(511, 22);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(133, 36);
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
            this.btnLimpiarBusqueda.Location = new System.Drawing.Point(662, 22);
            this.btnLimpiarBusqueda.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLimpiarBusqueda.Name = "btnLimpiarBusqueda";
            this.btnLimpiarBusqueda.Size = new System.Drawing.Size(133, 36);
            this.btnLimpiarBusqueda.TabIndex = 3;
            this.btnLimpiarBusqueda.Text = "Limpiar";
            this.btnLimpiarBusqueda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpiarBusqueda.UseVisualStyleBackColor = true;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnNuevo.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnNuevo.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(47)))), ((int)(((byte)(103)))));
            this.btnNuevo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNuevo.IconSize = 28;
            this.btnNuevo.Location = new System.Drawing.Point(40, 22);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(133, 36);
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
            this.btnGuardar.Location = new System.Drawing.Point(222, 22);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(133, 36);
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
            this.btnCancelar.Location = new System.Drawing.Point(404, 22);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(133, 36);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            this.btnEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnEditar.IconChar = FontAwesome.Sharp.IconChar.Edit;
            this.btnEditar.IconColor = System.Drawing.Color.DarkOrange;
            this.btnEditar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEditar.IconSize = 28;
            this.btnEditar.Location = new System.Drawing.Point(587, 22);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(133, 36);
            this.btnEditar.TabIndex = 3;
            this.btnEditar.Text = "Editar";
            this.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnEliminar.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.btnEliminar.IconColor = System.Drawing.Color.Firebrick;
            this.btnEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEliminar.IconSize = 28;
            this.btnEliminar.Location = new System.Drawing.Point(769, 22);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(133, 36);
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
            this.btnLimpiar.Location = new System.Drawing.Point(951, 22);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(133, 36);
            this.btnLimpiar.TabIndex = 5;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnCerrarGestionar
            // 
            this.btnCerrarGestionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrarGestionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCerrarGestionar.IconChar = FontAwesome.Sharp.IconChar.RightFromBracket;
            this.btnCerrarGestionar.IconColor = System.Drawing.Color.Firebrick;
            this.btnCerrarGestionar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCerrarGestionar.IconSize = 28;
            this.btnCerrarGestionar.Location = new System.Drawing.Point(972, 22);
            this.btnCerrarGestionar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCerrarGestionar.Name = "btnCerrarGestionar";
            this.btnCerrarGestionar.Size = new System.Drawing.Size(133, 36);
            this.btnCerrarGestionar.TabIndex = 0;
            this.btnCerrarGestionar.Text = "Cerrar";
            this.btnCerrarGestionar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCerrarGestionar.UseVisualStyleBackColor = true;
            // 
            // FrmExamenVisual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 698);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmExamenVisual";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exámenes Visuales";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.PanelPrincipal.ResumeLayout(false);
            this.PanelCentral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExamenVisual)).EndInit();
            this.PanelInferior.ResumeLayout(false);
            this.PanelInferior.PerformLayout();
            this.PanelCheck.ResumeLayout(false);
            this.PanelCheck.PerformLayout();
            this.PanelFiltros.ResumeLayout(false);
            this.PanelFiltros.PerformLayout();
            this.PanelEncabezado.ResumeLayout(false);
            this.PanelEncabezado.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.PanelPrincipalGestionar.ResumeLayout(false);
            this.PanelCentralGestionar.ResumeLayout(false);
            this.grpDatos.ResumeLayout(false);
            this.grpDatos.PerformLayout();
            this.PanelAcciones.ResumeLayout(false);
            this.PanelInferiorGestionar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel PanelPrincipal;
        private System.Windows.Forms.Panel PanelEncabezado;
        private System.Windows.Forms.Label lblTitulo;
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
        private System.Windows.Forms.DataGridView dgvExamenVisual;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoExamen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoOptometrista;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoCita;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObservaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResultadoGeneral;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.Panel PanelDivisor4;
        private System.Windows.Forms.Panel PanelInferior;
        private System.Windows.Forms.Label lblTotalRegistros;
        private FontAwesome.Sharp.IconButton btnCerrar;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel PanelPrincipalGestionar;
        private System.Windows.Forms.Panel PanelEncabezadoGestionar;
        private System.Windows.Forms.Panel PanelDivisor5;
        private System.Windows.Forms.Panel PanelCentralGestionar;
        private System.Windows.Forms.GroupBox grpDatos;
        private System.Windows.Forms.Label lblCodigoExamen;
        private System.Windows.Forms.TextBox txtCodigoExamen;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.Label lblOptometrista;
        private System.Windows.Forms.ComboBox cboOptometrista;
        private System.Windows.Forms.Label lblCita;
        private System.Windows.Forms.ComboBox cboCita;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblResultadoGeneral;
        private System.Windows.Forms.TextBox txtResultadoGeneral;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.TextBox txtObservaciones;
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
    }
}
