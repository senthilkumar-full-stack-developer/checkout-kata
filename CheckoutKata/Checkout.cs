namespace CheckoutKata
{
    public class Checkout
    {
        public double CalculateTotalPrice(int numberOfItems, double priceOfItem, int numberOfItemsForPromotions, int discountedValue)
        {
            double totalPrice = numberOfItems * priceOfItem;
            if (numberOfItemsForPromotions > 0)
                totalPrice -= (numberOfItems / numberOfItemsForPromotions) * discountedValue;
            
            return totalPrice;
        }

        public double CalculateTotalPrice(int numberOfItems, double priceOfItem, int numberOfItemsForPromotions, double discountedValue)
        {
            double totalPrice = numberOfItems * priceOfItem;
            if (numberOfItemsForPromotions > 0)
                totalPrice -= (numberOfItems / numberOfItemsForPromotions) * (discountedValue * numberOfItemsForPromotions * priceOfItem);

            return totalPrice;
        }
    }
}