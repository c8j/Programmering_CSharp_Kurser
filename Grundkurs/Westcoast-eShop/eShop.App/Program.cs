using eShop.Models;

List<SalesOrder>? orders = Storage.ReadOrdersFromFile();

if (orders is not null)
{
    foreach (SalesOrder order in orders)
    {
        Console.WriteLine(order);
    }

    Storage.SaveOrdersToFile(orders);
}
