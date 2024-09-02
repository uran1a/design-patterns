using FlixOne.InventoryManagement.Models;
using FlixOne.InventoryManagement.Repositories.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlixOne.InventoryManagement.Repositories
{
    public interface IInventoryContext : IInventoryReadContext, IInventoryWriteContext { }
    public class InventoryContext : IInventoryContext
    {
        private static object _lock = new object();

        private readonly IDictionary<string, Book> _books;

        public InventoryContext()
        {
            _books = new ConcurrentDictionary<string, Book>();
        }

        private IInventoryContext GetInventoryContext()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IInventoryContext, IInventoryContext>();
            var provider = services.BuildServiceProvider();

            return provider.GetService<IInventoryContext>();
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

        public bool DeleteBook(string name)
        {
            _books.Remove(name);

            return true;
        }
    }
}
