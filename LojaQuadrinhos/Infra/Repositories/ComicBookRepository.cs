using LojaQuadrinhos.Infra.Context;
using LojaQuadrinhos.Infra.Repositories;
using LojaQuadrinhos.Domain.Entities;
using LojaQuadrinhos.Infra.Interfaces;

namespace LojaQuadrinhos.Infra.Repositories
{
    public class ComicBookRepository : BaseRepository<ComicBook>, IComicBookRepository
    {
        private readonly ModelContext _context;

        public ComicBookRepository(ModelContext context) : base(context)
        {
            _context = context;
        }        
    }
}
