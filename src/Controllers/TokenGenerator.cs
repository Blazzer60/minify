using System;
using Minify.Interfaces;

namespace Minify.Controllers
{
    public class TokenGenerator : ITokenGenerator
    {
        public string Generate()
        {
            return Guid.NewGuid().ToString();
        }
    }
}