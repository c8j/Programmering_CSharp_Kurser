using System.Text.Encodings.Web;
using System.Text.Json;

namespace eShop.Models;

public static class Storage
{
    private static readonly JsonSerializerOptions s_jsonOptions = new()
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };

    private static readonly string s_path = $"{Environment.CurrentDirectory}/data/orders.json";

    public static void SaveOrdersToFile(List<SalesOrder> orders)
    {
        File.WriteAllText(s_path, JsonSerializer.Serialize(orders, s_jsonOptions));
    }

    public static List<SalesOrder>? ReadOrdersFromFile()
    {
        return JsonSerializer.Deserialize<List<SalesOrder>>(File.ReadAllText(s_path), s_jsonOptions);
    }
}
