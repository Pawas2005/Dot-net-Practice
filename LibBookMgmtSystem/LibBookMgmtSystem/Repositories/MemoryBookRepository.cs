using LibBookMgmtSystem.Models;
using LibBookMgmtSystem.Repositories;

namespace LibBookMgmtSystem.Repositories
{
    public class MemoryBookRepository : IBookRepository
    {
        private List<Book> books;
        private int nextId;

        public MemoryBookRepository()
        {
            books = new List<Book>()
            {
                new Book{BookId=1, Title="Clean Code", Author="Robert C. Martin", Price=500},
                new Book{BookId=2, Title="Design Patterns", Author="GoF", Price=600},
                new Book{BookId=3, Title="Refactoring", Author="Martin Fowler", Price=700}
            };
            nextId = 4;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return books;
        }

        public Book GetBookById(int id)
        {
            return books.FirstOrDefault(b => b.BookId == id);
        }

        public void AddBook(Book book)
        {
            book.BookId = nextId++;
            books.Add(book); 
        }

        public void DeleteBook(int id)
        {
            var book = books.FirstOrDefault(b => b.BookId == id);
            if(book != null)
            {
                books.Remove(book);
            }
        }

    }
}
