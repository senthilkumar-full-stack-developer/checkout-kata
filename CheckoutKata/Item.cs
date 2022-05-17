namespace CheckoutKata
{
    public class Item
    {
        public double DiscountedValue { get; set; }
        public bool IsDiscountInPercentage { get; set; }
        public string Name { get; set; } = string.Empty;
        public int NumberOfItemsForPromotions { get; set; }
        public double Price { get; set; }
    }
}