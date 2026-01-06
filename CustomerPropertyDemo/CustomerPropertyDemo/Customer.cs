using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerPropertyDemo
{
    class Customer
    {
        List<Orders> orderList;

        public Customer()
        {
            orderList = new List<Orders>();

        }
        public int CustId { get; set; }
        public string Name { get; set; }
        public Address BillingAddr { get; set; }
        public Address ShippingAddr { get; set; }
        public List<Orders> MyOrders
        {
            get
            {
                return orderList;
            }
            protected set
            {
                orderList = value;
            }
        }
    }
}
