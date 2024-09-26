namespace Westcoast_shop.Models;

public class Person(int id)
{
    /* PROPERTIES */
    public ContactDetails ContactDetails { get; } = Database.FindContactDetails(id);

    /* METHODS */
    public override string ToString() => $"Namn: {ContactDetails.Name}, Adress: {ContactDetails.Address}";
}
