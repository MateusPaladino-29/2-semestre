import React from 'react';

// import dos componentes de rota 
import { BrowserRouter, Routes, Route } from 'react-router-dom';
// Importar a pagina de rotas

import HomePage from './Pages/HomePage/HomePage';
import Login from './Pages/LoginPage/Login';
import EventoPage from './Pages/EventosPage/EventoPage';
import TipoEventos from './Pages/TipoEventoPage/TipoEventos';
import TestePage from './Pages/TestePage/TestePage';
import Header from './Components/Header/Header';
import Footer from './Components/Footer/Footer';

const Rotas = () => {
    return (
        // Criar a estrutura de rotas 
        <BrowserRouter>
        <Header/>
            <Routes>
                <Route element={<HomePage />} path="/" exact /> 
                <Route element={<Login />} path="/login"  />
                <Route element={<EventoPage />} path="/eventos" />
                <Route element={<TipoEventos />} path="/tipo-eventos"/>
                <Route element={<TestePage />} path="/TestePage"/>
            </Routes>
            <Footer />
        </BrowserRouter>
    );
};

export default Rotas;