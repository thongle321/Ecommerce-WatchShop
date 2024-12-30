using System;
using System.Collections.Generic;

namespace Ecommerce_WatchShop.Models;

public partial class Blog
{
    public int BlogId { get; set; }

    public string? Image { get; set; }

    public string? Subject { get; set; }

    public string? Contents { get; set; }

    public virtual ICollection<BlogImage> BlogImages { get; set; } = new List<BlogImage>();
}
