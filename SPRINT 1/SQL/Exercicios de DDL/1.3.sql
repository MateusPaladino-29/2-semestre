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