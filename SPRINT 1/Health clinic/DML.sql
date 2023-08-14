--DML

insert into TipoUsuario(TituloTipoUsuario)
values ('Admin'), ('Medico'),('Paciente')

insert into CLinica(NomeFantasia,RazaoSocial,CNPJ,Funcionamento)
values ('HC','Health Clinic', '898562226474215', 'Segunda a Sabado, das 05:00 as 23:00')

insert into Especialidade(TituloEspecialidade)
values('otorrinolaringologista')

insert into Comentario(IdAgendamento,Descricao,Exibe)
values (1,'Medico muito lindo e otimo atendimento',0)

insert into Usuario(IdTipoUsuario,Email,Senha)
values(1,'Teixeirapaladino921@Gmail.com','1626') 

insert into Paciente(IdUsuario,Nome,CPF,idade)
values (1,'Jacinto','256325486258*36','20')