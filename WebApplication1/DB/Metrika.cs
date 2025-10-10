using System;
using System.Collections.Generic;

namespace WebApplication1.DB;

public partial class Metrika
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();
}
