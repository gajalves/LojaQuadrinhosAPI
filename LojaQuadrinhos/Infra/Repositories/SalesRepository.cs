using LojaQuadrinhos.Infra.Context;
using LojaQuadrinhos.Infra.Repositories;
using LojaQuadrinhos.Domain.Entities;
using LojaQuadrinhos.Infra.Interfaces;

namespace LojaQuadrinhos.Infra.Repositories
{
    public class SalesRepository : BaseRepository<Sales>, ISalesRepository
    {
        private readonly ModelContext _context;

        public SalesRepository(ModelContext context) : base(context)
        {
            _context = context;
        }        
    }
}
