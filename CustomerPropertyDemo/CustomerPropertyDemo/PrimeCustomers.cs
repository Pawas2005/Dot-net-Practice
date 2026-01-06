using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerPropertyDemo
{
    class PrimeCustomers : Customer
    {
        public List<Orders> MyPrimeOrders //Write only property
        {
            set
            {
                MyOrders = value;
            }
        }
    }
}
