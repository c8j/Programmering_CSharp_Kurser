namespace InvoiceApp;

public class Invoice
{
    /* PROPERTIES */
    //Base info
    public int InvoiceNumber { get; }
    public DateTime InvoiceDate { get; }
    public DateTime DueDate { get; }
    public decimal TotalValue { get; private set; }

    //Sender(Company) info
    public string SenderName { get; set; }
    public string SenderAddress { get; set; }
    public string SenderPostalCode { get; set; }
    public string SenderCity { get; set; }
    public string SenderPhone { get; set; }
    public string SenderReference { get; set; }
    public string SenderReferenceEmail { get; set; }

    /* Customer Info */
    public int CustomerNumber { get; set; }
    public string CustomerName { get; set; }
    public string CustomerAddress { get; set; }
    public string CustomerPostalCode { get; set; }
    public string CustomerCity { get; set; }
    public string CustomerReference { get; set; }
    public int PaymentTerms { get; }

    /* Fakturans rader */
    public List<InvoiceItem> InvoiceItems { get; }

    /* CONSTRUCTORS */
    public Invoice()
    {
        SenderName = "";
        SenderAddress = "";
        SenderPostalCode = "";
        SenderCity = "";
        SenderPhone = "";
        SenderReference = "";
        SenderReferenceEmail = "";
        CustomerName = "";
        CustomerAddress = "";
        CustomerPostalCode = "";
        CustomerCity = "";
        CustomerReference = "";

        //Generera fakturanummer
        InvoiceNumber = new Random().Next(10000, 33001);

        //Sätt betalningsvilkor
        PaymentTerms = 30;

        //Skapa fakturadatum
        InvoiceDate = DateTime.Now;

        //Räkna fram förfallodatum
        DueDate = InvoiceDate.AddDays(PaymentTerms);

        //Initiera listan av fakturarader
        InvoiceItems = [];
    }

    /* METHODS */
    public override string ToString()
    {
        return $"Fakturanummer: {InvoiceNumber} - Fakturadatum: {InvoiceDate} - Förfallodatum: {DueDate} - Kund: {CustomerName} - Totalt: {TotalValue}";
    }

    public void AddItem(InvoiceItem invoiceItem)
    {
        InvoiceItems.Add(invoiceItem);
        TotalValue += invoiceItem.RowPrice;
    }

    public void ListItems()
    {
        foreach (var invoiceItem in InvoiceItems)
        {
            Console.WriteLine(invoiceItem);
        }
    }
}
