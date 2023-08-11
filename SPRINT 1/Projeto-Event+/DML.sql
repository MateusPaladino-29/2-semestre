--DML

insert into TipoUsuario(TituloTipoUsuario)
values ('Administrador'),('Comum')

insert into TipoEvento(TituloTipoEvento)
values ('SQL Server')

insert into instituicao(NomeFantasia,CNPJ,Endereco)
values ('DevSchool','12312121000495','Rua Niteroi 180')

insert into Usuario(IdTipoUsuario,Nome,Email,Senha)
values (1,'Mateus','SucoFruta@gmail.com','1626')

insert into evento(IdInstituicao,IdTipoEvento,Nome,Data_Evento,Horario,Descricao)
values (3,1,'Intensivao SQL','2023-08-11','15:30:00','Um evendo voltado para TI ...')

insert into PresencaEvento(IdUsuario,IdEvento,Situacao)
values(4,6,1)

insert into Comentario(IdUsuario,IdEvento,Descricao,Exibe)
values(1,1,'Evento muito bala',1)