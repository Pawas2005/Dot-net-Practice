using System;
namespace JewelleryComplexVer;

class Program
{
    static void Main()
    {
        JewelleryUtility utility = new JewelleryUtility();

        while (true)
        {
            Console.WriteLine("\n1 Add");
            Console.WriteLine("2 Display All");
            Console.WriteLine("3 Update Price");
            Console.WriteLine("4 Search By Type");
            Console.WriteLine("5 Exit");
            Console.WriteLine();

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    string input = Console.ReadLine();
                    string[] data = input.Split(' ');

                    Jewellery jewellery = new Jewellery()
                    {
                        Id = data[0],
                        Type = data[1],
                        Material = data[2],
                        Price = double.Parse(data[3])
                    };

                    utility.AddJewellery(jewellery);
                    break;
                
                case 2:
                    utility.DisPlayAll();
                    break;

                case 3:
                    string updatedInp = Console.ReadLine();
                    string[] upd = updatedInp.Split(' ');

                    string id = upd[0];
                    double price = double.Parse(upd[1]);

                    utility.UpdatePrice(id, price);
                    break;

                case 4:
                    string type = Console.ReadLine();
                    utility.SearchByTYpe(type);
                    break;

                case 5:
                    Console.WriteLine("Thank You");
                    return;
            }
        }
    }
}