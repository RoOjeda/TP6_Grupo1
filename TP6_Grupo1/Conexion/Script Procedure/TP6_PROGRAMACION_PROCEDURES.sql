use Neptuno;

GO

-- PROCEDURE PARA LISTAR TODOS LOS PRODUCTOS
CREATE PROCEDURE ProcedureTodosProducto
AS
BEGIN
     SELECT IdProducto, idProveedor, NombreProducto, CantidadPorUnidad, PrecioUnidad from Productos
END;
GO



-- PROCEDURE PARA ELIMINAR UN PRODUCTO
CREATE PROCEDURE ProcedureDeleteProducto
(
	@IDPRODUCTO INT
)
AS
BEGIN
	DELETE FROM Productos
	WHERE IdProducto = @IDPRODUCTO
END;
GO

-- PROCEDURE PARA MODIFICAR UN PRODUCTO
CREATE PROCEDURE ProcedureModificarProducto
(
    @IDPRODUCTO INT,
    @NombreProducto NVARCHAR(40),
    @CantidadPorUnidad NVARCHAR(20),
    @PrecioUnidad MONEY
)
AS
BEGIN
    UPDATE Productos
    SET
        NombreProducto = @NombreProducto,
        CantidadPorUnidad = @CantidadPorUnidad,
        PrecioUnidad = @PrecioUnidad
    WHERE
        IdProducto = @IDPRODUCTO;
END;
GO