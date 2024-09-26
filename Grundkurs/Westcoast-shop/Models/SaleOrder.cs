namespace Westcoast_shop.Models;

public class SaleOrder(int customerNumber)
{
    /* PROPERTIES */
    public Customer Customer { get; } = new Customer(customerNumber);
    public int SalesNumber { get; } = new Random().Next(10000, 33001);
    public DateTime PurchaseDate { get; } = DateTime.Now;
    public decimal TotalValue { get; private set; }
    public List<ProductItem> ProductItems { get; } = [];

    /* METHODS */
    public void AddItem(int productID, int numberOfItems)
    {
        ProductItems.Add(new ProductItem(new Product(productID), numberOfItems));
        TotalValue += ProductItems.Last().TotalPrice;
    }
    public void ListItems()
    {
        foreach (ProductItem productItem in ProductItems)
        {
            Console.WriteLine(productItem);
        }
    }

    public Invoice CreateInvoice(int senderID, int invoiceNumber)
    {
        return new Invoice(senderID, Customer.ID, invoiceNumber, this);
    }

    public override string ToString()
    {
        return $"Försäljningsnummer: {SalesNumber} - Försäljningsdatum: {PurchaseDate} Kund: {Customer.ID} ({Customer}) - Totalt: {TotalValue}";
    }
}
