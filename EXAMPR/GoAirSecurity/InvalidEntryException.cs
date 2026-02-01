using System;
namespace GoAirSecurity;
public class InvalidEntryException : Exception
{
    public InvalidEntryException(string message) : base(message)
    {  
    }
}