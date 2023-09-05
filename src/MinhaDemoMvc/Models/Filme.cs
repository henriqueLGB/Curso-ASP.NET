using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhaDemoMvc.Models
{
    public class Filme
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo título é obrigatório")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "o título precisa ter entre 3 ou 60 caracteres")]
        public string Titulo { get; set; }

        [DataType(DataType.DateTime, ErrorMessage = "Data em formato incorreto")]
        [Required(ErrorMessage = "O campo Data de Lançamento é obrigatório")]
        [Display(Name = "Data de Lançamento")]
        public DateTime DataLancamento { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA\u00C0-\u00FF""'\w-]*$",ErrorMessage = "Genero em formato inválido")]
        [StringLength(30, ErrorMessage = "Máximo de 30 caracteres"), Required(ErrorMessage = "O campo Data de Lançamento é obrigatório")]
        public string Genero { get; set; }

        [Range(1,900,ErrorMessage = "Valor de 1 a 900")]
        [Required(ErrorMessage = "O campo Valor é obrigatório")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Preencha o campo Avaliação")]
        [RegularExpression(@"^[0-5]*$", ErrorMessage = "Somente números")]
        [Display(Name = "Avaliação")]
        public int Avaliacao { get; set; }
    }
}
