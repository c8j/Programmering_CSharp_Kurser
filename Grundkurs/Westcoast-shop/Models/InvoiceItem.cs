namespace Westcoast_shop.Models;

public class InvoiceItem(Product product, int numberOfItems)
{
    /* PROPERTIES */
    public Product Product { get; } = product;
    public int NumberOfItems { get; } = numberOfItems;
    public decimal TotalPrice
    {
        get { return NumberOfItems * Product.Price; }
    }

    /* METHODS */
    public override string ToString()
    {
        return $"{Product}, Antal: {NumberOfItems}, Totalt: {TotalPrice}";
    }
}
