--DML

insert into TipoUsuario(TituloTipoUsuario)
values ('Medico')

insert into CLinica(NomeFantasia,RazaoSocial,CNPJ,Funcionamento)
values ('HC','Health Clinic', '89856222647421', 'Segunda a Sabado, das 05:00 as 23:00')

insert into Especialidade(TituloEspecialidade)
values('Cardiologista')

insert into Usuario(IdTipoUsuario,Nome,Email,Senha)
values(3,'mikael','mikael@Gmail.com','1627')

insert into Paciente(IdUsuario,CPF,idade)
values (1,'154879652304*15','18')

insert into Medico(IdUsuario,IdEspecialidade,IdClinica,CRM)
values (3,2,1,'48652055')

insert into Agendamento(IdPaciente,IdMedico,Sexo,Prontuario,Data_Consulta)
values(1,1,'Masculino','lucca, 18 anos, entupiu com cola o nariz', '2023-08-15')

insert into Comentario(IdAgendamento,Descricao,Exibe)
values (1,'Medico muito lindo e otimo atendimento',0)


--DQL

SELECT
    Usuario.Nome AS NomePaciente,
    Paciente.CPF AS CPFPaciente,
    Agendamento.Data_Consulta,
    CONCAT(Usuario.Nome, ' - ', Especialidade.TituloEspecialidade) AS EnderecoClinica,
    MedicoUsuario.Nome AS NomeMedico,
    Especialidade.TituloEspecialidade AS Especialidade,
    Medico.CRM AS CRMMedico,
    Agendamento.Prontuario

FROM Agendamento

INNER JOIN Paciente ON Agendamento.IdPaciente = Paciente.IdPaciente
INNER JOIN Medico ON Agendamento.IdMedico = Medico.IdMedico
INNER JOIN Usuario ON Paciente.IdUsuario = Usuario.IdUsuario
INNER JOIN Especialidade ON Medico.IdEspecialidade = Especialidade.IdEspecialidade
INNER JOIN Usuario AS MedicoUsuario ON Medico.IdUsuario = MedicoUsuario.IdUsuario;


select * from TipoUsuario
select * from Clinica
select * from Especialidade
select * from Comentario
select * from Usuario
select * from Paciente
select * from Medico
select * from Agendamento




create procedure MedicoEspecialidade
AS
SELECT * FROM Medico 
select * from Especialidade
GO;

exec MedicoEspecialidade


create function BuscaMedico
(
	@Especialidade varchar(100)
)
returns table
as
return
(
	select MedicoUsuario.Nome as Médico, 
	Especialidade.TituloEspecialidade as Especialidade
	from Especialidade
	inner join Medico on Medico.IdEspecialidade = Especialidade.IdEspecialidade
	inner join Usuario as MedicoUsuario on Medico.IdUsuario = MedicoUsuario.IdUsuario
	where Especialidade.TituloEspecialidade = @Especialidade
);

select * from BuscaMedico('otorrinolaringologista')



