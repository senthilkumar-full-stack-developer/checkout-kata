using FluentAssertions;
using Xunit;

namespace CheckoutKata.Tests
{
    public class CalculateTotalPriceTests
    {
        [Theory]
        [InlineData(1, 15, 3, 5, 15)] //B
        [InlineData(2, 15, 3, 5, 30)] //B
        [InlineData(3, 15, 3, 5, 40)] //B
        [InlineData(4, 15, 3, 5, 55)] //B
        [InlineData(5, 15, 3, 5, 70)] //B
        [InlineData(6, 15, 3, 5, 80)] //B
        [InlineData(2, 10, 0, 0, 20)] //A
        [InlineData(2, 40, 0, 0, 80)] //C
        public void Checkout_Items_With_B_Items_Promotions_Not_In_Percentage(int numberOfItems, double priceOfItem, int numberOfItemsForPromotions, int discountedValue, double expectedTotalPrice)
        {
            var checkOut = new Checkout();

            var calculateTotalPrice = checkOut.CalculateTotalPrice(numberOfItems, priceOfItem, numberOfItemsForPromotions, discountedValue);

            calculateTotalPrice.Should().Be(expectedTotalPrice);
        }

        [Theory]
        [InlineData(1, 55, 2, 0.25, 55)] //D
        [InlineData(2, 55, 2, 0.25, 82.5)] //D
        [InlineData(3, 55, 2, 0.25, 137.50)] //D
        [InlineData(4, 55, 2, 0.25, 165)] //D
        [InlineData(2, 10, 0, 0, 20)] //A
        [InlineData(2, 40, 0, 0, 80)] //C
        public void Checkout_Items_With_D_Items_Promotions_In_Percentage(int numberOfItems, double priceOfItem, int numberOfItemsForPromotions, double discountedValue, double expectedTotalPrice)
        {
            var checkOut = new Checkout();

            var calculateTotalPrice = checkOut.CalculateTotalPrice(numberOfItems, priceOfItem, numberOfItemsForPromotions, discountedValue);

            calculateTotalPrice.Should().Be(expectedTotalPrice);
        }
    }
}