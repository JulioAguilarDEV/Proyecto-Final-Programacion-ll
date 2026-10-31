# COMANDOS_RAPIDOS.md – Comandos del proyecto

**Regla:** en Windows se prefiere **CMD (`cmd.exe`)**; no usar PowerShell si CMD está disponible.
En VS Code: Terminal → New Terminal → flecha junto al **+** → **Command Prompt**.

## Carpeta del proyecto

```cmd
cd /d "C:\Users\rephot\Desktop\Proyecto Final Julio\ProyectoFinal_SistemaOptica"
dir
tree /f ia docs database
```

## Compilar la solución

```cmd
"C:\Program Files\Microsoft Visual Studio\18\Community\MSBuild\Current\Bin\MSBuild.exe" "src\Sistema Optica.slnx" /t:Build /p:Configuration=Debug /v:minimal /nologo
```

En Visual Studio el proyecto de inicio debe ser **Presentacion**.

## SQL Server en Docker

```cmd
docker ps
docker start sql_prog2a
```

Consulta de prueba (cambiar `<contraseña>` por la de su `App.config` local; no guardarla aquí):

```cmd
docker exec sql_prog2a /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P "<contraseña>" -C -d OpticaGrupo8 -Q "SELECT DB_NAME() AS BaseActual;"
```

## Respaldo

```cmd
docker exec sql_prog2a ls -la /var/opt/mssql/backups
docker cp sql_prog2a:/var/opt/mssql/backups/<archivo>.bak database\backups\
```

El script del respaldo es `database/01_Backup_Base_Datos.sql`.

## Git (solo cuando se pida)

```cmd
git status
git pull
```
