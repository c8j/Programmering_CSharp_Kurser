using eShop.Models;

List<SalesOrder>? orders = Storage.ReadOrdersFromFile();

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

    Storage.SaveOrdersToFile(orders);
}
