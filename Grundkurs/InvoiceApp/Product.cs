namespace InvoiceApp;

public class Product
{
    /* PROPERTIES */
    public int ID { get; init; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }

    /* CONSTRUCTORS */
    public Product(int id)
    {
        Name = "";
        ID = id;
        FindProduct();
    }

    /* METHODS */
    public override string ToString()
    {
        return $"Artikel ID: {ID}, Produktnamn: {Name}, Pris/st: {Price}";
    }

    /* PRIVATE METHODS */
    private void FindProduct()
    {
        if (ID == 1)
        {
            Name = "Kofot";
            Price = 149M;
        }
        else if (ID == 2)
        {
            Name = "Slägga";
            Price = 1095M;
        }
        else
        {
            throw new ArgumentException($"Kunde inte hitta produkt med ID: {ID}");
        }
    }
}
