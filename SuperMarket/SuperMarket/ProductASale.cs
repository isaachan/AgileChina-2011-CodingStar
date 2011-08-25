using System.Collections.Generic;
using System.Linq;

namespace SuperMarket
{
    public class ProductASale : IProductSale
    {
        private readonly DiscountCalculator discountCalculator;
        public ProductASale(DiscountCalculator discountCalculator)
        {
            this.discountCalculator = discountCalculator;
        }

        public decimal GetDiscount(IEnumerable<Product> products)
        {
            var productCount = products.Where(p => p.IsProduct("A")).Count();
            return discountCalculator.CalDiscount(productCount, 3, 20);
        }
    }
}
