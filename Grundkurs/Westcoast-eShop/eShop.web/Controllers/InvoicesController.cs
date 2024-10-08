using Microsoft.AspNetCore.Mvc;

namespace eShop.web.Controllers;

public class InvoicesController : Controller
{

    public IActionResult Index()
    {
        return View();
    }
}
