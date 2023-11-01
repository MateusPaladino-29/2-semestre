const url = "http://localhost:3000/Contatos"

async function Cadastrar(e) {
    e.preventDefault();

    const cep = document.getElementById("cep").value;
    const bairro = document.getElementById("bairro").value;
    const cidade = document.getElementById("cidade").value;
    const uf = document.getElementById("UF").value;
    const rua = document.getElementById("rua").value;
    const complemento = document.getElementById("complemento").value; 
    const numero = document.getElementById("numero").value; 
    const nome = document.getElementById("nome").value; 
    const sobrenome = document.getElementById("sobrenome").value;
    const email = document.getElementById("email").value;
    const pais = document.getElementById("pais").value;
    const ddd = document.getElementById("ddd").value; 
    const telefone = document.getElementById("telefone").value;
    const anotacoes = document.getElementById("anotacoes").value; 

    const objDados = { cep, bairro, cidade, uf, rua, complemento, numero, nome, sobrenome, email, pais, ddd, telefone, anotacoes }

    try {
        const promise = await fetch(url, {
            body: JSON.stringify(objDados),
            headers: { "Content-Type": "application/json" },
            method: "post"
        });
        const retorno = await promise.json();
        console.log(retorno);

    } catch (error) {
        alert(`Deu Ruim papai`)
    }
}


async function ChamarApi() {
    console.clear();
    event.preventDefault();

    const cep = document.getElementById("cep").value;
    const url = `https://viacep.com.br/ws/${cep}/json/`

    try {
        const promise = await fetch(url);
        const dados = await promise.json();

        ExibeDados(dados)
        console.log(dados);




    } catch (error) {
        console.log(`Deu ruim na Api`);

        alert(`Deu Ruim papai`)
        LimpaDados()


    }


    function ExibeDados(dados) {

        document.getElementById("bairro").value = dados.bairro;
        document.getElementById("cidade").value = dados.localidade;
        document.getElementById("UF").value = dados.uf;
        document.getElementById("rua").value = dados.logradouro;
        // document.getElementById("complemento").value = dados.complemento;
        // document.getElementById("numero").value = dados.numero;
        // document.getElementById("nome").value = dados.nome;
        // document.getElementById("sobrenome").value = dados.sobrenome;
        // document.getElementById("email").value = dados.email;
        // document.getElementById("pais").value = dados.email;
        document.getElementById("ddd").value = dados.ddd;
        // document.getElementById("telefone").value = dados.telefone;
        // document.getElementById("anotacoes").value = dados.anotacoes;


    }

    function LimpaDados() {
        document.getElementById("bairro").value = "..."
        document.getElementById("rua").value = "..."
        document.getElementById("cidade").value = "..."
        document.getElementById("UF").value = "..."
        document.getElementById("complemento").value = "..."
        document.getElementById("numero").value = "..."
        document.getElementById("nome").value = "..."
        document.getElementById("sobrenome").value = "..."
        document.getElementById("email").value = "..."
        document.getElementById("pais").value = "..."
        document.getElementById("ddd").value = "..."
        document.getElementById("telefone").value = "..."
        document.getElementById("anotacoes").value = "..."

    }
};