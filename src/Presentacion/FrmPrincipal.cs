using FontAwesome.Sharp;
using Entidad;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmPrincipal : Form
    {
        // =====================================================
        // FUNCIONES DE WINDOWS
        // Permiten mover el formulario (que no tiene borde)
        // arrastrando la barra de título.
        // =====================================================

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        // =====================================================
        // POO: ENCAPSULAMIENTO
        // =====================================================

        // Pantalla que se está mostrando en el panel contenedor
        private Form _formularioActivo = null;

        // Ancho original del menú lateral
        private int _anchoMenu;
        private readonly UsuarioEntidad _usuario;
        private IconButton _btnRoles;
        private Label _lblUsuarioPanel;
        private readonly Dictionary<IconButton, string> _textosBotonesMenu =
            new Dictionary<IconButton, string>();

        // Colores del sistema (salen del logo)
        private readonly Color _colorMenu = Color.FromArgb(3, 47, 103);
        private readonly Color _colorSeleccionado = Color.FromArgb(101, 114, 122);

        // =====================================================
        // POO: CONSTRUCTOR
        // =====================================================

        public FrmPrincipal()
        {
            InitializeComponent();
            _anchoMenu = PanelMenu.Width;
            foreach (Control control in PanelMenu.Controls)
            {
                if (control is IconButton && control != _btnRoles)
                {
                    IconButton boton = (IconButton)control;
                    _textosBotonesMenu.Add(boton, boton.Text);
                }
            }

            PanelMenu.SizeChanged += PanelMenu_SizeChanged;
            WindowState = FormWindowState.Maximized;
        }

        public FrmPrincipal(UsuarioEntidad usuario) : this()
        {
            _usuario = usuario;
        }

        // =====================================================
        // EVENTO LOAD DEL FORMULARIO
        // =====================================================

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            MaximizedBounds = Screen.FromControl(this).WorkingArea;
            WindowState = FormWindowState.Maximized;

            MtdCrearBotonRoles();
            MtdMostrarUsuarioPanel();
            MtdAplicarPermisos();

            // Al iniciar el sistema se muestra la pantalla de Inicio (FrmDashboard)
            MtdResaltarBoton(btnInicio);
            MtdAbrirFormulario(new FrmDashboard(), "Inicio");
        }

        private void MtdCrearBotonRoles()
        {
            _btnRoles = new IconButton
            {
                Text = "  Roles y Accesos",
                Dock = DockStyle.None,
                Location = new Point(0, 635),
                Size = new Size(231, 31),
                Padding = new Padding(18, 0, 0, 0),
                TextAlign = ContentAlignment.MiddleLeft,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                BackColor = _colorMenu,
                IconChar = IconChar.UserShield,
                IconColor = Color.White,
                IconSize = 25
            };
            _btnRoles.FlatAppearance.BorderSize = 0;
            _btnRoles.Click += btnRoles_Click;
            PanelMenu.Controls.Add(_btnRoles);
            _textosBotonesMenu.Add(_btnRoles, _btnRoles.Text);
            MtdAjustarBotonRoles();
            _btnRoles.BringToFront();
        }

        // Muestra la identidad de la sesión en el panel inferior y en la barra superior.
        private void MtdMostrarUsuarioPanel()
        {
            if (_usuario == null)
            {
                return;
            }

            lblNombreUsuario.Text = _usuario.NombreCompleto;
            lblNombreUsuario.AutoSize = false;
            lblNombreUsuario.Size = new Size(145, 24);
            lblNombreUsuario.AutoEllipsis = true;
            lblSucursalUsuario.Text = "Rol: " + _usuario.Rol;
            lblSucursalUsuario.AutoSize = false;
            lblSucursalUsuario.Size = new Size(145, 20);
            lblSucursalUsuario.AutoEllipsis = true;

            _lblUsuarioPanel = new Label
            {
                Text = _usuario.NombreCompleto + " | " + _usuario.Rol,
                Location = new Point(760, 35),
                Size = new Size(245, 24),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                TextAlign = ContentAlignment.MiddleRight,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(73, 85, 98),
                AutoEllipsis = true
            };
            _lblUsuarioPanel.MouseDown += PanelBarraTitulo_MouseDown;
            PanelBarraTitulo.Controls.Add(_lblUsuarioPanel);
            _lblUsuarioPanel.BringToFront();
            btnCerrar.BringToFront();
            btnMaximizar.BringToFront();
            btnRestaurar.BringToFront();
            btnMinimizar.BringToFront();
        }

        private void MtdAplicarPermisos()
        {
            btnInicio.Visible = MtdPuedeAcceder("Inicio");
            btnSucursales.Visible = MtdPuedeAcceder("Sucursales");
            btnUsuarios.Visible = MtdPuedeAcceder("Usuarios");
            btnClientes.Visible = MtdPuedeAcceder("Clientes");
            btnCitas.Visible = MtdPuedeAcceder("Citas");
            btnOptometristas.Visible = MtdPuedeAcceder("Optometristas");
            btnExamenes.Visible = MtdPuedeAcceder("Examenes");
            btnRecetas.Visible = MtdPuedeAcceder("Recetas");
            btnTiposProducto.Visible = MtdPuedeAcceder("TiposProducto");
            btnProductos.Visible = MtdPuedeAcceder("Productos");
            btnOrdenes.Visible = MtdPuedeAcceder("Ordenes");
            btnEntregas.Visible = MtdPuedeAcceder("Entregas");
            _btnRoles.Visible = _usuario != null && _usuario.Rol == "Administrador";
        }

        private bool MtdPuedeAcceder(string codigoAcceso)
        {
            return _usuario != null && _usuario.Accesos != null
                && _usuario.Accesos.Contains(codigoAcceso);
        }

        // =====================================================
        // ABRIR UNA PANTALLA DENTRO DEL PANEL CONTENEDOR
        // =====================================================

        private void MtdAbrirFormulario(Form formulario, string titulo)
        {
            // Guardar la pantalla anterior y cambiar a la nueva
            Form formularioAnterior = _formularioActivo;
            _formularioActivo = formulario;

            // Cerrar la pantalla que estaba abierta
            if (formularioAnterior != null && !formularioAnterior.IsDisposed)
            {
                formularioAnterior.Close();
            }

            formulario.AutoScaleMode = AutoScaleMode.None;
            MtdAjustarBotonesFormulario(formulario);

            // La pantalla se muestra dentro del panel, sin borde
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            formulario.FormClosed += MtdFormularioCerrado;

            PanelContenedor.Controls.Add(formulario);
            PanelContenedor.PerformLayout();
            formulario.BringToFront();
            formulario.Show();

            lblTituloPantalla.Text = titulo;
        }

        // Da más espacio a los botones para que el icono no quite espacio al texto.
        private void MtdAjustarBotonesFormulario(Control control)
        {
            foreach (Control elemento in control.Controls)
            {
                if (elemento is IconButton)
                {
                    IconButton boton = (IconButton)elemento;
                    boton.AutoSize = false;
                    boton.Width = Math.Max(boton.Width, 150);
                    boton.Font = new Font("Segoe UI", 9F);
                    boton.IconSize = 20;
                    boton.TextImageRelation = TextImageRelation.ImageBeforeText;
                }

                if (elemento.HasChildren)
                {
                    MtdAjustarBotonesFormulario(elemento);
                }
            }
        }

        // Mantiene el botón de Roles sobre el panel de usuario y adapta el menú compacto.
        private void PanelMenu_SizeChanged(object sender, EventArgs e)
        {
            MtdAjustarBotonRoles();

            bool menuCompacto = PanelMenu.Width <= 70;
            foreach (KeyValuePair<IconButton, string> elemento in _textosBotonesMenu)
            {
                if (elemento.Key.IsDisposed)
                {
                    continue;
                }

                elemento.Key.Text = menuCompacto ? string.Empty : elemento.Value;
                elemento.Key.Padding = menuCompacto ? Padding.Empty : new Padding(18, 0, 0, 0);
                elemento.Key.ImageAlign = menuCompacto
                    ? ContentAlignment.MiddleCenter
                    : ContentAlignment.MiddleLeft;
            }

            lblNombreUsuario.Visible = !menuCompacto;
            lblSucursalUsuario.Visible = !menuCompacto;
        }

        private void MtdAjustarBotonRoles()
        {
            if (_btnRoles == null || _btnRoles.IsDisposed)
            {
                return;
            }

            bool menuCompacto = PanelMenu.Width <= 70;
            _btnRoles.Location = new Point(
                0,
                Math.Max(0, PanelMenu.ClientSize.Height - PanelUsuario.Height - _btnRoles.Height));
            _btnRoles.Width = PanelMenu.ClientSize.Width;
            _btnRoles.Text = menuCompacto ? string.Empty : _textosBotonesMenu[_btnRoles];
            _btnRoles.Padding = menuCompacto ? Padding.Empty : new Padding(18, 0, 0, 0);
            _btnRoles.ImageAlign = menuCompacto
                ? ContentAlignment.MiddleCenter
                : ContentAlignment.MiddleLeft;
        }

        // Si se cierra una pantalla (botón Cerrar), se regresa a Inicio
        private void MtdFormularioCerrado(object sender, FormClosedEventArgs e)
        {
            if (sender == _formularioActivo && !(sender is FrmDashboard))
            {
                MtdResaltarBoton(btnInicio);
                MtdAbrirFormulario(new FrmDashboard(), "Inicio");
            }
        }

        // =====================================================
        // RESALTAR EL BOTÓN SELECCIONADO DEL MENÚ
        // =====================================================

        private void MtdResaltarBoton(IconButton botonSeleccionado)
        {
            // Regresar todos los botones del menú a su color normal
            foreach (Control control in PanelMenu.Controls)
            {
                if (control is IconButton)
                {
                    control.BackColor = _colorMenu;
                }
            }

            // Pintar el botón seleccionado
            botonSeleccionado.BackColor = _colorSeleccionado;
        }

        // Mensaje para las pantallas que todavía no existen
        private void MtdPantallaPendiente(string nombrePantalla)
        {
            MessageBox.Show("La pantalla de " + nombrePantalla + " todavía no está creada.", "En construcción",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // =====================================================
        // BOTONES DEL MENÚ
        // =====================================================

        private void btnInicio_Click(object sender, EventArgs e)
        {
            if (!MtdPuedeAcceder("Inicio")) return;
            MtdResaltarBoton(btnInicio);
            MtdAbrirFormulario(new FrmDashboard(), "Inicio");
        }

        private void btnSucursales_Click(object sender, EventArgs e)
        {
            if (!MtdPuedeAcceder("Sucursales")) return;
            MtdPantallaPendiente("Sucursales");
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            if (!MtdPuedeAcceder("Usuarios")) return;
            MtdResaltarBoton(btnUsuarios);
            MtdAbrirFormulario(new FrmUsuarios(_usuario), "Usuarios");
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            if (!MtdPuedeAcceder("Clientes")) return;
            MtdResaltarBoton(btnClientes);
            MtdAbrirFormulario(new FrmClientes(), "Clientes");
        }

        private void btnCitas_Click(object sender, EventArgs e)
        {
            if (!MtdPuedeAcceder("Citas")) return;
            MtdResaltarBoton(btnCitas);
            MtdAbrirFormulario(new FrmCitas(), "Citas");
        }

        private void btnOptometristas_Click(object sender, EventArgs e)
        {
            if (!MtdPuedeAcceder("Optometristas")) return;
            MtdResaltarBoton(btnOptometristas);
            MtdAbrirFormulario(new FrmOptometrista(), "Optometristas");
        }

        private void btnExamenes_Click(object sender, EventArgs e)
        {
            if (!MtdPuedeAcceder("Examenes")) return;
            MtdResaltarBoton(btnExamenes);
            MtdAbrirFormulario(new FrmExamenVisual(), "Exámenes Visuales");
        }

        private void btnRecetas_Click(object sender, EventArgs e)
        {
            if (!MtdPuedeAcceder("Recetas")) return;
            MtdResaltarBoton(btnRecetas);
            MtdAbrirFormulario(new FrmReceta(), "Recetas");
        }

        private void btnTiposProducto_Click(object sender, EventArgs e)
        {
            if (!MtdPuedeAcceder("TiposProducto")) return;
            MtdResaltarBoton(btnTiposProducto);
            MtdAbrirFormulario(new FrmTiposDeProducto(), "Tipos de Producto");
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            if (!MtdPuedeAcceder("Productos")) return;
            MtdResaltarBoton(btnProductos);
            MtdAbrirFormulario(new FrmProductos(), "Productos Ópticos");
        }

        private void btnOrdenes_Click(object sender, EventArgs e)
        {
            if (!MtdPuedeAcceder("Ordenes")) return;
            MtdResaltarBoton(btnOrdenes);
            MtdAbrirFormulario(new FrmOrdenes(), "Órdenes");
        }

        private void btnEntregas_Click(object sender, EventArgs e)
        {
            if (!MtdPuedeAcceder("Entregas")) return;
            MtdPantallaPendiente("Entregas");
        }

        private void btnRoles_Click(object sender, EventArgs e)
        {
            if (_usuario == null || _usuario.Rol != "Administrador") return;
            MtdResaltarBoton(_btnRoles);
            MtdAbrirFormulario(new FrmRoles(_usuario), "Roles y Accesos");
        }

        // =====================================================
        // BARRA DE TÍTULO
        // =====================================================

        // Botón hamburguesa: esconde o muestra el menú
        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (PanelMenu.Width == _anchoMenu)
            {
                PanelMenu.Width = 70;
            }
            else
            {
                PanelMenu.Width = _anchoMenu;
            }

            PanelMenu_SizeChanged(PanelMenu, EventArgs.Empty);
        }

        // Mover la ventana arrastrando la barra de título
        private void PanelBarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            // Para que al maximizar no tape la barra de tareas de Windows
            this.MaximizedBounds = Screen.FromControl(this).WorkingArea;
            this.WindowState = FormWindowState.Maximized;

            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;

            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblTituloPantalla_Click(object sender, EventArgs e)
        {

        }

        private void lblRolUsuario_Click(object sender, EventArgs e)
        {

        }
    }
}
