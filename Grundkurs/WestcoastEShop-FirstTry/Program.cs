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

var salesOrder1 = new SalesOrder
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

var orders = new List<SalesOrder>
{
    salesOrder1,
    new() {
        OrderDate = DateTime.Now,
        OrderId = 26,
        Customer = new Customer
        {
            CustomerId = 19,
            CreatedAt = DateTime.Now,
            LastBuy = DateTime.Now,
            FirstName = "James",
            LastName = "Cameron",
            AddressLine = "Lillagatan 80",
            PostalCode = "123 54",
            City = "Lillastad"
        },
        OrderItems =
        [
            new OrderItem
            {
                Product = product1,
                Quantity = 5,
                Discount = 0.2M
            },
            new OrderItem
            {
                Product = product2,
                Quantity = 10,
                Discount = 0.5M
            }
        ]
    }
};

var jsonOptions = new JsonSerializerOptions
{
    WriteIndented = true,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
};

var path = $"{Environment.CurrentDirectory}/data/orders.json";

var jsonText = JsonSerializer.Serialize(orders, jsonOptions);

File.WriteAllText(path, jsonText);

/* using (var sw = new StreamWriter(path))
{
    foreach (SalesOrder order in orders)
    {
        var jsonText = JsonSerializer.Serialize(order, jsonOptions);
        sw.WriteLine(jsonText);
    }
} */
