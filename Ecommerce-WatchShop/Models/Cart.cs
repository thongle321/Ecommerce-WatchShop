using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce_WatchShop.Models;

public partial class Cart
{
    [Key]
    public int CartId { get; set; }

    public int ProductId { get; set; }

    public int? CustomerId { get; set; }

    public decimal? Price { get; set; }

    public int Quantity { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Product Product { get; set; } = null!;
}
