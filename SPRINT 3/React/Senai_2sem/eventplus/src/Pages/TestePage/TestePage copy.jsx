import React, { useState } from 'react';
import Input from "../../Components/Input/Input";
import Botao from '../../Components/Botao/Botao';

const TestePage = () => {
    const[Total, SetTotal] = useState();
    const[N1, SetN1] = useState();
    const[N2, SetN2] = useState();

    function HandleCalcular(e) {
        e.preventDefault()
        SetTotal(parseFloat(N1)+ parseFloat(N2))
    }

    return (
        <form onSubmit={HandleCalcular}>
          
            <Input
            tipo="number"
            id="numero1"
            nome="numero1" 
            dicaCampo="Primeiro Numero"
            valor={N1}
            fnAltera={SetN1}
            />

            <Input
            tipo="number"
            id="numero2"
            nome="numero2"
            dicaCampo="Segundo Numero"
            valor={N2}
            fnAltera={SetN2}
            />

            <Botao
            tipo="submit"
            textoBotao="Somar" />

            <p>Resultado: <strong>{Total}</strong></p>
            
        </form>
    );
};

export default TestePage;