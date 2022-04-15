using AutoMapper;
using LojaQuadrinhos.Core.Exceptions;
using LojaQuadrinhos.Domain.Entities;
using LojaQuadrinhos.Infra.Interfaces;
using LojaQuadrinhos.Services.DTO;
using LojaQuadrinhos.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaQuadrinhos.Services.Services
{
    public class ComicBookService : IComicBookService
    {
        private readonly IMapper _mapper;
        private readonly IComicBookRepository _comicBookRepository;

        public ComicBookService(IMapper mapper, IComicBookRepository comicBookRepository)
        {
            _mapper = mapper;
            _comicBookRepository = comicBookRepository;
        }

        public async Task<ComicBookDTO> Create(ComicBookDTO comicbookDTO)
        {                        
            ComicBook cb = _mapper.Map<ComicBook>(comicbookDTO);
            cb.Validate();
            
            ComicBook cbCreate = await _comicBookRepository.Create(cb);

            return _mapper.Map<ComicBookDTO>(cbCreate);
        }

        public async Task<ComicBookDTO> Update(ComicBookDTO comicbookDTO)
        {
            ComicBook cbExists = await _comicBookRepository.Get(comicbookDTO.Id);

            if (cbExists == null)
                throw new DomainException("Quadrinho não encontrado com o id informado");

            ComicBook cb = _mapper.Map<ComicBook>(comicbookDTO);
            cb.Validate();            

            ComicBook cbCreate = await _comicBookRepository.Update(cb);

            return _mapper.Map<ComicBookDTO>(cbCreate);
        }

        public async Task Remove(int id)
        {
            await _comicBookRepository.Remove(id);
        }

        public async Task<ComicBookDTO> Get(int id)
        {
            ComicBook cb = await _comicBookRepository.Get(id);

            return _mapper.Map<ComicBookDTO>(cb);
        }

        public async Task<List<ComicBookDTO>> Get()
        {
            List<ComicBook> lComicBook = await _comicBookRepository.GetAll();
            return _mapper.Map<List<ComicBookDTO>>(lComicBook);
        }
    }


}
