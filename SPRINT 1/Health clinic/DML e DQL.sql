--DML

insert into TipoUsuario(TituloTipoUsuario)
values ('Paciente')

insert into CLinica(NomeFantasia,RazaoSocial,CNPJ,Funcionamento)
values ('HC','Health Clinic', '89856222647421', 'Segunda a Sabado, das 05:00 as 23:00')

insert into Especialidade(TituloEspecialidade)
values('otorrinolaringologista')

insert into Comentario(IdAgendamento,Descricao,Exibe)
values (1,'Medico muito lindo e otimo atendimento',0)

insert into Usuario(IdTipoUsuario,Email,Senha)
values(2,'lucca@Gmail.com','1627') 

insert into Paciente(IdUsuario,Nome,CPF,idade)
values (2,'lucca','154879652304*15','18')

insert into Medico(IdUsuario,IdEspecialidade,IdClinica,Nome,CRM)
values (1,1,1,'Dr.Paladino','48652054')

insert into Agendamento(IdPaciente,IdMedico,Sexo,Prontuario,Data_Consulta)
values(2,1,'Masculino','lucca, 18 anos, entupiu com cola o nariz', '2023-08-15')


--DQL

select 
	Paciente.Nome AS NomePaciente,
	Paciente.CPF AS CPFPaciente,
	Agendamento.Data_Consulta,
	Medico.Nome AS NomeMedico,
	Medico.CRM AS CRMMedico,
	Agendamento.Prontuario

from Agendamento
inner join Paciente on Agendamento.IdPaciente = Paciente.IdPaciente
inner join Medico on Agendamento.IdMedico = Medico.IdMedico
inner join Usuario on Medico.IdUsuario = Usuario.IdUsuario
inner join Usuario AS U on Paciente.IdUsuario = U.IdUsuario





select * from TipoUsuario
select * from Clinica
select * from Especialidade
select * from Comentario
select * from Usuario
select * from Paciente
select * from Medico
select * from Agendamento

