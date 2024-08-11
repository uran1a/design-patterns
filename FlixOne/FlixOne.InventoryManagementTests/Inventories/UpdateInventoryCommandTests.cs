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
/// UpdateQuantity Command Tests
/// </summary>
/// <remarks>
/// An update quantity command ("u", "updatequantity") is available 
///     parameter "name" of type string
///     parameter "quantity" of a positive or negative integer
///     updates the quantity value of the book with the given name by adding the given quantity
/// </remarks>
[TestClass]
public class UpdateInventoryCommandTests
{
    [TestMethod]
    public void UpdateQuantity_ExistingBook_Successful()
    {
        const string expectedBookName = "UpdateQuantityUnitTest";
        var expectedInterface = new Helpers.TestUserInterface(
                new List<Tuple<string, string>>()
                {
                    new Tuple<string, string>("Enter name: ", expectedBookName),
                    new Tuple<string, string>("Enter quantity: ", "6")
                },
                new List<string>(),
                new List<string>()
            );

        var context = new TestInventoryContext(new Dictionary<string, Book>
            {
                { "Beavers", new Book { Id = 1, Name = "Beavers", Quantity = 3 } },
                { expectedBookName, new Book { Id = 2, Name = expectedBookName, Quantity = 7 } },
                { "Ducks", new Book { Id = 3, Name = "Ducks", Quantity = 12 } }
            });

        var command = new UpdateQuantityCommand(expectedInterface, context);

        var result = command.RunCommand();


        Assert.IsFalse(result.shouldQuit, $"'{nameof(UpdateQuantityCommand)}' - это не завершающая команда.");
        Assert.IsTrue(result.wasSuccessful, $"Не удалось успешно завершить команду '{nameof(UpdateQuantityCommand)}'.");

        Assert.AreEqual(0, context.GetAddedBooks().Length, $"Команда '{nameof(UpdateQuantityCommand)}' не должна добавлять новых книг.");

        var updatedBooks = context.GetUpdatedBooks();
        Assert.AreEqual(1, updatedBooks.Length, $"Команда '{nameof(UpdateQuantityCommand)}' должна обновить новую книгу.");
        Assert.AreEqual(expectedBookName, updatedBooks.First().Name, $"Команда '{nameof(UpdateQuantityCommand)}' неправильно обновила книгу."); ;
        Assert.AreEqual(13, updatedBooks.First().Quantity, "Командtе '{nameof(UpdateQuantityCommand)}' не удалось упешно обновить поле 'Количество' у книги.");
    }
}
