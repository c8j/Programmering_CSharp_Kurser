using Westcoast_EShop.Models;
using System.Text.Json;
using System.Text.Encodings.Web;

var salesOrder = new SalesOrder
{
    OrderDate = DateTime.Now,
    OrderId = 23
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
