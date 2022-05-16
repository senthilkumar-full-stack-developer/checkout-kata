namespace CheckoutKata
{
    public class Checkout
    {
        public double CalculateTotalPrice(Dictionary<Item, int> itemList)
        {
            int numberOfItems;
            double price;
            double discountedValue;
            int numberOfItemsForPromotions;
            bool isDiscountInPercentage;
            double totalPrice = 0;

            foreach (var item in itemList)
            {
                numberOfItems = item.Value;
                price = item.Key.Price;
                discountedValue = item.Key.DiscountedValue;
                numberOfItemsForPromotions = item.Key.NumberOfItemsForPromotions;
                isDiscountInPercentage = item.Key.IsDiscountInPercentage;

                totalPrice += numberOfItems * price;

                if (isDiscountInPercentage)
                    discountedValue = (numberOfItemsForPromotions * price) * (discountedValue / 100);
                else
                    discountedValue = (numberOfItemsForPromotions * price) - (discountedValue);

                if (numberOfItemsForPromotions > 0)
                    totalPrice -= (numberOfItems / numberOfItemsForPromotions) * discountedValue;
            }

            return totalPrice;
        }
    }
}