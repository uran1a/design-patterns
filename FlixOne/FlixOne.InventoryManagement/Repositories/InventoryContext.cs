using FlixOne.InventoryManagement.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlixOne.InventoryManagement.Repositories
{
    public interface IInventoryContext
    {
        public Book[] GetBooks();
        public bool AddBook(string name);
        public bool UpdateQuantity(string name, int quantity);
    }
    internal class InventoryContext : IInventoryContext
    {
        private static InventoryContext _context;
        private static object _lock = new object();

        private readonly IDictionary<string, Book> _books;

        public static InventoryContext Instance
        {
            get
            {
                if(_context == null)
                {
                    lock (_lock)
                    {
                        if(_context == null)
                        {
                            _context = new InventoryContext();
                        }
                    }
                }
                return _context;
            }
        }

        protected InventoryContext()
        {
            _books = new ConcurrentDictionary<string, Book>();
        }
        public bool AddBook(string name)
        {
            _books.Add(name, new Book() { Name = name });
            return true;
        }

        public Book[] GetBooks()
        {
            return _books.Values.ToArray();
        }

        public bool UpdateQuantity(string name, int quantity)
        {
            lock (_lock)
            {
                _books[name].Quantity += quantity;
            }

            return true;
        }
    }
}
