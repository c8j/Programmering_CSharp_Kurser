using eShop.models;
using Microsoft.AspNetCore.Mvc;

namespace eShop.web.Controllers;

public class OrdersController : Controller
{
    private List<SalesOrder>? _salesOrders = [];
    private readonly IWebHostEnvironment _environment;

    public OrdersController(IWebHostEnvironment environment)
    {
        _environment = environment;
        var root = _environment.WebRootPath;
        var path = root + "/Data/orders.json";
        GetOrders(path);
    }

    // GET: OrdersController
    public ActionResult Index()
    {
        return View(_salesOrders);
    }

    private void GetOrders(string path)
    {
        _salesOrders = Storage.ReadOrdersFromFile(path);
    }

}
