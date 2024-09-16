namespace InvoiceApp;

public class Customer : Person
{
    /* PROPERTIES */
    public int ID { get; }
    public int PaymentTerms { get; }

    /* CONSTRUCTORS */
    public Customer(int id) : base(id)
    {
        ID = id;
        PaymentTerms = Database.FindPaymentTerms(id);
        PaymentTerms = 14;
    }
}
