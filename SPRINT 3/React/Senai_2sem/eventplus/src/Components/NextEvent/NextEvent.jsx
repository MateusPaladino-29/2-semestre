import React from 'react';
import Titulo from '../Titulo/Titulo';
import './NextEvent.css'
import { dateFormatDbToView } from '../../Utils/stringFunction';
import { Tooltip } from 'react-tooltip';

const NextEvent = ({ Titulo, description, eventDate, idEvento }) => {
    function conectar(idEvento) {
        alert(`Conectando ao evento: ${idEvento}`)
    }

    return (
        <article className='event-card'>
            <h2 className='event-card__title'>{Titulo}</h2>

            <p className='event-card__description'

                data-tooltip-id={idEvento}
                data-tooltip-content={description}
                data-tooltip-place="top"
            >
                <Tooltip id={idEvento} className="tooltip" />
                {description.substr(0, 16)}...

            </p>


            <p className='event-card__description'>{dateFormatDbToView(eventDate)}</p>

            <a href="" onClick={() => { conectar(idEvento) }} className='event-card__connect-link'>Conectar</a>

        </article>
    );
};

export default NextEvent;