import React from 'react';
import { Route, BrowserRouter, Routes } from "react-router-dom";
import Header from '../components/Header/Header';
import Footer from '../components/Footer/Footer';

import EventosPage from '../pages/EventosPage/EventosPage';
import HomePage from '../pages/HomePage/HomePage';
import LoginPage from '../pages/LoginPage/LoginPage';
import TipoEventos from '../pages/TipoEventosPage/TipoEventosPage';
import EventosAlunosPage from '../pages/EventosAlunoPage/EventosAlunoPage';
import { PrivateRoute } from './PrivateRoutes';

const routes = () => {
    return (
        <div>
            <BrowserRouter>
            <Header/>
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
                        path={"/eventos"}
                        element={<PrivateRoute redirectTo='/'>
                            <EventosPage />
                        </PrivateRoute>}
                    />

                    <Route
                        path={"/eventos-alunos"}
                        element={<PrivateRoute redirectTo='/'>
                            <EventosAlunosPage/>
                        </PrivateRoute>}
                    />


                </Routes>
                <Footer />
            </BrowserRouter>

        </div>
    );
}

export default routes;