# Sistema Optica – Ópticas Visión Guatemala, S. A.

Proyecto Final del curso **Programación II** – Universidad Mariano Gálvez de Guatemala,
Centro Universitario Cuilapa, Santa Rosa. Catedrático: M.A. Ing. Elvis Morales.

Sistema de escritorio para una cadena de ópticas con varias sucursales: administra
sucursales, usuarios, clientes, citas, optometristas, exámenes visuales, recetas, productos
ópticos, órdenes y entregas.

## Grupo 8

| Integrante | Carné | Módulos | Componente |
|---|---|---|---|
| Diego José Velásquez González | 1590-24-9994 | Usuarios · Clientes · Citas | Login |
| Luis Alfredo Ruano Dealtán | 1590-22-5860 | Tipos de Producto · Productos Ópticos · Órdenes | Panel de Acceso |
| Julio César Aguilar Tije | 1590-24-20986 | Optometristas · Exámenes Visuales · Recetas | Dashboard |

Sucursales: docente + grupo.

## Tecnologías

- C# .NET Framework 4.8 · Windows Forms · arquitectura por capas (Entidad → Datos → Negocio → Presentación)
- SQL Server (scripts también para PostgreSQL)
- FontAwesome.Sharp (íconos), System.Data.SqlClient
- Visual Studio · Git / GitHub · Agente de IA (`AGENTS.md`, `MEMORY.md`, `ia/skills/`)

## Estructura

```
ProyectoFinal_SistemaOptica\
├── database\
│   ├── scripts\    Creación de la base de datos
│   ├── data\       Datos de prueba
│   └── backups\    Respaldos
├── docs\
│   ├── diagrams\   Diagrama conceptual y entidad-relación
│   └── guides\     Enunciado y guías
├── ia\
│   └── skills\     Skills del agente de IA (crear-pantalla)
├── src\            Solución de Visual Studio
├── AGENTS.md       Reglas para el agente de IA
├── MEMORY.md       Memoria del proyecto
├── .gitignore
└── README.md
```

## Cómo ejecutarlo

1. **Base de datos (SQL Server):** ejecutar en SSMS, en este orden:
   1. `database/scripts/1_Script_Creacion_BD_SQLServer.sql`
   2. `database/data/2_Script_Datos_Prueba_SQLServer.sql`
   - En una base existente, ejecutar `database/scripts/2_Script_Roles_SQLServer.sql`
     para crear el catálogo de roles y sus accesos iniciales.
2. **Conexión:** revisar la cadena `ConexionSQLServer` en `src/Presentacion/App.config`
   (servidor, usuario y contraseña).
3. **Visual Studio:** abrir `src/Sistema Optica.slnx`, clic derecho en el proyecto
   **Presentacion** → *Establecer como proyecto de inicio*, y presionar **F5**.
   Los paquetes NuGet se restauran solos al compilar.

Al iniciar la aplicación se solicita usuario y contraseña. Los accesos iniciales de
Administrador, Operador y Optometrista se pueden ajustar desde **Roles y Accesos**,
disponible únicamente para Administrador.
