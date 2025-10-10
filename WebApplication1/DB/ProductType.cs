using System;
using System.Collections.Generic;

namespace WebApplication1.DB;

public partial class ProductType
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public double Coificient { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
