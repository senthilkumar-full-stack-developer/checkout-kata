﻿namespace CheckoutKata
{
    public class Item
    {
        public double DiscountedValue { get; set; }
        public bool isDiscountInPercentage { get; set; }
        public string Name { get; set; }
        public int NumberOfItemsForPromotions { get; set; }
        public double Price { get; set; }
    }
}