using System;
using System.Collections.Generic;

namespace Ecommerce_WatchShop.Models;

public partial class Favorite
{
    public int FavoriteId { get; set; }

    public int ProductId { get; set; }

    public int? CustomerId { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Product Product { get; set; } = null!;
}
