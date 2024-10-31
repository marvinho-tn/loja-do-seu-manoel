namespace Store.Domain.Entities;

/// <summary>
/// Classe de representação de objetos dimensionáveis.
/// </summary>
public class Measurable
{
    /// <summary>
    /// Largura do objeto.
    /// </summary>
    public uint Width { get; set; }
    
    /// <summary>
    /// Altura do objeto.
    /// </summary>
    public uint Height { get; set; }
    
    /// <summary>
    /// Comprimento do objeto.
    /// </summary>
    public uint Length { get; set; }

    /// <summary>
    /// Volume do objeto.
    /// </summary>
    public uint Volume => Height * Width * Length;
}