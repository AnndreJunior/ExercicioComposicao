using System.Globalization;
using Exercicio.Entities;
using Exercicio.Entities.Enums;

Console.Clear();

CultureInfo brazilCulture = CultureInfo.CreateSpecificCulture("pt-BR");

Console.WriteLine("Enter client data:");

Console.Write("Name: ");
string name = Console.ReadLine() ?? "";

Console.Write("Email: ");
string email = Console.ReadLine() ?? "";

Console.Write("Birth date(DD/MM/YYYY): ");
DateTime birthDate = DateTime.Parse(Console.ReadLine() ?? "", brazilCulture);

Client client = new(name, email, birthDate);

Console.WriteLine("Enter order data:");
OrderStatus orderStatus = OrderStatus.Processing;

Order order = new(orderStatus, client);

Console.WriteLine("How many items to this order? ");
int quantityOrder = int.Parse(Console.ReadLine() ?? "");

for (int i = 1; i <= quantityOrder; i++)
{
    Console.WriteLine($"Enter #{i} data:");

    Console.Write("Product name: ");
    string porductName = Console.ReadLine() ?? "";

    Console.Write("Product price: ");
    double productPrice = double.Parse(Console.ReadLine() ?? "");

    Console.Write("Quantity: ");
    int quantity = int.Parse(Console.ReadLine() ?? "");

    Product product = new(porductName, productPrice);

    OrderItem orderItem = new(quantity, product);

    order.AddItem(orderItem);

    double subTotal = orderItem.SubTotal();
}

Console.Clear();

Console.WriteLine("ORDER SUMMARY");
Console.WriteLine("");

Console.Write(order);
