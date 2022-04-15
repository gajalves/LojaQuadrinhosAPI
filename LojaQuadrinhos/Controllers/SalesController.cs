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
    public class SalesController : ControllerBase
    {
        private readonly ISalesService _salesservice;
        private readonly IComicBookService _comicbookservice;
        private readonly IUserService _userservice;
        private readonly IMapper _mapper;

        public SalesController(ISalesService salesservice, IComicBookService comicbookservice, IMapper mapper, IUserService user)
        {
            _salesservice = salesservice;
            _comicbookservice = comicbookservice;
            _userservice = user;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles = "user,admin")]
        [Route("/api/v1/sales/buy")]
        public async Task<IActionResult> BuySomeComic([FromBody] BuyComicViewModel bcViewModel)
        {
            try
            {
                if (User.Identity.Name != bcViewModel.UserEmail)
                    return BadRequest(Responses.DomainErrorMessage("Token inválido para o Usuário informado"));

                SalesDTO oSalesDTO = _mapper.Map<SalesDTO>(bcViewModel);
                SalesDTO retSalesCreate = await _salesservice.Create(oSalesDTO);                

                return Ok(new RetViewModel
                {
                    Message = "Compra registrada com sucesso!",
                    Success = true,
                    Data = retSalesCreate
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

