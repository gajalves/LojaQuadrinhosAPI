using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaQuadrinhos.Core.Exceptions;
using LojaQuadrinhos.Domain.Validators;
namespace LojaQuadrinhos.Domain.Entities
{
    public class User: Base
    {
        public string Nome { get; private set; }

        public string Email { get; private set; }

        public string Senha { get; private set; }

        public string Role { get; private set; }

        protected User() { }

        public User(string nome, string email, string senha, string role)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Role = role;
            _erros = new List<string>();

            Validate();
        }
        
        public void SetNome(string nome)
        {
            Nome = nome;
            Validate();
        }

        public void SetEmail(string email)
        {
            Email = email;
            Validate();
        }

        public void SetSenha(string senha)
        {
            Senha = senha;
            Validate();
        }

        public void SetRole(string role)
        {
            Role = role;
            Validate();
        }

        public override bool Validate()
        {
            UserValidator validator = new UserValidator();
            var validacao = validator.Validate(this);

            if(!validacao.IsValid)
            {
                foreach(var error in validacao.Errors)
                {
                    _erros.Add(error.ErrorMessage);
                }

                throw new DomainException("Alguns campos estão inválidos, por favor corrigir! " + _erros);
            }

            return true;
        }
    }
}
