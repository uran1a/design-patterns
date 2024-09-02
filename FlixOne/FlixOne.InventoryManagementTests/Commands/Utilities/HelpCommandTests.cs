using FlixOne.InventoryManagement.Commands.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlixOne.InventoryManagementTests.Commands.Utilities;

/// <summary>
///     Тесты Help Command
/// </summary>
/// <remarks>
///     Доступна команда помощи ("?")
///         выводит краткое описание доступных команд
///         выводит примеры использования каждой команды
/// </remarks>
[TestClass]
internal class HelpCommandTests
{
    [TestMethod]
    public void HelpCommand_Successful()
    {
        var expectedInterface = new Helpers.TestUserInterface(
            new List<Tuple<string, string>>(),
            new List<string>
            {
                    "USAGE:",
                    "\taddinventory (a)",
                    "\tgetinventory (g)",
                    "\tupdatequantity (u)",
                    "\tquit (q)",
                    "\t?",
                    "Examples:",
                    "\tNew Inventory",
                    "\t> addinventory",
                    "\tEnter name:The Meaning of Life",
                    "",
                    "\tGet Inventory",
                    "\t> getinventory",
                    "\tThe Meaning of Life        Quantity:10",
                    "\tThe Life of a Ninja        Quantity:2",
                    "",
                    "\tUpdate Quantity (Increase)",
                    "\t> updatequantity",
                    "\tEnter name:The Meaning of Life",
                    "\t11",
                    "\t11 added to quantity",
                    "",
                    "\tUpdate Quantity (Decrease)",
                    "\t> updatequantity",
                    "\tEnter name:The Life of a Ninja",
                    "\t-3",
                    "\t3 removed from quantity",
                    ""
            },
            new List<string>()
        );

        var command = new HelpCommand(expectedInterface);

        var result = command.RunCommand();

        Assert.IsFalse(result.shouldQuit, "'HelpCommand' - не является завершающей командой");
        Assert.IsTrue(result.wasSuccessful, "Не удалось успешно завершить команду 'HelpCommand'");
    }
}
