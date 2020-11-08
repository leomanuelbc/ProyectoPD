--TABLA USUARIOS
if object_id('usuarios') is not null
 drop table usuarios;
create table usuarios(
IdUsuario int Primary key Identity (1,1) not null,
NombreCompleto varchar(150),
Usuario varchar(50),
Contraseña varchar(100),
TipoUsuario varchar(50),
Estado varchar(50),
 );
--TABLA DEPARTAMENTO
 if object_id('Departamentos') is not null
 drop table Departamentos;
create table Departamentos(
IdDepartamento int Primary key Identity (1,1) not null,
NombreD varchar(50),
DescripcionD text
 );
--TABLA EMPLEADOS
 if object_id('Empleados') is not null
 drop table Empleados;
create table Empleados(
IdEmpleado int Primary key Identity (1,1) not null,
Nombre varchar(150),
Identidad varchar(20),
Genero varchar(15),
Telefono varchar(20),
Correo varchar(40),
Direccion Text,
IdPuesto int,
IdDepartamento int
 );
--TABLA PUESTOS
 if object_id('Puestos') is not null
 drop table Puestos;
create table Puestos( 
IdPuestos int ,
NombreP varchar(50),
DescripcionP Text,
 );
--TABLA ARTICULOS
 if object_id('Articulos') is not null
 drop table Articulos;
create table Articulos( 
IdArticulo int Primary key Identity (1,1) not null ,
NombreA varchar(50),
NumeroSeriee varchar(50),
CodigoA varchar(50),
IdMarca int,
Modelo varchar(50),
PrecioCompra Money,
FechaCompra date,
EstadoArticulo varchar(50),
Descripcion Text,
 );

--TABLA MARCA
 if object_id('Marca') is not null
 drop table Marca;
create table Marca( 
IdMarca int Primary key Identity (1,1) not null  ,
NombreM varchar(50),
DescripcionM Text,
 );

--TABLA CARGO
if object_id('CargoActivos') is not null
 drop table CargoActivos;
create table CargoActivos( 
IdCargo int Primary key Identity (1,1) not null  ,
CodigoInventario varchar(50),
FechaAsignacion date,
EstadoArticulo varchar(50),
Descripcion text,
IdArticulo int,
IdEmpleado int
 );
 --TABLA Descargos
 if object_id('Descargos') is not null
 drop table Descargos;
create table Descargos( 
IdDescargo int Primary key Identity (1,1) not null  ,
FechaDescargo date,
Descripcion Text,
MotivoDescargo nchar(10),
IdCargoActivo int
 );