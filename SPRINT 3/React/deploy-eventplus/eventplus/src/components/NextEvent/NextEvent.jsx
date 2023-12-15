import React from 'react';
import './NextEvent.css';
import { dateFormatDbToView } from '../../Utils/stringFunctions';
import { Tooltip } from 'react-tooltip';

const NextEvent = ({title, decription, eventDate, idEvent}) => {
    function conectar(idEvent){
        alert(`Chamar recurso para conectar: ${idEvent}`)
    }

    return (
        <article className='event-card'>
            <h2 className='event-card__title'>{title}</h2>

            <p 
                className='event-card__description'
                data-tooltip-id={idEvent}
                data-tooltip-content={decription}
                data-tooltip-place="top"
            >
                <Tooltip id={idEvent} className="tooltip" />
                {decription.substr(0, 15)}...
            </p>

            <p className='event-card__description'>{dateFormatDbToView(eventDate)}</p> 
            
            {/* {dateFormatDbToView(eventDate)}    FORMA CHAMANDO FUNCAO CRIADA EM Utils/stringFunctions.js PARA CONVERTER A DATA, NomeFuncao: dateFormatDbToView */}
            
            {/* <p className='event-card__description'>{new Date(eventDate).toLocaleDateString()}</p> */} {/*new Date(eventDate).toLocaleDateString()   FORMA COM FUNCAO NATIVA JS MELHOR PARA FAZER */}

            <a onClick={() => conectar(idEvent)} href="" className='event-card__connect-link'>Conectar</a>
        </article>
    );
};

export default NextEvent;