using System;
using System.Collections.Generic;

namespace WebApplication1.DB;

public partial class Product
{
    public int Article { get; set; }

    public string Title { get; set; } = null!;

    public int ProductTypeId { get; set; }

    public decimal MinCost { get; set; }

    public virtual ProductType ProductType { get; set; } = null!;
}
