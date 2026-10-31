using Entidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmUsuarios : Form
    {
        public FrmUsuarios()
        {
            InitializeComponent();
        }

        // Muestra en ambos encabezados el usuario y el rol de la sesión.
        public FrmUsuarios(UsuarioEntidad usuario) : this()
        {
            MtdMostrarUsuarioConectado(usuario);
        }

        // Agrega el texto de sesión al panel superior existente.
        private void MtdMostrarUsuarioConectado(UsuarioEntidad usuario)
        {
            if (usuario == null)
            {
                return;
            }

            string texto = "Conectado: " + usuario.NombreCompleto + " | Rol: " + usuario.Rol;
            MtdAgregarUsuarioAlEncabezado(PanelEncabezado, texto);
            MtdAgregarUsuarioAlEncabezado(PanelEncabezadoGestionar, texto);
        }

        // Presenta la identidad de la sesión dentro de un panel de encabezado.
        private void MtdAgregarUsuarioAlEncabezado(Panel panel, string texto)
        {
            panel.Height = 36;
            panel.BackColor = System.Drawing.Color.FromArgb(253, 252, 250);
            panel.Controls.Add(new Label
            {
                Text = texto,
                Dock = DockStyle.Right,
                Width = 480,
                TextAlign = System.Drawing.ContentAlignment.MiddleRight,
                ForeColor = System.Drawing.Color.FromArgb(3, 47, 103),
                Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold),
                AutoEllipsis = true
            });
        }

        private void grpDatos_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void PanelPrincipalGestionar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PanelEncabezadoGestionar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PanelDivisor5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PanelInferiorGestionar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCerrarGestionar_Click(object sender, EventArgs e)
        {

        }

        private void PanelDivisor6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PanelAcciones_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        private void PanelDivisor7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PanelCentralGestionar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtSucursalPer_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblSucursalPerteneciente_Click(object sender, EventArgs e)
        {

        }

        private void txtNombreUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }

        private void txtCodigoUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblCodigoDeUsuario_Click(object sender, EventArgs e)
        {

        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblContraseña_Click(object sender, EventArgs e)
        {

        }

        private void rdbInactivo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdbActivo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lblEstado_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void PanelPrincipal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PanelEncabezado_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PanelDivisor1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PanelFiltros_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLimpiarBusqueda_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblBuscar_Click(object sender, EventArgs e)
        {

        }

        private void PanelDivisor2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PanelCheck_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {

        }

        private void chkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void PanelDivisor3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PanelInferior_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalRegistros_Click(object sender, EventArgs e)
        {

        }

        private void PanelDivisor4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PanelCentral_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvCitas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
