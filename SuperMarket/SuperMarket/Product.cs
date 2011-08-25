namespace SuperMarket
{
    public class Product
    {
        private readonly string name;
        private readonly decimal price;

        public Product(string name, decimal price)
        {
            this.name = name;
            this.price = price;
        }

        public decimal GetPrice()
        {
            return price;
        }

        public bool IsProduct(string name)
        {
            return this.name == name;
        }
    }
}