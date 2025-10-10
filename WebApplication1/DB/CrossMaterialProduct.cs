using System;
using System.Collections.Generic;

namespace WebApplication1.DB;

public partial class CrossMaterialProduct
{
    public int IdMaterial { get; set; }

    public int IdProduct { get; set; }

    public double MaterialCount { get; set; }

    public virtual Material IdMaterialNavigation { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;
}
