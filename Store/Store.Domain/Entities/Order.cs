namespace Store.Domain.Entities;

public class Order(bool newOrder = false)
{
    public Guid? Id { get; set; } = newOrder ? Guid.NewGuid() : null;
    public List<Product> Products { get; set; } = [];
    public List<Box> Boxes { get; set; } = [];
}