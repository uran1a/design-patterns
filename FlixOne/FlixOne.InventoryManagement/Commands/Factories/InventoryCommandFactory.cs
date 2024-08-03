using FlixOne.InventoryManagement.Commands.Abstraсtions;
using FlixOne.InventoryManagement.Commands.Inventories;
using FlixOne.InventoryManagement.Commands.Utilities;
using FlixOne.InventoryManagement.Repositories;
using FlixOne.InventoryManagement.UserInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlixOne.InventoryManagement.Commands.Factories;

public interface IInventoryCommandFactory
{
    InventoryCommand GetCommand(string input);
}

public class InventoryCommandFactory : IInventoryCommandFactory
{
    private readonly IUserInterface _userInterface;
    private readonly IInventoryContext _context = InventoryContext.Instance;

    public InventoryCommandFactory(IUserInterface userInterface)
    {
        _userInterface = userInterface;
    }
    public InventoryCommand GetCommand(string input)
    {
        switch (input.ToLower())
        {
            case "q":
            case "quit":
                return new QuitCommand(_userInterface);
            case "a":
            case "add-inventory":
                return new AddInventoryCommand(_userInterface, _context);
            case "g":
            case "get-inventory":
                return new GetInventoryCommand(_userInterface, _context);
            case "u":
            case "update-quantity":
                return new UpdateQuantityCommand(_userInterface, _context);
            case "?":
                return new HelpCommand(_userInterface);
            default:
                return new UnknownCommand(_userInterface);
        }
    }
}
