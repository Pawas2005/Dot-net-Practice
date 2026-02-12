using System;

namespace AdvOrderManagementSystem
{
    class Program
    {
        static void Main()
        {
            OrderUtility utility = new OrderUtility();

            Console.WriteLine("1 Add Order");
            Console.WriteLine("2 Display All Orders");
            Console.WriteLine("3 Update Quantity");
            Console.WriteLine("4 Delete Order");
            Console.WriteLine("5 Search Order");
            Console.WriteLine("6 Sort By Amount");
            Console.WriteLine("7 Exit");

            while (true)
            {
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        string input = Console.ReadLine();
                        string[] data = input.Split(' ');

                        Order order = new Order()
                        {
                            OrderId = data[0],
                            CustomerName = data[1],
                            ProductName = data[2],
                            Quantity = int.Parse(data[3]),
                            PricePerUnit = int.Parse(data[4])
                        };

                        utility.AddOrder(order);
                        break;

                    case 2:
                        utility.DisplayOrders();
                        break;

                    case 3:
                        string up = Console.ReadLine();
                        string[] upd = up.Split(' ');

                        utility.UpdateOrderQuantity(upd[0], int.Parse(upd[1]));
                        break;

                    case 4:
                        string id = Console.ReadLine();

                        utility.DeleteOrder(id);
                        break;

                    case 5:
                        string idd = Console.ReadLine();

                        utility.SearchOrder(idd);
                        break;

                    case 6:
                        utility.SortOrdersByAmount();
                        break;

                    case 7:
                        Console.WriteLine("Thank You");
                        return;
                }
            }
        }
    }
}