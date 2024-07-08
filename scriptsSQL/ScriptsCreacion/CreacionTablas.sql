/*
	DROP TABLE TipoIdentificacion;
	DROP TABLE TipoPersona;
	DROP TABLE Cliente;
	DROP TABLE TipoCuenta;
	DROP TABLE Cuenta;
	DROP TABLE Banco;
	DROP TABLE FormaPago;
	DROP TABLE TipoTransaccion;
	DROP TABLE Transaccion;
	DROP TABLE Rol;
	DROP TABLE Usuario;
*/

CREATE TABLE TipoIdentificacion(
	id INT IDENTITY,
	descripcion VARCHAR(250),
	abreviatura VARCHAR(3),
	fechaCreacion DATETIME,
	fechaEdicion DATETIME
	PRIMARY KEY (id)
);
ALTER TABLE TipoIdentificacion ADD CONSTRAINT [DF_TipoIdentificacion_fechaCreacion] DEFAULT GETDATE() FOR fechaCreacion;

INSERT INTO TipoIdentificacion(descripcion, abreviatura) SELECT 'Cedula de ciudadania', 'C.C';
INSERT INTO TipoIdentificacion(descripcion, abreviatura) SELECT 'Tarjeta de identidad', 'T.I';
INSERT INTO TipoIdentificacion(descripcion, abreviatura) SELECT 'Registro civil', 'R.C';

CREATE TABLE TipoPersona(
	id INT IDENTITY,
	descripcion VARCHAR(70),
	fechaCreacion DATETIME,
	fechaEdicion DATETIME
	PRIMARY KEY (id)
);
ALTER TABLE TipoPersona ADD CONSTRAINT [DF_TipoPersona_fechaCreacion] DEFAULT GETDATE() FOR fechaCreacion;
INSERT INTO TipoPersona(descripcion) SELECT 'Persona natural';
INSERT INTO TipoPersona(descripcion) SELECT 'Persona juridica';

CREATE TABLE Cliente(
	id INT IDENTITY,
	idTipoIdentificacion INT,
	idTipoPersona INT,
	nombres VARCHAR(250),
	apellidos VARCHAR(250),
	identificacion VARCHAR(10),
	telefono VARCHAR(250),
	fechaCreacion DATETIME,
	fechaEdicion DATETIME
	PRIMARY KEY (id)
);
ALTER TABLE Cliente ADD CONSTRAINT [DF_Cliente_fechaCreacion] DEFAULT GETDATE() FOR fechaCreacion;
ALTER TABLE Cliente ADD CONSTRAINT [FK_Cliente_TipoIdentificacion] FOREIGN KEY (idTipoIdentificacion) REFERENCES TipoIdentificacion(id);
ALTER TABLE Cliente ADD CONSTRAINT [FK_Cliente_TipoPersona] FOREIGN KEY (idTipoPersona) REFERENCES TipoPersona(id);

INSERT INTO Cliente(idTipoIdentificacion, idTipoPersona, nombres, apellidos, identificacion, telefono) 
	SELECT 1, 1, 'Nicolás', 'Jaiquel Rubio', '1019990889', '3016027717';

INSERT INTO Cliente(idTipoIdentificacion, idTipoPersona, nombres, apellidos, identificacion, telefono) 
	SELECT 1, 1, 'Jose Manuel', 'Delgado', '1019990982', '1122334455';

SELECT c.*, ti.descripcion as tipoIdentificacion, ti.abreviatura, tp.descripcion as tipoPersona FROM Cliente c WITH(NOLOCK)
INNER JOIN TipoIdentificacion ti WITH(NOLOCK) ON ti.id = c.idTipoIdentificacion
INNER JOIN TipoPersona tp WITH(NOLOCK) ON tp.id = c.idTipoPersona;

CREATE TABLE TipoCuenta(
	id INT IDENTITY,
	descripcion VARCHAR(50),
	fechaCreacion DATETIME,
	fechaEdicion DATETIME
	PRIMARY KEY (id)
);
ALTER TABLE TipoCuenta ADD CONSTRAINT [DF_TipoCuenta_fechaCreacion] DEFAULT GETDATE() FOR fechaCreacion;

INSERT INTO TipoCuenta(descripcion) SELECT 'Ahorros';
INSERT INTO TipoCuenta(descripcion) SELECT 'Corriente';

CREATE TABLE Cuenta(
	id INT IDENTITY,
	idCliente INT,
	idTipoCuenta INT,
	numeroCuenta INT,
	saldo NUMERIC(10,3),
	fechaCreacion DATETIME,
	fechaEdicion DATETIME
	PRIMARY KEY (id)
);
ALTER TABLE Cuenta ADD CONSTRAINT [DF_Cuenta_fechaCreacion] DEFAULT GETDATE() FOR fechaCreacion;
ALTER TABLE Cuenta ADD CONSTRAINT [FK_Cuenta_Cliente] FOREIGN KEY (idCliente) REFERENCES Cliente(id);
ALTER TABLE Cuenta ADD CONSTRAINT [FK_Cuenta_TipoCuenta] FOREIGN KEY (idTipoCuenta) REFERENCES TipoCuenta(id);
ALTER TABLE Cuenta ADD CONSTRAINT [UQ_Cuenta_numeroCuenta] UNIQUE (numeroCuenta, idCliente);

INSERT INTO Cuenta(idCliente, idTipoCuenta, numeroCuenta, saldo) SELECT 1, 1, 12345, 150000;
INSERT INTO Cuenta(idCliente, idTipoCuenta, numeroCuenta, saldo) SELECT 2, 2, 54321, 150000;
INSERT INTO Cuenta(idCliente, idTipoCuenta, numeroCuenta, saldo) SELECT 1, 2, 22334, 3000;

SELECT cu.*, cli.nombres + ' ' + cli.apellidos as nombreTitular, tc.descripcion as tipoCuenta FROM Cuenta cu
INNER JOIN Cliente cli ON cli.id = cu.idCliente
INNER JOIN TipoCuenta tc ON tc.id = cu.idTipoCuenta; 

CREATE TABLE Banco(
	id INT IDENTITY,
	nombre VARCHAR(100),
	fechaCreacion DATETIME,
	fechaEdicion DATETIME
	PRIMARY KEY (id)
);
ALTER TABLE Banco ADD CONSTRAINT [DF_Banco_fechaCreacion] DEFAULT GETDATE() for fechaCreacion;

INSERT INTO Banco(nombre) SELECT 'Bancolombia';
INSERT INTO Banco(nombre) SELECT 'Banco de Bogota';

CREATE TABLE FormaPago(
	id INT IDENTITY,
	descripcion VARCHAR(100),
	fechaCreacion DATETIME,
	fechaEdicion DATETIME,
	PRIMARY KEY (id)
);
ALTER TABLE FormaPago ADD CONSTRAINT [DF_FormaPago_fechaCreacion] DEFAULT GETDATE() for fechaCreacion;

INSERT INTO FormaPago(descripcion) SELECT 'Cheque';
INSERT INTO FormaPago(descripcion) SELECT 'Efectivo';
SELECT * FROM FormaPago;

CREATE TABLE TipoTransaccion(
	id INT IDENTITY,
	descripcion VARCHAR(100),
	fechaCreacion DATETIME,
	fechaEdicion DATETIME
	PRIMARY KEY (id)
);

ALTER TABLE TipoTransaccion ADD CONSTRAINT [DF_TipoTransaccion_fechaCreacion] DEFAULT GETDATE() for fechaCreacion;
INSERT INTO TipoTransaccion(descripcion) SELECT 'Apertura';
INSERT INTO TipoTransaccion(descripcion) SELECT 'Consignacion';
INSERT INTO TipoTransaccion(descripcion) SELECT 'Retiro';
SELECT * FROM TipoTransaccion;

CREATE TABLE Transaccion(
	id INT IDENTITY,
	idTipoTransaccion INT,
	idCuenta INT,
	idFormaPago INT,
	idBanco INT,
	numeroCheque VARCHAR(20),
	monto DECIMAL (10,3),
	fechaCreacion DATETIME,
	fechaEdicion DATETIME
	PRIMARY KEY (id)
);
ALTER TABLE Transaccion ADD CONSTRAINT [DF_Transaccion_fechaCreacion] DEFAULT GETDATE() FOR fechaCreacion;
ALTER TABLE Transaccion ADD CONSTRAINT [FK_Transaccion_Cuenta] FOREIGN KEY (idCuenta) REFERENCES Cuenta(id);
ALTER TABLE Transaccion ADD CONSTRAINT [FK_Transaccion_TipoTransaccion] FOREIGN KEY (idTipoTransaccion) REFERENCES TipoTransaccion(id);
ALTER TABLE Transaccion ADD CONSTRAINT [FK_Transaccion_FormaPago] FOREIGN KEY (idFormaPago) REFERENCES FormaPago(id);
ALTER TABLE Transaccion ADD CONSTRAINT [FK_Transaccion_Banco] FOREIGN KEY (idBanco) REFERENCES Banco(id);

INSERT INTO Transaccion(idTipoTransaccion, idCuenta, idFormaPago, monto) SELECT 2,1,2, 2300;

SELECT t.*, tt.descripcion as tipoTransaccion, c.numeroCuenta, cc.nombres + ' ' + cc.apellidos as nombresCliente,
 fp.descripcion as formaPago FROM Transaccion t WITH(NOLOCK)
INNER JOIN TipoTransaccion tt WITH(NOLOCK) ON tt.id = t.idTipoTransaccion
INNER JOIN Cuenta c WITH(NOLOCK) ON c.id = t.idCuenta
INNER JOIN Cliente cc WITH(NOLOCK) ON cc.id = c.idCliente
INNER JOIN FormaPago fp WITH(NOLOCK) ON fp.id = t.idFormaPago

CREATE TABLE Rol(
	id INT IDENTITY,
	descripcion VARCHAR(70),
	fechaCreacion DATETIME,
	fechaEdicion DATETIME
	PRIMARY KEY (id)
);
ALTER TABLE Rol ADD CONSTRAINT [DF_Rol_fechaCreacion] DEFAULT GETDATE() FOR fechaCreacion;

INSERT INTO Rol(descripcion) SELECT 'admin';
INSERT INTO Rol(descripcion) SELECT 'viewer';

CREATE TABLE Usuario(
	id INT IDENTITY,
	idRol INT,
	username VARCHAR(200),
	password VARCHAR(250),
	fechaCreacion DATETIME,
	fechaEdicion DATETIME
	PRIMARY KEY (id)
);
ALTER TABLE Usuario ADD CONSTRAINT [DF_Usuario_fechaCreacion] DEFAULT GETDATE() FOR fechaCreacion;
ALTER TABLE Usuario ADD CONSTRAINT [FK_Usuario_Rol] FOREIGN KEY (idRol) REFERENCES Rol(id);

INSERT INTO Usuario(username, password, idRol) SELECT 'nicxlasj', 'abc123', 1;
INSERT INTO Usuario(username, password, idRol) SELECT 'alex', '1207', 2;

SELECT u.*, r.descripcion as rol FROM Usuario u WITH(NOLOCK)
INNER JOIN Rol r WITH(NOLOCK) ON r.id = u.idRol;
