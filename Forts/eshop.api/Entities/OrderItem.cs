using System.ComponentModel.DataAnnotations.Schema;

namespace eshop.api.Entities;

public class OrderItem
{
    public int OrderID { get; set; }
    public int ProductID { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }

    [ForeignKey("OrderID")]
    public SalesOrder SalesOrder { get; set; }
    [ForeignKey("ProductID")]
    public Product Product { get; set; }
}
