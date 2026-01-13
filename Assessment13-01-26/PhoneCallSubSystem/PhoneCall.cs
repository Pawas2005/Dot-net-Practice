using System;

namespace PhoneCallSubSystem
{
    //1. Define a delegate method with no parameters and no return type.
    public delegate void Notify();

    public class PhoneCall
    {
        //2. Declare an event
        public event Notify PhoneCallEvent;

        // 3. Message Property
        public string Message { get; private set; }

        //4. Event Handlers ---> a. OnSubscribe   b. OnUnSubscribe
        private void OnSubscribe()
        {
            Message = "Subscribed to Call";
        }

        private void OnUnSubscribe()
        {
            Message = "UnSubscribed to Call";
        }

        // 5. Event Trigger Method        
        public void MakeAPhoneCall(bool notify)
        {
            PhoneCallEvent = null;

            if (notify)
            {
                PhoneCallEvent += OnSubscribe;
            }
            else
            {
                PhoneCallEvent += OnUnSubscribe;
            }

            PhoneCallEvent?.Invoke();
        }
    }
}