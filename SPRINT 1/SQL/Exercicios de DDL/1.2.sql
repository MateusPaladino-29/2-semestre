--DDL

create database Exercicio_1_2;

create table Cliente
(

IdCliente int primary key identity,
Nome Varchar(30),
CPF char(11) unique 

)


create table Empresa
(
IdEmpresa int primary key identity,
Nome Varchar(30) unique
)

create table Modelo
(
IdModelo int primary key identity,
Nome Varchar(30)
)

create table Marca
(
IdMarca int primary key identity,
Nome Varchar(30) unique 
)

create table Veiculo
(
IdVeiculo int primary key identity,
IdEmpresa int foreign key references Empresa(IdEmpresa),
IdModelo int foreign key references Modelo(IdModelo),
IdMarca int foreign key references Marca(IdMarca),
Placa char(8)
)


create table Aluguel
(
IdAluguel int primary key identity,
IdVeiculo int foreign key references Veiculo(IdVeiculo),
IdCliente int foreign key references Cliente(IdCliente),
protocolo varchar(50)
)

alter table Aluguel
add Data_Final varchar(30)

alter table Aluguel 
add Data_Inicial varchar(30)

select * from Aluguel

