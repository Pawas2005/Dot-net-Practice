using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace HotelRoomBookingSystem;

public class HotelManager
{
    private List<Room> rooms = new List<Room>();

    public void AddRoom(int roomNumber, string type, double price)
    {
        if(rooms.Any(r => r.RoomNumber == roomNumber))
        {
            Console.WriteLine($"{roomNumber} already exists.");
            return;
        }

        rooms.Add(new Room
        {
           RoomNumber = roomNumber,
           RoomType = type, 
           PricePerNight = price,
           IsAvailable = true
        });
    }

    public Dictionary<string, List<Room>> GroupRoomsByType()
    {
        return rooms
            .Where(r => r.IsAvailable)
            .GroupBy(r => r.RoomType)
            .ToDictionary(g => g.Key, g => g.ToList());
    }
    
    public bool BookRoom(int roomNumber, int nights)
    {
        var room = rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);

        if(room == null)
        {
            Console.WriteLine("Room not found.");
            return false;
        }

        if (!room.IsAvailable)
        {
            Console.WriteLine("Room already booked.");
            return false;
        }

        double totalCost = room.PricePerNight * nights;

        room.IsAvailable = false;
        Console.WriteLine($"Room {roomNumber} booked for {nights} nights. Total Cost = {totalCost}");

        return true;
    }

    public List<Room> GetAvailableRoomsByPriceRange(double min, double max)
    {
        return rooms.Where
                (r => r.IsAvailable && 
                r.PricePerNight >= min && 
                r.PricePerNight <= max).ToList();
    }
}