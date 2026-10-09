# 06 · Capa Negocio (métodos y validaciones)

> **Úsalo para crear la clase Negocio** de una tabla: valida los datos con las reglas del
> negocio y llama a la capa Datos. Mismos métodos: `MtdConsultar`, `MtdAgregar`,
> `MtdEditar`, `MtdEliminar`, `MtdBuscar` + `MtdValidarDatos` (privado).

## 1. Archivo y registro en el .csproj

- Archivo: `src/Negocio/{Tabla}Negocio.cs`
- Agregar en `src/Negocio/Negocio.csproj`: `<Compile Include="{Tabla}Negocio.cs" />`

## 2. Plantilla

```csharp
using Datos;
using Entidad;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class OptometristaNegocio
    {
        // =====================================================
        // POO: COMPOSICIÓN
        // La capa Negocio utiliza la capa Datos.
        // =====================================================

        private readonly OptometristaDatos _optometristaDatos = new OptometristaDatos();

        // =====================================================
        // CRUD: CONSULTAR
        // =====================================================

        public List<OptometristaEntidad> MtdConsultar()
        {
            return _optometristaDatos.MtdConsultar();
        }

        // =====================================================
        // CRUD: AGREGAR
        // =====================================================

        public bool MtdAgregar(OptometristaEntidad optometristaEntidad)
        {
            if (optometristaEntidad == null)
            {
                throw new Exception("Los datos del optometrista no pueden ser nulos.");
            }

            // Validar la información antes de enviarla a la base de datos
            MtdValidarDatos(optometristaEntidad);

            return _optometristaDatos.MtdAgregar(optometristaEntidad);
        }

        // =====================================================
        // POO: MÉTODOS DE VALIDACIÓN
        // Valida los datos ingresados según las reglas del negocio.
        // =====================================================

        private void MtdValidarDatos(OptometristaEntidad optometristaEntidad)
        {
            if (string.IsNullOrWhiteSpace(optometristaEntidad.Nombres))
            {
                throw new Exception("Debe ingresar los nombres del optometrista.");
            }

            if (string.IsNullOrWhiteSpace(optometristaEntidad.Apellidos))
            {
                throw new Exception("Debe ingresar los apellidos del optometrista.");
            }

            if (string.IsNullOrWhiteSpace(optometristaEntidad.NumeroColegiado))
            {
                throw new Exception("Debe ingresar el número de colegiado.");
            }

            if (string.IsNullOrWhiteSpace(optometristaEntidad.Telefono))
            {
                throw new Exception("Debe ingresar un número telefónico.");
            }

            string telefono = optometristaEntidad.Telefono.Trim();
            if (telefono.Length < 8 || telefono.Length > 15)
            {
                throw new Exception("El número telefónico debe tener entre 8 y 15 dígitos.");
            }

            foreach (char caracter in telefono)
            {
                if (!char.IsDigit(caracter))
                {
                    throw new Exception("El número telefónico solo debe contener números.");
                }
            }

            if (!optometristaEntidad.Correo.Contains("@") || !optometristaEntidad.Correo.Contains("."))
            {
                throw new Exception("Debe ingresar un correo electrónico válido.");
            }

            if (string.IsNullOrWhiteSpace(optometristaEntidad.Estado))
            {
                throw new Exception("Debe seleccionar el estado del optometrista.");
            }
        }

        // =====================================================
        // CRUD: EDITAR
        // =====================================================

        public bool MtdEditar(OptometristaEntidad optometristaEntidad)
        {
            if (optometristaEntidad == null)
            {
                throw new Exception("Los datos del optometrista no pueden ser nulos.");
            }

            if (optometristaEntidad.CodigoOptometrista <= 0)
            {
                throw new Exception("Debe seleccionar un optometrista válido.");
            }

            MtdValidarDatos(optometristaEntidad);

            return _optometristaDatos.MtdEditar(optometristaEntidad);
        }

        // =====================================================
        // CRUD: ELIMINAR
        // =====================================================

        public bool MtdEliminar(int codigoOptometrista)
        {
            // Validar la llave primaria
            if (codigoOptometrista <= 0)
            {
                throw new Exception("El código del optometrista no es válido.");
            }

            return _optometristaDatos.MtdEliminar(codigoOptometrista);
        }

        // =====================================================
        // CRUD: BUSCAR
        // =====================================================

        public OptometristaEntidad MtdBuscar(int codigoOptometrista)
        {
            // Validar que el código sea mayor que cero
            if (codigoOptometrista <= 0)
            {
                throw new Exception("El código del optometrista no es válido.");
            }

            return _optometristaDatos.MtdBuscar(codigoOptometrista);
        }
    }
}
```

**Reglas de validación sugeridas (MtdValidarDatos):**

| Campo | Regla |
|---|---|
| VARCHAR NOT NULL | `string.IsNullOrWhiteSpace` → "Debe ingresar …" |
| FK NOT NULL | `<= 0` → "Debe seleccionar el/la …" |
| Estado / listas | vacío → "Debe seleccionar el estado …" |
| Teléfono | 8 a 15 caracteres y solo dígitos |
| DPI | exactamente 13 dígitos |
| Correo | si trae texto: debe tener `@` y `.` (si es NOT NULL, también obligatorio) |
| FechaNacimiento | no puede ser mayor a hoy |
| Fecha de cita | no puede ser anterior a hoy (al agregar) |
| Fecha examen / emisión / entrega | no puede ser mayor a hoy |
| Precio, PrecioUnitario | mayor que 0 |
| Cantidad | mayor que 0 |
| Subtotal | se calcula en Negocio: `Cantidad * PrecioUnitario` |
| Eje (OD/OI) | 0 a 180 |
| Esfera | −30 a 30 · Cilindro −10 a 10 · Adición 0 a 4 |
| DistanciaPupilar | 40 a 80 |

Usar el género correcto en los mensajes: "el optometrista … agregado", "la receta … agregada".
