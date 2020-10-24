using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Codesanook.EFCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly OrchardDbContext dbContext;

        public HomeController(OrchardDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ActionResult Index()
        {
            var books = dbContext.Books.ToList(); ;
            return View();
        }
    }
}
