import React, { useState } from 'react';
import "./Header.css"
import Container from "../Container/Container"
import PerfilUsuario from "../PerfilUsuario/PerfilUsuario"
import Nav from "../Nav/Nav"
import menubar from "../../assets/images/images/menubar.png"


const Header = () => {
    const [exibeNavbar, setExibeNavbar] = useState(false)
    console.log(`Exibe a NavBar? ${exibeNavbar}`);
    return (
        <header className="headerpage">
            <Container>
                <div className="header-flex">

                    <img src={menubar}
                        className='headerpage__menubar'
                        alt="Imagem menu de barras. Serve para exibir ou esconder o menu no smartphone"
                        onClick={() => { setExibeNavbar(true) }}
                    />

                    <Nav
                        setExibeNavbar={setExibeNavbar}
                        exibeNavbar={exibeNavbar}
                    />

                    <PerfilUsuario />

                </div>
            </Container>
        </header>
    );
};

export default Header;