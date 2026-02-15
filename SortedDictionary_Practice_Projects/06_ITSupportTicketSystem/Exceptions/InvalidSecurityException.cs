using System;

namespace Exceptions
{
    public class InvalidSecurityException : Exception
    {
        public InvalidSecurityException(string message) : base(message) { }
    }
}
