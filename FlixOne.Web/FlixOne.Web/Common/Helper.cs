using FlixOne.Web.Models;
using System.Globalization;

namespace FlixOne.Web.Common
{
    public interface IHelper
    {
        IEnumerable<DiscountViewModel> FilterOutInvalidDiscountRates(IEnumerable<DiscountViewModel> discountViewModels);
        IEnumerable<ProductViewModel> FilterOutInvalidProductNames(IEnumerable<ProductViewModel> productViewModels);
    }
    public class Helper : IHelper
    {
        private static readonly TextInfo TextInfo = new CultureInfo("en-US", false).TextInfo;
        private readonly Predicate<string> _isProductNameTitleCase = s => s.Equals(TextInfo.ToTitleCase(s));
        private readonly Func<decimal, bool> _validDiscount = d => d == 0 || d - 100 <= 1;
        public IEnumerable<DiscountViewModel> FilterOutInvalidDiscountRates(IEnumerable<DiscountViewModel> discountViewModels)
        {
            var viewModels = discountViewModels.ToList();
            var res = viewModels.Select(x => x.ProductDiscountRate).Where(_validDiscount);
            return viewModels.Where(x => res.Contains(x.ProductDiscountRate));
        }

        public IEnumerable<ProductViewModel> FilterOutInvalidProductNames(IEnumerable<ProductViewModel> productViewModels)
        {
            return productViewModels.ToList().Where(p => _isProductNameTitleCase(p.ProductName));
        }
    }
}
