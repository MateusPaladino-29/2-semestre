import React from "react";
import './CardEvento.css'

const CardEvento = (props) => {
    return (
        <div className="card-evento">
            <h3 className="card-evento__titulo">{props.titulo}</h3>
            <p className="card-evento__text">{props.texto}</p>
            <a 
            href="" 
            className={
                props.desabilitar
                ? "card-evento__conection card-evento__conection--disable"
                : "card-evento__conection"
            }
            >
                {props.textoLink}
                {props.desabilitar}
            </a>
        </div>
    );
}

export default CardEvento;