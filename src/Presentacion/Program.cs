using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidad;

namespace Presentacion
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (FrmLogin formularioLogin = new FrmLogin())
            {
                if (formularioLogin.ShowDialog() == DialogResult.OK)
                {
                    UsuarioEntidad usuario = formularioLogin.UsuarioAutenticado;
                    Application.Run(new FrmPrincipal(usuario));
                }
            }
        }
    }
}
