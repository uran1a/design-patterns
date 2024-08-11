using FlixOne.InventoryManagement.Commands.Inventories;
using FlixOne.InventoryManagement.Models;
using FlixOne.InventoryManagementTests.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlixOne.InventoryManagementTests.Inventories;

/// <summary>
/// AddInventory unit tests
/// </summary>
/// <remarks>
///     An add inventory command ("a", "addInventory") is available
///         paramenter "name" of type string
///         adds an entry into the database with the given name and a 0 quantity
/// </remarks>
[TestClass]
public class AddInventoryCommandTests
{
    [TestMethod]
    public void AddInventoryCommand_Successful()
    {
        const string expectedBookName = "AddInventoryCommandTests";
        var expectedInterface = new TestUserInterface(
                new List<Tuple<string, string>>
                {
                    new Tuple<string, string>("Enter name: ", expectedBookName)
                },
                new List<string>(),
                new List<string>()
            );

        var context = new TestInventoryContext(new Dictionary<string, Book>
        {
            { "Gremlins", new Book{ Id = 1, Name = "Gremlins", Quantity = 7 } }
        });

        var command = new AddInventoryCommand(expectedInterface, context);

        var result = command.RunCommand();

        Assert.IsFalse(result.shouldQuit, $"'{nameof(AddInventoryCommand)}' - это не завершающая команда.");
        Assert.IsTrue(result.wasSuccessful, $"Не удалось успешно завершить команду '{nameof(AddInventoryCommand)}'.");

        foreach (var item in context.GetBooks())
        {
            Debug.WriteLine(item.Name);
        }

        // проверка, что книга была добавлена с переданным именем и кол-вом 0
        Assert.AreEqual(1, context.GetAddedBooks().Length, $"'{nameof(AddInventoryCommand)}' должно иметь одну новую книгу");

        var newBook = context.GetAddedBooks().First();
        Assert.AreEqual(expectedBookName, newBook.Name, $"'{nameof(AddInventoryCommand)}' не имеет книги с переданным именем");
    }
}
