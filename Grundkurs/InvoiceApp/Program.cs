using InvoiceApp;

//Skapa ett objekt ifrån klassen Invoice
Invoice invoice = new(0, 98156);

try
{
    invoice.AddItem(1, 4);
    invoice.AddItem(2, 1);
    invoice.AddItem(3, 2);
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}
catch (Exception)
{
    Console.WriteLine("Något blev fel");
}

Console.WriteLine(invoice);
Console.WriteLine("Fakturarader:");
invoice.ListItems();
