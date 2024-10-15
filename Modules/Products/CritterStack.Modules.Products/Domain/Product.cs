namespace CritterStack.Modules.Products.Domain;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public int Stock { get; private set; }

    public Product(Guid id, string name, decimal price, int stock)
    {
        Id = id;
        Name = name;
        Price = price;
        Stock = stock;
    }

    public void SetName(string name)
    {
        Name = name;
    }

    public void SetPrice(decimal price)
    {
        Price = price;
    }

    public void AddStock(int quantity)
    {
        Stock += quantity;
    }

    public void RemoveStock(int quantity)
    {
        Stock -= quantity;
    }

}
