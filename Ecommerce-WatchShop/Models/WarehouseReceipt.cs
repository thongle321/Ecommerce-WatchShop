using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_WatchShop.Models;

public partial class WarehouseReceipt
{
    [Key]
    public int ReceiptId { get; set; }

    
    public string? Voucher { get; set; }

    public DateTime DateCreated { get; set; }

    [Precision(18,0)]
    public decimal Total { get; set; }

    [Column(TypeName = "nvarchar(200)")]
    public string? Note { get; set; }

    public int SupplierId { get; set; }

    public virtual Supplier Supplier { get; set; } = null!;
}
