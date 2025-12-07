using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AWE_Agent_WebApp.Models;

namespace AWE_Agent_WebApp.Controllers
{
    public class ShoppingCartController : Controller
    {
        private List<CartItem> Cart
        {
            get
            {
                if (Session["Cart"] == null)
                    Session["Cart"] = new List<CartItem>();
                return (List<CartItem>)Session["Cart"];
            }
            set
            {
                Session["Cart"] = value;
            }
        }

        // Hiển thị giỏ hàng
        public ActionResult Index()
        {
            return View(Cart);
        }

        // Thêm sản phẩm vào giỏ
        public ActionResult Add(int id, string name, string category, string image, decimal price)
        {
            var item = Cart.FirstOrDefault(x => x.Id == id);

            if (item == null)
            {
                Cart.Add(new CartItem
                {
                    Id = id,
                    Name = name,
                    Category = category,
                    Image = image,
                    Price = price,
                    Quantity = 1
                });
            }
            else
            {
                item.Quantity++;
            }

            return RedirectToAction("Index");
        }

        // Tăng số lượng
        public ActionResult Increase(int id)
        {
            Cart.First(x => x.Id == id).Quantity++;
            return RedirectToAction("Index");
        }

        // Giảm số lượng
        public ActionResult Decrease(int id)
        {
            var item = Cart.First(x => x.Id == id);
            if (item.Quantity > 1)
                item.Quantity--;
            return RedirectToAction("Index");
        }

        // Xoá item
        public ActionResult Remove(int id)
        {
            Cart.RemoveAll(x => x.Id == id);
            return RedirectToAction("Index");
        }
    }
}
