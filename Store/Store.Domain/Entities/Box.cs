namespace Store.Domain.Entities;

public class Box : Measurable
{
    public Guid Id { get; set; }
    public List<Product> Products { get; set; }
}