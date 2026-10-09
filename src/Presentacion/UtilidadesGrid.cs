using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    // =====================================================
    // CLASE DE APOYO PARA LOS DATAGRIDVIEW
    // La usan todas las pantallas para los botones
    // Exportar e Imprimir de la pestaña Consultar.
    // =====================================================

    public class UtilidadesGrid
    {
        // =====================================================
        // POO: ENCAPSULAMIENTO
        // Datos que se necesitan mientras se imprime.
        // =====================================================

        private DataGridView _dgvImprimir;
        private string _tituloImprimir;
        private int _filaActual;

        // =====================================================
        // EXPORTAR
        // Guarda los registros del DataGridView en un archivo
        // CSV que se puede abrir con Excel.
        // =====================================================

        public void MtdExportar(DataGridView dgv, string nombreArchivo)
        {
            try
            {
                // Validar que existan registros
                if (dgv.Rows.Count == 0)
                {
                    MessageBox.Show("No hay registros para exportar.", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Preguntar dónde se guardará el archivo
                SaveFileDialog guardarArchivo = new SaveFileDialog();
                guardarArchivo.Filter = "Archivo CSV (*.csv)|*.csv";
                guardarArchivo.FileName = nombreArchivo + ".csv";

                if (guardarArchivo.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                // Separador de columnas que usa Excel en esta computadora
                string separador = CultureInfo.CurrentCulture.TextInfo.ListSeparator;

                StringBuilder contenido = new StringBuilder();

                // 1. Escribir los encabezados de las columnas
                bool primeraColumna = true;
                foreach (DataGridViewColumn columna in dgv.Columns)
                {
                    if (!columna.Visible)
                    {
                        continue;
                    }

                    if (!primeraColumna)
                    {
                        contenido.Append(separador);
                    }

                    contenido.Append(MtdTextoCsv(columna.HeaderText));
                    primeraColumna = false;
                }
                contenido.AppendLine();

                // 2. Escribir cada fila del DataGridView
                foreach (DataGridViewRow fila in dgv.Rows)
                {
                    primeraColumna = true;
                    foreach (DataGridViewColumn columna in dgv.Columns)
                    {
                        if (!columna.Visible)
                        {
                            continue;
                        }

                        if (!primeraColumna)
                        {
                            contenido.Append(separador);
                        }

                        object valor = fila.Cells[columna.Index].FormattedValue;
                        contenido.Append(MtdTextoCsv(valor == null ? "" : valor.ToString()));
                        primeraColumna = false;
                    }
                    contenido.AppendLine();
                }

                // 3. Guardar el archivo (UTF8 para que Excel muestre bien las tildes)
                File.WriteAllText(guardarArchivo.FileName, contenido.ToString(), Encoding.UTF8);

                MessageBox.Show("Registros exportados correctamente.", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Encierra el texto entre comillas para que el CSV no se desordene
        private string MtdTextoCsv(string texto)
        {
            return "\"" + texto.Replace("\"", "\"\"") + "\"";
        }

        // =====================================================
        // IMPRIMIR
        // Muestra una vista previa con los registros del
        // DataGridView desde donde se puede imprimir.
        // =====================================================

        public void MtdImprimir(DataGridView dgv, string titulo)
        {
            try
            {
                // Validar que existan registros
                if (dgv.Rows.Count == 0)
                {
                    MessageBox.Show("No hay registros para imprimir.", "Imprimir", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _dgvImprimir = dgv;
                _tituloImprimir = titulo;

                // Documento que se va a imprimir (hoja horizontal)
                PrintDocument documento = new PrintDocument();
                documento.DefaultPageSettings.Landscape = true;
                documento.BeginPrint += MtdIniciarImpresion;
                documento.PrintPage += MtdImprimirPagina;

                // Vista previa del documento
                PrintPreviewDialog vistaPrevia = new PrintPreviewDialog();
                vistaPrevia.Document = documento;
                vistaPrevia.WindowState = FormWindowState.Maximized;
                vistaPrevia.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al imprimir: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cada vez que inicia una impresión se comienza desde la primera fila
        private void MtdIniciarImpresion(object sender, PrintEventArgs e)
        {
            _filaActual = 0;
        }

        // Dibuja una página con el título, los encabezados y las filas
        private void MtdImprimirPagina(object sender, PrintPageEventArgs e)
        {
            using (Font fuenteTitulo = new Font("Arial", 14, FontStyle.Bold))
            using (Font fuenteEncabezado = new Font("Arial", 8, FontStyle.Bold))
            using (Font fuenteDatos = new Font("Arial", 8))
            {
                int x = e.MarginBounds.Left;
                int y = e.MarginBounds.Top;
                int altoFila = 22;

                // Contar las columnas visibles para calcular el ancho de cada una
                int totalColumnas = 0;
                foreach (DataGridViewColumn columna in _dgvImprimir.Columns)
                {
                    if (columna.Visible)
                    {
                        totalColumnas++;
                    }
                }
                int anchoColumna = e.MarginBounds.Width / totalColumnas;

                // 1. Título y fecha de impresión
                e.Graphics.DrawString(_tituloImprimir, fuenteTitulo, Brushes.DarkBlue, x, y);
                y += 30;
                e.Graphics.DrawString("Fecha de impresión: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), fuenteDatos, Brushes.Black, x, y);
                y += 25;

                // 2. Encabezados de las columnas
                int posicionX = x;
                foreach (DataGridViewColumn columna in _dgvImprimir.Columns)
                {
                    if (!columna.Visible)
                    {
                        continue;
                    }

                    Rectangle celda = new Rectangle(posicionX, y, anchoColumna, altoFila);
                    e.Graphics.FillRectangle(Brushes.LightGray, celda);
                    e.Graphics.DrawRectangle(Pens.Black, celda);
                    e.Graphics.DrawString(columna.HeaderText, fuenteEncabezado, Brushes.Black, celda);
                    posicionX += anchoColumna;
                }
                y += altoFila;

                // 3. Filas de datos
                while (_filaActual < _dgvImprimir.Rows.Count)
                {
                    // Si ya no cabe otra fila se continúa en una nueva página
                    if (y + altoFila > e.MarginBounds.Bottom)
                    {
                        e.HasMorePages = true;
                        return;
                    }

                    DataGridViewRow fila = _dgvImprimir.Rows[_filaActual];
                    posicionX = x;

                    foreach (DataGridViewColumn columna in _dgvImprimir.Columns)
                    {
                        if (!columna.Visible)
                        {
                            continue;
                        }

                        object valor = fila.Cells[columna.Index].FormattedValue;
                        Rectangle celda = new Rectangle(posicionX, y, anchoColumna, altoFila);
                        e.Graphics.DrawRectangle(Pens.Black, celda);
                        e.Graphics.DrawString(valor == null ? "" : valor.ToString(), fuenteDatos, Brushes.Black, celda);
                        posicionX += anchoColumna;
                    }

                    y += altoFila;
                    _filaActual++;
                }

                // Ya no hay más filas para imprimir
                e.HasMorePages = false;
            }
        }
    }
}
