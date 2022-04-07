select * from Provincia
select * from Canton
select * from Parroquia

----- INSERTE PROVINCIA
--INSERT INTO Provincia (idPais, descripcion) VALUES(1, 'Orellana'),(1, 'Morona Santiago')
--,(1,'Pichincha');

---- INSERTE CANTON
--INSERT INTO Canton(idProvincia, descripcion)VALUES(1,'Loreto' ),(1,'Sacha'),(2,'Macas'),(2,'Taisha')


---- INSERT PARROAQUIA
--INSERT INTO Parroquia(idcanton, descripcion)VALUES(3, 'Macuma')

--INSERT INTO dbo.Categoria(codigo, descripcion) VALUES(1, 'Impresora'), (2, 'Laptop'), (3, 'Cámara'), (4, 'Accesorios')


--INSERT INTO dbo.Politica(codigo, descripcion, estado) VALUES(1, 'root', 1), (2, 'Técnico', 1), (3, 'Cliente', 1)

INSERT INTO Entidad(razonSocial, nombrecomercial, ruc, abreviatura, direccion, correo,  telefono, estado)VALUES('AcontPlus','AcontPlus','1450152325001','VMC','Av. 09 de octubre', 'zaratec@qacontplus.com.ec','0991686066',1)
INSERT INTO Sucursal(idEntidad, razonSocial, nombrecomercial, direccion, estado)VALUES(1, 'AcontPlus','AcontPlus','Av. 09 de octubre', 1)
select * from Entidad
select * from Sucursal

--- siga avazando con Store procedure --- ya vuelvo en minutos je,je...