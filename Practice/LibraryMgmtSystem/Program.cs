using System;
namespace LibraryMgmtSystem;

public class Program
{
    public static void Main()
    {
        LibrarySystem Libsystem = new LibrarySystem();
        int n = int.Parse(Console.ReadLine());

        for(int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(' ');

            Book book = new Book();
            book.Id = int.Parse(input[0]);
            book.Title = input[1];
            book.Author = input[2];
            book.Category = input[3];
            book.Price = int.Parse(input[4]);
            int quantity = int.Parse(input[5]);

            Libsystem.AddBook(book, quantity);
        }

        Console.WriteLine("Book Info: ");
        foreach(var line in Libsystem.BooksInfo())
            Console.WriteLine(line);

        Console.WriteLine("Category Total Price: ");
        foreach(var line in Libsystem.CategoryTotalPrice())
            Console.WriteLine(line);

        Console.WriteLine("Category And Author With Count:");
        foreach (var line in Libsystem.CategoryAndAuthorWithCount())
            Console.WriteLine(line);

        Console.WriteLine("Total Price: " + Libsystem.CalculateTotal());
    }
}