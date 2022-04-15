using LojaQuadrinhos.ViewModels;
using System.Collections.Generic;

namespace LojaQuadrinhos.Utilities
{
    public static class Responses
    {
        public static RetViewModel ApplicationErrorMessage()
        {
            return new RetViewModel
            {
                Message = "Ocorreu algum erro interno na aplicação, por favor tente novamente.",
                Success = false,
                Data = null
            };
        }

        public static RetViewModel DomainErrorMessage(string message)
        {
            return new RetViewModel
            {
                Message = message,
                Success = false,
                Data = null
            };
        }

        public static RetViewModel DomainErrorMessage(string message, IReadOnlyCollection<string> errors)
        {
            return new RetViewModel
            {
                Message = message,
                Success = false,
                Data = errors
            };
        }

        public static RetViewModel UnauthorizedErrorMessage()
        {
            return new RetViewModel
            {
                Message = "A combinação de login e senha está incorreta!",
                Success = false,
                Data = null
            };
        }

        public static RetViewModel InternalServerErrorMessage()
        {
            return new RetViewModel
            {
                Message = "Ocorreu um erro interno na aplicação, por favor tente novamente.",
                Success = false,
                Data = null
            };
        }
    }
}
