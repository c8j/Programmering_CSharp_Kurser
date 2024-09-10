using InvoiceApp;

//Skapa ett objekt ifrån klassen Invoice
Invoice invoice = new();

Console.WriteLine(invoice);

/* Fakturans Basinformation  */
invoice.InvoiceNumber = 1;
invoice.InvoiceDate = DateTime.Now;
invoice.PaymentTerms = 30;
invoice.DueDate = DateTime.Now.AddDays(invoice.PaymentTerms);

/* Kund information */
invoice.CustomerNumber = 981256;
invoice.CustomerName = "Bosse Kofot";
invoice.CustomerAddress = "Rånarvägen 1";
invoice.CustomerPostalCode = "666 78";
invoice.CustomerCity = "Härlanda";
invoice.CustomerReference = "Sickan Karlsson";

Console.WriteLine(invoice);
