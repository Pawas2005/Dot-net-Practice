using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AdvOrderManagementSystem
{
    class OrderUtility
    {
        private List<Order> OrderList = new List<Order>();

        public double CalculateTotal(int qty, double price)
        {
            double total = qty * price;

            if(total >= 50000)
            {
                total *= 0.90;
            }
            else if(total >= 20000)
            {
                total *= 0.95;
            }

            return total;
        }

        // 1️⃣ AddOrder(Order order)
        public void AddOrder(Order order)
        {
            order.TotalAmount = CalculateTotal(order.Quantity, order.PricePerUnit);
            order.OrdersDate = DateTime.Now;
            OrderList.Add(order);

            Console.WriteLine("Order Added Successfully");
            Console.WriteLine($"Final Amount: {order.TotalAmount}");
        }

        //2️⃣ DisplayOrders()
        public void DisplayOrders()
        {
            if(OrderList.Count == 0)
            {
                Console.WriteLine("No Offers available.");
                return;
            }

            foreach(var o in OrderList)
            {
                Console.WriteLine($"{o.OrderId} {o.CustomerName} {o.ProductName} {o.Quantity} {o.TotalAmount} {o.OrdersDate}");
            }
        }

        // 3️⃣ UpdateOrderQuantity(string id, int qty)
        public void UpdateOrderQuantity(string id, int qty)
        {
            var item = OrderList.FirstOrDefault(o => o.OrderId == id);

            if(item != null)
            {
                item.Quantity = qty;
                item.TotalAmount = CalculateTotal(qty, item.PricePerUnit);
                
                Console.WriteLine($"Updated Successfully");
            }
            else
            {
                Console.WriteLine("Order Not Found");
            }
        }

        //4️⃣ DeleteOrder(string id)
        public void DeleteOrder(string id)
        {
            var order = OrderList.FirstOrDefault(o => o.OrderId == id);

            if(order != null)
            {
                OrderList.Remove(order);
                Console.WriteLine("Order Deleted Successfully");
            }
            else
            {
                Console.WriteLine("Order Not Found");
            }
        }

        // 5️⃣ SearchOrder(string id)
        public void SearchOrder(string id)
        {
            var order = OrderList.FirstOrDefault(o => o.OrderId == id);

            if(order != null)
            {
                Console.WriteLine($"Found: {order.OrderId} {order.CustomerName} {order.TotalAmount}");
            }
            else
            {
                Console.WriteLine("Order Not Found");
            }
        }
        
        // 6️⃣ SortOrdersByAmount()
        public void SortOrdersByAmount()
        {
            var sorted = OrderList.OrderBy(o => o.TotalAmount);

            foreach(var o in sorted)
            {
                Console.WriteLine($"{o.OrderId} {o.CustomerName} {o.TotalAmount}");
            }
        }
    }
}