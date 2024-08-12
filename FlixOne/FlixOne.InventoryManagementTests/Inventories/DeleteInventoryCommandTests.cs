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
/// DeleteInventoryCommand unit tests
/// </summary>
/// <remarks>
///     Доступна команда "удалить инвентарь" ("d", "delete-inventory")
///         строковый параметр "name"
///         удаление инвенторя из базы данных
/// </remarks>
[TestClass]
public class DeleteInventoryCommandTests
{
    [TestMethod]
    public void DeleteInventotyCommandTests_Successful()
    {
        /*
            Создать контекст с двумя добавленными книгами 
            Создать экземпляр команды
            Выполнить команду
            Проверить, что в базе данных осталось только одна книга
        */

        const string expectedBookName = "DeleteInventoryCommandTests";
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
            { expectedBookName, new Book{ Id = 1, Name = expectedBookName, Quantity = 7 } }
        });

        var command = new DeleteInventoryCommand(expectedInterface, context);

        var result = command.RunCommand();

        Assert.IsFalse(result.shouldQuit, $"'{nameof(DeleteInventoryCommand)}' - это не завершающая команда.");
        Assert.IsTrue(result.wasSuccessful, $"Не удалось успешно завершить команду '{nameof(DeleteInventoryCommand)}'.");

        // проверка, что книга была удалена
        Assert.AreEqual(1, context.GetDeletedBooks().Length, $"Команда '{nameof(DeleteInventoryCommand)}' не удалила книгу");

        var book = context.GetDeletedBooks().First();
        Assert.AreEqual(expectedBookName, book.Name, $"Команда '{nameof(DeleteInventoryCommand)}' удалиоа не ту книгу");
    }
}
