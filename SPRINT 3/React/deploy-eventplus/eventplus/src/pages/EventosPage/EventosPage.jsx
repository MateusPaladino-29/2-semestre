import React, { useEffect, useState } from 'react';

// Components
import Header from '../../components/Header/Header';
import ImageIllustrator from '../../components/ImageIllustrator/ImageIllustrator';
import Container from '../../components/Container/Container';
import Notification from '../../components/Notification/Notification';
import TableEv from './TableEv/TableEv';
import Titulo from '../../components/Titulo/Titulo';
import MainContext from '../../components/Main/MainContent';
import Spinner from '../../components/Spinner/Spinner'

// Assets and Services
import EventPhoto from '../../assets/images/evento.svg';
import api, { eventsResource, eventsTypeResource } from '../../Services/Service';

// Form Components
import { Button, Input, Select } from '../../components/FormComponents/FormComponents';

const EventosPage = () => {
    // Estados em ordem alfabética
    const [dataEvento, setDataEvento] = useState();
    const [descricao, setDescricao] = useState();
    const [frmEdit, setFrmEdit] = useState(false);
    const [idEventos, setIdEventos] = useState([]);
    const Instituicao = "6aa3a247-56ea-412d-9ccc-41fab9b79515"
    const [idTipoEvento, setIdTipoEvento] = useState();
    const [listTipoEvento, setListTipoEvento] = useState([]); // Uma lista do tipo de evento
    const [nomeEvento, setNomeEvento] = useState();
    const [notifyUser, setNotifyUser] = useState({});
    const [showSpinner, setShowSpinner] = useState(false);
    const [eventos, setEventos] = useState([]);

    useEffect(() => {
        // Função assíncrona que carrega os tipos de eventos
        async function loadEvents() {
            setShowSpinner(true)
            try {
                // Faz uma requisição GET para a API para obter os tipos de eventos
                const retorno = await api.get(eventsResource);

                // Atualiza o estado 'tipoEventos' com os dados retornados da API
                setEventos(retorno.data);

                // Exibe os dados retornados no console para fins de depuração
                console.log(retorno.data);

                const request = await (await api.get(eventsTypeResource)).data;
                setListTipoEvento(request);
            } catch (error) {
                // Se ocorrer um erro ao acessar a API, exibe uma mensagem de erro no console

                notifyError("Erro na API");
            }
            setShowSpinner(false)
        }

        // Chama a função 'loadEvents' ao carregar o componente
        loadEvents();
    }, []);

    async function ApiReload() {
        const searchEvent = await api.get(eventsResource);

        setEventos(searchEvent.data);
    }

    function dePara(request) {
        let arrayOptions = [];
        request.forEach((e) => {
            arrayOptions.push({ value: e.idTipoEvento, text: e.titulo });
        });
        return arrayOptions;
    }

    async function handleSubmit(e) {
        e.preventDefault();

        if (nomeEvento.trim().length < 5) {


            notifyWarning("O Titulo deve ter Mais de 5 Caracteres ")
        }
        else try {
            const retorno = await api.post(eventsResource, {

                "dataEvento": dataEvento,
                "nomeEvento": nomeEvento,
                "descricao": descricao,
                "idTipoEvento": idTipoEvento,
                "idInstituicao": Instituicao
            })

            notifySuccess("Evento Cadastrado Com Sucesso")

            ApiReload();


        } catch (error) {

            notifyError("Nao foi Possivel Cadastrar o Evento")
        }
    }

    async function handleDelete(idElement) {

        if (window.confirm("Deseja Apagar este Evento")) {

            try {
                const retorno = api.delete(`${eventsResource}/${idElement}`)

                console.log((await retorno).status);

                ApiReload();

                notifySuccess("Evento Deletado Com Sucesso");

            } catch (error) {

                notifyError("Nao foi Possivel Deletar e Evento ")
            }

        }


    }

    async function handleUpdate(e) {

        e.preventDefault();

        try {
            await api.put(`${eventsResource}/${idEventos}`, {
                "dataEvento": dataEvento,
                "nomeEvento": nomeEvento,
                "descricao": descricao,
                "idTipoEvento": idTipoEvento,
                "idInstituicao": Instituicao
            });

            notifySuccess("O Evento foi Ataulizado com sucesso")

            ApiReload();

            editActionAbort();
        } catch (error) {
            notifyError("Nao Foi possivel atualizar o Evento")
        }


    }

    async function showUpdate(idElement) {
        setFrmEdit(true)
        setIdEventos(idElement)

        try {
            const retorno = await api.get(eventsResource + "/" + idElement)
            setNomeEvento(retorno.data.nomeEvento);
            setDataEvento(retorno.data.dataEvento.slice(0, 10));
            setDescricao(retorno.data.descricao);
            setIdTipoEvento(retorno.data.idTipoEvento)



        } catch (error) {
            console.log(error);
        }
    }


    function editActionAbort(params) {
        setFrmEdit(false)
        setNomeEvento("")
        setDataEvento("")
        setDescricao("")

    }

    const notifySuccess = (textNote) => {
        setNotifyUser({
            titleNote: "Sucesso",
            textNote,
            imgIcon: 'success',
            imgAlt: 'Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.',
            showMessage: true
        });
    };

    const notifyError = (textNote) => {
        setNotifyUser({
            titleNote: "Erro",
            textNote,
            imgIcon: 'danger',
            imgAlt: 'Imagem de ilustração de erro. Homem segurando um balão com símbolo de X.',
            showMessage: true
        });
    };

    const notifyWarning = (textNote) => {
        setNotifyUser({
            titleNote: "Aviso",
            textNote,
            imgIcon: 'warning',
            imgAlt: 'Imagem de ilustração de aviso. Mulher em frente a um grande ponto de exclamação.',
            showMessage: true
        });
    };


    return (
        <>
            {<Notification {...notifyUser} setNotifyUser={setNotifyUser} />}
            {showSpinner ? <Spinner /> : null}
            <MainContext>

                <Container>
                    <div className='cadastro-evento__box cadastro-evento-section '>

                        <Titulo titleText={"Eventos"} />

                        <ImageIllustrator imageRender={EventPhoto} />
                        <form className='ftipo-evento' onSubmit={frmEdit ? handleUpdate : handleSubmit}>
                            {
                                !frmEdit ? (

                                    // CADASTRAR
                                    <>
                                        <Input
                                            id={"Nome"}
                                            placeholder={"Nome"}
                                            name={"nome"}
                                            type={"text"}
                                            required={"required"}
                                            value={nomeEvento}
                                            manipulationFunction={(e) => { setNomeEvento(e.target.value) }}
                                        />

                                        <Input
                                            id={"Descricao"}
                                            placeholder={"Descricao"}
                                            name={"descricao"}
                                            type={"text"}
                                            required={"required"}
                                            value={descricao}
                                            manipulationFunction={(e) => { setDescricao(e.target.value) }}
                                        />

                                        <Select
                                            id={"TipoEvento"}
                                            name={"tipo evento"}
                                            options={dePara(listTipoEvento)}
                                            defaultValue ={ idTipoEvento}
                                            required={"required"}
                                            manipulationFunction={e => {
                                                setIdTipoEvento(e.target.value)
                                            }}

                                        />

                                        <Input
                                            id={"Data"}
                                            placeholder={"Data"}
                                            name={"data"}
                                            type={"date"}
                                            required={"required"}
                                            value={dataEvento}
                                            manipulationFunction={(e) => { setDataEvento(e.target.value) }}
                                        />

                                        <Button
                                            textButton={"Cadastrar"}
                                            id={"cadastrar"}
                                            name={"cadastrar"}
                                            type={"submit"}

                                        />

                                    </>
                                ) : (
                                    //Tela Edicao 
                                    <>
                                        <Input
                                            id={"Nome"}
                                            placeholder={"Nome"}
                                            name={"nome"}
                                            type={"text"}
                                            required={"required"}
                                            value={nomeEvento}
                                            manipulationFunction={(e) => { setNomeEvento(e.target.value) }}
                                        />

                                        <Input
                                            id={"Descricao"}
                                            placeholder={"Descricao"}
                                            name={"descricao"}
                                            type={"text"}
                                            required={"required"}
                                            value={descricao}
                                            manipulationFunction={(e) => { setDescricao(e.target.value) }}
                                        />

                                        <Select
                                            id={"TipoEvento"}
                                            name={"tipoEvento"}
                                            options={dePara(listTipoEvento)}
                                            required={"required"}
                                            defaultValue={idTipoEvento}
                                            manipulationFunction={e => {
                                                setIdTipoEvento(e.target.value)
                                            }}

                                        />

                                        <Input
                                            id={"Data"}
                                            placeholder={"Data"}
                                            name={"data"}
                                            type={"date"}
                                            required={"required"}
                                            value={dataEvento}
                                            manipulationFunction={(e) => { setDataEvento(e.target.value) }}
                                        />
                                        <div className="buttons-editbox">
                                            <Button
                                                textButton={"Editar"}
                                                id={"Editar"}
                                                name={"Editar"}
                                                type={"submit"}

                                            />

                                            <Button
                                                textButton={"Cancelar"}
                                                id={"cancelar"}
                                                name={"cancelar"}
                                                type={"buttom"}
                                                manipulationFunction={editActionAbort}
                                            />
                                        </div>

                                    </>
                                )
                            }

                        </form>

                    </div>
                </Container>
                <section className='lista-eventos-section'>
                    <Container>
                        <Titulo titleText={"Lista Eventos"} color="white" />
                        <TableEv dados={eventos} fnDelete={handleDelete} fnUpdate={showUpdate} />
                    </Container>
                </section>
            </MainContext>


        </>
    );
};

export default EventosPage;