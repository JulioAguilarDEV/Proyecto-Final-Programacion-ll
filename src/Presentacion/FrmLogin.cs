using Entidad;
using Negocio;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmLogin : Form
    {
        private readonly UsuarioNegocio _usuarioNegocio = new UsuarioNegocio();

        // Prepara el formulario y mantiene la contraseña oculta al escribir.
        public FrmLogin()
        {
            InitializeComponent();
            MtdConfigurarDiseno();
            txtContraseña.UseSystemPasswordChar = true;
            AcceptButton = btnIngresar;
            CancelButton = btnSalir;
        }

        public UsuarioEntidad UsuarioAutenticado { get; private set; }

        private void MtdConfigurarDiseno()
        {
            BackColor = Color.FromArgb(238, 246, 255);
            Font = new Font("Segoe UI", 10F);
            ClientSize = new Size(900, 580);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inicio de sesión - Ópticas Visión";

            Panel panelSuperior = new Panel
            {
                BackColor = Color.FromArgb(3, 47, 103),
                Dock = DockStyle.Top,
                Height = 12
            };
            Controls.Add(panelSuperior);
            panelSuperior.BringToFront();

            label1.Text = "¡Bienvenido!";
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(3, 47, 103);
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Location = new Point(0, 40);
            label1.Size = new Size(ClientSize.Width, 48);
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            Label lblIndicaciones = new Label
            {
                Text = "Inicia sesión para continuar",
                Font = new Font("Segoe UI", 11F),
                ForeColor = Color.FromArgb(90, 110, 130),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(0, 91),
                Size = new Size(ClientSize.Width, 28),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            Controls.Add(lblIndicaciones);

            groupBox1.Text = "Datos de acceso";
            groupBox1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox1.ForeColor = Color.FromArgb(3, 47, 103);
            groupBox1.BackColor = Color.White;
            groupBox1.Location = new Point(180, 145);
            groupBox1.Size = new Size(540, 365);
            groupBox1.Anchor = AnchorStyles.Top;

            lblNombreUsuario.Text = "Nombre de usuario";
            lblNombreUsuario.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNombreUsuario.ForeColor = Color.FromArgb(55, 75, 95);
            lblNombreUsuario.Location = new Point(45, 54);

            txtNombreUsuario.Font = new Font("Segoe UI", 12F);
            txtNombreUsuario.BackColor = Color.FromArgb(247, 250, 255);
            txtNombreUsuario.ForeColor = Color.FromArgb(35, 50, 70);
            txtNombreUsuario.BorderStyle = BorderStyle.FixedSingle;
            txtNombreUsuario.Location = new Point(45, 80);
            txtNombreUsuario.Size = new Size(445, 32);
            txtNombreUsuario.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            lblContraseña.Text = "Contraseña";
            lblContraseña.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblContraseña.ForeColor = Color.FromArgb(55, 75, 95);
            lblContraseña.Location = new Point(45, 139);

            txtContraseña.Font = new Font("Segoe UI", 12F);
            txtContraseña.BackColor = Color.FromArgb(247, 250, 255);
            txtContraseña.ForeColor = Color.FromArgb(35, 50, 70);
            txtContraseña.BorderStyle = BorderStyle.FixedSingle;
            txtContraseña.Location = new Point(45, 165);
            txtContraseña.Size = new Size(445, 32);
            txtContraseña.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            Label lblNota = new Label
            {
                Text = "Tu contraseña se mostrará protegida.",
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(105, 120, 135),
                Location = new Point(45, 205),
                AutoSize = true
            };
            groupBox1.Controls.Add(lblNota);

            btnIngresar.Text = "Ingresar";
            btnIngresar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnIngresar.IconChar = FontAwesome.Sharp.IconChar.ArrowRight;
            btnIngresar.IconColor = Color.White;
            btnIngresar.BackColor = Color.FromArgb(22, 160, 133);
            btnIngresar.ForeColor = Color.White;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.FlatAppearance.BorderSize = 0;
            btnIngresar.FlatAppearance.MouseOverBackColor = Color.FromArgb(18, 135, 113);
            btnIngresar.Location = new Point(45, 260);
            btnIngresar.Size = new Size(180, 48);
            btnIngresar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

            btnLimpiar.Text = "Limpiar";
            btnLimpiar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLimpiar.IconColor = Color.FromArgb(3, 47, 103);
            btnLimpiar.BackColor = Color.FromArgb(225, 239, 255);
            btnLimpiar.ForeColor = Color.FromArgb(3, 47, 103);
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.FlatAppearance.BorderColor = Color.FromArgb(175, 205, 235);
            btnLimpiar.FlatAppearance.MouseOverBackColor = Color.FromArgb(205, 228, 250);
            btnLimpiar.Location = new Point(245, 260);
            btnLimpiar.Size = new Size(125, 48);
            btnLimpiar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

            btnSalir.Text = "Salir";
            btnSalir.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSalir.BackColor = Color.FromArgb(255, 239, 237);
            btnSalir.ForeColor = Color.FromArgb(185, 55, 55);
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.FlatAppearance.BorderColor = Color.FromArgb(245, 195, 190);
            btnSalir.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 222, 218);
            btnSalir.Location = new Point(390, 260);
            btnSalir.Size = new Size(100, 48);
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

            Label lblMarca = new Label
            {
                Text = "ÓPTICAS VISIÓN GUATEMALA, S. A.",
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                ForeColor = Color.FromArgb(95, 120, 145),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(0, 530),
                Size = new Size(ClientSize.Width, 24),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            };
            Controls.Add(lblMarca);
        }

        // Valida las credenciales y abre el sistema si el usuario está activo.
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioAutenticado = _usuarioNegocio.MtdIniciarSesion(
                    txtNombreUsuario.Text, txtContraseña.Text);

                if (UsuarioAutenticado == null)
                {
                    MessageBox.Show("Usuario o contraseña incorrectos, o la cuenta no está activa.",
                        "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtContraseña.Clear();
                    txtContraseña.Focus();
                    return;
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Limpia los campos del formulario.
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombreUsuario.Clear();
            txtContraseña.Clear();
            txtNombreUsuario.Focus();
        }

        // Cierra el formulario de inicio de sesión.
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
