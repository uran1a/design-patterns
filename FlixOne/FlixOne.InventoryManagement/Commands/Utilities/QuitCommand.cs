using FlixOne.InventoryManagement.Commands.Abstraсtions;
using FlixOne.InventoryManagement.UserInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlixOne.InventoryManagement.Commands.Utilities;

internal class QuitCommand : InventoryCommand
{
    internal QuitCommand(IUserInterface userInterface) : base(true, userInterface) { }
    protected override bool InternalCommand()
    {
        Interface.WriteMessage("Благодарим вас за использование системы управления инвентаризаций FlixOne.");

        return true;
    }
}
