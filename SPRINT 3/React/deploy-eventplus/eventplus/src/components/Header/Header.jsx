import React, { useState } from 'react'; // Importa a biblioteca React e a função useState
import Container from '../Container/Container.jsx'; // Importa o componente Container
import Nav from '../Nav/Nav'; // Importa o componente de navegação Nav
import PerfilUsuario from '../PerfilUsuario/PerfilUsuario'; // Importa o componente de perfil de usuário
import menubar from '../../assets/images/menubar.png'; // Importa a imagem do ícone do menu

import './Header.css'; // Importa o arquivo de estilos CSS para o componente Header

const Header = () => {
    // Define o componente Header
    
    const [exibeNavbar, setExibeNavbar] = useState(false);
    // Define o estado local 'exibeNavbar' e a função 'setExibeNavbar' com o valor inicial 'false'
    // Esse estado controla se o menu de navegação está sendo exibido ou oculto

    return (
        <header className="headerpage">
            {/* Renderiza o cabeçalho da página com a classe CSS 'headerpage' */}
            
            <Container>
                {/* Renderiza o componente Container para envolver o conteúdo */}
                <div className="header-flex">
                    {/* Cria um contêiner flexível para o conteúdo do cabeçalho */}
                    
                    <img
                        src={menubar}
                        alt="Imagem menu de barras. Serve para ativar e exibir ou esconder o menu no smartphone"
                        onClick={() => { setExibeNavbar(true) }}
                        className="headerpage__menubar"
                    />
                    {/* Renderiza uma imagem de ícone de menu que pode ser clicada para ativar a exibição do menu de navegação no smartphone */}
                    
                    <Nav exibeNavbar={exibeNavbar} setExibeNavbar={setExibeNavbar} />
                    {/* Renderiza o componente de navegação 'Nav' e passa o estado 'exibeNavbar' e a função 'setExibeNavbar' como props */}
                    
                    <PerfilUsuario />
                    {/* Renderiza o componente de perfil de usuário */}
                </div>
            </Container>
        </header>
    );
};

export default Header;
// Exporta o componente Header para uso em outros lugares da aplicação
