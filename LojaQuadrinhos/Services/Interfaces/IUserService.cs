using LojaQuadrinhos.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaQuadrinhos.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> Create(UserDTO userDTO);

        Task<UserDTO> Update(UserDTO userDTO);

        Task Remove(int id);

        Task<UserDTO> Get(int id);

        Task<List<UserDTO>> Get();

        Task<UserDTO> GetByEmail(string email);

        Task<List<UserDTO>> SearchByName(string name);
    }
}
