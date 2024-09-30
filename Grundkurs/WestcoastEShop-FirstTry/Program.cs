using Westcoast_EShop.Models;
using System.Text.Json;
using System.Text.Encodings.Web;

var salesOrder = new SalesOrder
{
    OrderDate = DateTime.Now,
    OrderId = 23
};

salesOrder.Customer = new Customer
{
    CustomerId = 12,
    CreatedAt = DateTime.Now,
    LastBuy = DateTime.Now,
    FirstName = "John",
    LastName = "Smith",
    AddressLine = "Storgatan 8",
    PostalCode = "123 45",
    City = "Storstad"
};

var jsonOptions = new JsonSerializerOptions
{
    WriteIndented = true,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
};

var path = $"{Environment.CurrentDirectory}/data/salesOrder.json";

var jsonText = JsonSerializer.Serialize(salesOrder, jsonOptions);

File.WriteAllText(path, jsonText);
