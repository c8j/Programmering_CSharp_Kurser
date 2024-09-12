using InvoiceApp;

//Skapa ett objekt ifrån klassen Invoice
Invoice invoice =
    new()
    {
        /* Fakturans Basinformation  */
        //invoice.InvoiceNumber = 1;
        //invoice.InvoiceDate = DateTime.Now;
        //invoice.DueDate = DateTime.Now.AddDays(invoice.PaymentTerms);

        /* Kund information */
        CustomerNumber = 981256,
        CustomerName = "Bosse Kofot",
        CustomerAddress = "Rånarvägen 1",
        CustomerPostalCode = "666 78",
        CustomerCity = "Härlanda",
        CustomerReference = "Sickan Karlsson",

        /* Företags information */
        SenderName = "Vanhedens järnhandel",
        SenderAddress = "Stålgatan 14",
        SenderPostalCode = "888 98",
        SenderCity = "Hålan",
        SenderPhone = "073-444222",
        SenderReference = "Dynamit Harry",
        SenderReferenceEmail = "harry@gmail.com",
    };


try
{
    invoice.AddItem(new InvoiceItem(new Product(1), 4));
    invoice.AddItem(new InvoiceItem(new Product(2), 1));
    invoice.AddItem(new InvoiceItem(new Product(3), 2));
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
