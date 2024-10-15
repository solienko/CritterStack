namespace CritterStack.Modules.Customers.Domain;

public class Customer
{
    public Guid Id { get; set; }
    public string Name { get; private set; } = string.Empty;
    public Customer(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public void SetName(string name)
    {
        Name = name;
    }
}
