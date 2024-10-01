using Westcoast_EShop.Models;
using System.Text.Json;
using System.Text.Encodings.Web;

var product1 = new Product
{
    ProductId = 1,
    ProductName = "Crowbar",
    Price = 400M
};

var product2 = new Product
{
    ProductId = 2,
    ProductName = "Hammer",
    Price = 200M
};

var orderItem1 = new OrderItem
{
    Product = product1,
    Quantity = 3,
    Discount = 0.1M
};

var orderItem2 = new OrderItem
{
    Product = product2,
    Quantity = 2
};

var salesOrder = new SalesOrder
{
    OrderDate = DateTime.Now,
    OrderId = 23,
    Customer = new Customer
    {
        CustomerId = 12,
        CreatedAt = DateTime.Now,
        LastBuy = DateTime.Now,
        FirstName = "John",
        LastName = "Smith",
        AddressLine = "Storgatan 8",
        PostalCode = "123 45",
        City = "Storstad"
    },
    OrderItems = [orderItem1, orderItem2]
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
