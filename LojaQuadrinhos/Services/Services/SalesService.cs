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
    public class SalesService : ISalesService
    {
        private readonly IMapper _mapper;
        private readonly ISalesRepository _salesRepository;
        private readonly IUserRepository _userRepository;
        private readonly IComicBookRepository _comicbookRepository;

        public SalesService(IMapper mapper, ISalesRepository salesRepository, 
                            IUserRepository userRepository, IComicBookRepository comicbookRepository)
        {
            _mapper = mapper;
            _salesRepository = salesRepository;
            _userRepository = userRepository;
            _comicbookRepository = comicbookRepository;
        }

        public async Task<SalesDTO> Create(SalesDTO salesDTO)
        {
            ComicBook retComic = await _comicbookRepository.Get(salesDTO.ComicId);
            if (retComic == null)
                throw new DomainException("Quadrinho não encontrado com o id informado");

            User retUser = await _userRepository.GetByEmail(salesDTO.UserEmail);
            if (retUser == null)
                throw new DomainException("Usuário não encontrado com o email informado");

            if(retComic.Estoque < salesDTO.Quantity)
                throw new DomainException("Quadrinho sem estoque disponível");

            Sales sales = _mapper.Map<Sales>(salesDTO);
            sales.Validate();
            
            Sales salesCreate = await _salesRepository.Create(sales);
            
            retComic.Estoque = retComic.Estoque - salesDTO.Quantity;
            ComicBook oCbUpdated = await _comicbookRepository.Update(retComic);

            return _mapper.Map<SalesDTO>(salesCreate);
        }
    }
}
