using System.Text.Encodings.Web;
using System.Text.Json;
using ReadingWritingJsonFiles;

Person person = new()
{
    FirstName = "John",
    LastName = "Smith",
    Age = 30,
    Phone = "0462738291",
    Email = "johnsmith@gmail.com",
    Address = {
        AddressLine = "Tunavägen 12",
        PostalCode = "145 67",
        City = "Lund"
    }
};

Console.WriteLine(person);
var path = $"{Environment.CurrentDirectory}/data/person.json";
#pragma warning disable CA1869 // Cache and reuse 'JsonSerializerOptions' instances
var jsonOption = new JsonSerializerOptions
{
    WriteIndented = true,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
};
#pragma warning restore CA1869 // Cache and reuse 'JsonSerializerOptions' instances
var json = JsonSerializer.Serialize(person, jsonOption);
File.WriteAllText(path, json);
