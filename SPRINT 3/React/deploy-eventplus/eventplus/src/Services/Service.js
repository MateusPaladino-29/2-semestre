/**
 *  Modulo para trabalhar com apis. Disponibiliza as rotas da api bem como o servico com a biblioteca axios
 */
import axios from "axios";


/**
 *  Rota para o recurso eventos
 */
export const eventsResource = '/Evento'

// Rota para login
export const LoginResource = '/login'

// Rota para Home
export const HomeResource = '/'

export const myEventsResource = '/PresencasEvento/ListarMinhas'


export const CommentaryResource = '/ComentariosEvento/BuscarPorIdUsuario'

//Rota para o recurso Listar Presenças Evento
export const presencesEventsResource = 'PresencasEvento'

// Rota para Instituicao
export const IstituicaoResource = '/instituicao'
/**
 *  Rota para o recurso proximos eventos
 */
export const nextEventResource = '/Evento/ListarProximos'

/**
 *  Rota para o recurso tipos eventos
 */
export const eventsTypeResource = '/TiposEvento'


const externalApiUri = `https://eventwebapi-paladino.azurewebsites.net/api`;

const api = axios.create({
    baseURL: externalApiUri
});

export default api;