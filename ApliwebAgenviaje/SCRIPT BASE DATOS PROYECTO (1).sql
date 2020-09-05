create database AgenciaViajeSA
drop database AgenciaViajeSA
go
use AgenciaViajeSA

create table empleado(
id int primary key,
cedula int,
NombreComple varchar(60),
telefono varchar(20),
email varchar(60),
estado bit,
ultimodifi DateTimeOffset NOT NULL default SYSDATETIMEOFFSET() 
)

insert into empleado (id,cedula,NombreComple,telefono,email,estado)
values (1,12456789,'Santiago Ortega','32525124','sena@sena.com',1),
(2,5523123,'Juan Velez','31152452','censa@sena.com',1), 
(3,4256633,'Yesica Marin','302522523','mycorre@hotmail.com',1)
insert into empleado (id,cedula,NombreComple,telefono,email,estado)
values (4,423212,'Mustafa Gay','523523','mustafa@hotmail.com',1)

select * from empleado
go

create table cliente(
cedula int primary key,
NombreComple varchar(60),
telefono varchar(20),
email varchar(60),
estado bit,
ultimodifi DateTimeOffset NOT NULL default SYSDATETIMEOFFSET() 
)



insert into cliente(cedula,NombreComple,telefono,email,estado)
values(12341234,'Juanes de Nazareth','301252345','nazareth@hotmail.com',1),
(111526634,'Camilo Cabuya','35602412','cabuya@hotmail.com',0),
(156221235,'Elizabeth Taylor','307125212','taylor@hotmail.com',1)


select * from detalle
go


create table detalle(
id int IDENTITY primary key,
NombreServi varchar(255),
valorservi int,
estado bit
)
insert into detalle
values('Hotel Habitacion232',700232,1)
insert into detalle
values('Aerolinea Bethoven',3532124,1)

select * from detalle
go

create table factura(
id int IDENTITY primary key,
cedula_cliente int,
id_empleado int,
id_detalle int,
subtotal int,
iva int,
total int,

foreign key (id_empleado) references empleado(id),
foreign key (cedula_cliente) references cliente(cedula),
foreign key (id_detalle) references detalle(id)
)


insert into factura
values(156221235,1,1,34523,19,704235)

select * from factura
go

create table DetalleServi(
idmov int IDENTITY primary key,
factura_id int,
detalle_id int,
fecha datetime NOT NULL default CURRENT_TIMESTAMP
foreign key (factura_id) references factura(id),
foreign key (detalle_id) references detalle(id)
)
insert into DetalleServi(factura_id,detalle_id)
values(1,1)


go

select * from empleado
select * from cliente
select * from detalle
select * from factura

truncate table factura
select * from DetalleServi
go
--------Procedimientos almacenados---------------------->
create procedure USP_ultifac
as
begin
select 0 as idfac
union
SELECT MAX (id) + 1 from factura
end

go
----factura ultimo
create procedure USP_ingresoultifac
as
begin
SELECT MAX (id) + 1 FROM factura

end


go
----mov ingreso----
create procedure USP_movisave
@factura_id int,
@detalle_id int
as
begin
insert into DetalleServi(factura_id,detalle_id) values (@factura_id,@detalle_id)
end

go
-------factura ingresar-----
create procedure USP_ingresofactura

-----fac
@cedula_cliente int,
@id_empleado int,
@id_detalle int,
@subtotal int,
@iva int,
@total int
as
begin
insert into factura(cedula_cliente,id_empleado,id_detalle,subtotal,iva,total)
values(@cedula_cliente,@id_empleado,@id_detalle,@subtotal,@iva,@total)
end

----insertar detalle




create procedure USP_InsertDetalles
@NombreServi varchar(255),
@valorservi int,
@estado bit,
@descripcion varchar(60),
@id_servi int
as
begin
insert into detalle values (@NombreServi,@valorservi,@estado,@descripcion,@id_servi)
end
----selecionar detalle
go
create procedure USP_SelectDetalleUlti
as
begin
select 0 as id_deta, 'Selecione ultimo detalle' as NombreDeta, 0 as valorservi
union
select id,NombreServi,valorservi from detalle
end





----Mostrar factura unica ulti-----------
go
create procedure USP_Mostrar_Factura
@cedula_cliente int
as
begin
select TOP 1 D.fecha AS FECHA_FACTURA, f.id AS COD_FACTURA, f.id_empleado AS COD_EMPLEADO , e.cedula AS CEDULA_ASESOR,
e.NombreComple AS NOMBRE_ASESOR, c.cedula AS CEDULA_CLIENTE , c.NombreComple AS NOMBRE_CLIENTE, de.NombreServi AS DESCRIPCION_PAQUETE, f.iva AS IVA, f.total AS TOTAL_A_PAGAR from factura f
inner join empleado e
on e.id=f.id_empleado
inner join cliente c
on c.cedula=f.cedula_cliente
inner join DetalleServi D
on D.factura_id=f.id
inner join detalle de
on de.id=f.id_detalle
where f.cedula_cliente = @cedula_cliente
order by COD_FACTURA desc
end


USP_Mostrar_Factura 666999

select * from detalle
select * from factura
select * from DetalleServi

use AgenciaViajeSA


----mostrar factura general
go
create procedure USP_Mostrar_FacturaAll
@cedula_cliente int
as
begin
--  
select deta.fecha AS FECHA_FACTURA, f.id AS COD_FACTURA,f.id_empleado AS COD_EMPLEADO , e.cedula AS CEDULA_ASESOR,
e.NombreComple AS NOMBRE_ASESOR, c.cedula AS CEDULA_CLIENTE , c.NombreComple AS NOMBRE_CLIENTE, de.NombreServi AS DESCRIPCION_PAQUETE, f.iva AS IVA, f.total AS TOTAL_A_PAGAR from factura f
inner join empleado e
on e.id=f.id_empleado
inner join cliente c
on c.cedula=f.cedula_cliente
inner join DetalleServi D
on D.detalle_id=f.id_empleado
inner join detalle de
on de.id=f.id_detalle
inner join DetalleServi deta
on deta.idmov=d.detalle_id
where f.cedula_cliente = 552321

end

--exec USP_Mostrar_Factura 552321
select * from cliente
go

go
------insertar cliente-----------


create proc USP_Insertar_Cliente
@cedula int,
@nombre varchar(60),
@tel varchar(20),
@mail varchar(60),
@estado bit
as 
begin
insert into cliente ([cedula],[NombreComple],[telefono],[email],[estado]) values (@cedula, @nombre, @tel, @mail, @estado)
end
--exec USP_Insertar_Cliente 1001368018, 'Judas Iscariote', '2380691', 'losamigosvalenoro@gmail.com', 1

select * from cliente


go


----------editar cliente------------


create proc USP_Editar_Cliente
@cedula int,
@nombre varchar(60),
@tel varchar(20),
@mail varchar(60),
@estado bit
as
begin
update cliente set NombreComple = @nombre, telefono = @tel, email = @mail, estado = @estado
where cedula = @cedula
end
--exec USP_Editar_Cliente 1001368018, 'Judas tadeos','2445212','judas@judas.com',1 


go

----------activar o inacticar cliente------------


create proc USP_actividadCliente
@cedula int,
@estado bit
as
begin
update cliente set estado=@estado where cedula=@cedula
end
--exec USP_actividadCliente 1001368018, 0

select * from cliente

go


-----------Selecionar empleado-------------->


create proc USP_Consult_Emple
as
begin
select 0 as idemple, 'Selecione un empleado' as SelectEmple
UNION
select id, NombreComple from empleado
UNION
select 9999 as idemple, 'Agregar nuevo empleado' as SelectEmple
order by idemple
end

--exec USP_Consult_Emple

go

create proc USP_Consult_factu
as
begin
select 0 as idfactu
UNION
select id from factura

end


------insertar empleado---------


create proc USP_Insertar_Empleado
@cedula int,
@NombreComple varchar(60),
@telefono varchar(20),
@email varchar(60),
@estado bit,
@idestaemple int OUTPUT
as
IF NOT EXISTS (SELECT * 
	FROM empleado
		WHERE cedula = @cedula)
	BEGIN
		BEGIN Transaction creat
		DECLARE @id_emple int
		SET @id_emple = (SELECT MAX (id) + 1
			FROM empleado)
		INSERT INTO empleado([id],[cedula],[NombreComple],[telefono],[email],[estado])
			VALUES (@id_emple, @cedula, @NombreComple, @telefono, @email, @estado)
		IF @@ERROR > 0
		BEGIN 
			ROLLBACK Transaction creat
			SET @idestaemple = 0
			SELECT @idestaemple
			return
		END
	ELSE
		COMMIT Transaction creat
		SET @idestaemple = @id_emple
		SELECT @idestaemple
		return
	END
ELSE
	BEGIN 
		SET @idestaemple = -1
		SELECT @idestaemple
		return
END
/*
Declare @cod int
exec USP_Insertar_Empleado 18843412,'Luis David Arboleda','34252312','luisda@gmail.com',1, @cod OUTPUT
select @cod
*/


go
select* from cliente
select * from factura
select * from empleado
select * from detalle
go


------activar/inactivar empleado------

create proc USP_actividadEmple
@id int,
@estado bit
as
begin
update empleado set estado=@estado where id=@id
end
--exec USP_actividadEmple 5,1

go

create procedure USP_GeneFactura
@cedula_cliente int,
@id_empleado int,
@id_detalle int
as
begin
insert into factura values(@cedula_cliente,@id_empleado,@id_detalle)
end
--exec USP_GeneFactura 12341234,1,2 

select * from detalle
select * from factura



select * from DetalleServi
select * from detalle

GO

----Insertar movimientos------

create procedure USP_InsertMov
@factura_id int,
@detalle_id int,
@cant int,
@valorTol int
as
begin
insert into DetalleServi(factura_id,detalle_id,cant,valorTol) values(@factura_id,@detalle_id,@cant,@valorTol)
end

exec USP_InsertMov 2,2,1,523212
go
create procedure USP_InsertDetalle
@NombreServi varchar(255),
@valorservi int,
@estado bit
as
begin
insert into detalle values( @NombreServi,@valorservi,@estado)
end
exec USP_InsertDetalle 'AutoBrindad',4523523,1


exec usp_
--FALTARIA INSERT DE TABLA MOVIMIENTO, Y LA DE DETALLE QUE ES DE LOS WEBSERVICE