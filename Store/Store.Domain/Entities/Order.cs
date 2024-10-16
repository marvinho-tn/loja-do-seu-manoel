namespace Store.Domain.Entities;

public class Order(bool newOrder = false)
{
    public Guid? Id { get; set; } = newOrder ? Guid.NewGuid() : null;
    public List<Product> Products { get; set; } = [];
    public List<Box> Boxes { get; set; } = [];
    
    public bool IsBoxed(Product product) => Boxes.Any(box => box.Products.Any(boxedProduct => boxedProduct.Equals(product)));

    public void Box(Product product, Box box)
    {
        box.Products.Add(product);

        if (!Boxes.Any(orderBox => orderBox.Equals(box)))
        {
            Boxes.Add(box);
        }
    }
    
    public void Box(List<Product> product, Box box)
    {
        box.Products.AddRange(product);

        if (!Boxes.Any(orderBox => orderBox.Equals(box)))
        {
            Boxes.Add(box);
        }
    }
}