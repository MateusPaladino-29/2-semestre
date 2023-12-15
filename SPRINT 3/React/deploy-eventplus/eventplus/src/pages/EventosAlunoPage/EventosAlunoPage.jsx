import React, { useContext, useEffect, useState } from "react";

import Header from "../../components/Header/Header";
import MainContent from "../../components/Main/MainContent";
import Title from "../../components/Titulo/Titulo";
import Table from "./TableEva/TableEva";
import Container from "../../components/Container/Container";
import { Select } from "../../components/FormComponents/FormComponents";
import Spinner from "../../components/Spinner/Spinner";
import Modal from "../../components/Modal/Modal";
import api, { CommentaryResource, eventsResource, myEventsResource, presencesEventsResource } from "../../Services/Service";
import TipoEventos from "../TipoEventosPage/TipoEventosPage";
import { UserContext } from "../../context/AuthContext";
import { clear } from "@testing-library/user-event/dist/clear";
import "./EventosAlunoPage.css";

const EventosAlunoPage = () => {
  // state do menu mobile
  const [exibeNavbar, setExibeNavbar] = useState(false);
  const [eventos, setEventos] = useState([]);
  // select mocado
  const [quaisEventos, setQuaisEventos] = useState([
    { value: 1, text: "Todos os eventos" },
    { value: 2, text: "Meus eventos" },
  ]);

  const [tipoEvento, setTipoEvento] = useState(""); //código do tipo do Evento escolhido
  const [showSpinner, setShowSpinner] = useState(false);
  const [showModal, setShowModal] = useState(false);
  // recupera os dados globais do usuário
  const { userData, setUserData } = useContext(UserContext);
  const { comentario, setComentario } = useState("")
  // console.log(userData.data);

  useEffect(() => {

    loadEventsType()
  }, [tipoEvento, userData.userId]);

  async function loadEventsType() {
    // setShowSpinner(true)
    if (tipoEvento === "1") { //todos os eventos (Evento)

      try {

        const todosEventos = await api.get(eventsResource)

        const retornoEventos = await api.get(`${myEventsResource}/${userData.userId}`)

        const eventosMarcados = verificaPresenca(todosEventos.data, retornoEventos.data);

        setEventos(eventosMarcados)


        // console.log("Todos os eventos");
        // console.log(todosEventos.data);
        // console.log("Meus Eventos");
        // console.log(retornoEventos.data);
        // console.log("Eventos marcados");
        // console.log(eventosMarcados);

      } catch (error) { //coclocar o notification

        alert(`Erro na API ${error}`)
      }

    } else if (tipoEvento === "2") {

      try {
        const retorno = await api.get(`${myEventsResource}/${userData.userId}`)

        const arrEventos = [];
        retorno.data.forEach(e => {
          arrEventos.push({ ...e.evento, situacao: e.situacao, idPresencaEvento: e.idPresencaEvento });
        });

        setEventos(arrEventos);
      }
      catch (error) {
        alert(`Erro na API ${error}`)
      }

    } else {
      setEventos([])
    }
    // setShowSpinner(false)
  }

  const verificaPresenca = (arrAllEvents, eventsUser) => {

    for (let x = 0; x < arrAllEvents.length; x++) { //para vada evento procurado 

      for (let i = 0; i < eventsUser.length; i++) { //procurar a correr

        if (arrAllEvents[x].idEvento === eventsUser[i].evento.idEvento) {

          arrAllEvents[x].situacao = true;

          arrAllEvents[x].idPresencaEvento = eventsUser[i].idPresencaEvento;

          // console.log("A condição está aceitando");

          break; //paro de procurar pata o evento principal atual
        }
      }
    }

    // console.log("AAAAAAAAAAAAAA");
    // console.log(arrAllEvents);
    //retorna todos os eventos marcados com a presenca do usuario
    return arrAllEvents;
  }


  // toggle meus eventos ou todos os eventos
  function myEvents(tpEvent) {
    setTipoEvento(tpEvent);
  }

  // async function loadMyCommentary(idComentary) {
  //   return "????";
  // }

  const showHideModal = (IdEvento) => {
    setShowModal(showModal ? false : true);
    setUserData({ ...userData, idEvento: IdEvento})
  };

  //ler o comentario
  const loadMyCommentary = async (IdEvento) => {

    const promise = await api.get(`${CommentaryResource}?IdUsuario=${userData.userId}&IdEvento=${IdEvento}`)
  const data = promise.data;
  console.log(data);
console.log(`usuario${userData.userId}`);
console.log(IdEvento);
    
    // console.log(promise.data.Descricao);

    // setComentario(promise.data.Descricao);
  }



  //Post um comentario
  const posMyCommentary = async (IdEvento, comentary__text, Situacao) => {
    try {
      const promise = await api.post(CommentaryResource, {
        "Descrição": comentary__text,
        "Exibe": Situacao,
        "IdEvento": IdEvento,
      })

      console.log(promise.data);

    } catch (error) {

    }
  }


  //remove o comentario - delete
  const commentaryRemove = () => {
    alert("Remover o comentário");
  };



  async function handleConnect(eventId, whatTheFunction, presencaId = null) {
    if (whatTheFunction === "connect") {

      try {
        const promise = await api.post(presencesEventsResource, {
          situacao: true,
          idUsuario: userData.userId,
          idEvento: eventId
        }

        )

        if (promise.status === 201) {
          loadEventsType()
          alert("Presença confirmada, parabens")
        }

        const todosEventos = await api.get(eventsResource);
        setEventos(todosEventos.data)
        loadEventsType()

      } catch (error) {

        alert("Desenvolver a função conectar evento" + eventId);
        return;

      }

      return;

    }
    try {

      const unconnect = await api.delete(`${presencesEventsResource}/${presencaId}`)
      if (unconnect.status === 204) {

        const todosEventos = await api.get(eventsResource);
        setEventos(todosEventos.data)

      }

      loadEventsType()
      alert("Desconectado do Evento");

    } catch (error) {
    }
  }
  return (
    <>
      {/* <Header exibeNavbar={exibeNavbar} setExibeNavbar={setExibeNavbar} /> */}

      <MainContent>
        <Container>
          <Title titleText={"Eventos"} className="custom-title" />

          <Select
            id="id-tipo-evento"
            name="tipo-evento"
            required={true}
            options={quaisEventos} // aqui o array dos tipos
            manipulationFunction={(e) => {
              myEvents(e.target.value)
            }} // aqui só a variável state
            defaultValue={tipoEvento}
            additionalClass="select-tp-evento"
          />
          <Table
            dados={eventos}
            fnConnect={handleConnect}
            fnShowModal={() => {
              showHideModal();
            }}
          />
        </Container>
      </MainContent>

      {/* SPINNER -Feito com position */}
      {showSpinner ? <Spinner /> : null}

      {showModal ? (
        <Modal
          userId={userData.userId}
          showHideModal={showHideModal}
          fnGet={loadMyCommentary}
          fnPost={posMyCommentary}
          fnDelete={commentaryRemove}
          comentaryText={comentario}
        />
      ) : null}
    </>
  );
};

export default EventosAlunoPage;
