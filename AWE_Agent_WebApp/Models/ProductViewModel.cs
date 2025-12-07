namespace AWE_Agent_WebApp.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }
        public double Rating { get; set; }
        public int Reviews { get; set; }
        public string SKU { get; set; }
        public string Category { get; set; }
        public string ImagePath { get; set; }
    }
}
