using LojaQuadrinhos.Core.Exceptions;
using LojaQuadrinhos.Domain.Entities;
using LojaQuadrinhos.Infra.Interfaces;
using LojaQuadrinhos.Services.Cryptography.Interfaces;
using LojaQuadrinhos.Services.DTO;
using LojaQuadrinhos.Services.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LojaQuadrinhos.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IAesCryptography _aesCryptography;

        public UserService(IMapper mapper, IUserRepository userRepository, IAesCryptography aesCryptography)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _aesCryptography = aesCryptography;
        }

        public async Task<UserDTO> Create(UserDTO userDTO) 
        {
            User userExists = await _userRepository.GetByEmail(userDTO.Email) ;

            if (userExists != null)
                throw new DomainException("Já existe um usuário com o email informado");

            User user = _mapper.Map<User>(userDTO);
            user.Validate();
            user.SetSenha(_aesCryptography.Encrypt(user.Senha));
            
            User userCreate = await _userRepository.Create(user);

            return _mapper.Map<UserDTO>(userCreate);
        }

        public async Task<UserDTO> Update(UserDTO userDTO) 
        {
            User userExists = await _userRepository.Get(userDTO.Id);

            if (userExists == null)
                throw new DomainException("Usuário não encontrado com o id informado");

            User user = _mapper.Map<User>(userDTO);
            user.Validate();
            user.SetSenha(_aesCryptography.Encrypt(user.Senha));

            User userCreate = await _userRepository.Update(user);

            return _mapper.Map<UserDTO>(userCreate);
        }

        public async Task Remove(int id) 
        {
            await _userRepository.Remove(id);            
        }

        public async Task<UserDTO> Get(int id) 
        {
            User user = await _userRepository.Get(id);

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<List<UserDTO>> Get() 
        {
            List<User> allUsers = await _userRepository.GetAll();

            return _mapper.Map<List<UserDTO>>(allUsers);
        }

        public async Task<UserDTO> GetByEmail(string email) 
        {
            User user = await _userRepository.GetByEmail(email);

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<List<UserDTO>> SearchByName(string name) 
        {
            List<User> user = await _userRepository.SearchByName(name);

            return _mapper.Map<List<UserDTO>>(user);
        }        
    }
}
