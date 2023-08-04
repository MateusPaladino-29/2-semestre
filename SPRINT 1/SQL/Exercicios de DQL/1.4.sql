--DQL

-- listar todos os veterin�rios (nome e CRMV) de uma cl�nica (raz�o social)

select

Veterinario.nome,
Veterinario.CRMV,
Clinica.IdCLinica

from Veterinario

left join Clinica on Veterinario.IdClinica = Clinica.IdClinica


-- listar todas as ra�as que come�am com a letra S

select * from raca where descricao like 'S%'

-- listar todos os tipos de pet que terminam com a letra O
select * from Pet where nome like '%o'

-- listar todos os pets mostrando os nomes dos seus donos

select 
Pet.nome, 
Dono.nome

 from Pet

left join Dono on Pet.IdDono = Dono.IdDono




-- listar todos os atendimentos mostrando o nome do veterin�rio que atendeu, o nome, a ra�a e o tipo do pet que foi atendido, o nome do dono do pet e o nome da cl�nica onde o pet foi atendido





SELECT 
	Atendimento.Descricao,
	Dono.Nome , 
	Pet.Nome, 
	TipoPet.descricao, 
	raca.descricao, 
	Veterinario.Nome, 
	Clinica.Endereco

FROM 	Atendimento

LEFT JOIN Veterinario ON Veterinario.IdVeterinario = Atendimento.IdVeterinario
LEFT JOIN Pet ON Pet.IdPet = Atendimento.IdPet
LEFT JOIN Dono ON Dono.IdDono = Pet.IdDono
LEFT JOIN raca ON raca.IdRaca = Pet.IdRaca
LEFT JOIN TipoPet ON TipoPet.IdTipoPet = Pet.IdTipoPet
LEFT JOIN Clinica 	ON Clinica.IdClinica = Veterinario.IdClinica;










--SELECT 
--	Atendimento.IDAtendimento AS ATENDIMENTO,
--	Dono.Nome AS DONO, 
--	Pet.Nome AS  PET, 
--	Pet.IdTipoPet AS ESPECIE, 
--	Pet.IdRaca AS  RA�A, 
--	Veterinario.Nome AS VETERIN�RIO, 
--	Clinica.Endereco AS CL�NICA
--FROM 
--	Atendimento
--LEFT JOIN Veterinario ON Veterinario.IdVeterinario = Atendimento.IdVeterinario
--LEFT JOIN Pet ON Pet.IdPet = Atendimento.IdPet
--LEFT JOIN Dono ON Dono.IdDono = Pet.IdDono
--LEFT JOIN Clinica 	ON Clinica.IdClinica = Veterinario.IdClinica;