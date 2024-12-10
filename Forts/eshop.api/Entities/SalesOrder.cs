namespace eshop.api.Entities;

public class SalesOrder
{
    public int ID { get; set; }
    public DateTime DateCreated { get; set; }

    public IList<OrderItem> OrderItems { get; set; }
}
