// Importa o hook 'useState' do React
import { useEffect, useState } from 'react';

// Importa o contexto 'UserContext' do arquivo './context/AuthContext'
import { UserContext } from './context/AuthContext';

// Importa o componente 'Rotas' que contém as rotas da aplicação
import Rotas from './routes/routes';

// Função principal App que representa a aplicação
function App() {
  // Define um estado 'userData' e uma função 'setUserData' para atualizá-lo
  const [userData, setUserData] = useState({});
  

  useEffect(() => {
    const token = localStorage.getItem("token")
    setUserData(token === null ? {} : JSON.parse(token))
  }, [])

  return (
    <div className="App">
      {/* 
        Provedor do contexto 'UserContext' que envolve o componente 'Rotas'.
        Passa o estado 'userData' e a função 'setUserData' como valor para o contexto.
      */}
      <UserContext.Provider value={{ userData, setUserData }}>
        {/* Renderiza o componente 'Rotas', que controla as rotas da aplicação */}
        <Rotas />
      </UserContext.Provider>
    </div>
  );
}

export default App;
