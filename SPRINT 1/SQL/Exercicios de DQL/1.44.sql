--DQL

-- listar todos os usuários administradores, sem exibir suas senhas

select 
Usuarios.Nome,
Usuarios.Permissao,
Usuarios.Email


from Usuarios

where Usuarios.Permissao = 'Adm'



-- listar todos os álbuns lançados após  um determinado ano de lançamento

select 
Albuns.Lancamento,
Albuns.QtndMinitos,
Artistas.Nome

from Albuns

left join Artistas on Artistas.IdArtista = Albuns.IdArtista

where Lancamento = '03/08/2023'


-- listar os dados de um usuário através do e-mail e senha

select 
Usuarios.Email,
Usuarios.Senha

from Usuarios

left join 






-- listar todos os álbuns ativos, mostrando o nome do artista e os estilos do álbum 