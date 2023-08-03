--DDL

create database exercicio_1_3

create table Clinica
(
IdClinica int primary key identity,
Endereco varchar(200)
)

create table Dono
(
IdDono int Primary key identity,
Nome varchar(15)
)

create table raca	
(
IdRaca int Primary key identity,
descricao varchar(15) unique 
)

create table TipoPet
(
IdTipoPet int Primary key identity,
descricao varchar(15)
)


create table Pet
(
IdPet int Primary key identity,
IdTipoPet int foreign key references TipoPet(IdTipoPet),
IdRaca int foreign key references Raca(IdRaca),
IdDono int foreign key references Dono(IdDono),
nome varchar(20),
nascimento varchar (15)
)

create table Veterinario
(
IdVeterinario int Primary key identity,
IdClinica int foreign key references Clinica(IdClinica),
nome varchar(20),
CRMV varchar (15)
)

create table Atendimento
(
IdAtendimento int Primary key identity,
IdPet int foreign key references Pet(IdPet),
IdVeterinario int foreign key references Veterinario(IdVeterinario),
Descricao varchar(20),
Data_atendimento varchar (15)
)



