using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using LojaQuadrinhos.Domain.Entities;

namespace LojaQuadrinhos.Domain.Validators
{
    public class SalesValidator: AbstractValidator<Sales>
    {
        public SalesValidator()
        {
            RuleFor(sales => sales)
                .NotEmpty().WithMessage("A entidade não pode ser vazia.")
                .NotNull().WithMessage("A entidade não pode ser nula.");

            RuleFor(sales => sales.ComicId)
                .NotEmpty().WithMessage("O ID do Quadrinho não pode ser vazio.")
                .NotNull().WithMessage("O ID do Quadrinho não pode ser nulo.");

            RuleFor(sales => sales.UserEmail)
                .NotEmpty().WithMessage("O Email não pode ser vazio.")
                .NotNull().WithMessage("O Email não pode ser nulo.")
                .MinimumLength(10).WithMessage("O Email deve ser maior que 10 caracteres.")
                .MaximumLength(180).WithMessage("O Email deve ter no maximo 180 caracteres.")
                .Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$").WithMessage("O email informado não é válido.");

            RuleFor(sales => sales.Quantity)
                .NotEmpty().WithMessage("A Quantidade não pode ser vazia.")
                .NotNull().WithMessage("A Quantidade não pode ser nula.");                
        }
    }
}
