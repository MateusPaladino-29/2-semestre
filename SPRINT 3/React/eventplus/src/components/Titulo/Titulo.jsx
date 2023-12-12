import React from 'react'; // Importa a biblioteca React
import './Titulo.css'; // Importa o arquivo de estilos CSS para o componente Titulo

// Define o componente Titulo com propriedades titleText, color e className
const Titulo = ({ titleText, color = "", className = "" }) => {
    return (
        <h1 className={`title ${className}`} style={{ color: color }}>
            {/* Renderiza o título com a classe "title" e a cor personalizada se fornecida nas props */}
            {titleText}

            <hr className="title__underscore"
                style={color !== "" ? { borderColor: color } : {}}
            />
            {/* Renderiza uma linha de sublinhado opcional com a cor personalizada se fornecida nas props */}
        </h1>
    );
};

export default Titulo; // Exporta o componente Titulo para uso em outros lugares da aplicação
