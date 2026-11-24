using System.ComponentModel.DataAnnotations;

namespace ExerciciosPt2.Models
{
    public class Evento
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatorio")]
        [StringLength(80, MinimumLength = 5, ErrorMessage = "O nome deve ter entre 5 e 80 caracteres")]
        public string Nome { get; set; } = "";

        [Required(ErrorMessage = "A descrição é obrigatória")]
        [StringLength(int.MaxValue, MinimumLength = 10, ErrorMessage = "E-mail inválido")]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "O local é obrigatótio")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O local deve ter entre 3 e 100 caracteres")]
        public string Local { get; set; } = "";

        [Required(ErrorMessage = "A data do evento é obrigatória")]
        public DateTime DataEvento { get; set; }

        [Required(ErrorMessage = "A quantidade de vagas é obrigatória")]
        [Range(1, 1000)]
        public int QuantidadeVagas { get; set; }


        [Required(ErrorMessage = "O valor do ingresso é obrigatório")]
        [Range(0, int.MaxValue, ErrorMessage = "O valor deve ser maior ou igual que 0")]
        public decimal ValorIngresso { get; set; }
    }
}