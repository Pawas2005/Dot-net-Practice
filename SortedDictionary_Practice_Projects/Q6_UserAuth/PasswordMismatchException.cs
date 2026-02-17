using System;
namespace UserAuthentication;

public class PasswordMismatchException : Exception
{
    public PasswordMismatchException(String msg) : base(msg)
    {
        
    }
}