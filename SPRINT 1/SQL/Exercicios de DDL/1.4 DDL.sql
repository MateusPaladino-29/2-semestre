--DDL 1.4

create database exercicio_1_4

create table Artistas 
(
IdArtista int primary key identity,
Nome varchar(20)
)

create table Estilo 
(
IdEstilo int primary key identity,
Nome varchar(20)
)

create table Albuns
(
IdAlbum int primary key identity,
IdArtista int foreign key references Artistas(IdArtista),
Titulo varchar(20),
Lancamento varchar(20),
Localizacao varchar(30),
QtndMinitos varchar(15),
ativo varchar(6)
)



--Executar primeriro o album e o estilo 
create table AlbunsEstilo
(
IdAlbumEstilo int primary key identity,
IdEstilo int foreign key references Estilo(IdEstilo),
IdAlbum int foreign key references Albuns(IdAlbum)
)


create table Usuarios
(
IdUsuarios int primary key identity,
Nome varchar(20),
Email varchar(20),
Senha varchar(30) unique,
Permissao varchar(15),
)
