--DML

insert into Clinica(Endereco)
Values ('Rua niteroi N 180')

insert into Dono (Nome)
values('Mateus'), ('vini')

insert into raca(descricao)
Values('Pastor Alemao'), ('Arara-Azul')

insert into TipoPet(descricao)
Values ('Canino'), ('Ave')

insert into Pet(IdDono,IdRaca,IdTipoPet,nome,nascimento)
values (1,2,2,'Judite','22/08/2022'), (1,1,1,'judito','02/08/2020')

insert into Veterinario(IdClinica,nome,CRMV)
Values (1,'Murilo','123456'), (1,'Felipe','1564872')

insert into Atendimento(IdPet, IdVeterinario, Descricao, Data_atendimento)
values (1,1,'Cirurgia', '02/02/2023'), (1,2,'pos-cirurgia','03/08/2023'), (2,1,'Avalicao', '03/08/2023')



select * from Atendimento