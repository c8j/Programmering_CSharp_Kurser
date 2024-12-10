using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

using eshop.api.Entities;

namespace eshop.api.Data;

public static class Seed
{

    private static readonly JsonSerializerOptions s_options = new()
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
        IncludeFields = true
    };

    public static async Task LoadProducts(DataContext context)
    {
        if (context.Products.Any()) return;
        var products = JsonSerializer.Deserialize<List<Product>>(File.ReadAllText("Data/json/products.json"), s_options);
        if (products is not null && products.Count > 0)
        {
            await context.Products.AddRangeAsync(products);
            await context.SaveChangesAsync();
        }
    }

    public static async Task LoadOrders(DataContext context)
    {
        if (context.SalesOrders.Any()) return;
        var orders = JsonSerializer.Deserialize<List<SalesOrder>>(File.ReadAllText("Data/json/orders.json"), s_options);
        if (orders is not null && orders.Count > 0)
        {
            await context.SalesOrders.AddRangeAsync(orders);
            await context.SaveChangesAsync();
        }
    }

    public static async Task LoadOrderItems(DataContext context)
    {
        if (context.OrderItems.Any()) return;
        var orderItems = JsonSerializer.Deserialize<List<OrderItem>>(File.ReadAllText("Data/json/orderItems.json"), s_options);
        if (orderItems is not null && orderItems.Count > 0)
        {
            await context.OrderItems.AddRangeAsync(orderItems);
            await context.SaveChangesAsync();
        }
    }
}
