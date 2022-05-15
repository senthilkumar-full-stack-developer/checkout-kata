namespace CheckoutKata
{
    public class Checkout
    {
        public double CalculateTotalPrice(Dictionary<Item, int> itemList)
        {
            double totalPrice = 0;

            foreach (var item in itemList)
            {
                totalPrice += item.Value * item.Key.Price;

                if (item.Key.isDiscountInPercentage)
                    item.Key.DiscountedValue = item.Key.DiscountedValue * item.Key.NumberOfItemsForPromotions * item.Key.Price;

                if (item.Key.NumberOfItemsForPromotions > 0)
                    totalPrice -= (item.Value / item.Key.NumberOfItemsForPromotions) * item.Key.DiscountedValue;
            }

            return totalPrice;
        }
    }
}