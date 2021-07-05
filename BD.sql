CREATE DATABASE pruebaMicroservice;


CREATE TABLE CargaBipRetail(
	ID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Codigo int NOT NULL,
	Entidad varchar(300) NOT NULL,
	NombreFantasia varchar(300) NOT NULL,
	Direccion varchar(max) NOT NULL,
	Comuna varchar(300) NOT NULL,
	HorarioReferencial varchar(500) NOT NULL,
	Este int NOT NULL,
	Norte int NOT NULL,
	Longitud float NOT NULL,
	Latitud float NOT NULL)

INSERT INTO CargaBipRetail values
(102
,'UNIMARC'
,'UNIMARC JUAN ANTONIO RIOS'
,'SALOMON SACK 351'
,'INDEPENDENCIA'
,'Lun-Dom 09:00 a 20:00'
,344653
,6300937
,-70.67080616666668
,-33.419566666666654)

INSERT INTO CargaBipRetail values
(103
,'UNIMARC'
,'UNIMARC DORSAL'
,'AV. EL GUANACO 3100'
,'CONCHALI'
,'Lun-Dom 09:00 a 20:00'
,345812
,6303726
,-70.6578679616206
,-33.3945915377861)

select * from CargaBipRetail
