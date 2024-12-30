using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce_WatchShop.Models;

public partial class WarehouseReceipt
{
    [Key]
    public int ReceiptId { get; set; }

    public string? Voucher { get; set; }

    public DateTime DateCreated { get; set; }

    public decimal Total { get; set; }

    public string? Note { get; set; }

    public int SupplierId { get; set; }

    public virtual Supplier Supplier { get; set; } = null!;
}
