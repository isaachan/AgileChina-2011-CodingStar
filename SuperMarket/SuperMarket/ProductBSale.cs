using System.Collections.Generic;
using System.Linq;

namespace SuperMarket
{
    public class ProductBSale : IProductSale
    {
        private readonly DiscountCalculator discountCalculator;

        public ProductBSale(DiscountCalculator discountCalculator)
        {
            this.discountCalculator = discountCalculator;
        }

        public decimal GetDiscount(IEnumerable<Product> products)
        {
            var productCount = products.Where(p => p.IsProduct("B")).Count();
            return discountCalculator.CalDiscount(productCount, 2, 15);
        }
    }
}
