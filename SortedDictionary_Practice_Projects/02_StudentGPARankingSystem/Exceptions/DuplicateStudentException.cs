using System;

namespace Exceptions
{
    public class DuplicateStudentException : Exception
    {
        public DuplicateStudentException(string msg) : base(msg)
        {
            
        }
    }
}