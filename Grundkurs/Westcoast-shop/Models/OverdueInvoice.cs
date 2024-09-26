namespace Westcoast_shop.Models;

public class OverdueInvoice(int senderID, int customerID, int invoiceNumber) : Invoice(senderID, customerID, invoiceNumber)
{
    /* PROPERTIES */
    public decimal Interest { get; } = 0.25M;
    public decimal Charge
    {
        get
        {
            return Interest * TotalValue;
        }
    }

    /* METHODS */
    public override string ToString()
    {
        return base.ToString() +
        "\n" +
        $"Obetald: {TotalValue}, Avgift: {Charge}, Nytt totalt: {TotalValue + Charge}";
    }
}
