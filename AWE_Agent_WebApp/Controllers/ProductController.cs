using System.Web.Mvc;
using AWE_Agent_WebApp.DAL;

namespace AWE_Agent_WebApp.Controllers
{
    public class ProductController : Controller
    {
        ProductDAL dal = new ProductDAL();

        public ActionResult Index()
        {
            var list = dal.GetAll();
            return View(list);
        }
    }
}
