using System;
namespace Exceptions
{
    public class InvalidGPAException : Exception
    {
        public InvalidGPAException(string msg) : base(msg)
        {
            
        }
    }
}