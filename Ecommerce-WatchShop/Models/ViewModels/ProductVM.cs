using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce_WatchShop.Models.ViewModels
{
    public class ProductVM
    {
        public int ProductId { get; set; }

        public string Image { get; set; } = null!;

        public string? ProductName { get; set; }

        public double? Price { get; set; }

        public string? ShortDescription { get; set; }

        public double ProductRating { get; set; }

        public int TotalRating { get; set; }

        public string? Slug { get; set; }

    }
}
