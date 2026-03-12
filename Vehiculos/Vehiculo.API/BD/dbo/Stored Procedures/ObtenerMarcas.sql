CREATE PROCEDURE ObtenerMarcas
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		SELECT [Id]
      ,[Nombre]
  FROM [Vehiculos].[dbo].[Marcas]
END