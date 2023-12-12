import React, { useEffect, useState } from 'react';
import './HomePage.css';
import Header from '../../components/Header/Header';
import Title from '../../components/Titulo/Titulo';
import Banner from '../../components/Banner/Banner';
import MainContent from '../../components/Main/MainContent'
import VisionSection from '../../components/VisionSection/VisionSection';
import ContactSection from '../../components/ContactSection/ContactSection';
import Container from '../../components/Container/Container';
import NextEvent from '../../components/NextEvent/NextEvent';

import api from '../../Services/Service';
import { nextEventResource } from '../../Services/Service';

const HomePage = () => {

    const [nextEvents, setNextEvents] = useState([]); //dados mocados

    useEffect(() => {
        async function getNextEvents() {
            try {
                const promise = await api.get(`${nextEventResource}`);
                const dados = await promise.data;

                // Caso de erro olhar na API se ela esta em HTTP ou HTTPS
                setNextEvents(dados)//Atualiza o state
            } catch (error) {
                
                alert("oia, deu erro aqui viu")
            }
        }


        getNextEvents();//roda a funcao
    },[]);

    return (
        <div>
          
            {/* <Title titleText={"Home Page"} className="margem_acima" /> */}
            <MainContent>

            <Banner />

            {/* PROXIMOS EVENTOS */}

                <section className='proximos-eventos'>
                    <Container>
                        
                        <Title titleText={"Proximos Eventos"}/>

                        <div className='events-box'>

                            {
                                nextEvents.map((e) => {
                                    return (
                                    <NextEvent 
                                    key={e.idEvento}
                                    title={e.nomeEvento}
                                    decription={e.descricao}
                                    eventDate={e.dataEvento}
                                    idEvent ={e.idEvento}
                                    />
                                    );
                                })
                            }

                        </div>

                    </Container>
                </section>

                <VisionSection />

                <ContactSection />

            </MainContent>

        </div>
    );
};

export default HomePage;