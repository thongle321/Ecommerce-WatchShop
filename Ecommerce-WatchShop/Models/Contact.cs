using System;
using System.Collections.Generic;

namespace Ecommerce_WatchShop.Models;

public partial class Contact
{
    public int ContactId { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Subject { get; set; } = null!;

    public string Note { get; set; } = null!;
}
