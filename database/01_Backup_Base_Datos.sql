-- =====================================================
-- RESPALDO DE LA BASE DE DATOS OpticaGrupo8
-- Estado: preparado, SIN EJECUTAR.
-- Antes de ejecutarlo comprobar la ruta dentro del contenedor:
--   docker exec sql_prog2a ls -la /var/opt/mssql/backups
-- =====================================================

USE master;
GO

-- =====================================================
-- RESPALDO COMPLETO
-- =====================================================

BACKUP DATABASE [OpticaGrupo8]
TO DISK = N'/var/opt/mssql/backups/OpticaGrupo8_20261017_01.bak'
WITH INIT, NAME = N'OpticaGrupo8 - Respaldo completo';
GO

-- =====================================================
-- VERIFICAR QUE EL RESPALDO SE PUEDE LEER
-- =====================================================

RESTORE VERIFYONLY
FROM DISK = N'/var/opt/mssql/backups/OpticaGrupo8_20261017_01.bak';
GO

-- =====================================================
-- COPIAR EL RESPALDO FUERA DEL CONTENEDOR
-- (en CMD, desde la carpeta del proyecto)
--   docker cp sql_prog2a:/var/opt/mssql/backups/OpticaGrupo8_20261017_01.bak database\backups\
-- =====================================================
