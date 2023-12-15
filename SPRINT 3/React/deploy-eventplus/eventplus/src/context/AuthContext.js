// Importa a função jwtDecode do pacote "jwt-decode" e a função createContext do pacote "react"
import { jwtDecode } from "jwt-decode";
import { createContext } from "react";

// Cria um contexto do usuário que será utilizado para compartilhar dados do usuário na aplicação React
export const UserContext = createContext(null);

// Função responsável por decodificar um token JWT e extrair informações específicas
export const userDecodeToken = (theToken) => {
    // Decodifica o token recebido como argumento usando a função jwtDecode
    const decoded = jwtDecode(theToken);

    // Retorna um objeto com informações extraídas do token
    return {
        // Propriedade 'role' contém a função do usuário extraída do token
        role: decoded.role,
        // Propriedade 'nome' contém o nome do usuário extraído do token
        nome: decoded.name,

        userId: decoded.jti,
        // Propriedade 'token' mantém o token original recebido como argumento
        token: theToken


    };
}
