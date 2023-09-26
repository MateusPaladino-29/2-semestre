using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webapi.healthclinic.Domains
{
    [Table(nameof(Agendamento))]
    public class Agendamento
    {
        [Key]

        public Guid IdAgendamento { get; set; } = Guid.NewGuid();

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "Data da consulta obrigatória!")]
        public DateTime? DataConsulta { get; set; }

        [Column(TypeName = "TIME")]
        [Required(ErrorMessage = "Horario da consulta obrigatória!")]
        public TimeSpan? HoraConsulta { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Prontuário obrigatório!")]
        public string? Prontuario { get; set; }

        [Column(TypeName = "Varchar(100)")]
        [Required(ErrorMessage = "Sexo é Obrigatorio")]
        public string? Sexo { get; set;}



        /// <summary>
        /// ForeingKey
        /// </summary>
        [Required(ErrorMessage = "Id do Médico obrigatório!")]
        public Guid IdMedico { get; set; }

        [ForeignKey(nameof(IdMedico))]
        public Medico? Medico { get; set; }

        [Required(ErrorMessage = "Id do Paciente obrigatório!")]
        public Guid IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        public Paciente? Paciente { get; set; }
    }
}
