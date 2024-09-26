using Microsoft.AspNetCore.Mvc;
using Westcoast_shop.Models;

namespace Westcoast_shop.Controllers;

public class InvoiceController : Controller
{
    // GET: InvoiceController
    public ActionResult Index()
    {
        SaleOrder order = new(981256);
        order.AddItem(1, 4);
        order.AddItem(2, 1);
        Invoice invoice = order.CreateInvoice(0);

        return View(invoice);
    }

}
