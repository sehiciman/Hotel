using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Redirekcija na stranicu prijave Identity
            return RedirectToPage("/Account/Login", new { area = "Identity" });
        }
    }
}