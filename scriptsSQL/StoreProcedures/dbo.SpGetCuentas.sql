/*
	Autor				:	Nicol�s Jaiquel
	Descripcion			:	Selecciona los datos de la tabla Cuenta por id de cliente
	Fecha				:	2024-05-23
*/

CREATE OR ALTER PROCEDURE SpGetCuentas(
	@id INT
)AS
BEGIN
	SELECT c.*, cl.nombres + ' ' + cl.apellidos as nombresCliente, tc.descripcion as tipoCuentaDescripcion FROM Cuenta c WITH(NOLOCK)
	INNER JOIN Cliente cl WITH(NOLOCK) ON cl.id = c.idCliente
	INNER JOIN TipoCuenta tc WITH(NOLOCK) ON tc.id = c.idTipoCuenta
	WHERE cl.id = @id;
END