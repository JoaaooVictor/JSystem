namespace JSystem.Models
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public Guid BrandId { get; set; }
        public BrandModel Brand { get; set; }
    }
}
