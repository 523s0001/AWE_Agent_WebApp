using System.Web.Mvc;
using AWE_Agent_WebApp.Models;

namespace AWE_Agent_WebApp.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Details(int? id)
        {
            if (id == null)
                id = 1; // default demo product

            var vm = new ProductViewModel
            {
                Id = id.Value,
                Name = "Apple MacBook Air 13-inch - M2 / 8GB / 256GB",
                Description = "Powerful Apple M2 chip • 16-core Neural Engine • Lightweight 13-inch laptop.",
                Price = 849.00m,
                OldPrice = 999.00m,
                Rating = 4.9,
                Reviews = 4817,
                SKU = "MBA2024-M2",
                Category = "Apple",
                ImagePath = "/Images/apple_macbook.jpg"
            };

            return View(vm);
        }
    }
}
