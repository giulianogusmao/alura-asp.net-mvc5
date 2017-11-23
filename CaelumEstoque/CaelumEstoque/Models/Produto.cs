using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaelumEstoque.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório"), StringLength(20, ErrorMessage = "Nome não pode ter mais que {0} caracteres")]
        public String Nome { get; set; }

        [Range(0.0, 10000.0, ErrorMessage = "O preço precisa ser maior que {1} e menor que {2}")]
        public float Preco { get; set; }

        public CategoriaDoProduto Categoria { get; set; }

        public int? CategoriaId { get; set; }

        public String Descricao { get; set; }

        [Range(0, 10000)]
        public int Quantidade { get; set; }
    }
}