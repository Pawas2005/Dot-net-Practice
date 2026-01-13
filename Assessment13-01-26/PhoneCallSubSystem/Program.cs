using System;

namespace PhoneCallSubSystem
{
    public class Program
    {
        public static void Main()
        {
            PhoneCall call = new PhoneCall();

            //OnSubscribe()
            call.MakeAPhoneCall(true);
            Console.WriteLine(call.Message);

            //OnUnSubscribe()
            call.MakeAPhoneCall(false);
            Console.WriteLine(call.Message);

            Console.ReadLine();
        }
    }
}