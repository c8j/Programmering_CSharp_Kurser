namespace eShop.Models;

public class OrderItem
{
    public decimal Discount { get; set; }
    public Product? Product { get; set; }
    public decimal TotalPrice
    {
        get
        {
            if (Product != null)
            {
                var initialPrice = Product.Price * Quantity;
                return initialPrice - initialPrice * Discount;
            }
            return 0;
        }
    }
    public int Quantity { get; set; }

    public override string ToString() => $"{Product} {Quantity} {Discount} {TotalPrice}";
}
