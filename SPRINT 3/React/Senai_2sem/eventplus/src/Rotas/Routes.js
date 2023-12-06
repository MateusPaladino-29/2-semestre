import React from 'react';

// import dos componentes de rota 
import { BrowserRouter, Routes, Route } from 'react-router-dom';
// Importar a pagina de rotas

import HomePage from '../Pages/HomePage/HomePage';
import LoginPage from '../Pages/LoginPage/Login';
import EventosPage from '../Pages/EventosPage/EventoPage';
import TipoEventos from '../Pages/TipoEventoPage/TipoEventos';
import TestePage from '../Pages/TestePage/TestePage';
import Header from '../Components/Header/Header';
import Footer from '../Components/Footer/Footer';
import { PrivateRoute } from './PrivateRoute';

const Rotas = () => {
    return (
        // Criar a estrutura de rotas 
        <div>
            <BrowserRouter>
                <Header />
                <Routes>
                    <Route path="/" element={<HomePage />} exact />

                    <Route path="/login" element={<LoginPage />} />

                    <Route
                        path="/tipo-eventos"
                        element={<PrivateRoute redirectTo='/'>
                            <TipoEventos />
                        </PrivateRoute>}
                    />

                    <Route
                        path={"/Evento"}
                        element={<PrivateRoute   redirectTo='/'>
                            <EventosPage />
                        </PrivateRoute>}
                    />


                </Routes>
                <Footer />
            </BrowserRouter>

        </div>  
    );
};

export default Rotas;