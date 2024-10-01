namespace Westcoast_EShop.Models;

public class OrderItem
{
    public decimal Discount { get; set; }
    public Product? Product { get; set; }
    public decimal TotalPrice
    {
        get
        {
            return (Product != null) ? Product.Price * Quantity - Discount : 0;
        }
    }
    public int Quantity { get; set; }

    public override string ToString() => $"{Product} {Quantity} {Discount} {TotalPrice}";
}
