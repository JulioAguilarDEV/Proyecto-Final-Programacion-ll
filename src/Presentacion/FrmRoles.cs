using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Presentacion
{
    public class FrmRoles : Form
    {
        private readonly RolNegocio _rolNegocio = new RolNegocio();
        private readonly DataGridView _dgvRoles = new DataGridView();
        private readonly TextBox _txtCodigo = new TextBox();
        private readonly TextBox _txtNombre = new TextBox();
        private readonly TextBox _txtDescripcion = new TextBox();
        private readonly TextBox _txtBuscar = new TextBox();
        private readonly ComboBox _cboxEstado = new ComboBox();
        private readonly CheckedListBox _clbAccesos = new CheckedListBox();
        private string _nombreAnterior = string.Empty;

        private sealed class OpcionAcceso
        {
            public string Codigo { get; set; }
            public string Nombre { get; set; }

            public override string ToString()
            {
                return Nombre;
            }
        }

        public FrmRoles()
        {
            MtdConfigurarFormulario();
            MtdCargarRoles();
        }

        // Muestra el nombre y rol del usuario conectado.
        public FrmRoles(UsuarioEntidad usuario) : this()
        {
            if (usuario == null)
            {
                return;
            }

            Label lblUsuarioConectado = new Label
            {
                Text = "Conectado: " + usuario.NombreCompleto + " | Rol: " + usuario.Rol,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(3, 47, 103),
                Location = new Point(560, 22),
                Size = new Size(580, 24),
                TextAlign = ContentAlignment.MiddleRight,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                AutoEllipsis = true
            };
            Controls.Add(lblUsuarioConectado);
            lblUsuarioConectado.BringToFront();
        }

        // Crea los controles y distribuye las secciones del CRUD de roles.
        private void MtdConfigurarFormulario()
        {
            Text = "Administración de Roles y Accesos";
            BackColor = Color.FromArgb(253, 252, 250);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(1000, 650);
            Size = new Size(1180, 720);
            StartPosition = FormStartPosition.CenterParent;

            Label titulo = new Label
            {
                Text = "Administración de Roles y Accesos",
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = Color.FromArgb(3, 47, 103),
                Location = new Point(20, 15),
                AutoSize = true
            };
            Controls.Add(titulo);

            GroupBox grupoRoles = new GroupBox
            {
                Text = "Roles existentes",
                Location = new Point(20, 65),
                Size = new Size(510, 555),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left
            };
            Controls.Add(grupoRoles);

            _dgvRoles.Location = new Point(12, 72);
            _dgvRoles.Size = new Size(486, 465);
            _dgvRoles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _dgvRoles.ReadOnly = true;
            _dgvRoles.AllowUserToAddRows = false;
            _dgvRoles.AllowUserToDeleteRows = false;
            _dgvRoles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _dgvRoles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dgvRoles.MultiSelect = false;
            _dgvRoles.Columns.Add("CodigoRol", "Código");
            _dgvRoles.Columns.Add("NombreRol", "Rol");
            _dgvRoles.Columns.Add("Descripcion", "Descripción");
            _dgvRoles.Columns.Add("Estado", "Estado");
            _dgvRoles.CellClick += MtdSeleccionarRol;
            grupoRoles.Controls.Add(_dgvRoles);

            _txtBuscar.Location = new Point(12, 34);
            _txtBuscar.Size = new Size(345, 25);
            grupoRoles.Controls.Add(_txtBuscar);

            Button btnBuscar = MtdCrearBoton("Buscar", 365, 31, 130, 30);
            btnBuscar.Click += MtdBuscarRol;
            grupoRoles.Controls.Add(btnBuscar);

            GroupBox grupoEditar = new GroupBox
            {
                Text = "Datos del rol y accesos al menú",
                Location = new Point(550, 65),
                Size = new Size(590, 555),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            };
            Controls.Add(grupoEditar);

            _txtCodigo.Location = new Point(155, 32);
            _txtCodigo.Size = new Size(90, 25);
            _txtCodigo.ReadOnly = true;
            grupoEditar.Controls.Add(MtdCrearEtiqueta("Código:", 20, 35));
            grupoEditar.Controls.Add(_txtCodigo);
            grupoEditar.Controls.Add(MtdCrearEtiqueta("Nombre:", 20, 75));
            _txtNombre.Location = new Point(155, 72);
            _txtNombre.Size = new Size(400, 25);
            _txtNombre.MaxLength = 30;
            grupoEditar.Controls.Add(_txtNombre);
            grupoEditar.Controls.Add(MtdCrearEtiqueta("Descripción:", 20, 115));
            _txtDescripcion.Location = new Point(155, 112);
            _txtDescripcion.Size = new Size(400, 25);
            _txtDescripcion.MaxLength = 150;
            grupoEditar.Controls.Add(_txtDescripcion);
            grupoEditar.Controls.Add(MtdCrearEtiqueta("Estado:", 20, 155));
            _cboxEstado.Location = new Point(155, 152);
            _cboxEstado.Size = new Size(180, 25);
            _cboxEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboxEstado.Items.AddRange(new object[] { "Activo", "Inactivo" });
            grupoEditar.Controls.Add(_cboxEstado);
            grupoEditar.Controls.Add(MtdCrearEtiqueta("Accesos visibles:", 20, 198));

            _clbAccesos.Location = new Point(155, 192);
            _clbAccesos.Size = new Size(400, 255);
            _clbAccesos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _clbAccesos.CheckOnClick = true;
            _clbAccesos.ItemCheck += MtdValidarAccesoInicio;
            grupoEditar.Controls.Add(_clbAccesos);
            MtdCargarOpcionesAcceso();

            Button btnNuevo = MtdCrearBoton("Nuevo", 20, 475, 120, 35);
            btnNuevo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnNuevo.Click += MtdNuevoRol;
            grupoEditar.Controls.Add(btnNuevo);

            Button btnGuardar = MtdCrearBoton("Guardar", 150, 475, 120, 35);
            btnGuardar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnGuardar.Click += MtdGuardarRol;
            grupoEditar.Controls.Add(btnGuardar);

            Button btnEliminar = MtdCrearBoton("Eliminar", 280, 475, 120, 35);
            btnEliminar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEliminar.Click += MtdEliminarRol;
            grupoEditar.Controls.Add(btnEliminar);

            Button btnLimpiar = MtdCrearBoton("Limpiar", 410, 475, 145, 35);
            btnLimpiar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnLimpiar.Click += delegate { MtdLimpiar(); };
            grupoEditar.Controls.Add(btnLimpiar);

            Button btnCerrar = MtdCrearBoton("Cerrar", 1010, 635, 130, 35);
            btnCerrar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCerrar.Click += delegate { Close(); };
            Controls.Add(btnCerrar);
        }

        // Agrega las opciones de acceso que se pueden asignar a un rol.
        private void MtdCargarOpcionesAcceso()
        {
            string[] codigos = RolNegocio.AccesosDisponibles;
            string[] nombres =
            {
                "Inicio", "Sucursales", "Usuarios", "Clientes", "Citas", "Optometristas",
                "Exámenes Visuales", "Recetas", "Tipos de Producto", "Productos Ópticos",
                "Órdenes", "Entregas"
            };

            for (int i = 0; i < codigos.Length; i++)
            {
                _clbAccesos.Items.Add(new OpcionAcceso { Codigo = codigos[i], Nombre = nombres[i] });
            }

            _clbAccesos.SetItemChecked(0, true);
        }

        // Evita que un rol se quede sin acceso a la pantalla de Inicio.
        private void MtdValidarAccesoInicio(object sender, ItemCheckEventArgs e)
        {
            if (e.Index == 0 && e.NewValue == CheckState.Unchecked)
            {
                e.NewValue = CheckState.Checked;
            }
        }

        // Carga en la tabla los roles y sus accesos desde la capa Negocio.
        private void MtdCargarRoles()
        {
            try
            {
                _dgvRoles.Rows.Clear();
                List<RolEntidad> roles = _rolNegocio.MtdConsultar();
                foreach (RolEntidad rol in roles)
                {
                    int indice = _dgvRoles.Rows.Add(rol.CodigoRol, rol.NombreRol, rol.Descripcion, rol.Estado);
                    _dgvRoles.Rows[indice].Tag = rol;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Copia los datos del rol seleccionado a los controles del formulario.
        private void MtdSeleccionarRol(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || _dgvRoles.Rows[e.RowIndex].Tag == null)
            {
                return;
            }

            RolEntidad rol = (RolEntidad)_dgvRoles.Rows[e.RowIndex].Tag;
            _txtCodigo.Text = rol.CodigoRol.ToString();
            _nombreAnterior = rol.NombreRol;
            _txtNombre.Text = rol.NombreRol;
            _txtDescripcion.Text = rol.Descripcion;
            _cboxEstado.SelectedItem = rol.Estado;

            for (int i = 0; i < _clbAccesos.Items.Count; i++)
            {
                OpcionAcceso opcion = (OpcionAcceso)_clbAccesos.Items[i];
                _clbAccesos.SetItemChecked(i, rol.Accesos.Contains(opcion.Codigo));
            }
        }

        // Busca un rol por su código.
        private void MtdBuscarRol(object sender, EventArgs e)
        {
            int codigoRol;
            if (!int.TryParse(_txtBuscar.Text.Trim(), out codigoRol))
            {
                MessageBox.Show("Ingrese un código de rol válido.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                RolEntidad rol = _rolNegocio.MtdBuscar(codigoRol);
                if (rol == null)
                {
                    MessageBox.Show("No se encontró el rol solicitado.", "Búsqueda",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                for (int i = 0; i < _dgvRoles.Rows.Count; i++)
                {
                    if (Convert.ToInt32(_dgvRoles.Rows[i].Cells["CodigoRol"].Value) == codigoRol)
                    {
                        _dgvRoles.Rows[i].Selected = true;
                        MtdSeleccionarRol(_dgvRoles, new DataGridViewCellEventArgs(0, i));
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Prepara los controles para ingresar un rol nuevo.
        private void MtdNuevoRol(object sender, EventArgs e)
        {
            MtdLimpiar();
            _txtNombre.Focus();
        }

        // Agrega o actualiza el rol y los accesos marcados.
        private void MtdGuardarRol(object sender, EventArgs e)
        {
            try
            {
                RolEntidad rol = new RolEntidad
                {
                    NombreRol = _txtNombre.Text.Trim(),
                    Descripcion = _txtDescripcion.Text.Trim(),
                    Estado = _cboxEstado.SelectedItem == null ? string.Empty : _cboxEstado.SelectedItem.ToString(),
                    Accesos = MtdObtenerAccesosSeleccionados()
                };

                if (string.IsNullOrWhiteSpace(_txtCodigo.Text))
                {
                    _rolNegocio.MtdAgregar(rol);
                    MessageBox.Show("El rol se agregó correctamente.", "Roles",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    rol.CodigoRol = Convert.ToInt32(_txtCodigo.Text);
                    _rolNegocio.MtdEditar(rol, _nombreAnterior);
                    MessageBox.Show("El rol se actualizó correctamente.", "Roles",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                MtdLimpiar();
                MtdCargarRoles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "No se pudo guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Devuelve los códigos de acceso marcados en la lista.
        private List<string> MtdObtenerAccesosSeleccionados()
        {
            List<string> accesos = new List<string>();
            foreach (object elemento in _clbAccesos.CheckedItems)
            {
                accesos.Add(((OpcionAcceso)elemento).Codigo);
            }

            return accesos;
        }

        // Confirma y elimina el rol seleccionado.
        private void MtdEliminarRol(object sender, EventArgs e)
        {
            int codigoRol;
            if (!int.TryParse(_txtCodigo.Text, out codigoRol))
            {
                MessageBox.Show("Seleccione un rol para eliminar.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Está seguro de eliminar este rol?", "Confirmar eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                _rolNegocio.MtdEliminar(codigoRol);
                MtdLimpiar();
                MtdCargarRoles();
                MessageBox.Show("El rol se eliminó correctamente.", "Roles",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "No se pudo eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Borra los campos y las selecciones del formulario.
        private void MtdLimpiar()
        {
            _txtCodigo.Clear();
            _txtNombre.Clear();
            _txtDescripcion.Clear();
            _txtBuscar.Clear();
            _cboxEstado.SelectedIndex = -1;
            _nombreAnterior = string.Empty;
            for (int i = 0; i < _clbAccesos.Items.Count; i++)
            {
                _clbAccesos.SetItemChecked(i, i == 0);
            }

            _dgvRoles.ClearSelection();
        }

        private Label MtdCrearEtiqueta(string texto, int x, int y)
        {
            return new Label { Text = texto, Location = new Point(x, y), AutoSize = true };
        }

        private Button MtdCrearBoton(string texto, int x, int y, int ancho, int alto)
        {
            return new Button
            {
                Text = texto,
                Location = new Point(x, y),
                Size = new Size(ancho, alto),
                BackColor = Color.FromArgb(3, 47, 103),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
        }
    }
}
