using System;
using System.Collections.Generic;

namespace WakeMeAWish;

class Program
{
    static void Main()
    {
        CakeOrder cakeOrder = new CakeOrder();

        Console.WriteLine("Enter number of cake orders to be added");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the cake order details (Order Id:CakeCost)");
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(':');
            cakeOrder.addOrderDetails(input[0], double.Parse(input[1]));
        }

        Console.WriteLine("Enter the cost to search the cake orders");
        double cost = double.Parse(Console.ReadLine());

        Dictionary<string, double> result = cakeOrder.findOrdersAboveSpecifiedCost(cost);

        if (result.Count == 0)
        {
            Console.WriteLine("No cake orders found");
        }
        else
        {
            Console.WriteLine("Cake Orders above the specified cost");
            foreach (var item in result)
            {
                Console.WriteLine($"Order ID: {item.Key}, Cake Cost: {item.Value:F1}");
            }
        }
    }
}
