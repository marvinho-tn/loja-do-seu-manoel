namespace Store.Domain.Entities;

public class Box : Measurable
{
    public Guid Id { get; set; }
    public List<Product> Products { get; set; } = [];
    
    public int RemainderVolume => Volume - Products.Sum(p => p.Volume);

    public bool AllProductsFit(List<Product> products)
    {
        return products.Sum(p => p.Volume) >= RemainderVolume;
    }
}