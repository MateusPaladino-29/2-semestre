CREATE DATABASE Filmes_Tarde
USE Filmes_Tarde

CREATE TABLE Genero
(
	IdGenero INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(50)
)

CREATE TABLE Filme
(
	IdFilme INT PRIMARY KEY IDENTITY,
	IdGenero INT FOREIGN KEY REFERENCES Genero(IdGenero),
	Titulo VARCHAR(50)
)

insert into Genero(Nome)
values('Comedia'),('Ação')

insert into Filme(IdGenero,Titulo)
values(1,'Gente Grande 2'), (2,'Matrix')

select
Genero.Nome,
Filme.Titulo

from Genero
inner join filme on Filme.IdGenero = Filme.IdFilme