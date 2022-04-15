using FluentValidation;
using LojaQuadrinhos.Domain.Entities;

namespace LojaQuadrinhos.Domain.Validators
{
    public class ComicBookValidator : AbstractValidator<ComicBook>
    {
        public ComicBookValidator()
        {
            RuleFor(comicbook => comicbook)
               .NotEmpty().WithMessage("A entidade não pode ser vazia.")
               .NotNull().WithMessage("A entidade não pode ser nula.");

            RuleFor(comicbook => comicbook.Titulo)
                .NotEmpty().WithMessage("O Titulo não pode ser vazio.")
                .NotNull().WithMessage("O Titulo não pode ser nulo.")
                .MinimumLength(1).WithMessage("O Titulo deve ser maior que 1 caracteres.")
                .MaximumLength(50).WithMessage("O Titulo deve ter no maximo 50 caracteres.");

            RuleFor(comicbook => comicbook.Descricao)
                .NotEmpty().WithMessage("A Descrição não pode ser vazia.")
                .NotNull().WithMessage("O Descrição não pode ser nula.")
                .MinimumLength(1).WithMessage("O Descrição deve ser maior que 1 caracteres.")
                .MaximumLength(180).WithMessage("O Descrição deve ter no maximo 180 caracteres.");

            RuleFor(comicbook => comicbook.Preco)
                .NotNull().WithMessage("O Preço não pode ser nulo");

            RuleFor(comicbook => comicbook.DataPublicacao)
                .NotEmpty().WithMessage("A Data de Publicacao não pode ser vazia.")
                .NotNull().WithMessage("A Data de Publicacao não pode ser nula.");

            RuleFor(comicbook => comicbook.Autor)
                .NotEmpty().WithMessage("O Autor não pode ser vazio.")
                .NotNull().WithMessage("O Autor não pode ser nulo.")                
                .MaximumLength(50).WithMessage("O Autor deve ter no maximo 50 caracteres.");

            RuleFor(comicbook => comicbook.Estoque)
                .NotEmpty().WithMessage("O Estoque não pode ser vazio.");
        }
    }
}
