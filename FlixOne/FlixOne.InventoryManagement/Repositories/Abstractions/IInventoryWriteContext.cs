using FlixOne.InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlixOne.InventoryManagement.Repositories.Abstractions
{
    public interface IInventoryWriteContext
    {
        public bool AddBook(string name);
        public bool UpdateQuantity(string name, int quantity);
        public bool DeleteBook(string name);
    }
}
