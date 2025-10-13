namespace WebApplication1.CQRS.CommandList
{
    public class MaterialDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int MaterialTypeId { get; set; }
        public string MaterialType { get; set; }
        public decimal Price { get; set; }
        public double StorageCount { get; set; }
        public double MinCount { get; set; }
        public double PackCount { get; set; }
        public int MetricaId { get; set; }
        public string Metrica { get; set; }
    }
}
