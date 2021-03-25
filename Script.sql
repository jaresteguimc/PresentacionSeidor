CREATE DATABASE[BDARESTEGUI]
GO
--TABLAS
CREATE TABLE [dbo].[cliente](
	IdCliente int identity (1,1),
	DNI INT primary key,
	Nombres VARCHAR(250),
	FechaNacimiento DATETIME,
	SaldoDisponible MONEY,
	PuntosAcumulados INT,
	Estado int
)
GO
create table Bonos
(
	IdBono int identity(1,1),
	DNI INT,
	CONSTRAINT fk_Clientes FOREIGN KEY (DNI) REFERENCES [cliente] (DNI),
	Bono MONEY,
	Estado int
)
GO
--SP
CREATE PROCEDURE [dbo].[SP_Cliente] (@pOpcion INT, @pParametro VARCHAR(MAX)) AS BEGIN
SET NOCOUNT ON;

DECLARE @IdCliente int;

DECLARE @DNI INT;

DECLARE @Nombres VARCHAR(250);

DECLARE @FechaNacimiento DATETIME;

DECLARE @SaldoDisponible MONEY;

DECLARE @PuntosAcumulados INT;

DECLARE @Estado int;

DECLARE @Bono MONEY;

DECLARE @BonoActual MONEY;

DECLARE @PuntoActual INT;

DECLARE @indicador int = 0;

DECLARE @tParametro TABLE (id INT,valor VARCHAR(MAX));

BEGIN IF(LEN(LTRIM(RTRIM(@pParametro))) > 0) BEGIN
INSERT INTO @tParametro (id, valor)
SELECT ids,
       DATA
FROM [dbo].[StringListjs_v2](@pParametro, '|');

END;

END;

IF(@pOpcion = 0) BEGIN
SELECT IdCliente,
       DNI,
       Nombres,
       convert(varchar,FechaNacimiento, 103) AS FechaNacimiento,
       SaldoDisponible,
       PuntosAcumulados,
       Estado
FROM [dbo].[cliente] END;

ELSE IF(@pOpcion = 1) BEGIN BEGIN TRY DECLARE @añoActual int;

DECLARE @anioNacimiento int;

DECLARE @edad int;


SET @DNI =
  (SELECT valor
   FROM @tParametro
   WHERE id = 1);


SET @Nombres =
  (SELECT valor
   FROM @tParametro
   WHERE id = 2);


SET @FechaNacimiento =
  (SELECT valor
   FROM @tParametro
   WHERE id = 3);


SET @añoactual = year(getdate());


SET @anioNacimiento = year(@FechaNacimiento);


SET @edad =@añoActual-@anioNacimiento;

IF(@edad <=40) BEGIN
SET @PuntosAcumulados = 1000;

END ELSE IF(@edad > 40) BEGIN
SET @PuntosAcumulados = 100;

END;

;

INSERT INTO [dbo].[cliente](DNI, Nombres, FechaNacimiento, SaldoDisponible, PuntosAcumulados, Estado)
VALUES(@DNI,@Nombres,@FechaNacimiento,0,@PuntosAcumulados,1);


SET @indicador =
  (SELECT scope_identity());

IF(@indicador <> 0) BEGIN
SELECT 'ok' AS mensaje;

END;

END TRY BEGIN CATCH
SELECT 'error' AS mensaje;

END CATCH END;

ELSE IF(@pOpcion = 2) BEGIN BEGIN TRY
SET @DNI =
  (SELECT valor
   FROM @tParametro
   WHERE id = 1);


SET @Bono =
  (SELECT valor
   FROM @tParametro
   WHERE id = 2);

IF(@Bono >=1000) BEGIN
SET @PuntosAcumulados = 200;

END ELSE IF(@Bono<1000) BEGIN
SET @PuntosAcumulados = 50;

END;


SET @BonoActual =
  (SELECT top 1[SaldoDisponible]
   FROM[dbo].[cliente]
   WHERE DNI=@DNI);


SET @PuntoActual =
  (SELECT top 1 [PuntosAcumulados]
   FROM[dbo].[cliente]
   WHERE DNI=@DNI);


SET @BonoActual = @BonoActual + @Bono;


SET @PuntoActual = @PuntoActual + @PuntosAcumulados;


INSERT INTO [dbo].[Bonos](DNI, Bono, Estado)
VALUES(@DNI,@Bono,1);


UPDATE [dbo].[cliente]
SET [SaldoDisponible] =@BonoActual,
    [PuntosAcumulados]=@PuntoActual
WHERE DNI=@DNI;


SET @indicador =
  (SELECT scope_identity());

IF(@indicador <> 0) BEGIN
SELECT 'ok' AS mensaje;

END;

END TRY BEGIN CATCH
SELECT 'error' AS mensaje;

END CATCH END;

END;
GO
--FUNCION
CREATE FUNCTION [dbo].[StringListjs_v2](@StringList varchar(max),@delimitador varchar(40))
RETURNS @Results TABLE (ids int identity(1,1),data varchar(800))
AS
BEGIN


			 
			--declare a variable and populate it with a comma separated string
			DECLARE @SQLString VARCHAR(MAX)
			SET @SQLString = @StringList;

			--append a comma to the string to get correct results with empty strings or strings with a single value (no commas)
			SET @SQLString = @SQLString + @delimitador;--'|';


			--the main query
			--Itzik Ban-Gan style CTE to generate us a lot of numbers (this will produce up to 65536)
			WITH Nbrs_3(n) AS (SELECT 1 UNION SELECT 0),
				Nbrs_2(n) AS (SELECT 1 FROM Nbrs_3 n1 CROSS JOIN Nbrs_3 n2),
				Nbrs_1(n) AS (SELECT 1 FROM Nbrs_2 n1 CROSS JOIN Nbrs_2 n2),
				Nbrs_0(n) AS (SELECT 1 FROM Nbrs_1 n1 CROSS JOIN Nbrs_1 n2),
				Nbrs  (n) AS (SELECT 1 FROM Nbrs_0 n1 CROSS JOIN Nbrs_0 n2)
			--chop up the string based on the position of the comma returned from the inner query

			insert into @Results(data)
			SELECT SUBSTRING(@SQLString, n+1, CHARINDEX(@delimitador, @SQLString, n+1) - n-1)--SELECT SUBSTRING(@SQLString, n+1, CHARINDEX('|', @SQLString, n+1) - n-1)			
			FROM
			(
				--select a holding record to ensure we get the very first value in the string
				SELECT 0 AS 'n' 
				UNION ALL 
				--select the maximum amount of generated numbers that we will need.
				--this will be the len of the string -1. the last char of string is a comma
				SELECT TOP(LEN(@SQLString)-1) ROW_NUMBER() OVER (ORDER BY n) AS 'n'
				FROM Nbrs
			) x
			--only return the numbers that equate to the position of a comma in the original string
			--returning 0 ensures that we get the first value in the string.
			--WHERE SUBSTRING(@SQLString, n, 1) = '|' OR n = 0
			WHERE SUBSTRING(@SQLString, n, 1) = @delimitador OR n = 0
			
	--------
	--------
    -- Insert statements for procedure here
    

RETURN
END
