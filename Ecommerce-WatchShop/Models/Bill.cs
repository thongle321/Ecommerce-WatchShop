﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_WatchShop.Models;

public partial class Bill
{
    [Key]
    public int BillId { get; set; }

    public int? CustomerId { get; set; }

    public DateTime OrderDate { get; set; }
    [Column(TypeName = "nvarchar(200)")]
    public string? Province { get; set; }
    [Column(TypeName ="nvarchar(200)")]
    public string? District { get; set; }
    [Column(TypeName = "nvarchar(200)")]
    public string? Ward { get; set; }
    [Column(TypeName = "nvarchar(50)")]
    public string? PaymentMethod { get; set; }
    [Column(TypeName = "decimal(18,0)")]
    public decimal Total { get; set; }

    public int? Status { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}
