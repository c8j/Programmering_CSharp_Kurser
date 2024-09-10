using InvoiceApp;

//Skapa ett objekt ifrån klassen Invoice
Invoice invoice = new();

Console.WriteLine(invoice);

/* Fakturans Basinformation  */
//invoice.InvoiceNumber = 1;
//invoice.InvoiceDate = DateTime.Now;
//invoice.DueDate = DateTime.Now.AddDays(invoice.PaymentTerms);

/* Kund information */
invoice.CustomerNumber = 981256;
invoice.CustomerName = "Bosse Kofot";
invoice.CustomerAddress = "Rånarvägen 1";
invoice.CustomerPostalCode = "666 78";
invoice.CustomerCity = "Härlanda";
invoice.CustomerReference = "Sickan Karlsson";

/* Företags information */
invoice.SenderName = "Vanhedens järnhandel";
invoice.SenderAddress = "Stålgatan 14";
invoice.SenderPostalCode = "888 98";
invoice.SenderCity = "Hålan";
invoice.SenderPhone = "073-444222";
invoice.SenderReference = "Dynamit Harry";
invoice.SenderReferenceEmail = "harry@gmail.com";

invoice.AddItem(new InvoiceItem(1, "Kofot", 149.00M, 4));
invoice.AddItem(new InvoiceItem(2, "Slägga", 1095.00M, 1));
Console.WriteLine(invoice);
Console.WriteLine("Fakturarader:");
invoice.ListItems();
