using System;
using System.Collections.Generic;

namespace Ecommerce_WatchShop.Models;

public partial class ProductImage
{
    public int ProductImageId { get; set; }

    public int? ProductId { get; set; }

    public string? Image { get; set; }

    public virtual Product? Product { get; set; }
}
