namespace JSystem.Models
{
    public class BrandModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ProductModel Product { get; set; }
    }
}
