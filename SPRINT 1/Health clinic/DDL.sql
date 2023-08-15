--DDL

create database Health_Clinic

create table TipoUsuario
(
IdTipoUsuario int primary key identity,
TituloTipoUsuario varchar(30) not null
)

create table Clinica
(	
IdClinica int primary key identity,
NomeFantasia varchar(30) not null,
RazaoSocial varchar(30) unique not null,
CNPJ char(14) unique not null,
Funcionamento varchar(70) not null 
)

create table Especialidade
(
IdEspecialidade int primary key identity,
TituloEspecialidade varchar(30) not null
)

create table Comentario
(
IdComentario int primary key identity,
IdAgendamento int foreign key references Agendamento(IdAgendamento),
Descricao varchar(100) not null,
Exibe bit default(0)
)



Create table Usuario
(
IdUsuario int primary key identity,
IdTipoUsuario int foreign key references TipoUsuario(IdTipoUsuario),
Email varchar(50) unique not null,
Senha varchar(20) not null,
)

	

Create table Paciente
(
IdPaciente int primary key identity,
IdUsuario int foreign key references Usuario(IdUsuario),
Nome varchar(50) not null,
CPF char(15) unique not null,
idade varchar(3) not null

)



Create table Medico
(
IdMedico int primary key identity,
IdUsuario int foreign key references Usuario(IdUsuario),
IdEspecialidade int foreign key references Especialidade(IdEspecialidade),
IdClinica int foreign key references Clinica(IdClinica),
Nome varchar(50) not null,
CRM varchar(15) unique not null,
)



Create table Agendamento
(
IdAgendamento int primary key identity,
IdPaciente int foreign key references Paciente(IdPaciente),
IdMedico int foreign key references Medico(IdMedico),
Sexo varchar(15) not null,
Prontuario varchar(50) not null,
Data_Consulta date not null

)


drop database Health_Clinic