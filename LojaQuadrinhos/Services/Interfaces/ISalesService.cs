using LojaQuadrinhos.Services.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaQuadrinhos.Services.Interfaces
{
    public interface ISalesService
    {
        Task<SalesDTO> Create(SalesDTO comicbookDTO);        
    }
}
