using System.Collections.Generic;
using System.Linq;

namespace SuperMarket
{
    public class ProductFactory
    {
        private readonly ProductRepository productRepository;

        public ProductFactory(ProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IEnumerable<Product> GetProducts(string input)
        {
            var productName = input.ToCharArray();
            return productName.Select(p => p.ToString()).Select(GetProduct);
        }

        private Product GetProduct(string input)
        {
            return productRepository.GetByName(input);
        }
    }
}
