--DML 1.4

insert into Artistas(Nome)
values ('Matue'), ('Pixote')

insert into Estilo(Nome)
values ('trap'),('Pagode')

insert into Albuns(IdArtista,Titulo,Lancamento,Localizacao,QtndMinitos,ativo)
values (1,'tue', '03/08/2023', 'spotfy', '60 min', 'Sim'), (2,'Amor', '03/08/2023', 'spotfy', '70 min', 'Sim')

insert into AlbunsEstilo(IdAlbum, IdEstilo)
values (1,1), (2,2)

insert into Usuarios(Nome,Email,Senha,Permissao)
values ('vini','Vini@gmail.com','1234','Sim'),('Mateus','Mat@gmail.com','1626','Sim')

select * from Albuns