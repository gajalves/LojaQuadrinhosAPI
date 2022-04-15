using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaQuadrinhos.Core.Exceptions
{
    public class DomainException : Exception
    {
        internal List<string> _errors;

        public List<string> Errors => _errors;

        public DomainException()
        {

        }

        public DomainException(String message, List<String> errors) : base(message)
        {
            _errors = errors;
        }

        public DomainException(string message) : base(message)
        {

        }
    }
}
