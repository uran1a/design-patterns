using FlixOne.InventoryManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlixOne.InventoryManagementTests.Repositories;

[TestClass]
public class InventoryContextTests
{
    [TestMethod]
    public void MaintainBooks_Successful()
    {
        List<Task> tasks = new List<Task>();

        // добавление 30 книг
        foreach (var id in Enumerable.Range(1, 30))
        {
            tasks.Add(AddBook($"Book_{id}"));
        }

        Task.WaitAll(tasks.ToArray());
        tasks.Clear();

        // обновление поля 'Количество' у книг, добавив 1, 2, 3, 4, 5 ...
        foreach (var quantity in Enumerable.Range(1, 10))
        {
            foreach (var id in Enumerable.Range(1, 30))
            {
                tasks.Add(UpdateQuantity($"Book_{id}", quantity));
            }
        }

        // обновление поля 'Количество' у книг, вычтя 1, 2, 3, 4, 5 ...
        foreach (var quantity in Enumerable.Range(1, 10))
        {
            foreach (var id in Enumerable.Range(1, 30))
            {
                tasks.Add(UpdateQuantity($"Book_{id}", -quantity));
            }
        }

        // ошибаем все потоки
        Task.WaitAll(tasks.ToArray());

        // у всех книг поле 'Количество' должно быть равно 0            
        foreach (var book in InventoryContext.Instance.GetBooks())
        {
            Assert.AreEqual(0, book.Quantity);
        }
    }

    public Task AddBook(string book)
    {
        return Task.Run(() =>
        {
            Assert.IsTrue(InventoryContext.Instance.AddBook(book));
        });
    }

    public Task UpdateQuantity(string book, int quantity)
    {
        return Task.Run(() =>
        {
            Assert.IsTrue(InventoryContext.Instance.UpdateQuantity(book, quantity));
        });
    }

}