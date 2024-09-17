namespace InvoiceApp;

public class ProductItem(Product product, int numberOfItems)
{
    public Product Product { get; } = product;
    public int NumberOfItems { get; set; } = numberOfItems;
    public decimal TotalPrice
    {
        get
        {
            return NumberOfItems * Product.Price;
        }
    }

    /* METHODS */
    public override string ToString()
    {
        return $"{Product}, Antal: {NumberOfItems}, Totalt: {TotalPrice}";
    }
}
