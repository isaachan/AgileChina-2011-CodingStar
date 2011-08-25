using System.Collections.Generic;
using System.Linq;

namespace SuperMarket
{
    public class Shop
    {
        private readonly ProductFactory productFactory;
        private readonly List<IProductSale> sales;

        public Shop(ProductFactory productFactory, List<IProductSale> sales)
        {
            this.productFactory = productFactory;
            this.sales = sales;
        }

        public decimal Price(string input)
        {
            var products = productFactory.GetProducts(input);
            var calculatePrice = CalculatePrice(products);
            var discount = GetDiscount(products);
            return calculatePrice - discount;
        }

        private decimal GetDiscount(IEnumerable<Product> products)
        {
            return sales.Sum(p => p.GetDiscount(products));
        }

        private static decimal CalculatePrice(IEnumerable<Product> products)
        {
            return products.Sum(p => p.GetPrice());
        }
    }
}
