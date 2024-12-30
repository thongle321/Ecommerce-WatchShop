using System;
using System.Collections.Generic;

namespace Ecommerce_WatchShop.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string Image { get; set; } = null!;

    public string? ProductName { get; set; }

    public int? CategoryId { get; set; }

    public int? BrandId { get; set; }

    public int? SupplierId { get; set; }

    public int? Gender { get; set; }

    public double? Price { get; set; }

    public string? ShortDescription { get; set; }

    public string? Description { get; set; }

    public string? Specification { get; set; }

    public int? Quantity { get; set; }

    public int? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? Deleted { get; set; }

    public string? Slug { get; set; }

    public virtual Brand? Brand { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual Category? Category { get; set; }

    public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<ProductComment> ProductComments { get; set; } = new List<ProductComment>();

    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();

    public virtual ICollection<ProductRating> ProductRatings { get; set; } = new List<ProductRating>();

    public virtual Supplier? Supplier { get; set; }
}
