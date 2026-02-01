using System;
namespace ShopValidator;

public class InvalidGadgetException : Exception
{
    public InvalidGadgetException(string message) : base(message)
    {
    }
}