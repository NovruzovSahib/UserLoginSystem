using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UserLoginSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index2()
        {
            return Content("Index2 page");
        }
        [AllowAnonymous]
        public IActionResult ShowInformation()
        {
            return Content("Product Information");
        }
    }
}
