# 🧪 Prueba Técnica Full Stack - Quala

Este proyecto incluye:

- ✅ Backend en .NET 6 con Dapper, JWT, SQL Server
- ✅ Frontend en Angular 17 + Ng Zorro
- ✅ Base de datos con procedimientos almacenados
- ✅ Control de autenticación por JWT
- ✅ CRUD completo de sucursales

---

🔙 Ejecutar Backend (.NET)

Ir a la carpeta:

cd Quala.Api
---------------------------------------------------------

Modificar appsettings.json si lo necesitas:

"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=TestDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
-----------------------------------------------------------
Ejecutar:

dotnet run
----------------------------------------------------------

Swagger disponible en:

https://localhost:7007/swagger
---------------------------------------------------------

Scripts Utilazdos en al base de datos:

USE TestDB;
GO

-- Crear tabla JD_suc_sucursal
IF OBJECT_ID('JD_suc_sucursal', 'U') IS NULL
BEGIN
    CREATE TABLE JD_suc_sucursal (
        Codigo INT IDENTITY(1,1) PRIMARY KEY,
        Descripcion NVARCHAR(250) NOT NULL,
        Direccion NVARCHAR(250) NOT NULL,
        Identificacion NVARCHAR(50) NOT NULL,
        FechaCreacion DATE NOT NULL,
        MonedaId INT NOT NULL
    );
END;
GO


--USE [TestDB];
--GO

--SET ANSI_NULLS ON;
--GO
--SET QUOTED_IDENTIFIER ON;
--GO

----  SP: Insertar
--CREATE OR ALTER PROCEDURE JD_usp_InsertarSucursal
--    @Descripcion NVARCHAR(250),
--    @Direccion NVARCHAR(250),
--    @Identificacion NVARCHAR(50),
--    @FechaCreacion DATE,
--    @MonedaId INT
--AS
--BEGIN
--    INSERT INTO JD_suc_sucursal (Descripcion, Direccion, Identificacion, FechaCreacion, MonedaId)
--    VALUES (@Descripcion, @Direccion, @Identificacion, @FechaCreacion, @MonedaId);

--    SELECT SCOPE_IDENTITY() AS NuevoCodigo;
--END;
--GO



----  SP: Obtener todos
--CREATE OR ALTER PROCEDURE JD_usp_ObtenerSucursales
--AS
--BEGIN
--    SELECT * FROM JD_suc_sucursal;
--END;
--GO



----  SP: Obtener por ID
--CREATE OR ALTER PROCEDURE JD_usp_ObtenerSucursalPorId
--    @Codigo INT
--AS
--BEGIN
--    SELECT * FROM JD_suc_sucursal WHERE Codigo = @Codigo;
--END;
--GO



----  SP: Actualizar
--CREATE OR ALTER PROCEDURE JD_usp_ActualizarSucursal
--    @Codigo INT,
--    @Descripcion NVARCHAR(250),
--    @Direccion NVARCHAR(250),
--    @Identificacion NVARCHAR(50),
--    @FechaCreacion DATE,
--    @MonedaId INT
--AS
--BEGIN
--    UPDATE JD_suc_sucursal
--    SET
--        Descripcion = @Descripcion,
--        Direccion = @Direccion,
--        Identificacion = @Identificacion,
--        FechaCreacion = @FechaCreacion,
--        MonedaId = @MonedaId
--    WHERE Codigo = @Codigo;
--END;
--GO




----  SP: Eliminar
--CREATE OR ALTER PROCEDURE JD_usp_EliminarSucursal
--    @Codigo INT
--AS
--BEGIN
--    DELETE FROM JD_suc_sucursal WHERE Codigo = @Codigo;
--END;
--GO


--EXEC JD_usp_ObtenerSucursales;


/**************CREACION DE TABLA MONEDAS CON LISTA ****************/
--USE TestDB;
--GO

---- Crear la tabla
--IF OBJECT_ID('JD_mon_Moneda', 'U') IS NULL
--BEGIN
--    CREATE TABLE JD_mon_Moneda (
--        Id INT IDENTITY(1,1) PRIMARY KEY,
--        Descripcion NVARCHAR(50) NOT NULL
--    );
--END
--GO

---- Insertar datos base
--INSERT INTO JD_mon_Moneda (Descripcion) VALUES
--('COP'), -- Peso colombiano
--('USD'), -- Dólar estadounidense
--('EUR'), -- Euro
--('MXN'), -- Peso mexicano
--('BRL'); -- Real brasileño
--GO

---- Verificar los datos insertados
--USE TestDB SELECT * FROM JD_mon_Moneda;
--USE TestDB SELECT * FROM JD_suc_sucursal
--USE TestDB SELECT * FROM JD_mon_Moneda






