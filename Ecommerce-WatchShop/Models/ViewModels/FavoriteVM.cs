﻿namespace Ecommerce_WatchShop.Models.ViewModels
{
    public class FavoriteVM
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public double? Price { get; set; }
        public string Image { get; set; } = string.Empty;
    }
}
