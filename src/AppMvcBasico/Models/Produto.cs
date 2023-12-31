﻿using System.ComponentModel.DataAnnotations;

namespace AppMvcBasico.Models
{
    public class Produto : Entity
    {
        //Chave Estrangeira
        public Guid FornecedorId { get; set; }

        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        [StringLength(200,ErrorMessage = "O campo {0} precisa ter entre {2} e {1}" , MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1}", MinimumLength = 2)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1}", MinimumLength = 2)]
        public string Imagem { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Valor { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        /* EF RELATIONS */
        //No caso como o Fornecedor terá um produto pode chamar normal.
        public Fornecedor? Fornecedor { get; set; }
    }
}
