using FlixOne.InventoryManagement.Commands.Inventories;
using FlixOne.InventoryManagement.Models;
using FlixOne.InventoryManagementTests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlixOne.InventoryManagementTests.Inventories;
/// <summary>
/// GetInventory Command Tests
/// </summary>
/// <remarks>
/// A get inventory command ("g", "getinventory") is available
///     returns all the books and their quantities in the database
/// </remarks>
[TestClass]
public class GetInventoryCommandTests
{
    [TestMethod]
    public void GetInventoryCommand_Successful()
    {
        var expectedInterface = new TestUserInterface(
                new List<Tuple<string, string>>(),
                new List<string>
                {
                    "Gremlins                      \tQuantity:7",
                    "Willowsong                    \tQuantity:3",
                },
                new List<string>()
            );
        var context = new TestInventoryContext(new Dictionary<string, Book>
            {
                { "Gremlins", new Book { Id = 1, Name = "Gremlins", Quantity = 7 } },
                { "Willowsong", new Book { Id = 2, Name = "Willowsong", Quantity = 3 } },
            });

        var command = new GetInventoryCommand(expectedInterface, context);
        var result = command.RunCommand();

        Assert.IsFalse(result.shouldQuit, $"'{nameof(GetInventoryCommand)}' - это не завершающая команда.");
        Assert.IsTrue(result.wasSuccessful, $"Не удалось успешно завершить команду '{nameof(GetInventoryCommand)}'.");

        Assert.AreEqual(0, context.GetAddedBooks().Length, $"Команда '{nameof(GetInventoryCommand)}' не должна добавлять книги.");
        Assert.AreEqual(0, context.GetUpdatedBooks().Length, $"Команда '{nameof(GetInventoryCommand)}' не должна обновлять книги.");
    }
}
