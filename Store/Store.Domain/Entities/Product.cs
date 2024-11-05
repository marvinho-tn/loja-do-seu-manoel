namespace Store.Domain.Entities;

/// <summary>
/// Classe de representação do produto.
/// </summary>
public class Product
{
    public Product()
    {
        
    }

    public Product(bool newObj)
    {
        Id = newObj ? Guid.NewGuid() : null;
    }

    /// <summary>
    /// Identificação do produto.
    /// </summary>
    public Guid? Id { get; set; }
    
    /// <summary>
    /// Dimensões do produto.
    /// </summary>
    public Dimensions Dimensions { get; set; }
}