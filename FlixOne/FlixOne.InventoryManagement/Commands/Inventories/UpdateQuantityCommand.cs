using FlixOne.InventoryManagement.Commands.Abstraсtions;
using FlixOne.InventoryManagement.Repositories;
using FlixOne.InventoryManagement.UserInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlixOne.InventoryManagement.Commands.Inventories;

internal class UpdateQuantityCommand : NonTerminatingCommand, IParameterisedCommand
{
    private readonly IInventoryContext _context;
    
    internal UpdateQuantityCommand(IUserInterface userInterface, IInventoryContext context) : base(userInterface)
    {
        _context = context;
    }

    internal string InventoryName { get; private set; }

    private int _quantity;
    internal int Quantity { get => _quantity; private set => _quantity = value; }

    /// <summary>
    /// UpdateQuantity требуется название и целочисленные значение
    /// </summary>
    /// <returns></returns>
    public bool GetParameters()
    {
        if (string.IsNullOrWhiteSpace(InventoryName))
            InventoryName = GetParameter("name");

        if (Quantity == 0)
            int.TryParse(GetParameter("quantity"), out _quantity);

        return !string.IsNullOrWhiteSpace(InventoryName) && Quantity != 0;
    }

    protected override bool InternalCommand()
    {
        throw new NotImplementedException();
    }
}
