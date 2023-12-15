import React, { useContext } from "react";
import { Link, useNavigate } from "react-router-dom";
import iconeLogout from "../../assets/images/icone-logout.svg";
import { UserContext } from "../../context/AuthContext";
import { LoginResource } from "../../Services/Service";

import "./PerfilUsuario.css";
const PerfilUsuario = () => {


    const { userData, setUserData } = useContext(UserContext)
    const navigate = useNavigate();

    const logout = () => {
        localStorage.removeItem("token");
        setUserData({})
        navigate(LoginResource)

    }

    return (
        <div className="perfil-usuario">
            {userData.nome ? (
                <>
                    <span className="perfil-usuario__menuitem">{userData.nome}</span>

                    <img
                        onClick={logout}
                        title="Deslogar"
                        className="perfil-usuario__icon"
                        src={iconeLogout}
                        alt="imagem ilustrativa de uma porta de saída do usuário "
                    />
                </>
            ) : (
                <Link to={LoginResource} className="perfil-usuario__menuitem">
                    Login
                </Link>
            )}

            {/* <span className="perfil-usuario__menuitem"></span> */}


        </div>
    );
};

export default PerfilUsuario;
