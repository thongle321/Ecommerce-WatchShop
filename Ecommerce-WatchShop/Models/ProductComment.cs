using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce_WatchShop.Models;

public partial class ProductComment
{
    [Key]
    public int CommentId { get; set; }

    public int ProductId { get; set; }

    public int? CustomerId { get; set; }

    public string? Contents { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Product Product { get; set; } = null!;
}
