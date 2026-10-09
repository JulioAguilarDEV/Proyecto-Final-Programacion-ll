using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            // Formulario con el que inicia el sistema.
            // TEMPORAL: inicia en la ventana principal (menú) mientras se crea el Login.
            // Cuando exista el Login se cambia por: Application.Run(new FrmLogin());
            Application.Run(new FrmPrincipal());
        }
    }
}
