namespace SuperMarket
{
    public class DiscountCalculator
    {
        public decimal CalDiscount(int productCount, int saleNumber, int discountPrice)
        {
            var saleCounts = productCount/saleNumber;
            return discountPrice*saleCounts;
        }
    }
}