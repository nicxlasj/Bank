/*
	Autor			:	Nicolás Jaiquel Rubio
	Fecha			:	2024-05-30
	Descripción		:	Consulta las transacciones por id o en su defecto, todas.	
*/
CREATE OR ALTER PROCEDURE SpGetTransaccion(
	@id INT = NULL
)AS
BEGIN
	SELECT t.*, tt.descripcion as tipoTransaccion, c.numeroCuenta, cc.nombres + ' ' + cc.apellidos as nombresCliente,
	fp.descripcion as formaPago FROM Transaccion t WITH(NOLOCK)
	INNER JOIN TipoTransaccion tt WITH(NOLOCK) ON tt.id = t.idTipoTransaccion
	INNER JOIN Cuenta c WITH(NOLOCK) ON c.id = t.idCuenta
	INNER JOIN Cliente cc WITH(NOLOCK) ON cc.id = c.idCliente
	INNER JOIN FormaPago fp WITH(NOLOCK) ON fp.id = t.idFormaPago
	WHERE (@id IS NULL OR @id = c.id);
END