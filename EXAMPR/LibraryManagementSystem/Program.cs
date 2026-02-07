using System;
namespace LibraryManagementSystem;

public class Program
{
    public static void Main()
    {
        LibraryUtility libraryUtility = new LibraryUtility();

        libraryUtility.AddBook("The Hobbit", "J.R.R. Tolkien", "Fiction", 1937);
        libraryUtility.AddBook("Sherlock Holmes", "Arthur Conan Doyle", "Mystery", 1892);
        libraryUtility.AddBook("Sapiens", "Yuval Noah Harari", "Non-Fiction", 2011);
        libraryUtility.AddBook("LOTR", "J.R.R. Tolkien", "Fiction", 1954);

        Console.WriteLine("Books Grouped By Genre: ");
        var grouped = libraryUtility.GroupBooksByGenre();

        foreach(var genre in grouped)
        {
            Console.WriteLine($"Genre: {genre.Key}");
            foreach(var book in genre.Value)
            {
                Console.WriteLine($" {book}");
            }
            Console.WriteLine();
        }

        Console.WriteLine("Enter Author Name to Search: ");
        string authorName = Console.ReadLine();

        var authorBooks = libraryUtility.GetBooksByAuthor(authorName);
        if(authorBooks.Count > 0)
        {
            Console.WriteLine($"\nBooks by {authorName}:\n");
            foreach(var book in authorBooks)
            {
                Console.WriteLine(book);
            }
        }
        else
        {
            Console.WriteLine($"\nNo books found for author: {authorName}");
        }

        Console.WriteLine("\nStatistics:");
        Console.WriteLine($"Total Books: {libraryUtility.GetTotalBooksCount()}");
    }
}