---
name: crear-pantalla
description: Crea pantallas del Sistema Optica (Ópticas Visión Guatemala, Grupo 8) en C# Windows Forms .NET Framework 4.8 con arquitectura por capas (Entidad, Datos, Negocio, Presentacion), siguiendo el patrón del proyecto de ejemplo Sistema Veterinaria. Las reglas están divididas en archivos de parametrización (00 contexto y colores, 01 base de datos, 02 diseño CRUD, 03 diseño dashboard, 04 Entidad, 05 Datos, 06 Negocio, 07 lógica del formulario, 08 verificación, 09 diseño del menú principal). Usar cuando el usuario pida crear o diseñar una pantalla, formulario o módulo y pase una tabla con sus campos, cuando nombre alguno de esos archivos .md, o cuando pida agregar la lógica (CRUD Consultar, Agregar, Editar, Eliminar, Buscar) o una capa a una pantalla.
---

# Crear pantallas – Sistema Optica (Grupo 8)

Esta guía está dividida en **archivos de parametrización**, uno por tema
(carpeta `ia/skills/crear-pantalla/`). El usuario arma su pedido nombrando los archivos
que quiere usar y pasando la tabla con sus campos.

**Ejemplos de pedidos:**

> "Créame la pantalla de Clientes con el diseño de `02_DISENO_CRUD.md`. Campos: CodigoCliente INT PK, Nombres VARCHAR(100)…"
>
> "A FrmReceta ponle la Entidad de `04_CAPA_ENTIDAD.md`, los métodos de `05_CAPA_DATOS.md` y `06_CAPA_NEGOCIO.md` y la lógica de `07_LOGICA_FORMULARIO.md`."
>
> "Hazme solo la capa Datos de Optometrista con `05_CAPA_DATOS.md`."
>
> "Agrega la pantalla de Clientes al menú como dice `09_DISENO_MENU_PRINCIPAL.md`."

## Archivos

| Archivo | Qué contiene | Cuándo se usa |
|---|---|---|
| `00_CONTEXTO_PROYECTO.md` | Rutas y estructura de carpetas, librerías, integrantes, pantallas hechas, **colores del sistema**, nombres/marcadores `{Tabla}`, estilo de código | **Siempre** (leer primero) |
| `01_BASE_DE_DATOS.md` | Las 12 tablas, FK, UNIQUE, valores de Estado, qué mostrar en los ComboBox, tipos SQL → C# | **Siempre** (para completar los campos) |
| `02_DISENO_CRUD.md` | Diseño de la pantalla de mantenimiento (pestañas Consultar/Gestionar): estructura, controles por tipo de campo, posiciones, columnas, botones, plantilla completa del Designer | Diseño de pantallas CRUD |
| `03_DISENO_DASHBOARD.md` | Diseño A: bienvenida (texto del logo translúcido, sin el ojo, + "Bienvenidos", el actual). Diseño B: filtros, tarjetas KPI y gráficas (guardado) | Diseño del Dashboard |
| `04_CAPA_ENTIDAD.md` | Clase Entidad: atributos, propiedades, constructores; propiedad para ComboBox | Capa Entidad |
| `05_CAPA_DATOS.md` | Métodos `MtdConsultar/Agregar/Editar/Eliminar/Buscar` con SQL, campos NULL, errores SQL, cambio a PostgreSQL | Capa Datos |
| `06_CAPA_NEGOCIO.md` | Métodos de Negocio y `MtdValidarDatos` con las reglas de validación | Capa Negocio |
| `07_LOGICA_FORMULARIO.md` | Eventos del Designer, métodos del formulario, leer/llenar controles, ComboBox de FK, exportar/imprimir | Lógica de la pantalla |
| `08_VERIFICACION.md` | Compilar, lista de revisión, errores del ejemplo que no se copian | **Siempre al terminar** |
| `09_DISENO_MENU_PRINCIPAL.md` | Ventana principal: menú lateral azul marino con logo, barra de título, panel contenedor; cómo agregar una pantalla al menú | Menú y conectar pantallas nuevas |

## Cómo armar el pedido

1. Leer siempre `00_CONTEXTO_PROYECTO.md` y `01_BASE_DE_DATOS.md`.
2. Leer **solo** los archivos que el usuario nombre y seguirlos al pie de la letra.
   Si el usuario cambia algo en su pedido (otro color, otro campo, otra posición), lo que
   pide el usuario manda sobre el archivo.
3. Si no nombra archivos, usar las combinaciones de abajo según lo que pida. Si no queda
   claro si quiere solo diseño o también lógica, preguntar: *"¿Solo diseño o también la lógica?"*
4. Terminar siempre con `08_VERIFICACION.md` (compilar), anotar el avance en `MEMORY.md`
   (raíz del proyecto) y decirle al usuario qué archivos se usaron y qué archivos del
   proyecto se crearon o cambiaron.
5. Si el usuario pide un diseño o patrón que **no existe** en ningún archivo (por ejemplo
   Login, Panel de Acceso, pantalla maestro-detalle de Órdenes), hacerlo con el mismo estilo
   y **guardarlo como un archivo nuevo** (`10_DISENO_LOGIN.md`, `11_DISENO_MAESTRO_DETALLE.md`…)
   con el mismo formato (encabezado "Úsalo para…", estructura, reglas y bloques de código),
   y agregarlo a la tabla de arriba para poder reutilizarlo después.
6. Si se mejora una pantalla y el cambio debe aplicar a las demás, actualizar también el
   archivo de parametrización que corresponde.

## Combinaciones frecuentes

| Pedido | Archivos |
|---|---|
| Pantalla CRUD, solo diseño | 00 + 01 + 02 + 09 (conectar al menú) + 08 |
| Pantalla CRUD completa (diseño + lógica) | 00 + 01 + 02 + 04 + 05 + 06 + 07 + 09 + 08 |
| Agregar lógica a una pantalla ya diseñada | 00 + 01 + 04 + 05 + 06 + 07 + 08 |
| Solo una capa (ej. "la capa Datos de Clientes") | 00 + 01 + el archivo de esa capa + 08 |
| Dashboard | 00 + 03 + 08 (Diseño B con datos: + 01 + 05 + 06 + 07) |
| Cambiar el menú principal | 00 + 09 + 08 |
