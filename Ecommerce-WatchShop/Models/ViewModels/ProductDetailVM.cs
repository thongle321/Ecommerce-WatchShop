﻿namespace Ecommerce_WatchShop.Models.ViewModels
{
    public class ProductDetailVM
    {
        public Product Product { get; set; } = null!;
        public double ProductRating { get; set; }
        public int TotalRating { get; set; }
    } 
}
