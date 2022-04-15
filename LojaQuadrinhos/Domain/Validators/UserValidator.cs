using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using LojaQuadrinhos.Domain.Entities;

namespace LojaQuadrinhos.Domain.Validators
{
    public class UserValidator: AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user)
                .NotEmpty().WithMessage("A entidade não pode ser vazia.")
                .NotNull().WithMessage("A entidade não pode ser nula.");

            RuleFor(user => user.Nome)
                .NotEmpty().WithMessage("O Nome não pode ser vazio.")
                .NotNull().WithMessage("O Nome não pode ser nulo.")
                .MinimumLength(3).WithMessage("O Nome deve ser maior que 3 caracteres.")
                .MaximumLength(80).WithMessage("O Nome deve ter no maximo 80 caracteres.");

            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("O Email não pode ser vazio.")
                .NotNull().WithMessage("O Email não pode ser nulo.")
                .MinimumLength(10).WithMessage("O Email deve ser maior que 10 caracteres.")
                .MaximumLength(180).WithMessage("O Email deve ter no maximo 180 caracteres.")
                .Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$").WithMessage("O email informado não é válido.");

            RuleFor(user => user.Senha)
                .NotEmpty().WithMessage("A senha não pode ser vazia.")
                .NotNull().WithMessage("A Senha não pode ser nula.")
                .MinimumLength(3).WithMessage("A Senha deve ser maior que 3 caracteres.")
                .MaximumLength(80).WithMessage("A Senha deve ter no maximo 80 caracteres.");            
        }
    }
}
