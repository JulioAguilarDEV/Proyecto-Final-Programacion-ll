# 08 · Verificación

> **Úsalo siempre al terminar** cualquier pantalla o capa.

## 1. Compilar

Compilar desde la terminal (Visual Studio 2026 Community):

```powershell
& "C:\Program Files\Microsoft Visual Studio\18\Community\MSBuild\Current\Bin\MSBuild.exe" "C:\Users\rephot\Desktop\Proyecto Final Julio\ProyectoFinal_SistemaOptica\src\Sistema Optica.slnx" /t:Build /p:Configuration=Debug /v:minimal /nologo
```

Lista de revisión:
- [ ] Se agregaron los archivos al `.csproj` correcto.
- [ ] Compila sin errores ni advertencias.
- [ ] Cada campo de la tabla tiene su label + control y su columna en el grid.
- [ ] `MaxLength` igual al tamaño del VARCHAR; FKs en ComboBox DropDownList.
- [ ] Ningún control se sale de `grpDatos` (máx. 7 filas por columna).
- [ ] Si se puede, abrir el formulario en el diseñador de Visual Studio o tomar una captura.
- [ ] (Con lógica) Probar con la base de datos: Consultar, Agregar, Editar, Eliminar y Buscar.
- [ ] Si se creó o cambió algo importante, anotarlo en `MEMORY.md` (raíz del proyecto).

En Visual Studio: el proyecto de inicio debe ser **Presentacion** (clic derecho →
"Establecer como proyecto de inicio"); si no, sale el error "No se puede iniciar
directamente un proyecto con un tipo de resultado de biblioteca de clase".

## 2. Errores del ejemplo Veterinaria que NO se copian

- Panel central agregado en otra posición del `Controls.Add` → el grid quedaba tapado por el panel inferior (aquí: Fill primero).
- Botones sin evento (Cancelar, Limpiar, Cerrar) y métodos `iconButton3_Click` vacíos → aquí todos tienen nombre y evento.
- `CellContentClick` (solo funciona clic sobre el texto) → aquí `CellClick`.
- `TimeOfDay` guardaba segundos y milisegundos → aquí `new TimeSpan(hora, minuto, 0)`.
- ComboBox editables → aquí `DropDownList`.
- Guardar con un registro seleccionado duplicaba el registro → aquí Guardar se deshabilita al seleccionar.
- Mensajes de error sin la causa → aquí `": " + ex.Message`.
- Nombres como `FrmCitass`, `dvgCitas`, `PanelCentralGestioar` → aquí nombres correctos.
