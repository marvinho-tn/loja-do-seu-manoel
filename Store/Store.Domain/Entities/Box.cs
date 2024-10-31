namespace Store.Domain.Entities;

/// <summary>
/// Objeto de representação da caixa.
/// </summary>
public class Box : Measurable
{
    /// <summary>
    /// Construtor da caixa a partir ou não de um molde.
    /// </summary>
    /// <param name="boxMold">Molde da caixa.</param>
    public Box(BoxMold boxMold = null)
    {
        Width = boxMold?.Width ?? 0;
        Height = boxMold?.Height ?? 0;
        Length = boxMold?.Length ?? 0;
        Id = $"Caixa {Width}x{Height}x{Length}";
    }
    
    /// <summary>
    /// Identificação da caixa
    /// </summary>
    public string Id { get; set; }
    
    /// <summary>
    /// Produtos contidos na caixa.
    /// </summary>
    public List<Product> Products { get; set; } = [];
    
    /// <summary>
    /// Volume disponível na caixa.
    /// </summary>
    public long RemainderVolume => 
        Volume - Products.Sum(p => p.Dimensions.Volume);

    /// <summary>
    /// Verifica se os produtos cabem na caixa.
    /// </summary>
    /// <param name="products">Listagem de produtos a ser verificada.</param>
    /// <returns>Resultado da verificação.</returns>
    public bool AllProductsFit(List<Product> products) => 
        RemainderVolume >= products.Sum(p => p.Dimensions.Volume);

    /// <summary>
    /// Verifica se a caixa é do tipo do molde.
    /// </summary>
    /// <param name="boxMold">Molde a ser verificado.</param>
    /// <returns>Resultado da verificação.</returns>
    public bool OfType(BoxMold boxMold) => 
        boxMold.Height == Height && boxMold.Width == Width && boxMold.Length == Length;
}