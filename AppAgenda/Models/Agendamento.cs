using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppAgenda.Models
{
    [Table("Agendamentos")]
    public class Agendamento
    {
        [Key]
        public int AgendaId { get; set; }

        [Required]
        [Display(Name = "Nome do Paciente")]
        [StringLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Required]
        [Display(Name = "Inicio da Consulta")]
        [DataType(DataType.DateTime)]
        public DateTime DataHoraInicio { get; set; }

        [Required]
        [Display(Name = "Fim da Consulta")]
        [DataType(DataType.DateTime)]
        public DateTime DataHoraFim { get; set; }

        [DataType(DataType.MultilineText)]
        [Column(TypeName = "varchar(max)")]
        public string Observacao { get; set; }
    }
}
