using System.Collections.Generic;

namespace SuperMarket
{
    public interface IProductSale
    {
        decimal GetDiscount(IEnumerable<Product> products);
    }
}