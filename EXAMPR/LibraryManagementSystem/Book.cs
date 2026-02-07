using System;

namespace LibraryManagementSystem;

public class Book
{
    public int ID { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public int PublicationYear { get; set; }

    public override string ToString()
    {
        return $"ID: {ID}, Title: {Title}, Author: {Author}, Genre: {Genre}, Year: {PublicationYear}";
    }
}