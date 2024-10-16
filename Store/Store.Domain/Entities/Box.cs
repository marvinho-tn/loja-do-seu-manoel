namespace Store.Domain.Entities;

public class Box : Measurable
{
    public Box(BoxMold boxMold = null)
    {
        Width = boxMold?.Width ?? 0;
        Height = boxMold?.Height ?? 0;
        Length = boxMold?.Length ?? 0;
        Id = boxMold is not null ? Guid.NewGuid() : null;
    }
    
    public Guid? Id { get; set; }
    public List<Product> Products { get; set; } = [];
    
    public int RemainderVolume => Volume - Products.Sum(p => p.Volume);

    public bool AllProductsFit(List<Product> products)
    {
        return RemainderVolume >= products.Sum(p => p.Volume);
    }

    public bool OfType(BoxMold boxMold)
    {
        return boxMold.Height == Height && boxMold.Width == Width && boxMold.Length == Length;
    }
}