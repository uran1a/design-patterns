using FlixOne.InventoryManagement.UserInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlixOne.InventoryManagementTests.Helpers;

internal class TestUserInterface : IUserInterface
{
    private readonly List<Tuple<string, string>> _expectedReadValueRequests;
    private readonly List<string> _expectedWriteMessageRequests;
    private readonly List<string> _expectedWriteWarningRequests;

    private int _expectedReadValueRequestsIndex;
    private int _expectedWriteMessageRequestsIndex;
    private int _expectedWriteWarningRequestsIndex;

    public TestUserInterface(List<Tuple<string, string>> expectedReadValueRequests, List<string> expectedWriteMessageRequests, List<string> expectedWriteWarningRequests)
    {
        _expectedReadValueRequests = expectedReadValueRequests;
        _expectedWriteMessageRequests = expectedWriteMessageRequests;
        _expectedWriteWarningRequests = expectedWriteWarningRequests;
    }

    /// <summary>
    /// Полученив сообщение, убедитесь, что оно соотвествует ожидаемому, и верните результат
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    /// <remarks>
    ///  Полученные значения сообщений ожидаются в определенном порядке
    /// </remarks>
    public string ReadValue(string message)
    {
        Assert.IsTrue(_expectedReadValueRequestsIndex < _expectedReadValueRequests.Count,
            "Получено слишком много запросов на чтение от команды 'ReadValue'.");

        Assert.AreEqual(_expectedReadValueRequests[_expectedReadValueRequestsIndex].Item1, message,
            "Получено неожиданное сообщение от команды 'ReadValue'.");

        return _expectedReadValueRequests[_expectedReadValueRequestsIndex++].Item2;
    }

    public void WriteMessage(string message)
    {
        Assert.IsTrue(_expectedWriteMessageRequestsIndex < _expectedWriteMessageRequests.Count,
            "Получено слишком много запросов на запись сообщения от команды 'WriteMessage'.");

        Assert.AreEqual(_expectedWriteMessageRequests[_expectedWriteMessageRequestsIndex++], message,
            "Получено неожиданное сообщение от команды 'WriteMessage'.");
    }

    public void WriteWarning(string message)
    {
        Assert.IsTrue(_expectedWriteWarningRequestsIndex < _expectedWriteWarningRequests.Count,
            "Получено слишком много запросов на запись предупреждения от команды 'WriteWarning'.");

        Assert.AreEqual(_expectedWriteWarningRequests[_expectedWriteWarningRequestsIndex++], message,
            "Получено неожиданное сообщение от команды 'WriteWarning'.");
    }

    public void Validate()
    {
        Assert.IsTrue(_expectedReadValueRequestsIndex == _expectedReadValueRequests.Count, "Не все запросы на чтения были выполнены.");
        Assert.IsTrue(_expectedWriteMessageRequestsIndex == _expectedWriteMessageRequests.Count, "Не все запросы на запись сообщения были выполнены.");
        Assert.IsTrue(_expectedWriteWarningRequestsIndex == _expectedWriteWarningRequests.Count, "Не все запросы на запись предупреждения были выполнены.");
    }
}
