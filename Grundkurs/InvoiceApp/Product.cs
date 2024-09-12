namespace InvoiceApp;

public class Product(int ID, string name, decimal price)
{
    /* PROPERTIES */
    public int ID { get; init; } = ID;
    public string Name { get; init; } = name;
    public decimal Price { get; init; } = price;

    /* METHODS */
    public override string ToString()
    {
        return $"ArtikelID: {ID}, Produktnamn: {Name}, Pris/st: {Price}";
    }
}
