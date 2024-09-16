namespace InvoiceApp;

public class ContactDetails
{
    /* PROPERTIES */
    public string Name { get; set; } = "";
    public Address Address { get; } = new();
    public string Phone { get; set; } = "";
    public string Reference { get; set; } = "";
    public string ReferenceEmail { get; set; } = "";

    /* TODO: Add proper validation for each property */
}
