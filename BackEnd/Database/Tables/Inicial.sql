CREATE DATABASE APME

CREATE TABLE TipoDocumento(
	idTipoDocumento SMALLINT NOT NULL PRIMARY KEY IDENTITY(1,1)
	,codigo SMALLINT NOT NULL
	,descripcion NVARCHAR(20) NOT NULL
	,estado BIT NOT NULL
)

INSERT INTO dbo.TipoDocumento(codigo, descripcion, estado) 
VALUES(1, 'RUC', 1), (2, 'Cédula', 1), (3, 'Pasaporte', 1)



CREATE TABLE Pais(
	idPais INT NOT NULL PRIMARY KEY IDENTITY(1,1)
	,codigo INT NOT NULL
	,codigoPais NVARCHAR(5) NULL
	,descripcion NVARCHAR(100) NOT NULL
	,nacionalidad NVARCHAR(100) NOT NULL
	,estado BIT NOT NULL DEFAULT 1
)

INSERT INTO dbo.Pais(codigo, codigoPais, descripcion, nacionalidad)
VALUES(1, '+593', 'Ecuador', 'Ecuatoriana')


CREATE TABLE Provincia(
	idProvincia INT NOT NULL PRIMARY KEY IDENTITY(1,1)
	,idPais INT NOT NULL CONSTRAINT FK_Provincia_Pais FOREIGN KEY(idPais) REFERENCES Pais(idPais)
	,descripcion NVARCHAR(150) NOT NULL
	,estado BIT NULL DEFAULT 1
)



CREATE TABLE Canton(
	idCanton INT NOT NULL PRIMARY KEY IDENTITY(1,1)
	,idProvincia INT NOT NULL CONSTRAINT FK_Canton_Provincia FOREIGN KEY(idProvincia) REFERENCES Provincia(idProvincia)
	,descripcion NVARCHAR(150) NOT NULL
	,estado BIT NULL DEFAULT 1
)

CREATE TABLE Parroquia(
	idParroquia INT NOT NULL PRIMARY KEY IDENTITY(1,1)
	,idCanton INT NOT NULL CONSTRAINT FK_Parroquia_Canton FOREIGN KEY(idCanton) REFERENCES Canton(idCanton)
	,descripcion NVARCHAR(150) NOT NULL
	,estado BIT NULL DEFAULT 1
)



CREATE TABLE Persona(
	idPersona INT NOT NULL PRIMARY KEY IDENTITY(1,1)
	,idTipoDocumento SMALLINT NOT NULL CONSTRAINT FK_Usuario_TipoDocumento FOREIGN KEY(idTipoDocumento) REFERENCES TipoDocumento(idTipoDocumento)
	,nroDocumento NVARCHAR(15) NOT NULL
	,primerNombre NVARCHAR(20) NOT NULL
	,segundoNombre NVARCHAR(20) NULL
	,primerApellido NVARCHAR(20) NOT NULL
	,segundoApellido NVARCHAR(20) NULL
	,nombreCompleto NVARCHAR(80) NOT NULL
	,fechaNacimiento DATETIME NULL
	,email NVARCHAR(80) NULL
	,telefono NVARCHAR(50) NULL
	,idPais INT NULL CONSTRAINT FK_Persona_Pais FOREIGN KEY(idPais) REFERENCES Pais(idPais)
	,idProvincia INT NULL CONSTRAINT FK_Persona_Provincia FOREIGN KEY(idProvincia) REFERENCES Provincia(idProvincia)
	,idParroquia INT NULL CONSTRAINT FK_Persona_Parroquia FOREIGN KEY(idParroquia) REFERENCES Parroquia(idParroquia)
	,direccion NVARCHAR(250) NULL
	,fechaRegistro DATETIME NOT NULL
	,estado BIT NOT NULL
)

CREATE TABLE Usuario(
	idUsuario INT NOT NULL PRIMARY KEY IDENTITY(1,1)
	,idPersona INT NOT NULL CONSTRAINT FK_Usuario_Persona FOREIGN KEY(idPersona) REFERENCES Persona(idPersona)
	,usuario NVARCHAR(40) NOT NULL
	,contrasenia BINARY(64) NOT NULL
	,imagen NVARCHAR(MAX) NULL
	,fechaRegistro DATETIME NOT NULL
	,estado BIT NOT NULL DEFAULT 1
)

CREATE TABLE Politica(
	idPolitica INT NOT NULL PRIMARY KEY IDENTITY(1,1)
	,codigo INT NOT NULL
	,descripcion NVARCHAR(30) NOT NULL
	,estado BIT NOT NULL
)

CREATE TABLE Entidad(
	identidad INT NOT NULL PRIMARY KEY IDENTITY(1,1)
	,razonSocial NVARCHAR(50) NOT NULL
	,nombrecomercial NVARCHAR(50) NOT NULL
	,ruc NVARCHAR(20) NOT NULL
	,abreviatura NVARCHAR(10) NOT NULL
	,direccion NVARCHAR(80) NULL
	,correo NVARCHAR(70) NULL
	,passCorreo NVARCHAR(70) NULL
	,telefono NVARCHAR(50) NULL	
	,estado BIT DEFAULT 1 NOT NULL
)

CREATE TABLE Sucursal(
	idsucursal iNT NOT NULL PRIMARY KEY IDENTITY(1,1)
	,idEntidad INT NOT NULL CONSTRAINT FK_Sucursal_Entidad FOREIGN KEY (idEntidad) REFERENCES Entidad(idEntidad)
	,razonSocial NVARCHAR(50) NOT NULL
	,nombrecomercial NVARCHAR(50) NOT NULl		
	,direccion NVARCHAR(80) NULL
	,correo NVARCHAR(70) NULL
	,passCorreo NVARCHAR(70) NULL
	,telefono NVARCHAR(50) NULL
	,estado BIT DEFAULT 1 NOT NULL
)


CREATE TABLE EntidadLogo(
	idEntidadLogo iNT NOT NULL PRIMARY KEY IDENTITY(1,1)
	,idEntidad INT NOT NULL  CONSTRAINT FK_EntidadLogo_Entidad FOREIGN KEY (idEntidad) REFERENCES Entidad(idEntidad)
	,gestion INT NOT NULL
	,imagen NVARCHAR(MAX) NOT NULL
	,fechaRegsitro DATETIME NOT NULL	
	,estado BIT DEFAULT 1
)


CREATE TABLE Rol(
	idRol INT NOT NULL PRIMARY KEY IDENTITY(1,1)
	,idUsuario INT NOT NULL CONSTRAINT FK_Rol_Usuario FOREIGN KEY (idUsuario) REFERENCES Usuario(idUsuario)
	,idPolitica INT NOT NULL CONSTRAINT FK_Rol_Politica FOREIGN KEY (idPolitica) REFERENCES Politica(idPolitica)
	,idSucursal INT NOT NULL CONSTRaINT FK_Rol_idsucursal FOREIGN KEY (idsucursal) REFERENCES Sucursal(idsucursal)
	,fechaRegistro DATETIME NOT NULL 
	,estado BIT DEFAULT 1 NOT NULL 
)


CREATE TABLE Categoria (
	idCategoria INT NOT NULL PRIMARY KEY  IDENTITY(1,1) 
	,codigo INT NOT NULL 
	,descripcion NVARCHAR(50) NOT NULL
	,estado BIT DEFAULT 1 NOT NULL
)

CREATE TABLE OrdenConfiguracion(
	idOrdenConfiguracion iNT NOT NULL PRIMARY KEY IDENTITY(1,1)
	,codigo INT NOT NULL
	,descripcion NVARCHAR(50) NOT NULL
	,rango INT NOT NULL
	,estado BIT DEFAULT 1 NOT NULL

);

CREATE TABLE Equipo(
	idEquipo INT NOT NULL PRIMARY KEY IDENTITY(1,1)
	,idCategoria INT NOT NULL CONSTRAINT FK_EquipoIngreso_Categoria FOREIGN KEY (idCategoria) REFERENCES Categoria(idCategoria)
	,descripcion NVARCHAR(100) NOT NULL
	,estado BIT DEFAULT 1 NOT NULL

)

CREATE TABLE EquipoIngreso(
	idEquipoIngreso INT NOT NULL PRIMARY KEY IDENTITY(1,1)	
	,idPersona INT NOT NULL CONSTRAINT FK_EquipoIngreso_Persona FOREIGN KEY (idPersona) REFERENCES Persona(idPersona)
	,idUsuario INT NOT NULL CONSTRAINT FK_EquipoIngreso_Usuario FOREIGN KEY (idUsuario) REFERENCES Usuario(idusuario)
	,idOrdenConfiguracion INT NOT NULL CONSTRAINT FK_EquipoIngreso_OrdenConfiguracion FOREIGN KEY (idOrdenConfiguracion) REFERENCES OrdenConfiguracion(idOrdenConfiguracion)
	,idEquipo iNT NOT NULL CONSTRAINT FK_EquipoIngreso_Equipo FOREIGN  KEY (idEquipo) REFERENCES Equipo(idEquipo)
	,serie NVARCHAR(100) NOT NULL
	,observacion NVARCHAR(100) NULL
	,detalle nVARCHAR(200) NULL
	,valor MONEY NULL
	,fechaIngreso DATETIME NOT NULL
	,fechaEgreso DATETIME NULL
	,fechaRegistro DATETIME NOT NULL
);


CREATE TABLE EquipoIngresoComponente(
	idEquipoIngresoComponente INT NOT NULL PRIMARY KEY IDENTITY(1,1)
	,idEquipoIngreso INT NOT NULL CONSTRAINT FK_EquipoIngresoComponente_EquipoIngreso FOREIGN KEY (idEquipoIngreso) REFERENCES EquipoIngreso(idEquipoIngreso)
	,cantidad INT NOT NULL
	,nombre NVARCHAR(100) NOT NULL
	,modelo NVARCHAR(40) NULL
	,nroSerie NVARCHAR(50) NULL
	,valor MONEY NULL 
	,idUsuario INT NOT NULL CONSTRAINT FK_EquipoIngresoComponente_Usuario FOREIGN KEY (idUsuario) REFERENCES Usuario(idusuario)
	,fechaRegistro DATETIME NOT NULL
	,estado BIT DEFAULT 1 NOT NULL
)

