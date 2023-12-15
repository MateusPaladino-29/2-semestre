import React, { useState } from 'react';

const Input = (props) => {

    // const [numero1, setNumero1] = useState();
    return (
        <>
            <input type={props.type}
                placeholder={props.placeholder}
                name={props.name}
                id={props.id}
                value={props.value}
                onChange={props.onChange}
            />
            {/* <span>{props.value}</span> */}
        </>
    );
};

export default Input;