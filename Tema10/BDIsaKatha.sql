USE BDIsaKatha
GO

-- Borrar tablas
DROP TABLE Personas
GO
DROP TABLE Departamentos
GO

-- Crear tablas
CREATE TABLE Departamentos (
ID int IDENTITY(1,1) PRIMARY KEY,
Nombre varchar(30) NOT NULL
)
GO

CREATE TABLE Personas (
ID int IDENTITY(1,1) PRIMARY KEY,
Nombre varchar(30) NOT NULL, 
Apellidos varchar(60) NOT NULL,
Telefono varchar(15),
Direccion varchar(60),
Foto varchar(255),
FechaNacimiento DATE,
IDDepartamento int
CONSTRAINT FK_PersonaDepartamento FOREIGN KEY (IDDepartamento) REFERENCES Departamentos(ID)
)
GO

-- Insertar datos en tabla departamentos
insert into Departamentos (Nombre) values ('Comercial');
insert into Departamentos (Nombre) values ('Ventas');
insert into Departamentos (Nombre) values ('Recursos Humanos');
insert into Departamentos (Nombre) values ('Finanzas');

-- Insertar datos en tabla personas
insert into Personas (Nombre, Apellidos, Telefono, Direccion, Foto, FechaNacimiento, IDDepartamento) values ('Geneva', 'Bambrick', '8937405625', '7 Gulseth Place', 'http://dummyimage.com/121x100.png/dddddd/000000', '1987-06-17', 3);
insert into Personas (Nombre, Apellidos, Telefono, Direccion, Foto, FechaNacimiento, IDDepartamento) values ('Blondelle', 'Hadley', '2976806412', '9496 Gerald Circle', 'http://dummyimage.com/210x100.png/ff4444/ffffff', '1918-11-28', 2);
insert into Personas (Nombre, Apellidos, Telefono, Direccion, Foto, FechaNacimiento, IDDepartamento) values ('Tandi', 'Fowley', '5652448501', '08 Lyons Hill', 'http://dummyimage.com/179x100.png/dddddd/000000', '1926-04-19', 3);
insert into Personas (Nombre, Apellidos, Telefono, Direccion, Foto, FechaNacimiento, IDDepartamento) values ('Renelle', 'Izod', '8734047999', '75362 Atwood Way', 'http://dummyimage.com/114x100.png/5fa2dd/ffffff', '1974-12-15', 3);
insert into Personas (Nombre, Apellidos, Telefono, Direccion, Foto, FechaNacimiento, IDDepartamento) values ('Rici', 'Moryson', '5098132946', '2 Cambridge Plaza', 'http://dummyimage.com/108x100.png/dddddd/000000', '2006-04-11', 3);
insert into Personas (Nombre, Apellidos, Telefono, Direccion, Foto, FechaNacimiento, IDDepartamento) values ('Kiele', 'Sture', '8228710667', '7631 North Street', 'http://dummyimage.com/187x100.png/cc0000/ffffff', '1984-05-06', 4);
insert into Personas (Nombre, Apellidos, Telefono, Direccion, Foto, FechaNacimiento, IDDepartamento) values ('Druci', 'Henden', '6304452378', '7833 Burning Wood Alley', 'http://dummyimage.com/158x100.png/cc0000/ffffff', '1920-04-29', 3);
insert into Personas (Nombre, Apellidos, Telefono, Direccion, Foto, FechaNacimiento, IDDepartamento) values ('Forbes', 'Prime', '4348520143', '6569 Bluestem Pass', 'http://dummyimage.com/222x100.png/dddddd/000000', '1928-12-15', 3);
insert into Personas (Nombre, Apellidos, Telefono, Direccion, Foto, FechaNacimiento, IDDepartamento) values ('Sonni', 'Fagg', '6781579269', '8 Sunfield Park', 'http://dummyimage.com/235x100.png/ff4444/ffffff', '2001-08-05', 2);
insert into Personas (Nombre, Apellidos, Telefono, Direccion, Foto, FechaNacimiento, IDDepartamento) values ('Lidia', 'Jannaway', '7484365412', '47 Summit Pass', 'http://dummyimage.com/154x100.png/dddddd/000000', '1960-10-10', 2);
insert into Personas (Nombre, Apellidos, Telefono, Direccion, Foto, FechaNacimiento, IDDepartamento) values ('Celisse', 'Dach', '4789516235', '39021 Fallview Pass', 'http://dummyimage.com/164x100.png/5fa2dd/ffffff', '1949-03-14', 2);
insert into Personas (Nombre, Apellidos, Telefono, Direccion, Foto, FechaNacimiento, IDDepartamento) values ('Amalea', 'Donohue', '3078687742', '9992 Maple Wood Circle', 'http://dummyimage.com/186x100.png/ff4444/ffffff', '1919-06-23', 1);
insert into Personas (Nombre, Apellidos, Telefono, Direccion, Foto, FechaNacimiento, IDDepartamento) values ('Jemimah', 'Borman', '8799500598', '10 Buena Vista Avenue', 'http://dummyimage.com/212x100.png/5fa2dd/ffffff', '1941-03-29', 4);
insert into Personas (Nombre, Apellidos, Telefono, Direccion, Foto, FechaNacimiento, IDDepartamento) values ('Yetty', 'Haythorne', '2308796899', '71 Sherman Pass', 'http://dummyimage.com/171x100.png/dddddd/000000', '1987-03-17', 1);
insert into Personas (Nombre, Apellidos, Telefono, Direccion, Foto, FechaNacimiento, IDDepartamento) values ('Phedra', 'Higford', '1417094211', '3991 Shasta Hill', 'http://dummyimage.com/164x100.png/5fa2dd/ffffff', '2013-03-05', 3);
insert into Personas (Nombre, Apellidos, Telefono, Direccion, Foto, FechaNacimiento, IDDepartamento) values ('Savina', 'Croasdale', '8694626726', '7 Stone Corner Lane', 'http://dummyimage.com/134x100.png/ff4444/ffffff', '1949-09-02', 1);
insert into Personas (Nombre, Apellidos, Telefono, Direccion, Foto, FechaNacimiento, IDDepartamento) values ('Pippa', 'Thursfield', '8868112461', '00416 Eggendart Parkway', 'http://dummyimage.com/187x100.png/ff4444/ffffff', '2019-11-12', 4);
insert into Personas (Nombre, Apellidos, Telefono, Direccion, Foto, FechaNacimiento, IDDepartamento) values ('Marris', 'Sivell', '4235561138', '0 Declaration Way', 'http://dummyimage.com/175x100.png/dddddd/000000', '1932-01-04', 4);
insert into Personas (Nombre, Apellidos, Telefono, Direccion, Foto, FechaNacimiento, IDDepartamento) values ('Anita', 'St Leger', '9377123270', '10510 Stephen Pass', 'http://dummyimage.com/236x100.png/ff4444/ffffff', '1984-06-21', 4);
insert into Personas (Nombre, Apellidos, Telefono, Direccion, Foto, FechaNacimiento, IDDepartamento) values ('Joanne', 'Heare', '4605686478', '44 Southridge Crossing', 'http://dummyimage.com/130x100.png/cc0000/ffffff', '2022-07-31', 3);
insert into Personas (Nombre, Apellidos, Telefono, Direccion, Foto, FechaNacimiento, IDDepartamento) values ('Jeannette', 'Moyles', '7272321810', '63957 Mallard Park', 'http://dummyimage.com/115x100.png/ff4444/ffffff', '2009-02-27', 4);
insert into Personas (Nombre, Apellidos, Telefono, Direccion, Foto, FechaNacimiento, IDDepartamento) values ('Dall', 'Gainforth', '8631042700', '32 Shelley Plaza', 'http://dummyimage.com/225x100.png/5fa2dd/ffffff', '2013-11-03', 2);
insert into Personas (Nombre, Apellidos, Telefono, Direccion, Foto, FechaNacimiento, IDDepartamento) values ('Cameron', 'Maren', '6647744537', '68129 Randy Center', 'http://dummyimage.com/198x100.png/5fa2dd/ffffff', '1926-11-08', 4);
insert into Personas (Nombre, Apellidos, Telefono, Direccion, Foto, FechaNacimiento, IDDepartamento) values ('Genovera', 'Garthside', '2095414259', '0 Homewood Trail', 'http://dummyimage.com/131x100.png/5fa2dd/ffffff', '1997-12-12', 1);
insert into Personas (Nombre, Apellidos, Telefono, Direccion, Foto, FechaNacimiento, IDDepartamento) values ('Torrance', 'Panton', '3158073186', '5 Golf Hill', 'http://dummyimage.com/234x100.png/ff4444/ffffff', '1999-11-19', 1);
insert into Personas (Nombre, Apellidos, Telefono, Direccion, Foto, FechaNacimiento, IDDepartamento) values ('Humberto', 'McIlwraith', '4165229438', '771 Maryland Trail', 'http://dummyimage.com/198x100.png/dddddd/000000', '2004-01-11', 4);
insert into Personas (Nombre, Apellidos, Telefono, Direccion, Foto, FechaNacimiento, IDDepartamento) values ('Elisabetta', 'Stickley', '4683442859', '61 3rd Alley', 'http://dummyimage.com/192x100.png/5fa2dd/ffffff', '1954-03-14', 4);
insert into Personas (Nombre, Apellidos, Telefono, Direccion, Foto, FechaNacimiento, IDDepartamento) values ('Rachael', 'Weber', '1259689795', '79168 Meadow Ridge Drive', 'http://dummyimage.com/145x100.png/dddddd/000000', '1955-08-29', 3);
insert into Personas (Nombre, Apellidos, Telefono, Direccion, Foto, FechaNacimiento, IDDepartamento) values ('Amandie', 'Linnitt', '2209618952', '44210 Lyons Pass', 'http://dummyimage.com/167x100.png/ff4444/ffffff', '1908-08-28', 3);
insert into Personas (Nombre, Apellidos, Telefono, Direccion, Foto, FechaNacimiento, IDDepartamento) values ('Pavel', 'Mansel', '9625267112', '90 Redwing Plaza', 'http://dummyimage.com/200x100.png/cc0000/ffffff', '1953-10-24', 2);