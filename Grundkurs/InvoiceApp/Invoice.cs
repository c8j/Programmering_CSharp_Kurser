namespace InvoiceApp;

public class Invoice
{
    /* PROPERTIES */
    //Base info
    public int InvoiceNumber { get; set; }
    public DateTime InvoiceDate { get; set; }
    public DateTime DueDate { get; set; }
    public decimal TotalValue { get; set; }

    //Sender(Company) info
    public string SenderName { get; set; }
    public string SenderAddress { get; set; }
    public string SenderPostalCode { get; set; }
    public string SenderCity { get; set; }
    public string SenderPhone { get; set; }
    public string SenderReference { get; set; }
    public string SenderReferenceEmail { get; set; }
}
