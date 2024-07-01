/*
	Autor				:	Nicolás Jaiquel
	Descripcion			:	Inserta o actualiza los datos de la tabla Cuenta
	Fecha				:	2024-05-23
	Ejemplo				:	SpSaveCuenta 1, 1, 2, 33211, 12031 SpGetCuentas 1
*/

CREATE OR ALTER PROCEDURE SpSaveCuenta(
	@id INT = 0,
	@idCliente INT,
	@idTipoCuenta INT,
	@numeroCuenta INT,
	@saldo NUMERIC(10,3)
)AS
BEGIN
	IF(@id = 0) 
	BEGIN
		INSERT INTO Cuenta(idCliente, idTipoCuenta, numeroCuenta, saldo) SELECT @idCliente, @idTipoCuenta, @numeroCuenta, @saldo;
	END
	ELSE
	BEGIN
		UPDATE Cuenta
		SET idTipoCuenta = @idTipoCuenta,
		saldo = @saldo,
		fechaEdicion = GETDATE()
		WHERE id = @id;
	END
END