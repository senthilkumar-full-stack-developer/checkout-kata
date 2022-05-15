namespace CheckoutKata
{
    public class Checkout
    {
        public double CalculateTotalPrice(int numberOfItems, double priceOfItem, int numberOfItemsForPromotions, double discountedValue, bool isDiscountInPercentage)
        {
            double totalPrice = numberOfItems * priceOfItem;

            if (isDiscountInPercentage)
            {
                discountedValue = discountedValue * numberOfItemsForPromotions * priceOfItem;
            }

            if (numberOfItemsForPromotions > 0)
                totalPrice -= (numberOfItems / numberOfItemsForPromotions) * discountedValue;

            return totalPrice;
        }
    }
}