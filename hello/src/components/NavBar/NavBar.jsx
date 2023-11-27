import React, { useContext } from 'react';
import { Link } from 'react-router-dom'
import { ThemeContext } from '../../context/ThemeContext';


const NavBar = () => {
    const {theme, setTheme} = useContext(ThemeContext)
    function alterTema() {
        setTheme(theme === 'light' ? 'dark' : 'light')
    }
    return (
        <nav>
            <br />
            <Link to="/">Home</Link> | &nbsp;
            <Link to="/produtos">Produtoss</Link> | &nbsp;
            <Link to="/importantes">Importante</Link> | &nbsp;
            <Link to="/meus-pedidos">Meus Pedidos</Link> | &nbsp;
            <Link to="/login">Login</Link>
            <button onClick={alterTema}>{theme}</button>
        </nav>
    );
};

export default NavBar;