using FlixOne.InventoryManagement.Commands.Factories;
using FlixOne.InventoryManagement.Repositories;
using FlixOne.InventoryManagement.Repositories.Abstractions;
using FlixOne.InventoryManagement.UserInterface;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Security.Authentication.ExtendedProtection;

namespace FlixOne.InventoryManagementClient;

public class Program
{
    private static void Main(string[] args)
    {
        IServiceCollection services = new ServiceCollection();
        ConfigureServices(services);
        IServiceProvider serviceProvider = services.BuildServiceProvider();

        var service = serviceProvider.GetService<ICatalogService>();
        service.Run();

        Console.WriteLine("CatalogServise завершен");
        Console.ReadLine();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<IUserInterface, ConsoleUserInterface>();
        services.AddTransient<ICatalogService, CatalogService>();
        services.AddTransient<IInventoryCommandFactory, InventoryCommandFactory>();

        var context = new InventoryContext();
        services.AddSingleton<IInventoryReadContext, InventoryContext>(x => context);
        services.AddSingleton<IInventoryWriteContext, InventoryContext>(x => context);
        services.AddSingleton<IInventoryContext, InventoryContext>(x => context);
    }
}
