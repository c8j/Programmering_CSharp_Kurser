using eShop.models;

string path = $"{Environment.CurrentDirectory}/data/orders.json";

List<SalesOrder>? orders = Storage.ReadOrdersFromFile(path);

if (orders is not null)
{
    foreach (SalesOrder order in orders)
    {
        Console.WriteLine(order);
        if (order.OrderItems is not null)
        {
            foreach (OrderItem item in order.OrderItems)
            {
                Console.WriteLine(item);
            }
        }
    }

    Storage.SaveOrdersToFile(path, orders);
}
