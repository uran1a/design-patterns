using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlixOne.InventoryManagement.Commands.Abstraсtions;

internal interface IParameterisedCommand
{
    bool GetParameters();
}
