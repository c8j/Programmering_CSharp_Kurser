namespace InvoiceApp;

public class InvoiceItem
{
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public int Amount { get; set; }
    public decimal RowAmount { get; set; }

    public InvoiceItem()
    {
        ProductName = "";
    }

    public InvoiceItem(int productID, string productName, decimal price, int amount)
    {
        ProductID = productID;
        ProductName = productName;
        Price = price;
        Amount = amount;
        RowAmount = price * amount;
    }
}
