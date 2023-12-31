﻿using Webapi.healthclinic.Domains;

namespace Webapi.healthclinic.Interface
{
    public interface IClinicaRepository
    {
        void Cadastrar(Clinica clinica);
        void Deletar(Guid Id);
        List<Clinica> Listar();
        Clinica BuscarPorId(Guid Id);
        void Atualizar(Guid Id, Clinica clinica);
    }
}
