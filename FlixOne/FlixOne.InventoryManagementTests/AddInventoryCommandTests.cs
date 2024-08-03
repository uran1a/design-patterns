using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlixOne.InventoryManagementTests
{
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
            // создаем экземпляр команды
            // добавляем новую книгу с параметром "name"
            // проверяем, была ли добавлена книга с данным название и количеством 0

            Assert.Inconclusive("AddInventoryCommand_Successful has not been implemented.");
        }
    }
}
