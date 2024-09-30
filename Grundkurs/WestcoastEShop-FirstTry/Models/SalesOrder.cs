namespace Westcoast_EShop.Models;

public class SalesOrder
{
    public DateTime OrderDate { get; set; }
    public int OrderId { get; set; }
    public Customer? Customer { get; set; }
}
