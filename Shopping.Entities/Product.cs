namespace Shopping.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal CostPrice { get; set; }
        public decimal? SellingPrice { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
    }
}