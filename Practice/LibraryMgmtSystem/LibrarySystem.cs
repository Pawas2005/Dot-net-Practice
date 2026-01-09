using System;
using System.Runtime.InteropServices;
namespace LibraryMgmtSystem;

public class LibrarySystem : ILibrarySystem
{
    private Dictionary<IBook, int> _books = new Dictionary<IBook, int>();

    //Add Book
    public void AddBook(IBook book ,int quantity)
    {
        if (_books.ContainsKey(book))
        {
            _books[book] += quantity;
        }
        else
        {
            _books.Add(book, quantity);
        }
    }

    //Removing Book
    public void RemoveBook(IBook book, int quantity)
    {
        if (_books.ContainsKey(book))
        {
            _books[book] -= quantity;
            if(_books[book] <= 0)
            {
                _books.Remove(book);
            }
        }
    }

    public int CalculateTotal()
    {
        int total = 0;
        foreach(var item in _books)
        {
            total += item.Key.Price * item.Value;
        }

        return total;
    }

    public List<String> CategoryTotalPrice()
    {
        Dictionary<string, int> categoryTotals = new Dictionary<string, int>();

        foreach(var item in _books)
        {
            string category = item.Key.Category;
            int totalPrice = item.Key.Price * item.Value;

            if (categoryTotals.ContainsKey(category))
            {
                categoryTotals[category] += totalPrice;
            }
            else
            {
                categoryTotals.Add(category, totalPrice);
            }
        }

        List<string> result = new List<string>();
        foreach(var item in categoryTotals)
        {
            result.Add("Category:" + item.Key + ", Total Price :" + item.Value);
        }

        return result;
    }

    public List<String> BooksInfo()
    {
        List<string> result = new List<string>();

        foreach(var item in _books)
        {
            string line = "Book Name:" + item.Key.Title + 
                        ", Quantity:" + item.Value +
                        ", Price:" + item.Key.Price;
            
            result.Add(line);
        }
        return result;
    }

    public List<String> CategoryAndAuthorWithCount()
    {
        Dictionary<string, int> data = new Dictionary<string, int>();

        foreach(var item in _books)
        {
            string key = item.Key.Category + "|" + item.Key.Author;

            if (data.ContainsKey(key))
            {
                data[key] += item.Value;
            }
            else
            {
                data.Add(key, item.Value);
            }
        }

        List<string> res = new List<string>();

        foreach(var item in data)
        {
            string[] parts = item.Key.Split('|');
            string category = parts[0];
            string author = parts[1];

            res.Add("Category: " + category +
                    ", Author: " + author +
                    ", Count: " + item.Value); 
        }

        return res;
    }
}