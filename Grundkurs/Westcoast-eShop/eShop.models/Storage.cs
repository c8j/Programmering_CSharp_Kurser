using System.Text.Encodings.Web;
using System.Text.Json;

namespace eShop.models;

public static class Storage
{
    private static readonly JsonSerializerOptions s_jsonOptions = new()
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };

    public static void SaveOrdersToFile(string path, List<SalesOrder> orders)
    {
        File.WriteAllText(path, JsonSerializer.Serialize(orders, s_jsonOptions));
    }

    public static List<SalesOrder>? ReadOrdersFromFile(string path)
    {
        return JsonSerializer.Deserialize<List<SalesOrder>>(File.ReadAllText(path), s_jsonOptions);
    }
}
