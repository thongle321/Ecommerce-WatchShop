using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce_WatchShop.Models;

public partial class Role
{
    [Key]
    public int RoleId { get; set; }

    public string? Type { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
