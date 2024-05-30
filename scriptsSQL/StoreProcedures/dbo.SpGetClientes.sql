/*
	Autor				:	Nicolás Jaiquel
	Descripcion			:	Selecciona los datos de la tabla Cliente
	Fecha				:	2024-05-22
*/
CREATE OR ALTER PROCEDURE SpGetClientes(
	@id INT = NULL
)
AS
BEGIN
	SELECT c.*, ti.descripcion as tipoIdentificacion, ti.abreviatura, tp.descripcion as tipoPersona FROM Cliente c WITH(NOLOCK)
	INNER JOIN TipoIdentificacion ti WITH(NOLOCK) ON ti.id = c.idTipoIdentificacion
	INNER JOIN TipoPersona tp WITH(NOLOCK) ON tp.id = c.idTipoPersona WHERE (@id IS NULL OR @id = c.id);
END