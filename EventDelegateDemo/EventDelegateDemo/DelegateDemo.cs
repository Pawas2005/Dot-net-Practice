using System;
using System.Collections.Generic;
using System.Text;

namespace EventDelegateDemo
{
    //Multicast Delegate : if a delefate returns void 
    public delegate void GreetMessage(string msg);

    //Unicast Delegate : if a delegate returns a value
    public delegate int Calculate(int num1, int num2);

    class Hindi
    {
        public void WelcomeMsg(string userName) 
        {
            Console.WriteLine("Namaste " + userName);
        }
    }

    class Tamil
    {
        public void WelcomeMsg(string userName)
        {
            Console.WriteLine("Vanakkam " + userName);
        }
    }

    class Telugu
    {
        public void WelcomeMsg(string userName)
        {
            Console.WriteLine("Namaskaramu " + userName);
        }
    }

    public class Marathi
    {
        public void WelcomeMsg(string userName)
        {
            Console.WriteLine("Namaskar " + userName);
        }
    }

    public class DelegateDemo
    {
        public static void DelegateDemoMain()
        {
            Tamil tObj = new Tamil();
            GreetMessage GreetInTamil = new GreetMessage(tObj.WelcomeMsg);

            Hindi hObj = new Hindi();
            GreetMessage GreetInHindi = new GreetMessage(hObj.WelcomeMsg);

            GreetInTamil("Vivek Don");
        }
    }
}
