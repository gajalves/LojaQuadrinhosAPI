using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LojaQuadrinhos.Services.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        [JsonIgnore]
        public string Senha { get; set; }
        
        public string Role { get; set; }

        public UserDTO()
        {

        }

        public UserDTO(int id, string nome, string email, string senha, string role)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
            Role = role;
         }
    }
}
