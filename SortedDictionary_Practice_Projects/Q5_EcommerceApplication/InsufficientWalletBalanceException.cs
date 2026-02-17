using System;
namespace EcommerceApplication;

public class InsufficientWalletBalanceException : Exception
{
    public InsufficientWalletBalanceException(string msg) : base(msg){
        
    }
}