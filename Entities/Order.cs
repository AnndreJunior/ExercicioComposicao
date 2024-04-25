using System.Globalization;
using System.Text;
using Exercicio.Entities.Enums;

namespace Exercicio.Entities;

public class Order
{
    public DateTime Moment { get; private set; } = DateTime.Now;
    public OrderStatus Status { get; private set; }
    public List<OrderItem> OrderItems { get; private set; } = [];
    public Client Client { get; private set; }

    public Order(OrderStatus status, Client client)
    {
        Status = status;
        Client = client;
    }

    public void AddItem(OrderItem item)
    {
        OrderItems.Add(item);
    }

    public void RemoveItem(OrderItem item)
    {
        OrderItems.Remove(item);
    }

    public double Total()
    {
        double total = 0;

        foreach (OrderItem item in OrderItems)
            total += item.SubTotal();

        return total;
    }

    public override string ToString()
    {
        StringBuilder orderToString = new();

        CultureInfo brazilCulture = CultureInfo.CreateSpecificCulture("pt-BR");

        orderToString.AppendLine($"Oder moment: {Moment.ToString("dd/MM/yyyy hh:mm:ss")}");
        orderToString.AppendLine($"Order status: {Status}");
        orderToString.AppendLine(Client.ToString());
        orderToString.AppendLine("Order items:");

        foreach (OrderItem item in OrderItems)
            orderToString.AppendLine(item.ToString());
        orderToString.AppendLine($"Total price: {Total().ToString("C", brazilCulture)}");

        return orderToString.ToString();
    }
}
