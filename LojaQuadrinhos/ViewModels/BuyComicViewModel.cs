using System;
using System.ComponentModel.DataAnnotations;

namespace LojaQuadrinhos.ViewModels
{
    public class BuyComicViewModel
    {
        [Required(ErrorMessage = "O ID do Quadrinho não pode ser vazio.")]
        public int ComicId { get; set; }

        [Required(ErrorMessage = "O Email do Usuário não pode ser vazio.")]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "A Quantidade não pode ser vazia.")]
        public int Quantity { get; set; }        
    }
}
