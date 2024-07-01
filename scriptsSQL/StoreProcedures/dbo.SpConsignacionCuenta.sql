/*
	Autor			:	Nicolás Jaiquel Rubio
	Fecha			:	2024-05-30
	Descripción		:	Realiza la transaccion de consignacion sobre una cuenta	
*/
CREATE OR ALTER PROCEDURE SpConsignacionCuenta(
	@idCuenta INT,
	@idFormaPago INT,
	@numeroCheque VARCHAR(20) = NULL,
	@idTipoTransaccion INT,
	@idBanco INT = NULL,
	@monto DECIMAL (10,3)
)AS
BEGIN
	BEGIN TRAN
		BEGIN TRY
			INSERT INTO Transaccion(idTipoTransaccion, idCuenta, idFormaPago, numeroCheque, monto, idBanco) SELECT 
				@idTipoTransaccion, @idCuenta, @idFormaPago, @numeroCheque, @monto, @idBanco;
			DECLARE @id INT;
			SET @id = SCOPE_IDENTITY();
			IF(@idTipoTransaccion = 3)
			BEGIN
				UPDATE Cuenta SET saldo = saldo - @monto WHERE id = @idCuenta;	
			END

			ELSE
			BEGIN
				UPDATE Cuenta SET saldo = saldo + @monto WHERE id = @idCuenta;
			END
			EXEC SpGetTransaccion @id;
			COMMIT TRAN;
		END TRY
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(4000),
				@ErrorSeverity INT,
				@ErrorState INT;

		SELECT @ErrorMessage = ERROR_MESSAGE(),
			   @ErrorSeverity = ERROR_SEVERITY(),
			   @ErrorState = ERROR_STATE();

		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
		ROLLBACK TRAN;
	END CATCH
END