using System.Globalization;

namespace Exercicio.Entities;

public class OrderItem
{
    public int Quantity { get; private set; }
    public double Price { get; private set; }
    public Product Product { get; private set; }

    public OrderItem(int quantity, Product product)
    {
        Quantity = quantity;
        Price = product.Price;
        Product = product;
    }

    public double SubTotal()
    {
        return Quantity * Price;
    }

    public override string ToString()
    {
        CultureInfo brazilCulture = CultureInfo.CreateSpecificCulture("pt-BR");

        return $"{Product.Name}, {Price.ToString("C", brazilCulture)}, quantity: {Quantity}, subtotal: {SubTotal().ToString("C", brazilCulture)}";
    }
}
