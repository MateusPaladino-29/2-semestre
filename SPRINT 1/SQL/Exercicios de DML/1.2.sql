--DML

--Cliente
Insert into Cliente(Nome,CPF)
Values ('Mateus', '53282757836'),
('vini', '12345678911')


--Empresa

Insert into Empresa(Nome)
values 
('Alugue rico'),
('Alugue pobre')

--Modelo

insert into Modelo 
values 
('X4'),
('X3')

--Marca

Insert into Marca(Nome)
values 
('BMW'),
('SUBARO')

--Veiculo

insert into veiculo(IdEmpresa,IdMarca,IdModelo,Placa)

values
(1,1,1,'1234-ABC'),
(2,2,2,'7654-CBA')


--aluguel

insert into Aluguel(IdCliente,IdVeiculo, protocolo)

values
(1,2,'123456910'),
(1,1,'234567899'),
(2,1,'545467876')

update Aluguel
set Data_Inicial = '04/08/2023' where IdAluguel = 3


select * from Aluguel