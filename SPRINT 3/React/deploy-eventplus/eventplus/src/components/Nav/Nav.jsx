import React, { useContext } from 'react';

import logoMobile from '../../assets/images/logo-white.svg' // Importa a imagem do logotipo para telas móveis
import logoDesktop from '../../assets/images/logo-pink.svg' // Importa a imagem do logotipo para telas de desktop
import { Link } from 'react-router-dom'; // Importa o componente Link do react-router-dom

import './Nav.css'; // Importa o arquivo de estilos CSS para o componente Nav
import { UserContext } from '../../context/AuthContext';

const Nav = ({ exibeNavbar, setExibeNavbar }) => {

    const { userData } = useContext(UserContext);

    return (


        <nav className={`navbar ${exibeNavbar ? "exibeNavbar" : ""}`}>
            {/* Renderiza a barra de navegação, a classe CSS 'exibeNavbar' é adicionada se exibeNavbar for verdadeiro */}

            <span onClick={() => { setExibeNavbar(false) }} className='navbar__close'> X </span>
            {/* Renderiza um botão 'X' para fechar a barra de navegação ao ser clicado */}

            <Link to="/" className='eventlogo'>
                <img
                    className='eventlogo__logo-image'
                    src={window.innerWidth >= 992 ? logoDesktop : logoMobile}
                    alt="Event Plus Logo"
                />
            </Link>
            {/* Renderiza um link para a página inicial, contendo o logotipo, cuja imagem muda com base na largura da janela */}

            <div className='navbar__items-box'>
                {/* Renderiza uma caixa que contém links para diferentes páginas */}

                <Link to="/" className='navbar__item'>Home</Link> {/* Link para a página inicial */}

                {userData.nome && userData.role === "Admin" ? (
                    <>
                        <Link to="/tipo-eventos" className='navbar__item'>Tipos de Evento</Link> {/* Link para a página de tipos de evento */}
                        <Link to="/eventos" className='navbar__item'>Eventos</Link> {/* Link para a página de eventos */}
                    </>
                ) : userData.nome && userData.role === "Comum" ? (
                

                    <Link to="/eventos-alunos" className='navbar__item'>Eventos Alunos</Link> /* Link para a página de eventos */
                ): null}

                {/* <Link to="/login" className='navbar__item'>Login</Link> Link para a página de login */}
            </div>
        </nav>
    );
};

export default Nav; // Exporta o componente Nav para uso em outros lugares da aplicação
