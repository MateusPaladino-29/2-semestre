import React from 'react';
import "./Header.css"
import {Link} from 'react-router-dom';

const Header = () => {
    return (
        <header>
            <nav>
                <Link to="/">Home</Link>
                <br />
                <Link to="/TipoEventos">TipoEventos</Link>
                <br />
                <Link to="/EventosPage" >EventosPage</Link>
                <br />
                <Link to="/Login">Login</Link>
                <br />
                <Link to="/TestePage">TestePage</Link>
            </nav>
        </header>
    );
};

export default Header;