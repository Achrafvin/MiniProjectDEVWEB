using System.Web.Mvc;
using AppStore.Models;

namespace AppStore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
        
          return View(DbLocal.products);
        }

        
    }

    
}