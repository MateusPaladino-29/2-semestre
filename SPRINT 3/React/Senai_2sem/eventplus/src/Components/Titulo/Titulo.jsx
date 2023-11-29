import React from 'react';
import './Titulo.css';

const Titulo = ({tituloTexto, additionalClass = "", color = ""}) => {
    return (

        <h1 className={`titulo ${additionalClass}`} style={{color: color}}>

            {tituloTexto}
            <hr className='titulo__underscore' style={{borderColor: color}} />
        </h1>
    );
};

export default Titulo;