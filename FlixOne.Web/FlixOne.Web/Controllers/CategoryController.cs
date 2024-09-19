using FlixOne.Web.Models;
using FlixOne.Web.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FlixOne.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IInventoryRepository _inventoryRepository;

        public CategoryController(IInventoryRepository inventoryRepository) => _inventoryRepository = inventoryRepository;

        public IActionResult Index() => View(_inventoryRepository.GetCategories());

        public IActionResult Details(Guid id) => View(_inventoryRepository.GetCategory(id));

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Category category)
        {
            try
            {
                _inventoryRepository.AddCategory(category);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Edit(Guid id) => View(_inventoryRepository.GetCategory(id));

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, Category category)
        {
            try
            {
                _inventoryRepository.UpdateCategory(category);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Delete(Guid id) => View(_inventoryRepository.GetCategory(id));

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Guid id, Category category)
        {
            try
            {
                _inventoryRepository.RemoveCategory(category);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
