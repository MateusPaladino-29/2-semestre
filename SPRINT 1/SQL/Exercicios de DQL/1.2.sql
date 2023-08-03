 --listar todos os alugueis mostrando as datas de início e fim, o nome do cliente que alugou e nome do modelo do carro


--DQL

SELECT 

Aluguel.IdAluguel,
Aluguel.Data_Inicial,
Aluguel.Data_Final,
Cliente.Nome,
Modelo.Nome


FROM Aluguel 
inner join Cliente on Aluguel.IdCliente = Cliente.IdCliente
inner join Veiculo on Aluguel.IdVeiculo = Veiculo.Idveiculo
inner join Modelo on Modelo.IdModelo = Veiculo.IdModelo


-- listar os alugueis de um determinado cliente mostrando seu nome, as datas de início e fim e o nome do modelo do carro

SELECT 

Aluguel.IdAluguel,
Aluguel.Data_Inicial,
Aluguel.Data_Final,
Cliente.Nome,
Modelo.Nome


FROM Aluguel 
inner join Cliente on Aluguel.IdCliente = Cliente.IdCliente
inner join Veiculo on Aluguel.IdVeiculo = Veiculo.Idveiculo
inner join Modelo on Modelo.IdModelo = Veiculo.IdModelo

where 
cliente.Nome = 'Mateus' 
