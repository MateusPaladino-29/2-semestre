import React, { useEffect, useState } from 'react';
import MainContent from '../../Components/MainContent/MainContent';
import Banner from '../../Components/Banner/Banner';
import VisionSection from '../../Components/VisionSection/VisionSection';
import ContactSection from '../../Components/ContactSection/ContactSection';
import NextEvent from '../../Components/NextEvent/NextEvent';
import Titulo from '../../Components/Titulo/Titulo';
import Container from '../../Components/Container/Container';
import api from '../../Services/Services';
import { Swiper, SwiperSlide } from 'swiper/react';
// Import Swiper styles
import 'swiper/css'
import 'swiper/css/pagination';
import { Pagination } from 'swiper/modules';
import './HomePage.css'

const HomePage = () => {
    useEffect(() => {
        async function getProximosEventos() {
            try {
                const promise = await api.get("/Evento/ListarProximos");
                console.log(promise.data);
                setNextEVents(promise.data)
            } catch (error) {
               console.log('Deu Ruim na API');
            }
        }

        getProximosEventos();
        console.log("A HOME FOI MONTADA");
    }, [])

    const [nextEvents, setNextEVents] = useState([])

    return (
        <MainContent>
            <Banner />
            <section className=''>
                <Container>
                    <Titulo tituloTexto={"Proximos Eventos"} />
                    <div className='events-box'>
                        <Swiper
                            spaceBetween={50}
                            slidesPerView={1}

                            pagination={{
                                dynamicBullets: true,
                                
                            }}
                            
                            modules={[Pagination]}
                            className="mySwiper"
                        >
                            {
                                nextEvents.map((e) => {
                                    return (
                                        <>
                                            <SwiperSlide>
                                                <NextEvent
                                                    Titulo={e.nomeEvento}
                                                    description={e.descricao}
                                                    eventDate={e.dataEvento}
                                                    idEvento={e.idEvento}
                                                />
                                            </SwiperSlide>
                                        </>
                                    );
                                })
                            }
                        </Swiper>
                    </div>
                </Container>
            </section>
            <VisionSection />
            <ContactSection />
        </MainContent>
    );
};

export default HomePage;