// const  CamisaLacoste = {
//     descricao: "Camisa Lacoste",
//     preco: 400.50,
//     marca: "Lacoste",
//     tamanho: "GG",
//     cor:"Azul Ciano",
//     promocao: false

// }

// const descricao = CamisaLacoste.descricao;
// const preco = CamisaLacoste.preco;

// const {descricao, preco, promocao} = CamisaLacoste;



// console.log(`
//     Produto:${descricao}
//     Preço: ${preco}
//     Promoção: ${promocao ? "sim" : "nao"}
// `);

const Evento = {
    descricacao: "Lacoust vivo",
    tiutlo: "LACOUST0",
    data: new Date(),
    presenca: true,
    comenatrio: "Amei o lacoust vivo, ele é lindo"
}

const {descricacao, tiutlo, data, presenca, comenatrio, ... resto} = Evento;

console.log(`
Descrição: ${descricacao}
Titulo: ${tiutlo}
Data: ${data}
Presença: ${presenca ? "Irei" : "Nao Irei"}
Comentario: ${comenatrio}
`);

