const urlLocal = "http://localhost:3000/Contatos"
async function Cadastrar(e) {
    e.preventDefault();

   const document.getElementById("bairro").value = dados.bairro;
   const document.getElementById("cidade").value = dados.localidade;
   const  document.getElementById("UF").value = dados.uf;
   const document.getElementById("rua").value = dados.logradouro;
   const document.getElementById("complemento").value = dados.complemento;
   const document.getElementById("numero").value = dados.numero;
   const  document.getElementById("nome").value = dados.nome;
   const document.getElementById("sobrenome").value = dados.sobrenome;
   const document.getElementById("email").value = dados.email;
   const document.getElementById("pais").value = dados.;
   const document.getElementById("ddd").value = dados.ddd;
   const document.getElementById("telefone").value = dados.telefone;
   const document.getElementById("anotacoes").value = dados.anotacoes

    const objDados = { cep, bairro, cidade, UF, rua, complemento, numero, nome, sobrenome, email, pais, ddd, telefone, anotacoes }

    try {
        const promise = await fetch(urlLocal, {
            body: JSON.stringify(objDados),
            headers: { "Content-Type": "application/json" },
            method: "post"
        });
        const retorno = promise.json();
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