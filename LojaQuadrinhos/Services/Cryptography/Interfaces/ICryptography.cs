using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaQuadrinhos.Services.Cryptography.Interfaces
{
    public interface ICryptography
    {
        string Encrypt(string text);
        string Decrypt(string text);
    }
}
