using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_WatchShop.Models;

public partial class Blog
{
    [Key]
    public int BlogId { get; set; }
    [Column(TypeName ="")]
    public string? Image { get; set; }

    public string? Subject { get; set; }

    public string? Contents { get; set; }

    public virtual ICollection<BlogImage> BlogImages { get; set; } = new List<BlogImage>();
}
