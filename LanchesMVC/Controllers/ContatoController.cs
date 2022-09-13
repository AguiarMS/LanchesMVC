using Microsoft.AspNetCore.Mvc;

namespace LanchesMVC.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
