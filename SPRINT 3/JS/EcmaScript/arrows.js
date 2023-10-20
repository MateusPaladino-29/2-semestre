const somar = function name(x,y){
return x+y
}

const dobro = (numero) =>{
    return numero * 2;
}

// Quando temos apenas um parametro podemos fazer em os parenteses, entao "Numero pode ficar sem parenteses caso eu queira "

//quando temos uma linha apenas, podemos retirar as chaves e o return 

console.log(dobro(10));

const convidados = 
[
{nome:"Mateus", idade: 17},
{nome:"Kallan", idade: 18},
{nome:"VInin", idade: 20},
{nome:"Mica", idade: 16},
{nome:"lucca", idade: 18},
{nome:"Enzo", idade: 16},
{nome:"Parceiro", idade: 75}

 ];
 
 convidados.forEach( (p) => {
    console.log(`Convidado: ${p}`);
 });
 
