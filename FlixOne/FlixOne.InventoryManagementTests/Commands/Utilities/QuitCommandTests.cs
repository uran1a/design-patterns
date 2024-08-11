using FlixOne.InventoryManagement.Commands.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlixOne.InventoryManagementTests.Commands.Utilities;

/// <summary>
///     Тесты Quit Command
/// </summary>
/// <remarks>
///     Доступна команда завершения работы ("q", "quit")
///         выводит прощальное сообщение
///         завершает работу приложения
/// </remarks>
[TestClass]
internal class QuitCommandTests
{
    [TestMethod]
    public void QuitCommand_Successful()
    {
        var expectedInterface = new Helpers.TestUserInterface(
                new List<Tuple<string, string>>(), // ReadValue()
                new List<string> // WriteMessage()
                {
                    "Благодарим вас за использование системы управления инвентаризаций FlixOne."
                },
                new List<string>() // WriteWarning()
            );

        // создание экземпляра команды
        var command = new QuitCommand(expectedInterface);

        // запускаем команду
        var result = command.RunCommand();

        expectedInterface.Validate();

        Assert.IsTrue(result.shouldQuit, "'QuitCommand' - завершающая команда");
        Assert.IsTrue(result.wasSuccessful, "Не удалось успешно завершить команду 'QuitCommand'");
    }
}
