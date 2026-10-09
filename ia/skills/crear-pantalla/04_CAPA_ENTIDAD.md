# 04 · Capa Entidad

> **Úsalo para crear la clase Entidad** de una tabla: atributos privados, propiedades,
> constructor vacío y los dos constructores sobrecargados (Consultar/Editar/Buscar y Agregar).

## 1. Archivo y registro en el .csproj

- Archivo: `src/Entidad/{Tabla}Entidad.cs`
- Agregar en `src/Entidad/Entidad.csproj`: `<Compile Include="{Tabla}Entidad.cs" />`
- Tipos de cada campo: ver `01_BASE_DE_DATOS.md` (Tipos SQL → C#).

## 2. Plantilla

Repetir cada bloque por campo, en el orden de la tabla.

```csharp
using System;

namespace Entidad
{
    public class OptometristaEntidad
    {
        // =====================================================
        // POO: ENCAPSULAMIENTO
        // Los atributos se mantienen privados.
        // =====================================================

        private int _codigoOptometrista;
        private string _nombres;
        private string _apellidos;
        private string _numeroColegiado;
        private string _telefono;
        private string _correo;
        private string _estado;

        // =====================================================
        // POO: PROPIEDADES
        // Permiten acceder de forma controlada a los atributos.
        // =====================================================

        public int CodigoOptometrista
        {
            get { return _codigoOptometrista; }
            set { _codigoOptometrista = value; }
        }
        public string Nombres
        {
            get { return _nombres; }
            set { _nombres = value; }
        }
        // ... una propiedad por cada campo ...
        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        // =====================================================
        // POO: CONSTRUCTOR VACÍO
        // Inicializa un objeto sin recibir parámetros.
        // =====================================================

        public OptometristaEntidad()
        {
            _codigoOptometrista = 0;
            _nombres = string.Empty;
            _apellidos = string.Empty;
            _numeroColegiado = string.Empty;
            _telefono = string.Empty;
            _correo = string.Empty;
            _estado = string.Empty;
        }

        // =====================================================
        // POO: SOBRECARGA DE CONSTRUCTORES
        // Constructor utilizado para Consultar, Editar y Buscar.
        // =====================================================

        public OptometristaEntidad(
            int codigoOptometrista,
            string nombres,
            string apellidos,
            string numeroColegiado,
            string telefono,
            string correo,
            string estado)
        {
            _codigoOptometrista = codigoOptometrista;
            _nombres = nombres;
            _apellidos = apellidos;
            _numeroColegiado = numeroColegiado;
            _telefono = telefono;
            _correo = correo;
            _estado = estado;
        }

        // =====================================================
        // POO: SOBRECARGA DE CONSTRUCTORES
        // Constructor utilizado para Agregar.
        // No recibe el código porque es IDENTITY en la BDD.
        // =====================================================

        public OptometristaEntidad(
            string nombres,
            string apellidos,
            string numeroColegiado,
            string telefono,
            string correo,
            string estado)
        {
            _codigoOptometrista = 0;
            _nombres = nombres;
            _apellidos = apellidos;
            _numeroColegiado = numeroColegiado;
            _telefono = telefono;
            _correo = correo;
            _estado = estado;
        }
    }
}
```

## 3. Propiedad de solo lectura para ComboBox

Si la tabla relacionada no tiene una columna "Nombre", agregar en **su Entidad** una
propiedad de solo lectura con `[Browsable(false)]` (así no aparece en ningún DataGridView;
requiere `using System.ComponentModel;`):

```csharp
        // =====================================================
        // PROPIEDAD DE SOLO LECTURA
        // Se usa para mostrar el texto en los ComboBox.
        // [Browsable(false)] evita que aparezca en el DataGridView.
        // =====================================================

        [Browsable(false)]
        public string NombreCompleto
        {
            get { return _nombres + " " + _apellidos; }
        }

        [Browsable(false)]
        public string Descripcion
        {
            get { return "Examen #" + _codigoExamen + " - " + _fecha.ToString("dd/MM/yyyy"); }
        }
```
