/*
	Autor			:	Nicolás Jaiquel Rubio
	Fecha			:	2024-05-30
	Descripción		:	Realiza la transaccion de consignacion sobre una cuenta	
*/
CREATE OR ALTER PROCEDURE SpConsignacionCuenta(
	@idTipoTransaccion INT,
	@idCuenta INT,
	@idFormaPago INT,
	@numeroCheque VARCHAR(20) = NULL,
	@idBanco INT = NULL,
	@monto DECIMAL (10,3)
)AS
BEGIN
	BEGIN TRAN
		BEGIN TRY
			INSERT INTO Transaccion(idTipoTransaccion, idCuenta, idFormaPago, numeroCheque, monto, idBanco) SELECT 
				@idTipoTransaccion, @idCuenta, @idFormaPago, @numeroCheque, @monto, @idBanco;

			UPDATE Cuenta SET saldo = saldo + @monto WHERE id = @idCuenta;

			DECLARE @id INT;
			SET @id = SCOPE_IDENTITY();
			EXEC SpGetTransaccion @id;
		END TRY
	BEGIN CATCH
		ROLLBACK TRAN;
	END CATCH
END