using Microsoft.AspNetCore.Mvc;
using Westcoast_shop.Models;

namespace Westcoast_shop.Controllers;

public class InvoiceController : Controller
{
    private readonly List<Invoice> _invoices = [];

    // GET: InvoiceController

    public InvoiceController()
    {

        for (int i = 0; i < 5; i++)
        {
            SaleOrder order = new(981256);
            order.AddItem(1, 4 + i);
            order.AddItem(2, 1 + i);
            _invoices.Add(order.CreateInvoice(0, i));
        }
    }
    public ActionResult Index()
    {
        return View(_invoices);
    }

    public ActionResult Details(int id)
    {
        return View(_invoices.Where(i => i.InvoiceNumber == id).FirstOrDefault());
    }

}
