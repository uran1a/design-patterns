using FlixOne.InventoryManagement.Commands.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlixOne.InventoryManagementTests.Commands.Utilities;

[TestClass]
internal class UnknownCommandTests
{
    [TestMethod]
    public void UnknownCommand_Successful()
    {
        var expectedInterface = new Helpers.TestUserInterface(
            new List<Tuple<string, string>>(),
            new List<string>(),
            new List<string>()
            {
                "Не удается определить нужную команду."
            }
        );

        var command = new UnknownCommand(expectedInterface);

        var result = command.RunCommand();

        Assert.IsFalse(result.shouldQuit, "'UnknownCommand' - это не завершающая команда.");
        Assert.IsFalse(result.wasSuccessful, "Не удалось успешно завершить команду 'UnknownCommand'.");
    }
}
