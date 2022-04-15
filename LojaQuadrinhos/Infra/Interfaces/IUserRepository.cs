using LojaQuadrinhos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaQuadrinhos.Infra.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByEmail(string email);
        Task<List<User>> SearchByName(string name);

    }
}