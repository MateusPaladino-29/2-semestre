import React, { useEffect, useState } from "react";
import Titulo from "./../../Components/Titulo/Titulo";
import MainContent from "./../../Components/MainContent/MainContent";
import ImageIllustrator from "../../Components/ImageIllustrator/ImageIllustrator";
import Container from "../../Components/Container/Container";
import eventTypeImage from "../../assets/images/images/tipo-evento.svg"
import { Input, Button } from "../../Components/FormComponents/FormComponent";
import api from "../../Services/Services";
import TableTp from "./TableTp/TableTp";
import Notification from "../../Components/Notification/Notification";
import Spinner from "../../Components/Spinner/Spinner"
import "./TipoEventos.css";



const TipoEventoPage = () => {
  const [frmEdit, setFrmEdit] = useState(false); //TIpo de dados bool

  const [titulo, setTitulo] = useState("") //tipo de dado em string 

  const [tipoEventos, setTipoEventos] = useState([]) //tipo de dados em array

  const [showSpinner, setShowSpinner] = useState(true)

  const [idTipoEvento, setIdTipoEvento] = useState("")

  const [notifyUser, setNotifyUser] = useState({})

  async function handleSubmit(e) {
    e.preventDefault();
    // parar o submit do formulário
    // validar pelo menos 3 caracteres
    //chamar a api

    if (titulo.trim().length < 3) {
      alert("Digite pelo menos 3 caracteres");
    }
    //chamar a api
    try {
      const retorno = await api.post("/TiposEvento", { titulo });
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
    setTitulo("");
  }



  function showUpdateForm(tipoEvento) {
    setFrmEdit(true)
    setIdTipoEvento(tipoEvento.idTipoEvento)
    setTitulo(tipoEvento.titulo)

  }

  async function handleUpdate(e) {
    e.preventDefault()
    try {
      const promise = await api.put(`/TiposEvento/${idTipoEvento}`, {
        titulo: titulo,
      });
      setNotifyUser({
        titleNote: "Sucesso",
        textNote: `Atualizado com sucesso!`,
        imgIcon: "success",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });
      console.log(promise.data);
      setTitulo("")
      setFrmEdit(false)
    } catch (error) {
      console.log(`Erro ao Atualizar Tipo Eventos ${error}`);
    }
  }


  async function handleDelete(id) {
    try {
      const promise = await api.delete(`/TiposEvento/${id}`)
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
      console.log(`Erro ao deletar tipo de eventos ${error}`);
    }
  }

  function editActionAbort() {
    setFrmEdit(false)
    setTitulo("")
    setIdTipoEvento(null)
  }

  useEffect(() => {
    async function getTitulos() {
      setShowSpinner(true)
      try {
        const promise = await api.get(`/TiposEvento`)
        console.log(promise.data);
        setTipoEventos(promise.data)
      } catch (error) {
        console.log(`Erro ao Listar Tipo de Eventos ${error}`);
      }
      setShowSpinner(false)
    }

    getTitulos();
  }, [tipoEventos]);



  return (
    <MainContent>
      <Notification {...notifyUser} setNotifyUser={setNotifyUser} />
      {showSpinner ? <Spinner /> : null}
      <section className="cadastro-evento-section">
        <Container>
          <div className="cadastro-evento__box">
            <Titulo
              tituloTexto={"Página Tipos de Eventos"}
              additionalClass="margem-acima"
            />

            <ImageIllustrator alterText="??????" imageRender={eventTypeImage} />

            <form
              className="ftipo-evento"
              onSubmit={frmEdit ? handleUpdate : handleSubmit}
              action=""
            >
              {!frmEdit ? (
                <>
                  <p>Tela de Cadastro</p>
                  <Input
                    id="titulo"
                    placeholder="Título"
                    type="text"
                    name="titulo"
                    value={titulo}
                    required
                    manipulationFunction={(e) => {
                      setTitulo(e.target.value);
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
                    id="titulo"
                    placeholder="Título"
                    type="text"
                    name="titulo"
                    value={titulo}
                    required
                    manipulationFunction={(e) => {
                      setTitulo(e.target.value);
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
          <Titulo tituloTexto={"Lista Tipo de Eventos"} color="white" />
          <TableTp
            dados={tipoEventos}
            fnUpdate={showUpdateForm}
            fnDelete={handleDelete}
          />
        </Container>
      </section>

      {/* {Listagem de tipo de eventos} */}
    </MainContent>
  );
};

export default TipoEventoPage;