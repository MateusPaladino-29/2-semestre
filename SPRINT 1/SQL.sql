--DDL - DATA DEFINITION LANGUAGE

--CRIA BANCO DE DADOS

create database BancoTarde;

--USA BANCO DE DADOS
USE BancoTarde;

--CREATE TABLE PARA CRIAR TABELA

CREATE TABLE Funcionarios
(
	IdFuncionario int primary key identity,
	Nome char(10)
);

create table empresas
(
IdEmpresas int primary key identity,

IdFuncionarios int foreign key references Funcionarios(IdFuncionario),

Nome varchar(20)

);

-----------------

--Alter table

alter table Funcionarios
add cpf varchar(11)


alter table Funcionarios 
drop column cpf

drop table empresas;



drop database BancoTarde




--dml: data manipulation language

insert into Funcionarios(Nome)
values('vini')

update Funcionarios 
set Nome = 'REBECA' where Nome = 'Rebeca'




--dql - data query language

select * from Funcionarios 