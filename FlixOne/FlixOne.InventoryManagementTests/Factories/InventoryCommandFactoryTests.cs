using FlixOne.InventoryManagement.Commands.Factories;
using FlixOne.InventoryManagement.Commands.Inventories;
using FlixOne.InventoryManagement.Commands.Utilities;
using FlixOne.InventoryManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlixOne.InventoryManagementTests.Factories;

/// <summary>
/// Quit Command Tests
/// </summary>
/// <remarks>
/// A quit command ("q", "quit") is available
///     prints a farewell message
///     ends the application
/// </remarks>
[TestClass]
public class InventoryCommandFactoryTests
{
    public InventoryCommandFactory Factory { get; set; }
    public InventoryContext Context { get; set; }

    [TestInitialize]
    public void Initialize()
    {
        var expectedInterface = new Helpers.TestUserInterface(
            new List<Tuple<string, string>>(),
            new List<string>(),
            new List<string>()
        );

        Context = new InventoryContext();
        Factory = new InventoryCommandFactory(expectedInterface, Context);
    }

    [TestMethod]
    public void QuitCommand_Successful()
    {
        Assert.IsInstanceOfType(Factory.GetCommand("q"), typeof(QuitCommand), "q should be QuitCommand");
        Assert.IsInstanceOfType(Factory.GetCommand("quit"), typeof(QuitCommand), "quit should be QuitCommand");
    }

    [TestMethod]
    public void HelpCommand_Successful()
    {
        Assert.IsInstanceOfType(Factory.GetCommand("?"), typeof(HelpCommand), "h should be HelpCommand");
    }

    [TestMethod]
    public void UnknownCommand_Successful()
    {
        Assert.IsInstanceOfType(Factory.GetCommand("add"), typeof(UnknownCommand), "unmatched command should be UnknownCommand");
        Assert.IsInstanceOfType(Factory.GetCommand("add-inventry"), typeof(UnknownCommand), "unmatched command should be UnknownCommand");
        Assert.IsInstanceOfType(Factory.GetCommand("h"), typeof(UnknownCommand), "unmatched command should be UnknownCommand");
        Assert.IsInstanceOfType(Factory.GetCommand("help"), typeof(UnknownCommand), "unmatched command should be UnknownCommand");
    }

    [TestMethod]
    public void AddInventoryCommand_Successful()
    {
        Assert.IsInstanceOfType(Factory.GetCommand("a"), typeof(AddInventoryCommand), "a should be AddInventoryCommand");
        Assert.IsInstanceOfType(Factory.GetCommand("add-inventory"), typeof(AddInventoryCommand), "add-inventory should be AddInventoryCommand");
    }

    [TestMethod]
    public void GetInventoryCommand_Successful()
    {
        Assert.IsInstanceOfType(Factory.GetCommand("g"), typeof(GetInventoryCommand), "g should be GetInventoryCommand");
        Assert.IsInstanceOfType(Factory.GetCommand("get-inventory"), typeof(GetInventoryCommand), "get-inventory should be GetInventoryCommand");
    }

    [TestMethod]
    public void UpdateQuantityCommand_Successful()
    {
        Assert.IsInstanceOfType(Factory.GetCommand("u"), typeof(UpdateQuantityCommand), "u should be UpdateQuantityCommand");
        Assert.IsInstanceOfType(Factory.GetCommand("update-quantity"), typeof(UpdateQuantityCommand), "update-quantity should be UpdateQuantityCommand");
        Assert.IsInstanceOfType(Factory.GetCommand("UpdaTE-Quantity"), typeof(UpdateQuantityCommand), "UpdaTE-Quantity should be UpdateQuantityCommand");
    }

    [TestMethod]
    public void DeleteInventoryCommand_Successful()
    {
        Assert.IsInstanceOfType(Factory.GetCommand("d"), typeof(DeleteInventoryCommand), "u should be DeleteInventoryCommand");
        Assert.IsInstanceOfType(Factory.GetCommand("delete-inventory"), typeof(DeleteInventoryCommand), "delete-inventory should be DeleteInventoryCommand");
    }
}
