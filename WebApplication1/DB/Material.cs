using System;
using System.Collections.Generic;

namespace WebApplication1.DB;

public partial class Material
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int MaterialTypeId { get; set; }

    public decimal Price { get; set; }

    public double StorageCount { get; set; }

    public double MinCount { get; set; }

    public double PackCount { get; set; }

    public int MetricaId { get; set; }

    public virtual MaterialType MaterialType { get; set; } = null!;

    public virtual Metrika Metrica { get; set; } = null!;
}
