using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaQuadrinhos.Core.Exceptions;
using LojaQuadrinhos.Domain.Validators;
namespace LojaQuadrinhos.Domain.Entities
{
    public class Sales: Base
    {
        public int ComicId { get; private set; }

        public string UserEmail { get; private set; }

        public int Quantity { get; private set; }
        

        protected Sales() { }

        public Sales(int comicid, string useremail, int quantity)
        {
            ComicId = comicid;
            UserEmail = useremail;
            Quantity = quantity;
            _erros = new List<string>();

            Validate();
        }
                
        public override bool Validate()
        {
            SalesValidator validator = new SalesValidator();
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
