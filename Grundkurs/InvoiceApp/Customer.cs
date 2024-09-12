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
        try
        {
            PaymentTerms = Database.FindPaymentTerms(id);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            PaymentTerms = 14;
        }
    }
}
