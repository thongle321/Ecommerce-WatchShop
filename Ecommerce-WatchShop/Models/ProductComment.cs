﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_WatchShop.Models;

public partial class ProductComment
{
    [Key]
    public int CommentId { get; set; }

    public int ProductId { get; set; }

    public int? CustomerId { get; set; }

    [Column(TypeName = "nvarchar(MAX)")]
    public string? Contents { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Product Product { get; set; } = null!;
}
