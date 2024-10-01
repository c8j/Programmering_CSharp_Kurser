namespace Westcoast_EShop.Models;

public class SalesOrder
{
    public Customer? Customer { get; set; }
    public DateTime OrderDate { get; set; }
    public int OrderId { get; set; }
    public List<OrderItem>? OrderItems { get; set; }

    public override string ToString() => $"{OrderId} {OrderDate.ToShortDateString()} {Customer}";
}
