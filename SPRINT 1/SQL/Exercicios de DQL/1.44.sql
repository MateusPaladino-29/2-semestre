--DQL

-- listar todos os usu�rios administradores, sem exibir suas senhas

select 
Usuarios.Nome,
Usuarios.Permissao,
Usuarios.Email


from Usuarios

where Usuarios.Permissao = 'Adm'



-- listar todos os �lbuns lan�ados ap�s  um determinado ano de lan�amento

select 
Albuns.Lancamento,
Albuns.QtndMinitos,
Artistas.Nome

from Albuns

left join Artistas on Artistas.IdArtista = Albuns.IdArtista

where Lancamento = '03/08/2023'


-- listar os dados de um usu�rio atrav�s do e-mail e senha

select 
Usuarios.Email,
Usuarios.Senha

from Usuarios

left join 






-- listar todos os �lbuns ativos, mostrando o nome do artista e os estilos do �lbum 