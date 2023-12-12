import React, { useEffect, useState } from 'react';
import Button from '../../components/Button/Button';
import Header from '../../components/Header/Header';
import Input from '../../components/Input/Input';


const TestePage = () => {
    const [count, setCount] = useState(0);
    const [calculation, setCalculation] = useState(50);

    useEffect(() => {
        setCalculation( count * 2);
    }, [count]);

    return(
        <>
            <p>Count: {count}</p>
            <button onClick={() => setCount((c) => c + 1)}>+</button>
            <p>Calculation: {calculation}</p>
        </>
    );

};

export default TestePage;


// const TestePage = () => {
//     const [n1, setN1] = useState(0)
//     const [n2, setN2] = useState(0)
//     const [total, serTotal] = useState()

//     function handleCalcular(e) {
//         e.preventDefault();
//         serTotal(parseFloat(n1) + parseFloat(n2));
        
//     }

//     return (
//         <div>
//             <Header />
//             <h1>Pagina de Poc`s</h1>

//             <h2>Calculator</h2>
//             <form onSubmit={handleCalcular}>
//                 <Input
//                     type="number"
//                     placeholder="Digite o numero"
//                     name="n1"
//                     id="n1"
//                     value={n1}
//                     onChange={(e) => { setN1(e.target.value) }}
//                 />

//                 <br /><br />

//                 <Input
//                     type="number"
//                     placeholder="Digite o numero"
//                     name="n2"
//                     id="n2"
//                     value={n2}
//                     onChange={(e) => { setN2(e.target.value) }}
//                 />

//                 <br /><br />
//                 <Button
//                     textButton="Calcular"
//                     type="submit"
//                 />
//             </form>
           
//             <br />
//             <span> Total : <strong > {total} </strong></span>


//         </div>
//     );
// };

