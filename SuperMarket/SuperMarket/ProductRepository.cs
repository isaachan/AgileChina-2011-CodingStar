using System.Collections.Generic;

namespace SuperMarket
{
    public class ProductRepository
    {
        private readonly Dictionary<string, decimal> productList = new Dictionary<string, decimal>();

        public ProductRepository()
        {
            productList.Add("A", 50);
            productList.Add("B", 30);
            productList.Add("C", 20);
            productList.Add("D", 15);
        }

        public Product GetByName(string name)
        {
            return productList.ContainsKey(name) ? new Product(name, productList[name]) : null;
        }
    }
}