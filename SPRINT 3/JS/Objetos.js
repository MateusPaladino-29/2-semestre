let mateus = {

    nome: "Mateus",
    idade: 17,
    altura: 1.80

};

mateus.peso = 78;

let vinicius = new Object();

vinicius.nome = "Vinicius";
vinicius.idade = 20;
vinicius.sobrenome = "Oliveira";

let pessoas = [];

pessoas.push(mateus);
pessoas.push(vinicius);


// console.log(pessoas);

pessoas.forEach((f,i) => {

    console.log(`Nome da ${i + 1}º pessoas: ${f.nome}`);
})




console.log(mateus);

console.log(vinicius);