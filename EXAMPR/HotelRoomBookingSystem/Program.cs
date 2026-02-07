using System;
namespace HotelRoomBookingSystem;

public class Program
{
    public static void Main()
    {
        HotelManager hotelManager = new HotelManager();

        // Add Rooms
        hotelManager.AddRoom(101, "Single", 2000);
        hotelManager.AddRoom(102, "Double", 3500);
        hotelManager.AddRoom(103, "Suite", 6000);
        hotelManager.AddRoom(104, "Single", 2200);
        hotelManager.AddRoom(105, "Double", 4000);

        // Group By Type
        Console.WriteLine("Available Rooms Grouped By Type:\n");
        var grouped = hotelManager.GroupRoomsByType();
        
        foreach(var type in grouped)
        {
            Console.WriteLine($"Room Type: {type.Key}");
            foreach(var room in type.Value)
            {
                Console.WriteLine($" {room}");
            }
            Console.WriteLine();
        }

        //Book ROom
        Console.WriteLine("Enter RoomNumber to book: ");
        int roomNumber = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Nights: ");
        int nights = int.Parse(Console.ReadLine());
        hotelManager.BookRoom(roomNumber, nights);

        //PriceRange Search
        Console.WriteLine("\nEnter Min Price:");
        double min = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter Max Price:");
        double max = double.Parse(Console.ReadLine());

        var rooms = hotelManager.GetAvailableRoomsByPriceRange(min, max);

        Console.WriteLine("\nRooms Within Budget: ");
        foreach(var room in rooms)
        {
            Console.WriteLine(room);
        }
    }
}