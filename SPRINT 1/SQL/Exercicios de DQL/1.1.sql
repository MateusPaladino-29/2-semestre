
--DQL
--listar as pessoa em ordem alfabetica reversa, mostrando seus telefones, emails
--e CNHs

--script sem  usar join

--chama o nome, numero, email, e a cnh das tabelas em que elas estão armazenadas
select 
p.Nome as NOME, 
Telefone.Endereco as Telefone, 
e.Endereco as EnderecoEmail, 
p.CNH
--de quais tabelas quero q venha os dados
from 
Pessoa as p, 
Email as e, 
Telefone   --de quais tabelas quero q venha os dados
--where p/ 
where p.IdPessoa  = e.IdPessoa
AND p.IdPessoa = Telefone.IdPessoa

--ordena pelo nome
order by nome desc

--chama o nome, numero, email, e a cnh das tabelas em que elas estão armazenadas

insert into pessoa values 
('GABRIEL', '121121215'),
('VINI', '78787'),
('carlos', '9691215')


select * from pessoa