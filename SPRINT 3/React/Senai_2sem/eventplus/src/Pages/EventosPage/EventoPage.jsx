import React, { useState, useEffect } from 'react';
import MainContent from '../../Components/MainContent/MainContent';
import Titulo from '../../Components/Titulo/Titulo';
import Container from '../../Components/Container/Container';
import { Input, Button, Select } from '../../Components/FormComponents/FormComponent';
import api from "../../Services/Services";
import TableEv from './TableEv/TableEv';
import ImageIllustrator from '../../Components/ImageIllustrator/ImageIllustrator';
import eventTypeImage from "../../assets/images/images/evento.svg"
import Notification from "../../Components/Notification/Notification";
// import Spinner from "../../Components/Spinner/Spinner"

import './EventoPage.css';

const EventoPage = () => {

    const [nomeEvento, setNomeEvento] = useState("");

    const [listTipoEvento, setListTipoEvento] = useState([]);

    const [data, setData] = useState("");

    const [descricao, setDescricao] = useState("");

    const [tipoEventos, setTipoEventos] = useState([]);

    const [evento, setEvento] = useState([]);

    const [idEvento, setIdEvento] = useState("")

    const [idTipoEvento, setIdTipoEvento] = useState("")

    const [titulo, setTitulo] = useState("")

    const [frmEdit, setFrmEdit] = useState(false); //TIpo de dados bool

    const [showSpinner, setShowSpinner] = useState(true)

    const [notifyUser, setNotifyUser] = useState({})

    const constituicao = "418315f9-4217-4f03-b305-f7ac36082010"




    async function handleSubmit(e) {
        e.preventDefault();
        // parar o submit do formulário
        // validar pelo menos 3 caracteres
        //chamar a api

        if (nomeEvento.trim().length < 3) {
            alert("Digite pelo menos 3 caracteres");
        }
        //chamar a api
        try {
            const retorno = await api.post("/Evento",
                {
                    "nomeEvento": nomeEvento,
                    "descricao": descricao,
                    "tipoEventos": tipoEventos,
                    "data": data,
                    "idTipoEvento": idTipoEvento,
                    "idInstituicao": constituicao
                });

            setNotifyUser({
                titleNote: "Sucesso",
                textNote: `Cadastrado com sucesso!`,
                imgIcon: "success",
                imgAlt:
                    "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
                showMessage: true,
            });

            console.log(retorno.data)

        } catch (error) {
            console.error(error + "Erro ao cadastrar tipo de evento")
        }
        //limpar o formulário
        setNomeEvento("");
    }


    useEffect(() => {
        async function getTitulos() {
            setShowSpinner(true)
            try {
                const promise = await api.get(`/Evento`)
                console.log(promise.data);
                setEvento(promise.data)

                const request = await (await api.get(`/TiposEvento`)).data

                setListTipoEvento(request)

            } catch (error) {
                console.log(`Erro ao Listar Tipo de Eventos ${error}`);
            }
            setShowSpinner(false)
        }

        getTitulos();
    }, [evento]);






    async function handleDelete(id) {
        try {
            const promise = await api.delete(`/Evento/${id}`)
            setNotifyUser({
                titleNote: "Sucesso",
                textNote: `Deletado com sucesso!`,
                imgIcon: "success",
                imgAlt:
                    "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
                showMessage: true,
            });
            console.log(promise.data);
        } catch (error) {
            console.log(`Erro ao deletar Evento ${error}`);
        }
    }

    async function editActionAbort() {
        setFrmEdit(false)
        setNomeEvento("")
        setIdTipoEvento(null)
    }

    async function handleUpdate(e) {
        e.preventDefault()
        try {
            const promise = await api.put(`/Evento${frmEdit.idEvento}`, {
                "nomeEvento": nomeEvento,
                "descricao": descricao,
                "tipoEventos": tipoEventos,
                "data": data,
            });
            setNotifyUser({
                titleNote: "Sucesso",
                textNote: `Atualizado com sucesso!`,
                imgIcon: "success",
                imgAlt:
                    "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
                showMessage: true,
            });

            editActionAbort()

            console.log(promise.data);
            setNomeEvento("")
            setDescricao("")
            setTipoEventos("")
            setData("")
            setFrmEdit(false)


        } catch (error) {
            console.log(`Erro ao Atualizar dados: ${error}`);
        }
    }


    async function showUpdateForm(evento) {
        const retorno = await api.get(EventSource + "/" + evento)
        setFrmEdit(true)
        // setIdEvento()
        setNomeEvento(retorno.data.nomeEvento)
        setDescricao(retorno.data.descricao)
        setTipoEventos(retorno.data.tipoEventos)
        setData(retorno.data.data)
    }

    return (
        <MainContent>
            <Notification {...notifyUser} setNotifyUser={setNotifyUser} />
            {/* {showSpinner ? <Spinner /> : null} */}
            <section className="cadastro-evento-section">
                <Container>
                    <div className="cadastro-evento__box">
                        <Titulo
                            tituloTexto={"Página de Eventos"}
                            additionalClass="margem-acima"
                        />

                        <ImageIllustrator alterText=">>>>" imageRender={eventTypeImage} />


                        <form
                            className="ftipo-evento"
                            onSubmit={frmEdit ? handleUpdate : handleSubmit}
                            action=""
                        >
                            {!frmEdit ? (
                                <>


                                    <Input
                                        id="nome"
                                        placeholder="Nome"
                                        type="text"
                                        name="nome "
                                        value={nomeEvento}
                                        required
                                        manipulationFunction={(e) => {
                                            setNomeEvento(e.target.value);
                                        }}
                                    />
                                    <Input
                                        id="descricao"
                                        placeholder="Descrição"
                                        type="text"
                                        name="descricao"
                                        value={descricao}
                                        required
                                        manipulationFunction={(e) => {
                                            setDescricao(e.target.value);
                                        }}
                                    />


                                    <Select
                                        id="tipoEvento"
                                        name="tipo Evento"
                                        required="required"
                                        options={listTipoEvento}
                                        manipulationFunction={e => {
                                            setIdTipoEvento(e.target.value)
                                        }}
                                    />

                                    <Input
                                        id="data"
                                        placeholder="Data Evento"
                                        type="date"
                                        name="data"
                                        value={data}
                                        required
                                        manipulationFunction={(e) => {
                                            setData(e.target.value);
                                        }}
                                    />
                                    <Button
                                        id="cadastrar"
                                        type="submit"
                                        name="cadastrar"
                                        textButton="Cadastrar"
                                    />

                                </>
                            ) : (
                                <>
                                    <p>Tela de Edição</p>
                                    <Input
                                        id="nome"
                                        placeholder="Nome"
                                        type="text"
                                        name="nome"
                                        value={frmEdit.nomeEvento}
                                        required
                                        manipulationFunction={(e) => {
                                            setNomeEvento(e.target.value);
                                        }}
                                    />
                                    <Input
                                        id="descricao"
                                        placeholder="Descricao"
                                        type="text"
                                        name="descricao"
                                        value={frmEdit.descricao}
                                        required
                                        manipulationFunction={(e) => {
                                            setDescricao(e.target.value);
                                        }}
                                    />

                                    <Input
                                        id="data"
                                        placeholder="Data Evento"
                                        type="date"
                                        name="data"
                                        value={frmEdit.data}
                                        required
                                        manipulationFunction={(e) => {
                                            setData(e.target.value);
                                        }}
                                    />

                                    <div className="buttons-editbox">


                                        <Button
                                            id="editar"
                                            type="submit"
                                            name="editar"

                                            textButton="Editar"
                                        />
                                        <Button
                                            id="cancelar"
                                            type="reset" manipulationFunction={editActionAbort}
                                            name="cancelar"
                                            textButton="Cancelar"
                                            additionalClass="button-component--middle"
                                        />
                                    </div>

                                </>
                            )}
                        </form>
                    </div>
                </Container>
            </section>

            <section className="lista-eventos-section">
                <Container>
                    <Titulo tituloTexto={"Lista de Eventos"} color="white" />
                    <TableEv
                        dados={evento}
                        fnUpdate={showUpdateForm}
                        fnDelete={handleDelete}
                    />
                </Container>
            </section>

            {/* {Listagem de tipo de eventos} */}
        </MainContent>
    );
};

export default EventoPage;


