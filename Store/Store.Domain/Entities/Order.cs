namespace Store.Domain.Entities;

/// <summary>
/// Classe de representação de um pedido.
/// </summary>
public class Order
{
    public Order()
    {
        
    }

    public Order(bool newObj)
    {
        Id = newObj ? Guid.NewGuid() : null;
    }

    /// <summary>
    /// Identificação do pedido.
    /// </summary>
    public Guid? Id { get; set; }
    
    /// <summary>
    /// Produtos do pedido.
    /// </summary>
    public List<Product> Products { get; set; } = [];
    
    /// <summary>
    /// Caixas utilizadas no pedido.
    /// </summary>
    public List<Box> Boxes { get; set; } = [];
    
    /// <summary>
    /// Verifica se o produto já está encaixotado no pedido.
    /// </summary>
    /// <param name="product">Produto a ser verificado.</param>
    /// <returns>Resultado da verificação.</returns>
    public bool IsBoxed(Product product) => 
        Boxes.Any(box => box.Products.Any(boxedProduct => boxedProduct.Equals(product)));

    /// <summary>
    /// Realiza encaixotamento de um produto.
    /// </summary>
    /// <param name="product">Produto a ser encaixotado.</param>
    /// <param name="box">Caixa para encaixotar.</param>
    public void Box(Product product, Box box)
    {
        box.Products.Add(product);

        if (!Boxes.Any(orderBox => orderBox.Equals(box)))
        {
            Boxes.Add(box);
        }
    }
    
    /// <summary>
    /// Realiza encaixotamento de produtos.
    /// </summary>
    /// <param name="products">Produtos a serem encaixotados.</param>
    /// <param name="box">Caixa para encaixotar.</param>
    public void Box(List<Product> products, Box box)
    {
        foreach (var product in products)
        {
            Box(product, box);
        }
    }
}