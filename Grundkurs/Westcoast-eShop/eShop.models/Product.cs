namespace eShop.models;

public class Product
{
    public decimal Price { get; set; }
    public int ProductId { get; set; }
    public string? ProductName { get; set; }

    public override string ToString() => $"{ProductId} {ProductName} {Price}";
}
