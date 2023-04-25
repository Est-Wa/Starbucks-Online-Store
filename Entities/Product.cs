using System;
using System.Collections.Generic;

namespace Entities;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public int? Price { get; set; }

    public string? Description { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public string? ImageLink { get; set;  }

    public virtual ICollection<OrderItem> OrderItems { get; } = new List<OrderItem>();
}
