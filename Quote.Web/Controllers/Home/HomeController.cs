using Microsoft.AspNetCore.Mvc;



namespace Quote.Web.Controllers.Home
{

    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index() => View(nameof(Index));
    }
}
