using System.ComponentModel.DataAnnotations;

namespace LojaQuadrinhos.ViewModels
{
    public class AuthViewModel
    {
        [Required(ErrorMessage = "O Login não pode ser vazio.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A Senha não pode ser vazia.")]
        public string Password { get; set; }
    }
}
