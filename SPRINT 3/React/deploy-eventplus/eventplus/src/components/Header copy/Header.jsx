import React from 'react';
import Container from '../Container/Container.jsx'
import Nav from '../Nav/Nav'
import PerfilUsuario from '../PerfilUsuario/PerfilUsuario'
import menubar from '../../assets/images/menubar.png'

import './Header.css';
const Header = () => {
    return (
        <header className='headerpage'>

            <nav>
                <Link to="/"> Home </Link>
                <br />
                <Link to="/login">Login </Link>
                <br />
                <Link to="/tipo-eventos">Tipo Eventos </Link>
                <br />
                <Link to="/eventos"> Eventos </Link>
                <br />
                <Link to="/testes"> Teste </Link>

            </nav>
            
        </header>

    );
};

export default Header;
