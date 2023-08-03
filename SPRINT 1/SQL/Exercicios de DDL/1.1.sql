--Criar um banco

create database Exercicio_1_1;

--Criar no tabelas 

create table Pessoa
(
IdPessoa int primary key identity,
Nome varchar(15) not null,
CNH Char(10) not null unique 
);

create table Telefone 
(
IdTelefone int primary key identity,
IdPessoa int foreign key references Pessoa(IdPessoa),
Endereco varchar(20) not null unique 
);



create table Email
(
IdEmail int primary key identity,
IdPessoa int foreign key references Pessoa(IdPessoa),
Endereco varchar(20)not null 
);


select * from Telefone