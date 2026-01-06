using System;
using System.Collections.Generic;

namespace CustomerPropertyDemo
{
    struct Customer1 //value type in Csharp
    {
        int id;
        string name;
        //public int ID { get; set;  }
        //public string Name { get; set; }

        public Customer1(int id1, string nm) 
        {
            id = id1;
            name = nm;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Init Customer Object

            Customer CustObj = new Customer();

            CustObj.CustId = 101;
            CustObj.Name = "Alok";

            //Init the Shipping Address

            CustObj.ShippingAddr = new Address();
            CustObj.ShippingAddr.FlatNo = 1801;
            CustObj.ShippingAddr.BuildingName = "Sky Tower";
            CustObj.ShippingAddr.Street = "MG Road";
            CustObj.ShippingAddr.Locality = "Wakad";
            CustObj.ShippingAddr.City = "Pune";

            //1 Customer-Have-Many Orders

            CustObj.MyOrders = new List<Orders>()
            {
                new Orders{ OrderID = 1121, OrderDate = new DateTime(2001,12,22), Amount = 899000},
                new Orders{ OrderID = 1141, OrderDate = new DateTime(2001,12,12), Amount = 78000},
                new Orders{ OrderID = 1161, OrderDate = new DateTime(2001,12,2), Amount = 1400023},
                new Orders{ OrderID = 1181, OrderDate = new DateTime(2001,12,29), Amount = 140000},
            };
        }
    }
}