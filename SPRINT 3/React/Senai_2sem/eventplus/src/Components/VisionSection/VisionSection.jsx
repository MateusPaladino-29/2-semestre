import React from 'react';
import Titulo from '../Titulo/Titulo';
import './VisionSection.css'

const VisionSection = () => {
    return (
        <section className='vision'>
            <div className="vision__box">
                <Titulo 
                tituloTexto={"Visao"}
                color="white"
                additionalClass='vision__title'
                />

                <p className='vision__text'>Lorem ipsum dolor sit, amet consectetur adipisicing elit. Provident veritatis neque quam, sint perspiciatis illo reiciendis vitae dicta pariatur a exercitationem aperiam fugit minus aut assumenda quidem? Nam, aut doloribus.</p>
            </div>
        </section>
    );
};

export default VisionSection;