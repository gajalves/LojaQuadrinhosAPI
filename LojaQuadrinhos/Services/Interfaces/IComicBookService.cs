using LojaQuadrinhos.Services.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaQuadrinhos.Services.Interfaces
{
    public interface IComicBookService
    {
        Task<ComicBookDTO> Create(ComicBookDTO comicbookDTO);

        Task<ComicBookDTO> Update(ComicBookDTO comicbookDTO);

        Task Remove(int id);

        Task<ComicBookDTO> Get(int id);

        Task<List<ComicBookDTO>> Get();
    }
}
