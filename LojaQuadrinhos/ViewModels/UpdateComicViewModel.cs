using System.ComponentModel.DataAnnotations;

namespace LojaQuadrinhos.ViewModels
{
    public class UpdateComicViewModel
    {
        [Required(ErrorMessage = "O Id não pode ser vazio.")]
        [Range(1, int.MaxValue, ErrorMessage = "O Id não pode ser menor que 1.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O Titulo não pode ser vazio.")]
        [MinLength(1, ErrorMessage = "O Titulo deve ser maior que 1 caractere.")]
        [MaxLength(50, ErrorMessage = "O Titulo deve ter no maximo 50 caracteres.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "A Descricao não pode ser vazia.")]
        [MinLength(1, ErrorMessage = "A Descricao deve ser maior que 1 caractere.")]
        [MaxLength(180, ErrorMessage = "A Descricao deve ter no maximo 180 caracteres.")]        
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O Preço não pode ser vazio.")]        
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "A Data de Publicacao não pode ser vazia.")]
        public string DataPublicacao { get; set; }

        [Required(ErrorMessage = "O Autor não pode ser vazio.")]
        [MinLength(1, ErrorMessage = "O Autor deve ser maior que 1 caractere.")]
        [MaxLength(50, ErrorMessage = "O Autor deve ter no maximo 50 caracteres.")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "O Estoque não pode ser vazio.")]
        public int Estoque { get; set; }
    }
}
