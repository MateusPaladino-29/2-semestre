import React from 'react';
import './FormComponent.css'

export const Input = ({ 
    type,
    id,
    value,
    required,
    additionalClass,
    name,
    placeholder,
    manipulationFunction }) => {

    return (
        <input
            type={type}
            id={id}
            name = {name}
            value={value}
            required={required}
            className={`input-component ${additionalClass}`}
            placeholder={placeholder}
            onChange={manipulationFunction}
            autoComplete='off'
        />
    );
}

export const Button = ({
    type,
    id,
    name,
    additionalClass = "",
    textButton,
    manipulationFunction,
  }) => {
    return <button onClick={manipulationFunction} type={type} name={name} id={id} className={`button-component ${additionalClass}`}>
      {textButton}
    </button>;
  };


  //SELECT
export const Select = ({
  options,
  id,
  name,
  required, 
  additionalClass = "",
  manipulationFunction,
  defaultValue
}) => {
  return (
  <select
    name={name}
    required={required}
    id={id}
    className={`input-component ${additionalClass}`}
    onChange={manipulationFunction}
    value={defaultValue}
  >
    <option  defaultValue hidden>Selecione uma opção</option>

    {options.map((opt) => {
      return(
        <option key = { opt.idTipoEvento} value={opt.idTipoEvento}>

        {opt.titulo}
        
        </option>
      ) 
    })}
  </select>
);
};
