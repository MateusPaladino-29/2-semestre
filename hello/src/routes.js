import React, { useState } from "react";
import { Route, BrowserRouter, Routes } from "react-router-dom";

// Imports dos componentes - PÁGINAS
import HomePage from "./pages/HomePage/HomePage";
import LoginPage from "./pages/LoginPage/LoginPage";
import ProdutoPage from "./pages/ProdutoPage/ProdutoPage";
import NotFoundPage from "./pages/NotFoundPage/NotFoundPage";
import ImportantePage from "./pages/ImportantePage/ImportantePage";
import MeusPedidosPage from "./pages/MeusPedidosPage/MeusPedidosPage";
import NavBar from "./components/NavBar/NavBar";

import { ThemeContext } from "./context/ThemeContext";

// Testar as Rotas
// Context API
// Token
// Login em si

const Rotas = () => {
  const [theme, setTheme] = useState("light")
  const pessoa = "José"
  
  return (
    <BrowserRouter>
      <ThemeContext.Provider value={{ theme , setTheme, pessoa}}>
        <NavBar />
        <Routes>
          <Route element={<HomePage />} path={"/"} exact />
          <Route element={<ProdutoPage />} path={"/produtos"} />
          <Route element={<LoginPage />} path={"/login"} />
          <Route element={<NotFoundPage />} path={"*"} />
          <Route element={<ImportantePage />} path={"/importantes"} />
          <Route element={<MeusPedidosPage />} path={"/meus-pedidos"} />

        </Routes>
      </ThemeContext.Provider>
    </BrowserRouter>
  );
};

export default Rotas;