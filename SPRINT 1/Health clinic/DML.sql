--DML

insert into TipoUsuario(TituloTipoUsuario)
values ('Medico')

insert into CLinica(NomeFantasia,RazaoSocial,CNPJ,Funcionamento)
values ('HC','Health Clinic', '89856222647421', 'Segunda a Sabado, das 05:00 as 23:00')

insert into Especialidade(TituloEspecialidade)
values('otorrinolaringologista')

insert into Usuario(IdTipoUsuario,Email,Senha,Nome)
values (2,'SucoDeFruta@gmail.com','7879','Paladino')

insert into Paciente(IdUsuario,CPF,idade)
values (1,'154879652304*15','18')

insert into Medico(IdUsuario,IdEspecialidade,IdClinica,CRM)
values (2,1,1,'48652054')

insert into Comentario(IdAgendamento,Descricao,Exibe)
values (3,'Medico muito lindo e otimo atendimento',1)

insert into Agendamento(IdPaciente,IdMedico,Sexo,Prontuario,Data_Consulta)
values(1,2,'Masculino','lucca, 18 anos, entupiu com cola o nariz', '2023-08-15')




--DQL

SELECT
    Usuario.Nome AS NomePaciente,
    Paciente.CPF AS CPFPaciente,
    Agendamento.Data_Consulta,
    CONCAT(Usuario.Nome, ' - ', Especialidade.TituloEspecialidade) AS EspecialidadeMedico,
    MedicoUsuario.Nome AS NomeMedico,
    Especialidade.TituloEspecialidade AS Especialidade,
    Medico.CRM AS CRMMedico,
    Agendamento.Prontuario,
	Comentario.Descricao
FROM
    Agendamento
INNER JOIN Paciente ON Agendamento.IdPaciente = Paciente.IdPaciente
INNER JOIN Medico ON Agendamento.IdMedico = Medico.IdMedico
INNER JOIN Usuario ON Paciente.IdUsuario = Usuario.IdUsuario
INNER JOIN Especialidade ON Medico.IdEspecialidade = Especialidade.IdEspecialidade
INNER JOIN Usuario AS MedicoUsuario ON Medico.IdUsuario = MedicoUsuario.IdUsuario
left JOIN Comentario on Agendamento.IdComentario = Comentario.IdComentario

select * from TipoUsuario
select * from Clinica
select * from Especialidade
select * from Comentario
select * from Usuario
select * from Paciente
select * from Medico
select * from Agendamento

 create procedure TodosAgendamentos
 as
 Select * from Agendamento
 go;

 exec TodosAgendamentos

 

