using System;
namespace PaymentSuccessEvent;

public delegate void PaymentSuccess(string msg);

public class Payment
{
    //created an event
    public event PaymentSuccess OnPaymentSuccess;

    public void MakePayment(string customerName, double amount)
    {
        Console.WriteLine($"Payment of {amount} done by {customerName}");

        if(OnPaymentSuccess != null)
        {
            OnPaymentSuccess($"Payment Successful for {customerName} for {amount}");
        }
    }
}