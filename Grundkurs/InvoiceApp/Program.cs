using InvoiceApp;

try
{
    //Skapa ett objekt ifrån klassen Invoice
    Invoice invoice = new(0, 981256);
    invoice.AddItem(1, 4);
    invoice.AddItem(2, 1);
    //invoice.AddItem(3, 2);
    Console.WriteLine(invoice);
    Console.WriteLine("Fakturarader:");
    invoice.ListItems();
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}
catch (Exception)
{
    Console.WriteLine("Något blev fel");
}
