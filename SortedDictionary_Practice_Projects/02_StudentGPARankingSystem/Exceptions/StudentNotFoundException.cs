using System;

namespace Exceptions
{
    public class StudentNotFoundException : Exception
    {
        public StudentNotFoundException(string msg) : base(msg)
        {
            
        }
    }
}