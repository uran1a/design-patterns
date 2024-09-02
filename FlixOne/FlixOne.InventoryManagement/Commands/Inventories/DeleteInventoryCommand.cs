using FlixOne.InventoryManagement.Commands.Abstraсtions;
using FlixOne.InventoryManagement.Repositories;
using FlixOne.InventoryManagement.UserInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FlixOne.InventoryManagement.Commands.Inventories;

internal class DeleteInventoryCommand : NonTerminatingCommand, IParameterisedCommand
{
    private readonly IInventoryContext _context;

    private string InventoryName { get; set; }
    public DeleteInventoryCommand(IUserInterface userInterface, IInventoryContext context) : base(userInterface)
    {
        _context = context;
    }

    public bool GetParameters()
    {
        InventoryName = GetParameter("name");

        return !string.IsNullOrWhiteSpace(InventoryName);
    }

    protected override bool InternalCommand()
    {
        _context.DeleteBook(InventoryName);

        return true;
    }
}
