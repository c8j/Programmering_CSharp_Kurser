namespace Westcoast_EShop.Models;

public class OrderItem
{
    public decimal Discount { get; set; }
    public Product? Product { get; set; }
    public decimal TotalPrice { get; set; }
    public int Quantity { get; set; }

    public override string ToString() => $"{Product} {Quantity} {TotalPrice}";
}
