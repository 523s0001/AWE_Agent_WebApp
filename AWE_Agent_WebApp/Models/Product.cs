namespace AWE_Agent_WebApp.Models
{
    public class Product
    {
        // Các field mà DAL đang dùng (giữ nguyên / bổ sung)
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public int BrandID { get; set; }

        // Tên sản phẩm
        public string ProductName { get; set; }

        // Mô tả ngắn / dài
        public string ShortDesc { get; set; }
        public string FullDesc { get; set; }

        // Giá, tồn kho
        public decimal Price { get; set; }
        public int StockQty { get; set; }

        // Đường dẫn hình
        public string ImagePath { get; set; }

        // 👉 DAL đang đòi SKU nên mình thêm vào
        public string SKU { get; set; }

        // 👉 DAL cũng đòi Name, mình alias từ ProductName cho tiện
        public string Name
        {
            get { return ProductName; }
            set { ProductName = value; }
        }
    }
}
