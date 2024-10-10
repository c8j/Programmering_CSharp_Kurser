namespace eShop.models;

public class Product
{
    public decimal Price { get; set; }
    public int ID { get; set; }
    public string? Name { get; set; }

    public override string ToString() => $"{ID} {Name} {Price}";
}
