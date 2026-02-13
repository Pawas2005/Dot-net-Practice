using System;
using System.Diagnostics;
namespace InventoryMgmtSystem;

public class Program
{
    public static void Main()
    {
        ProductUtility utility = new ProductUtility();

        while (true)
        {
            Console.WriteLine("\n1 Add Product");
            Console.WriteLine("2 Display All Products");
            Console.WriteLine("3 Update Quantity");
            Console.WriteLine("4 Search Product");
            Console.WriteLine("5 Delete Product");
            Console.WriteLine("6 Sort By Stock Value");
            Console.WriteLine("7 Exit");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    string input = Console.ReadLine();
                    string[] data = input.Split(' ');

                    Product product = new Product()
                    {
                        ProductId = data[0],
                        ProductName = data[1],
                        Quantity = int.Parse(data[2]),
                        PricePerUnit = double.Parse(data[3])
                    };

                    utility.AddProduct(product);
                    break;

                case 2:
                    utility.DisplayProducts();
                    break;

                case 3:
                    string up = Console.ReadLine();
                    string[] upd = up.Split(' ');

                    utility.UpdateQuantity(upd[0], int.Parse(upd[1]));
                    break;

                case 4:
                    string search = Console.ReadLine();

                    utility.SearchProduct(search);
                    break;

                case 5:
                    string del = Console.ReadLine();

                    utility.DeleteProduct(del);
                    break;


                case 6:
                    utility.SortByStockValue();
                    break;

                case 7:
                    Console.WriteLine("Thank you");
                    return;
            }
        }
    }
}