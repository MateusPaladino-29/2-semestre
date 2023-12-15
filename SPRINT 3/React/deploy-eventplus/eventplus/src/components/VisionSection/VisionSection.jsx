import React from 'react';
import Title from '../Titulo/Titulo';
import "./VisionSection.css"
const VisionSection = () => {
    return (
       <section className='vision'>
        <div className="vision__box">

        <Title titleText ={"Visao"} color ='white' className ="vision__title"/>
        
        <p className='vision__text'>Lorem, ipsum dolor sit amet consectetur adipisicing elit. Provident ducimus quisquam nostrum, tempora deleniti, quasi aspernatur, odit quia culpa amet numquam! Provident, libero aliquid necessitatibus quas molestias quasi expedita ad?</p>

        </div>
       </section>
    );
};

export default VisionSection;