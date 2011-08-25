using System.Collections.Generic;
using SuperMarket;
using Xunit;

namespace SuperMarketTest
{
    public class ProductTest
    {
        [Fact]
        public void buy_one_item_A_should_pay_50()
        {
            var shop = BuildShop();
            Assert.Equal(50M, shop.Price("A"));
        }

        [Fact]
        public void buy_one_item_A_and_one_item_B_should_pay_80()
        {
            var shop = BuildShop(); 
            var price = shop.Price("AB");
            Assert.Equal(80M, price);
        }

        [Fact]
        public void buy_one_item_D_C_B_A_should_pay_115()
        {
            var shop = BuildShop();
            var price = shop.Price("CDBA");
            Assert.Equal(115M, price);
        }

        [Fact]
        public void buy_three_times_A_should_pay_130()
        {
            var shop = BuildShop();
            var price = shop.Price("AAA");
            Assert.Equal(130M, price);
        }

        [Fact]
        public void buy_two_times_B_should_pay_45()
        {
            var shop = BuildShop();
            var price = shop.Price("ABAABBB");
            Assert.Equal(220M, price);
        }

        private static Shop BuildShop()
        {
            var productRepository = new ProductRepository();
            var productFactory = new ProductFactory(productRepository);
            var discountCalculator = new DiscountCalculator();
            var productSales = new List<IProductSale> {new ProductASale(discountCalculator), new ProductBSale(discountCalculator)};
            return new Shop(productFactory, productSales);
        }
    }
}
