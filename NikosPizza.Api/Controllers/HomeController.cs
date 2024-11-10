using Microsoft.AspNetCore.Mvc;

namespace NikosPizza.Api.Controllers
{
    public class HomeController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    

    }
}
