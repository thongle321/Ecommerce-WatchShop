using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_WatchShop.Models;

public partial class Category
{
    [Key]
    public int CategoryId { get; set; }

    [Column(TypeName = "nvarchar(100)")]
    public string? CategoryName { get; set; }

    public int? ParentId { get; set; }

    public string? Slug { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
