import Titulo from "./components/Titulo/Titulo"
import CardEvento from "./components/CardEvento/CardEvento";



import "./App.css";
import Contador from "./components/Contador/Contador"
import Rotas from "./routes";

function App() {
  // Criar as propriedades titulo, texto, textoLink
  // passar as propriedades em cada um dios 3 componentes abaixo.
  return (
    <div className="App">
      <Rotas />
    </div>
  );
}

export default App;