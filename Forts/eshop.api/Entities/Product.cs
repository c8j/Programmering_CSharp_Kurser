namespace eshop.api.Entities;

public class Product
{
    public int ID { get; set; }
    public string ItemNumber { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
}
