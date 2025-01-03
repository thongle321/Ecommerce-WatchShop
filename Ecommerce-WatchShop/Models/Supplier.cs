using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_WatchShop.Models;

public partial class Supplier
{
    [Key]
    public int SupplierId { get; set; }
    [Column(TypeName = "nvarchar(100)")]
    public string Name { get; set; } = null!;
    [Column(TypeName = "varchar(15)")]
    public string Phone { get; set; } = null!;
    [Column(TypeName = "nvarchar(200)")]
    public string? Information { get; set; }
    [Column(TypeName = "nvarchar(150)")]
    public string? Address { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<WarehouseReceipt> WarehouseReceipts { get; set; } = new List<WarehouseReceipt>();
}
