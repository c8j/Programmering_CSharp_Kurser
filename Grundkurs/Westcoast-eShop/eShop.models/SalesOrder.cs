namespace eShop.models;

public class SalesOrder
{
    public Customer? Customer { get; set; }
    public DateTime OrderDate { get; set; }
    public int OrderId { get; set; }
    public List<OrderItem>? OrderItems { get; set; }
    public decimal TotalPrice
    {
        get
        {
            if (OrderItems is null)
            {
                return 0;
            }
            return OrderItems.Sum(item => item.TotalPrice);
        }
    }

    public override string ToString() => $"{OrderId} {OrderDate.ToShortDateString()} {Customer} {TotalPrice}";
}
