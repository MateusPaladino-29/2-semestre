import React, { useState } from 'react';

const Input = (props) => {
    
    return (
        <div>
            <input 
            type={props.tipo} 
            id={props.id} 
            name={props.nome} 
            placeholder={props.dicaCampo}
            value={props.valor}
            onChange={(e)=>{
            props.fnAltera(e.target.value)
            }}
            />
            <span>{props.valor}</span>
        </div>
    );
};

export default Input;