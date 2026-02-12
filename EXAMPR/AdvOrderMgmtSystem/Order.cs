using System;
namespace AdvOrderManagementSystem
{
    class Order
    {
        public string OrderId { get; set; }
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double PricePerUnit { get; set; }
        public double TotalAmount { get; set; }
        public DateTime OrdersDate { get; set; }
    }
}