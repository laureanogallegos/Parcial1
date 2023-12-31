﻿USE MASTER
GO
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'PARCIAL1')
BEGIN

    DROP DATABASE PARCIAL1;  
END;
CREATE DATABASE PARCIAL1;
GO
USE PARCIAL1
GO
--------------------------MONODROGAS---------------------------------------------------------
CREATE TABLE MONODROGAS (ID INT NOT NULL PRIMARY KEY IDENTITY, NOMBRE NVARCHAR(50) NOT NULL UNIQUE)
GO
CREATE PROCEDURE SP_RECUPERARMONODROGAS
AS BEGIN
    SELECT NOMBRE FROM MONODROGAS
END
GO
INSERT INTO MONODROGAS VALUES ('Acido Acetil Salicilico')
INSERT INTO MONODROGAS VALUES ('Modafinilo')
INSERT INTO MONODROGAS VALUES ('Cetirizina')
INSERT INTO MONODROGAS VALUES ('Clonazepam')
INSERT INTO MONODROGAS VALUES ('Acido tioctico')
--------------------------------------------------------------------------------------------

-------------------------DROGUERIAS---------------------------------------------------------
CREATE TABLE DROGUERIAS (ID INT NOT NULL PRIMARY KEY IDENTITY, CUIT BIGINT  NOT NULL UNIQUE, RAZON_SOCIAL NVARCHAR(50) NOT NULL, DIRECCION NVARCHAR(150) NOT NULL, EMAIL NVARCHAR(254) NULL )
GO
CREATE PROCEDURE SP_RECUPERARDROGUERIAS
AS BEGIN
    SELECT CUIT, RAZON_SOCIAL,DIRECCION,EMAIL FROM DROGUERIAS
END
GO
INSERT INTO DROGUERIAS VALUES (20123456789,'Rosfar','Mendonza 1525',null)
INSERT INTO DROGUERIAS VALUES (30062587456,'Kellerhof','Santiago 951','info@kellerof.com.ar')
INSERT INTO DROGUERIAS VALUES (27262346388,'Drogueria Saladillo','Alvear 5598',null)
INSERT INTO DROGUERIAS VALUES (23246751067,'Drogueria del parque','Pte Roca 2035',null)
INSERT INTO DROGUERIAS VALUES (20282587419,'Drogueria Norte','Casiano Casas 1292','drogueria@droguerianorte.com.ar')
--------------------------------------------------------------------------------------------

------------------------MEDICAMENTOS---------------------------------------------------------
CREATE TABLE MEDICAMENTOS (ID INT NOT NULL PRIMARY KEY IDENTITY, NOMBRE_COMERCIAL NVARCHAR(50) NOT NULL UNIQUE, ES_VENTA_LIBRE BIT NOT NULL, PRECIO_VENTA DECIMAL NOT NULL, STOCK INT NOT NULL, STOCK_MINIMO INT NOT NULL, ID_MONODROGRA INT NOT NULL FOREIGN KEY REFERENCES MONODROGAS(ID))
GO

CREATE TABLE MEDICAMENTOS_DROGUERIAS (ID_MEDICAMENTO INT NOT NULL FOREIGN KEY REFERENCES MEDICAMENTOS(ID), ID_DROGUERIA INT NOT NULL FOREIGN KEY REFERENCES DROGUERIAS(ID), PRIMARY KEY(ID_MEDICAMENTO, ID_DROGUERIA))
GO

CREATE PROCEDURE SP_RECUPERARMEDICAMENTOS
AS BEGIN
    SELECT NOMBRE_COMERCIAL,ES_VENTA_LIBRE, PRECIO_VENTA,STOCK, STOCK_MINIMO, MONODROGAS.NOMBRE AS NOMBRE_MONODROGA FROM MEDICAMENTOS INNER JOIN MONODROGAS ON MEDICAMENTOS.ID_MONODROGRA = MONODROGAS.ID
END

GO
CREATE PROCEDURE SP_RECUPERARDROGUERIASMEDICAMENTOS @NOMBRE_COMERCIAL NVARCHAR(50)
AS BEGIN
    DECLARE @ID_MEDICAMENTO INT
    SET @ID_MEDICAMENTO = (SELECT ID FROM MEDICAMENTOS WHERE NOMBRE_COMERCIAL = @NOMBRE_COMERCIAL)
    SELECT * FROM MEDICAMENTOS_DROGUERIAS INNER JOIN DROGUERIAS ON MEDICAMENTOS_DROGUERIAS.ID_DROGUERIA = DROGUERIAS.ID WHERE ID_MEDICAMENTO = @ID_MEDICAMENTO
END

GO
CREATE PROCEDURE SP_AGREGARMEDICAMENTO  @NOMBRE_COMERCIAL NVARCHAR(50), @ES_VENTA_LIBRE BIT, @PRECIO_VENTA DECIMAL , @STOCK INT, @STOCK_MINIMO INT, @MONODROGA NVARCHAR(50)
AS BEGIN
    DECLARE @ID_MONODROGA INT
    SET @ID_MONODROGA = (SELECT ID FROM MONODROGAS WHERE NOMBRE = @MONODROGA)
    INSERT INTO MEDICAMENTOS VALUES(@NOMBRE_COMERCIAL,@ES_VENTA_LIBRE,@PRECIO_VENTA,@STOCK,@STOCK_MINIMO,@ID_MONODROGA)
END

GO
CREATE PROCEDURE SP_MODIFICARMEDICAMENTO  @NOMBRE_COMERCIAL NVARCHAR(50), @ES_VENTA_LIBRE BIT, @PRECIO_VENTA DECIMAL , @STOCK INT, @STOCK_MINIMO INT, @MONODROGA NVARCHAR(50)
AS BEGIN
    DECLARE @ID_MONODROGA INT
    SET @ID_MONODROGA = (SELECT ID FROM MONODROGAS WHERE NOMBRE = @MONODROGA)
    UPDATE MEDICAMENTOS SET ES_VENTA_LIBRE = @ES_VENTA_LIBRE, PRECIO_VENTA = @PRECIO_VENTA,STOCK = @STOCK, STOCK_MINIMO = @STOCK_MINIMO , ID_MONODROGRA = @ID_MONODROGA WHERE NOMBRE_COMERCIAL = @NOMBRE_COMERCIAL
    DECLARE @ID_MEDICAMENTO INT
    SET @ID_MEDICAMENTO = (SELECT ID FROM MEDICAMENTOS WHERE NOMBRE_COMERCIAL = @NOMBRE_COMERCIAL)
    DELETE FROM MEDICAMENTOS_DROGUERIAS WHERE ID_MEDICAMENTO = @ID_MEDICAMENTO 
END

GO
CREATE PROCEDURE SP_ELIMINARMEDICAMENTO @NOMBRE_COMERCIAL NVARCHAR(50)
AS BEGIN
    DECLARE @ID_MEDICAMENTO INT
    SET @ID_MEDICAMENTO = (SELECT ID FROM MEDICAMENTOS WHERE NOMBRE_COMERCIAL = @NOMBRE_COMERCIAL)
    DELETE FROM MEDICAMENTOS_DROGUERIAS WHERE ID_MEDICAMENTO = @ID_MEDICAMENTO 
    DELETE FROM MEDICAMENTOS WHERE ID = @ID_MEDICAMENTO
END


GO
CREATE PROCEDURE SP_AGREGAR_DROGUERIASMEDICAMENTO @NOMBRE_COMERCIAL NVARCHAR(50), @CUIT BIGINT
AS BEGIN
    DECLARE @ID_MEDICAMENTO INT
    SET @ID_MEDICAMENTO = (SELECT ID FROM MEDICAMENTOS WHERE NOMBRE_COMERCIAL = @NOMBRE_COMERCIAL)
    DECLARE @ID_DROGUERIA INT
    SET @ID_DROGUERIA= (SELECT ID FROM DROGUERIAS WHERE CUIT= @CUIT)
    INSERT INTO MEDICAMENTOS_DROGUERIAS VALUES (@ID_MEDICAMENTO,@ID_DROGUERIA)
END