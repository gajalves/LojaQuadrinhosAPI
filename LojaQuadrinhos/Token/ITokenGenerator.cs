using LojaQuadrinhos.Domain.Entities;
using LojaQuadrinhos.Services.DTO;

namespace LojaQuadrinhos.Token
{
    public interface ITokenGenerator
    {
        string GenerateToken(UserDTO oUserDTO);
    }
}
