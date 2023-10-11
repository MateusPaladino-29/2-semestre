function calcular() {
    event.preventDefault();

    let n1 = parseFloat(document.getElementById("numero1").value);
    let n2 = parseFloat(document.getElementById("numero2").value);
    let res;
    let op = document.getElementById("operacao").value;

    if ( isNaN(n1) || isNaN(n2)) {
        alert("Preencha todos os campos")
        return;
    }

    if (op == '+') {
        res = somar(n1, n2)
        console.log(`Resultado: ${somar(n1, n2)}`)
        alert(`Resultado: ${res}`)

    } else if (op == '-') {
        res = subtrair(n1, n2);
        console.log(`Resultado: ${subtrair(n1, n2)}`);
        alert(`Resultado: ${res}`)

    } else if (op == '/') {
        res = dividir(n1, n2);
        console.log(`Resultado: ${dividir(n1, n2)}`);
        alert(`Resultado: ${res}`)

    } else if (op == '*') {
        res = multiplicar(n1, n2);
        console.log(`Resultado: ${multiplicar(n1, n2)}`);
        alert(`Resultado: ${res}`)
        
    } else {
        console.log("Selecione uma operação válida!");
        alert("Selecione uma operação válida!")
    }

    document.getElementById('resultado').innerText = res;

    console.log(n1);
    console.log(n2);
}

function somar(x, y) {
    return (x + y).toFixed(2);
}
function subtrair(x, y) {
    return (x - y).toFixed(2);
}
function dividir(x, y) {
    if (y == 0) {
        return "Impossível dividir por zero!";
    }
    return (x / y).toFixed(2);
}
function multiplicar(x, y) {
    return (x * y).toFixed(2);
}
