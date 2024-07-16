namespace Entities.ModelDto
{
    public class ProductDto
    {
        public int IdProduct { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
