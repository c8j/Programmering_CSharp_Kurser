namespace InvoiceApp;

public class Person
{
    /* PROPERTIES */
    public ContactDetails ContactDetails { get; }

    /* CONSTRUCTORS */
    public Person(int id)
    {

        try
        {
            ContactDetails = Database.FindContactDetails(id);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            ContactDetails = new ContactDetails();
        }
    }
}
