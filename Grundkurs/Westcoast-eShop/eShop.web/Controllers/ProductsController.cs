using eShop.models;
using Microsoft.AspNetCore.Mvc;

namespace eShop.web.Controllers;

public class ProductsController : Controller
{
    private readonly IWebHostEnvironment _environment;
    private readonly List<Product> _products;

    public ProductsController(IWebHostEnvironment environment)
    {
        _environment = environment;
        var root = _environment.WebRootPath;
        var path = root + "/Data/products.json";
        _products = GetProducts(path) ?? [];
    }

    public IActionResult Index()
    {
        return View(_products);
    }

    private static List<Product>? GetProducts(string path)
    {
        return Storage.ReadProductsFromFile(path);
    }
}
