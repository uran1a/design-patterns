﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlixOne.InventoryManagementClient.ImplemenationFactoryTests;

/// <summary>
/// Этот пример не использует комманды из FlixOne.InventoryManagement, а вместо этого использует классы, 
/// созданные только для иллюстрации использования ServiceProvider.Services() для определения зависимости InventoryCommand.
/// </summary>

[TestClass]
public class InventoryCommandServicesTests
{
    ServiceProvider Services { get; set; }

    [TestInitialize]
    public void Startup()
    {
        IServiceCollection services = new ServiceCollection();
        services.AddTransient<InventoryCommand, QuitCommand>();
        services.AddTransient<InventoryCommand, HelpCommand>();
        services.AddTransient<InventoryCommand, AddInventoryCommand>();
        services.AddTransient<InventoryCommand, GetInventoryCommand>();
        services.AddTransient<InventoryCommand, UpdateQuantityCommand>();
        services.AddTransient<InventoryCommand, UnknownCommand>();

        Services = services.BuildServiceProvider();
    }

    public InventoryCommand GetCommand(string input)
    {
        return Services.GetServices<InventoryCommand>().First(service => service.IsCommandFor(input));
    }

    [TestMethod]
    public void QuitCommand_Successful()
    {
        Assert.IsInstanceOfType(GetCommand("q"), typeof(QuitCommand), "q should be QuitCommand");
        Assert.IsInstanceOfType(GetCommand("quit"), typeof(QuitCommand), "quit should be QuitCommand");
    }

    [TestMethod]
    public void HelpCommand_Successful()
    {
        Assert.IsInstanceOfType(GetCommand("?"), typeof(HelpCommand), "? should be HelpCommand");
    }

    [TestMethod]
    public void UnknownCommand_Successful()
    {
        Assert.IsInstanceOfType(GetCommand("add"), typeof(UnknownCommand), "unmatched command should be UnknownCommand");
        Assert.IsInstanceOfType(GetCommand("addinventry"), typeof(UnknownCommand), "unmatched command should be UnknownCommand");
        Assert.IsInstanceOfType(GetCommand("h"), typeof(UnknownCommand), "unmatched command should be UnknownCommand");
        Assert.IsInstanceOfType(GetCommand("help"), typeof(UnknownCommand), "unmatched command should be UnknownCommand");
    }

    [TestMethod]
    public void AddInventoryCommand_Successful()
    {
        Assert.IsInstanceOfType(GetCommand("a"), typeof(AddInventoryCommand), "a should be AddInventoryCommand");
        Assert.IsInstanceOfType(GetCommand("addinventory"), typeof(AddInventoryCommand), "addinventory should be AddInventoryCommand");
    }

    [TestMethod]
    public void GetInventoryCommand_Successful()
    {
        Assert.IsInstanceOfType(GetCommand("g"), typeof(GetInventoryCommand), "g should be GetInventoryCommand");
        Assert.IsInstanceOfType(GetCommand("getinventory"), typeof(GetInventoryCommand), "getinventory should be GetInventoryCommand");
    }

    [TestMethod]
    public void UpdateQuantityCommand_Successful()
    {
        Assert.IsInstanceOfType(GetCommand("u"), typeof(UpdateQuantityCommand), "u should be UpdateQuantityCommand");
        Assert.IsInstanceOfType(GetCommand("updatequantity"), typeof(UpdateQuantityCommand), "updatequantity should be UpdateQuantityCommand");
        Assert.IsInstanceOfType(GetCommand("UpdaTEQuantity"), typeof(UpdateQuantityCommand), "UpdaTEQuantity should be UpdateQuantityCommand");
    }
}
