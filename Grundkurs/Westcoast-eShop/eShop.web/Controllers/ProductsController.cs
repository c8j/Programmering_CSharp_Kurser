using Microsoft.AspNetCore.Mvc;

namespace eShop.web.Controllers;

public class ProductsController : Controller
{

    public IActionResult Index()
    {
        return View();
    }
}
