namespace Categorizer.Web.Controllers
{
    using System.Web.Mvc;

    public class CategoriesController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}