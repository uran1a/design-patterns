using FlixOne.InventoryManagement.Commands.Abstraсtions;
using FlixOne.InventoryManagement.UserInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlixOne.InventoryManagement.Commands.Utilities;

internal class UnknownCommand : NonTerminatingCommand
{
    internal UnknownCommand(IUserInterface userInterface) : base(userInterface) { }

    protected override bool InternalCommand()
    {
        Interface.WriteWarning("Не удается определить нужную команду.");

        return false;
    }
}
