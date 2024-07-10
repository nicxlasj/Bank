/*
	Autor				:	Nicolás Jaiquel
	Descripcion			:	Guarda los datos de la tabla Cliente
	Fecha				:	2024-07-08
	Ejemplo				:	SpSaveClientes 3, 1, 1, 'Alexander', 'Pinzon', '1122009988', '3216540987'
*/
CREATE OR ALTER PROCEDURE SpSaveClientes(
	@id INT = 0,
	@idTipoIdentificacion INT,
	@idTipoPersona INT,
	@nombres VARCHAR(250),
	@apellidos VARCHAR(250),
	@identificacion VARCHAR(10),
	@telefono VARCHAR(250)
	
)AS
BEGIN
	IF(@id = 0)
	BEGIN
		INSERT INTO Cliente(idTipoIdentificacion, idTipoPersona, nombres, apellidos, identificacion, telefono)
			SELECT @idTipoIdentificacion, @idTipoPersona, @nombres, @apellidos, @identificacion, @telefono;
			SET @id = SCOPE_IDENTITY();
	END
	ELSE
	BEGIN
		UPDATE Cliente SET 
		idTipoIdentificacion = @idTipoIdentificacion, 
		idTipoPersona = @idTipoPersona, 
		nombres = @nombres, 
		apellidos = @apellidos, 
		identificacion = @identificacion,
		telefono = @telefono,
		fechaEdicion = GETDATE()
		WHERE id = @id
	END
	EXEC [dbo].[SpGetClientes] @id
END