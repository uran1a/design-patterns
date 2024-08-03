using FlixOne.InventoryManagement.UserInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlixOne.InventoryManagement.Commands.Abstraсtions;

internal abstract class NonTerminatingCommand : InventoryCommand
{
    protected NonTerminatingCommand(IUserInterface userInterface) : base(commandIsTerminating: false, userInterface) { }
}
