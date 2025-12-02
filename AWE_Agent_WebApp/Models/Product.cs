namespace AWE_Agent_WebApp.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string SKU { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockQty { get; set; }
        public string ShortDesc { get; set; }
        public int CategoryID { get; set; }
        public int BrandID { get; set; }
    }
}
