using System;
using System.Collections.Generic;

namespace Ecommerce_WatchShop.Models;

public partial class BlogImage
{
    public int BlogImageId { get; set; }

    public int? BlogId { get; set; }

    public string? Image { get; set; }

    public virtual Blog? Blog { get; set; }
}
