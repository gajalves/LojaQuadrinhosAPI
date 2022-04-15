using AutoMapper;
using LojaQuadrinhos.Core.Exceptions;
using LojaQuadrinhos.Services.DTO;
using LojaQuadrinhos.Services.Interfaces;
using LojaQuadrinhos.Utilities;
using LojaQuadrinhos.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaQuadrinhos.Controllers
{
    [ApiController]
    public class ComicBookController : ControllerBase
    {
        private readonly IComicBookService _comicbookservice;        
        private readonly IMapper _mapper;

        public ComicBookController(IComicBookService comicbookservice, IMapper mapper)
        {
            _comicbookservice = comicbookservice;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [Route("/api/v1/comicbooks/create")]
        public async Task<IActionResult> Create([FromBody] CreateComicViewModel cbViewModel)
        {
            try
            {
                ComicBookDTO oCbDTO = _mapper.Map<ComicBookDTO>(cbViewModel);
                ComicBookDTO retCbCreate = await _comicbookservice.Create(oCbDTO);

                return Ok(new RetViewModel
                {
                    Message = "Quadrinho criado com sucesso!",
                    Success = true,
                    Data = retCbCreate
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        [Route("/api/v1/comicbooks/update")]
        public async Task<IActionResult> Update([FromBody] UpdateComicViewModel cbViewModel)
        {
            try
            {
                ComicBookDTO oComicBookDTO = _mapper.Map<ComicBookDTO>(cbViewModel);
                ComicBookDTO oCbUpdated = await _comicbookservice.Update(oComicBookDTO);

                return Ok(new RetViewModel
                {
                    Message = "Quadrinho atualizado com sucesso!",
                    Success = true,
                    Data = oCbUpdated
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpDelete]
        [Authorize(Roles = "admin")]
        [Route("/api/v1/comicbooks/delete/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                await _comicbookservice.Remove(id);

                return Ok(new RetViewModel
                {
                    Message = "Quadrinho removido com sucesso!",
                    Success = true,
                    Data = null
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("/api/v1/comicbooks/getall")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<ComicBookDTO> lRetComics = await _comicbookservice.Get();

                return Ok(new RetViewModel
                {
                    Message = "Quadrinhos encontrados com sucesso!",
                    Success = true,
                    Data = lRetComics
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("/api/v1/comicbooks/GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                ComicBookDTO RetComic = await _comicbookservice.Get(id);

                if(RetComic == null)
                {
                    return Ok(new RetViewModel
                    {
                        Message = "Quadrinho com o ID informado não encontrado",
                        Success = true,
                        Data = null
                    });
                }

                return Ok(new RetViewModel
                {
                    Message = "Quadrinhos com o ID informaddo encontrado!",
                    Success = true,
                    Data = RetComic
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }
    }
}

