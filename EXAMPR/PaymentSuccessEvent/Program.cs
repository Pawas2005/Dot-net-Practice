using System;
namespace PaymentSuccessEvent;

public class Program
{
    public static void Main()
    {
        Payment payment = new Payment();

        payment.OnPaymentSuccess += NotificationService.SendEmail;
        payment.OnPaymentSuccess += NotificationService.SendMsg;
        payment.OnPaymentSuccess += NotificationService.GnerateBill;

        payment.MakePayment("Badmosh", 7000);
    }
}