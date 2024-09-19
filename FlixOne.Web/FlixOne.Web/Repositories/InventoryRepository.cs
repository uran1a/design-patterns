using FlixOne.Web.Common;
using FlixOne.Web.Contexts;
using FlixOne.Web.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.EntityFrameworkCore;

namespace FlixOne.Web.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly InventoryDbContext _inventoryDbContext;
        private readonly IHelper _helper;

        public InventoryRepository(InventoryDbContext inventoryDbContext, IHelper helper)
        {
            _inventoryDbContext = inventoryDbContext;
            _helper = helper;
        }

        public IEnumerable<Product> GetProducts() => _inventoryDbContext.Products.Include(c => c.Category).ToList();

        public Product GetProduct(Guid id) => _inventoryDbContext.Products.Include(c => c.Category).FirstOrDefault(x => x.Id == id);

        public bool AddProduct(Product product)
        {
            _inventoryDbContext.Products.Add(product);
            return _inventoryDbContext.SaveChanges() > 0;
        }

        public bool UpdateProduct(Product product)
        {
            _inventoryDbContext.Update(product);
            return _inventoryDbContext.SaveChanges() > 0;
        }

        public bool RemoveProduct(Product product)
        {
            _inventoryDbContext.Remove(product);
            return _inventoryDbContext.SaveChanges() > 0;
        }

        public IEnumerable<Category> GetCategories() => _inventoryDbContext.Categories.ToList();

        public Category GetCategory(Guid id) => _inventoryDbContext.Categories.FirstOrDefault(x => x.Id == id);

        public bool AddCategory(Category category)
        {
            _inventoryDbContext.Categories.Add(category);
            return _inventoryDbContext.SaveChanges() > 0;
        }

        public bool UpdateCategory(Category category)
        {
            _inventoryDbContext.Update(category);
            return _inventoryDbContext.SaveChanges() > 0;
        }

        public bool RemoveCategory(Category category)
        {
            _inventoryDbContext.Remove(category);
            return _inventoryDbContext.SaveChanges() > 0;
        }

        public IEnumerable<DiscountViewModel> GetValidDiscountedProducts(IEnumerable<DiscountViewModel> discountViewModel)
        {
            return _helper.FilterOutInvalidDiscountRates(discountViewModel);
        }
    }
}
