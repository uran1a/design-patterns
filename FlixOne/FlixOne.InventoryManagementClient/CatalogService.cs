using FlixOne.InventoryManagement.Commands.Factories;
using FlixOne.InventoryManagement.UserInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FlixOne.InventoryManagementClient;

interface ICatalogService
{
    void Run();
}

public class CatalogService : ICatalogService
{
    private readonly IUserInterface _userInterface;
    private readonly IInventoryCommandFactory _commandFactory;

    public CatalogService(IUserInterface userInterface, IInventoryCommandFactory commandFactory)
    {
        _userInterface = userInterface;
        _commandFactory = commandFactory;
    }

    public void Run()
    {
        Greeting();

        var response = _commandFactory.GetCommand("?").RunCommand();

        while (!response.shouldQuit)
        {
            var input = _userInterface.ReadValue(">").ToLower();
            var command = _commandFactory.GetCommand(input);

            response = command.RunCommand();

            if (!response.wasSuccessful)
            {
                _userInterface.WriteMessage("Введите ?, чтобы увидеть опции.");
            }
        }
    }

    private void Greeting()
    {
        var version = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        Console.WriteLine("*********************************************************************************************");
        Console.WriteLine("*                                                                                           *");
        Console.WriteLine("*               Добро пожаловать в FlixOne Систему Управления Инвентаризаций                *");
        Console.WriteLine($"*                                                                                v{version}   *");
        Console.WriteLine("*********************************************************************************************");
        Console.WriteLine("");
    }
}
