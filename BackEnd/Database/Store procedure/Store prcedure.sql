IF OBJECT_ID('uspPersonaInsertar') IS NOT NULL
BEGIN
	DROP PROC uspPersonaInsertar
END
GO 
CREATE PROC uspPersonaInsertar
@idTipoDocumento SMALLINT
,@nroDocumento NVARCHAR(12)
,@primerNombre NVARCHAR(20)
,@segundoNombre NVARCHAR(20)
,@primerApellido NVARCHAR(20)
,@segundoApellido NVARCHAR(20)
,@fechaNacimiento DATETIME
,@email NVARCHAR(80)
,@telefono NVARCHAR(12)
,@idPais INT
,@idProvincia INT
,@idParroquia INT
,@direccion NVARCHAR(150)
AS 
BEGIN 
SET NOCOUNT ON;
SET LANGUAGE SPANISH;
DECLARE @idPersona INT, @idUsuario INT

-- Nota: Necesitamos enviar Almacen y Politica de la persona    

	BEGIN TRY
		IF EXISTS(SELECT TOP 1 1 FROM dbo.Persona WHERE nroDocumento = @nroDocumento)
			BEGIN 
				SELECT '0', 'Existe usuario registrado con el numero de .', ''
				RETURN
			END
		BEGIN TRAN
			INSERT INTO dbo.Persona (idTipoDocumento, nroDocumento, primerNombre, segundoNombre, primerApellido, segundoApellido, nombreCompleto, fechaNacimiento, email, telefono, 
									 idPais, idProvincia, idParroquia, direccion, fechaRegistro) 
			VALUES(@idTipoDocumento, @nroDocumento, @primerNombre, @segundoNombre, @primerApellido, @segundoApellido, @primerNombre+' '+@segundoNombre+' '+@primerApellido+' '+@segundoApellido,
				   @fechaNacimiento, @email, @telefono, @idPais, @idProvincia,@idParroquia, @direccion, GETDATE())

			SET @idPersona = @@IDENTITY

			INSERT INTO dbo.Usuario(idPersona, usuario, contrasenia, imagen, fechaRegistro)
			VALUES(@idPersona, LOWER(@primerNombre)+'.'+LOWER(@primerApellido), HASHBYTES('sha_512', @nroDocumento), '', GETDATE())

			SET @idUsuario = @@IDENTITY
			
			INSERT INTO dbo.Rol(idUsuario, idPolitica, idSucursal, fechaRegistro) 
			VALUES(@idUsuario, 2, 1, GETDATE()  )
		COMMIT TRAN 
		SELECT '1','Registrado exitosamente', ''
		RETURN
		
	END TRY 
	BEGIN CATCH 
		IF @@TRANCOUNT > 0 ROLLBACK TRAN
		BEGIN 
			SELECT '0', 'Error ' + ERROR_MESSAGE(), ''
			RETURN
		END
	END CATCH
END
