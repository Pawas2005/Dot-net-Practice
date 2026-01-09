using System;
using System.ComponentModel;
namespace LibraryMgmtSystem;

public interface ILibrarySystem
{
    void AddBook(IBook Book, int quantity);
    void RemoveBook(IBook Book, int quantity);
    int CalculateTotal();
    List<string> CategoryTotalPrice();
    List<string> BooksInfo();
    List<string> CategoryAndAuthorWithCount();
}