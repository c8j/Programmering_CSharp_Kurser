using Microsoft.AspNetCore.Mvc;

namespace eShop.web.Controllers;

public class InvoicesController : Controller
{

    public ActionResult Index()
    {
        return View();
    }

    public ActionResult Create()
    {
        return View();
    }
}
