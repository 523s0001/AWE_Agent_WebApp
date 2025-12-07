using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AWE_Agent_WebApp.Models;

namespace AWE_Agent_WebApp.Controllers
{
    public class CheckoutController : Controller
    {
        // 🟦 1. Trang Checkout (Shipping)
        public ActionResult Index()
        {
            var cart = Session["Cart"] as List<CartItem> ?? new List<CartItem>();
            return View(cart);
        }

        // 🟦 2. Nhận dữ liệu Shipping từ form
        [HttpPost]
        public ActionResult SubmitShipping(FormCollection form)
        {
            // (bạn có thể lưu shipping info vào session nếu muốn)
            return RedirectToAction("Payment");
        }

        // 🟩 3. TRANG PAYMENT (BẠN THÊM ACTION NÀY)
        public ActionResult Payment()
        {
            var cart = Session["Cart"] as List<CartItem> ?? new List<CartItem>();
            return View(cart);
        }

        // 🟩 4. Xử lý khi nhấn nút Complete Payment (THÊM ACTION NÀY)
        [HttpPost]
        public ActionResult CompleteOrder()
        {
            // Clear giỏ hàng sau khi thanh toán
            Session["Cart"] = null;

            return RedirectToAction("OrderSuccess");
        }

        // 🟩 5. Trang báo hoàn tất đơn hàng (THÊM ACTION NÀY)
        public ActionResult OrderSuccess()
        {
            return View();
        }
    }
}
