using FlixOne.InventoryManagement.UserInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlixOne.InventoryManagementClient;

internal class ConsoleUserInterface : IUserInterface
{
    public string ReadValue(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(message);
        Console.ForegroundColor = ConsoleColor.White;
        return Console.ReadLine();
    }

    public void WriteMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.White;
    }

    public void WriteWarning(string message)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.White;
    }
}
