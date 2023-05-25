using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core
{
    public class BookService : IBookService
    {
        private readonly IMongoCollection<Book> _books;

        public BookService(IDbClient dbClient)
        {
            _books = dbClient.GetMongoCollection();
        }

        public Book AddBook(Book book)
        {
            _books.InsertOne(book);
            return book;
        }

        public void DeleteBook(string id)
        {
            _books.DeleteOne(book => book.Id == id);
        }

        public Book GetBook(string id)
        {
            return _books.Find(book => book.Id == id).First();
        }

        public List<Book> GetBooks()
        {
            return _books.Find(book=>true).ToList();

        }

        public Book UpdateBook(Book book)
        {
            GetBook(book.Id);
            _books.ReplaceOne(b => b.Id == book.Id, book);
            return book;
        }
    }
}
