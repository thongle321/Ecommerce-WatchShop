using System;
using System.Collections.Generic;

namespace Ecommerce_WatchShop.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public int? ParentId { get; set; }

    public string? Slug { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
