using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LibraryManagementSystem;

public class LibraryUtility
{
    private List<Book> books = new List<Book>();
    private int bookCounter = 1;

    public void AddBook(string title, string author, string genre, int year)
    {
        books.Add(new Book
        {
            ID = bookCounter++,
            Title = title,
            Author = author,
            Genre = genre,
            PublicationYear = year
        });
    }

    public SortedDictionary<string, List<Book>> GroupBooksByGenre()
    {
        SortedDictionary<string, List<Book>> grouped = new SortedDictionary<string, List<Book>>();

        foreach(var book in books)
        {
            if (!grouped.ContainsKey(book.Genre))
            {
                grouped[book.Genre] = new List<Book>();
            }
            grouped[book.Genre].Add(book);
        }
        return grouped;
    }

    public List<Book> GetBooksByAuthor(string author)
    {
        return books.Where(b => b.Author.Contains(author, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public int GetTotalBooksCount()
    {
        return books.Count;
    }
}