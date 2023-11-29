import React, { useState, useContext } from "react";
import ImageIllustrator from "../../Components/ImageIllustrator/ImageIllustrator";
import logo from "../../assets/images/images/logo-pink.svg";
import { Input, Button } from "../../Components/FormComponents/FormComponent"
import loginImage from "../../assets/images/images/login.svg"
import api from "../../Services/Services";
import "./LoginPage.css";
import { UserContext, userDecodeToken } from "../../context/AuthContext";

const LoginPage = () => {

    const [user, setUser] = useState({ email: "teixeirapaladino921@gmail.com", senha: "" })
    const {userData, setUserData} = useContext(UserContext)//importa os dados globais do usuario

   async function handleSubmit(e) {
        e.preventDefault()

        //validar usuario e senha 
        //tamanho minimo de caracteres: 3
        if (user.email.length >= 3 && user.senha.length >= 3) {
            try {
                const promise = await api.post("/login", {
                    email: user.email,
                    senha: user.senha
                })

                const userFullToken = userDecodeToken(promise.data.token); //decodifica o token vindo do 
                setUserData(userFullToken) //guarda o token globalmente 

                localStorage.setItem("token", JSON.stringify(userFullToken));

            } catch (error) {
                //erro da api, bad request (401) ou erro de conexao
                alert("Verifique os dados e a conexao com a internet")
               
            }
        }

        else{
            alert("Preencha os dados corretamente")
        }
    }

    return (
        <div className="layout-grid-login">
            <div className="login">
                <div className="login__illustration">
                    <div className="login__illustration-rotate"></div>
                    <ImageIllustrator
                        imageRender={loginImage}
                        altText="Imagem de um homem em frente de uma porta de entrada"
                        additionalClass={"login-illustrator"}
                    />
                </div>

                <div className="frm-login">
                    <img src={logo} className="frm-login__logo" alt="" />

                    <form className="frm-login__formbox" onSubmit={handleSubmit}>
                        <Input
                            className="frm-login__entry"
                            type="email"
                            id="login"
                            name="login"
                            required={true}
                            value={user.email}
                            onChange={(e) => {
                                setUser({...user, email: e.target.value.trim()})
                            }}
                            placeholder="Username"
                        />
                        <Input
                            additionalClass={"frm-login__entry"}
                            type="password"
                            id="senha"
                            name="senha"
                            required={true}
                            value={user.senha}
                            manipulationFunction={(e) => {
                                setUser({...user, senha: e.target.value.trim()})
                            }}
                            placeholder="****"
                        />

                        <Button
                            textButton="Login"
                            id="btn-login"
                            name="btn-login"
                            type="submit"
                            additionalClass={"frm-login__button"}
                            // manipulationFunction={(e) => {setUser(e.target.value)}}
                        />

                        <a href="" className="frm-login__link">
                            Esqueceu a senha?
                        </a>

                    </form>
                </div>
            </div>
        </div>
    );
};

export default LoginPage;
