﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_WatchShop.Models;

public partial class Product
{
    [Key]
    public int ProductId { get; set; }
    [Column(TypeName = "nvarchar(100)")]
    public string Image { get; set; } = null!;
    [Column(TypeName = "nvarchar(100)")]
    public string? ProductName { get; set; }

    public int? CategoryId { get; set; }

    public int? BrandId { get; set; }

    public int? SupplierId { get; set; }

    public int? Gender { get; set; }

    public double? Price { get; set; }
    [Column(TypeName = "nvarchar(200)")]
    public string? ShortDescription { get; set; }
    [Column(TypeName = "nvarchar(300)")]
    public string? Description { get; set; }
    [Column(TypeName = "nvarchar(500)")]
    public string? Specification { get; set; }

    public int? Quantity { get; set; }

    public int? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? Deleted { get; set; }
    [Column(TypeName = "varchar(100)")]
    public string? Slug { get; set; }

    public virtual Brand? Brand { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual Category? Category { get; set; }

    public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<ProductComment> ProductComments { get; set; } = new List<ProductComment>();

    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();

    public virtual ICollection<ProductRating> ProductRatings { get; set; } = new List<ProductRating>();

    public virtual Supplier? Supplier { get; set; }
}
