namespace Store.Domain.Entities;

public class Box : Measurable
{
    public Box(BoxMold boxMold = null)
    {
        Width = boxMold?.Width ?? 0;
        Height = boxMold?.Height ?? 0;
        Length = boxMold?.Length ?? 0;
        Id = $"Caixa {Width}x{Height}x{Length}";
    }
    
    public string Id { get; set; }
    public List<Product> Products { get; set; } = [];
    
    public long RemainderVolume => Volume - Products.Sum(p => p.Dimensions.Volume);

    public bool AllProductsFit(List<Product> products)
    {
        return RemainderVolume >= products.Sum(p => p.Dimensions.Volume);
    }

    public bool OfType(BoxMold boxMold)
    {
        return boxMold.Height == Height && boxMold.Width == Width && boxMold.Length == Length;
    }
}