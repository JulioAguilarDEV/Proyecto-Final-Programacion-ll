using FontAwesome.Sharp;
using System;
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
        }

        // =====================================================
        // EVENTO LOAD DEL FORMULARIO
        // =====================================================

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            // Al iniciar el sistema se muestra la pantalla de Inicio (FrmDashboard)
            MtdResaltarBoton(btnInicio);
            MtdAbrirFormulario(new FrmDashboard(), "Inicio");
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

            // La pantalla se muestra dentro del panel, sin borde
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            formulario.FormClosed += MtdFormularioCerrado;

            PanelContenedor.Controls.Add(formulario);
            formulario.BringToFront();
            formulario.Show();

            lblTituloPantalla.Text = titulo;
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
            MtdResaltarBoton(btnInicio);
            MtdAbrirFormulario(new FrmDashboard(), "Inicio");
        }

        private void btnSucursales_Click(object sender, EventArgs e)
        {
            MtdPantallaPendiente("Sucursales");
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            MtdResaltarBoton(btnUsuarios);
            MtdAbrirFormulario(new FrmUsuarios(), "Usuarios");
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            MtdResaltarBoton(btnClientes);
            MtdAbrirFormulario(new FrmClientes(), "Clientes");
        }

        private void btnCitas_Click(object sender, EventArgs e)
        {
            MtdResaltarBoton(btnCitas);
            MtdAbrirFormulario(new FrmCitas(), "Citas");
        }

        private void btnOptometristas_Click(object sender, EventArgs e)
        {
            MtdResaltarBoton(btnOptometristas);
            MtdAbrirFormulario(new FrmOptometrista(), "Optometristas");
        }

        private void btnExamenes_Click(object sender, EventArgs e)
        {
            MtdResaltarBoton(btnExamenes);
            MtdAbrirFormulario(new FrmExamenVisual(), "Exámenes Visuales");
        }

        private void btnRecetas_Click(object sender, EventArgs e)
        {
            MtdResaltarBoton(btnRecetas);
            MtdAbrirFormulario(new FrmReceta(), "Recetas");
        }

        private void btnTiposProducto_Click(object sender, EventArgs e)
        {
            MtdResaltarBoton(btnTiposProducto);
            MtdAbrirFormulario(new FrmTiposDeProducto(), "Tipos de Producto");
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            MtdResaltarBoton(btnProductos);
            MtdAbrirFormulario(new FrmProductos(), "Productos Ópticos");
        }

        private void btnOrdenes_Click(object sender, EventArgs e)
        {
            MtdResaltarBoton(btnOrdenes);
            MtdAbrirFormulario(new FrmOrdenes(), "Órdenes");
        }

        private void btnEntregas_Click(object sender, EventArgs e)
        {
            MtdPantallaPendiente("Entregas");
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
