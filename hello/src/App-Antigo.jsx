import './App.css';
import Titulo from './components/Titulo/Titulo'
import CardEvento from './components/CardEvento/CardEvento';

function App() {

// CRIAR O COMPONENTE CardEvento
// CRIAR O CSS DO COMPONENTE
// EXIBIR COMPONENTE NO APP.JS

// ALTERAR O COMPONENTE PARA RECEBER AS PROPS: titulo, texto, textoLink
// EXIBIR 3 COMPONENTES DO CardEvento

  return (
    <div className="App">
      <h1>Hello React</h1>
      {/* <Titulo texto="Eduardo"/> */}
      <CardEvento 
      titulo="SQL Server"
      texto="Mão na mesa com pão frances"
      textoLink="To com fome"
      desabilitar
      />
      <CardEvento 
      titulo="JavaScript"
      texto="Programando js"
      textoLink="Abuu"
      />
      <CardEvento 
      titulo="SQL Server"
      texto="Mão na mesa com pão frances"
      textoLink="To com fome"
      />
    </div>
  );
}

export default App;
