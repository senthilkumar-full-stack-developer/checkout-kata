using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace CheckoutKata.Tests
{
    public class CalculateTotalPriceTests
    {
        [Theory]
        [InlineData(1, 10, 0, 0, false, 1, 15, 3, 40, false, 1, 40, 0, 0, false, 1, 55, 2, 25, true, 120)] //No discounts will be applied
        [InlineData(2, 10, 0, 0, false, 2, 15, 3, 40, false, 2, 40, 0, 0, false, 2, 55, 2, 25, true, 212.5)] //Discount will be applied for Item D alone
        [InlineData(3, 10, 0, 0, false, 3, 15, 3, 40, false, 3, 40, 0, 0, false, 3, 55, 2, 25, true, 327.5)] //Discounts will be applied for both Item B and Item D
        public void When_Collection_Of_Items_With_Or_Without_Discounts_Are_CheckedOut_Then_Should_Return_Expected_Total_Price(int numberOfAItems, double priceOfAItem, int numberOfAItemsForPromotions, double discountedValueForA, bool isDiscountInPercentageForA,
                                                                                                                              int numberOfBItems, double priceOfBItem, int numberOfBItemsForPromotions, double discountedValueForB, bool isDiscountInPercentageForB,
                                                                                                                              int numberOfCItems, double priceOfCItem, int numberOfCItemsForPromotions, double discountedValueForC, bool isDiscountInPercentageForC,
                                                                                                                              int numberOfDItems, double priceOfDItem, int numberOfDItemsForPromotions, double discountedValueForD, bool isDiscountInPercentageForD,
                                                                                                                              double expectedTotalPrice)
        {
            var itemList = new Dictionary<Item, int>
            {
                { new Item { Name = "A", Price = priceOfAItem, NumberOfItemsForPromotions = numberOfAItemsForPromotions, DiscountedValue = discountedValueForA, IsDiscountInPercentage = isDiscountInPercentageForA }, numberOfAItems },
                { new Item { Name = "B", Price = priceOfBItem, NumberOfItemsForPromotions = numberOfBItemsForPromotions, DiscountedValue = discountedValueForB, IsDiscountInPercentage = isDiscountInPercentageForB }, numberOfBItems },
                { new Item { Name = "C", Price = priceOfCItem, NumberOfItemsForPromotions = numberOfCItemsForPromotions, DiscountedValue = discountedValueForC, IsDiscountInPercentage = isDiscountInPercentageForC }, numberOfCItems },
                { new Item { Name = "D", Price = priceOfDItem, NumberOfItemsForPromotions = numberOfDItemsForPromotions, DiscountedValue = discountedValueForD, IsDiscountInPercentage = isDiscountInPercentageForD }, numberOfDItems }
            };

            var calculateTotalPrice = Checkout.CalculateTotalPrice(itemList);

            calculateTotalPrice.Should().Be(expectedTotalPrice);
        }
    }
}