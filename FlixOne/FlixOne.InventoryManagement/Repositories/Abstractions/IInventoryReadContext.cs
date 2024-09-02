using FlixOne.InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlixOne.InventoryManagement.Repositories.Abstractions
{
    public interface IInventoryReadContext
    {
        public Book[] GetBooks();
    }
}
