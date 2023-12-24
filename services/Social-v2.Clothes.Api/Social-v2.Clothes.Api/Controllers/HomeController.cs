using Microsoft.AspNetCore.Mvc;

namespace Social_v2.Clothes.Api.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("~/swagger");
        }
    }
}
