namespace InvoiceApp;

public class InvoiceItem(Product product, int numberOfItems)
{
    /* PROPERTIES */
    public Product Product { get; } = product;
    public int NumberOfItems { get; } = numberOfItems;
    public decimal RowPrice
    {
        get { return NumberOfItems * Product.Price; }
    }

    /* METHODS */
    public override string ToString()
    {
        return $"{Product}, Antal: {NumberOfItems}, Totalt: {RowPrice}";
    }
}
