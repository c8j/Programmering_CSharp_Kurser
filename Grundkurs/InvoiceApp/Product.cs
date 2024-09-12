namespace InvoiceApp;

public class Product
{
    /* PROPERTIES */
    public int ID { get; }
    public string Name { get; private set; } = "";
    public decimal Price { get; private set; }

    /* CONSTRUCTORS */
    public Product(int id)
    {
        ID = id;
        try
        {
            Database.FindProduct(ID, out string name, out decimal price);
            Name = name;
            Price = price;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    /* METHODS */
    public override string ToString()
    {
        return $"Artikel ID: {ID}, Produktnamn: {Name}, Pris/st: {Price}";
    }

    /* PRIVATE METHODS */

}
