using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core
{
    public class DbClient : IDbClient
    {
        private readonly IMongoCollection<Book> _books;

        public DbClient(IOptions<BookStoreDbConfig> bookStoreDbConfig)
        {
            var client = new MongoClient(bookStoreDbConfig.Value.Connection_String);
            var database = client.GetDatabase(bookStoreDbConfig.Value.Books_Collection_Name);
            _books = database.GetCollection<Book>(bookStoreDbConfig.Value.Books_Collection_Name);
        }

        public IMongoCollection<Book> GetMongoCollection() => _books;
        
    }
}
