namespace Presentacion
{
    partial class FrmCitas
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
            this.PanelDivisor5 = new System.Windows.Forms.Panel();
            this.grpDatos = new System.Windows.Forms.GroupBox();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblCodigoDeCita = new System.Windows.Forms.Label();
            this.txtCodigoCita = new System.Windows.Forms.TextBox();
            this.lblHora = new System.Windows.Forms.Label();
            this.txtHora = new System.Windows.Forms.TextBox();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.txtMConsulta = new System.Windows.Forms.TextBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.PanelDivisor7 = new System.Windows.Forms.Panel();
            this.PanelAcciones = new System.Windows.Forms.Panel();
            this.btnNuevo = new FontAwesome.Sharp.IconButton();
            this.btnGuardar = new FontAwesome.Sharp.IconButton();
            this.btnCancelar = new FontAwesome.Sharp.IconButton();
            this.btnEditar = new FontAwesome.Sharp.IconButton();
            this.btnEliminar = new FontAwesome.Sharp.IconButton();
            this.btnLimpiar = new FontAwesome.Sharp.IconButton();
            this.PanelDivisor6 = new System.Windows.Forms.Panel();
            this.PanelInferiorGestionar = new System.Windows.Forms.Panel();
            this.btnCerrarGestionar = new FontAwesome.Sharp.IconButton();
            this.PanelCentralGestionar = new System.Windows.Forms.Panel();
            this.PanelEncabezadoGestionar = new System.Windows.Forms.Panel();
            this.PanelPrincipalGestionar = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.PanelPrincipal = new System.Windows.Forms.Panel();
            this.PanelCentral = new System.Windows.Forms.Panel();
            this.dgvCitas = new System.Windows.Forms.DataGridView();
            this.PanelDivisor4 = new System.Windows.Forms.Panel();
            this.PanelInferior = new System.Windows.Forms.Panel();
            this.lblTotalRegistros = new System.Windows.Forms.Label();
            this.btnCerrar = new FontAwesome.Sharp.IconButton();
            this.PanelDivisor3 = new System.Windows.Forms.Panel();
            this.PanelCheck = new System.Windows.Forms.Panel();
            this.chkSeleccionar = new System.Windows.Forms.CheckBox();
            this.btnExportar = new FontAwesome.Sharp.IconButton();
            this.btnImprimir = new FontAwesome.Sharp.IconButton();
            this.PanelDivisor2 = new System.Windows.Forms.Panel();
            this.PanelFiltros = new System.Windows.Forms.Panel();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscador = new System.Windows.Forms.TextBox();
            this.btnBuscar = new FontAwesome.Sharp.IconButton();
            this.btnLimpiarBusqueda = new FontAwesome.Sharp.IconButton();
            this.PanelDivisor1 = new System.Windows.Forms.Panel();
            this.PanelEncabezado = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblCodigoCliente = new System.Windows.Forms.Label();
            this.txtCodigoCliente = new System.Windows.Forms.TextBox();
            this.lblCSucursal = new System.Windows.Forms.Label();
            this.txtCSucursal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOptometrista = new System.Windows.Forms.TextBox();
            this.colCodigoOptometrista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApellidos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumeroColegiado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.op = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCorreo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpDatos.SuspendLayout();
            this.PanelAcciones.SuspendLayout();
            this.PanelInferiorGestionar.SuspendLayout();
            this.PanelCentralGestionar.SuspendLayout();
            this.PanelPrincipalGestionar.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.PanelPrincipal.SuspendLayout();
            this.PanelCentral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitas)).BeginInit();
            this.PanelInferior.SuspendLayout();
            this.PanelCheck.SuspendLayout();
            this.PanelFiltros.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelDivisor5
            // 
            this.PanelDivisor5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(47)))), ((int)(((byte)(103)))));
            this.PanelDivisor5.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelDivisor5.Location = new System.Drawing.Point(0, 10);
            this.PanelDivisor5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanelDivisor5.Name = "PanelDivisor5";
            this.PanelDivisor5.Size = new System.Drawing.Size(1195, 4);
            this.PanelDivisor5.TabIndex = 1;
            // 
            // grpDatos
            // 
            this.grpDatos.Controls.Add(this.label1);
            this.grpDatos.Controls.Add(this.txtOptometrista);
            this.grpDatos.Controls.Add(this.lblCSucursal);
            this.grpDatos.Controls.Add(this.txtCSucursal);
            this.grpDatos.Controls.Add(this.lblCodigoCliente);
            this.grpDatos.Controls.Add(this.txtCodigoCliente);
            this.grpDatos.Controls.Add(this.cboEstado);
            this.grpDatos.Controls.Add(this.lblFecha);
            this.grpDatos.Controls.Add(this.dtpFecha);
            this.grpDatos.Controls.Add(this.lblCodigoDeCita);
            this.grpDatos.Controls.Add(this.txtCodigoCita);
            this.grpDatos.Controls.Add(this.lblHora);
            this.grpDatos.Controls.Add(this.txtHora);
            this.grpDatos.Controls.Add(this.lblMotivo);
            this.grpDatos.Controls.Add(this.txtMConsulta);
            this.grpDatos.Controls.Add(this.lblEstado);
            this.grpDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.grpDatos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(47)))), ((int)(((byte)(103)))));
            this.grpDatos.Location = new System.Drawing.Point(18, 8);
            this.grpDatos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpDatos.Name = "grpDatos";
            this.grpDatos.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpDatos.Size = new System.Drawing.Size(1159, 306);
            this.grpDatos.TabIndex = 0;
            this.grpDatos.TabStop = false;
            this.grpDatos.Text = "Datos de la Cita:";
            this.grpDatos.Enter += new System.EventHandler(this.grpDatos_Enter);
            // 
            // cboEstado
            // 
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Items.AddRange(new object[] {
            "Pendiente",
            "Realizado",
            "Anulado"});
            this.cboEstado.Location = new System.Drawing.Point(829, 199);
            this.cboEstado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(249, 33);
            this.cboEstado.TabIndex = 17;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.ForeColor = System.Drawing.Color.Black;
            this.lblFecha.Location = new System.Drawing.Point(589, 38);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(73, 25);
            this.lblFecha.TabIndex = 15;
            this.lblFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "dd/MM/yyyy";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(829, 33);
            this.dtpFecha.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(249, 30);
            this.dtpFecha.TabIndex = 16;
            // 
            // lblCodigoDeCita
            // 
            this.lblCodigoDeCita.AutoSize = true;
            this.lblCodigoDeCita.ForeColor = System.Drawing.Color.Black;
            this.lblCodigoDeCita.Location = new System.Drawing.Point(27, 38);
            this.lblCodigoDeCita.Name = "lblCodigoDeCita";
            this.lblCodigoDeCita.Size = new System.Drawing.Size(121, 25);
            this.lblCodigoDeCita.TabIndex = 0;
            this.lblCodigoDeCita.Text = "Código Cita:";
            // 
            // txtCodigoCita
            // 
            this.txtCodigoCita.Enabled = false;
            this.txtCodigoCita.Location = new System.Drawing.Point(293, 36);
            this.txtCodigoCita.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCodigoCita.Name = "txtCodigoCita";
            this.txtCodigoCita.ReadOnly = true;
            this.txtCodigoCita.Size = new System.Drawing.Size(249, 30);
            this.txtCodigoCita.TabIndex = 1;
            this.txtCodigoCita.TabStop = false;
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.ForeColor = System.Drawing.Color.Black;
            this.lblHora.Location = new System.Drawing.Point(589, 93);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(60, 25);
            this.lblHora.TabIndex = 8;
            this.lblHora.Text = "Hora:";
            // 
            // txtHora
            // 
            this.txtHora.Location = new System.Drawing.Point(829, 90);
            this.txtHora.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtHora.MaxLength = 15;
            this.txtHora.Name = "txtHora";
            this.txtHora.Size = new System.Drawing.Size(249, 30);
            this.txtHora.TabIndex = 9;
            // 
            // lblMotivo
            // 
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.ForeColor = System.Drawing.Color.Black;
            this.lblMotivo.Location = new System.Drawing.Point(589, 147);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(189, 25);
            this.lblMotivo.TabIndex = 10;
            this.lblMotivo.Text = "Motivo De Consulta:";
            // 
            // txtMConsulta
            // 
            this.txtMConsulta.Location = new System.Drawing.Point(829, 147);
            this.txtMConsulta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMConsulta.MaxLength = 100;
            this.txtMConsulta.Name = "txtMConsulta";
            this.txtMConsulta.Size = new System.Drawing.Size(249, 30);
            this.txtMConsulta.TabIndex = 11;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.ForeColor = System.Drawing.Color.Black;
            this.lblEstado.Location = new System.Drawing.Point(589, 199);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(79, 25);
            this.lblEstado.TabIndex = 12;
            this.lblEstado.Text = "Estado:";
            // 
            // PanelDivisor7
            // 
            this.PanelDivisor7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelDivisor7.Location = new System.Drawing.Point(0, 336);
            this.PanelDivisor7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanelDivisor7.Name = "PanelDivisor7";
            this.PanelDivisor7.Size = new System.Drawing.Size(1195, 4);
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
            this.PanelAcciones.Location = new System.Drawing.Point(0, 340);
            this.PanelAcciones.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanelAcciones.Name = "PanelAcciones";
            this.PanelAcciones.Size = new System.Drawing.Size(1195, 80);
            this.PanelAcciones.TabIndex = 4;
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
            // PanelDivisor6
            // 
            this.PanelDivisor6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelDivisor6.Location = new System.Drawing.Point(0, 420);
            this.PanelDivisor6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanelDivisor6.Name = "PanelDivisor6";
            this.PanelDivisor6.Size = new System.Drawing.Size(1195, 4);
            this.PanelDivisor6.TabIndex = 3;
            // 
            // PanelInferiorGestionar
            // 
            this.PanelInferiorGestionar.Controls.Add(this.btnCerrarGestionar);
            this.PanelInferiorGestionar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelInferiorGestionar.Location = new System.Drawing.Point(0, 424);
            this.PanelInferiorGestionar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanelInferiorGestionar.Name = "PanelInferiorGestionar";
            this.PanelInferiorGestionar.Size = new System.Drawing.Size(1195, 80);
            this.PanelInferiorGestionar.TabIndex = 2;
            // 
            // btnCerrarGestionar
            // 
            this.btnCerrarGestionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrarGestionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCerrarGestionar.IconChar = FontAwesome.Sharp.IconChar.RightFromBracket;
            this.btnCerrarGestionar.IconColor = System.Drawing.Color.Firebrick;
            this.btnCerrarGestionar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCerrarGestionar.IconSize = 28;
            this.btnCerrarGestionar.Location = new System.Drawing.Point(1044, 22);
            this.btnCerrarGestionar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCerrarGestionar.Name = "btnCerrarGestionar";
            this.btnCerrarGestionar.Size = new System.Drawing.Size(133, 36);
            this.btnCerrarGestionar.TabIndex = 0;
            this.btnCerrarGestionar.Text = "Cerrar";
            this.btnCerrarGestionar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCerrarGestionar.UseVisualStyleBackColor = true;
            // 
            // PanelCentralGestionar
            // 
            this.PanelCentralGestionar.Controls.Add(this.grpDatos);
            this.PanelCentralGestionar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelCentralGestionar.Location = new System.Drawing.Point(0, 14);
            this.PanelCentralGestionar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanelCentralGestionar.Name = "PanelCentralGestionar";
            this.PanelCentralGestionar.Padding = new System.Windows.Forms.Padding(18, 8, 18, 8);
            this.PanelCentralGestionar.Size = new System.Drawing.Size(1195, 322);
            this.PanelCentralGestionar.TabIndex = 6;
            // 
            // PanelEncabezadoGestionar
            // 
            this.PanelEncabezadoGestionar.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelEncabezadoGestionar.Location = new System.Drawing.Point(0, 0);
            this.PanelEncabezadoGestionar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanelEncabezadoGestionar.Name = "PanelEncabezadoGestionar";
            this.PanelEncabezadoGestionar.Size = new System.Drawing.Size(1195, 10);
            this.PanelEncabezadoGestionar.TabIndex = 0;
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
            this.PanelPrincipalGestionar.Size = new System.Drawing.Size(1195, 504);
            this.PanelPrincipalGestionar.TabIndex = 0;
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
            this.tabControl1.Size = new System.Drawing.Size(1209, 537);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.PanelPrincipal);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(1201, 508);
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
            this.PanelPrincipal.Size = new System.Drawing.Size(1195, 504);
            this.PanelPrincipal.TabIndex = 0;
            // 
            // PanelCentral
            // 
            this.PanelCentral.Controls.Add(this.dgvCitas);
            this.PanelCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelCentral.Location = new System.Drawing.Point(0, 161);
            this.PanelCentral.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanelCentral.Name = "PanelCentral";
            this.PanelCentral.Padding = new System.Windows.Forms.Padding(18, 0, 18, 0);
            this.PanelCentral.Size = new System.Drawing.Size(1195, 259);
            this.PanelCentral.TabIndex = 6;
            // 
            // dgvCitas
            // 
            this.dgvCitas.AllowUserToAddRows = false;
            this.dgvCitas.AllowUserToDeleteRows = false;
            this.dgvCitas.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(244)))));
            this.dgvCitas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCitas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCitas.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(47)))), ((int)(((byte)(103)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(47)))), ((int)(((byte)(103)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCitas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCitas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigoOptometrista,
            this.colNombres,
            this.colApellidos,
            this.colNumeroColegiado,
            this.op,
            this.colCorreo,
            this.colEstado,
            this.colTelefono,
            this.Estado});
            this.dgvCitas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCitas.EnableHeadersVisualStyles = false;
            this.dgvCitas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dgvCitas.Location = new System.Drawing.Point(18, 0);
            this.dgvCitas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvCitas.MultiSelect = false;
            this.dgvCitas.Name = "dgvCitas";
            this.dgvCitas.ReadOnly = true;
            this.dgvCitas.RowHeadersVisible = false;
            this.dgvCitas.RowHeadersWidth = 62;
            this.dgvCitas.RowTemplate.Height = 28;
            this.dgvCitas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCitas.Size = new System.Drawing.Size(1159, 259);
            this.dgvCitas.TabIndex = 0;
            // 
            // PanelDivisor4
            // 
            this.PanelDivisor4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelDivisor4.Location = new System.Drawing.Point(0, 420);
            this.PanelDivisor4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanelDivisor4.Name = "PanelDivisor4";
            this.PanelDivisor4.Size = new System.Drawing.Size(1195, 4);
            this.PanelDivisor4.TabIndex = 8;
            // 
            // PanelInferior
            // 
            this.PanelInferior.Controls.Add(this.lblTotalRegistros);
            this.PanelInferior.Controls.Add(this.btnCerrar);
            this.PanelInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelInferior.Location = new System.Drawing.Point(0, 424);
            this.PanelInferior.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanelInferior.Name = "PanelInferior";
            this.PanelInferior.Size = new System.Drawing.Size(1195, 80);
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
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCerrar.IconChar = FontAwesome.Sharp.IconChar.RightFromBracket;
            this.btnCerrar.IconColor = System.Drawing.Color.Firebrick;
            this.btnCerrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCerrar.IconSize = 28;
            this.btnCerrar.Location = new System.Drawing.Point(1044, 22);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(133, 36);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // PanelDivisor3
            // 
            this.PanelDivisor3.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelDivisor3.Location = new System.Drawing.Point(0, 157);
            this.PanelDivisor3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanelDivisor3.Name = "PanelDivisor3";
            this.PanelDivisor3.Size = new System.Drawing.Size(1195, 4);
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
            this.PanelCheck.Size = new System.Drawing.Size(1195, 59);
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
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnExportar.IconChar = FontAwesome.Sharp.IconChar.FileExport;
            this.btnExportar.IconColor = System.Drawing.Color.SeaGreen;
            this.btnExportar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExportar.IconSize = 28;
            this.btnExportar.Location = new System.Drawing.Point(893, 12);
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
            this.btnImprimir.Location = new System.Drawing.Point(1044, 12);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(133, 36);
            this.btnImprimir.TabIndex = 2;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // PanelDivisor2
            // 
            this.PanelDivisor2.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelDivisor2.Location = new System.Drawing.Point(0, 94);
            this.PanelDivisor2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanelDivisor2.Name = "PanelDivisor2";
            this.PanelDivisor2.Size = new System.Drawing.Size(1195, 4);
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
            this.PanelFiltros.Size = new System.Drawing.Size(1195, 80);
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
            // PanelDivisor1
            // 
            this.PanelDivisor1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(47)))), ((int)(((byte)(103)))));
            this.PanelDivisor1.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelDivisor1.Location = new System.Drawing.Point(0, 10);
            this.PanelDivisor1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanelDivisor1.Name = "PanelDivisor1";
            this.PanelDivisor1.Size = new System.Drawing.Size(1195, 4);
            this.PanelDivisor1.TabIndex = 1;
            // 
            // PanelEncabezado
            // 
            this.PanelEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelEncabezado.Location = new System.Drawing.Point(0, 0);
            this.PanelEncabezado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanelEncabezado.Name = "PanelEncabezado";
            this.PanelEncabezado.Size = new System.Drawing.Size(1195, 10);
            this.PanelEncabezado.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.PanelPrincipalGestionar);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(1201, 508);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Gestionar";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblCodigoCliente
            // 
            this.lblCodigoCliente.AutoSize = true;
            this.lblCodigoCliente.ForeColor = System.Drawing.Color.Black;
            this.lblCodigoCliente.Location = new System.Drawing.Point(27, 87);
            this.lblCodigoCliente.Name = "lblCodigoCliente";
            this.lblCodigoCliente.Size = new System.Drawing.Size(147, 25);
            this.lblCodigoCliente.TabIndex = 18;
            this.lblCodigoCliente.Text = "Codigo Cliente:";
            // 
            // txtCodigoCliente
            // 
            this.txtCodigoCliente.Location = new System.Drawing.Point(293, 90);
            this.txtCodigoCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCodigoCliente.MaxLength = 15;
            this.txtCodigoCliente.Name = "txtCodigoCliente";
            this.txtCodigoCliente.Size = new System.Drawing.Size(249, 30);
            this.txtCodigoCliente.TabIndex = 19;
            // 
            // lblCSucursal
            // 
            this.lblCSucursal.AutoSize = true;
            this.lblCSucursal.ForeColor = System.Drawing.Color.Black;
            this.lblCSucursal.Location = new System.Drawing.Point(27, 147);
            this.lblCSucursal.Name = "lblCSucursal";
            this.lblCSucursal.Size = new System.Drawing.Size(163, 25);
            this.lblCSucursal.TabIndex = 20;
            this.lblCSucursal.Text = "Codigo Sucursal:";
            // 
            // txtCSucursal
            // 
            this.txtCSucursal.Location = new System.Drawing.Point(293, 147);
            this.txtCSucursal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCSucursal.MaxLength = 15;
            this.txtCSucursal.Name = "txtCSucursal";
            this.txtCSucursal.Size = new System.Drawing.Size(249, 30);
            this.txtCSucursal.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(27, 207);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 25);
            this.label1.TabIndex = 22;
            this.label1.Text = "Codigo Optometrista:";
            // 
            // txtOptometrista
            // 
            this.txtOptometrista.Location = new System.Drawing.Point(293, 207);
            this.txtOptometrista.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtOptometrista.MaxLength = 15;
            this.txtOptometrista.Name = "txtOptometrista";
            this.txtOptometrista.Size = new System.Drawing.Size(249, 30);
            this.txtOptometrista.TabIndex = 23;
            // 
            // colCodigoOptometrista
            // 
            this.colCodigoOptometrista.DataPropertyName = "CodigoOptometrista";
            this.colCodigoOptometrista.FillWeight = 60F;
            this.colCodigoOptometrista.HeaderText = "Código";
            this.colCodigoOptometrista.MinimumWidth = 6;
            this.colCodigoOptometrista.Name = "colCodigoOptometrista";
            this.colCodigoOptometrista.ReadOnly = true;
            // 
            // colNombres
            // 
            this.colNombres.DataPropertyName = "Codigo Cita";
            this.colNombres.HeaderText = "Codigo Cita";
            this.colNombres.MinimumWidth = 6;
            this.colNombres.Name = "colNombres";
            this.colNombres.ReadOnly = true;
            // 
            // colApellidos
            // 
            this.colApellidos.DataPropertyName = "Codigo Cliente";
            this.colApellidos.HeaderText = "Codigo Cliente";
            this.colApellidos.MinimumWidth = 6;
            this.colApellidos.Name = "colApellidos";
            this.colApellidos.ReadOnly = true;
            // 
            // colNumeroColegiado
            // 
            this.colNumeroColegiado.DataPropertyName = "Codigo Sucursal";
            this.colNumeroColegiado.HeaderText = "Codigo Sucursal";
            this.colNumeroColegiado.MinimumWidth = 6;
            this.colNumeroColegiado.Name = "colNumeroColegiado";
            this.colNumeroColegiado.ReadOnly = true;
            // 
            // op
            // 
            this.op.HeaderText = "Codigo Optometrista";
            this.op.MinimumWidth = 6;
            this.op.Name = "op";
            this.op.ReadOnly = true;
            // 
            // colCorreo
            // 
            this.colCorreo.DataPropertyName = "Fecha";
            this.colCorreo.FillWeight = 140F;
            this.colCorreo.HeaderText = "Fecha";
            this.colCorreo.MinimumWidth = 6;
            this.colCorreo.Name = "colCorreo";
            this.colCorreo.ReadOnly = true;
            // 
            // colEstado
            // 
            this.colEstado.DataPropertyName = "Hora";
            this.colEstado.FillWeight = 70F;
            this.colEstado.HeaderText = "Hora";
            this.colEstado.MinimumWidth = 6;
            this.colEstado.Name = "colEstado";
            this.colEstado.ReadOnly = true;
            // 
            // colTelefono
            // 
            this.colTelefono.DataPropertyName = "MotivoDeConsulta";
            this.colTelefono.HeaderText = "Motivo De Consulta";
            this.colTelefono.MinimumWidth = 6;
            this.colTelefono.Name = "colTelefono";
            this.colTelefono.ReadOnly = true;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.MinimumWidth = 6;
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            // 
            // FrmCitas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 537);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmCitas";
            this.Text = "FrmCitas";
            this.grpDatos.ResumeLayout(false);
            this.grpDatos.PerformLayout();
            this.PanelAcciones.ResumeLayout(false);
            this.PanelInferiorGestionar.ResumeLayout(false);
            this.PanelCentralGestionar.ResumeLayout(false);
            this.PanelPrincipalGestionar.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.PanelPrincipal.ResumeLayout(false);
            this.PanelCentral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitas)).EndInit();
            this.PanelInferior.ResumeLayout(false);
            this.PanelInferior.PerformLayout();
            this.PanelCheck.ResumeLayout(false);
            this.PanelCheck.PerformLayout();
            this.PanelFiltros.ResumeLayout(false);
            this.PanelFiltros.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelDivisor5;
        private System.Windows.Forms.GroupBox grpDatos;
        private System.Windows.Forms.Label lblCodigoDeCita;
        private System.Windows.Forms.TextBox txtCodigoCita;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.TextBox txtHora;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.TextBox txtMConsulta;
        private System.Windows.Forms.Label lblEstado;
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
        private System.Windows.Forms.Panel PanelCentralGestionar;
        private System.Windows.Forms.Panel PanelEncabezadoGestionar;
        private System.Windows.Forms.Panel PanelPrincipalGestionar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel PanelPrincipal;
        private System.Windows.Forms.Panel PanelCentral;
        private System.Windows.Forms.DataGridView dgvCitas;
        private System.Windows.Forms.Panel PanelDivisor4;
        private System.Windows.Forms.Panel PanelInferior;
        private System.Windows.Forms.Label lblTotalRegistros;
        private FontAwesome.Sharp.IconButton btnCerrar;
        private System.Windows.Forms.Panel PanelDivisor3;
        private System.Windows.Forms.Panel PanelCheck;
        private System.Windows.Forms.CheckBox chkSeleccionar;
        private FontAwesome.Sharp.IconButton btnExportar;
        private FontAwesome.Sharp.IconButton btnImprimir;
        private System.Windows.Forms.Panel PanelDivisor2;
        private System.Windows.Forms.Panel PanelFiltros;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscador;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private FontAwesome.Sharp.IconButton btnLimpiarBusqueda;
        private System.Windows.Forms.Panel PanelDivisor1;
        private System.Windows.Forms.Panel PanelEncabezado;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOptometrista;
        private System.Windows.Forms.Label lblCSucursal;
        private System.Windows.Forms.TextBox txtCSucursal;
        private System.Windows.Forms.Label lblCodigoCliente;
        private System.Windows.Forms.TextBox txtCodigoCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoOptometrista;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombres;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApellidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumeroColegiado;
        private System.Windows.Forms.DataGridViewTextBoxColumn op;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCorreo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
    }
}