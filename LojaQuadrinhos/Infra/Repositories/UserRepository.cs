using LojaQuadrinhos.Domain.Entities;
using LojaQuadrinhos.Infra.Context;
using LojaQuadrinhos.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaQuadrinhos.Infra.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ModelContext _contex;
        public UserRepository(ModelContext context) : base(context)
        {
            _contex = context;
        }

        public async Task<User> GetByEmail(string email)
        {
            User oUser = await _contex.Users.Where(user => user.Email.ToUpper() == email.ToUpper()).AsNoTracking().FirstOrDefaultAsync();

            return oUser;
        }

        public async Task<List<User>> SearchByName(string name)
        {
            List<User> lUser = await _contex.Users.Where(user => user.Nome.ToUpper() == name.ToUpper()).AsNoTracking().ToListAsync();

            return lUser;
        }

    }
}
