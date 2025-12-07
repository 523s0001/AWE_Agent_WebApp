using System.Web.Mvc;

namespace AWE_Agent_WebApp.Controllers
{
    public class AccountController : Controller
    {
        // GET: Login page
        public ActionResult Login()
        {
            return View();
        }

        // POST: Login submit
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            if (email == "admin@gmail.com" && password == "123456")
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Invalid email or password";
            return View();
        }
    }
}
