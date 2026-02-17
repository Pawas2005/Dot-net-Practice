using System;
namespace UserVerification;

public class InvalidPhoneNumberException : Exception
{
    public InvalidPhoneNumberException(string msg) : base(msg)
    {
        
    }
}