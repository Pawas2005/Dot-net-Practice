using System;
namespace PaymentSuccessEvent;

public class NotificationService
{
    public static void SendEmail(string msg)
    {
        Console.WriteLine("Email Sent -> " + msg);
    }

    public static void SendMsg(String msg)
    {
        Console.WriteLine("Msg Send -> " + msg);
    }

    public static void GnerateBill(String msg)
    {
        Console.WriteLine("Invoice Generated -> " + msg);
    }
}