using FluentAssertions;
using Xunit;

namespace CheckoutKata.Tests
{
    public class CalculateTotalPriceTests
    {
        [Theory]
        [InlineData(1, 15, 3, 5, false, 15)] //B
        [InlineData(2, 15, 3, 5, false, 30)] //B
        [InlineData(3, 15, 3, 5, false, 40)] //B
        [InlineData(4, 15, 3, 5, false, 55)] //B
        [InlineData(5, 15, 3, 5, false, 70)] //B
        [InlineData(6, 15, 3, 5, false, 80)] //D
        [InlineData(1, 55, 2, 0.25, true, 55)] //D
        [InlineData(2, 55, 2, 0.25, true, 82.5)] //D
        [InlineData(3, 55, 2, 0.25, true, 137.50)] //D
        [InlineData(4, 55, 2, 0.25, true, 165)] //D
        [InlineData(2, 10, 0, 0, false, 20)] //A
        [InlineData(2, 40, 0, 0, false, 80)] //C
        public void Checkout_Items_With_B_Items_Promotions_Not_In_Percentage_And_D_Items_Promotions_In_Percentage(int numberOfItems, double priceOfItem, int numberOfItemsForPromotions, double discountedValue, bool isDiscountInPercentage, double expectedTotalPrice)
        {
            var checkOut = new Checkout();

            var calculateTotalPrice = checkOut.CalculateTotalPrice(numberOfItems, priceOfItem, numberOfItemsForPromotions, discountedValue, isDiscountInPercentage);

            calculateTotalPrice.Should().Be(expectedTotalPrice);
        }
    }
}