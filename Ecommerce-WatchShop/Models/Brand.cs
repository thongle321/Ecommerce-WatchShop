using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce_WatchShop.Models;

public partial class Brand
{
    [Key]
    public int BrandId { get; set; }

    public string? Name { get; set; }

    public string? Slug { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
