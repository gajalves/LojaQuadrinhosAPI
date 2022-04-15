using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaQuadrinhos.Domain.Entities
{
    public abstract class Base
    {
        public int Id { get; set; }


        internal List<string> _erros;
        public IReadOnlyCollection<string> lErrors => _erros;


        public abstract bool Validate();
    }
}
