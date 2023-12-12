import React from 'react';
import './FormComponents.css'

export const Input = ({ type, id, value, required, additionalClass = "", name, placeholder, manipulationFunction }) => {
    return (
        <input
            type={type} id={id}
            value={value} required={required ? "required" : ""}
            className={`input-component ${additionalClass}`} name={name}
            placeholder={placeholder} onChange={manipulationFunction}
            autoComplete='off'

        />
    )
}

export const Label = (htmlFor, labelText) => {

    return <label htmlFor={htmlFor}> {labelText}</label>
}

export const Button = ({ textButton, name, id, type, manipulationFunction, additionalClass = "" }) => {
    return (
        <button id={id} name={name} type={type} className={`button-component ${additionalClass}`} onClick={manipulationFunction}>
            {textButton}
        </button>
    )
}

export const Select = ({ options, name, id, manipulationFunction, additionalClass = "", required, defaultValue }) => {
    return (
        <select
            name={name} 
            id={id} 
            required={required}
            className={`input-component ${additionalClass}`}
            value={defaultValue} 
            onChange={manipulationFunction}

        >


            <option defaultValue  hidden >Selecione o tipo do evento </option>
            {options.map((op) => {
                return (
                    <option key={Math.random()} value ={op.value}>

                        {op.text}
                        
                    </option>
                )

            })}
        </select>
    )
}


