using InvoiceApp;

try
{
    //Skapa ett objekt ifrån klassen Invoice
    SaleOrder order = new(981256);
    order.AddItem(1, 4);
    order.AddItem(2, 1);
    //invoice.AddItem(3, 2);
    Console.WriteLine(order);
    Console.WriteLine("Beställningrader:");
    order.ListItems();

    Invoice invoice = order.CreateInvoice(0);
    Console.WriteLine(invoice);

    //Skapa en fejk påminnelse
    OverdueInvoice reminder = new(0, 981256);
    reminder.AddItem(1, 4);
    reminder.AddItem(2, 1);

    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.WriteLine(reminder);
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}
catch (Exception)
{
    Console.WriteLine("Något blev fel");
}
