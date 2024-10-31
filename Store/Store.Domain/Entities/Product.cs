namespace Store.Domain.Entities;

/// <summary>
/// Classe de representação do produto.
/// </summary>
public class Product
{
    /// <summary>
    /// Identificação do produto.
    /// </summary>
    public string Id { get; set; }
    
    /// <summary>
    /// Dimensões do produto.
    /// </summary>
    public Measurable Dimensions { get; set; }
}