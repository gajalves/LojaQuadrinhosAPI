using AutoMapper;
using LojaQuadrinhos.Domain.Entities;
using LojaQuadrinhos.Services.Cryptography.Interfaces;
using LojaQuadrinhos.Services.DTO;
using LojaQuadrinhos.Services.Interfaces;
using LojaQuadrinhos.Token;
using LojaQuadrinhos.Utilities;
using LojaQuadrinhos.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace LojaQuadrinhos.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IUserService _userservice;
        private readonly IMapper _mapper;
        private readonly IAesCryptography _aesCryptography;

        public AuthController(IConfiguration configuration, ITokenGenerator tokenGenerator, IUserService userservice,
                              IMapper mapper, IAesCryptography aesCryptography)
        {
            _configuration = configuration;
            _tokenGenerator = tokenGenerator;
            _userservice = userservice;
            _mapper = mapper;
            _aesCryptography = aesCryptography;
        }


        [HttpPost]
        [Route("/api/v1/auth/login")]
        public async Task<IActionResult> Login([FromBody] AuthViewModel authViewModel)
        {
            try
            {
                UserDTO retUser = await _userservice.GetByEmail(authViewModel.Email);

                if (retUser == null)
                {
                    return Ok(new RetViewModel
                    {
                        Message = "Usuário com o email informado não encontrado",
                        Success = true,
                        Data = null
                    });
                }

                if(authViewModel.Password == _aesCryptography.Decrypt(retUser.Senha))
                {
                    return Ok(new RetViewModel
                    {
                        Message = "Usuário autenticado com sucesso!",
                        Success = true,
                        Data = new
                        {
                            Token = _tokenGenerator.GenerateToken(retUser),
                            TokenExpires = DateTime.UtcNow.AddHours(int.Parse(_configuration["Jwt:HoursToExpire"]))
                        }
                    });
                }
                return StatusCode(401, Responses.UnauthorizedErrorMessage());
            }
            catch(Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }            
        }
    }
}
