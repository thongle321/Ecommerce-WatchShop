using System;
using System.Collections.Generic;

namespace Ecommerce_WatchShop.Models;

public partial class Bill
{
    public int BillId { get; set; }

    public int? CustomerId { get; set; }

    public DateTime OrderDate { get; set; }

    public string? Province { get; set; }

    public string? District { get; set; }

    public string? Ward { get; set; }

    public string? PaymentMethod { get; set; }

    public decimal Total { get; set; }

    public int? Status { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}
