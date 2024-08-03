using FlixOne.InventoryManagement.Commands.Abstraсtions;
using FlixOne.InventoryManagement.Repositories;
using FlixOne.InventoryManagement.UserInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlixOne.InventoryManagement.Commands.Inventories
{
    internal class GetInventoriesCommand : NonTerminatingCommand
    {
        private readonly IInventoryContext _context;

        public GetInventoriesCommand(IUserInterface userInterface, IInventoryContext context) : base(userInterface)
        {
            _context = context;
        }

        protected override bool InternalCommand()
        {
            foreach (var book in _context.GetBooks())
            {
                Interface.WriteMessage($"{book.Name, -30}\tQuantity:{book.Quantity}");
            }

            return true;
        }
    }
}
