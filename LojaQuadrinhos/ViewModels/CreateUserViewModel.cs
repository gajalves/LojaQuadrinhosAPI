using System.ComponentModel.DataAnnotations;

namespace LojaQuadrinhos.ViewModels
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage = "O Nome não pode ser vazio.")]
        [MinLength(3, ErrorMessage = "O Nome deve ser maior que 3 caracteres.")]
        [MaxLength(80, ErrorMessage = "O Nome deve ter no maximo 80 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Email não pode ser vazio.")]
        [MinLength(10, ErrorMessage = "O Email deve ser maior que 10 caracteres.")]
        [MaxLength(180, ErrorMessage = "O Email deve ter no maximo 180 caracteres.")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
            ErrorMessage = "O email informado não é válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A Senha não pode ser vazia.")]
        [MinLength(3, ErrorMessage = "O Senha deve ser maior que 3 caracteres.")]
        [MaxLength(80, ErrorMessage = "O Senha deve ter no maximo 80 caracteres.")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "A Role não pode ser vazia.")]
        public string Role { get; set; }
    }
}
