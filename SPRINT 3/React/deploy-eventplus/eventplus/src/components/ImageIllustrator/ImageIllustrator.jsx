import React from 'react';
import './ImageIllustrator.css';
import imageDefault from '../../assets/images/default-image.jpeg'

const ImageIllustrator = ({altText, imageRender = imageDefault, additionalClass}) => {

    return (
        <figure className='illustrator-box'>
            <img 
            src={imageRender} 
            alt={altText} 
            className={`illustrator-box__image ${additionalClass}`}
            />
        </figure>
    );
};

export default ImageIllustrator;