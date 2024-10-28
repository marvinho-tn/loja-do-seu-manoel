namespace Store.Domain.Entities;

public class Order
{
    public uint Id { get; set; }
    public List<Product> Products { get; set; } = [];
    public List<Box> Boxes { get; set; } = [];
    
    public bool IsBoxed(Product product) => 
        Boxes.Any(box => box.Products.Any(boxedProduct => boxedProduct.Equals(product)));

    public void Box(Product product, Box box)
    {
        box.Products.Add(product);

        if (!Boxes.Any(orderBox => orderBox.Equals(box)))
        {
            Boxes.Add(box);
        }
    }
    
    public void Box(List<Product> products, Box box)
    {
        foreach (var product in products)
        {
            Box(product, box);
        }
    }
}