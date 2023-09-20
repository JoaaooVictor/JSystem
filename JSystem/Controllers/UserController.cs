using Microsoft.AspNetCore.Mvc;

namespace JSystem.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
