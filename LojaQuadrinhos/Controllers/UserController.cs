using LojaQuadrinhos.Core.Exceptions;
using LojaQuadrinhos.Services.DTO;
using LojaQuadrinhos.Services.Interfaces;
using LojaQuadrinhos.Utilities;
using LojaQuadrinhos.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaQuadrinhos.Controllers
{    
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userservice;
        private readonly IMapper _mapper;

        public UserController(IUserService userservice, IMapper mapper)
        {
            _userservice = userservice;
            _mapper = mapper;
        }

        [HttpPost]        
        [Route("/api/v1/users/create")]
        public async Task<IActionResult> Create([FromBody]CreateUserViewModel userViewModel)
        {
            try
            {
                UserDTO oUserDTO = _mapper.Map<UserDTO>(userViewModel);
                UserDTO retUserCreate = await _userservice.Create(oUserDTO);

                return Ok(new RetViewModel
                {
                    Message = "Usuário criado com sucesso!",
                    Success = true,
                    Data = retUserCreate
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
        [Authorize]
        [Route("/api/v1/users/update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserViewModel userViewModel)
        {
            try
            {
                UserDTO oUserDTO = _mapper.Map<UserDTO>(userViewModel);
                UserDTO oUserUpdated = await _userservice.Update(oUserDTO);

                return Ok(new RetViewModel
                {
                    Message = "Usuário atualizado com sucesso!",
                    Success = true,
                    Data = oUserUpdated
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
        [Authorize]
        [Route("/api/v1/users/delete/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                await _userservice.Remove(id);

                return Ok(new RetViewModel
                {
                    Message = "Usuário removido com sucesso!",
                    Success = true,
                    Data = null
                });
            }
            catch(DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch(Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Authorize]
        [Route("/api/v1/users/GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                UserDTO retUser = await _userservice.Get(id);
                
                if(retUser == null)
                {
                    return Ok(new RetViewModel
                    {
                        Message = "Usuário com o ID informado não encontrado",
                        Success = true,
                        Data = null
                    });
                }

                return Ok(new RetViewModel
                {
                    Message = "Usuário com o ID informado encontrado",
                    Success = true,
                    Data = retUser
                });

            }
            catch(DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch(Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]        
        [Route("/api/v1/users/GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<UserDTO> lRetUser = await _userservice.Get();
                                
                return Ok(new RetViewModel
                {
                    Message = "Usuários encontrados com sucesso!",
                    Success = true,
                    Data = lRetUser
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
        [Authorize]
        [Route("/api/v1/users/GetByEmail")]
        public async Task<IActionResult> GetByEmail([FromQuery] string email)
        {
            try
            {
                UserDTO retUser = await _userservice.GetByEmail(email);

                if (retUser == null)
                {
                    return Ok(new RetViewModel
                    {
                        Message = "Usuário com o email informado não encontrado",
                        Success = true,
                        Data = null
                    });
                }

                return Ok(new RetViewModel
                {
                    Message = "Usuário com o email informado encontrado",
                    Success = true,
                    Data = retUser
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
        [Authorize]
        [Route("/api/v1/users/SearchByName")]
        public async Task<IActionResult> SearchByName([FromQuery] string name)
        {
            try
            {
                List<UserDTO> lRetUser = await _userservice.SearchByName(name);

                if (lRetUser.Count == 0)
                {
                    return Ok(new RetViewModel
                    {
                        Message = "Nenhum usuário com o nome informado não encontrado",
                        Success = true,
                        Data = null
                    });
                }

                return Ok(new RetViewModel
                {
                    Message = "Usuário com o nome informado encontrado",
                    Success = true,
                    Data = lRetUser
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
