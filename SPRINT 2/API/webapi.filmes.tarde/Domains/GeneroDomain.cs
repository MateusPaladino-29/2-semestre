﻿using System.ComponentModel.DataAnnotations;

namespace webapi.filmes.tarde.Domains
{
    /// <summary>
    /// Classe que representa a entidade(Tabela) Genero
    /// </summary>
    /// 
    public class GeneroDomain
    {
        public int IdGenero { get; set; }

        [Required(ErrorMessage = "O nome do Genero é Obrigatorio")]
        public string? Nome { get; set; }
    }
}
