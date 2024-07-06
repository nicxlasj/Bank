/*
	Autor				:	Nicolás Jaiquel
	Descripcion			:	Selecciona los datos de la tabla Usuario
	Fecha				:	2024-07-05
	Ejemplo				:	SpGetUsuarios 'nicxlasj', 'abc123'
*/

CREATE OR ALTER PROCEDURE SpGetUsuarios(
	@username VARCHAR(200),
	@password VARCHAR(250)

)AS
BEGIN
	SELECT u.*, r.descripcion as rol FROM Usuario u WITH(NOLOCK)
	INNER JOIN Rol r WITH(NOLOCK) ON r.id = u.idRol
	WHERE u.username = @username AND u.password = @password;
END