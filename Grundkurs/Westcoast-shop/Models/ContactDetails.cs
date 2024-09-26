namespace Westcoast_shop.Models;

public class ContactDetails
{
    /* PROPERTIES */
    public string Name { get; set; } = "";
    public required Address Address { get; set; }
    public string Phone { get; set; } = "";
    public string Reference { get; set; } = "";
    public string ReferenceEmail { get; set; } = "";

    /* TODO: Add proper validation for each property */
}
