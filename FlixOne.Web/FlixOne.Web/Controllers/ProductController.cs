using System;
using FlixOne.Web.Common;
using FlixOne.Web.Models;
using FlixOne.Web.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FlixOne.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IInventoryRepository _repository;

        public ProductController(IInventoryRepository inventoryRepository) => _repository = inventoryRepository;

        public IActionResult Index() => View(_repository.GetProducts().ToProductViewModel());

        public IActionResult Details(Guid id) => View(_repository.GetProduct(id).ToProductViewModel());
        
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            try
            {
                _repository.AddProduct(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        
       public IActionResult Edit(Guid id) => View(_repository.GetProduct(id));

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, Product product)
        {
            try
            {
                _repository.UpdateProduct(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Delete(Guid id) => View(_repository.GetProduct(id));

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Guid id, Product product)
        {
            try
            {
                _repository.RemoveProduct(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}