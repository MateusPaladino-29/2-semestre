--DML INSERIR DADOS NAS TABELAS

--INSERINDO

insert into Pessoa (Nome,CNH)

values 
('joao', '3333333333'),
('Carlos', '4444444444')


insert into Telefone (IdPessoa,Endereco)

values 

(3,'(11)95967-3130'),
(1, '(11)77777-8888')


insert into Email (IdPessoa,Endereco)

values 
(1,'Teixeira@gmail.com'),
(2, 'Fruta@gmail.com'),
(1,'paladino@gmail.com')


select * from Email
