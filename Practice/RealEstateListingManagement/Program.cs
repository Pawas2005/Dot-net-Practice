using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RealEstateListingManagement;

public class Program
{
    public static void Main()
    {
        RealEstateApp app = new RealEstateApp();
        int choice = 0;

        do
        {
            Console.WriteLine("=======REAL ESTATE MANAGEMNT=========");
            Console.WriteLine("1. Add Listing");
            Console.WriteLine("2. Remove Listing");
            Console.WriteLine("3. Update Listing");
            Console.WriteLine("4. View all Listings");
            Console.WriteLine("5. Search By Location");
            Console.WriteLine("6. Search By Price Range");
            Console.WriteLine("7. Exit");
            Console.Write("Enter Your Choice : ");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddListing(app);
                    break;
                case 2:
                    Console.Write("Enter the id to remove : ");
                    int rId = int.Parse(Console.ReadLine());
                    app.RemoveListing(rId);
                    break;
                case 3:
                    UpdateListing(app);
                    break;
                case 4:
                    Display(app.GetListings());
                    break;
                case 5:
                    Console.Write("Enter the location to search : ");
                    string loc = Console.ReadLine();
                    Display(app.GetListingsByLocation(loc));
                    break;
                case 6:
                    Console.Write("Enter min price: ");
                    int min = int.Parse(Console.ReadLine());
                    Console.Write("Enter max price: ");
                    int max = int.Parse(Console.ReadLine());
                    Display(app.GetListingsByPriceRange(min, max));
                    break;
                case 7:
                    Console.WriteLine("Thank you!");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }while (choice != 7);
    }

    public static void AddListing(RealEstateApp app)
    {
        RealEstateListing listing = new RealEstateListing();

        Console.Write("Enter the ID : ");
        listing.ID = int.Parse(Console.ReadLine());

        Console.Write("Enter the Title : ");
        listing.Title = Console.ReadLine();

        Console.Write("Enter Description : ");
        listing.Description = Console.ReadLine();

        Console.Write("Enter the Price : ");
        listing.Price = int.Parse(Console.ReadLine());

        Console.Write("Enter the Location : ");
        listing.Location = Console.ReadLine();

        app.AddListing(listing);
        Console.WriteLine("Listing added successfully.");
    }

    public static void UpdateListing(RealEstateApp app)
    {
        RealEstateListing listing = new RealEstateListing();

        Console.Write("Enter ID to update: ");
        listing.ID = int.Parse(Console.ReadLine());

        Console.Write("Enter new Title: ");
        listing.Title = Console.ReadLine();

        Console.Write("Enter new Description: ");
        listing.Description = Console.ReadLine();

        Console.Write("Enter new Price: ");
        listing.Price = int.Parse(Console.ReadLine());

        Console.Write("Enter new Location: ");
        listing.Location = Console.ReadLine();

        app.UpdateListing(listing);
        Console.WriteLine("Listing updated successfully.");
    }

    public static void Display(List<RealEstateListing> list)
    {
        if(list.Count == 0)
        {
            Console.WriteLine("No listings found.");
            return;
        }

        Console.WriteLine("\nID | Title | Location | Price");
        Console.WriteLine("--------------------------------");

        foreach(var item in list)
        {
            Console.WriteLine($"{item.ID} | {item.Title} | {item.Location} | {item.Price}");
        }
    }
}